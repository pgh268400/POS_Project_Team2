namespace POS_Project_Team2
{
    partial class PayMentLogShowForm
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
            listView1 = new ListView();
            columnHeader0 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            label_show = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listView1.Location = new Point(9, 9);
            listView1.Margin = new Padding(2);
            listView1.Name = "listView1";
            listView1.Size = new Size(575, 416);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader0
            // 
            columnHeader0.Text = "결제 시간";
            columnHeader0.Width = 110;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "물품명";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "단가";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "개수";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "총 가격";
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "적립자";
            columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "전화번호";
            columnHeader6.Width = 80;
            // 
            // label_show
            // 
            label_show.AutoSize = true;
            label_show.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_show.Location = new Point(11, 436);
            label_show.Margin = new Padding(2, 0, 2, 0);
            label_show.Name = "label_show";
            label_show.Size = new Size(40, 15);
            label_show.TabIndex = 2;
            label_show.Text = "Hello!";
            // 
            // PayMentLogShowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 462);
            Controls.Add(label_show);
            Controls.Add(listView1);
            Margin = new Padding(2);
            Name = "PayMentLogShowForm";
            Text = "POS System";
            Load += PayMentLogShowForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Label label_show;
        private ColumnHeader columnHeader0;
    }
}