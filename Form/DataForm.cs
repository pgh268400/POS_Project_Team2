namespace POS_Project_Team2
{
    public partial class DataForm : Form
    {
        ItemData dataset;

        public List<(string item_name, int item_cost, int item_count)> items = new List<(string item_name, int item_cost, int item_count)>();

        int selected;

        public DataForm()
        {
            InitializeComponent();

            dataset = new ItemData();

            dataset.Tables["ItemList"].Rows.Add(new object[] { 1, "Pen", 1000, 10 });
            dataset.Tables["ItemList"].Rows.Add(new object[] { 2, "Brush", 2000, 20 });
            dataset.Tables["ItemList"].Rows.Add(new object[] { 3, "Erase", 400, 30 });
            dataset.Tables["ItemList"].Rows.Add(new object[] { 4, "Pen2", 1500, 40 });

            datagridview.DataSource = dataset.Tables["ItemList"];

        }

        private void DataForm_Load(object sender, EventArgs e)
        {

        }

        // 검색 버튼 클릭시 해당 물품 있는지 검사 후 해당 행을 선택.
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string search_text = textbox_search.Text;

            for (int i = 0; i < datagridview.Rows.Count; i++)
            {
                if (datagridview.Rows[i].Cells[1].Value.ToString() == search_text)
                {
                    MessageBox.Show("선택");

                    selected = i;   //검색한 물품 있는 행 선택하고 선택하기 버튼 클릭 시에 사용
                    break;
                }

            }
        }

        // CountText에 판매할 상품 개수 적고 선택하기 버튼 클릭시 선택한 물품의 이름, 가격, 갯수 반환 
        private void SelectBtn_Click(object sender, EventArgs e)
        {
            int item_cost = Convert.ToInt32(datagridview.Rows[selected].Cells[2].Value.ToString()); //값을 정수로 받기 위해서 변환
            int item_count = int.Parse(textbox_count.Text);

            items.Add((datagridview.Rows[selected].Cells[1].Value.ToString(), item_cost, item_count));   //이름 가격 갯수 가지는 List items에 추가
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
