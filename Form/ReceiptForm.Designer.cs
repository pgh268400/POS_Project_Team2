namespace POS_Project_Team2
{
    partial class ReceiptForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            button_print = new Button();
            button_cancle = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(45, 63);
            label1.Name = "label1";
            label1.Size = new Size(239, 28);
            label1.TabIndex = 0;
            label1.Text = "구매하신 회원 정보 : null";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(45, 96);
            label2.Name = "label2";
            label2.Size = new Size(192, 28);
            label2.TabIndex = 1;
            label2.Text = "구매하신 물품 : null";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(45, 132);
            label3.Name = "label3";
            label3.Size = new Size(239, 28);
            label3.TabIndex = 2;
            label3.Text = "구매하신 물품 개수 : null";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(45, 169);
            label4.Name = "label4";
            label4.Size = new Size(226, 28);
            label4.TabIndex = 3;
            label4.Text = "결제 하신 총 금액 : null";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(31, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(347, 251);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "광운 문구";
            // 
            // button_print
            // 
            button_print.Location = new Point(31, 274);
            button_print.Name = "button_print";
            button_print.Size = new Size(164, 49);
            button_print.TabIndex = 5;
            button_print.Text = "출력";
            button_print.UseVisualStyleBackColor = true;
            // 
            // button_cancle
            // 
            button_cancle.Location = new Point(214, 274);
            button_cancle.Name = "button_cancle";
            button_cancle.Size = new Size(164, 49);
            button_cancle.TabIndex = 6;
            button_cancle.Text = "취소";
            button_cancle.UseVisualStyleBackColor = true;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 335);
            Controls.Add(button_cancle);
            Controls.Add(button_print);
            Controls.Add(groupBox1);
            Name = "ReceiptForm";
            Text = "ReceiptForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private Button button_print;
        private Button button_cancle;
    }
}