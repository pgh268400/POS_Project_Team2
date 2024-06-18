using POS_Project_Team2.Class;
using System.Data;

namespace POS_Project_Team2
{
    public partial class PayMentLogShowForm : Form
    {
        /*
           해당 폼은 결제 내역 및 영수증, 환불 내역을 위해 재활용 된다.
        */

        private ContextMenuStrip contextMenu;
        private ListViewItem selected_item; // 선택된 아이템을 저장할 변수


        public PayMentLogShowForm()
        {
            InitializeComponent();
        }

        // 어떤 목적으로 사용되는지에 따라 상대방이 호출할 업데이트 함수
        public void set_form_role(List<string[]> log_data, string label_text)
        {
            label_show.Text = label_text;

            // 결제 내역을 리스트뷰에 뿌린다.
            foreach (string[] log in log_data)
            {
                ListViewItem item = new ListViewItem(log);

                // 아이템 텍스트가 "null" 인 경우 없음으로 표시
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    if (item.SubItems[i].Text == "null")
                        item.SubItems[i].Text = "없음";
                }

                listView1.Items.Add(item);
            }
        }
        private void PayMentLogShowForm_Load(object sender, EventArgs e)
        {
        }

        // 영수증 출력 활성화시 해당 함수 호출
        public void enable_recepit_mode()
        {
            label_show.Text = "* 영수증 출력을 원하시는 경우 요소를 오른쪽 클릭후 출력을 눌러주세요";

            contextMenu = new ContextMenuStrip();
            var printMenuItem = new ToolStripMenuItem("출력", null, OnPrintMenuItemClick);
            contextMenu.Items.Add(printMenuItem);

            listView1.MouseUp += ListView1_MouseUp;
        }

        // 환불 모드 활성화시 해당 함수 호출
        public void enable_refund_mode()
        {
            // label_show.Text = "* 환불을 원하시는 경우 요소를 오른쪽 클릭후 환불을 눌러주세요";

            contextMenu = new ContextMenuStrip();
            var refundMenuItem = new ToolStripMenuItem("환불", null, OnRefundMenuItemClick);
            contextMenu.Items.Add(refundMenuItem);

            listView1.MouseUp += ListView1_MouseUp;
        }

        private void OnRefundMenuItemClick(object? sender, EventArgs e)
        {
            if (selected_item != null)
            {
                // string item_details = string.Join(", ", selected_item.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subItem => subItem.Text));
                // MessageBox.Show($"출력 버튼이 클릭되었습니다. 선택된 행의 정보: {item_details}");

                // 정말 삭제할건지 묻는다.
                DialogResult result = MessageBox.Show("해당 결제를 환불하시겠습니까? 결제 내역에는 삭제되고 환불 내역에서만 확인 가능합니다.", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // 리스트뷰 아이템을 string[] 에 담는다
                    string[] refund_data = new string[selected_item.SubItems.Count];
                    for (int i = 0; i < selected_item.SubItems.Count; i++)
                    {
                        // 이름 인덱스인 경우 (환불) 이라고 기록하도록 한다.
                        if (i == 1)
                            refund_data[i] = "(환불) " + selected_item.SubItems[i].Text;
                        else
                            refund_data[i] = selected_item.SubItems[i].Text;
                    }

                    // 환불 기록을 로그에 저장
                    Logger logger = new Logger();
                    logger.append_refund_log(refund_data);

                    int selected_item_index = listView1.Items.IndexOf(selected_item);

                    // 결제 기록 로그에도 삭제 반영
                    logger.remove_payment_log(selected_item_index);

                    // 리스트뷰에서 삭제
                    listView1.Items.Remove(selected_item);


                    // 환불 했으니 재고를 원래대로 돌려야 한다
                    // 재고를 불러온다
                    DataSet itemDataSet = new DataSet();
                    using (StreamReader reader = new StreamReader("item_data.xml"))
                    {
                        itemDataSet.ReadXml(reader);
                    }

                    DataTable itemList = itemDataSet.Tables["ItemList"];

                    // 환불한 제품을 찾아서 재고를 늘려준다
                    foreach (DataRow row in itemList.Rows)
                    {
                        if (row["Name"].ToString() == refund_data[1])
                        {
                            row["Stock"] = int.Parse(row["Stock"].ToString()) + int.Parse(refund_data[3]);
                            break;
                        }
                    }

                    // 변경된 데이터를 다시 저장
                    using (StreamWriter writer = new StreamWriter("item_data.xml"))
                    {
                        itemDataSet.WriteXml(writer);
                    }

                    MessageBox.Show("환불 처리가 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ListView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit_test_info = listView1.HitTest(e.Location);
                if (hit_test_info.Item != null)
                {
                    selected_item = hit_test_info.Item; // 선택된 아이템을 변수에 저장
                    contextMenu.Show(listView1, e.Location);
                }
            }
        }

        private void OnPrintMenuItemClick(object sender, EventArgs e)
        {
            if (selected_item != null)
            {
                string itemDetails = string.Join(", ", selected_item.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subItem => subItem.Text));
                MessageBox.Show($"출력 버튼이 클릭되었습니다. 선택된 행의 정보: {itemDetails}");

                // 출력을 위해 영수증 출력창을 연다.
                ReceiptForm receipt_form = new ReceiptForm();
                // receipt_form.set_receipt(selectedItem.SubItems[0].Text, selectedItem.SubItems[1].Text, selectedItem.SubItems[2].Text, selectedItem.SubItems[3].Text, selectedItem.SubItems[4].Text);
            }
        }


    }
}
