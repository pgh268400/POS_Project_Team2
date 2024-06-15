using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Project_Team2
{
    public partial class DataForm : Form
    {
        ItemData dataset;
        public List<(string ItemName, int ItemCost, int ItemCount)> items = new List<(string ItemName, int ItemCost, int ItemCount)>();

        int Selected;
        
        public DataForm()
        {
            InitializeComponent();

            dataset = new ItemData();

            dataset.Tables["ItemList"].Rows.Add(new object[] { 1, "Pen", 1000, 10 });
            dataset.Tables["ItemList"].Rows.Add(new object[] { 2, "Brush", 2000, 20 });
            dataset.Tables["ItemList"].Rows.Add(new object[] { 3, "Erase", 400, 30 });
            dataset.Tables["ItemList"].Rows.Add(new object[] { 4, "Pen2", 1500, 40 });

            dataGridView1.DataSource = dataset.Tables["ItemList"];

        }

        private void DataForm_Load(object sender, EventArgs e)
        {

        }
        
        //검색 버튼 클릭시 해당 물품 있는지 검사 후 해당 행을 선택.
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string Search = SearchText.Text;
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == Search)
                {
                    MessageBox.Show("선택");

                    Selected = i;   //검색한 물품 있는 행 선택하고 선택하기 버튼 클릭 시에 사용
                    break;
                }

            }
        }

        //CountText에 판매할 상품 개수 적고 선택하기 버튼 클릭시 선택한 물품의 이름, 가격, 갯수 반환 
        private void SelectBtn_Click(object sender, EventArgs e)
        {
            
            int ItemCost = Convert.ToInt32(dataGridView1.Rows[Selected].Cells[2].Value.ToString()); //값을 정수로 받기 위해서 변환
            int ItemCount = int.Parse(CountText.Text);  

            items.Add((dataGridView1.Rows[Selected].Cells[1].Value.ToString(), ItemCost, ItemCount));   //이름 가격 갯수 가지는 List items에 추가
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
