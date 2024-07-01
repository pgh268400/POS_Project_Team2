namespace POS_Project_Team2
{
    using System.Data.SQLite;
    using System.Drawing.Drawing2D;

    public partial class LoginForm : Form
    {
        /*
          사용자 입장에서 가장 처음 만나는
          로그인 창 (Entry Point)
        */

        /*
          sqlite를 이용하면 서버 없이 파일 단 1개만으로 db를 연습해볼 수 있다.
          참고 : https://ainayoon.tistory.com/7
          만약 db 파일이 없을경우 만드는 db 파일 이름
         */
        private static string db_file_path = "users.db";
        public static string auto_login_file_path = "autologin"; // program.cs에서 사용하기 위해 public으로 변경


        public static void init_db()
        {
            // 데이터베이스 파일 존재 여부 확인
            if (!File.Exists(db_file_path))
            {
                // 데이터베이스 파일이 없으면 생성하고 테이블 초기화
                create_database_with_table();
            }
        }

        private static void create_database_with_table()
        {
            string connection_string = $"Data Source={db_file_path};Version=3;";
            using (var connection = new SQLiteConnection(connection_string))
            {
                connection.Open();

                // 파일로 작업하지만 다루는건 당연히 SQL문법으로 다룬다.
                string create_table_query = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL
            )";
                using (var command = new SQLiteCommand(create_table_query, connection))
                {
                    // ExecuteNonQuery = SQL 명령문을 실행하지만 결과를 반환하지 않는 경우에 사용
                    // NonQuery = 결과 집합을 반환하지 않는다는 의미
                    command.ExecuteNonQuery();
                    Console.WriteLine("Users 테이블이 생성되었습니다.");
                }
            }

            // 새로 만들었으면 기본 유저 3개를 추가한다. (관리자)
            insert_user_data("pgh268400@naver.com", "$2a$11$AGSymNxbp5.vNByqEVqx0OnEuml73PhmDcs4P.qdWF66uf7CdnZV2");
            insert_user_data("admin@naver.com", "$2a$12$fayeaZIXIEqMVv4IkMDDaOb0KhE4a65/zel5oHJ9k..E2Q/EytTFu");
            insert_user_data("admin", "$2a$12$fayeaZIXIEqMVv4IkMDDaOb0KhE4a65/zel5oHJ9k..E2Q/EytTFu");
        }

        // 참고 : password 의 경우 반드시 비밀번호를 bcrypt 로 해싱한 값을 넣어야 한다.
        private static void insert_user_data(string username, string hashed_password)
        {
            string connection_string = $"Data Source={db_file_path};Version=3;";
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

        public LoginForm()
        {

            InitializeComponent();

            // 실행시 창을 화면 중앙에 위치시키기
            this.StartPosition = FormStartPosition.CenterScreen;

            // 폼 사이즈 변경 금지
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }

        private bool is_verify_auto_login()
        {
            // 먼저 autologin 파일이 존재하는지 확인한다.
            if (File.Exists(auto_login_file_path))
            {
                // 있다면 파일이 비지 않았는지, 두줄의 내용을 가지는지 확인한다
                string[] lines = File.ReadAllLines(auto_login_file_path);

                if (lines.Length != 2) return false;
                string username = lines[0];
                string hashed_password = lines[1];

                // db에 요청해 id에 해당하는 pw를 가져온다.
                string select_query = "SELECT Password FROM Users WHERE Username = @Username";
                string connection_string = $"Data Source={db_file_path};Version=3;";

                /*
                  C#에서 using 문을 간결하게 사용할 수 있도록 
                  C# 8.0부터 using 에 중괄호로 코드를 묶지 않아도 되는 문법 업데이트를 했다.
                  이 새로운 문법은 using 선언을 사용하여 자원을 자동으로 해제할 수 있다고 한다.
                  이 문법을 사용하면 블록 범위를 명시하지 않아도 되므로 코드가 간결해진다.
                  기존 using 과 비교했을때 기능상은 동일하다고 한다. 두 방식 모두 자원 해제
                  시점이 동일하다고 한다. by ChatGPT4o. 인공지능 챗봇의 답변이므로 정확한
                  내용은 msdn 및 인터넷 등지에서 검증이 필요하다.
                 */
                using var connection = new SQLiteConnection(connection_string);
                connection.Open();

                using var command = new SQLiteCommand(select_query, connection);
                command.Parameters.AddWithValue("@Username", username);

                using var reader = command.ExecuteReader();
                if (!reader.Read()) return false;

                // db에 저장된 해시된 비밀번호와 autologin 파일에 저장된 해시된 비밀번호가 일치하는지 확인
                string stored_hash = reader["Password"].ToString();
                if (stored_hash == hashed_password)
                {
                    // 일치하면 로그인 성공
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // 사각 패널 깎아서 뭉툭하게 만들기 (디자인)
        private void panel_background_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            int diameter = radius * 2;
            Rectangle bounds = new Rectangle(0, 0, panel_background.Width, panel_background.Height);

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.X + bounds.Width - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.X + bounds.Width - diameter, bounds.Y + bounds.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - diameter, diameter, diameter, 90, 90);
            path.CloseAllFigures();

            panel_background.Region = new Region(path);
        }

        private void process_auto_login(string user_id)
        {
            // db에 요청해 id에 해당하는 pw를 가져온다.
            string select_query = "SELECT Password FROM Users WHERE Username = @Username";
            string stored_hash = "";
            string connection_string = $"Data Source={db_file_path};Version=3;";
            using var connection = new SQLiteConnection(connection_string);
            connection.Open();

            using var command = new SQLiteCommand(select_query, connection);
            command.Parameters.AddWithValue("@Username", user_id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                stored_hash = reader["Password"].ToString();
            }

            if (stored_hash != "")
            {
                // autologin 파일을 생성하고 id와 pw를 각각 저장해놓는다
                File.WriteAllText(auto_login_file_path, $"{user_id}\n{stored_hash}");
            }
        }

        // 로그인 버튼
        private void button_login_Click(object sender, EventArgs e)
        {
            /*
               sqlite 와 bcrypt 를 이용해 pw를 검증한다.
               이미 users.db 안에 id 및 bcrypt로 암호화된 비밀번호가 저장되어 있다.
               가능한 id/pw
               1. admin / admin
               2. admin@naver.com / admin
               3. pgh268400@naver.com / 내가 항상 쓰던 비밀번호 (sqlite에 bcrypt로 암호화, 해싱되어 있다.)
             */

            // 입력된 ID와 비밀번호를 변수에 저장
            string input_id = textbox_id.Text.Trim();
            string input_pw = textbox_pw.Text.Trim();

            if (!is_valid_user(input_id, input_pw))
            {
                // 로그인 실패
                MessageBox.Show("로그인에 실패했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // 로그인 성공
            {

                // 자동 로그인 활성화된 경우
                if (checkbox_auto_login.Checked)
                    // id와 pw를 로그인 파일에 2줄로 저장한다
                    process_auto_login(input_id);


                /*
                  로그인 성공시 메인 화면으로 이동 :
                  로그인 창 숨기기
                  Close가 아닌 Hide를 하는 이유는, 본 프로그램의 시작점인 LoginForm이 닫히면
                  프로그램이 종료되기 때문이다. 따라서 본인은 숨김 처리한다.
                */
                this.Hide();

                /*
                  여기서 메인 화면을 띄우는데 중요한 점은,
                  메인 폼을 껐을때 프로그램이 종료되게 해야 하는데,
                  현재 Hide된 상태의 로그인 폼을 꺼야 완전히 종료가 된다.
                  따라서 메인 폼을 껐을때 해당 LoginForm이 같이 종료되도록
                  이벤트 핸들러를 걸어줘야 한다.
                 */

                MainForm main_form = new MainForm();
                main_form.Closed += (s, args) => this.Close(); // important!
                main_form.Show();
            }
        }

        private bool is_valid_user(string username, string password)
        {
            string connection_string = $"Data Source={db_file_path};Version=3;";
            using var connection = new SQLiteConnection(connection_string);
            connection.Open();

            // @Username = 자리표시자
            // SQL 쿼리에서 매개변수를 사용하여 값을 전달하기 위한 자리 표시자라고 한다.
            // 이는 SQL 인젝션 공격을 방지하고, 쿼리를 더 안전하게 작성할 수 있도록 도와준다고 한다.
            string select_query = "SELECT Password FROM Users WHERE Username = @Username";
            using var command = new SQLiteCommand(select_query, connection);
            command.Parameters.AddWithValue("@Username", username);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                string stored_hash = reader["Password"].ToString();
                // Install-Package BCrypt.Net-Next
                return BCrypt.Net.BCrypt.Verify(password, stored_hash);
            }
            else
                return false;
        }

        private void button_online_Click(object sender, EventArgs e)
        {
            MessageBox.Show("온라인 모드는 현재 사용하실 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button_offline_Click(object sender, EventArgs e)
        {
            MessageBox.Show("현재 오프라인 모드입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ? 버튼 = 정보 버튼

        private void button_information_Click(object sender, EventArgs e)
        {
            MessageBox.Show("아이디 / 비밀번호 분실, 사용법 및 회원가입 문의는 admin@naver.com 으로 문의 바랍니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        // ID, PW 텍스트 박스에서 엔터키 입력시 수행하는 이벤트 핸들러
        private void get_enter(object sender, KeyPressEventArgs e)
        {
            // 엔터키 누르면 로그인 버튼 클릭 이벤트 발생
            if (e.KeyChar == (char)Keys.Enter)
            {
                button_login_Click(sender, e);
            }
        }

        private void checkbox_auto_login_CheckedChanged(object sender, EventArgs e)
        {
            // 자동 로그인 체크했을때
            if (checkbox_auto_login.Checked)
            {
                DialogResult result = MessageBox.Show("해당 기능 사용시 다음 프로그램 실행시부터 로그인 없이 간편하게 프로그램을 사용할 수 있는 기능입니다. 자동 로그인을 비활성화 하고 싶으면 같은 경로 내의 autologin 파일을 삭제하시면 됩니다. 수행하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // 자동 로그인 기능의 경우 로그인이 성공한 경우에만 수행해야한다.
                }
                else
                {
                    // 체크 해제
                    checkbox_auto_login.Checked = false;
                }
            }
        }


        /*
         Load = 실제로 폼이 그려지기 직전에 발동한다.
         따라서 여기서 Hide를 걸면 작동하지 않는다.
         다 그려지지 않았는데 숨긴다고 했기 때문이다.
        */
        private void LoginForm_Load(object sender, EventArgs e)
        {


            // 유저 정보 저장할 db 없으면 자동 생성
            init_db();

            // ID, PW 입력창에 KeyPress 이벤트 핸들러 등록
            textbox_id.KeyPress += new KeyPressEventHandler(get_enter);
            textbox_pw.KeyPress += new KeyPressEventHandler(get_enter);

            // 편의를 위해 ID, PW를 미리 입력해놓는다.
            textbox_id.Text = "admin@naver.com";
            textbox_pw.Text = "admin";

            // 비밀번호에 포커스를 건다.
            textbox_pw.Focus();

        }
    }
}
