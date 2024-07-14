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
            label_ic_approval = new Label();
            label_for_customer_use = new Label();
            label_terminal = new Label();
            label_store_name = new Label();
            label_earner = new Label();
            label_business_number = new Label();
            label_receipt_number = new Label();
            label_tel = new Label();
            label_separator1 = new Label();
            label_amount = new Label();
            label_vat = new Label();
            label_total = new Label();
            label_separator2 = new Label();
            table_layout_panel_amounts = new TableLayoutPanel();
            label_amount_value = new Label();
            label_vat_value = new Label();
            label_total_value = new Label();
            label_card_company = new Label();
            label_card_number = new Label();
            label_installment = new Label();
            label_payday = new Label();
            label_approval_number = new Label();
            label_approval_number_value = new Label();
            button_print = new Button();
            table_layout_panel_amounts.SuspendLayout();
            SuspendLayout();
            // 
            // label_ic_approval
            // 
            label_ic_approval.AutoSize = true;
            label_ic_approval.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_ic_approval.ForeColor = SystemColors.HotTrack;
            label_ic_approval.Location = new Point(23, 23);
            label_ic_approval.Name = "label_ic_approval";
            label_ic_approval.Size = new Size(113, 19);
            label_ic_approval.TabIndex = 0;
            label_ic_approval.Text = "IC 신용승인";
            // 
            // label_for_customer_use
            // 
            label_for_customer_use.AutoSize = true;
            label_for_customer_use.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_for_customer_use.ForeColor = SystemColors.HotTrack;
            label_for_customer_use.Location = new Point(263, 23);
            label_for_customer_use.Name = "label_for_customer_use";
            label_for_customer_use.Size = new Size(111, 19);
            label_for_customer_use.TabIndex = 1;
            label_for_customer_use.Text = "(고  객  용)";
            // 
            // label_terminal
            // 
            label_terminal.AutoSize = true;
            label_terminal.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_terminal.ForeColor = SystemColors.HotTrack;
            label_terminal.Location = new Point(23, 52);
            label_terminal.Name = "label_terminal";
            label_terminal.Size = new Size(140, 16);
            label_terminal.TabIndex = 2;
            label_terminal.Text = "단말기 : IA1594795";
            // 
            // label_store_name
            // 
            label_store_name.AutoSize = true;
            label_store_name.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_store_name.ForeColor = SystemColors.HotTrack;
            label_store_name.Location = new Point(23, 75);
            label_store_name.Name = "label_store_name";
            label_store_name.Size = new Size(134, 16);
            label_store_name.TabIndex = 3;
            label_store_name.Text = "가맹점 : 가짜문구";
            // 
            // label_earner
            // 
            label_earner.AutoSize = true;
            label_earner.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_earner.ForeColor = SystemColors.HotTrack;
            label_earner.Location = new Point(23, 99);
            label_earner.Name = "label_earner";
            label_earner.Size = new Size(171, 16);
            label_earner.TabIndex = 4;
            label_earner.Text = "포인트 적립자 : 홍길동";
            // 
            // label_business_number
            // 
            label_business_number.AutoSize = true;
            label_business_number.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_business_number.ForeColor = SystemColors.HotTrack;
            label_business_number.Location = new Point(23, 124);
            label_business_number.Name = "label_business_number";
            label_business_number.Size = new Size(204, 16);
            label_business_number.TabIndex = 5;
            label_business_number.Text = "사업자 번호 : 425-15-79797";
            // 
            // label_receipt_number
            // 
            label_receipt_number.AutoSize = true;
            label_receipt_number.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_receipt_number.ForeColor = SystemColors.HotTrack;
            label_receipt_number.Location = new Point(252, 52);
            label_receipt_number.Name = "label_receipt_number";
            label_receipt_number.Size = new Size(134, 16);
            label_receipt_number.TabIndex = 6;
            label_receipt_number.Text = "전표번호 : 020202";
            // 
            // label_tel
            // 
            label_tel.AutoSize = true;
            label_tel.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_tel.ForeColor = SystemColors.HotTrack;
            label_tel.Location = new Point(252, 124);
            label_tel.Name = "label_tel";
            label_tel.Size = new Size(138, 16);
            label_tel.TabIndex = 7;
            label_tel.Text = "TEL : 02-000-0000";
            // 
            // label_separator1
            // 
            label_separator1.AutoSize = true;
            label_separator1.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_separator1.ForeColor = SystemColors.HotTrack;
            label_separator1.Location = new Point(16, 153);
            label_separator1.Name = "label_separator1";
            label_separator1.Size = new Size(383, 16);
            label_separator1.TabIndex = 8;
            label_separator1.Text = "-----------------------------------------------";
            // 
            // label_amount
            // 
            label_amount.AutoSize = true;
            label_amount.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_amount.ForeColor = SystemColors.HotTrack;
            label_amount.Location = new Point(28, 169);
            label_amount.Name = "label_amount";
            label_amount.Size = new Size(70, 19);
            label_amount.TabIndex = 9;
            label_amount.Text = "금   액";
            // 
            // label_vat
            // 
            label_vat.AutoSize = true;
            label_vat.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_vat.ForeColor = SystemColors.HotTrack;
            label_vat.Location = new Point(28, 193);
            label_vat.Name = "label_vat";
            label_vat.Size = new Size(69, 19);
            label_vat.TabIndex = 10;
            label_vat.Text = "부가세";
            // 
            // label_total
            // 
            label_total.AutoSize = true;
            label_total.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_total.ForeColor = SystemColors.HotTrack;
            label_total.Location = new Point(28, 216);
            label_total.Name = "label_total";
            label_total.Size = new Size(70, 19);
            label_total.TabIndex = 11;
            label_total.Text = "합   계";
            // 
            // label_separator2
            // 
            label_separator2.AutoSize = true;
            label_separator2.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_separator2.ForeColor = SystemColors.HotTrack;
            label_separator2.Location = new Point(16, 235);
            label_separator2.Name = "label_separator2";
            label_separator2.Size = new Size(383, 16);
            label_separator2.TabIndex = 12;
            label_separator2.Text = "-----------------------------------------------";
            // 
            // table_layout_panel_amounts
            // 
            table_layout_panel_amounts.ColumnCount = 1;
            table_layout_panel_amounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table_layout_panel_amounts.Controls.Add(label_amount_value, 0, 0);
            table_layout_panel_amounts.Controls.Add(label_vat_value, 0, 1);
            table_layout_panel_amounts.Controls.Add(label_total_value, 0, 2);
            table_layout_panel_amounts.Location = new Point(199, 169);
            table_layout_panel_amounts.Name = "table_layout_panel_amounts";
            table_layout_panel_amounts.RowCount = 3;
            table_layout_panel_amounts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table_layout_panel_amounts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table_layout_panel_amounts.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            table_layout_panel_amounts.Size = new Size(200, 66);
            table_layout_panel_amounts.TabIndex = 13;
            // 
            // label_amount_value
            // 
            label_amount_value.Anchor = AnchorStyles.Right;
            label_amount_value.AutoSize = true;
            label_amount_value.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_amount_value.ForeColor = SystemColors.HotTrack;
            label_amount_value.Location = new Point(157, 2);
            label_amount_value.Name = "label_amount_value";
            label_amount_value.Size = new Size(40, 19);
            label_amount_value.TabIndex = 14;
            label_amount_value.Text = "0원";
            // 
            // label_vat_value
            // 
            label_vat_value.Anchor = AnchorStyles.Right;
            label_vat_value.AutoSize = true;
            label_vat_value.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_vat_value.ForeColor = SystemColors.HotTrack;
            label_vat_value.Location = new Point(157, 25);
            label_vat_value.Name = "label_vat_value";
            label_vat_value.Size = new Size(40, 19);
            label_vat_value.TabIndex = 15;
            label_vat_value.Text = "0원";
            // 
            // label_total_value
            // 
            label_total_value.Anchor = AnchorStyles.Right;
            label_total_value.AutoSize = true;
            label_total_value.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_total_value.ForeColor = SystemColors.HotTrack;
            label_total_value.Location = new Point(157, 46);
            label_total_value.Name = "label_total_value";
            label_total_value.Size = new Size(40, 19);
            label_total_value.TabIndex = 16;
            label_total_value.Text = "0원";
            // 
            // label_card_company
            // 
            label_card_company.AutoSize = true;
            label_card_company.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_card_company.ForeColor = SystemColors.HotTrack;
            label_card_company.Location = new Point(28, 259);
            label_card_company.Name = "label_card_company";
            label_card_company.Size = new Size(127, 19);
            label_card_company.TabIndex = 14;
            label_card_company.Text = "ABC비씨카드";
            // 
            // label_card_number
            // 
            label_card_number.AutoSize = true;
            label_card_number.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_card_number.ForeColor = SystemColors.HotTrack;
            label_card_number.Location = new Point(28, 282);
            label_card_number.Name = "label_card_number";
            label_card_number.Size = new Size(251, 16);
            label_card_number.TabIndex = 15;
            label_card_number.Text = "카드번호 : 1788-03**-****-****(C)";
            // 
            // label_installment
            // 
            label_installment.AutoSize = true;
            label_installment.Font = new Font("굴림", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_installment.ForeColor = SystemColors.HotTrack;
            label_installment.Location = new Point(334, 281);
            label_installment.Name = "label_installment";
            label_installment.Size = new Size(62, 17);
            label_installment.TabIndex = 16;
            label_installment.Text = "일시불";
            // 
            // label_payday
            // 
            label_payday.AutoSize = true;
            label_payday.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_payday.ForeColor = SystemColors.HotTrack;
            label_payday.Location = new Point(28, 306);
            label_payday.Name = "label_payday";
            label_payday.Size = new Size(230, 16);
            label_payday.TabIndex = 17;
            label_payday.Text = "거래일시 : 2024-07-12 00:00:00";
            // 
            // label_approval_number
            // 
            label_approval_number.AutoSize = true;
            label_approval_number.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_approval_number.ForeColor = SystemColors.HotTrack;
            label_approval_number.Location = new Point(28, 330);
            label_approval_number.Name = "label_approval_number";
            label_approval_number.Size = new Size(86, 16);
            label_approval_number.TabIndex = 18;
            label_approval_number.Text = "승인번호 : ";
            // 
            // label_approval_number_value
            // 
            label_approval_number_value.AutoSize = true;
            label_approval_number_value.Font = new Font("굴림", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_approval_number_value.ForeColor = SystemColors.HotTrack;
            label_approval_number_value.Location = new Point(111, 328);
            label_approval_number_value.Name = "label_approval_number_value";
            label_approval_number_value.Size = new Size(97, 19);
            label_approval_number_value.TabIndex = 19;
            label_approval_number_value.Text = "79794456";
            // 
            // button_print
            // 
            button_print.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button_print.ForeColor = SystemColors.ActiveCaptionText;
            button_print.Location = new Point(151, 377);
            button_print.Name = "button_print";
            button_print.Size = new Size(107, 30);
            button_print.TabIndex = 20;
            button_print.Text = "출력";
            button_print.UseVisualStyleBackColor = true;
            button_print.Click += button_print_Click;
            // 
            // ReceiptForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(418, 419);
            Controls.Add(button_print);
            Controls.Add(label_approval_number_value);
            Controls.Add(label_approval_number);
            Controls.Add(label_payday);
            Controls.Add(label_installment);
            Controls.Add(label_card_number);
            Controls.Add(label_card_company);
            Controls.Add(table_layout_panel_amounts);
            Controls.Add(label_separator2);
            Controls.Add(label_total);
            Controls.Add(label_vat);
            Controls.Add(label_amount);
            Controls.Add(label_separator1);
            Controls.Add(label_tel);
            Controls.Add(label_receipt_number);
            Controls.Add(label_business_number);
            Controls.Add(label_earner);
            Controls.Add(label_store_name);
            Controls.Add(label_terminal);
            Controls.Add(label_for_customer_use);
            Controls.Add(label_ic_approval);
            ForeColor = SystemColors.ControlLight;
            Name = "ReceiptForm";
            Text = "POS System";
            Load += ReceiptForm_Load;
            table_layout_panel_amounts.ResumeLayout(false);
            table_layout_panel_amounts.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_ic_approval;
        private Label label_for_customer_use;
        private Label label_terminal;
        private Label label_store_name;
        private Label label_earner;
        private Label label_business_number;
        private Label label_receipt_number;
        private Label label_tel;
        private Label label_separator1;
        private Label label_amount;
        private Label label_vat;
        private Label label_total;
        private Label label_separator2;
        private TableLayoutPanel table_layout_panel_amounts;
        private Label label_amount_value;
        private Label label_vat_value;
        private Label label_total_value;
        private Label label_card_company;
        private Label label_card_number;
        private Label label_installment;
        private Label label_payday;
        private Label label_approval_number;
        private Label label_approval_number_value;
        private Button button_print;

    }
}