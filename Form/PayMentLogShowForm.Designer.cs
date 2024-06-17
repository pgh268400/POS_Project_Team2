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
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            button_refresh = new Button();
            label_recepit = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(622, 426);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
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
            // button_refresh
            // 
            button_refresh.Location = new Point(540, 444);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(94, 29);
            button_refresh.TabIndex = 1;
            button_refresh.Text = "새로고침";
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // label_recepit
            // 
            label_recepit.AutoSize = true;
            label_recepit.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_recepit.Location = new Point(12, 448);
            label_recepit.Name = "label_recepit";
            label_recepit.Size = new Size(51, 20);
            label_recepit.TabIndex = 2;
            label_recepit.Text = "Hello!";
            // 
            // PayMentLogShowForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 486);
            Controls.Add(label_recepit);
            Controls.Add(button_refresh);
            Controls.Add(listView1);
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
        private Button button_refresh;
        private Label label_recepit;
    }
}