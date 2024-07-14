namespace POS_Project_Team2
{
    partial class ReceiptViewForm
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
            columnHeaderId = new ColumnHeader();
            columnHeaderTerminalNumber = new ColumnHeader();
            columnHeaderSlipNumber = new ColumnHeader();
            columnHeaderMerchant = new ColumnHeader();
            columnHeaderPointHolder = new ColumnHeader();
            columnHeaderBusinessNumber = new ColumnHeader();
            columnHeaderTelNumber = new ColumnHeader();
            columnHeaderAmount = new ColumnHeader();
            columnHeaderVat = new ColumnHeader();
            columnHeaderTotal = new ColumnHeader();
            columnHeaderCardName = new ColumnHeader();
            columnHeaderCardNumber = new ColumnHeader();
            columnHeaderIsInstallment = new ColumnHeader();
            columnHeaderTransactionDatetime = new ColumnHeader();
            columnHeaderApprovalNumber = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeaderId, columnHeaderTerminalNumber, columnHeaderSlipNumber, columnHeaderMerchant, columnHeaderPointHolder, columnHeaderBusinessNumber, columnHeaderTelNumber, columnHeaderAmount, columnHeaderVat, columnHeaderTotal, columnHeaderCardName, columnHeaderCardNumber, columnHeaderIsInstallment, columnHeaderTransactionDatetime, columnHeaderApprovalNumber });
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(914, 480);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeaderId
            // 
            columnHeaderId.Text = "Id";
            // 
            // columnHeaderTerminalNumber
            // 
            columnHeaderTerminalNumber.Text = "단말기 번호";
            columnHeaderTerminalNumber.Width = 100;
            // 
            // columnHeaderSlipNumber
            // 
            columnHeaderSlipNumber.Text = "전표 번호";
            columnHeaderSlipNumber.Width = 100;
            // 
            // columnHeaderMerchant
            // 
            columnHeaderMerchant.Text = "가맹점";
            columnHeaderMerchant.Width = 150;
            // 
            // columnHeaderPointHolder
            // 
            columnHeaderPointHolder.Text = "포인트 적립자";
            columnHeaderPointHolder.Width = 100;
            // 
            // columnHeaderBusinessNumber
            // 
            columnHeaderBusinessNumber.Text = "사업자 번호";
            columnHeaderBusinessNumber.Width = 120;
            // 
            // columnHeaderTelNumber
            // 
            columnHeaderTelNumber.Text = "전화번호";
            columnHeaderTelNumber.Width = 100;
            // 
            // columnHeaderAmount
            // 
            columnHeaderAmount.Text = "금액";
            columnHeaderAmount.Width = 80;
            // 
            // columnHeaderVat
            // 
            columnHeaderVat.Text = "부가세";
            columnHeaderVat.Width = 80;
            // 
            // columnHeaderTotal
            // 
            columnHeaderTotal.Text = "합계";
            columnHeaderTotal.Width = 80;
            // 
            // columnHeaderCardName
            // 
            columnHeaderCardName.Text = "카드명";
            columnHeaderCardName.Width = 100;
            // 
            // columnHeaderCardNumber
            // 
            columnHeaderCardNumber.Text = "카드번호";
            columnHeaderCardNumber.Width = 120;
            // 
            // columnHeaderIsInstallment
            // 
            columnHeaderIsInstallment.Text = "일시불 여부";
            columnHeaderIsInstallment.Width = 100;
            // 
            // columnHeaderTransactionDatetime
            // 
            columnHeaderTransactionDatetime.Text = "거래 일시";
            columnHeaderTransactionDatetime.Width = 150;
            // 
            // columnHeaderApprovalNumber
            // 
            columnHeaderApprovalNumber.Text = "승인번호";
            columnHeaderApprovalNumber.Width = 120;
            // 
            // ReceiptViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 516);
            Controls.Add(listView1);
            Name = "ReceiptViewForm";
            Text = "POS System";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeaderTerminalNumber;
        private ColumnHeader columnHeaderSlipNumber;
        private ColumnHeader columnHeaderMerchant;
        private ColumnHeader columnHeaderPointHolder;
        private ColumnHeader columnHeaderBusinessNumber;
        private ColumnHeader columnHeaderTelNumber;
        private ColumnHeader columnHeaderAmount;
        private ColumnHeader columnHeaderVat;
        private ColumnHeader columnHeaderTotal;
        private ColumnHeader columnHeaderCardName;
        private ColumnHeader columnHeaderCardNumber;
        private ColumnHeader columnHeaderIsInstallment;
        private ColumnHeader columnHeaderTransactionDatetime;
        private ColumnHeader columnHeaderApprovalNumber;
        private ColumnHeader columnHeaderId;
    }
}