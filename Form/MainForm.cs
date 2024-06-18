﻿using POS_Project_Team2.Class;

namespace POS_Project_Team2
{

    public partial class MainForm : Form
    {
        private List<List<(string item_name, int item_cost, int item_count)>> savedProducts = new List<List<(string item_name, int item_cost, int item_count)>>();
        private Button[] waitButtons;

        public bool paymentform_purchase = false;   //PaymentForm이 구매로 닫힐 때 대기로 닫힐 때를 구분하기 위해 생성
        public int total_num_sales = 0;             //금일 총 판매 건수
        public int total_num_refund = 0;            //금일 총 환불 건수
        public int total_num_profit = 0;            //금일 총 수익
        public int total_previous_purchase = 0;     //이전 구매액

        public MainForm()
        {
            // 실행시 창을 화면 중앙에 위치시키기
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            InitializeWaitButtons();
        }

        private void InitializeWaitButtons()
        {
            waitButtons = new Button[] { button_wait1, button_wait2, button_wait3 };

            foreach (var button in waitButtons)
            {
                button.Click += WaitButton_Click;
                button.BackColor = Color.Gray;
            }
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

            // 영수증, 상품 조회, 영수증 조회 숨기기
            button_receipt.Hide();
            button_get_goods.Hide();
            button_get_receipt.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 결제를 누르면 PaymentForm으로 이동
            var paymentForm = new PaymentForm();
            FormHelper.show(paymentForm);
            paymentForm.FormClosing += PaymentForm_FormClosing;
            paymentForm.Owner = this;
            paymentForm.Show();
        }


        private void button_get_all_Click(object sender, EventArgs e)
        {
            MessageBox.Show("통합 조회의 경우 아래 재고조회, 총 결제 내역 조회를 사용해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 재고 조회
        private void button_get_stock_Click(object sender, EventArgs e)
        {
            DataForm data_form = new DataForm();
            FormHelper.show(data_form);
            data_form.block_all();
        }

        // 총 결제 내역 조회
        private void button_get_tpt_Click(object sender, EventArgs e)
        {
            // 총 결제 내역 창 열기
            FormHelper.show(new PayMentLogShowForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button_wait1_Click(object sender, EventArgs e)
        {

        }

        private void button_wait3_Click(object sender, EventArgs e)
        {

        }

        private void button_receipt_Click(object sender, EventArgs e)
        {

            // 영수증 출력을 위해 PayMentLogShowForm으로 이동
            PayMentLogShowForm log_form = new PayMentLogShowForm();

            // 영수증 출력할거라고 함수 호출
            log_form.enable_recepit_mode();

            FormHelper.show(log_form);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 정말 모든걸 삭제할거냐는 메세지 출력
            DialogResult result = MessageBox.Show("정말 모든 데이터를 삭제하시겠습니까? 모든 로그 데이터는 삭제되고, 재고 데이터가 원상 복구됩니다.", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Logger 이용해 로그 삭제
                Logger logger = new Logger();
                logger.delete_all_log();

                // 재고 데이터 원상복귀 (추후 구현)

                // 데이터 청소가 완료되었습니다 메세지 출력
                MessageBox.Show("모든 데이터가 삭제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void WaitButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            int index = Array.IndexOf(waitButtons, clickedButton);

            if (index >= 0 && index < savedProducts.Count)
            {
                var products = savedProducts[index];
                var paymentForm = new PaymentForm(products);
                paymentForm.FormClosing += PaymentForm_FormClosing;
                paymentForm.Owner = this;
                FormHelper.show(paymentForm);
            }
        }

        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var closingForm = sender as PaymentForm;

            if (closingForm != null && !paymentform_purchase)
            {
                int index = savedProducts.FindIndex(products => products.SequenceEqual(closingForm.GetProducts()));
                if (index >= 0)
                {
                    savedProducts[index] = closingForm.GetProducts();
                }
                else
                {
                    savedProducts.Add(closingForm.GetProducts());
                    int waitButtonIndex = savedProducts.Count - 1;
                    if (waitButtonIndex < waitButtons.Length && !paymentform_purchase)
                    {
                        waitButtons[waitButtonIndex].BackColor = Color.Red;
                    }
                }
            }
            else if (closingForm != null && paymentform_purchase)
            {
                label_tatal_num_sales.Text = "금일 총 판매 " + total_num_sales + "건";
                label_total_num_profit.Text = "금일 총 수익 " + total_num_profit + "원";
                label_total_previous_payment.Text = total_previous_purchase + "원";
                label_total_previous_purchase.Text = total_previous_purchase + "원";

            }
        }
        public void UpdateWaitButton(int index, Color color)
        {
            if (index >= 0 && index < waitButtons.Length)
            {
                waitButtons[index].BackColor = color;
            }
        }

        private void button_clear_all_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("해당 기능 사용시 저장된 모든 데이터가 삭제되며, 초기 프로그램 상태로 돌아갑니다. 또한 프로그램이 자동 재실행 됩니다. 수행하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Logger 이용해 로그 삭제
                Logger logger = new Logger();
                logger.delete_all_log();

                // 컴퓨터에 저장된 재고 데이터 item_data.xml 존재하는 경우 삭제
                if (File.Exists("item_data.xml"))
                    File.Delete("item_data.xml");

                // 자동 로그인 파일 삭제
                if (File.Exists("autologin"))
                    File.Delete("autologin");

                // 데이터 청소가 완료되었습니다 메세지 출력
                MessageBox.Show("모든 데이터가 삭제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 프로그램 재시작
                Application.Restart();
            }
        }
    }
}
