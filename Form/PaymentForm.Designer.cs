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
            label_wait3 = new Label();
            label_wait2 = new Label();
            label_wait1 = new Label();
            label_realtime_clock = new Label();
            lvwProducts = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label_change = new Label();
            label7 = new Label();
            label8 = new Label();
            label_paid = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label_total_amount = new Label();
            panel2 = new Panel();
            button1 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label_amount_money = new Label();
            label_num_product = new Label();
            label_sum = new Label();
            button_cash = new Button();
            button_mobile = new Button();
            button_wait = new Button();
            button_all_cancle = new Button();
            button_card = new Button();
            button_select_product = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            panel1.Controls.Add(label_wait3);
            panel1.Controls.Add(label_wait2);
            panel1.Controls.Add(label_wait1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 40);
            panel1.TabIndex = 15;
            // 
            // label_wait3
            // 
            label_wait3.AutoSize = true;
            label_wait3.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_wait3.Location = new Point(301, 9);
            label_wait3.Name = "label_wait3";
            label_wait3.Size = new Size(68, 20);
            label_wait3.TabIndex = 18;
            label_wait3.Text = "대기열 3";
            // 
            // label_wait2
            // 
            label_wait2.AutoSize = true;
            label_wait2.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_wait2.Location = new Point(168, 9);
            label_wait2.Name = "label_wait2";
            label_wait2.Size = new Size(68, 20);
            label_wait2.TabIndex = 17;
            label_wait2.Text = "대기열 2";
            // 
            // label_wait1
            // 
            label_wait1.AutoSize = true;
            label_wait1.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_wait1.Location = new Point(50, 9);
            label_wait1.Name = "label_wait1";
            label_wait1.Size = new Size(68, 20);
            label_wait1.TabIndex = 16;
            label_wait1.Text = "대기열 1";
            // 
            // label_realtime_clock
            // 
            label_realtime_clock.AutoSize = true;
            label_realtime_clock.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label_realtime_clock.Location = new Point(27, 379);
            label_realtime_clock.Name = "label_realtime_clock";
            label_realtime_clock.Size = new Size(103, 19);
            label_realtime_clock.TabIndex = 17;
            label_realtime_clock.Text = "현재 날짜 시간";
            // 
            // lvwProducts
            // 
            lvwProducts.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lvwProducts.Location = new Point(27, 6);
            lvwProducts.Name = "lvwProducts";
            lvwProducts.Size = new Size(596, 212);
            lvwProducts.TabIndex = 16;
            lvwProducts.UseCompatibleStateImageBehavior = false;
            lvwProducts.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "NO";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "상품명";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "단가";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "수량";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "금액";
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
            groupBox1.Controls.Add(label_total_amount);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(353, 273);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(270, 125);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label_change);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label_paid);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(6, 43);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(258, 82);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            // 
            // label_change
            // 
            label_change.AutoSize = true;
            label_change.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_change.ForeColor = Color.Red;
            label_change.Location = new Point(169, 46);
            label_change.Name = "label_change";
            label_change.Size = new Size(22, 25);
            label_change.TabIndex = 20;
            label_change.Text = "0";
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
            label8.Location = new Point(226, 49);
            label8.Name = "label8";
            label8.Size = new Size(26, 21);
            label8.TabIndex = 21;
            label8.Text = "원";
            // 
            // label_paid
            // 
            label_paid.AutoSize = true;
            label_paid.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_paid.ForeColor = Color.Blue;
            label_paid.Location = new Point(169, 15);
            label_paid.Name = "label_paid";
            label_paid.Size = new Size(22, 25);
            label_paid.TabIndex = 21;
            label_paid.Text = "0";
            label_paid.Click += label_Paid_Click;
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
            label2.Location = new Point(232, 19);
            label2.Name = "label2";
            label2.Size = new Size(26, 21);
            label2.TabIndex = 19;
            label2.Text = "원";
            // 
            // label_total_amount
            // 
            label_total_amount.AutoSize = true;
            label_total_amount.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label_total_amount.ForeColor = Color.Red;
            label_total_amount.Location = new Point(173, 12);
            label_total_amount.Name = "label_total_amount";
            label_total_amount.Size = new Size(27, 32);
            label_total_amount.TabIndex = 18;
            label_total_amount.Text = "0";
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(label_realtime_clock);
            panel2.Controls.Add(button_cash);
            panel2.Controls.Add(button_mobile);
            panel2.Controls.Add(button_wait);
            panel2.Controls.Add(button_all_cancle);
            panel2.Controls.Add(button_card);
            panel2.Controls.Add(button_select_product);
            panel2.Controls.Add(lvwProducts);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(803, 419);
            panel2.TabIndex = 19;
            panel2.Paint += panel2_Paint;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveBorder;
            button1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(27, 277);
            button1.Name = "button1";
            button1.Size = new Size(171, 43);
            button1.TabIndex = 33;
            button1.Text = "포인트 등록";
            button1.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.BackColor = SystemColors.ActiveBorder;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.59731F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.95302F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.4496651F));
            tableLayoutPanel1.Controls.Add(label_amount_money, 2, 0);
            tableLayoutPanel1.Controls.Add(label_num_product, 1, 0);
            tableLayoutPanel1.Controls.Add(label_sum, 0, 0);
            tableLayoutPanel1.Location = new Point(27, 228);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(596, 43);
            tableLayoutPanel1.TabIndex = 32;
            // 
            // label_amount_money
            // 
            label_amount_money.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_amount_money.AutoSize = true;
            label_amount_money.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_amount_money.Location = new Point(495, 0);
            label_amount_money.Name = "label_amount_money";
            label_amount_money.Size = new Size(98, 43);
            label_amount_money.TabIndex = 4;
            label_amount_money.Text = "0원";
            label_amount_money.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_num_product
            // 
            label_num_product.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_num_product.AutoSize = true;
            label_num_product.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_num_product.Location = new Point(388, 0);
            label_num_product.Name = "label_num_product";
            label_num_product.Size = new Size(101, 43);
            label_num_product.TabIndex = 3;
            label_num_product.Text = "0개";
            label_num_product.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_sum
            // 
            label_sum.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_sum.AutoSize = true;
            label_sum.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_sum.Location = new Point(3, 0);
            label_sum.Name = "label_sum";
            label_sum.Size = new Size(379, 43);
            label_sum.TabIndex = 1;
            label_sum.Text = "합계";
            label_sum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_cash
            // 
            button_cash.BackColor = Color.ForestGreen;
            button_cash.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_cash.ForeColor = Color.White;
            button_cash.Location = new Point(626, 216);
            button_cash.Name = "button_cash";
            button_cash.Size = new Size(171, 54);
            button_cash.TabIndex = 31;
            button_cash.Text = "현금";
            button_cash.UseVisualStyleBackColor = false;
            // 
            // button_mobile
            // 
            button_mobile.BackColor = Color.ForestGreen;
            button_mobile.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_mobile.ForeColor = Color.White;
            button_mobile.Location = new Point(627, 272);
            button_mobile.Name = "button_mobile";
            button_mobile.Size = new Size(171, 54);
            button_mobile.TabIndex = 30;
            button_mobile.Text = "모바일";
            button_mobile.UseVisualStyleBackColor = false;
            // 
            // button_wait
            // 
            button_wait.BackColor = Color.FromArgb(64, 64, 64);
            button_wait.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button_wait.ForeColor = Color.White;
            button_wait.Location = new Point(715, 343);
            button_wait.Name = "button_wait";
            button_wait.Size = new Size(82, 55);
            button_wait.TabIndex = 29;
            button_wait.Text = "대기";
            button_wait.UseVisualStyleBackColor = false;
            // 
            // button_all_cancle
            // 
            button_all_cancle.BackColor = Color.FromArgb(255, 128, 128);
            button_all_cancle.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button_all_cancle.ForeColor = Color.White;
            button_all_cancle.Location = new Point(627, 343);
            button_all_cancle.Name = "button_all_cancle";
            button_all_cancle.Size = new Size(82, 55);
            button_all_cancle.TabIndex = 25;
            button_all_cancle.Text = "전체 취소";
            button_all_cancle.UseVisualStyleBackColor = false;
            // 
            // button_card
            // 
            button_card.BackColor = Color.ForestGreen;
            button_card.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_card.ForeColor = Color.White;
            button_card.Location = new Point(626, 160);
            button_card.Name = "button_card";
            button_card.Size = new Size(171, 54);
            button_card.TabIndex = 22;
            button_card.Text = "신용카드/체크카드";
            button_card.UseVisualStyleBackColor = false;
            // 
            // button_select_product
            // 
            button_select_product.BackColor = Color.BlueViolet;
            button_select_product.Font = new Font("맑은 고딕", 17F, FontStyle.Bold, GraphicsUnit.Point);
            button_select_product.ForeColor = SystemColors.ButtonHighlight;
            button_select_product.Location = new Point(626, 6);
            button_select_product.Name = "button_select_product";
            button_select_product.Size = new Size(171, 148);
            button_select_product.TabIndex = 21;
            button_select_product.Text = "상품 선택";
            button_select_product.UseVisualStyleBackColor = false;
            button_select_product.Click += btn_SelectProduct_Click;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(803, 459);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "PaymentForm";
            Text = "POS System";
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
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Label label_wait1;
        private Label label_realtime_clock;
        private ListView lvwProducts;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label_total_amount;
        private GroupBox groupBox2;
        private Label label_change;
        private Label label7;
        private Label label8;
        private Label label_paid;
        private Label label4;
        private Label label3;
        private Panel panel2;
        private Label label_amount_money;
        private Label label_num_product;
        private Label label_sum;
        private Button button_wait;
        private Button button_all_cancle;
        private Button button_card;
        private Button button_select_product;
        private Button button_cash;
        private Button button_mobile;
        private Label label_wait2;
        private Label label_wait3;
        private TableLayoutPanel tableLayoutPanel1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button button1;
    }
}