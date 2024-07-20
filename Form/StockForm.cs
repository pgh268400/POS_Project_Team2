using POS_Project_Team2.Class;
using System.ComponentModel;

namespace POS_Project_Team2
{
    public partial class StockForm : Form
    {
        // 부모폼인 결제 폼에 접근하기 위한 변수
        PaymentForm payment_form;

        /*
          폼을 열었다 닫아도 계속 유지되도록,
          전 객체(여기선 여러창) 가 공유하는 static 변수를 하나 선언
          이 변수는 아이템 품목을 임시적으로 저장하는 역할을 한다.  

          참고로 BindingList 란 바인딩을 위한 리스트로,
          이 데이터를 gridview 에 바인딩 시 이 데이터가 바뀌면 
          자동으로 gridview 에도 반영된다.
          따라서 값을 변경할 때는 그리드 뷰에서 직접 수정하는게 아니라 이 변수를 수정해야 한다.

          웹에서 Vue.js 에서 DOM 을 직접 수정하는게 안좋은 패턴이고, 데이터 바인딩된 변수를 수정해야만
          좋은 패턴인걸 기억해보면 된다.
        */
        public BindingList<StockRecord> stock_items = new();

        // 결제창과 공유할 선택한 결제 품목을 담는 리스트
        public List<StockRecord> select_items = new();

        int selected;
        private bool restart_status = false; // 다시 창을 껐다 켰는지 체크하는 변수

        // 결제창 추가하기에 의해 창이 닫힌지 체크하는 변수
        public bool is_closed_by_payment = false;

        // 생성자, 생성시 payment_form 을 부모로 참조해 함수를 호출할 수 있도록 한다
        public StockForm(PaymentForm payment_form = null)
        {
            InitializeComponent();

            // 실행시 창을 화면 중앙에 위치시키기
            this.StartPosition = FormStartPosition.CenterScreen;

            FormHelper.disable_resize(this);

            restart_status = false;

            // 부모폼인 결제폼에 접근하기 위한 변수를 초기화한다.
            if (payment_form != null)
                this.payment_form = payment_form;
        }


        // 해당 Load 함수는 폼이 닫히고 새로 열릴때마다 매번 새로 호출된다.
        private void DataForm_Load(object sender, EventArgs e)
        {
            // 아이템이 비어있는 경우 (첫 번째 창 연 경우) UI 기본 설정
            first_init_ui();


            // 환불폼에서 넘어온 경우 다시 바인딩
            var db_master = DBMaster.Instance;
            if (db_master.is_refund)
            {
                set_item_and_bind();
                db_master.is_refund = false;
            }

            /*
              리스트뷰에 아이템이 남아 있는 경우
              == 창을 닫고 다시 열었을 때
              이때 data grid view에 하이라이팅을 복구한다
              
              이유는 모르겠지만 창을 닫고 다시 열었을 때 같은 창을 참조해 열도록
              설계하였으나 grid view 에 선택한 포커스나 배경 하이라이팅은 소멸함을
              확인 했다. 따라서 복구 로직이 필요하다.
            */
            if (listview_selected.Items.Count > 0)
            {
                // 데이터가 바인딩된 후 하이라이팅 복구
                after_bind_execute_func(datagridview_stock, () =>
                {
                    highlight_gridview_item();
                    Console.WriteLine("하이라이팅 복구 완료");
                });
            }

            // 선택하다 중간에 나갔는 경우에도 아이템을 선택하도록 복구한다
            if (textbox_search.Enabled == false)
            {
                after_bind_execute_func(datagridview_stock, () =>
                {
                    // 선택하다 중간에 나갔다는 상황을 표시하기 위해 bool 변수 설정
                    restart_status = true;

                    // 검색 버튼 다시 클릭
                    button_search_Click(null, null);

                    // 포커싱도 다시 수량으로 넘김
                    textbox_count.Focus();

                    Console.WriteLine("선택 복구 완료");
                });
            }
        }

        // 데이터가 바인딩된 후 특정 동작을 수행하고 이벤트 핸들러를 제거하는 함수
        private void after_bind_execute_func(DataGridView data_grid_view, Action callback_func)
        {
            DataGridViewBindingCompleteEventHandler data_bind_complete_event_handler = null;
            data_bind_complete_event_handler = (s, ev) =>
            {
                callback_func();

                // 한 번만 동작을 수행하고 이벤트 핸들러를 제거한다.
                data_grid_view.DataBindingComplete -= data_bind_complete_event_handler;
            };

            data_grid_view.DataBindingComplete += data_bind_complete_event_handler;
        }

        /*
          data grid view 의 아이템이 비어있을 때,
          최초로 ui를 설정하는 함수. 아래는 수행하는 작업들이다.
          1. 물품명을 먼저 입력해야지 수량을 입력할 수 있으므로, 
             수량 텍스트 박스 및 수량 선택 버튼을 비활성화 한다.
          2. data grid view 를 수정할 수 없도록 ReadOnly로 설정한다.
          3. data grid view 선택 상태를 해제한다. (data grid view는 처음에 0행 0열에 선택되어 있다.)
          4. stock_items 를 초기화하고 데이터 그리드 뷰에 바인딩한다.
        */
        private void first_init_ui()
        {
            if (stock_items.Count == 0)
            {
                // 물품명을 먼저 입력해야지 수량을 입력할 수 있도록 설정
                textbox_count.Enabled = false; // 수량을 비활성화 한다.

                // 수량 옆에 선택 버튼도 비활성화
                button_select.Enabled = false;

                // 버그 방지를 위해 data grid view 수정을 막는다
                datagridview_stock.ReadOnly = true;

                // data grid view 선택 상태 해제
                datagridview_stock.ClearSelection();

                // 아이템 추가 및 바인딩 진행
                set_item_and_bind();
            }
        }


        // 메인 화면에서 호출하는 함수로, 메인 화면에서
        // "재고 조회" 버튼을 눌렀을 때 이 함수를 호출한다.
        public void set_stock_view_mode()
        {
            /*
              재고 조회 창을 열었을 때는 수정을 모두 막아야 한다.
              말그대로 "조회" 만 가능한 Read Only 상태를 만들기 위해
              폼 구성 요소들을 아래와 같이 설정한다.
            */
            textbox_search.Enabled = false;
            textbox_count.Enabled = false;
            button_search.Enabled = false;
            button_select.Enabled = false;
            button_select_cancle.Enabled = false;
            button_pay_cancle.Enabled = false;
            listview_selected.Enabled = false;
            datagridview_stock.ReadOnly = true;
            datagridview_stock.AllowUserToAddRows = false;
            button_add_into_payment.Enabled = false;

            // 오른쪽 라벨에 읽기 모드라고 출력
            label_mode.Text = "* 현재 읽기 모드입니다.";
            label_tip.Text = "";

            // 왼쪽 라벨에 설명 출력
            label_tip.Text = "현재 재고 조회 모드로 읽기 전용 상태입니다.";
        }

        // 결제폼에서 호출하는 함수로, 구매가 완료된 목록들을 이쪽 인자로 넘겨서 호출하고,
        // 이 폼에선 그 인자로 넘거온 목록들을 리스트뷰에 찾아서 지우는 함수
        public void remove_selected_items(List<StockRecord> selected_items)
        {
            foreach (var item in selected_items)
            {
                for (int i = 0; i < listview_selected.Items.Count; i++)
                {
                    // 모든 항목이 같아야만 삭제한다
                    if (listview_selected.Items[i].SubItems[1].Text == item.ItemName &&
                        listview_selected.Items[i].SubItems[2].Text == item.Count.ToString() &&
                        listview_selected.Items[i].SubItems[3].Text == item.Cost.ToString())
                    {
                        listview_selected.Items.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        // db 에서 데이터를 다시 불러와 바인딩하는 함수
        public void reload_data()
        {
            // stock_items 가 비어있으면 DB에서 로드후 stock_items 에 저장
            var db_master = DBMaster.Instance;
            List<StockRecord> all_stock_list = db_master.get_all_stock_table_data();

            stock_items.Clear();

            // 기존 참조에 데이터를 추가한다
            foreach (var item in all_stock_list)
            {
                stock_items.Add(item);
            }

        }

        /*
          아이템 품목 이름을 입력 받았을때 그에 대한 재고를 뱉는 함수
          db 에서 아이템 이름으로 읽어와서 원본 재고를 구하고,
          그 원본 재고해서 고른 아이템의 재고를 빼서 반환한다.
        */
        public int get_available_stock_count(string item_name, int item_count)
        {
            // db에서 아이템 이름으로 읽어와서 원본 재고를 구한다.
            // sql 쿼리문을 이용해 db에서 아이템 이름으로 읽어온다.
            var db_master = DBMaster.Instance;
            var stock_data = db_master.get_stock_record_by_item_name(item_name);

            // stock_data, item_count를 출력한다
            Console.WriteLine($"stock_data.Count : {stock_data.Count}");
            Console.WriteLine($"item_count : {item_count}");

            // 원본 재고에서 고른 아이템의 재고를 빼서 반환한다.
            return stock_data.Count - item_count;
        }

        // 아이템 추가 및 바인딩 진행
        private void set_item_and_bind()
        {
            // stock_items 가 비어있으면 DB에서 로드후 stock_items 에 저장
            var db_master = DBMaster.Instance;
            List<StockRecord> all_stock_list = db_master.get_all_stock_table_data();

            // stock_items를 새로운 BindingList로 초기화하고 all_stock_list의 항목들을 추가합니다.
            stock_items = new BindingList<StockRecord>(all_stock_list);

            /*
              리스트와 데이터 그리드 뷰 DataSource 를 동기화 시킨다.
              이 코드 실행 이후 앞으로 stock_items 가 바뀌면 바로 바로
              데이터 그리드 뷰에도 반영된다.
            */
            datagridview_stock.DataSource = stock_items;

            Console.WriteLine("바인딩 완료");
        }

        // 창 닫고 다시 들어왔을 때 리스트뷰에 아이템 남아있으면
        // 다시 data grid view에 하이라이팅 해주는 함수
        private void highlight_gridview_item()
        {
            // 리스트뷰에 아이템이 존재하는지 체크
            if (listview_selected.Items.Count <= 0) return;
            foreach (ListViewItem listItem in listview_selected.Items)
            {
                string item_name = listItem.SubItems[1].Text.Trim();

                for (int i = 0; i < datagridview_stock.Rows.Count; i++)
                {
                    var cell_value = datagridview_stock.Rows[i].Cells[1].Value;
                    if (cell_value != null && cell_value.ToString().Trim() == item_name)
                    {
                        for (int j = 0; j < datagridview_stock.Columns.Count; j++)
                            datagridview_stock.Rows[i].Cells[j].Style.BackColor = Color.Crimson;
                    }
                }
            }

            datagridview_stock.ClearSelection();
        }



        // data grid view 의 특정 행(인덱스)을 인자로 받아서, 그 행의 모든 데이터를 반환
        private StockRecord get_grid_view_data_by_index(int index)
        {
            return new StockRecord
            {
                Id = Convert.ToInt32(datagridview_stock.Rows[index].Cells[0].Value),
                ItemName = datagridview_stock.Rows[index].Cells[1].Value.ToString(),
                Cost = Convert.ToInt32(datagridview_stock.Rows[index].Cells[2].Value),
                Count = Convert.ToInt32(datagridview_stock.Rows[index].Cells[3].Value)
            };
        }

        // Stock Record 를 받아서 data grid view 의 특정 행에 Update 하는 함수
        private void update_grid_view_by_index(int index, StockRecord stock_record)
        {
            datagridview_stock.Rows[index].Cells[0].Value = stock_record.Id;
            datagridview_stock.Rows[index].Cells[1].Value = stock_record.ItemName;
            datagridview_stock.Rows[index].Cells[2].Value = stock_record.Cost;
            datagridview_stock.Rows[index].Cells[3].Value = stock_record.Count;
        }

        private bool search_item(SearchBy search_by, string keyword)
        {
            // 모든 행을 반복하며 검색어와 일치하는 행을 찾는다.
            for (int i = 0; i < datagridview_stock.Rows.Count; i++)
            {
                // 먼저 해당 행의 모든 데이터를 얻는다.
                StockRecord row_data = get_grid_view_data_by_index(i);

                // 찾을 때 비교할 값
                string cell_value = "";

                // 아이템 이름과 개수
                string item_name = row_data.ItemName;
                string item_count = row_data.Count.ToString();

                if (search_by == SearchBy.Number)
                    cell_value = row_data.Id.ToString(); // 검색 방식이 숫자인 경우 비교할 셀 값은 아이템 번호 (id)
                else if (search_by == SearchBy.Name)
                    cell_value = row_data.ItemName; // 검색 방식이 이름인 경우 비교할 셀 값은 아이템 이름

                // cell_value 가 비지 않았으면서, cell_value 가 검색어와 일치하는 경우
                if (cell_value != null && cell_value == keyword)
                {
                    // 해당 행을 선택한다.
                    select_item(i, item_name, Convert.ToInt32(item_count));
                    return true;
                }
            }

            // 위 for문이 다 돌았는데 return 되지 않았다면 검색에 실패한 것. false 값을 반환.
            return false;
        }

        // 검색 버튼 클릭
        private void button_search_Click(object sender, EventArgs e)
        {
            string search_text = textbox_search.Text;
            bool item_found = false;

            if (search_text.All(char.IsDigit))
            {
                // No 번호를 기준으로 검색
                item_found = search_item(SearchBy.Number, search_text);
            }
            else
            {
                // 물품명을 기준으로 검색
                item_found = search_item(SearchBy.Name, search_text);
            }

            if (!item_found)
            {
                MessageBox.Show("찾는 물품이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void select_item(int row_index, string item_name, int item_count)
        {
            if (item_count == 0)
            {
                // 재고가 없으면 선택 불가
                MessageBox.Show("재고가 없는 물품입니다. 다른 항목을 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (restart_status == false)
            {
                MessageBox.Show($"{item_name} 항목이 선택되었습니다. 이제 수량을 선택해주세요.", "알림", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            selected = row_index; // 검색한 물품 있는 행 선택하고 선택하기 버튼 클릭 시에 사용

            // 물품명을 찾으면 수량을 입력할 수 있도록 설정
            textbox_count.Enabled = true;

            // 수량 옆에 선택 버튼도 활성화
            button_select.Enabled = true;

            // 물품 선택이 성공적으로 진행된 경우 물품 개수를 입력하거나 
            // 선택 취소하기 버튼을 누르기 전까진 물품 이름을 함부로 변경할 수 없다.
            textbox_search.Enabled = false;

            // data grid view 의 선택 상태를 전부 해제한다.
            for (int i = 0; i < datagridview_stock.Rows.Count; i++)
            {
                datagridview_stock.Rows[i].Selected = false;
            }

            // 선택한 물품의 행을 강조한다.
            datagridview_stock.Rows[row_index].Selected = true;
            datagridview_stock.Rows[row_index].DefaultCellStyle.BackColor = Color.Crimson;

            // 선택이 완료됐으므로 포커스를 수량으로 넘긴다
            textbox_count.Focus();

            // 선택 완료시 restart_status 를 false 로 변경
            restart_status = false;
        }

        // CountText에 판매할 상품 개수 적고 선택하기 버튼 클릭시 선택한 물품의 이름, 가격, 갯수 반환 
        // 물건을 선택해서 오른쪽 리스트뷰에 추가하는 함수
        private void button_select_click(object sender, EventArgs e)
        {
            // 수량이 비었거나, 숫자가 입력되지 않았으면 함수 강제 종료
            if (textbox_count.Text == "" || !(textbox_count.Text.All(char.IsDigit)))
            {
                MessageBox.Show("수량엔 숫자만 입력 가능합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 선택된 행의 데이터 가져오기
            StockRecord selected_item = get_grid_view_data_by_index(selected);

            int id = selected_item.Id; // 아이템 번호 (unique id)
            int item_cost = selected_item.Cost; // 아이템 가격

            int request_item_count = int.Parse(textbox_count.Text); // 요구한 아이템 개수
            string item_name = selected_item.ItemName; // 아이템 이름
            int stock = selected_item.Count; // 존재하는 아이템 재고

            // 선택전에 재고 이상의 물건을 주문하는지 검사
            if (request_item_count > stock)
            {
                MessageBox.Show("재고 이상의 물품을 주문할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 이미 리스트뷰에 같은 아이템이 있는지 확인
            bool is_item_already_exist = false;

            // 이미 있다면 수량과 가격만 업데이트
            foreach (ListViewItem item in listview_selected.Items)
            {
                if (item.SubItems[1].Text == item_name)
                {
                    // 이미 존재하는 아이템의 수량과 총 가격을 업데이트
                    int existing_count = int.Parse(item.SubItems[2].Text);
                    int new_count = existing_count + request_item_count;
                    item.SubItems[2].Text = new_count.ToString();
                    item.SubItems[4].Text = (new_count * item_cost).ToString();
                    is_item_already_exist = true;
                    break;
                }
            }

            // 만약 리스트뷰에 같은 아이템이 없다면 새로운 항목 추가
            if (!is_item_already_exist)
            {
                ListViewItem listview_item = new ListViewItem(id.ToString());
                listview_item.SubItems.Add(item_name);
                listview_item.SubItems.Add(request_item_count.ToString());
                listview_item.SubItems.Add(item_cost.ToString());
                listview_item.SubItems.Add((item_cost * request_item_count).ToString());

                listview_selected.Items.Add(listview_item); // Listview에 추가
            }

            // 선택하기가 완료된 경우 재고 개수를 stock items 에 반영 시킨다
            stock_items[selected].Count -= request_item_count;

            /*
              주의 : 결제 전까진 제고 데이터를 DB에 쓰기 하지 않는다.
              보여주는 UI 에서만 재고를 반영한다.
              결제가 완료되야 DB에 반영한다.
            */

            // 물품명과 수량 입력 텍스트 박스를 초기화 한다.
            textbox_search.Text = "";
            textbox_count.Text = "";

            // 물품명을 다시 입력할 수 있도록 설정
            textbox_search.Enabled = true;

            // 선택이 완료됐으므로 포커스를 물품명으로 넘긴다
            textbox_search.Focus();

            // data grid view 의 선택을 해제한다.
            datagridview_stock.Rows[selected].Selected = false;

            // 선택된 행의 색상을 빨간색으로 변경
            for (int i = 0; i < datagridview_stock.Columns.Count; i++)
            {
                datagridview_stock.Rows[selected].Cells[i].Style.BackColor = Color.Crimson;
            }

            // 수량 텍스트 박스 비활성화
            textbox_count.Enabled = false;

            // 수량 옆에 선택 버튼도 비활성화
            button_select.Enabled = false;
        }

        // 결제창 추가하기
        private void button_add_into_payment_Click(object sender, EventArgs e)
        {
            // 현재 리스트뷰 아이템이 비었는 경우 오류 메세지 출력후 함수 종료
            if (listview_selected.Items.Count <= 0)
            {
                MessageBox.Show("선택된 물품이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 추가 전에 재고 이상의 물건을 주문하는지 일일히 검사
            // listview item 의 구매하려는 개수가 data grid view item의 재고보다 많은지 검사
            foreach (ListViewItem item in listview_selected.Items)
            {
                string item_name = item.SubItems[1].Text;
                int item_count = int.Parse(item.SubItems[2].Text);

                // 재고가 부족한 경우
                if (get_available_stock_count(item_name, item_count) < 0)
                {
                    MessageBox.Show("재고 이상의 물품을 주문할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            select_items.Clear();

            // 현재 리스트뷰 아이템을 선택한 아이템 리스트에 추가한다
            for (int i = 0; i < listview_selected.Items.Count; i++)
            {
                int item_id = int.Parse(listview_selected.Items[i].SubItems[0].Text);
                string item_name = listview_selected.Items[i].SubItems[1].Text;
                int item_cost = int.Parse(listview_selected.Items[i].SubItems[3].Text);
                int item_count = int.Parse(listview_selected.Items[i].SubItems[2].Text);

                // select_items 에 추가한다
                select_items.Add(new StockRecord
                {
                    Id = item_id,
                    ItemName = item_name,
                    Cost = item_cost,
                    Count = item_count
                });
            }

            // 아이템의 내용을 콘솔에 출력한다
            foreach (var element in select_items)
            {
                Console.WriteLine($"{element.ItemName} {element.Cost} {element.Count}");
            }

            is_closed_by_payment = true;

            // select_items 는 PaymentForm에서 이어 받는다.
            // 여기선 단순히 Dialog를 종료한다.
            DialogResult = DialogResult.OK;
            Close();
        }

        // 주문 취소 버튼
        private void button_pay_cancle_Click(object sender, EventArgs e)
        {
            // 리스트뷰 아이템을 순회하면서, 아이템을 삭제하고 재고를 복원한다.
            // 그리고 부모폼인 결제폼에 있는 아이템도 삭제한다.

            foreach (ListViewItem item in listview_selected.Items)
            {
                string item_name = item.SubItems[1].Text;
                int item_count = int.Parse(item.SubItems[2].Text);

                // 해당 아이템의 재고를 stock_items 에 복원
                for (int i = 0; i < datagridview_stock.Rows.Count; i++)
                {
                    if (datagridview_stock.Rows[i].Cells[1].Value.ToString() == item_name)
                    {
                        stock_items[i].Count += item_count;

                        // 선택된 셀의 색상을 흰색으로 복구
                        for (int j = 0; j < datagridview_stock.Columns.Count; j++)
                            datagridview_stock.Rows[i].Cells[j].Style.BackColor = Color.White;

                        break;
                    }
                }

                // 결제 창에서도 삭제를 반영
                payment_form.remove_listview_item_by_name(item_name);
            }

            // 리스트뷰 아이템을 모두 삭제한다.
            listview_selected.Items.Clear();
        }

        // 리스트뷰 아이템 더블 클릭시 요소 삭제
        private void listview_selected_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 선택된 아이템이 없다면 함수 강제 종료
            if (listview_selected.SelectedItems.Count <= 0) return;

            // 선택된 아이템 가져오기
            ListViewItem selected_item = listview_selected.SelectedItems[0];
            string item_name = selected_item.SubItems[1].Text;
            int item_count = int.Parse(selected_item.SubItems[2].Text);

            // 해당 아이템의 재고를 stock_items 에 복원
            for (int i = 0; i < datagridview_stock.Rows.Count; i++)
            {
                if (datagridview_stock.Rows[i].Cells[1].Value.ToString() == item_name)
                {
                    stock_items[i].Count += item_count;
                    break;
                }
            }

            // 선택된 아이템 삭제
            listview_selected.Items.Remove(selected_item);

            // 결제 창에도 삭제를 반영
            payment_form.remove_listview_item_by_name(item_name);

            // data grid view 선택 색상 원래대로 돌리기
            for (int i = 0; i < datagridview_stock.Rows.Count; i++)
            {
                if (datagridview_stock.Rows[i].Cells[1].Value.ToString() == item_name)
                {
                    for (int j = 0; j < datagridview_stock.Columns.Count; j++)
                    {
                        datagridview_stock.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                    break;
                }
            }

        }


        // 물품명 텍스트 박스에서 엔터 입력 => 버튼 클릭
        private void textbox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_search_Click(sender, e);
            }
        }

        // 수량 텍스트 박스에서 엔터 입력 => 버튼 클릭
        private void textbox_count_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_select_click(sender, e);
            }
        }

        // 수량 텍스트 박스에 숫자만 입력 가능하도록 설정
        private void textbox_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자, 백스페이스, 또는 컨트롤 키가 입력된 경우
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // 숫자 이외의 문자는 입력되지 않도록 합니다.
            }
        }

        // 선택 취소하기 버튼
        private void button_select_cancle_Click(object sender, EventArgs e)
        {
            // 현재 아이템이 선택중인지 체크한다.
            if (textbox_count.Enabled == false)
            {
                MessageBox.Show("현재 물품 선택중이 아닙니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 현재 선택된 상태를 원래대로 돌리는 기능을 수행한다.

            // 물품명과 수량 입력 텍스트 박스를 초기화 한다.
            textbox_search.Text = "";
            textbox_count.Text = "";

            // 물품명을 다시 입력할 수 있도록 설정
            textbox_search.Enabled = true;

            // 선택이 완료됐으므로 포커스를 물품명으로 넘긴다
            textbox_search.Focus();

            // data grid view 의 선택을 전부 해제한다.
            datagridview_stock.ClearSelection();

            // data grid view 의 수정을 다시 허용한다.
            datagridview_stock.Enabled = true;

            // data grid view 의 선택 색상을 원래대로 돌린다.
            for (int i = 0; i < datagridview_stock.Rows.Count; i++)
            {
                datagridview_stock.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

        }

        // 현재 listview product 의 모든 아이템 반환
        // ListView의 모든 아이템을 반환하는 함수
        public List<string> get_all_listview_item()
        {
            List<string> items = new List<string>();

            foreach (ListViewItem item in listview_selected.Items)
            {
                items.Add(item.Text);
            }

            return items;
        }
    }
}