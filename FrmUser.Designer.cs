using System.Drawing;

namespace SupplementMall
{
    partial class FrmUser
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
            this.lblUName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.rbtnAdmin = new System.Windows.Forms.RadioButton();
            this.rbtnUser = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLogOut = new System.Windows.Forms.LinkLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUName
            // 
            this.lblUName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUName.AutoSize = true;
            this.lblUName.BackColor = System.Drawing.Color.Transparent;
            this.lblUName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblUName.Location = new System.Drawing.Point(111, 135);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(50, 19);
            this.lblUName.TabIndex = 0;
            this.lblUName.Text = "Name";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblUserName.Location = new System.Drawing.Point(111, 173);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(82, 19);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "UserName";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPassword.Location = new System.Drawing.Point(111, 211);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(76, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblEmail.Location = new System.Drawing.Point(111, 249);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 19);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // lblType
            // 
            this.lblType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblType.Location = new System.Drawing.Point(111, 291);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 19);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Location = new System.Drawing.Point(199, 132);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(179, 27);
            this.txtName.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtUserName.Location = new System.Drawing.Point(199, 170);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(179, 27);
            this.txtUserName.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPassword.Location = new System.Drawing.Point(199, 208);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(179, 27);
            this.txtPassword.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtEmail.Location = new System.Drawing.Point(199, 246);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(179, 27);
            this.txtEmail.TabIndex = 7;
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.AutoSize = true;
            this.rbtnAdmin.Checked = true;
            this.rbtnAdmin.Location = new System.Drawing.Point(3, 3);
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Size = new System.Drawing.Size(74, 23);
            this.rbtnAdmin.TabIndex = 9;
            this.rbtnAdmin.TabStop = true;
            this.rbtnAdmin.Text = "Admin";
            this.rbtnAdmin.UseVisualStyleBackColor = true;
            // 
            // rbtnUser
            // 
            this.rbtnUser.AutoSize = true;
            this.rbtnUser.Location = new System.Drawing.Point(94, 3);
            this.rbtnUser.Name = "rbtnUser";
            this.rbtnUser.Size = new System.Drawing.Size(59, 23);
            this.rbtnUser.TabIndex = 10;
            this.rbtnUser.Text = "User";
            this.rbtnUser.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.rbtnAdmin);
            this.panel1.Controls.Add(this.rbtnUser);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.panel1.Location = new System.Drawing.Point(199, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 31);
            this.panel1.TabIndex = 10;
            // 
            // lblLogOut
            // 
            this.lblLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.BackColor = System.Drawing.Color.Transparent;
            this.lblLogOut.Location = new System.Drawing.Point(442, 9);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(43, 13);
            this.lblLogOut.TabIndex = 13;
            this.lblLogOut.TabStop = true;
            this.lblLogOut.Text = "Log out";
            this.lblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLogOut_LinkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::SupplementMall.Properties.Resources.btncancel;
            this.btnCancel.Location = new System.Drawing.Point(359, 504);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::SupplementMall.Properties.Resources.btnsave;
            this.btnSave.Location = new System.Drawing.Point(227, 504);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 28);
            this.btnSave.TabIndex = 11;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += btnSave_Click;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SupplementMall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(497, 544);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUName);
            this.MinimumSize = new System.Drawing.Size(513, 583);
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.RadioButton rbtnAdmin;
        private System.Windows.Forms.RadioButton rbtnUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lblLogOut;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}