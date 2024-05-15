namespace POS_Project_Team2
{
    partial class PaymentForm
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
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            label_realtime_clock = new Label();
            label_waiting_page = new Label();
            lvwProducts = new ListView();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label9 = new Label();
            label7 = new Label();
            label8 = new Label();
            label_Paid = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            totalAmount = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            splitter1 = new Splitter();
            label5 = new Label();
            splitter2 = new Splitter();
            labelNumProduct = new Label();
            labelAmountMoney = new Label();
            button1 = new Button();
            button2 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.notifications_24dp_FILL0_wght400_GRAD0_opsz24;
            pictureBox1.Location = new Point(706, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.menu_24dp_FILL0_wght400_GRAD0_opsz24;
            pictureBox3.Location = new Point(749, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 39);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label_realtime_clock);
            panel1.Controls.Add(label_waiting_page);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 40);
            panel1.TabIndex = 15;
            // 
            // label_realtime_clock
            // 
            label_realtime_clock.AutoSize = true;
            label_realtime_clock.Location = new Point(164, 14);
            label_realtime_clock.Name = "label_realtime_clock";
            label_realtime_clock.Size = new Size(87, 15);
            label_realtime_clock.TabIndex = 17;
            label_realtime_clock.Text = "현재 날짜 시간";
            // 
            // label_waiting_page
            // 
            label_waiting_page.AutoSize = true;
            label_waiting_page.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_waiting_page.Location = new Point(49, 9);
            label_waiting_page.Name = "label_waiting_page";
            label_waiting_page.Size = new Size(53, 20);
            label_waiting_page.TabIndex = 16;
            label_waiting_page.Text = "대기 1";
            // 
            // lvwProducts
            // 
            lvwProducts.Location = new Point(27, 6);
            lvwProducts.Name = "lvwProducts";
            lvwProducts.Size = new Size(596, 212);
            lvwProducts.TabIndex = 16;
            lvwProducts.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 17;
            label1.Text = "받을 금액";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(totalAmount);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(353, 273);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(270, 125);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label_Paid);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(6, 43);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(258, 82);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(170, 42);
            label9.Name = "label9";
            label9.Size = new Size(27, 25);
            label9.TabIndex = 20;
            label9.Text = "N";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(232, 19);
            label7.Name = "label7";
            label7.Size = new Size(26, 21);
            label7.TabIndex = 20;
            label7.Text = "원";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(232, 53);
            label8.Name = "label8";
            label8.Size = new Size(26, 21);
            label8.TabIndex = 21;
            label8.Text = "원";
            // 
            // label_Paid
            // 
            label_Paid.AutoSize = true;
            label_Paid.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_Paid.Location = new Point(170, 16);
            label_Paid.Name = "label_Paid";
            label_Paid.Size = new Size(20, 20);
            label_Paid.TabIndex = 21;
            label_Paid.Text = "N";
            label_Paid.Click += label_Paid_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(6, 50);
            label4.Name = "label4";
            label4.Size = new Size(60, 17);
            label4.TabIndex = 20;
            label4.Text = "거스름돈";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(78, 17);
            label3.TabIndex = 19;
            label3.Text = "결제한 금액";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(238, 19);
            label2.Name = "label2";
            label2.Size = new Size(26, 21);
            label2.TabIndex = 19;
            label2.Text = "원";
            // 
            // totalAmount
            // 
            totalAmount.AutoSize = true;
            totalAmount.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point);
            totalAmount.ForeColor = Color.Red;
            totalAmount.Location = new Point(176, 10);
            totalAmount.Name = "totalAmount";
            totalAmount.Size = new Size(32, 32);
            totalAmount.TabIndex = 18;
            totalAmount.Text = "N";
            // 
            // panel2
            // 
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(lvwProducts);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 410);
            panel2.TabIndex = 19;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(labelAmountMoney);
            panel3.Controls.Add(labelNumProduct);
            panel3.Controls.Add(splitter2);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(splitter1);
            panel3.Location = new Point(27, 228);
            panel3.Name = "panel3";
            panel3.Size = new Size(596, 39);
            panel3.TabIndex = 20;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(302, 39);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(123, 9);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 1;
            label5.Text = "합계";
            // 
            // splitter2
            // 
            splitter2.Location = new Point(302, 0);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(153, 39);
            splitter2.TabIndex = 2;
            splitter2.TabStop = false;
            // 
            // labelNumProduct
            // 
            labelNumProduct.AutoSize = true;
            labelNumProduct.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelNumProduct.Location = new Point(364, 9);
            labelNumProduct.Name = "labelNumProduct";
            labelNumProduct.Size = new Size(20, 20);
            labelNumProduct.TabIndex = 3;
            labelNumProduct.Text = "N";
            // 
            // labelAmountMoney
            // 
            labelAmountMoney.AutoSize = true;
            labelAmountMoney.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelAmountMoney.Location = new Point(514, 9);
            labelAmountMoney.Name = "labelAmountMoney";
            labelAmountMoney.Size = new Size(20, 20);
            labelAmountMoney.TabIndex = 4;
            labelAmountMoney.Text = "N";
            // 
            // button1
            // 
            button1.BackColor = Color.BlueViolet;
            button1.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(626, 6);
            button1.Name = "button1";
            button1.Size = new Size(171, 148);
            button1.TabIndex = 21;
            button1.Text = "상품 선택";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.ForestGreen;
            button2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(626, 161);
            button2.Name = "button2";
            button2.Size = new Size(171, 54);
            button2.TabIndex = 22;
            button2.Text = "신용카드";
            button2.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 128, 128);
            button5.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(629, 335);
            button5.Name = "button5";
            button5.Size = new Size(82, 55);
            button5.TabIndex = 25;
            button5.Text = "전체 취소";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(64, 64, 64);
            button4.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(715, 335);
            button4.Name = "button4";
            button4.Size = new Size(82, 55);
            button4.TabIndex = 29;
            button4.Text = "대기";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.ForestGreen;
            button3.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(626, 271);
            button3.Name = "button3";
            button3.Size = new Size(171, 54);
            button3.TabIndex = 30;
            button3.Text = "모바일";
            button3.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.ForestGreen;
            button6.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.White;
            button6.Location = new Point(626, 217);
            button6.Name = "button6";
            button6.Size = new Size(171, 54);
            button6.TabIndex = 31;
            button6.Text = "현금";
            button6.UseVisualStyleBackColor = false;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "PaymentForm";
            Text = "PaymentForm";
            Load += PaymentForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Label label_waiting_page;
        private Label label_realtime_clock;
        private ListView lvwProducts;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label totalAmount;
        private GroupBox groupBox2;
        private Label label9;
        private Label label7;
        private Label label8;
        private Label label_Paid;
        private Label label4;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private Label labelAmountMoney;
        private Label labelNumProduct;
        private Splitter splitter2;
        private Label label5;
        private Splitter splitter1;
        private Button button4;
        private Button button5;
        private Button button2;
        private Button button1;
        private Button button6;
        private Button button3;
    }
}