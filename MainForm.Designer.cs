namespace POS_Project_Team2
{
    partial class MainForm
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
            label_realtime_clock = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            groupBox1 = new GroupBox();
            button6 = new Button();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            button7 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox4 = new GroupBox();
            button8 = new Button();
            listView1 = new ListView();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label_realtime_clock
            // 
            label_realtime_clock.AutoSize = true;
            label_realtime_clock.Location = new Point(17, 17);
            label_realtime_clock.Name = "label_realtime_clock";
            label_realtime_clock.Size = new Size(103, 19);
            label_realtime_clock.TabIndex = 0;
            label_realtime_clock.Text = "현재 날짜 시간";
            // 
            // button1
            // 
            button1.Location = new Point(20, 45);
            button1.Name = "button1";
            button1.Size = new Size(231, 45);
            button1.TabIndex = 1;
            button1.Text = "통합 조회";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(20, 108);
            button2.Name = "button2";
            button2.Size = new Size(112, 45);
            button2.TabIndex = 2;
            button2.Text = "상품 조회";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(138, 108);
            button3.Name = "button3";
            button3.Size = new Size(113, 45);
            button3.TabIndex = 3;
            button3.Text = "영수증 조회";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(20, 172);
            button4.Name = "button4";
            button4.Size = new Size(112, 45);
            button4.TabIndex = 4;
            button4.Text = "재고 조회";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(138, 172);
            button5.Name = "button5";
            button5.Size = new Size(113, 45);
            button5.TabIndex = 5;
            button5.Text = "교통카드\r\n잔액 조회";
            button5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Location = new Point(20, 225);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 256);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "조회";
            // 
            // button6
            // 
            button6.Location = new Point(15, 24);
            button6.Name = "button6";
            button6.Size = new Size(178, 81);
            button6.TabIndex = 7;
            button6.Text = "결제";
            button6.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(button6);
            groupBox2.Location = new Point(313, 225);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(413, 304);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "메인";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(button7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(15, 111);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(379, 173);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "직전 결제 내역";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(158, 120);
            label9.Name = "label9";
            label9.Size = new Size(34, 19);
            label9.TabIndex = 18;
            label9.Text = "N원";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(158, 94);
            label8.Name = "label8";
            label8.Size = new Size(34, 19);
            label8.TabIndex = 17;
            label8.Text = "N원";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(158, 70);
            label7.Name = "label7";
            label7.Size = new Size(34, 19);
            label7.TabIndex = 16;
            label7.Text = "N원";
            // 
            // button7
            // 
            button7.Location = new Point(252, 19);
            button7.Name = "button7";
            button7.Size = new Size(121, 37);
            button7.TabIndex = 15;
            button7.Text = "영수증 출력";
            button7.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 120);
            label6.Name = "label6";
            label6.Size = new Size(65, 19);
            label6.TabIndex = 14;
            label6.Text = "거스름돈";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 94);
            label5.Name = "label5";
            label5.Size = new Size(70, 19);
            label5.TabIndex = 13;
            label5.Text = "결제 금액";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 70);
            label4.Name = "label4";
            label4.Size = new Size(70, 19);
            label4.TabIndex = 12;
            label4.Text = "총 구매액";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(214, 86);
            label3.Name = "label3";
            label3.Size = new Size(119, 19);
            label3.TabIndex = 10;
            label3.Text = "금일 총 수익 N원";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(214, 56);
            label2.Name = "label2";
            label2.Size = new Size(119, 19);
            label2.TabIndex = 9;
            label2.Text = "금일 총 환불 N건";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(214, 24);
            label1.Name = "label1";
            label1.Size = new Size(119, 19);
            label1.TabIndex = 8;
            label1.Text = "금일 총 판매 N건";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button8);
            groupBox4.Controls.Add(listView1);
            groupBox4.Location = new Point(732, 225);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(264, 304);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "기타";
            // 
            // button8
            // 
            button8.Location = new Point(15, 172);
            button8.Name = "button8";
            button8.Size = new Size(243, 112);
            button8.TabIndex = 1;
            button8.Text = "환불";
            button8.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(15, 24);
            listView1.Name = "listView1";
            listView1.Size = new Size(243, 142);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.notifications_24dp_FILL0_wght400_GRAD0_opsz24;
            pictureBox1.Location = new Point(910, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.menu_24dp_FILL0_wght400_GRAD0_opsz24;
            pictureBox3.Location = new Point(953, 17);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 39);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.광운문구_축소;
            pictureBox2.Location = new Point(412, 17);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(197, 194);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 545);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label_realtime_clock);
            Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "MainForm";
            Text = "POS System";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_realtime_clock;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private GroupBox groupBox1;
        private Button button6;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private Label label8;
        private Label label7;
        private GroupBox groupBox4;
        private ListView listView1;
        private Button button8;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
    }
}