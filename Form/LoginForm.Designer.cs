namespace POS_Project_Team2
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label label_title;
        private TextBox textbox_id;
        private TextBox textbox_pw;
        private Button button_online;
        private Button button_offline;
        private Button button_login;
        private Panel panel_background;



        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_title = new Label();
            textbox_id = new TextBox();
            textbox_pw = new TextBox();
            button_online = new Button();
            button_offline = new Button();
            button_login = new Button();
            panel_background = new Panel();
            checkbox_auto_login = new CheckBox();
            label_pw = new Label();
            label_id = new Label();
            button_information = new Button();
            panel_background.SuspendLayout();
            SuspendLayout();
            // 
            // label_title
            // 
            label_title.AutoSize = true;
            label_title.Font = new Font("맑은 고딕", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label_title.ForeColor = Color.White;
            label_title.Location = new Point(170, 29);
            label_title.Name = "label_title";
            label_title.Size = new Size(117, 30);
            label_title.TabIndex = 0;
            label_title.Text = "Welcome!";
            // 
            // textbox_id
            // 
            textbox_id.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textbox_id.Location = new Point(86, 138);
            textbox_id.Name = "textbox_id";
            textbox_id.Size = new Size(300, 25);
            textbox_id.TabIndex = 2;
            // 
            // textbox_pw
            // 
            textbox_pw.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textbox_pw.Location = new Point(86, 206);
            textbox_pw.Name = "textbox_pw";
            textbox_pw.PasswordChar = '●';
            textbox_pw.Size = new Size(300, 25);
            textbox_pw.TabIndex = 4;
            // 
            // button_online
            // 
            button_online.BackColor = Color.Gray;
            button_online.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button_online.ForeColor = Color.White;
            button_online.Location = new Point(218, 357);
            button_online.Name = "button_online";
            button_online.Size = new Size(85, 34);
            button_online.TabIndex = 5;
            button_online.Text = "온라인";
            button_online.UseVisualStyleBackColor = false;
            button_online.Click += button_online_Click;
            // 
            // button_offline
            // 
            button_offline.BackColor = Color.Green;
            button_offline.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button_offline.ForeColor = Color.White;
            button_offline.Location = new Point(309, 357);
            button_offline.Name = "button_offline";
            button_offline.Size = new Size(99, 34);
            button_offline.TabIndex = 6;
            button_offline.Text = "오프라인";
            button_offline.UseVisualStyleBackColor = false;
            button_offline.Click += button_offline_Click;
            // 
            // button_login
            // 
            button_login.BackColor = SystemColors.Highlight;
            button_login.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button_login.ForeColor = Color.White;
            button_login.Location = new Point(19, 184);
            button_login.Name = "button_login";
            button_login.Size = new Size(300, 49);
            button_login.TabIndex = 8;
            button_login.Text = "로그인 [Enter]";
            button_login.UseVisualStyleBackColor = false;
            button_login.Click += button_login_Click;
            // 
            // panel_background
            // 
            panel_background.BackColor = Color.FromArgb(224, 224, 224);
            panel_background.Controls.Add(checkbox_auto_login);
            panel_background.Controls.Add(label_pw);
            panel_background.Controls.Add(label_id);
            panel_background.Controls.Add(button_login);
            panel_background.Location = new Point(66, 82);
            panel_background.Name = "panel_background";
            panel_background.Size = new Size(340, 263);
            panel_background.TabIndex = 9;
            panel_background.Paint += panel_background_Paint;
            // 
            // checkbox_auto_login
            // 
            checkbox_auto_login.AutoSize = true;
            checkbox_auto_login.Location = new Point(20, 155);
            checkbox_auto_login.Name = "checkbox_auto_login";
            checkbox_auto_login.Size = new Size(103, 23);
            checkbox_auto_login.TabIndex = 2;
            checkbox_auto_login.Text = "자동 로그인";
            checkbox_auto_login.UseVisualStyleBackColor = true;
            // 
            // label_pw
            // 
            label_pw.AutoSize = true;
            label_pw.Location = new Point(19, 102);
            label_pw.Name = "label_pw";
            label_pw.Size = new Size(65, 19);
            label_pw.TabIndex = 1;
            label_pw.Text = "비밀번호";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(19, 33);
            label_id.Name = "label_id";
            label_id.Size = new Size(51, 19);
            label_id.TabIndex = 0;
            label_id.Text = "아이디";
            // 
            // button_information
            // 
            button_information.BackColor = SystemColors.Highlight;
            button_information.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button_information.ForeColor = Color.White;
            button_information.Location = new Point(65, 357);
            button_information.Name = "button_information";
            button_information.Size = new Size(39, 34);
            button_information.TabIndex = 10;
            button_information.Text = "?";
            button_information.UseVisualStyleBackColor = false;
            button_information.Click += button_information_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(153, 204, 255);
            ClientSize = new Size(480, 422);
            Controls.Add(button_information);
            Controls.Add(label_title);
            Controls.Add(textbox_id);
            Controls.Add(textbox_pw);
            Controls.Add(button_online);
            Controls.Add(button_offline);
            Controls.Add(panel_background);
            Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "LoginForm";
            Text = "POS System";
            Load += DesignTest_Load;
            panel_background.ResumeLayout(false);
            panel_background.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private CheckBox checkbox_auto_login;
        private Label label_pw;
        private Label label_id;
        private Button button_information;
    }
}