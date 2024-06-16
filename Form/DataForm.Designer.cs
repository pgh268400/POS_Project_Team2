namespace POS_Project_Team2
{
    partial class DataForm
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
            datagridview_stock = new DataGridView();
            groupbox_current_stock = new GroupBox();
            groupbox_search = new GroupBox();
            textbox_count = new TextBox();
            button_select = new Button();
            button_search = new Button();
            textbox_search = new TextBox();
            groupBox1 = new GroupBox();
            listview_item = new ListView();
            columnHeader0 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            groupBox2 = new GroupBox();
            button_select_cancle = new Button();
            button_pay_cancle = new Button();
            button_add_into_payment = new Button();
            label_mode = new Label();
            label_tip = new Label();
            ((System.ComponentModel.ISupportInitialize)datagridview_stock).BeginInit();
            groupbox_current_stock.SuspendLayout();
            groupbox_search.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // datagridview_stock
            // 
            datagridview_stock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridview_stock.Location = new Point(23, 22);
            datagridview_stock.Name = "datagridview_stock";
            datagridview_stock.RowTemplate.Height = 25;
            datagridview_stock.Size = new Size(597, 270);
            datagridview_stock.TabIndex = 0;
            // 
            // groupbox_current_stock
            // 
            groupbox_current_stock.Controls.Add(datagridview_stock);
            groupbox_current_stock.Location = new Point(16, 126);
            groupbox_current_stock.Name = "groupbox_current_stock";
            groupbox_current_stock.Size = new Size(638, 302);
            groupbox_current_stock.TabIndex = 1;
            groupbox_current_stock.TabStop = false;
            groupbox_current_stock.Text = "현재 재고 물품";
            // 
            // groupbox_search
            // 
            groupbox_search.Controls.Add(textbox_count);
            groupbox_search.Controls.Add(button_select);
            groupbox_search.Controls.Add(button_search);
            groupbox_search.Controls.Add(textbox_search);
            groupbox_search.Location = new Point(16, 12);
            groupbox_search.Name = "groupbox_search";
            groupbox_search.Size = new Size(333, 108);
            groupbox_search.TabIndex = 2;
            groupbox_search.TabStop = false;
            groupbox_search.Text = "검색";
            // 
            // textbox_count
            // 
            textbox_count.Location = new Point(34, 67);
            textbox_count.Name = "textbox_count";
            textbox_count.PlaceholderText = "수량";
            textbox_count.Size = new Size(147, 23);
            textbox_count.TabIndex = 3;
            textbox_count.KeyDown += textbox_count_KeyDown;
            textbox_count.KeyPress += textbox_count_KeyPress;
            // 
            // button_select
            // 
            button_select.Location = new Point(206, 67);
            button_select.Name = "button_select";
            button_select.Size = new Size(75, 23);
            button_select.TabIndex = 2;
            button_select.Text = "선택하기";
            button_select.UseVisualStyleBackColor = true;
            button_select.Click += button_select_click;
            // 
            // button_search
            // 
            button_search.Location = new Point(206, 34);
            button_search.Name = "button_search";
            button_search.Size = new Size(75, 23);
            button_search.TabIndex = 1;
            button_search.Text = "검색하기";
            button_search.UseVisualStyleBackColor = true;
            button_search.Click += button_search_Click;
            // 
            // textbox_search
            // 
            textbox_search.Location = new Point(34, 34);
            textbox_search.Name = "textbox_search";
            textbox_search.PlaceholderText = "물품명";
            textbox_search.Size = new Size(147, 23);
            textbox_search.TabIndex = 0;
            textbox_search.KeyDown += textbox_search_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listview_item);
            groupBox1.Location = new Point(664, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(351, 408);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "현재 선택된 아이템 (더블 클릭시 삭제)";
            // 
            // listview_item
            // 
            listview_item.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listview_item.Location = new Point(17, 26);
            listview_item.Name = "listview_item";
            listview_item.Size = new Size(328, 372);
            listview_item.TabIndex = 0;
            listview_item.UseCompatibleStateImageBehavior = false;
            listview_item.View = View.Details;
            listview_item.MouseDoubleClick += listview_MouseDoubleClick;
            // 
            // columnHeader0
            // 
            columnHeader0.Text = "No";
            columnHeader0.Width = 40;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "상품명";
            columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "단가";
            columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "수량";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "금액";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button_select_cancle);
            groupBox2.Controls.Add(button_pay_cancle);
            groupBox2.Controls.Add(button_add_into_payment);
            groupBox2.Location = new Point(368, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(286, 100);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "기능";
            // 
            // button_select_cancle
            // 
            button_select_cancle.Location = new Point(6, 54);
            button_select_cancle.Name = "button_select_cancle";
            button_select_cancle.Size = new Size(274, 26);
            button_select_cancle.TabIndex = 2;
            button_select_cancle.Text = "선택 취소하기";
            button_select_cancle.UseVisualStyleBackColor = true;
            button_select_cancle.Click += button_select_cancle_Click;
            // 
            // button_pay_cancle
            // 
            button_pay_cancle.Location = new Point(156, 22);
            button_pay_cancle.Name = "button_pay_cancle";
            button_pay_cancle.Size = new Size(124, 26);
            button_pay_cancle.TabIndex = 1;
            button_pay_cancle.Text = "주문 취소하기";
            button_pay_cancle.UseVisualStyleBackColor = true;
            button_pay_cancle.Click += button_pay_cancle_Click;
            // 
            // button_add_into_payment
            // 
            button_add_into_payment.Location = new Point(6, 22);
            button_add_into_payment.Name = "button_add_into_payment";
            button_add_into_payment.Size = new Size(144, 26);
            button_add_into_payment.TabIndex = 0;
            button_add_into_payment.Text = "결제창 추가하기";
            button_add_into_payment.UseVisualStyleBackColor = true;
            button_add_into_payment.Click += button1_Click;
            // 
            // label_mode
            // 
            label_mode.AutoSize = true;
            label_mode.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_mode.Location = new Point(880, 438);
            label_mode.Name = "label_mode";
            label_mode.Size = new Size(135, 15);
            label_mode.TabIndex = 5;
            label_mode.Text = "* 현재 선택 모드입니다.";
            // 
            // label_tip
            // 
            label_tip.AutoSize = true;
            label_tip.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_tip.ForeColor = Color.Red;
            label_tip.Location = new Point(16, 436);
            label_tip.Name = "label_tip";
            label_tip.Size = new Size(368, 17);
            label_tip.TabIndex = 6;
            label_tip.Text = "결제할 물건 선택 완료시 결제창 추가하기 버튼을 눌러주세요";
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1027, 462);
            Controls.Add(label_tip);
            Controls.Add(label_mode);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupbox_search);
            Controls.Add(groupbox_current_stock);
            Name = "DataForm";
            Text = "POS System";
            Load += DataForm_Load;
            ((System.ComponentModel.ISupportInitialize)datagridview_stock).EndInit();
            groupbox_current_stock.ResumeLayout(false);
            groupbox_search.ResumeLayout(false);
            groupbox_search.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView datagridview_stock;
        private GroupBox groupbox_current_stock;
        private GroupBox groupbox_search;
        private TextBox textbox_search;
        private Button button_select;
        private Button button_search;
        private TextBox textbox_count;
        private GroupBox groupBox1;
        private ListView listview_item;
        private GroupBox groupBox2;
        private Button button_pay_cancle;
        private Button button_add_into_payment;
        private Label label_mode;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader0;
        private Label label_tip;
        private Button button_select_cancle;
    }
}