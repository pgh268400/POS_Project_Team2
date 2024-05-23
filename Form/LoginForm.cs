namespace POS_Project_Team2
{
    /*
       ����� ���忡�� ���� ó�� ������
       �α��� â (Entry Point)
     */
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            // ����� â�� ȭ�� �߾ӿ� ��ġ��Ű��
            this.StartPosition = FormStartPosition.CenterScreen;

            // �����̳� ������ ���� �Լ�, ����� �� �Լ��� �ǵ��� �� ��.
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // ID, PW �Է�â�� KeyPress �̺�Ʈ �ڵ鷯 ���
            textbox_id.KeyPress += new KeyPressEventHandler(get_enter);
            textbox_pw.KeyPress += new KeyPressEventHandler(get_enter);

            // ���Ǹ� ���� ID, PW�� �̸� �Է��س��´�.
            textbox_id.Text = "admin";
            textbox_pw.Text = "admin";

            // ��й�ȣ�� ��Ŀ���� �Ǵ�.
            textbox_pw.Focus();
        }

        // ���� ��ư
        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // �α��� ��ư
        private void button_login_Click(object sender, EventArgs e)
        {
            /*
               �ܺ� ���̺귯���� ����� �� �����Ƿ�,
               DB ���� �� �α��� ó���� ���ڿ� �� �񱳷� ��ü�Ѵ�.
               id : admin, pw : admin
               �� ���� ������ �־ ���� ���� �α��� �ǵ��� Trim ó���� ���Ѵ�.
             */
            if (textbox_id.Text.Trim() == "admin" && textbox_pw.Text.Trim() == "admin")
            {
                /*
                  �α��� ������ ���� ȭ������ �̵� :
                  �α��� â �����
                  Close�� �ƴ� Hide�� �ϴ� ������, �� ���α׷��� �������� LoginForm�� ������
                  ���α׷��� ����Ǳ� �����̴�. ���� ������ ���� ó���Ѵ�.
                */
                this.Hide();

                /*
                  ���⼭ ���� ȭ���� ���µ� �߿��� ����,
                  ���� ���� ������ ���α׷��� ����ǰ� �ؾ� �ϴµ�,
                  ���� Hide�� ������ �α��� ���� ���� ������ ���ᰡ �ȴ�.
                  ���� ���� ���� ������ �ش� LoginForm�� ���� ����ǵ���
                  �̺�Ʈ �ڵ鷯�� �ɾ���� �Ѵ�.
                 */

                MainForm main_form = new MainForm();
                main_form.Closed += (s, args) => this.Close(); // important!
                main_form.ShowDialog();
            }
            else
            {
                // �α��� ����
                MessageBox.Show("�α��ο� �����߽��ϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ? ��ư = ���� ��ư
        private void button_information_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���̵� / ��й�ȣ �н�, ���� �� ȸ������ ���Ǵ� admin@naver.com ���� ���� �ٶ��ϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ID, PW �ؽ�Ʈ �ڽ����� ����Ű �Է½� �����ϴ� �̺�Ʈ �ڵ鷯
        private void get_enter(object sender, KeyPressEventArgs e)
        {
            // ����Ű ������ �α��� ��ư Ŭ�� �̺�Ʈ �߻�
            if (e.KeyChar == (char)Keys.Enter)
            {
                button_login_Click(sender, e);
            }
        }
    }
}