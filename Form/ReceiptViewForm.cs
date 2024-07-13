using POS_Project_Team2.Class;

namespace POS_Project_Team2
{
    public partial class ReceiptViewForm : Form
    {
        public ReceiptViewForm(List<ReceiptRecord> record_items = null)
        {
            InitializeComponent();

            // 생성자에서 리스트뷰 아이템을 받아서 리스트뷰에 추가
            if (record_items != null)
            {
                foreach (var record in record_items)
                {
                    ListViewItem item = new ListViewItem(record.Id.ToString());
                    item.SubItems.Add(record.TerminalNumber);
                    item.SubItems.Add(record.SlipNumber);
                    item.SubItems.Add(record.Merchant);
                    item.SubItems.Add(record.PointHolder);
                    item.SubItems.Add(record.BusinessNumber);
                    item.SubItems.Add(record.TelNumber);
                    item.SubItems.Add(record.Amount.ToString());
                    item.SubItems.Add(record.Vat.ToString());
                    item.SubItems.Add(record.Total.ToString());
                    item.SubItems.Add(record.CardName);
                    item.SubItems.Add(record.CardNumber);
                    item.SubItems.Add(record.IsInstallment.ToString());
                    item.SubItems.Add(record.PayDay.ToString());
                    item.SubItems.Add(record.ApprovalNumber);
                    listView1.Items.Add(item);
                }
            }
        }
    }
}
