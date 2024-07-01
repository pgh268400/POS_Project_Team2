using POS_Project_Team2.Class;

namespace POS_Project_Team2
{
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
        public static string auto_login_file_path = "autologin"; // program.cs에서 사용하기 위해 public으로 변경

        public LoginForm()
        {

            InitializeComponent();

            // 실행시 창을 화면 중앙에 위치시키기
            this.StartPosition = FormStartPosition.CenterScreen;

            // 폼 사이즈 변경 금지
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


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
            DBMaster db_master = DBMaster.Instance; // 싱글톤 접근이라 new를 쓰지 않는다.
            string hashed_pw = db_master.get_user_pw_by_id(user_id);

            if (hashed_pw != "")
            {
                // autologin 파일을 생성하고 id와 pw를 각각 저장해놓는다
                File.WriteAllText(auto_login_file_path, $"{user_id}\n{hashed_pw}");
            }
            else
            {
                throw new Exception("자동 로그인 파일 생성에 실패했습니다.");
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

            DBMaster db_master = DBMaster.Instance;
            if (!db_master.is_login_success(input_id, input_pw))
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
