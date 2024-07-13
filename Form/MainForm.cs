using POS_Project_Team2.Class;

namespace POS_Project_Team2
{

    public partial class MainForm : Form
    {
        private Button[] wait_buttons;

        public bool paymentform_purchase = false;   // PaymentForm이 구매로 닫힐 때 대기로 닫힐 때를 구분하기 위해 생성
        public int total_num_sales = 0;             // 금일 총 판매 건수
        public int total_num_refund = 0;            // 금일 총 환불 건수
        public int total_num_profit = 0;            // 금일 총 수익
        public int total_previous_purchase = 0;     // 이전 구매액


        public MainForm()
        {
            InitializeComponent();

            // 실행시 창을 화면 중앙에 위치시키기
            this.StartPosition = FormStartPosition.CenterScreen;

            // 폼 크기 조절 불가능하게 설정
            FormHelper.disable_resize(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 대기열 버튼 이벤트 핸들러 등록
            register_wait_button_event_handler();

            // RealTimeClock 싱글톤 인스턴스를 가져와서 레이블을 등록
            RealTimeClock.Instance.register_label(label_realtime_clock);

            // 타이머를 시작 (이미 시작된 경우에도 문제가 없음)
            RealTimeClock.Instance.start_clock();

            // picturebox 배경 투명으로 설정하기
            set_picture_box_transparent();
        }

        // 대기열 버튼 이벤트 핸들러 등록
        private void register_wait_button_event_handler()
        {
            wait_buttons = new Button[] { button_wait1, button_wait2, button_wait3 };
            foreach (var button in wait_buttons)
                button.Click += wait_button_Click;
        }

        // picturebox 배경 투명으로 설정하기
        private void set_picture_box_transparent()
        {
            // picturebox 투명으로 설정하기
            picture_box_alarm.BackColor = Color.Transparent;

            // picturebox 투명을 위해선 자신이 겹쳐있는 컨트롤을 부모로 설정해야 제대로 설정된다 : 중요
            //picture_box_alarm.Parent = picture_box_top;

            picture_box_menu.BackColor = Color.Transparent;
            //picture_box_menu.Parent = picture_box_top;
        }

        // 결제 버튼
        private void button_payment_Click(object sender, EventArgs e)
        {
            PaymentForm payment_form = new PaymentForm(this);
            payment_form.FormClosing += PaymentForm_FormClosing;
            payment_form.Owner = this;
            FormHelper.show(payment_form);
        }

        // 대기열 버튼 활성화 시키는 함수 WaitNumber 을 인자로 받아서 버튼을 활성화 시킨다
        public void enable_wait_button(WaitNumber wait_number)
        {
            // 버튼 전체를 우선 다 비활성화 시킨다
            // foreach (var button in wait_buttons)
            //    button.Enabled = false;

            int index = (int)wait_number - 1;
            // 활성화된 이외의 버튼을 회색으로
            foreach (var button in wait_buttons)
            {
                if (button != wait_buttons[index])
                    button.BackColor = Color.LightGray;
            }


            // 해당 버튼만 활성화 시킨다
            //wait_buttons[(int)wait_number - 1].Enabled = true;

            // 활성화된 버튼을 파란색으로
            wait_buttons[(int)wait_number - 1].BackColor = SystemColors.MenuHighlight;
        }
        // 통합 조회 버튼
        private void button_get_all_Click(object sender, EventArgs e)
        {
            // DB 에서 결제 내역을 가져온다
            DBMaster db_master = DBMaster.Instance;
            List<TotalRecord> payment_data = db_master.get_all_total_records_data();

            // 총 결제 내역 창 열기
            MultiPurposeShowForm log_form = new MultiPurposeShowForm();
            FormHelper.show(log_form);

            // 총 결제 내역 창 리스트뷰 및 라벨 설정
            log_form.set_form_role(payment_data, "현재 모든 로그 기록을 확인중입니다.");
        }

        // 재고 조회 버튼
        private void button_get_stock_Click(object sender, EventArgs e)
        {
            // 재고 조회 모드로 재고 창을 연다.
            StockForm stock_form = new StockForm();
            stock_form.set_stock_view_mode();
            FormHelper.show(stock_form);
        }

        // 총 결제 내역 조회
        private void button_get_tpt_Click(object sender, EventArgs e)
        {
            // DB 에서 결제 내역을 가져온다
            DBMaster db_master = DBMaster.Instance;
            var payment_data = db_master.get_all_payments_table_data();

            // 총 결제 내역 창 열기
            MultiPurposeShowForm log_form = new MultiPurposeShowForm();
            FormHelper.show(log_form);

            // 총 결제 내역 창 리스트뷰 및 라벨 설정
            log_form.set_form_role(payment_data, "현재 총 결제 기록을 확인중입니다.");
        }

        private void button_wait1_Click(object sender, EventArgs e)
        {
            // 현재 대기열 1에서만 작동합니다 메세지 박스 출력
            // MessageBox.Show("현재 대기열 1에서만 작동합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 대기열 버튼 1/2/3 클릭시 발생
        private void wait_button_Click(object sender, EventArgs e)
        {
            // 대기열 버튼을 클릭하면 해당 대기열 이외에 다른 대기열 버튼의 색을 회색으로 변경
            Button button = (Button)sender;
            foreach (var wait_button in wait_buttons)
            {
                if (wait_button != button)
                    wait_button.BackColor = Color.LightGray;
            }

            // 누른 버튼을 파란색으로 변경
            button.BackColor = SystemColors.MenuHighlight;

            // 누른 버튼에 따라 wait_number를 결정
            WaitNumber active_wait_number = WaitNumber.None;
            if (button == button_wait1)
                active_wait_number = WaitNumber.Wait1;
            else if (button == button_wait2)
                active_wait_number = WaitNumber.Wait2;
            else if (button == button_wait3)
                active_wait_number = WaitNumber.Wait3;

            // 이미 PaymentForm이 열려온 경우 참조(주소)를 얻고
            // 이미 열려있는 창에 대해 자식폼에 대기열 라벨 클릭을 요구한다.
            foreach (Form form in Application.OpenForms)
            {
                if (form is PaymentForm)
                {
                    PaymentForm existing_form = (PaymentForm)form;
                    existing_form.click_wait_button(active_wait_number);
                    return;
                }
            }
            // 활성화 내역을 PaymentForm에 전달해 창을 연다
            PaymentForm payment_form = new PaymentForm(this, active_wait_number);
            FormHelper.show(payment_form);
            payment_form.click_wait_button(active_wait_number);
        }



        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        public void update_wait_button(int index, Color color)
        {
            if (index >= 0 && index < wait_buttons.Length)
            {
                wait_buttons[index].BackColor = color;
            }
        }


        // 모든 기록 삭제 버튼
        private void button_clear_all_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("해당 기능 사용시 저장된 모든 데이터가 삭제되며, 초기 프로그램 상태로 돌아갑니다. 또한 프로그램이 자동 재실행 됩니다. 수행하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // 자동 로그인 파일 삭제
                    if (File.Exists(LoginForm.auto_login_file_path))
                        File.Delete(LoginForm.auto_login_file_path);

                    // db 파일 삭제
                    DBMaster db_master = DBMaster.Instance;
                    db_master.clear_db_file();

                    // 데이터 청소가 완료되었습니다 메세지 출력
                    MessageBox.Show("모든 데이터가 삭제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 프로그램 재시작
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    // 오류 발생시 메세지 박스로 오류 출력
                    MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        // 환불 라벨 업데이트 함수
        public void update_refund_label()
        {
            total_num_refund++;
            label_total_num_refund.Text = "금일 총 환불 " + total_num_refund + "건";
        }

        // 환불 버튼
        private void button_refund_Click(object sender, EventArgs e)
        {
            DBMaster db_master = DBMaster.Instance;
            var payment_data = db_master.get_all_payments_table_data();

            // 총 결제 내역 창 열기
            MultiPurposeShowForm log_form = new MultiPurposeShowForm();
            log_form.Owner = this;  // 나중에 수익 값 조절하기 위해 Main 폼 부모로

            FormHelper.show(log_form);

            log_form.set_form_role(payment_data, "환불하고 싶으면 결제 내역을 오른쪽 클릭해주세요.");
            log_form.enable_refund_mode();

        }

        // 환불 내역 버튼
        private void button_get_refund_Click(object sender, EventArgs e)
        {
            // 환불 내역 조회
            DBMaster db_master = DBMaster.Instance;
            var refund_data = db_master.get_all_refunds_table_data();

            MultiPurposeShowForm log_form = new MultiPurposeShowForm();
            FormHelper.show(log_form);
            log_form.set_form_role(refund_data, "환불 내역을 표시하고 있습니다. 환불을 원하시면 메인 화면의 환불 버튼을 클릭해주세요.");

        }

        // 환불 후 MainForm의 라벨 업데이트하는 함수
        public void update_label()
        {
            label_tatal_num_sales.Text = "금일 총 판매 " + total_num_sales + "건";
            label_total_num_profit.Text = "금일 총 수익 " + total_num_profit + "원";
            label_total_num_refund.Text = "금일 총 환불 " + total_num_refund + "건";
            label_total_previous_payment.Text = total_previous_purchase + "원";
            label_total_previous_purchase.Text = total_previous_purchase + "원";
        }

        // 영수증 조회 버튼
        private void button_get_receipt_Click(object sender, EventArgs e)
        {
            // DB 에서 영수증 데이터 모두 가져오기
            DBMaster db_master = DBMaster.Instance;
            var receipt_data = db_master.get_all_receipt_table_data();

            // 영수증 출력시 별도의 폼 이용
            ReceiptViewForm receipt_view_form = new ReceiptViewForm(receipt_data);
            FormHelper.show(receipt_view_form);
        }

        // 영수증 출력 버튼
        private void button_receipt_Click(object sender, EventArgs e)
        {
            // DB 에서 결제 내역을 가져온다
            DBMaster db_master = DBMaster.Instance;
            var payment_data = db_master.get_all_payments_table_data();

            MultiPurposeShowForm log_form = new MultiPurposeShowForm();

            // 총 결제 내역 창 리스트뷰 및 라벨 설정
            log_form.set_form_role(payment_data, "");

            // 영수증 모드 활성화
            log_form.enable_recepit_mode();

            // 총 결제 내역 창 열기
            FormHelper.show(log_form);
        }

    }
}
