namespace SupplementMall
{
    partial class FrmCustomer
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLogOut = new System.Windows.Forms.LinkLabel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblUName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::SupplementMall.Properties.Resources.btnsave;
            this.btnSave.Location = new System.Drawing.Point(229, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLogOut
            // 
            this.lblLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.Location = new System.Drawing.Point(440, 9);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(43, 13);
            this.lblLogOut.TabIndex = 10;
            this.lblLogOut.TabStop = true;
            this.lblLogOut.Text = "Log out";
            this.lblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLogOut_LinkClicked);
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPhone.Location = new System.Drawing.Point(138, 191);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(274, 27);
            this.txtPhone.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Location = new System.Drawing.Point(138, 148);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(274, 27);
            this.txtName.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPhone.Location = new System.Drawing.Point(73, 194);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 19);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone";
            // 
            // lblUName
            // 
            this.lblUName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUName.AutoSize = true;
            this.lblUName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblUName.Location = new System.Drawing.Point(73, 151);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(50, 19);
            this.lblUName.TabIndex = 0;
            this.lblUName.Text = "Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::SupplementMall.Properties.Resources.btncancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 507);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblDate.Location = new System.Drawing.Point(73, 238);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 19);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtDate.Location = new System.Drawing.Point(138, 232);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(274, 27);
            this.dtDate.TabIndex = 7;
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SupplementMall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(497, 544);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblUName);
            this.MinimumSize = new System.Drawing.Size(513, 583);
            this.Name = "FrmCustomer";
            this.Text = "Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lblLogOut;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtDate;
    }
}