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
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            CountText = new TextBox();
            SelectBtn = new Button();
            SearchBtn = new Button();
            SearchText = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(676, 270);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(22, 144);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(741, 302);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "현재 재고 물품";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(CountText);
            groupBox2.Controls.Add(SelectBtn);
            groupBox2.Controls.Add(SearchBtn);
            groupBox2.Controls.Add(SearchText);
            groupBox2.Location = new Point(22, 30);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(333, 108);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "검색";
            // 
            // CountText
            // 
            CountText.Location = new Point(34, 67);
            CountText.Name = "CountText";
            CountText.Size = new Size(100, 23);
            CountText.TabIndex = 3;
            // 
            // SelectBtn
            // 
            SelectBtn.Location = new Point(206, 67);
            SelectBtn.Name = "SelectBtn";
            SelectBtn.Size = new Size(75, 23);
            SelectBtn.TabIndex = 2;
            SelectBtn.Text = "선택하기";
            SelectBtn.UseVisualStyleBackColor = true;
            SelectBtn.Click += SelectBtn_Click;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(206, 34);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(75, 23);
            SearchBtn.TabIndex = 1;
            SearchBtn.Text = "검색하기";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // SearchText
            // 
            SearchText.Location = new Point(34, 34);
            SearchText.Name = "SearchText";
            SearchText.Size = new Size(100, 23);
            SearchText.TabIndex = 0;
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "DataForm";
            Text = "DataForm";
            Load += DataForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox SearchText;
        private Button SelectBtn;
        private Button SearchBtn;
        private TextBox CountText;
    }
}