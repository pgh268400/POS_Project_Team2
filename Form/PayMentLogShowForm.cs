using POS_Project_Team2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Project_Team2
{
    public partial class PayMentLogShowForm : Form
    {
        public PayMentLogShowForm()
        {
            InitializeComponent();
        }

        private void update_list_view()
        {
            // Logger 객체를 생성한다.
            Logger logger = new Logger();

            // 결제 내역을 읽어온다.
            List<string[]> payment_log = logger.get_payment_log();

            // 결제 내역을 리스트뷰에 뿌린다.
            foreach (string[] log in payment_log)
            {
                ListViewItem item = new ListViewItem(log);
                listView1.Items.Add(item);
            }
        }
        private void PayMentLogShowForm_Load(object sender, EventArgs e)
        {
            update_list_view();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            // 리스트뷰를 초기화 한다.
            listView1.Items.Clear();

            // 리스트뷰를 업데이트 한다.
            update_list_view();

        }
    }
}
