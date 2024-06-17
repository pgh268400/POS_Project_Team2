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
        private ContextMenuStrip contextMenu;

        private ListViewItem selectedItem; // 선택된 아이템을 저장할 변수


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

            // 영수증 출력 모드의 경우 기본이 OFF
            // label_recepit.Visible = false;
        }

        // 영수증 출력 활성화시 해당 함수 호출
        public void enable_recepit_mode()
        {
            // label_recepit.Visible = true;
            label_recepit.Text = "* 영수증 출력을 원하시는 경우 요소를 오른쪽 클릭후 출력을 눌러주세요";

            contextMenu = new ContextMenuStrip();
            var printMenuItem = new ToolStripMenuItem("출력", null, OnPrintMenuItemClick);
            contextMenu.Items.Add(printMenuItem);

            listView1.MouseUp += ListView1_MouseUp;
        }

        private void ListView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = listView1.HitTest(e.Location);
                if (hitTestInfo.Item != null)
                {
                    selectedItem = hitTestInfo.Item; // 선택된 아이템을 변수에 저장
                    contextMenu.Show(listView1, e.Location);
                }
            }
        }

        private void OnPrintMenuItemClick(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                string itemDetails = string.Join(", ", selectedItem.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subItem => subItem.Text));
                MessageBox.Show($"출력 버튼이 클릭되었습니다. 선택된 행의 정보: {itemDetails}");

                // 출력을 위해 영수증 출력창을 연다.
                ReceiptForm receipt_form = new ReceiptForm();
                // receipt_form.set_receipt(selectedItem.SubItems[0].Text, selectedItem.SubItems[1].Text, selectedItem.SubItems[2].Text, selectedItem.SubItems[3].Text, selectedItem.SubItems[4].Text);
            }
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
