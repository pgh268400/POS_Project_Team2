using POS_Project_Team2.Class;

namespace POS_Project_Team2
{
    public partial class MainForm : Form
    {
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
            // 결제를 누르면 PaymentForm으로 이동
            FormHelper.show(new PaymentForm());
        }


        private void button_get_all_Click(object sender, EventArgs e)
        {

        }

        // 재고 조회
        private void button_get_stock_Click(object sender, EventArgs e)
        {

            FormHelper.show(new DataForm());
        }

        // 총 결제 내역 조회
        private void button_get_tpt_Click(object sender, EventArgs e)
        {
            // 총 결제 내역 창 열기
            FormHelper.show(new PayMentLogShowForm());
        }
    }
}
