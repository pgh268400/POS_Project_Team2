using System.Data;

namespace POS_Project_Team2
{
    public partial class DataForm : Form
    {
        public ItemData dataset;
        DataTable originalData;

        // PayMentForm 과 공유할 결제 내역을 담는 리스트
        public List<(string item_name, int item_cost, int item_count)> items = new();

        int selected;
        int listview_item_count = 1;    //listview_item의 No 컨트롤

        // 결제창이 아닌 일반 메인창에서 보기 위해 접근했을때 모든 컨트롤을
        // 비활성화 시키는 메서드
        public void block_all()
        {
            textbox_search.Enabled = false;
            textbox_count.Enabled = false;
            button_search.Enabled = false;
            button_select.Enabled = false;
            button_select_cancle.Enabled = false;
            button_pay_cancle.Enabled = false;
            listview_item.Enabled = false;
            datagridview_stock.Enabled = false;
            button_add_into_payment.Enabled = false;

            // 라벨에 읽기 모드라고 출력
            label_mode.Text = "* 현재 읽기 모드입니다.";
            label_tip.Text = "";
        }
        // 아이템 추가 및 바인딩 진행
        private void set_item_and_bind()
        {
            // 강의에서 배운 dataset 을 활용해서 데이터를 저장후, 이를 datagridview에 바인딩하는 방법을 사용
            dataset = new ItemData();

            //업데이트 된 재고 데이터 불러오기 위해서 Load
            LoadDataTable(dataset.Tables["ItemList"], "item_data.xml");

            //데이터 없으면 기본 데이터 추가
            if (dataset.Tables["ItemList"].Rows.Count == 0)
            {
                dataset.Tables["ItemList"].Rows.Add(new object[] { 1, "싸인펜", 1000, 10 });
                dataset.Tables["ItemList"].Rows.Add(new object[] { 2, "붓", 2000, 20 });
                dataset.Tables["ItemList"].Rows.Add(new object[] { 3, "지우개", 800, 30 });
                dataset.Tables["ItemList"].Rows.Add(new object[] { 4, "제도샤프", 1500, 40 });
            }

            // 원본 데이터 복사
            originalData = dataset.Tables["ItemList"].Copy();

            datagridview_stock.DataSource = dataset.Tables["ItemList"];
        }
        public DataForm()
        {
            InitializeComponent();

            // 아이템 추가 및 바인딩 진행
            set_item_and_bind();

            // 애플리케이션 종료 시 파일 제거 이벤트 등록 비활성화 해둠. >> 그러면 프로그램 꺼도 저장됨
            //Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            // 물품명을 먼저 입력해야지 수량을 입력할 수 있도록 설정
            textbox_count.Enabled = false; // 수량을 비활성화 한다.
        }

        // 검색 버튼 클릭시 해당 물품 있는지 검사 후 해당 행을 선택.
        private void button_search_Click(object sender, EventArgs e)
        {
            string search_text = textbox_search.Text;
            bool item_found = false;

            for (int i = 0; i < datagridview_stock.Rows.Count; i++)
            {
                var cell_value = datagridview_stock.Rows[i].Cells[1].Value;

                // null 체크 후 검색한 물품 있는 행 선택
                if (cell_value != null && cell_value.ToString() == search_text)
                {
                    MessageBox.Show($"{cell_value} 항목이 선택되었습니다. 이제 수량을 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    selected = i;   // 검색한 물품 있는 행 선택하고 선택하기 버튼 클릭 시에 사용
                    item_found = true;

                    // 물품명을 찾으면 수량을 입력할 수 있도록 설정
                    textbox_count.Enabled = true;

                    // 물품 선택이 성공적으로 진행된 경우 물품 개수를 입력하거나 
                    // 선택 취소하기 버튼을 누르기 전까진 물품 이름을 함부로 변경할 수 없다.
                    textbox_search.Enabled = false;

                    // data gridview 역시 수정을 못하게 막는다.
                    datagridview_stock.Enabled = false;

                    // 선택한 물품의 행을 강조한다.
                    datagridview_stock.Rows[i].Selected = true;
                    datagridview_stock.Rows[i].DefaultCellStyle.BackColor = Color.Crimson;

                    // 선택이 완료됐으므로 포커스를 수량으로 넘긴다
                    textbox_count.Focus();


                    break;
                }
            }

            if (!item_found)
            {
                MessageBox.Show("찾는 물품이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // CountText에 판매할 상품 개수 적고 선택하기 버튼 클릭시 선택한 물품의 이름, 가격, 갯수 반환 
        private void button_select_click(object sender, EventArgs e)
        {
            int item_cost = Convert.ToInt32(datagridview_stock.Rows[selected].Cells[2].Value.ToString()); // 값을 정수로 받기 위해서 변환
            int item_count = int.Parse(textbox_count.Text);
            string item_name = datagridview_stock.Rows[selected].Cells[1].Value.ToString();

            // 선택전에 재고 이상의 물건을 주문하는지 검사
            int stock = Convert.ToInt32(datagridview_stock.Rows[selected].Cells[3].Value.ToString());
            if (item_count > stock)
            {
                MessageBox.Show("재고 이상의 물품을 주문할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 이 items 를 현재 리스트뷰에 추가
            ListViewItem lvi = new ListViewItem((listview_item_count).ToString());
            lvi.SubItems.Add(item_name);
            lvi.SubItems.Add(item_count.ToString());
            lvi.SubItems.Add(item_cost.ToString());
            lvi.SubItems.Add((item_cost * item_count).ToString());

            listview_item.Items.Add(lvi); // Listview에 추가

            listview_item_count++;

            // 선택하기가 완료된 경우 재고 개수를 data grid view에 반영시킨다.
            datagridview_stock.Rows[selected].Cells[3].Value = stock - item_count;

            // 변경된 제고 데이터 xml에 저장
            SaveDataTable(dataset.Tables["ItemList"], "item_data.xml");

            // 물품명과 수량 입력 텍스트 박스를 초기화 한다.
            textbox_search.Text = "";
            textbox_count.Text = "";

            // 물품명을 다시 입력할 수 있도록 설정
            textbox_search.Enabled = true;

            // 선택이 완료됐으므로 포커스를 물품명으로 넘긴다
            textbox_search.Focus();

            // data grid view 의 선택을 해제한다.
            datagridview_stock.Rows[selected].Selected = false;



            // 이 리스트 아이템을 현재 리스트뷰에 추가
            // DialogResult = DialogResult.OK;
            // Close();
        }



        // 결제창 추가하기
        private void button1_Click(object sender, EventArgs e)
        {
            items.Clear();
            // 현재 리스트뷰 아이템을 items 에 저장한다.
            for (int i = 0; i < listview_item.Items.Count; i++)
            {
                string item_name = listview_item.Items[i].SubItems[1].Text;
                int item_cost = int.Parse(listview_item.Items[i].SubItems[3].Text);
                int item_count = int.Parse(listview_item.Items[i].SubItems[2].Text);

                items.Add((item_name, item_cost, item_count));
            }
            // items 는 Payment Form에서 이어 받는다.
            // 여기선 단순히 Dialog를 종료한다.
            DialogResult = DialogResult.OK;
            Close();

        }

        private void button_pay_cancle_Click(object sender, EventArgs e)
        {
            listview_item.Clear();
            RestoreOriginalData();
        }

        private void listview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listview_item.SelectedItems.Count > 0)
            {
                // 선택된 아이템 가져오기
                ListViewItem selectedItem = listview_item.SelectedItems[0];
                string item_name = selectedItem.SubItems[1].Text;
                int item_count = int.Parse(selectedItem.SubItems[2].Text);

                // 해당 아이템의 재고를 복원
                for (int i = 0; i < datagridview_stock.Rows.Count; i++)
                {
                    var cell_value = datagridview_stock.Rows[i].Cells[1].Value;

                    if (cell_value != null && cell_value.ToString() == item_name)
                    {
                        int stock = Convert.ToInt32(datagridview_stock.Rows[i].Cells[3].Value.ToString());
                        datagridview_stock.Rows[i].Cells[3].Value = stock + item_count;
                        break;
                    }
                }

                // 선택된 아이템 삭제
                listview_item.Items.Remove(selectedItem);

                // 변경된 재고 데이터 xml에 저장
                SaveDataTable(dataset.Tables["ItemList"], "item_data.xml");

                // data grid view 선택 색상 원래대로 돌리기
                for (int i = 0; i < datagridview_stock.Rows.Count; i++)
                {
                    datagridview_stock.Rows[i].DefaultCellStyle.BackColor = Color.White;
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
        //변경된 table xml파일로 저장
        public void SaveDataTable(DataTable table, string filePath)
        {
            table.WriteXml(filePath);
        }

        //저장된 table xml파일로 로드
        public void LoadDataTable(DataTable table, string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                table.ReadXml(filePath);
            }
        }

        // 원본 데이터를 복원하는 메서드
        public void RestoreOriginalData()
        {
            dataset.Tables["ItemList"].Clear(); //변경된 데이터 지우고
            foreach (DataRow row in originalData.Rows)
            {
                dataset.Tables["ItemList"].ImportRow(row);      //이전에 카피해둔 원본 데이터 ItemList에 삽입
            }
            SaveDataTable(dataset.Tables["ItemList"], "item_data.xml");
        }

        //애플리케이션 종료 시 실행
        private void OnApplicationExit(object sender, EventArgs e)
        {
            RemoveDataFile("item_data.xml");    //어플리케이션 종료 시 item_data 변화제어하는 xml 제거 
        }

        // XML 파일을 제거하는 메서드
        private void RemoveDataFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

    }
}
