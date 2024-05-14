namespace POS_Project_Team2
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_id = new Label();
            label_pw = new Label();
            textbox_id = new TextBox();
            textbox_pw = new TextBox();
            button_login = new Button();
            button_exit = new Button();
            button_information = new Button();
            SuspendLayout();
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(26, 26);
            label_id.Name = "label_id";
            label_id.Size = new Size(51, 19);
            label_id.TabIndex = 0;
            label_id.Text = "아이디";
            // 
            // label_pw
            // 
            label_pw.AutoSize = true;
            label_pw.Location = new Point(26, 59);
            label_pw.Name = "label_pw";
            label_pw.Size = new Size(65, 19);
            label_pw.TabIndex = 1;
            label_pw.Text = "비밀번호";
            // 
            // textbox_id
            // 
            textbox_id.Location = new Point(108, 23);
            textbox_id.Name = "textbox_id";
            textbox_id.Size = new Size(161, 25);
            textbox_id.TabIndex = 2;
            // 
            // textbox_pw
            // 
            textbox_pw.Location = new Point(108, 59);
            textbox_pw.Name = "textbox_pw";
            textbox_pw.PasswordChar = '*';
            textbox_pw.Size = new Size(161, 25);
            textbox_pw.TabIndex = 3;
            // 
            // button_login
            // 
            button_login.Location = new Point(108, 90);
            button_login.Name = "button_login";
            button_login.Size = new Size(91, 29);
            button_login.TabIndex = 4;
            button_login.Text = "로그인";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // button_exit
            // 
            button_exit.Location = new Point(205, 90);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(64, 29);
            button_exit.TabIndex = 5;
            button_exit.Text = "종료";
            button_exit.UseVisualStyleBackColor = true;
            button_exit.Click += button_exit_Click;
            // 
            // button_information
            // 
            button_information.Location = new Point(27, 90);
            button_information.Name = "button_information";
            button_information.Size = new Size(33, 29);
            button_information.TabIndex = 6;
            button_information.Text = "?";
            button_information.UseVisualStyleBackColor = true;
            button_information.Click += button_information_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 149);
            Controls.Add(button_information);
            Controls.Add(button_exit);
            Controls.Add(button_login);
            Controls.Add(textbox_pw);
            Controls.Add(textbox_id);
            Controls.Add(label_pw);
            Controls.Add(label_id);
            Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "LoginForm";
            Text = "POS System";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_id;
        private Label label_pw;
        private TextBox textbox_id;
        private TextBox textbox_pw;
        private Button button_login;
        private Button button_exit;
        private Button button_information;
    }
}