using System.Drawing;

namespace SupplementMall
{
    partial class FrmAdminPanel
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
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.lblLogOut = new System.Windows.Forms.LinkLabel();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsers
            // 
            this.btnUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Image = global::SupplementMall.Properties.Resources.btnusers;
            this.btnUsers.Location = new System.Drawing.Point(130, 146);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(247, 35);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Image = global::SupplementMall.Properties.Resources.btncustomers;
            this.btnCustomers.Location = new System.Drawing.Point(130, 203);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(247, 35);
            this.btnCustomers.TabIndex = 1;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Image = global::SupplementMall.Properties.Resources.btnaddcustomer;
            this.btnAddCustomer.Location = new System.Drawing.Point(130, 260);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(247, 35);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // lblLogOut
            // 
            this.lblLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.BackColor = System.Drawing.Color.Transparent;
            this.lblLogOut.Location = new System.Drawing.Point(442, 9);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(43, 13);
            this.lblLogOut.TabIndex = 4;
            this.lblLogOut.TabStop = true;
            this.lblLogOut.Text = "Log out";
            this.lblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLogOut_LinkClicked);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAccount.Image = global::SupplementMall.Properties.Resources.btneditaccount;
            this.btnEditAccount.Location = new System.Drawing.Point(130, 317);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(247, 35);
            this.btnEditAccount.TabIndex = 3;
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // FrmAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SupplementMall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(497, 544);
            this.Controls.Add(this.btnEditAccount);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnUsers);
            this.MinimumSize = new System.Drawing.Size(513, 583);
            this.Name = "FrmAdminPanel";
            this.Text = "Admin Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.LinkLabel lblLogOut;
        private System.Windows.Forms.Button btnEditAccount;
    }
}