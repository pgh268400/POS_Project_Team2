using System.Data.SQLite;
using System.Reflection;

namespace POS_Project_Team2.Class
{
    /*
      SQlite를 쉽게 사용하기 위한 DBMaster 객체의 설계도(class)
      이 객체 하나로 SQLite를 한번에 컨트롤 하기 위해 싱글톤으로 설계한다.

      싱글톤?
      게임 개발에서 주로 게임을 관리하는 매니저 계열의 클래스를 만들 때 적합하며, (딱 하나만 필요)
      사운드를 재생하려 할 때, 관련된 정보를 어디에서나 알게 하여 누구나 재생할 수 있도록 하기 위해(전역적 접근) 
      사용한다고 생각하면 된다. 여기서도 역시 SQL 매니저를 만들어 전역적으로 사용할 것이므로 싱글톤이 적합하다.
     */
    public class DBMaster
    {
        // 정적 인스턴스 변수
        private static DBMaster _instance;

        // lock 을 위해 사용하는 변수 (뮤텍스 변수 같은 것)
        private static readonly object _lock = new object();

        // 멤버 변수
        // 모든 table을 일괄적으로 저장할 db 파일
        private const string total_db_path = "total.db";

        // 해당 connection 변수를 이용해 db에 접근한다.
        // 첫 생성자때 연결이 이루어지며, 계속 유지하며 사용하다가 소멸자에서 연결을 끊는다.
        private SQLiteConnection connection;

        // 각 테이블들의 이름
        /*
         readonly 와 const 의 차이?
         const는 컴파일 시점에 값이 저장되는 상수
         readonly는 런타임 시점에 값이 저장되는 상수

         const : 선언과 동시에 초기화해야 하며, 이후에 변경할 수 없습니다.
         readonly : 선언 시 또는 클래스 생성자에서 초기화할 수 있으며, 초기화된 후에는 변경할 수 없습니다.

         readonly는 로그인 id를 객체에 담을 경우 같이, 객체 생성마다 값이 바뀌지만 이후 수정을 하면 안되는 경우에 사용하면 됩니다.
         const는 절대 변하지 않는 경우, 예를 들어 URI 값이라던가 규정된 연동 키값 등에 활용하면 됩니다.

         참고 : https://woojoolog.tistory.com/6
       */
        private const string user_table_name = "User",
            payment_table_name = "Payment",
            refund_table_name = "Refund",
            total_record_table_name = "TotalRecord",
            stock_table_name = "Stock",
            receipt_table_name = "Receipt";

        // 유저, 총 결제 내역, 환불 내역, 통합 기록 테이블, 등등 테이블의 (이름 : 타입) 묶어서 리스트로 저장

        private List<SQLiteTable> all_tables = new()
        {
            new SQLiteTable(user_table_name, typeof(UserRecord)),
            new SQLiteTable(payment_table_name, typeof(PayMentRefundRecord)),
            new SQLiteTable(refund_table_name, typeof(PayMentRefundRecord)),
            new SQLiteTable(total_record_table_name, typeof(TotalRecord)),
            new SQLiteTable(stock_table_name, typeof(StockRecord)),
            new SQLiteTable(receipt_table_name, typeof(ReceiptRecord))
        };

        // private 생성자 = 싱글톤으로 Instance 프로퍼티에 접근해서만 생성할 수 있게 제한한다.
        // 해당 생성자는 직접 호출이 불가하다.
        private DBMaster()
        {
            /*
              db 파일에 연결을 시도한다.
              참고로 SQLite는 connection 시 대응되는 db 파일이 없다면 알아서 자동 생성하니
              db 파일이 없어도 걱정하지 않아도 된다.
            */
            string connection_string = $"Data Source={total_db_path};Version=3;";

            /*
              SQLite DB 연결
              속도 저하를 막기 위해 연결을 유지할 것이기에, 자동으로 해제 시키는 using은 사용하지 않고 소멸자에서 Close 한다.
              매번 Open 하는 경우 db 파일을 열기 위해 File I/O 가 지속적으로 발생해서 성능이 떨어진다.
              어디에선가 줏어들은 기억으로는 일반적으로 DB에서 성능 저하가 가장 큰 부분(= 비용이 큰 부분)이 첫 접속이라고 한다.
            */
            connection = new SQLiteConnection(connection_string);
            connection.Open();

            // 기존에 유저, 재고 테이블이 있는지 확인한다.
            bool user_table_exist = is_table_exist(user_table_name);
            bool stock_table_exist = is_table_exist(stock_table_name);

            // db 파일 안에 table 들이 없다면 생성한다.
            foreach (var table in all_tables)
            {
                if (!is_table_exist(table.table_name))
                {
                    string create_table_query = generate_create_table_query(table.record_type, table.table_name, true);
                    create_table(create_table_query, table.table_name, true);
                }
            }

            // 유저 테이블이 존재하지 않았던 경우에만 기본 데이터 생성 (초기 1회만 실행)
            if (!user_table_exist)
                set_default_user_table_value();


            // 재고 테이블이 존재하지 않았던 경우에만 기본 데이터 생성 (초기 1회만 실행)
            if (!stock_table_exist)
                set_default_stock_table_value();
        }

        // 소멸자
        ~DBMaster()
        {
            // 소멸시 DB 연결을 끊는다.
            // 그 전까지 DB 연결은 유지된다.
            connection.Close();
        }

        // ======================================================================================================
        // DBMasterType에 정의된 DB의 타입을 스키마로 이용해 Table 쿼리를 생성한다.
        /*
          Class 타입을 참고해서 자동으로 테이블 생성 쿼리를 작성하는 함수
          이 함수를 호출함으로써 테이블의 스키마를 지키며 테이블을 생성할 수 있다.
          해당 함수는 반드시 Class 내부 변수를 프로퍼티로 선언해야 작동한다.

          + 무조건 첫 번째 열은 Id로 지정하며, AUTO INCREMENT로 설정한다.
        */
        private string generate_create_table_query(Type table_type, string table_name, bool if_not_exists = true)
        {
            PropertyInfo[] inherited_properties = table_type.BaseType?.GetProperties(BindingFlags.Public | BindingFlags.Instance) ?? Array.Empty<PropertyInfo>();
            PropertyInfo[] current_properties = table_type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            string columns = "";

            // 상속된 속성들을 먼저 처리
            foreach (PropertyInfo property in inherited_properties)
            {
                string column_name = property.Name;
                string column_type = get_sqlite_type(property.PropertyType);

                bool is_nullable = !property.PropertyType.IsValueType
                                   ||
                                   (property.PropertyType.IsGenericType
                                    &&
                                    property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
                string nullability = is_nullable ? "NULL" : "NOT NULL";

                // Id 열에 대해 AUTOINCREMENT 추가
                if (string.Equals(column_name, "Id", StringComparison.OrdinalIgnoreCase))
                {
                    column_type = "INTEGER PRIMARY KEY AUTOINCREMENT";
                    nullability = "";
                }

                columns += $"{column_name} {column_type} {nullability}, ";
            }

            // 현재 클래스의 속성들을 처리
            foreach (PropertyInfo property in current_properties)
            {
                string column_name = property.Name;
                string column_type = get_sqlite_type(property.PropertyType);

                bool is_nullable = !property.PropertyType.IsValueType
                                   ||
                                   (property.PropertyType.IsGenericType
                                    &&
                                    property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
                string nullability = is_nullable ? "NULL" : "NOT NULL";

                // Id 열에 대해 AUTOINCREMENT 추가
                if (string.Equals(column_name, "Id", StringComparison.OrdinalIgnoreCase))
                {
                    column_type = "INTEGER PRIMARY KEY AUTOINCREMENT";
                    nullability = "";
                }

                columns += $"{column_name} {column_type} {nullability}, ";
            }

            columns = columns.TrimEnd(',', ' '); // 마지막 쉼표와 공백 제거

            string if_not_exists_clause = if_not_exists ? "IF NOT EXISTS " : "";

            string create_table_query = $"CREATE TABLE {if_not_exists_clause}{table_name} ({columns});";
            return create_table_query;
        }

        // generate_create_table_query 에서 사용하는 함수
        // C#의 데이터 타입을 SQLite 데이터 타입으로 변환하는 함수
        private string get_sqlite_type(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            if (type == typeof(int) || type == typeof(long) || type == typeof(short) || type == typeof(byte))
            {
                return "INTEGER";
            }
            else if (type == typeof(bool))
            {
                return "INTEGER"; // SQLite에는 BOOLEAN 타입이 없으므로 INTEGER로 매핑
            }
            else if (type == typeof(float) || type == typeof(double) || type == typeof(decimal))
            {
                return "REAL";
            }
            else if (type == typeof(string))
            {
                return "TEXT";
            }
            else if (type == typeof(DateTime))
            {
                return "DATETIME";
            }
            else if (type == typeof(byte[]))
            {
                return "BLOB";
            }
            else if (type == typeof(Guid))
            {
                return "TEXT"; // GUID는 일반적으로 TEXT로 저장
            }
            else if (type.IsEnum)
            {
                return "INTEGER"; // 열거형 타입은 INTEGER로 저장
            }
            throw new NotSupportedException($"Type {type.Name} is not supported");
        }
        // ======================================================================================================

        // db 파일 전체 삭제 함수
        public void clear_db_file()
        {
            try
            {
                // Connection 을 끊어준다
                connection.Close();

                if (File.Exists(total_db_path))
                {
                    File.Delete(total_db_path);
                    Console.WriteLine("DB 파일이 삭제되었습니다.");
                }
                else
                {
                    Console.WriteLine("DB 파일이 존재하지 않습니다.");
                }
            }
            catch (Exception e)
            {
                // 예외 발생시 호출자쪽으로 떠넘긴다. (java의 throws 처럼)
                throw e;
            }

            // _instance 초기화, 이 구문에 의해 현재 싱글턴 객체는 버려지고
            // 다음에 DBMaster.Instance 로 접근할 때 새로운 객체가 생성된다.
            _instance = null;
        }

        // 테이블이 존재하는지 확인하는 함수
        private bool is_table_exist(string table_name)
        {
            string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{table_name}';";
            using (var command = new SQLiteCommand(query, connection))
            {
                using var reader = command.ExecuteReader();
                return reader.HasRows; // table이 존재하면 true, 아니면 false
            }
        }

        // 생성 & 기본값 관련 ==============================================================
        // 테이블 생성 공통 함수
        private void create_table(string full_query, string table_name, bool enable_debug_text = false)
        {
            using (var command = new SQLiteCommand(full_query, connection))
            {
                /*
                     주의 : SQL에서는 테이블 이름과 같은 객체 식별자는 매개 변수로 전달할 수 없다.
                     C#의 문자열 보간을 이용해야 한다. / 다만 이러면 SQL 인젝션에 취약해진다.
                     물론 여기선 사용자가 입력하는 부분이 없으니 상관없다.
                     // command.Parameters.AddWithValue("@Tablename", user_table_name);
                */
                // ExecuteNonQuery = SQL 명령문을 실행하지만 결과를 반환하지 않는 경우에 사용
                // NonQuery = 결과 집합을 반환하지 않는다는 의미
                command.ExecuteNonQuery();

                if (enable_debug_text)
                    Console.WriteLine($"{table_name} 테이블이 생성되었습니다.");
            }
        }

        // 유저 테이블 기본값 설정
        private void set_default_user_table_value()
        {
            // 새로 만들었으면 기본 유저 3개를 추가한다. (관리자)
            // 비밀번호의 경우 bcrypt로 해싱한 값을 넣어준다.
            insert_user_data("pgh268400@naver.com", "$2a$11$AGSymNxbp5.vNByqEVqx0OnEuml73PhmDcs4P.qdWF66uf7CdnZV2");
            insert_user_data("admin@naver.com", "$2a$12$fayeaZIXIEqMVv4IkMDDaOb0KhE4a65/zel5oHJ9k..E2Q/EytTFu");
            insert_user_data("admin", "$2a$12$fayeaZIXIEqMVv4IkMDDaOb0KhE4a65/zel5oHJ9k..E2Q/EytTFu");
        }

        // 재고 테이블 기본값 설정
        private void set_default_stock_table_value()
        {
            // 기본 재고 데이터 설정
            // 데이터 추가
            insert_stock_data(new StockRecord { Id = 1, ItemName = "싸인펜", Cost = 1000, Count = 30 });
            insert_stock_data(new StockRecord { Id = 2, ItemName = "붓", Cost = 2000, Count = 20 });
            insert_stock_data(new StockRecord { Id = 3, ItemName = "지우개", Cost = 800, Count = 30 });
            insert_stock_data(new StockRecord { Id = 4, ItemName = "제도샤프", Cost = 1500, Count = 40 });
            insert_stock_data(new StockRecord { Id = 5, ItemName = "A4 노트", Cost = 2000, Count = 30 });
            insert_stock_data(new StockRecord { Id = 6, ItemName = "스티커 메모", Cost = 1500, Count = 20 });
            insert_stock_data(new StockRecord { Id = 7, ItemName = "수정 테이프", Cost = 700, Count = 20 });
            insert_stock_data(new StockRecord { Id = 8, ItemName = "가위", Cost = 1500, Count = 15 });
            insert_stock_data(new StockRecord { Id = 9, ItemName = "글루건", Cost = 1000, Count = 10 });
            insert_stock_data(new StockRecord { Id = 10, ItemName = "필통", Cost = 2000, Count = 12 });
            insert_stock_data(new StockRecord { Id = 11, ItemName = "바인더 클립(20개)", Cost = 2000, Count = 20 });
            insert_stock_data(new StockRecord { Id = 12, ItemName = "미니 스테이플러", Cost = 2500, Count = 10 });
            insert_stock_data(new StockRecord { Id = 13, ItemName = "자", Cost = 1000, Count = 20 });
        }

        // 조회 관련 ==============================================================
        // 모든 행을 전체 조회하는 공통 함수 (제네릭 사용)
        private List<T> get_all_table_data<T>(string table_name, Func<SQLiteDataReader, T> read_record)
        {
            var records = new List<T>();
            string select_query = $"SELECT * FROM {table_name}";

            using (var command = new SQLiteCommand(select_query, connection))
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    records.Add(read_record(reader));
                }
            }
            return records;
        }

        // 유저 테이블의 모든 데이터 가져오기
        public List<UserRecord> get_all_users_table_data()
        {
            return get_all_table_data(user_table_name, reader => new UserRecord
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                Password = reader.GetString(2)
            });
        }

        // 결제 테이블의 모든 데이터 가져오기
        public List<PayMentRefundRecord> get_all_payments_table_data()
        {
            return get_all_table_data(payment_table_name, reader => new PayMentRefundRecord
            {
                Id = reader.GetInt32(0),
                Time = reader.GetDateTime(1),
                ItemName = reader.GetString(2),
                UnitPrice = reader.GetInt32(3),
                Count = reader.GetInt32(4),
                TotalPrice = reader.GetInt32(5),
                Payer = reader.IsDBNull(6) ? null : reader.GetString(6),
                PhoneNumber = reader.IsDBNull(7) ? null : reader.GetString(7)
            });
        }

        // 환불 테이블의 모든 데이터 가져오기
        public List<PayMentRefundRecord> get_all_refunds_table_data()
        {
            return get_all_table_data(refund_table_name, reader => new PayMentRefundRecord
            {
                Id = reader.GetInt32(0),
                Time = reader.GetDateTime(1),
                ItemName = reader.GetString(2),
                UnitPrice = reader.GetInt32(3),
                Count = reader.GetInt32(4),
                TotalPrice = reader.GetInt32(5),
                Payer = reader.IsDBNull(6) ? null : reader.GetString(6),
                PhoneNumber = reader.IsDBNull(7) ? null : reader.GetString(7)
            });
        }

        // 총 결제기록의 모든 데이터 가져오기
        // 총 결제 기록을 조회하는 메서드
        public List<TotalRecord> get_all_total_records_data()
        {
            return get_all_table_data(total_record_table_name, reader => new TotalRecord
            {
                Id = reader.GetInt32(0),
                Time = reader.GetDateTime(1),
                ItemName = reader.GetString(2),
                UnitPrice = reader.GetInt32(3),
                Count = reader.GetInt32(4),
                TotalPrice = reader.GetInt32(5),
                Payer = reader.IsDBNull(6) ? null : reader.GetString(6),
                PhoneNumber = reader.IsDBNull(7) ? null : reader.GetString(7),
                isRefund = reader.GetInt32(8)
            });
        }

        // 재고 테이블의 모든 데이터 가져오기
        public List<StockRecord> get_all_stock_table_data()
        {
            return get_all_table_data(stock_table_name, reader => new StockRecord
            {
                Id = reader.GetInt32(0),
                ItemName = reader.GetString(1),
                Cost = reader.GetInt32(2),
                Count = reader.GetInt32(3)
            });
        }

        // 영수증 테이블의 모든 데이터 가져오기
        public List<ReceiptRecord> get_all_receipt_table_data()
        {
            return get_all_table_data(receipt_table_name, reader => new ReceiptRecord
            {
                Id = reader.GetInt32(0),
                TerminalNumber = reader.GetString(1),
                SlipNumber = reader.GetString(2),
                Merchant = reader.GetString(3),
                PointHolder = reader.GetString(4),
                BusinessNumber = reader.GetString(5),
                TelNumber = reader.GetString(6),
                Amount = reader.GetInt32(7),
                Vat = reader.GetInt32(8),
                Total = reader.GetInt32(9),
                CardName = reader.GetString(10),
                CardNumber = reader.GetString(11),
                IsInstallment = reader.GetBoolean(12),
                PayDay = reader.GetDateTime(13),
                ApprovalNumber = reader.GetString(14)
            });
        }

        // 아이템 이름을 입력 받아서 재고 테이블에서 해당 아이템을 읽어들여 반환하는 함수
        public StockRecord get_stock_record_by_item_name(string item_name)
        {
            string select_query = $"SELECT * FROM {stock_table_name} WHERE ItemName = @ItemName";
            using (var command = new SQLiteCommand(select_query, connection))
            {
                command.Parameters.AddWithValue("@ItemName", item_name);

                using var reader = command.ExecuteReader();
                if (!reader.Read()) return null;

                return new StockRecord
                {
                    Id = reader.GetInt32(0),
                    ItemName = reader.GetString(1),
                    Cost = reader.GetInt32(2),
                    Count = reader.GetInt32(3)
                };
            }
        }

        // id 번호를 입력 받아서 재고 테이블에서 해당 아이템을 읽어들여 반환하는 함수
        public StockRecord get_stock_record_by_id(int id)
        {
            string select_query = $"SELECT * FROM {stock_table_name} WHERE Id = @Id";
            using (var command = new SQLiteCommand(select_query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using var reader = command.ExecuteReader();
                if (!reader.Read()) return null;

                return new StockRecord
                {
                    Id = reader.GetInt32(0),
                    ItemName = reader.GetString(1),
                    Cost = reader.GetInt32(2),
                    Count = reader.GetInt32(3)
                };
            }
        }

        // 삽입 관련 ==============================================================
        // 참고 : password 의 경우 반드시 비밀번호를 bcrypt 로 해싱한 값을 넣어야 한다.
        private void insert_user_data(string username, string hashed_password)
        {
            // bcrypt로 암호화된 비밀번호를 저장한다.
            string insert_query = $"INSERT INTO {user_table_name} (Username, Password) VALUES (@Username, @Password)";
            using (var command = new SQLiteCommand(insert_query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", hashed_password);
                command.ExecuteNonQuery();
            }
        }

        // 결제 테이블에 데이터 삽입
        public void insert_payment_data(PayMentRefundRecord record)
        {
            string insert_query = $@"
                                    INSERT INTO {payment_table_name} 
                                    (Time, ItemName, UnitPrice, Count, TotalPrice, Payer, PhoneNumber) 
                                    VALUES (@Time, @ItemName, @UnitPrice, @Count, @TotalPrice, @Payer, @PhoneNumber)";
            using (var command = new SQLiteCommand(insert_query, connection))
            {
                command.Parameters.AddWithValue("@Time", record.Time);
                command.Parameters.AddWithValue("@ItemName", record.ItemName);
                command.Parameters.AddWithValue("@UnitPrice", record.UnitPrice);
                command.Parameters.AddWithValue("@Count", record.Count);
                command.Parameters.AddWithValue("@TotalPrice", record.TotalPrice);
                command.Parameters.AddWithValue("@Payer", (object?)record.Payer ?? DBNull.Value);
                command.Parameters.AddWithValue("@PhoneNumber", (object?)record.PhoneNumber ?? DBNull.Value);
                command.ExecuteNonQuery();
            }

            // TotalRecord 객체로 변환 & 통합 기록 테이블에 삽입
            var total_record = new TotalRecord
            {
                Time = record.Time,
                ItemName = record.ItemName,
                UnitPrice = record.UnitPrice,
                Count = record.Count,
                TotalPrice = record.TotalPrice,
                Payer = record.Payer,
                PhoneNumber = record.PhoneNumber,
                isRefund = 0
            };

            // 결제 테이블 삽입시 통합 기록에도 삽입
            insert_total_record_data(total_record);
        }

        // 환불 테이블에 데이터 삽입
        public void insert_refund_data(PayMentRefundRecord record)
        {
            string insert_query = $"INSERT INTO {refund_table_name} (Time, ItemName, UnitPrice, Count, TotalPrice, Payer, PhoneNumber) VALUES (@Time, @ItemName, @UnitPrice, @Count, @TotalPrice, @Payer, @PhoneNumber)";
            using (var command = new SQLiteCommand(insert_query, connection))
            {
                command.Parameters.AddWithValue("@Time", record.Time);
                command.Parameters.AddWithValue("@ItemName", record.ItemName);
                command.Parameters.AddWithValue("@UnitPrice", record.UnitPrice);
                command.Parameters.AddWithValue("@Count", record.Count);
                command.Parameters.AddWithValue("@TotalPrice", record.TotalPrice);
                command.Parameters.AddWithValue("@Payer", (object?)record.Payer ?? DBNull.Value);
                command.Parameters.AddWithValue("@PhoneNumber", (object?)record.PhoneNumber ?? DBNull.Value);
                command.ExecuteNonQuery();
            }

            // TotalRecord 객체로 변환 & 통합 기록 테이블에 삽입
            var total_record = new TotalRecord
            {
                Time = record.Time,
                ItemName = record.ItemName,
                UnitPrice = record.UnitPrice,
                Count = record.Count,
                TotalPrice = record.TotalPrice,
                Payer = record.Payer,
                PhoneNumber = record.PhoneNumber,
                isRefund = 1
            };

            // 결제 테이블 삽입시 통합 기록에도 삽입
            insert_total_record_data(total_record);
        }

        // 통합 기록 테이블에 데이터 삽입
        // 해당 기록은 readonly 이므로 insert 함수는 public이 아닌 private로 선언한다.
        private void insert_total_record_data(TotalRecord record)
        {
            string insert_query = $"INSERT INTO {total_record_table_name} (Time, ItemName, UnitPrice, Count, TotalPrice, Payer, PhoneNumber, isRefund) VALUES (@Time, @ItemName, @UnitPrice, @Count, @TotalPrice, @Payer, @PhoneNumber, @isRefund)";
            using (var command = new SQLiteCommand(insert_query, connection))
            {
                command.Parameters.AddWithValue("@Time", record.Time);
                command.Parameters.AddWithValue("@ItemName", record.ItemName);
                command.Parameters.AddWithValue("@UnitPrice", record.UnitPrice);
                command.Parameters.AddWithValue("@Count", record.Count);
                command.Parameters.AddWithValue("@TotalPrice", record.TotalPrice);
                command.Parameters.AddWithValue("@Payer", (object?)record.Payer ?? DBNull.Value);
                command.Parameters.AddWithValue("@PhoneNumber", (object?)record.PhoneNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@isRefund", record.isRefund);
                command.ExecuteNonQuery();
            }
        }

        // 재고 테이블에 데이터 삽입
        public void insert_stock_data(StockRecord record)
        {
            string insert_query = $"INSERT INTO {stock_table_name} (ItemName, Cost, Count) VALUES (@ItemName, @Cost, @Count)";
            using (var command = new SQLiteCommand(insert_query, connection))
            {
                command.Parameters.AddWithValue("@ItemName", record.ItemName);
                command.Parameters.AddWithValue("@Cost", record.Cost);
                command.Parameters.AddWithValue("@Count", record.Count);
                command.ExecuteNonQuery();
            }
        }

        // 영수증 테이블에 데이터 삽입
        public void insert_receipt_data(ReceiptRecord record)
        {
            string insert_query = $@"
                                    INSERT INTO {receipt_table_name} 
                                    (TerminalNumber, SlipNumber, Merchant, PointHolder, BusinessNumber, TelNumber, Amount, Vat, Total, CardName, CardNumber, IsInstallment, PayDay, ApprovalNumber) 
                                    VALUES (@TerminalNumber, @SlipNumber, @Merchant, @PointHolder, @BusinessNumber, @TelNumber, @Amount, @Vat, @Total, @CardName, @CardNumber, @IsInstallment, @PayDay, @ApprovalNumber)";
            using (var command = new SQLiteCommand(insert_query, connection))
            {
                command.Parameters.AddWithValue("@TerminalNumber", record.TerminalNumber);
                command.Parameters.AddWithValue("@SlipNumber", record.SlipNumber);
                command.Parameters.AddWithValue("@Merchant", record.Merchant);
                command.Parameters.AddWithValue("@PointHolder", record.PointHolder);
                command.Parameters.AddWithValue("@BusinessNumber", record.BusinessNumber);
                command.Parameters.AddWithValue("@TelNumber", record.TelNumber);
                command.Parameters.AddWithValue("@Amount", record.Amount);
                command.Parameters.AddWithValue("@Vat", record.Vat);
                command.Parameters.AddWithValue("@Total", record.Total);
                command.Parameters.AddWithValue("@CardName", record.CardName);
                command.Parameters.AddWithValue("@CardNumber", record.CardNumber);
                command.Parameters.AddWithValue("@IsInstallment", record.IsInstallment);
                command.Parameters.AddWithValue("@PayDay", record.PayDay);
                command.Parameters.AddWithValue("@ApprovalNumber", record.ApprovalNumber);
                command.ExecuteNonQuery();
            }
        }

        // 삭제 관련 ==============================================================
        // 결제 테이블의 n번째 행을 삭제하는 메서드
        public void delete_payment_row(int n)
        {
            string delete_query = $@"
            DELETE FROM {payment_table_name}
            WHERE ROWID = (SELECT ROWID FROM {payment_table_name} LIMIT 1 OFFSET @RowIndex)";

            using (var command = new SQLiteCommand(delete_query, connection))
            {
                command.Parameters.AddWithValue("@RowIndex", n);
                command.ExecuteNonQuery();
            }
        }

        // 환불 테이블의 n번째 행을 삭제하는 메서드
        public void delete_refund_row(int n)
        {
            string delete_query = $@"
            DELETE FROM {refund_table_name}
            WHERE ROWID = (SELECT ROWID FROM {refund_table_name} LIMIT 1 OFFSET @RowIndex)";

            using (var command = new SQLiteCommand(delete_query, connection))
            {
                command.Parameters.AddWithValue("@RowIndex", n);
                command.ExecuteNonQuery();
            }
        }

        // ========================================================================
        // 재고 데이터 Update 하기
        public void update_stock_data(StockRecord record)
        {
            string update_query = $"UPDATE {stock_table_name} SET ItemName = @ItemName, Cost = @Cost, Count = @Count WHERE Id = @Id";
            using (var command = new SQLiteCommand(update_query, connection))
            {
                command.Parameters.AddWithValue("@ItemName", record.ItemName);
                command.Parameters.AddWithValue("@Cost", record.Cost);
                command.Parameters.AddWithValue("@Count", record.Count);
                command.Parameters.AddWithValue("@Id", record.Id);

                // 완성된 쿼리 출력
                string completed_query = command.CommandText;
                foreach (SQLiteParameter parameter in command.Parameters)
                {
                    completed_query = completed_query.Replace(parameter.ParameterName, parameter.Value.ToString());
                }
                Console.WriteLine("Completed Query: " + completed_query);

                command.ExecuteNonQuery();
            }
        }

        // ========================================================================
        /*
         싱글톤을 구현하는 핵심 부분
         new 가 아닌 정적 프로퍼티를 통해 인스턴스에 접근
         이 부분은 싱글톤 패턴의 핵심입니다. 정적 프로퍼티 Instance는 클래스의 유일한 인스턴스를 생성하고 관리하는 역할을 합니다. 이 패턴의 동작 방식을 이해하기 위해, 단계별로 설명해드리겠습니다.

            정적 변수 _instance:

            클래스 내에 private static DBMaster _instance 변수를 선언합니다. 이 변수는 DBMaster 클래스의 유일한 인스턴스를 저장합니다.
            정적 프로퍼티 Instance:

            public static DBMaster Instance 프로퍼티는 클래스의 인스턴스에 접근할 수 있는 방법을 제공합니다. 이 프로퍼티를 통해 언제나 동일한 인스턴스가 반환되도록 합니다.
            스레드 안전성 보장:

            lock (_lock)을 사용하여 멀티스레드 환경에서도 인스턴스가 안전하게 생성되도록 합니다. _lock은 private static readonly object _lock = new object();로 선언된 락 객체입니다.
            인스턴스 생성:

            Instance 프로퍼티가 처음 호출될 때 _instance가 null인지 확인합니다.
            _instance가 null이면 새로운 DBMaster 인스턴스를 생성합니다. new DBMaster() 호출은 private 생성자를 사용하여 클래스 인스턴스를 만듭니다.
            _instance가 이미 생성되어 있으면, 기존 인스턴스를 반환합니다.
          by ChatGPT4.0 / 정확한 설명인지는 인터넷 레퍼런스 참고가 필수.

          사용시 var db_master = DBMaster.Instance; 와 같은 형태로 class의 프로퍼티를 접근하면
          첫 접근시 아래 _instance = new DBMaster(); 에 의해 생성자가 호출되어 객체가 생성된다.
          이후로는 _instance 가 null 이 아니라 새로운 DBMaster 객체를 참조(가리키게 됨) 하게 됐으니
          같은 주소 (_instance) 를 return 하여 결론적으로 한개의 객체만을 사용하게 된다.
         */
        public static DBMaster Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DBMaster();
                    }
                    return _instance;
                }
            }
        }

        // 자동 로그인에서 사용하는 함수로, 사용자의 id와 pw를 입력받아 user DB에 존재하는지 체크하는 함수
        // password 의 경우 반드시 해싱된 값을 넘겨야 한다.
        public bool is_exist_user(string user_id, string hashed_password)
        {
            // db에 요청해 id에 해당하는 pw를 가져온다.
            string select_query = $"SELECT Password FROM {user_table_name} WHERE Username = @Username";

            using var command = new SQLiteCommand(select_query, connection);
            command.Parameters.AddWithValue("@Username", user_id);

            using var reader = command.ExecuteReader();
            if (!reader.Read()) return false; // 결과가 없다면 실패

            // db에 저장된 pw와 입력받은 pw가 같은지 비교한다.
            // 참고로 유저의 id string은 unique 하기 때문에 결과가 정확히 1개 나와야 한다.
            string db_password = reader.GetString(0);
            return db_password == hashed_password;
        }

        // db에 요청해 id에 해당하는 pw를 가져온다.
        public string get_user_pw_by_id(string user_id)
        {
            string select_query = $"SELECT Password FROM {user_table_name} WHERE Username = @Username";
            string stored_hash = "";
            string connection_string = $"Data Source={total_db_path};Version=3;";
            using var connection = new SQLiteConnection(connection_string);
            connection.Open();

            using var command = new SQLiteCommand(select_query, connection);
            command.Parameters.AddWithValue("@Username", user_id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                stored_hash = reader["Password"].ToString();
                return stored_hash;
            }
            return stored_hash;
        }

        /*
          로그인시에 사용하는 함수로 id와, pw를 입력받아 (여기서 pw는 평문)
          id에 해당하는 pw를 db에서 찾고, 입력받은 pw를 bcrypt 검증해
          유저가 제대로 로그인 했는지 검사하는 함수
        */
        public bool is_login_success(string user_id, string password)
        {
            // db에 요청해 id에 해당하는 pw를 가져온다.
            string select_query = $"SELECT Password FROM {user_table_name} WHERE Username = @Username";

            using var command = new SQLiteCommand(select_query, connection);
            command.Parameters.AddWithValue("@Username", user_id);

            using var reader = command.ExecuteReader();
            if (!reader.Read()) return false; // 결과가 없다면 실패

            // db에 저장된 pw와 입력받은 pw가 같은지 비교한다.
            // 참고로 유저의 id string은 unique 하기 때문에 결과가 정확히 1개 나와야 한다.
            string db_password = reader.GetString(0);

            // 입력받은 pw를 bcrypt로 검증한다.
            return BCrypt.Net.BCrypt.Verify(password, db_password);
        }
    }
}
