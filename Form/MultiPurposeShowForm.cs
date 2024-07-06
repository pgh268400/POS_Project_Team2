using POS_Project_Team2.Class;
using System.Data;

namespace POS_Project_Team2
{
    public partial class MultiPurposeShowForm : Form
    {
        /*
           해당 폼은 결제 내역 및 영수증, 환불 내역 등 다양한 용도로 재사용된다.
        */

        // null 대신 사용할 문자
        string null_string = "없음";


        private ContextMenuStrip context_menu;
        private ListViewItem selected_item; // 선택된 아이템을 저장할 변수


        public MultiPurposeShowForm()
        {
            InitializeComponent();

            FormHelper.disable_resize(this);
        }

        // 어떤 목적으로 사용되는지에 따라 상대방이 호출할 업데이트 함수
        public void set_form_role(List<PayMentRefundRecord> log_data, string label_text)
        {
            label_show.Text = label_text;


            // 결제 내역을 리스트뷰에 뿌린다.
            foreach (var record in log_data)
            {
                // 각 속성을 문자열 배열로 변환 (id 값은 리스트뷰에 보여줄 필요 없어 버린다)
                string[] item_data = {
                    record.Time.ToString(),
                    record.ItemName ?? "",
                    record.UnitPrice.ToString(),
                    record.Count.ToString(),
                    record.TotalPrice.ToString(),
                    record.Payer ?? null_string,
                    record.PhoneNumber?.ToString() ?? null_string
                };

                // 리스트뷰 아이템 생성시 문자열 배열만 받는다.
                ListViewItem item = new ListViewItem(item_data);

                listView1.Items.Add(item);
            }
        }

        public void set_form_role(List<TotalRecord> log_data, string label_text)
        {
            label_show.Text = label_text;

            // 결제 내역을 리스트뷰에 뿌린다.
            foreach (var record in log_data)
            {
                string item_name = record.isRefund == 1 ? record.ItemName + " (환불)" : record.ItemName;

                // 각 속성을 문자열 배열로 변환 (id 값, isRefund 값은 리스트뷰에 보여줄 필요 없어 버린다)
                string[] item_data = {
                    record.Time.ToString(),
                    item_name,
                    record.UnitPrice.ToString(),
                    record.Count.ToString(),
                    record.TotalPrice.ToString(),
                    record.Payer ?? "없음",
                    record.PhoneNumber?.ToString() ?? "없음",
                    record.isRefund.ToString()
                };

                // 리스트뷰 아이템 생성시 문자열 배열만 받는다.
                ListViewItem item = new ListViewItem(item_data);

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

            context_menu = new ContextMenuStrip();
            var printMenuItem = new ToolStripMenuItem("출력", null, OnPrintMenuItemClick);
            context_menu.Items.Add(printMenuItem);

            listView1.MouseUp += ListView1_MouseUp;
        }

        // 환불 모드 활성화시 해당 함수 호출
        public void enable_refund_mode()
        {
            // label_show.Text = "* 환불을 원하시는 경우 요소를 오른쪽 클릭후 환불을 눌러주세요";

            context_menu = new ContextMenuStrip();
            var refundMenuItem = new ToolStripMenuItem("환불", null, OnRefundMenuItemClick);
            context_menu.Items.Add(refundMenuItem);

            listView1.MouseUp += ListView1_MouseUp;
        }

        // 환불 메뉴 클릭시
        private void OnRefundMenuItemClick(object? sender, EventArgs e)
        {
            if (selected_item == null) return;


            // string item_details = string.Join(", ", selected_item.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subItem => subItem.Text));
            // MessageBox.Show($"출력 버튼이 클릭되었습니다. 선택된 행의 정보: {item_details}");

            // 정말 삭제할건지 묻는다.
            DialogResult result = MessageBox.Show("해당 결제를 환불하시겠습니까? 결제 내역에는 삭제되고 환불 내역에서만 확인 가능합니다.", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            var db_master = DBMaster.Instance;

            DateTime time_stamp = DateTime.Now; // 환불시 TimeStamp 가 업데이트 되어야 한다.
            string item_name = selected_item.SubItems[1].Text;
            string unit_price = selected_item.SubItems[2].Text;
            string count = selected_item.SubItems[3].Text;
            string total_price = selected_item.SubItems[4].Text;
            string? payer = selected_item.SubItems[5].Text;
            string? phone_number = selected_item.SubItems[6].Text;

            // 위 변수 콘솔에 출력
            Console.WriteLine($"환불 시간: {time_stamp}");
            Console.WriteLine($"아이템 이름: {item_name}");
            Console.WriteLine($"단가: {unit_price}");
            Console.WriteLine($"수량: {count}");
            Console.WriteLine($"총 가격: {total_price}");
            Console.WriteLine($"결제자: {payer}");
            Console.WriteLine($"전화번호: {phone_number}");

            // 선택된 아이템의 정보를 PayMentRefundRecord 객체로 담는다
            var refund_record = new PayMentRefundRecord
            {
                Time = time_stamp,
                ItemName = item_name,
                UnitPrice = int.Parse(unit_price),
                Count = int.Parse(count),
                TotalPrice = int.Parse(total_price),
                Payer = payer,
                PhoneNumber = phone_number == null_string ? null : phone_number
            };

            // 환불 기록을 DB에 저장
            db_master.insert_refund_data(refund_record);

            // 삭제한 아이템의 인덱스 번호
            int selected_item_index = listView1.Items.IndexOf(selected_item);

            // 결제 db에 환불한 아이템 삭제를 반영
            db_master.delete_payment_row(selected_item_index);

            // 리스트뷰에서도 삭제
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
                // MessageBox.Show(refund_data[1].Replace("(환불) ", ""));
                if (row["Name"].ToString() == item_name)
                {
                    row["Stock"] = int.Parse(row["Stock"].ToString()) + int.Parse(count);
                    break;
                }
            }

            // 변경된 데이터를 다시 저장
            using (StreamWriter writer = new StreamWriter("item_data.xml"))
                itemDataSet.WriteXml(writer);

            MessageBox.Show("환불 처리가 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ListView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit_test_info = listView1.HitTest(e.Location);
                if (hit_test_info.Item != null)
                {
                    selected_item = hit_test_info.Item; // 선택된 아이템을 변수에 저장
                    context_menu.Show(listView1, e.Location);
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
