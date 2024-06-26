﻿namespace POS_Project_Team2
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
            button_get_receipt = new Button();
            button_get_stock = new Button();
            button_get_tpt = new Button();
            group_get = new GroupBox();
            button_get_refund = new Button();
            button_payment = new Button();
            group_main = new GroupBox();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label_total_previous_payment = new Label();
            label_total_previous_purchase = new Label();
            button_receipt = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label_total_num_profit = new Label();
            label_total_num_refund = new Label();
            label_tatal_num_sales = new Label();
            group_etc = new GroupBox();
            button_wait3 = new Button();
            button_wait2 = new Button();
            button_wait1 = new Button();
            button_refund = new Button();
            picture_box_alarm = new PictureBox();
            picture_box_menu = new PictureBox();
            realtime_timer = new System.Windows.Forms.Timer(components);
            picture_box_top = new PictureBox();
            button_clear_all = new Button();
            group_get.SuspendLayout();
            group_main.SuspendLayout();
            groupBox3.SuspendLayout();
            group_etc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_box_alarm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_box_menu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_box_top).BeginInit();
            SuspendLayout();
            // 
            // label_realtime_clock
            // 
            label_realtime_clock.AutoSize = true;
            label_realtime_clock.Location = new Point(20, 282);
            label_realtime_clock.Name = "label_realtime_clock";
            label_realtime_clock.Size = new Size(103, 19);
            label_realtime_clock.TabIndex = 0;
            label_realtime_clock.Text = "현재 날짜 시간";
            // 
            // button_get_all
            // 
            button_get_all.BackColor = Color.ForestGreen;
            button_get_all.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point);
            button_get_all.ForeColor = Color.White;
            button_get_all.Location = new Point(20, 25);
            button_get_all.Name = "button_get_all";
            button_get_all.Size = new Size(231, 77);
            button_get_all.TabIndex = 1;
            button_get_all.Text = "통합 조회";
            button_get_all.UseVisualStyleBackColor = false;
            button_get_all.Click += button_get_all_Click;
            // 
            // button_get_receipt
            // 
            button_get_receipt.BackColor = SystemColors.WindowFrame;
            button_get_receipt.ForeColor = SystemColors.ControlLightLight;
            button_get_receipt.Location = new Point(252, 66);
            button_get_receipt.Name = "button_get_receipt";
            button_get_receipt.Size = new Size(121, 57);
            button_get_receipt.TabIndex = 3;
            button_get_receipt.Text = "영수증 조회";
            button_get_receipt.UseVisualStyleBackColor = false;
            // 
            // button_get_stock
            // 
            button_get_stock.BackColor = SystemColors.WindowFrame;
            button_get_stock.ForeColor = SystemColors.ControlLightLight;
            button_get_stock.Location = new Point(20, 108);
            button_get_stock.Name = "button_get_stock";
            button_get_stock.Size = new Size(112, 116);
            button_get_stock.TabIndex = 4;
            button_get_stock.Text = "재고 조회";
            button_get_stock.UseVisualStyleBackColor = false;
            button_get_stock.Click += button_get_stock_Click;
            // 
            // button_get_tpt
            // 
            button_get_tpt.BackColor = SystemColors.WindowFrame;
            button_get_tpt.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button_get_tpt.ForeColor = SystemColors.ControlLightLight;
            button_get_tpt.Location = new Point(138, 108);
            button_get_tpt.Name = "button_get_tpt";
            button_get_tpt.Size = new Size(113, 59);
            button_get_tpt.TabIndex = 5;
            button_get_tpt.Text = "총 결제\r\n내역 조회";
            button_get_tpt.UseVisualStyleBackColor = false;
            button_get_tpt.Click += button_get_tpt_Click;
            // 
            // group_get
            // 
            group_get.Controls.Add(button_get_refund);
            group_get.Controls.Add(button_get_all);
            group_get.Controls.Add(button_get_tpt);
            group_get.Controls.Add(button_get_stock);
            group_get.Controls.Add(label_realtime_clock);
            group_get.Location = new Point(24, 67);
            group_get.Name = "group_get";
            group_get.Size = new Size(275, 318);
            group_get.TabIndex = 6;
            group_get.TabStop = false;
            group_get.Text = "조회";
            // 
            // button_get_refund
            // 
            button_get_refund.BackColor = SystemColors.WindowFrame;
            button_get_refund.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button_get_refund.ForeColor = SystemColors.ControlLightLight;
            button_get_refund.Location = new Point(138, 171);
            button_get_refund.Name = "button_get_refund";
            button_get_refund.Size = new Size(113, 53);
            button_get_refund.TabIndex = 6;
            button_get_refund.Text = "환불 내역 조회";
            button_get_refund.UseVisualStyleBackColor = false;
            button_get_refund.Click += button_get_refund_Click;
            // 
            // button_payment
            // 
            button_payment.BackColor = Color.BlueViolet;
            button_payment.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button_payment.ForeColor = SystemColors.Window;
            button_payment.Location = new Point(15, 24);
            button_payment.Name = "button_payment";
            button_payment.Size = new Size(178, 81);
            button_payment.TabIndex = 7;
            button_payment.Text = "결제";
            button_payment.UseVisualStyleBackColor = false;
            button_payment.Click += button6_Click;
            // 
            // group_main
            // 
            group_main.Controls.Add(groupBox3);
            group_main.Controls.Add(label_total_num_profit);
            group_main.Controls.Add(label_total_num_refund);
            group_main.Controls.Add(label_tatal_num_sales);
            group_main.Controls.Add(button_payment);
            group_main.Location = new Point(317, 67);
            group_main.Name = "group_main";
            group_main.Size = new Size(413, 318);
            group_main.TabIndex = 9;
            group_main.TabStop = false;
            group_main.Text = "메인";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label_total_previous_payment);
            groupBox3.Controls.Add(button_get_receipt);
            groupBox3.Controls.Add(label_total_previous_purchase);
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
            label9.Location = new Point(179, 104);
            label9.Name = "label9";
            label9.Size = new Size(31, 19);
            label9.TabIndex = 18;
            label9.Text = "0원";
            // 
            // label_total_previous_payment
            // 
            label_total_previous_payment.AutoSize = true;
            label_total_previous_payment.Location = new Point(179, 78);
            label_total_previous_payment.Name = "label_total_previous_payment";
            label_total_previous_payment.Size = new Size(31, 19);
            label_total_previous_payment.TabIndex = 17;
            label_total_previous_payment.Text = "0원";
            // 
            // label_total_previous_purchase
            // 
            label_total_previous_purchase.AutoSize = true;
            label_total_previous_purchase.Location = new Point(179, 54);
            label_total_previous_purchase.Name = "label_total_previous_purchase";
            label_total_previous_purchase.Size = new Size(31, 19);
            label_total_previous_purchase.TabIndex = 16;
            label_total_previous_purchase.Text = "0원";
            // 
            // button_receipt
            // 
            button_receipt.BackColor = Color.LightGray;
            button_receipt.Location = new Point(252, 19);
            button_receipt.Name = "button_receipt";
            button_receipt.Size = new Size(121, 41);
            button_receipt.TabIndex = 15;
            button_receipt.Text = "영수증 출력";
            button_receipt.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 104);
            label6.Name = "label6";
            label6.Size = new Size(65, 19);
            label6.TabIndex = 14;
            label6.Text = "거스름돈";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 78);
            label5.Name = "label5";
            label5.Size = new Size(70, 19);
            label5.TabIndex = 13;
            label5.Text = "결제 금액";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 54);
            label4.Name = "label4";
            label4.Size = new Size(70, 19);
            label4.TabIndex = 12;
            label4.Text = "총 구매액";
            // 
            // label_total_num_profit
            // 
            label_total_num_profit.AutoSize = true;
            label_total_num_profit.Location = new Point(214, 59);
            label_total_num_profit.Name = "label_total_num_profit";
            label_total_num_profit.Size = new Size(116, 19);
            label_total_num_profit.TabIndex = 10;
            label_total_num_profit.Text = "금일 총 수익 0원";
            // 
            // label_total_num_refund
            // 
            label_total_num_refund.AutoSize = true;
            label_total_num_refund.Location = new Point(214, 56);
            label_total_num_refund.Name = "label_total_num_refund";
            label_total_num_refund.Size = new Size(0, 19);
            label_total_num_refund.TabIndex = 9;
            // 
            // label_tatal_num_sales
            // 
            label_tatal_num_sales.AutoSize = true;
            label_tatal_num_sales.Location = new Point(214, 37);
            label_tatal_num_sales.Name = "label_tatal_num_sales";
            label_tatal_num_sales.Size = new Size(116, 19);
            label_tatal_num_sales.TabIndex = 8;
            label_tatal_num_sales.Text = "금일 총 판매 0건";
            // 
            // group_etc
            // 
            group_etc.Controls.Add(button_wait3);
            group_etc.Controls.Add(button_wait2);
            group_etc.Controls.Add(button_wait1);
            group_etc.Controls.Add(button_refund);
            group_etc.Location = new Point(736, 67);
            group_etc.Name = "group_etc";
            group_etc.Size = new Size(264, 318);
            group_etc.TabIndex = 10;
            group_etc.TabStop = false;
            group_etc.Text = "기타";
            // 
            // button_wait3
            // 
            button_wait3.BackColor = SystemColors.WindowFrame;
            button_wait3.Enabled = false;
            button_wait3.ForeColor = SystemColors.ControlLightLight;
            button_wait3.Location = new Point(15, 120);
            button_wait3.Name = "button_wait3";
            button_wait3.Size = new Size(243, 45);
            button_wait3.TabIndex = 8;
            button_wait3.Text = "대기열 3";
            button_wait3.UseVisualStyleBackColor = false;
            button_wait3.Click += button_wait3_Click;
            // 
            // button_wait2
            // 
            button_wait2.BackColor = SystemColors.WindowFrame;
            button_wait2.Enabled = false;
            button_wait2.ForeColor = SystemColors.ControlLightLight;
            button_wait2.Location = new Point(15, 72);
            button_wait2.Name = "button_wait2";
            button_wait2.Size = new Size(243, 45);
            button_wait2.TabIndex = 7;
            button_wait2.Text = "대기열 2";
            button_wait2.UseVisualStyleBackColor = false;
            button_wait2.Click += button2_Click;
            // 
            // button_wait1
            // 
            button_wait1.BackColor = SystemColors.WindowFrame;
            button_wait1.ForeColor = SystemColors.ControlLightLight;
            button_wait1.Location = new Point(15, 25);
            button_wait1.Name = "button_wait1";
            button_wait1.Size = new Size(243, 45);
            button_wait1.TabIndex = 6;
            button_wait1.Text = "대기열 1";
            button_wait1.UseVisualStyleBackColor = false;
            button_wait1.Click += button_wait1_Click;
            // 
            // button_refund
            // 
            button_refund.BackColor = Color.Red;
            button_refund.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button_refund.ForeColor = SystemColors.Window;
            button_refund.Location = new Point(15, 172);
            button_refund.Name = "button_refund";
            button_refund.Size = new Size(243, 112);
            button_refund.TabIndex = 1;
            button_refund.Text = "환불";
            button_refund.UseVisualStyleBackColor = false;
            button_refund.Click += button_refund_Click;
            // 
            // picture_box_alarm
            // 
            picture_box_alarm.BackColor = Color.Transparent;
            picture_box_alarm.Image = Properties.Resources.alarm_white;
            picture_box_alarm.Location = new Point(920, 7);
            picture_box_alarm.Name = "picture_box_alarm";
            picture_box_alarm.Size = new Size(37, 39);
            picture_box_alarm.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_box_alarm.TabIndex = 11;
            picture_box_alarm.TabStop = false;
            // 
            // picture_box_menu
            // 
            picture_box_menu.Image = Properties.Resources.menu_white;
            picture_box_menu.Location = new Point(963, 7);
            picture_box_menu.Name = "picture_box_menu";
            picture_box_menu.Size = new Size(37, 39);
            picture_box_menu.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_box_menu.TabIndex = 13;
            picture_box_menu.TabStop = false;
            // 
            // realtime_timer
            // 
            realtime_timer.Interval = 1000;
            // 
            // picture_box_top
            // 
            picture_box_top.Image = Properties.Resources.kwangwoon_top;
            picture_box_top.Location = new Point(0, -1);
            picture_box_top.Name = "picture_box_top";
            picture_box_top.Size = new Size(1016, 53);
            picture_box_top.TabIndex = 15;
            picture_box_top.TabStop = false;
            // 
            // button_clear_all
            // 
            button_clear_all.BackColor = Color.Red;
            button_clear_all.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button_clear_all.ForeColor = SystemColors.Window;
            button_clear_all.Location = new Point(44, 297);
            button_clear_all.Name = "button_clear_all";
            button_clear_all.Size = new Size(231, 48);
            button_clear_all.TabIndex = 9;
            button_clear_all.Text = "모든 기록 삭제";
            button_clear_all.UseVisualStyleBackColor = false;
            button_clear_all.Click += button_clear_all_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1016, 398);
            Controls.Add(button_clear_all);
            Controls.Add(picture_box_menu);
            Controls.Add(picture_box_alarm);
            Controls.Add(picture_box_top);
            Controls.Add(group_etc);
            Controls.Add(group_main);
            Controls.Add(group_get);
            Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlText;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "POS System";
            Load += MainForm_Load;
            group_get.ResumeLayout(false);
            group_get.PerformLayout();
            group_main.ResumeLayout(false);
            group_main.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            group_etc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picture_box_alarm).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_box_menu).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_box_top).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label_realtime_clock;
        private Button button_get_all;
        private Button button_get_receipt;
        private Button button_get_stock;
        private Button button_get_tpt;
        private GroupBox group_get;
        private Button button_payment;
        private GroupBox group_main;
        private GroupBox groupBox3;
        private Label label_total_num_profit;
        private Label label_total_num_refund;
        private Label label_tatal_num_sales;
        private Button button_receipt;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private Label label_total_previous_payment;
        private Label label_total_previous_purchase;
        private GroupBox group_etc;
        private Button button_refund;
        private PictureBox picture_box_alarm;
        private PictureBox picture_box_menu;
        private System.Windows.Forms.Timer realtime_timer;
        private PictureBox picture_box_top;
        private Button button3;
        private Button button2;
        private Button button_get_refund;
        private Button button_clear_all;

        private Button button_wait1;
        private Button button_wait2;
        private Button button_wait3;
    }
}