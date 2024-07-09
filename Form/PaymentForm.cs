using POS_Project_Team2.Class;

namespace POS_Project_Team2
{
    public partial class PaymentForm : Form
    {
        // 대기열 라벨을 담는 배열
        private Label[] labels_wait;

        // 결제 창에서 물품 선택 폼을 메모리 접근 하기 위한 변수
        public StockForm stock_form;

        private List<StockRecord> products = new();

        int total_num_purchase = 0;
        int total_price_purchase = 0;

        // 전체 취소 버튼 누름 여부
        public bool all_cancel = false;

        public PaymentForm(List<StockRecord> products = null)
        {
            InitializeComponent();

            if (products != null)
            {
                this.products = new List<StockRecord>(products);
            }

            FormHelper.disable_resize(this);
        }

        // 실시간 시계 등록 및 시작
        private void register_realtime_clock()
        {
            // RealTimeClock 싱글톤 인스턴스를 가져와서 레이블을 등록
            RealTimeClock.Instance.register_label(label_realtime_clock);

            /*
              타이머를 시작
              앞에 MainForm 쪽에서 이미 실시간 시계가 시작되어도 문제가 없다.
              start_clock() 을 한다고 해도 MainForm 쪽에서 쓰는
              객체를 그대로 가져와서 사용하기에 시간 동기화 문제가 발생하지 않는다.
            */
            RealTimeClock.Instance.start_clock();
        }

        // 품목명을 받아서 리스트뷰 아이템을 삭제하는 함수, 못찾았다면 아무것도 하지 않는다.
        public void remove_item(string item_name)
        {
            bool item_found = false;

            // 리스트뷰 아이템을 삭제한다.
            foreach (ListViewItem item in listview_product.Items)
            {
                if (item.SubItems[1].Text == item_name)
                {
                    listview_product.Items.Remove(item);
                    item_found = true;
                    break;
                }
            }

            // 아이템을 찾지 못했으면 아무것도 하지 않는다
            if (!item_found)
            {
                return;
            }

            // 물품 개수와 총 금액을 업데이트한다.
            total_num_purchase -= 1;
            label_num_product.Text = total_num_purchase.ToString() + "개";

            // 물품 개수와 총 금액을 업데이트한다.
            foreach (var product in products)
            {
                if (product.ItemName == item_name)
                {
                    total_price_purchase -= product.Cost * product.Count;
                    break;
                }
            }

            label_amount_money.Text = total_price_purchase.ToString() + "원";
            label_total_amount.Text = total_price_purchase.ToString();
        }

        // 대기열 라벨 초기화
        private void init_label_wait()
        {
            /*
              대기열 라벨을 배열에 담는다.
              참고로 label 들은 이미 InitializeComponent 부분에서 new로 생성되어 있으므로,
              배열 내부에서 포인터로 참조하는 형태로 작동한다.
            */
            labels_wait = new Label[] { label_wait1, label_wait2, label_wait3 };

            // 대기 1,2,3 에 클릭 이벤트, 마우스 이벤트 추가
            for (int i = 0; i < labels_wait.Length; i++)
            {
                labels_wait[i].Click += wait_click_event;
                labels_wait[i].MouseEnter += label_mouse_enter;
                labels_wait[i].MouseLeave += label_mouse_leave;
            }

            // 초기 대기열은 1번만 활성화하고, 나머지는 비활성화 되어 있는 상태이다. (회색 글자 처리)
            label_wait1.ForeColor = Color.Black;
            label_wait2.ForeColor = Color.Gray;
            label_wait3.ForeColor = Color.Gray;
        }

        // ListView의 보여질 목록
        private void list_view_control(List<StockRecord> products)
        {
            // 기존에 있던 물품 지움. 이전 물건들 List Products에 저장되어있어서 지우지않으면 중복으로 생김
            listview_product.Items.Clear();

            // 기존 물품 정보 초기화
            total_num_purchase = 0;
            total_price_purchase = 0;

            //업데이트 끝날 때까지 UI 중지
            listview_product.BeginUpdate();

            // 뷰모드 지정
            listview_product.View = View.Details;

            foreach (var product in products)    //products 리스트 돌면서 선택된 '물품 넘버', '이름', '갯수', '가격', '총가격' ListView에 추가
            {
                ListViewItem listview_item = new ListViewItem(product.Id.ToString());
                listview_item.SubItems.Add(product.ItemName);
                listview_item.SubItems.Add(product.Count.ToString());
                listview_item.SubItems.Add(product.Cost.ToString());

                int total_cost = product.Cost * product.Count;  //총가격 가격 * 갯수

                listview_item.SubItems.Add(total_cost.ToString());
                listview_product.Items.Add(listview_item); //Listview에 추가

                total_num_purchase += product.Count;   //총 구매액 계산
                total_price_purchase += total_cost;         //총 갯수 계산
            }

            // Column 설정
            //listview_product.Columns.Add("Id", 30, HorizontalAlignment.Left);
            //listview_product.Columns.Add("물품명", 200, HorizontalAlignment.Left);
            //listview_product.Columns.Add("수량", 70, HorizontalAlignment.Left);
            //listview_product.Columns.Add("단가", 70, HorizontalAlignment.Left);
            //listview_product.Columns.Add("금액", 70, HorizontalAlignment.Left);

            listview_product.EndUpdate();    //업데이트 끝

            label_num_product.Text = total_num_purchase.ToString() + "개";     //총 물품 개수
            label_amount_money.Text = total_price_purchase.ToString() + "원";  //총 구매액
            label_total_amount.Text = total_price_purchase.ToString();  //거스름돈 0원 고정하고 총 구매액하고 같게 설정

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // 실시간 시계 등록 및 시작
            register_realtime_clock();

            // 대기열 라벨 이벤트 핸들러 등록 및 초기화
            // init_label_wait();

            // 리스트뷰 너비 비율 조정
            FormHelper.adjust_column_widths(listview_product, new int[] { 10, 40, 20, 15, 15 });

            if (products.Count > 0)
            {
                list_view_control(products);
            }

        }

        // 마우스가 라벨 위에 있을 때 호출되는 메소드
        private void label_mouse_enter(object sender, EventArgs e)
        {
            Label hovered_label = sender as Label;
            if (hovered_label != null)
            {
                hovered_label.Cursor = Cursors.Hand; // 손 모양 커서로 변경
            }
        }

        // 마우스가 라벨을 벗어났을 때 호출되는 메소드
        private void label_mouse_leave(object sender, EventArgs e)
        {
            Label hovered_label = sender as Label;
            if (hovered_label != null)
            {
                hovered_label.Cursor = Cursors.Default; // 기본 커서로 변경
            }
        }

        // 대기열 1/2/3 클릭시 실행되는 이벤트 핸들러(=함수)
        private void wait_click_event(object? sender, EventArgs e)
        {
            Label clicked_label = sender as Label; // 클릭된 라벨을 가져온다.

            // 모종의 이유로 클릭 라벨이 빈 경우 함수를 강제 종료한다.
            if (clicked_label == null)
                return;

            if (clicked_label == label_wait1)
            {
                // 대기 1 라벨 클릭시
                label_wait1.Text = "대기중";
                label_wait1.BackColor = Color.Red;
            }
            else if (clicked_label == label_wait2)
            {
                // 대기 2 라벨 클릭시
                label_wait2.Text = "대기중";
                label_wait2.BackColor = Color.Red;
            }
            else if (clicked_label == label_wait3)
            {
                // 대기 3 라벨 클릭시
                label_wait3.Text = "대기중";
                label_wait3.BackColor = Color.Red;
            }

        }


        // 물품 선택 버튼 클릭 시 물품 선택하는 DataForm 열고 물품 값 가져오는 메서드
        private void btn_SelectProduct_Click(object sender, EventArgs e)
        {
            // data_form 의 경우 첫 번째 열때만 생성하고
            if (stock_form == null || stock_form.IsDisposed)
            {
                stock_form = new StockForm(this);
            }

            // 이후 이미 data_form 이 생성된 경우 ShowDialog() 로 열기만 해서 같은 창을 열도록 한다(재활용) 한다. 
            // 이렇게 설계한 이유는 재고 선택 창을 껐다 켜도 그대로 데이터를 유지시키기 위해서다.
            if (stock_form.ShowDialog() == DialogResult.OK)
            {
                products.Clear();
                products.AddRange(stock_form.select_items);
                list_view_control(products);
            }
        }

        // 결제 버튼 클릭 시 DataForm에서 재고처리 미리 해서 메시지만 띄움 >> MainForm에서 업데이트 되도록 해야함
        private void button_card_Click(object sender, EventArgs e)
        {
            if (listview_product.Items.Count <= 0)
            {
                MessageBox.Show("상품을 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 포인트 정립 상태. 기본은 null이다.
            // 문자열에 null을 허용하기 위해 nullable 타입인 string? 을 사용한다.
            string? name = null;
            string? phone_number = null;

            // 포인트를 적립할 건지 메세지 박스를 띄운다.
            DialogResult result = MessageBox.Show("포인트를 적립하시겠습니까?", "포인트 적립", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // 이 포인트의 경우 유저의 전화번호 뒷자리와 이름을 입력받아야 한다.
                // 이를 위한 폼을 띄운다.

                PointForm point_form = new PointForm();
                if (point_form.ShowDialog() == DialogResult.OK)
                {
                    // 포인트 폼에서 이름과 전화번호 뒷자리를 가져온다.
                    name = point_form.name;
                    phone_number = point_form.phone_number;


                    // 포인트 적립이 완료되었음을 알린다.
                    MessageBox.Show($"{name} 님 {phone_number} 번호로 포인트가 적립되었습니다.", "알림", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    // 포인트 적립을 취소하는 경우 아무것도 하지 않는다.
                }
            }

            // 결제 내역을 DB에 기록한다.
            DBMaster db_master = DBMaster.Instance;

            /*
              products를 for문을 돌면서 순회하고,
              (아이템 이름, 아이템 가격, 아이템 개수, 총 금액, 포인트 결제자명, 전화번호 4자리)
              을 db에 기록하자.
            */

            // products 출력
            foreach (var product in products)
            {
                Console.WriteLine(product.Id);
                Console.WriteLine(product.ItemName);
                Console.WriteLine(product.Cost);
                Console.WriteLine(product.Count);
            }

            // for문을 돌면서 DB에 결제 데이터를 삽입한다.
            foreach (var product in products)
            {
                int total_cost = product.Cost * product.Count;

                var payment = new PayMentRefundRecord
                {
                    Time = DateTime.Now,
                    ItemName = product.ItemName,
                    UnitPrice = product.Cost,
                    Count = product.Count,
                    TotalPrice = total_cost,
                    Payer = name,
                    PhoneNumber = phone_number
                };
                db_master.insert_payment_data(payment);
            }


            // 현재 선택한 products 에 있는 데이터를 db 에 업데이트 한다.

            foreach (var product in products)
            {
                // product를 활용해 Stack Record를 생성 한다
                StockRecord stock_record = new StockRecord
                {
                    // Update 시 기본키인 id를 이용해 업데이트 하므로
                    // 반드시 id를 넣어주어야 한다.
                    Id = product.Id,
                    ItemName = product.ItemName,
                    Cost = product.Cost,
                    // Count = product.Count <-- 이렇게 쓰면 현재 선택된 수량이 업데이트 되서 의미가 없어진다
                    // 재고의 경우 data grid view에서 감소된 재고를 얻어와야 한다.
                    Count = stock_form.get_stock_count(product.ItemName)
                };

                // 재고 데이터 업데이트
                db_master.update_stock_data(stock_record);
            }

            // 결제한 내역을 재고창 폼에 넘긴다
            stock_form.remove_selected_items(products);

            // 결제 후 리스트 뷰 초기화
            listview_product.Clear();
            products.Clear();

            MessageBox.Show("결제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MainForm main_form = (MainForm)this.Owner;
            main_form.UpdateWaitButton(0, Color.Gray);
            main_form.paymentform_purchase = true;
            main_form.total_num_sales += 1;
            main_form.total_num_profit += total_price_purchase;
            main_form.total_previous_purchase = total_price_purchase;

            // 받을 금액 초기화
            label_total_amount.Text = "0";
        }

        // 취소 버튼
        private void button_all_cancle_Click(object sender, EventArgs e)
        {
            // 모든 물품 삭제
            listview_product.Items.Clear();

            // 받을 금액 초기화
            label_total_amount.Text = "0";

            // 개수랑 원도 초기화
            label_num_product.Text = "0개";
            label_amount_money.Text = "0원";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("결제시 포인트 등록이 가능합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_wait_Click(object sender, EventArgs e)
        {
            // MainForm mainForm = (MainForm)this.Owner;
            // mainForm.paymentform_purchase = false;
            // this.Close();
        }
        public List<StockRecord> get_products()
        {
            return new List<StockRecord>(products);
        }
    }
}
