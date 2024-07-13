using POS_Project_Team2.Class;
using System.Drawing.Printing;

namespace POS_Project_Team2
{
    public partial class ReceiptForm : Form
    {
        private PrintDocument print_document;

        private string total_price;
        private string earner;

        public ReceiptForm()
        {
            InitializeComponent();

            FormHelper.disable_resize(this);
        }

        // 상대방이 호출할 영수증 출력 정보

        // 구매한 회원 정보, 구매한 물품, 구매한 물품 개수, 결제한 총 금액을 인자로 받는다.
        public void set_receipt_data(string total_price, string earner, DateTime payday)
        {
            this.total_price = total_price;
            this.earner = earner;

            // 금액 , 부가세 설정
            // 금액은 90%, 부가세는 10% 로 설정
            int total_price_int = int.Parse(total_price);
            int vat = (int)(total_price_int * 0.1);
            int amount = total_price_int - vat;

            label_amount_value.Text = amount.ToString() + "원";
            label_vat_value.Text = vat.ToString() + "원";
            label_total_value.Text = total_price + "원";

            // 전표 번호 6자리 랜덤 생성
            Random random = new Random();
            label_receipt_number.Text = "전표번호 : " + random.Next(100000, 999999).ToString();

            // 포인트 적립자 설정
            label_earner.Text = "포인트 적립자 : " + earner;

            // 사업자 번호 랜덤 생성
            label_business_number.Text = "사업자 번호 : " + random.Next(100, 999) + "-" + random.Next(10, 99) + "-" + random.Next(10000, 99999);

            // TEL 번호 랜덤 생성
            label_tel.Text = "TEL : 02-" + random.Next(100, 999) + "-" + random.Next(1000, 9999);

            // 알파벳 3글자 랜덤 생성
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alphabet3 = "";
            for (int i = 0; i < 3; i++)
            {
                alphabet3 += alphabet[random.Next(0, alphabet.Length)];
            }

            label_card_company.Text = alphabet3 + "비씨카드";

            // 거래일시 설정
            label_payday.Text = "거래일시 : " + payday;

            // 승인 번호 8자리 랜덤 생성
            label_approval_number_value.Text = random.Next(10000000, 99999999).ToString();

            // 카드 번호 생성
            label_card_number.Text =
                "카드번호 : " + random.Next(1000, 9999) + "-" + random.Next(10, 99) + "**" + "-****-****(C)";

        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            print_document = new PrintDocument();
            print_document.PrintPage += PrintDocument_PrintPage;
            print_document.EndPrint += PrintDocument_EndPrint; // EndPrint 이벤트 핸들러 추가

        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // 여기서 인쇄할 내용을 정의합니다. 예를 들어, Label 텍스트를 출력합니다.
            float ypos = 100;
            float left_margin = e.MarginBounds.Left;
            float top_margin = e.MarginBounds.Top;

            // 각 라벨의 텍스트를 출력합니다.
            e.Graphics.DrawString(label_ic_approval.Text, label_ic_approval.Font, Brushes.Black, left_margin, ypos);
            ypos += label_ic_approval.Height;

            e.Graphics.DrawString(label_for_customer_use.Text, label_for_customer_use.Font, Brushes.Black, left_margin, ypos);
            ypos += label_for_customer_use.Height;

            e.Graphics.DrawString(label_terminal.Text, label_terminal.Font, Brushes.Black, left_margin, ypos);
            ypos += label_terminal.Height;

            e.Graphics.DrawString(label_store_name.Text, label_store_name.Font, Brushes.Black, left_margin, ypos);
            ypos += label_store_name.Height;

            e.Graphics.DrawString(label_earner.Text, label_earner.Font, Brushes.Black, left_margin, ypos);
            ypos += label_earner.Height;

            e.Graphics.DrawString(label_business_number.Text, label_business_number.Font, Brushes.Black, left_margin, ypos);
            ypos += label_business_number.Height;

            e.Graphics.DrawString(label_receipt_number.Text, label_receipt_number.Font, Brushes.Black, left_margin, ypos);
            ypos += label_receipt_number.Height;

            e.Graphics.DrawString(label_tel.Text, label_tel.Font, Brushes.Black, left_margin, ypos);
            ypos += label_tel.Height;

            e.Graphics.DrawString(label_separator1.Text, label_separator1.Font, Brushes.Black, left_margin, ypos);
            ypos += label_separator1.Height;

            e.Graphics.DrawString(label_amount.Text, label_amount.Font, Brushes.Black, left_margin, ypos);
            ypos += label_amount.Height;

            e.Graphics.DrawString(label_amount_value.Text, label_amount_value.Font, Brushes.Black, left_margin + 200, ypos);
            ypos += label_amount_value.Height;

            e.Graphics.DrawString(label_vat.Text, label_vat.Font, Brushes.Black, left_margin, ypos);
            ypos += label_vat.Height;

            e.Graphics.DrawString(label_vat_value.Text, label_vat_value.Font, Brushes.Black, left_margin + 200, ypos);
            ypos += label_vat_value.Height;

            e.Graphics.DrawString(label_total.Text, label_total.Font, Brushes.Black, left_margin, ypos);
            ypos += label_total.Height;

            e.Graphics.DrawString(label_total_value.Text, label_total_value.Font, Brushes.Black, left_margin + 200, ypos);
            ypos += label_total_value.Height;

            e.Graphics.DrawString(label_separator2.Text, label_separator2.Font, Brushes.Black, left_margin, ypos);
            ypos += label_separator2.Height;

            e.Graphics.DrawString(label_card_company.Text, label_card_company.Font, Brushes.Black, left_margin, ypos);
            ypos += label_card_company.Height;

            e.Graphics.DrawString(label_card_number.Text, label_card_number.Font, Brushes.Black, left_margin, ypos);
            ypos += label_card_number.Height;

            e.Graphics.DrawString(label_installment.Text, label_installment.Font, Brushes.Black, left_margin + 300, ypos);
            ypos += label_installment.Height;

            e.Graphics.DrawString(label_payday.Text, label_payday.Font, Brushes.Black, left_margin, ypos);
            ypos += label_payday.Height;

            e.Graphics.DrawString(label_approval_number.Text, label_approval_number.Font, Brushes.Black, left_margin, ypos);
            ypos += label_approval_number.Height;

            e.Graphics.DrawString(label_approval_number_value.Text, label_approval_number_value.Font, Brushes.Black, left_margin + 100, ypos);
            ypos += label_approval_number_value.Height;
        }

        private void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            // 프린트 성공 여부를 체크
            if (e.Cancel || e.PrintAction != PrintAction.PrintToPrinter)
            {
                //MessageBox.Show("프린트 실패: 프린팅이 취소되었거나 오류가 발생했습니다.", "프린트 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //print_success = false;
            }
            else
            {
                //MessageBox.Show("프린트 성공", "프린트 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //print_success = true;

                // 정상적으로 출력이 완료된 경우 영수증 데이터를 DB에 저장
                ReceiptRecord receipt_record = new ReceiptRecord
                {
                    TerminalNumber = label_terminal.Text.Split(":")[1].Trim(),
                    SlipNumber = label_receipt_number.Text.Split(":")[1].Trim(),
                    Merchant = label_store_name.Text.Split(":")[1].Trim(),
                    PointHolder = label_earner.Text.Split(":")[1].Trim(),
                    BusinessNumber = label_business_number.Text.Split(":")[1].Trim(),
                    TelNumber = label_tel.Text.Split(":")[1].Trim(),
                    Amount = int.Parse(label_amount_value.Text.Replace("원", "")),
                    Vat = int.Parse(label_vat_value.Text.Replace("원", "")),
                    Total = int.Parse(label_total_value.Text.Replace("원", "")),
                    CardName = label_card_company.Text,
                    CardNumber = label_card_number.Text.Split(":")[1].Trim(),
                    IsInstallment = label_installment.Text == "일시불" ? false : true,
                    PayDay = DateTime.Parse(label_payday.Text.Replace("거래일시 : ", "")),
                    ApprovalNumber = label_approval_number_value.Text
                };

                // DB에 저장
                DBMaster.Instance.insert_receipt_data(receipt_record);
            }
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            PrintDialog print_dialog = new PrintDialog();
            print_dialog.Document = print_document;
            if (print_dialog.ShowDialog() == DialogResult.OK)
            {
                print_document.Print();
            }
        }
    }
}
