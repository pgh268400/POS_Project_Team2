namespace POS_Project_Team2
{
    using System.Drawing.Drawing2D;
    public partial class LoginForm : Form
    {
        /*
          사용자 입장에서 가장 처음 만나는
          로그인 창 (Entry Point)
        */

        public LoginForm()
        {
            // 실행시 창을 화면 중앙에 위치시키기
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
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


        // 로그인 버튼
        private void button_login_Click(object sender, EventArgs e)
        {
            /*
               외부 라이브러리를 사용할 수 없으므로,
               DB 연결 및 로그인 처리는 문자열 평문 비교로 대체한다.
               id : admin, pw : admin
               양 옆에 공백이 있어도 문제 없이 로그인 되도록 Trim 처리후 비교한다.
             */
            if (textbox_id.Text.Trim() == "admin" && textbox_pw.Text.Trim() == "admin" || textbox_id.Text.Trim() == "admin@naver.com" && textbox_pw.Text.Trim() == "admin")
            {
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
                main_form.ShowDialog();
            }
            else
            {
                // 로그인 실패
                MessageBox.Show("로그인에 실패했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DesignTest_Load(object sender, EventArgs e)
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

        // ID, PW 텍스트 박스에서 엔터키 입력시 수행하는 이벤트 핸들러
        private void get_enter(object sender, KeyPressEventArgs e)
        {
            // 엔터키 누르면 로그인 버튼 클릭 이벤트 발생
            if (e.KeyChar == (char)Keys.Enter)
            {
                button_login_Click(sender, e);
            }
        }
    }
}
