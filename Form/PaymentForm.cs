using POS_Project_Team2.Class;
using System.Xml.Linq;

namespace POS_Project_Team2
{
    public partial class PaymentForm : Form
    {
        // 대기열 라벨을 담는 배열
        private Label[] labels_wait;

        public DataForm data_form;
        private List<(string item_name, int item_cost, int item_count)> products = new List<(string item_name, int item_cost, int item_count)>();
        public PaymentForm(List<(string item_name, int item_cost, int item_count)> products = null)
        {
            InitializeComponent();

            if (products != null)
            {
                this.products = new List<(string item_name, int item_cost, int item_count)>(products);
            }

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

        //ListView의 보여질 목록
        private void list_view_control(List<(string item_name, int item_cost, int item_count)> products)
        {
            listview_product.Clear();    //기존에 있던 물품 지움. 이전 물건들 List Products에 저장되어있어서 지우지않으면 중복으로 생김

            listview_product.BeginUpdate();  //업데이트 끝날 때까지 UI 중지

            listview_product.View = View.Details;    //뷰모드 지정

            int total_num_purchase = 0;
            int total_price_purchase = 0;


            int index = 1;  //No 나타내는 index 값

            foreach (var product in products)    //products 리스트 돌면서 선택된 '물품 넘버', '이름', '갯수', '가격', '총가격' ListView에 추가
            {
                ListViewItem lvi = new ListViewItem(index.ToString());
                ++index;    //물품 하나 출력할 때마다 No 수 늘려주기

                lvi.SubItems.Add(product.item_name);
                lvi.SubItems.Add(product.item_count.ToString());
                lvi.SubItems.Add(product.item_cost.ToString());

                int total_cost = product.item_cost * product.item_count;  //총가격 가격 * 갯수

                lvi.SubItems.Add(total_cost.ToString());
                listview_product.Items.Add(lvi); //Listview에 추가

                total_num_purchase += product.item_count;
                total_price_purchase += total_cost;
            }

            //Column 설정
            listview_product.Columns.Add("No", 30, HorizontalAlignment.Left);
            listview_product.Columns.Add("물품명", 200, HorizontalAlignment.Left);
            listview_product.Columns.Add("수량", 70, HorizontalAlignment.Left);
            listview_product.Columns.Add("단가", 70, HorizontalAlignment.Left);
            listview_product.Columns.Add("금액", 70, HorizontalAlignment.Left);

            listview_product.EndUpdate();    //업데이트 끝

            label_num_product.Text = total_num_purchase.ToString();
            label_amount_money.Text = total_price_purchase.ToString();
            label_total_amount.Text = total_price_purchase.ToString();

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // 실시간 시계 등록 및 시작
            register_realtime_clock();

            // 대기열 라벨 이벤트 핸들러 등록 및 초기화
            init_label_wait();

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


        //물품 선택 버튼 클릭 시 물품 선택하는 DataForm 열고 물품 값 가져오는 메서드
        private void btn_SelectProduct_Click(object sender, EventArgs e)
        {
            if (data_form == null || data_form.IsDisposed)
            {
                data_form = new DataForm();
            }

            if (data_form.ShowDialog() == DialogResult.OK)
            {
                products.AddRange(data_form.items);
                list_view_control(products);
            }
        }

        // 결제 버튼 클릭 시DataForm에서 재고처리 미리 해서 메시지만 띄움 >> MainForm에서 업데이트 되도록 해야함
        private void button_card_Click(object sender, EventArgs e)
        {
            if (listview_product.Items.Count > 0)
            {
                // 포인트 정립 상태. 기본은 null이다.
                string name = "null";
                string phone_number = "null";

                // 포인트를 적립할 건지 메세지 박스를 띄운다.
                DialogResult result = MessageBox.Show("포인트를 적립하시겠습니까?", "포인트 적립", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        MessageBox.Show($"{name} 님 {phone_number} 번호로 포인트가 적립되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 포인트 적립을 취소하는 경우 아무것도 하지 않는다.
                    }

                }

                // 결제 내역을 로그에 기록한다.
                Logger logger = new Logger();

                // products 를 로그에 기록한다.
                // products를 for문을 돌면서 순회하고,
                // (아이템 이름, 아이템 가격, 아이템 개수, 총 금액, name, phonenumber)
                // 형태로 string [] 으로 바꾼다.
                // 이를 logger.append_payment_log() 메소드에 넘겨주면 된다.
                foreach (var product in products)
                {
                    int total_cost = product.item_cost * product.item_count;
                    string[] log_entry = new string[]
                    {
                product.item_name,
                product.item_cost.ToString(),
                product.item_count.ToString(),
                total_cost.ToString(),
                name,
                phone_number
                    };

                    // logger.append_payment_log() 메소드에 넘겨주면 된다.
                    logger.append_payment_log(log_entry);
                }

                listview_product.Clear();
                MessageBox.Show("결제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();

            }
            else
            {
                MessageBox.Show("상품을 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //취소 버튼 클릭 시 담았던 재고 원상 복구
        private void button_all_cancle_Click(object sender, EventArgs e)
        {

            if (data_form != null)
            {
                data_form.RestoreOriginalData();    // DataForm의 원본 데이터 복원 메서드 호출
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("결제시 포인트 등록이 가능합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_wait_Click(object sender, EventArgs e)
        {
            MainForm mainForm = (MainForm)this.Owner;
            mainForm.UpdateWaitButton(0, Color.Red);
            this.Close();
        }
        public List<(string item_name, int item_cost, int item_count)> GetProducts()
        {
            return new List<(string item_name, int item_cost, int item_count)>(products);
        }
    }
}
