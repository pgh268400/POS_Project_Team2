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
    public partial class PointForm : Form
    {
        // 이름과 전화번호 뒷자리를 public 으로 기록.
        // ShowDialog 를 호출하는 쪽에서 이 값을 가져가서 사용할 수 있도록 한다.
        public string name;
        public string phone_number;

        public PointForm()
        {
            InitializeComponent();
        }

        private void button_point_cancle_Click(object sender, EventArgs e)
        {
            // 취소시 Dialog Result는 False
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void button_point_ok_Click(object sender, EventArgs e)
        {
            // 포인트 적립 확인시 제대로 입력했는지 확인

            // 이름이 비지 않았는지 우선 검증
            if (textbox_name.Text == "")
            {
                MessageBox.Show("이름을 입력해주세요.");
                return;
            }

            // 전화번호 4자리 입력했는지 확인
            if (textbox_phone_4.Text.Length != 4)
            {
                MessageBox.Show("전화번호 뒷 4자리를 입력해주세요. 4자리가 아닙니다.");
                return;
            }

            // 멤버 변수에 값 기록
            name = textbox_name.Text;
            phone_number = textbox_phone_4.Text;

            // 포인트 적립 확인시 Dialog Result는 OK
            this.DialogResult = DialogResult.OK;
        }

        private void textbox_phone_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자, 백스페이스, 또는 컨트롤 키가 입력된 경우
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // 숫자 이외의 문자는 입력되지 않도록 합니다.
            }
        }
    }
}
