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
            datagridview = new DataGridView();
            groupbox_current_stock = new GroupBox();
            groupbox_search = new GroupBox();
            textbox_count = new TextBox();
            button_select = new Button();
            button_search = new Button();
            textbox_search = new TextBox();
            ((System.ComponentModel.ISupportInitialize)datagridview).BeginInit();
            groupbox_current_stock.SuspendLayout();
            groupbox_search.SuspendLayout();
            SuspendLayout();
            // 
            // datagridview
            // 
            datagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridview.Location = new Point(23, 22);
            datagridview.Name = "datagridview";
            datagridview.RowTemplate.Height = 25;
            datagridview.Size = new Size(676, 270);
            datagridview.TabIndex = 0;
            // 
            // groupbox_current_stock
            // 
            groupbox_current_stock.Controls.Add(datagridview);
            groupbox_current_stock.Location = new Point(16, 126);
            groupbox_current_stock.Name = "groupbox_current_stock";
            groupbox_current_stock.Size = new Size(741, 302);
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
            // 
            // button_select
            // 
            button_select.Location = new Point(206, 67);
            button_select.Name = "button_select";
            button_select.Size = new Size(75, 23);
            button_select.TabIndex = 2;
            button_select.Text = "선택하기";
            button_select.UseVisualStyleBackColor = true;
            button_select.Click += SelectBtn_Click;
            // 
            // button_search
            // 
            button_search.Location = new Point(206, 34);
            button_search.Name = "button_search";
            button_search.Size = new Size(75, 23);
            button_search.TabIndex = 1;
            button_search.Text = "검색하기";
            button_search.UseVisualStyleBackColor = true;
            button_search.Click += SearchBtn_Click;
            // 
            // textbox_search
            // 
            textbox_search.Location = new Point(34, 34);
            textbox_search.Name = "textbox_search";
            textbox_search.PlaceholderText = "물품명";
            textbox_search.Size = new Size(147, 23);
            textbox_search.TabIndex = 0;
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupbox_search);
            Controls.Add(groupbox_current_stock);
            Name = "DataForm";
            Text = "DataForm";
            Load += DataForm_Load;
            ((System.ComponentModel.ISupportInitialize)datagridview).EndInit();
            groupbox_current_stock.ResumeLayout(false);
            groupbox_search.ResumeLayout(false);
            groupbox_search.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView datagridview;
        private GroupBox groupbox_current_stock;
        private GroupBox groupbox_search;
        private TextBox textbox_search;
        private Button button_select;
        private Button button_search;
        private TextBox textbox_count;
    }
}