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
            components = new System.ComponentModel.Container();
            label_realtime_clock = new Label();
            button_get_all = new Button();
            button_get_goods = new Button();
            button_get_receipt = new Button();
            button_get_stock = new Button();
            button_get_tpt = new Button();
            groupBox1 = new GroupBox();
            button_payment = new Button();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            button_receipt = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox4 = new GroupBox();
            button_refund = new Button();
            listView1 = new ListView();
            picture_box_alarm = new PictureBox();
            picture_box_menu = new PictureBox();
            pictureBox2 = new PictureBox();
            realtime_timer = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_box_alarm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_box_menu).BeginInit();
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
            // button_get_all
            // 
            button_get_all.Location = new Point(20, 45);
            button_get_all.Name = "button_get_all";
            button_get_all.Size = new Size(231, 45);
            button_get_all.TabIndex = 1;
            button_get_all.Text = "통합 조회";
            button_get_all.UseVisualStyleBackColor = true;
            // 
            // button_get_goods
            // 
            button_get_goods.Location = new Point(20, 108);
            button_get_goods.Name = "button_get_goods";
            button_get_goods.Size = new Size(112, 45);
            button_get_goods.TabIndex = 2;
            button_get_goods.Text = "상품 조회";
            button_get_goods.UseVisualStyleBackColor = true;
            // 
            // button_get_receipt
            // 
            button_get_receipt.Location = new Point(138, 108);
            button_get_receipt.Name = "button_get_receipt";
            button_get_receipt.Size = new Size(113, 45);
            button_get_receipt.TabIndex = 3;
            button_get_receipt.Text = "영수증 조회";
            button_get_receipt.UseVisualStyleBackColor = true;
            // 
            // button_get_stock
            // 
            button_get_stock.Location = new Point(20, 172);
            button_get_stock.Name = "button_get_stock";
            button_get_stock.Size = new Size(112, 45);
            button_get_stock.TabIndex = 4;
            button_get_stock.Text = "재고 조회";
            button_get_stock.UseVisualStyleBackColor = true;
            // 
            // button_get_tpt
            // 
            button_get_tpt.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button_get_tpt.Location = new Point(138, 172);
            button_get_tpt.Name = "button_get_tpt";
            button_get_tpt.Size = new Size(113, 45);
            button_get_tpt.TabIndex = 5;
            button_get_tpt.Text = "교통카드\r\n잔액 조회";
            button_get_tpt.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_get_all);
            groupBox1.Controls.Add(button_get_tpt);
            groupBox1.Controls.Add(button_get_goods);
            groupBox1.Controls.Add(button_get_stock);
            groupBox1.Controls.Add(button_get_receipt);
            groupBox1.Location = new Point(20, 225);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 256);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "조회";
            // 
            // button_payment
            // 
            button_payment.Location = new Point(15, 24);
            button_payment.Name = "button_payment";
            button_payment.Size = new Size(178, 81);
            button_payment.TabIndex = 7;
            button_payment.Text = "결제";
            button_payment.UseVisualStyleBackColor = true;
            button_payment.Click += button6_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(button_payment);
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
            groupBox3.Controls.Add(button_receipt);
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
            // button_receipt
            // 
            button_receipt.Location = new Point(252, 19);
            button_receipt.Name = "button_receipt";
            button_receipt.Size = new Size(121, 37);
            button_receipt.TabIndex = 15;
            button_receipt.Text = "영수증 출력";
            button_receipt.UseVisualStyleBackColor = true;
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
            groupBox4.Controls.Add(button_refund);
            groupBox4.Controls.Add(listView1);
            groupBox4.Location = new Point(732, 225);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(264, 304);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "기타";
            // 
            // button_refund
            // 
            button_refund.Location = new Point(15, 172);
            button_refund.Name = "button_refund";
            button_refund.Size = new Size(243, 112);
            button_refund.TabIndex = 1;
            button_refund.Text = "환불";
            button_refund.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(15, 25);
            listView1.Name = "listView1";
            listView1.Size = new Size(243, 142);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // picture_box_alarm
            // 
            picture_box_alarm.Image = Properties.Resources.notifications_24dp_FILL0_wght400_GRAD0_opsz24;
            picture_box_alarm.Location = new Point(910, 17);
            picture_box_alarm.Name = "picture_box_alarm";
            picture_box_alarm.Size = new Size(37, 39);
            picture_box_alarm.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_box_alarm.TabIndex = 11;
            picture_box_alarm.TabStop = false;
            // 
            // picture_box_menu
            // 
            picture_box_menu.Image = Properties.Resources.menu_24dp_FILL0_wght400_GRAD0_opsz24;
            picture_box_menu.Location = new Point(953, 17);
            picture_box_menu.Name = "picture_box_menu";
            picture_box_menu.Size = new Size(37, 39);
            picture_box_menu.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_box_menu.TabIndex = 13;
            picture_box_menu.TabStop = false;
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
            // realtime_timer
            // 
            realtime_timer.Interval = 1000;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1016, 545);
            Controls.Add(pictureBox2);
            Controls.Add(picture_box_menu);
            Controls.Add(picture_box_alarm);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label_realtime_clock);
            Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlText;
            Name = "MainForm";
            Text = "POS System";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picture_box_alarm).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_box_menu).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_realtime_clock;
        private Button button_get_all;
        private Button button_get_goods;
        private Button button_get_receipt;
        private Button button_get_stock;
        private Button button_get_tpt;
        private GroupBox groupBox1;
        private Button button_payment;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button_receipt;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private Label label8;
        private Label label7;
        private GroupBox groupBox4;
        private ListView listView1;
        private Button button_refund;
        private PictureBox picture_box_alarm;
        private PictureBox picture_box_menu;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer realtime_timer;
    }
}