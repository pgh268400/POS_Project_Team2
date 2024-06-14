using POS_Project_Team2.Class;

namespace POS_Project_Team2
{
    public partial class MainForm : Form
    {

        // 해당 폼에서 payment_form의 인스턴스를 관리한다.
        private PaymentForm payment_form;


        public MainForm()
        {
            // 실행시 창을 화면 중앙에 위치시키기
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        private void set_picture_box_transparent()
        {
            // picturebox 투명으로 설정하기
            picture_box_alarm.BackColor = Color.Transparent;

            // picturebox 투명을 위해선 자신이 겹쳐있는 컨트롤을 부모로 설정해야 제대로 설정된다 : 중요
            picture_box_alarm.Parent = picture_box_top;

            picture_box_menu.BackColor = Color.Transparent;
            picture_box_menu.Parent = picture_box_top;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // RealTimeClock 싱글톤 인스턴스를 가져와서 레이블을 등록
            RealTimeClock.Instance.register_label(label_realtime_clock);

            // 타이머를 시작 (이미 시작된 경우에도 문제가 없음)
            RealTimeClock.Instance.start_clock();

            // picturebox 배경 투명으로 설정하기
            set_picture_box_transparent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*
              결제를 누르면 PaymentForm으로 이동
              계속 버튼을 누르면 폼이 생성되서 새로운 창이 열리므로
              이미 열린 상태인지 체크해야 한다.
              기본적으로 멤버 변수에 기억하여 관리하면 된다.
            */

            // payment_form 객체 변수가 null이면 폼이 생성 안된 상태이므로 새로 생성하고 보여준다.
            if (payment_form == null)
            {
                payment_form = new PaymentForm();
                payment_form.FormClosed += PaymentForm_FormClosed; // 폼이 닫힐 때 이벤트 핸들러 등록
                payment_form.Show();
            }
            // 이미 생성된 폼이 있으면 생성은 필요 없고 최상단으로 끌어와서 표시 해주면 된다.
            else
            {
                // Activate() 를 사용하면 폼을 최상단으로 표시해줄 수 있다.
                payment_form.Activate();
            }
        }

        private void PaymentForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // 폼이 닫힐 때 payment_form 변수를 null로 설정
            // 이거 없으면 결제창 닫고 다시 열려고 할 때 결제창 안열린다.
            payment_form = null;
        }
    }
}
