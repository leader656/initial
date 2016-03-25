using System.Windows.Forms;

namespace SupplementMall
{
    partial class FrmCustomers
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
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblAllowedPeriod = new System.Windows.Forms.Label();
            this.cmboSearch = new System.Windows.Forms.ComboBox();
            this.cmboPeriod = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblLogOut = new System.Windows.Forms.LinkLabel();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.picWaitingAnimation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWaitingAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CustomerName,
            this.Phone,
            this.Product,
            this.Date});
            this.dgvCustomers.Location = new System.Drawing.Point(2, 118);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(495, 340);
            this.dgvCustomers.TabIndex = 7;
            this.dgvCustomers.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomers_CellMouseClick);
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.Frozen = true;
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 150;
            // 
            // Phone
            // 
            this.Phone.Frozen = true;
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 70;
            // 
            // Product
            // 
            this.Product.Frozen = true;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 70;
            // 
            // Date
            // 
            this.Date.Frozen = true;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 160;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(13, 55);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search : ";
            // 
            // lblAllowedPeriod
            // 
            this.lblAllowedPeriod.AutoSize = true;
            this.lblAllowedPeriod.Location = new System.Drawing.Point(13, 23);
            this.lblAllowedPeriod.Name = "lblAllowedPeriod";
            this.lblAllowedPeriod.Size = new System.Drawing.Size(181, 13);
            this.lblAllowedPeriod.TabIndex = 0;
            this.lblAllowedPeriod.Text = "Allow Customer to buy again after : ";
            // 
            // cmboSearch
            // 
            this.cmboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSearch.FormattingEnabled = true;
            this.cmboSearch.Items.AddRange(new object[] {
            "Name",
            "Phone",
            "Product",
            "Date"});
            this.cmboSearch.Location = new System.Drawing.Point(69, 52);
            this.cmboSearch.Name = "cmboSearch";
            this.cmboSearch.Size = new System.Drawing.Size(97, 21);
            this.cmboSearch.TabIndex = 3;
            this.cmboSearch.SelectedIndexChanged += new System.EventHandler(this.cmboSearch_SelectedIndexChanged);
            // 
            // cmboPeriod
            // 
            this.cmboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboPeriod.FormattingEnabled = true;
            this.cmboPeriod.Items.AddRange(new object[] {
            "1 month",
            "3 month",
            "6 month",
            "1 year"});
            this.cmboPeriod.Location = new System.Drawing.Point(221, 20);
            this.cmboPeriod.Name = "cmboPeriod";
            this.cmboPeriod.Size = new System.Drawing.Size(97, 21);
            this.cmboPeriod.TabIndex = 1;
            this.cmboPeriod.SelectedIndexChanged += new System.EventHandler(this.cmboPeriod_SelectedIndexChanged);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(172, 55);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(43, 13);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Value : ";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(221, 52);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(164, 20);
            this.txtValue.TabIndex = 5;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Location = new System.Drawing.Point(221, 52);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(200, 20);
            this.dtDateFrom.TabIndex = 5;
            this.dtDateFrom.Visible = false;
            // 
            // dtDateTo
            // 
            this.dtDateTo.Location = new System.Drawing.Point(221, 78);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(200, 20);
            this.dtDateTo.TabIndex = 7;
            this.dtDateTo.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(172, 82);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 13);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To : ";
            this.lblTo.Visible = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(438, 50);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(47, 23);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(410, 474);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblLogOut
            // 
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.Location = new System.Drawing.Point(442, 9);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(43, 13);
            this.lblLogOut.TabIndex = 13;
            this.lblLogOut.TabStop = true;
            this.lblLogOut.Text = "Log out";
            this.lblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLogOut_LinkClicked);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(329, 474);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnAddCustomer.TabIndex = 11;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(438, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Tahoma", 7F);
            this.lblNote.Location = new System.Drawing.Point(13, 463);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(156, 12);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "* Right click on a row for options";
            // 
            // picWaitingAnimation
            // 
            this.picWaitingAnimation.Location = new System.Drawing.Point(12, 90);
            this.picWaitingAnimation.Name = "picWaitingAnimation";
            this.picWaitingAnimation.Size = new System.Drawing.Size(22, 22);
            this.picWaitingAnimation.TabIndex = 14;
            this.picWaitingAnimation.TabStop = false;
            // 
            // FrmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 509);
            this.Controls.Add(this.picWaitingAnimation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.cmboPeriod);
            this.Controls.Add(this.lblAllowedPeriod);
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.dtDateFrom);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.cmboSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.lblNote);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(513, 548);
            this.MinimumSize = new System.Drawing.Size(513, 548);
            this.Name = "FrmCustomers";
            this.Text = "FrmCustomers";
            this.Load += new System.EventHandler(this.FrmCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWaitingAnimation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn UName;
        private System.Windows.Forms.Label lblAllowedPeriod;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmboSearch;
        private System.Windows.Forms.ComboBox cmboPeriod;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.LinkLabel lblLogOut;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNote;
        private PictureBox picWaitingAnimation;
    }
}