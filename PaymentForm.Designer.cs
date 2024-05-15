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
            btn_Cash = new Button();
            btn_Mobile = new Button();
            btn_Waiting = new Button();
            btn_AllCancel = new Button();
            btn_Card = new Button();
            btn_SelectProduct = new Button();
            panel3 = new Panel();
            labelAmountMoney = new Label();
            labelNumProduct = new Label();
            splitter2 = new Splitter();
            label5 = new Label();
            splitter1 = new Splitter();
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
            label9.Location = new Point(169, 46);
            label9.Name = "label9";
            label9.Size = new Size(27, 25);
            label9.TabIndex = 20;
            label9.Text = "N";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(226, 19);
            label7.Name = "label7";
            label7.Size = new Size(26, 21);
            label7.TabIndex = 20;
            label7.Text = "원";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(226, 48);
            label8.Name = "label8";
            label8.Size = new Size(26, 21);
            label8.TabIndex = 21;
            label8.Text = "원";
            // 
            // label_Paid
            // 
            label_Paid.AutoSize = true;
            label_Paid.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_Paid.Location = new Point(170, 19);
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
            totalAmount.Location = new Point(173, 12);
            totalAmount.Name = "totalAmount";
            totalAmount.Size = new Size(32, 32);
            totalAmount.TabIndex = 18;
            totalAmount.Text = "N";
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_Cash);
            panel2.Controls.Add(btn_Mobile);
            panel2.Controls.Add(btn_Waiting);
            panel2.Controls.Add(btn_AllCancel);
            panel2.Controls.Add(btn_Card);
            panel2.Controls.Add(btn_SelectProduct);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(lvwProducts);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 410);
            panel2.TabIndex = 19;
            // 
            // btn_Cash
            // 
            btn_Cash.BackColor = Color.ForestGreen;
            btn_Cash.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Cash.ForeColor = Color.White;
            btn_Cash.Location = new Point(626, 217);
            btn_Cash.Name = "btn_Cash";
            btn_Cash.Size = new Size(171, 54);
            btn_Cash.TabIndex = 31;
            btn_Cash.Text = "현금";
            btn_Cash.UseVisualStyleBackColor = false;
            // 
            // btn_Mobile
            // 
            btn_Mobile.BackColor = Color.ForestGreen;
            btn_Mobile.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Mobile.ForeColor = Color.White;
            btn_Mobile.Location = new Point(626, 271);
            btn_Mobile.Name = "btn_Mobile";
            btn_Mobile.Size = new Size(171, 54);
            btn_Mobile.TabIndex = 30;
            btn_Mobile.Text = "모바일";
            btn_Mobile.UseVisualStyleBackColor = false;
            // 
            // btn_Waiting
            // 
            btn_Waiting.BackColor = Color.FromArgb(64, 64, 64);
            btn_Waiting.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Waiting.ForeColor = Color.White;
            btn_Waiting.Location = new Point(715, 335);
            btn_Waiting.Name = "btn_Waiting";
            btn_Waiting.Size = new Size(82, 55);
            btn_Waiting.TabIndex = 29;
            btn_Waiting.Text = "대기";
            btn_Waiting.UseVisualStyleBackColor = false;
            // 
            // btn_AllCancel
            // 
            btn_AllCancel.BackColor = Color.FromArgb(255, 128, 128);
            btn_AllCancel.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_AllCancel.ForeColor = Color.White;
            btn_AllCancel.Location = new Point(629, 335);
            btn_AllCancel.Name = "btn_AllCancel";
            btn_AllCancel.Size = new Size(82, 55);
            btn_AllCancel.TabIndex = 25;
            btn_AllCancel.Text = "전체 취소";
            btn_AllCancel.UseVisualStyleBackColor = false;
            // 
            // btn_Card
            // 
            btn_Card.BackColor = Color.ForestGreen;
            btn_Card.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Card.ForeColor = Color.White;
            btn_Card.Location = new Point(626, 161);
            btn_Card.Name = "btn_Card";
            btn_Card.Size = new Size(171, 54);
            btn_Card.TabIndex = 22;
            btn_Card.Text = "신용카드";
            btn_Card.UseVisualStyleBackColor = false;
            // 
            // btn_SelectProduct
            // 
            btn_SelectProduct.BackColor = Color.BlueViolet;
            btn_SelectProduct.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_SelectProduct.ForeColor = SystemColors.ButtonHighlight;
            btn_SelectProduct.Location = new Point(626, 6);
            btn_SelectProduct.Name = "btn_SelectProduct";
            btn_SelectProduct.Size = new Size(171, 148);
            btn_SelectProduct.TabIndex = 21;
            btn_SelectProduct.Text = "상품 선택";
            btn_SelectProduct.UseVisualStyleBackColor = false;
            btn_SelectProduct.Click += btn_SelectProduct_Click;
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
            // splitter2
            // 
            splitter2.Location = new Point(302, 0);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(153, 39);
            splitter2.TabIndex = 2;
            splitter2.TabStop = false;
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
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(302, 39);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
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
        private Button btn_Waiting;
        private Button btn_AllCancel;
        private Button btn_Card;
        private Button btn_SelectProduct;
        private Button btn_Cash;
        private Button btn_Mobile;
    }
}