using System.Data.SQLite;

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
        private static readonly object _lock = new object();

        // 멤버 변수
        // 모든 table을 일괄적으로 저장할 db 파일
        private string total_db_path = "total.db";

        // 해당 connection 변수를 이용해 db에 접근한다.
        private SQLiteConnection connection;

        // 유저 테이블 이름
        private string user_table_name = "Users";

        // 총 결제 내역 테이블 이름
        private string payment_table_name = "Payments";

        // 환불 내역 테이블 이름
        private string refund_table_name = "Refunds";


        // private 생성자
        private DBMaster()
        {
            /*
              db 파일에 연결을 시도한다.
              참고로 SQLite는 connection 시 대응되는 db 파일이 없다면 알아서 자동 생성하니
              db 파일이 없어도 걱정하지 않아도 된다.
            */
            string connection_string = $"Data Source={total_db_path};Version=3;";

            /*
              db 연결
              속도 저하를 막기 위해 연결을 유지할 것이기에, 자동으로 해제 시키는 using은 사용하지 않고 소멸자에서 Close 한다.
              매번 Open 하는 경우 db 파일을 열기 위해 File I/O 가 지속적으로 발생해서 성능이 떨어진다.
              일반적으로 db에서 성능 저하가 가장 큰 부분(비용이 큰 부분) 이 첫 접속이라고 한다.
            */
            connection = new SQLiteConnection(connection_string);
            connection.Open();

            // db 파일 안에 table 들이 없다면 생성한다.
            if (!is_table_exist(user_table_name))
                create_user_table();

            if (!is_table_exist(payment_table_name))
                create_payment_table();

            if (!is_table_exist(refund_table_name))
                create_refund_table();
        }

        // db 파일 삭제 함수
        // 참고로 해당 함수 호출 이후 반드시 재 실행해야 db가 정상 작동한다.
        public void clear_db_file()
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

        private bool is_table_exist(string table_name)
        {
            string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{table_name}';";
            using (var command = new SQLiteCommand(query, connection))
            {
                using var reader = command.ExecuteReader();
                return reader.HasRows; // table이 존재하면 true, 아니면 false
            }
        }

        // 유저 테이블 생성
        private void create_user_table()
        {
            /*
              User Table 모습
              +----+----------+---------------------+
              | Id | Username |      Password       |
              +----+----------+---------------------+
              | 1  | user1    | bcrypt_hased_pass1  |
              | 2  | user2    | bcrypt_hased_pass2  |
              | 3  | user3    | bcrypt_hased_pass3  |
              +----+----------+---------------------+ 
              Id: INTEGER, PRIMARY KEY, AUTOINCREMENT
              Username: TEXT, NOT NULL, UNIQUE
              Password: TEXT, NOT NULL
            */

            string connection_string = $"Data Source={total_db_path};Version=3;";
            using var connection = new SQLiteConnection(connection_string);
            connection.Open();

            // 파일로 작업하지만 다루는건 당연히 SQL문법으로 다룬다.
            string create_table_query = $@"
            CREATE TABLE IF NOT EXISTS {user_table_name} (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL
            )";
            using (var command = new SQLiteCommand(create_table_query, connection))
            {
                /*
                     SQL에서는 테이블 이름과 같은 객체 식별자는 매개 변수로 전달할 수 없다.
                     C#의 문자열 보간을 이용해야 한다. / 다만 이러면 SQL 인젝션에 취약해진다.
                     물론 여기선 사용자가 입력하는 부분이 없으니 상관없다.
                     // command.Parameters.AddWithValue("@Tablename", user_table_name);
                    */

                // ExecuteNonQuery = SQL 명령문을 실행하지만 결과를 반환하지 않는 경우에 사용
                // NonQuery = 결과 집합을 반환하지 않는다는 의미
                command.ExecuteNonQuery();
                Console.WriteLine($"{user_table_name} 테이블이 생성되었습니다.");
            }

            // 새로 만들었으면 기본 유저 3개를 추가한다. (관리자)
            // 비밀번호의 경우 bcrypt로 해싱한 값을 넣어준다.
            insert_user_data("pgh268400@naver.com", "$2a$11$AGSymNxbp5.vNByqEVqx0OnEuml73PhmDcs4P.qdWF66uf7CdnZV2");
            insert_user_data("admin@naver.com", "$2a$12$fayeaZIXIEqMVv4IkMDDaOb0KhE4a65/zel5oHJ9k..E2Q/EytTFu");
            insert_user_data("admin", "$2a$12$fayeaZIXIEqMVv4IkMDDaOb0KhE4a65/zel5oHJ9k..E2Q/EytTFu");
        }

        // 결제 테이블 생성
        private void create_payment_table()
        {
            /*
              Payments Table 모습
              +-------------------+----------+-----------+-------+------------+----------+-------------+
              |       Time        | ItemName | UnitPrice | Count | TotalPrice | Payer    | PhoneNumber |
              +-------------------+----------+-----------+-------+------------+----------+-------------+
              | 2023-01-01 10:00  | Item1    | 1000      | 2     | 2000       | user1    | 1234        |
              | 2023-01-02 11:00  | Item2    | 2000      | 1     | 2000       | user2    | 5678        |
              | 2023-01-03 12:00  | Item3    | 1500      | 3     | 4500       | user3    | 9012        |
              +-------------------+----------+-----------+-------+------------+----------+-------------+
              Time: TIMESTAMP, NOT NULL
              ItemName: TEXT, NOT NULL
              UnitPrice: INTEGER, NOT NULL
              Count: INTEGER, NOT NULL
              TotalPrice: INTEGER, NOT NULL
              Payer: TEXT, NULL
              PhoneNumber: INTEGER, NULL
            */

            string connection_string = $"Data Source={total_db_path};Version=3;";
            using (var connection = new SQLiteConnection(connection_string))
            {
                connection.Open();

                // 파일로 작업하지만 다루는건 당연히 SQL문법으로 다룬다.
                string create_table_query = $@"
                CREATE TABLE IF NOT EXISTS {payment_table_name} (
                    Time TIMESTAMP NOT NULL,
                    ItemName TEXT NOT NULL,
                    UnitPrice INTEGER NOT NULL,
                    Count INTEGER NOT NULL,
                    TotalPrice INTEGER NOT NULL,
                    Payer TEXT,
                    PhoneNumber INTEGER
                )";
                using (var command = new SQLiteCommand(create_table_query, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine($"{payment_table_name} 테이블이 생성되었습니다.");
                }
            }
        }

        // 환불 테이블 생성
        private void create_refund_table()
        {
            /*
              Refunds Table 모습
              +-------------------+----------+-----------+-------+------------+----------+-------------+
              |       Time        | ItemName | UnitPrice | Count | TotalPrice | Payer    | PhoneNumber |
              +-------------------+----------+-----------+-------+------------+----------+-------------+
              | 2023-01-01 10:00  | Item1    | 1000      | 2     | 2000       | user1    | 1234        |
              | 2023-01-02 11:00  | Item2    | 2000      | 1     | 2000       | user2    | 5678        |
              | 2023-01-03 12:00  | Item3    | 1500      | 3     | 4500       | user3    | 9012        |
              +-------------------+----------+-----------+-------+------------+----------+-------------+
              Time: TIMESTAMP, NOT NULL
              ItemName: TEXT, NOT NULL
              UnitPrice: INTEGER, NOT NULL
              Count: INTEGER, NOT NULL
              TotalPrice: INTEGER, NOT NULL
              Payer: TEXT, NULL
              PhoneNumber: INTEGER, NULL
            */

            string connection_string = $"Data Source={total_db_path};Version=3;";
            using (var connection = new SQLiteConnection(connection_string))
            {
                connection.Open();

                // 파일로 작업하지만 다루는건 당연히 SQL문법으로 다룬다.
                string create_table_query = $@"
                CREATE TABLE IF NOT EXISTS {refund_table_name} (
                    Time TIMESTAMP NOT NULL,
                    ItemName TEXT NOT NULL,
                    UnitPrice INTEGER NOT NULL,
                    Count INTEGER NOT NULL,
                    TotalPrice INTEGER NOT NULL,
                    Payer TEXT,
                    PhoneNumber INTEGER
                )";
                using (var command = new SQLiteCommand(create_table_query, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine($"{refund_table_name} 테이블이 생성되었습니다.");
                }
            }
        }

        // 유저 테이블의 모든 데이터를 named tuple이 담긴 리스트로 반환한다.
        public List<UserRecord> get_all_users_table()
        {
            var users = new List<UserRecord>();

            string select_query = $"SELECT Id, Username, Password FROM {user_table_name}";
            using (var command = new SQLiteCommand(select_query, connection))
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var user = new UserRecord
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2)
                    };
                    users.Add(user);
                }
            }

            return users;
        }

        // 유저 테이블의 데이터를 담을 클래스
        public class UserRecord
        {
            public int Id;
            public string Username;
            public string Password;
        }

        // 결제 테이블과 환불 테이블의 데이터를 담을 클래스
        public class PayMentRefundRecord
        {
            public DateTime Time;
            public string ItemName;
            public int UnitPrice;
            public int Count;
            public int TotalPrice;
            public string Payer;
            public int PhoneNumber;
        }

        // 결제 테이블의 모든 데이터 가져오기
        public List<PayMentRefundRecord> get_all_payments_table()
        {
            var payments = new List<PayMentRefundRecord>();

            string select_query = $"SELECT * FROM {payment_table_name}";
            using (var command = new SQLiteCommand(select_query, connection))
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var payment = new PayMentRefundRecord
                    {
                        Time = reader.GetDateTime(0),
                        ItemName = reader.GetString(1),
                        UnitPrice = reader.GetInt32(2),
                        Count = reader.GetInt32(3),
                        TotalPrice = reader.GetInt32(4),
                        Payer = reader.IsDBNull(5) ? null : reader.GetString(5),
                        PhoneNumber = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                    };
                    payments.Add(payment);
                }
            }

            return payments;
        }

        // 환불 테이블의 모든 데이터 가져오기
        public List<PayMentRefundRecord> get_all_refunds_table()
        {
            var refunds = new List<PayMentRefundRecord>();

            string select_query = $"SELECT * FROM {refund_table_name}";
            using (var command = new SQLiteCommand(select_query, connection))
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var refund = new PayMentRefundRecord
                    {
                        Time = reader.GetDateTime(0),
                        ItemName = reader.GetString(1),
                        UnitPrice = reader.GetInt32(2),
                        Count = reader.GetInt32(3),
                        TotalPrice = reader.GetInt32(4),
                        Payer = reader.IsDBNull(5) ? null : reader.GetString(5),
                        PhoneNumber = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                    };
                    refunds.Add(refund);
                }
            }

            return refunds;
        }



        // 참고 : password 의 경우 반드시 비밀번호를 bcrypt 로 해싱한 값을 넣어야 한다.
        private void insert_user_data(string username, string hashed_password)
        {
            string connection_string = $"Data Source={total_db_path};Version=3;";
            using (var connection = new SQLiteConnection(connection_string))
            {
                connection.Open();

                // bcrypt로 암호화된 비밀번호를 저장한다.
                string insert_query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                using (var command = new SQLiteCommand(insert_query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashed_password);
                    command.ExecuteNonQuery();
                }
            }
        }


        /*
         정적 프로퍼티를 통해 인스턴스에 접근
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
            string select_query = "SELECT Password FROM Users WHERE Username = @Username";
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

        // 로그인시에 사용하는 함수로 id와, pw를 입력받아 (여기서 pw는 평문)
        // id에 해당하는 pw를 db에서 찾고, 입력받은 pw를 bcrypt 검증해
        // 유저가 제대로 로그인 했는지 검사하는 함수
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

        // 소멸자
        ~DBMaster()
        {
            // 소멸시 db 연결을 끊는다.
            connection.Close();
        }
    }
}
