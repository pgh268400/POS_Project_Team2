using POS_Project_Team2.Class;
using System.ComponentModel;
using System.Data;

namespace POS_Project_Team2
{
    public partial class StockForm : Form
    {
        public ItemData dataset;
        DataTable original_data;

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
        private static BindingList<StockRecord> stock_items = new();

        // 결제창과 공유할 선택한 결제 품목을 담는 리스트
        public List<(string item_name, int item_cost, int item_count)> select_items = new();

        int selected;
        int listview_item_count = 1;    //listview_item의 No 컨트롤

        // 결제창이 아닌 일반 메인창에서 보기 위해 접근했을때 모든 컨트롤을 비활성화 시키는 메서드
        public void block_all()
        {
            textbox_search.Enabled = false;
            textbox_count.Enabled = false;
            button_search.Enabled = false;
            button_select.Enabled = false;
            button_select_cancle.Enabled = false;
            button_pay_cancle.Enabled = false;
            listview_selected.Enabled = false;
            //datagridview_stock.Enabled = false;
            datagridview_stock.ReadOnly = true;
            button_add_into_payment.Enabled = false;

            // 라벨에 읽기 모드라고 출력
            label_mode.Text = "* 현재 읽기 모드입니다.";
            label_tip.Text = "";
        }
        // 아이템 추가 및 바인딩 진행
        private void set_item_and_bind()
        {
            // stock_items 가 비어있다면 DB에서 로드
            // 바인딩은 이미 이루어져 있어, stock_items 에 수정만 하면 된다.
            if (stock_items.Count == 0)
            {
                // stock_items 가 비어있으면 DB에서 로드후 stock_items 에 저장
                var db_master = DBMaster.Instance;
                List<StockRecord> all_stock_list = db_master.get_all_stock_table();

                // stock_items를 새로운 BindingList로 초기화하고 all_stock_list의 항목들을 추가합니다.
                stock_items = new BindingList<StockRecord>(all_stock_list);

                /*
                  리스트와 데이터 그리드 뷰 DataSource 를 동기화 시킨다.
                  이 코드 실행 이후 앞으로 stock_items 가 바뀌면 바로 바로
                  데이터 그리드 뷰에도 반영된다.
                */
                datagridview_stock.DataSource = stock_items;
            }
        }


        public StockForm()
        {
            InitializeComponent();

            // 아이템 추가 및 바인딩 진행
            set_item_and_bind();

            // 실행시 창을 화면 중앙에 위치시키기
            this.StartPosition = FormStartPosition.CenterScreen;

            FormHelper.disable_resize(this);
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            // 물품명을 먼저 입력해야지 수량을 입력할 수 있도록 설정
            textbox_count.Enabled = false; // 수량을 비활성화 한다.

            // 버그 방지를 위해 data grid view 수정을 막는다
            datagridview_stock.ReadOnly = true;
        }

        // 검색 버튼 클릭시 해당 물품 있는지 검사 후 해당 행을 선택.
        private void button_search_Click(object sender, EventArgs e)
        {
            string search_text = textbox_search.Text;
            bool item_found = false;

            // search_text 가 숫자로만 이루어졌는지 확인
            if (search_text.All(char.IsDigit))
            {
                // No 번호를 기준으로 검색
                for (int i = 0; i < datagridview_stock.Rows.Count; i++)
                {
                    var cell_value = datagridview_stock.Rows[i].Cells[0].Value; // No 컬럼은 인덱스 0

                    // null 체크 후 검색한 No 번호가 있는 행 선택
                    if (cell_value != null && cell_value.ToString() == search_text)
                    {
                        var item_name = datagridview_stock.Rows[i].Cells[1].Value.ToString(); // 물품명은 인덱스 1
                        select_item(i, item_name);
                        item_found = true;
                        break;
                    }
                }
            }
            else
            {
                // 물품명을 기준으로 검색
                for (int i = 0; i < datagridview_stock.Rows.Count; i++)
                {
                    var cell_value = datagridview_stock.Rows[i].Cells[1].Value; // 물품명 컬럼은 인덱스 1

                    // null 체크 후 검색한 물품명이 있는 행 선택
                    if (cell_value != null && cell_value.ToString() == search_text)
                    {
                        select_item(i, cell_value.ToString());
                        item_found = true;
                        break;
                    }
                }
            }

            if (!item_found)
            {
                MessageBox.Show("찾는 물품이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void select_item(int row_index, string item_name)
        {
            MessageBox.Show($"{item_name} 항목이 선택되었습니다. 이제 수량을 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

            selected = row_index;   // 검색한 물품 있는 행 선택하고 선택하기 버튼 클릭 시에 사용

            // 물품명을 찾으면 수량을 입력할 수 있도록 설정
            textbox_count.Enabled = true;

            // 물품 선택이 성공적으로 진행된 경우 물품 개수를 입력하거나 
            // 선택 취소하기 버튼을 누르기 전까진 물품 이름을 함부로 변경할 수 없다.
            textbox_search.Enabled = false;

            // data gridview 역시 수정을 못하게 막는다.
            datagridview_stock.Enabled = false;

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
        }

        // CountText에 판매할 상품 개수 적고 선택하기 버튼 클릭시 선택한 물품의 이름, 가격, 갯수 반환 
        // 물건을 선택해서 오른쪽 리스트뷰에 추가하는 함수
        private void button_select_click(object sender, EventArgs e)
        {
            string str_item_cost = datagridview_stock.Rows[selected].Cells[2].Value.ToString(); // 문자열로 나타난 가격
            int item_cost = Convert.ToInt32(str_item_cost); // 아이템 가격을 정수로 변환
            int item_count = int.Parse(textbox_count.Text); // 아이템 개수를 정수로 변환
            string item_name = datagridview_stock.Rows[selected].Cells[1].Value.ToString(); // 아이템 이름

            string str_stock = datagridview_stock.Rows[selected].Cells[3].Value.ToString(); // 문자열로 나타난 재고

            // 선택전에 재고 이상의 물건을 주문하는지 검사
            int stock = Convert.ToInt32(str_stock);
            if (item_count > stock)
            {
                MessageBox.Show("재고 이상의 물품을 주문할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 이 items 를 현재 리스트뷰에 추가
            ListViewItem listview_item = new ListViewItem((listview_item_count).ToString());
            listview_item.SubItems.Add(item_name);
            listview_item.SubItems.Add(item_count.ToString());
            listview_item.SubItems.Add(item_cost.ToString());
            listview_item.SubItems.Add((item_cost * item_count).ToString());

            listview_selected.Items.Add(listview_item); // Listview에 추가

            listview_item_count++;

            // 선택하기가 완료된 경우 재고 개수를 stock items 에 반영 시킨다
            stock_items[selected].Count -= item_count;

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

            // 수량 텍스트 박스 비활성화
            textbox_count.Enabled = false;
        }



        // 결제창 추가하기
        private void button_add_into_payment_Click(object sender, EventArgs e)
        {
            select_items.Clear();
            // 현재 리스트뷰 아이템을 items 에 저장한다.
            for (int i = 0; i < listview_selected.Items.Count; i++)
            {
                string item_name = listview_selected.Items[i].SubItems[1].Text;
                int item_cost = int.Parse(listview_selected.Items[i].SubItems[3].Text);
                int item_count = int.Parse(listview_selected.Items[i].SubItems[2].Text);

                select_items.Add((item_name, item_cost, item_count));
            }

            // 아이템의 내용을 콘솔에 출력한다
            foreach (var item in select_items)
            {
                Console.WriteLine($"{item.item_name} {item.item_cost} {item.item_count}");
            }


            // items 는 Payment Form에서 이어 받는다.
            // 여기선 단순히 Dialog를 종료한다.
            DialogResult = DialogResult.OK;
            Close();

        }

        private void button_pay_cancle_Click(object sender, EventArgs e)
        {
            listview_selected.Clear();
            restore_origin_data();
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


            // data grid view 선택 색상 원래대로 돌리기
            for (int i = 0; i < datagridview_stock.Rows.Count; i++)
                datagridview_stock.Rows[i].DefaultCellStyle.BackColor = Color.White;

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
        // 변경된 table xml파일로 저장
        public void SaveDataTable(DataTable table, string filePath)
        {
            table.WriteXml(filePath);
        }

        //저장된 table xml파일로 로드
        public void LoadDataTable(DataTable table, string file_path)
        {
            if (System.IO.File.Exists(file_path))
            {
                table.ReadXml(file_path);
            }
        }

        // 원본 데이터를 복원하는 메서드
        public void restore_origin_data()
        {
            dataset.Tables["ItemList"].Clear(); //변경된 데이터 지우고
            foreach (DataRow row in original_data.Rows)
            {
                dataset.Tables["ItemList"].ImportRow(row);      //이전에 카피해둔 원본 데이터 ItemList에 삽입
            }
            SaveDataTable(dataset.Tables["ItemList"], "item_data.xml");
        }

        //애플리케이션 종료 시 실행
        private void OnApplicationExit(object sender, EventArgs e)
        {
            remove_data_file("item_data.xml");    //어플리케이션 종료 시 item_data 변화제어하는 xml 제거 
        }

        // XML 파일을 제거하는 메서드
        private void remove_data_file(string filePath)
        {
            if (File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // xml 파일에서 데이터 읽어와 data grid view 에 다시 뿌리기 = 새로고침
            dataset.Tables["ItemList"].Clear();
            LoadDataTable(dataset.Tables["ItemList"], "item_data.xml");
            datagridview_stock.DataSource = dataset.Tables["ItemList"];
        }
    }
}
