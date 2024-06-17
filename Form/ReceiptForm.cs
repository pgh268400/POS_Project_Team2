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
    public partial class ReceiptForm : Form
    {
        public ReceiptForm()
        {
            InitializeComponent();
        }

        // 상대방이 호출할 영수증 출력 정보

        // 구매한 회원 정보, 구매한 물품, 구매한 물품 개수, 결제한 총 금액을 인자로 받는다.
        public void print_receipt(string member_info, string product_info, string product_count, string total_price)
        {
            // 영수증 출력
        /*
            label_member_info.Text = member_info;
            label_product_info.Text = product_info;
            label_product_count.Text = product_count;
            label_total_price.Text = total_price;
        */
        }
    }
}
