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
        // 사용자들의 id와 pw를 저장하는 db 파일 경로
        private string user_db_path = "users.db";

        // 해당 connection 변수를 이용해 db에 접근한다.
        private SQLiteConnection user_connection;

        // private 생성자
        private DBMaster()
        {
            // 생성시 db 파일을 모두 로드한다.
            string user_connection_string = $"Data Source={user_db_path};Version=3;";

            // db 연결
            // 속도 저하를 막기 위해 연결을 유지할 것이기에, 자동으로 해제 시키는 using은 사용하지 않는다.
            user_connection = new SQLiteConnection(user_connection_string);
            user_connection.Open();
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
            string select_query = "SELECT Password FROM Users WHERE Username = @Username";

            using var command = new SQLiteCommand(select_query, user_connection);
            command.Parameters.AddWithValue("@Username", user_id);

            using var reader = command.ExecuteReader();
            if (!reader.Read()) return false; // 결과가 없다면 실패

            // db에 저장된 pw와 입력받은 pw가 같은지 비교한다.
            // 참고로 유저의 id string은 unique 하기 때문에 결과가 정확히 1개 나와야 한다.
            string db_password = reader.GetString(0);
            return db_password == hashed_password;
        }

        // 소멸자
        ~DBMaster()
        {
            // 소멸시 db 연결을 끊는다.
            user_connection.Close();
        }
    }
}
