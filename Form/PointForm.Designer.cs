namespace POS_Project_Team2
{
    partial class PointForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            textbox_name = new TextBox();
            textbox_phone_4 = new TextBox();
            button_point_ok = new Button();
            button_point_cancle = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(27, 26);
            label1.Name = "label1";
            label1.Size = new Size(319, 20);
            label1.TabIndex = 0;
            label1.Text = "포인트 적립을 위해 아래 정보를 입력해주세요";
            // 
            // textbox_name
            // 
            textbox_name.Location = new Point(27, 63);
            textbox_name.Name = "textbox_name";
            textbox_name.PlaceholderText = "이름";
            textbox_name.Size = new Size(142, 27);
            textbox_name.TabIndex = 1;
            // 
            // textbox_phone_4
            // 
            textbox_phone_4.Location = new Point(197, 63);
            textbox_phone_4.Name = "textbox_phone_4";
            textbox_phone_4.PlaceholderText = "전화번호 뒷 4자리";
            textbox_phone_4.Size = new Size(149, 27);
            textbox_phone_4.TabIndex = 2;
            textbox_phone_4.KeyPress += textbox_phone_4_KeyPress;
            // 
            // button_point_ok
            // 
            button_point_ok.Location = new Point(79, 117);
            button_point_ok.Name = "button_point_ok";
            button_point_ok.Size = new Size(100, 29);
            button_point_ok.TabIndex = 3;
            button_point_ok.Text = "확인";
            button_point_ok.UseVisualStyleBackColor = true;
            button_point_ok.Click += button_point_ok_Click;
            // 
            // button_point_cancle
            // 
            button_point_cancle.Location = new Point(185, 117);
            button_point_cancle.Name = "button_point_cancle";
            button_point_cancle.Size = new Size(100, 29);
            button_point_cancle.TabIndex = 4;
            button_point_cancle.Text = "취소";
            button_point_cancle.UseVisualStyleBackColor = true;
            button_point_cancle.Click += button_point_cancle_Click;
            // 
            // PointForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 164);
            Controls.Add(button_point_cancle);
            Controls.Add(button_point_ok);
            Controls.Add(textbox_phone_4);
            Controls.Add(textbox_name);
            Controls.Add(label1);
            Name = "PointForm";
            Text = "POS System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textbox_name;
        private TextBox textbox_phone_4;
        private Button button_point_ok;
        private Button button_point_cancle;
    }
}