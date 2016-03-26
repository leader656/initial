using System.Drawing;
using System.Windows.Forms;

namespace SupplementMall
{
    partial class FrmAddCustomer
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
            this.components = new System.ComponentModel.Container();
            this.btnStartDevice = new System.Windows.Forms.Button();
            this.timerFinger = new System.Windows.Forms.Timer(this.components);
            this.btnNext = new System.Windows.Forms.Button();
            this.lblDeviceStatus = new System.Windows.Forms.Label();
            this.lblDeviceStatusInfo = new System.Windows.Forms.Label();
            this.lblLogOut = new System.Windows.Forms.LinkLabel();
            this.btnBack = new System.Windows.Forms.Button();
            this.picWaitingAnimation = new System.Windows.Forms.PictureBox();
            this.picFingerPrint = new System.Windows.Forms.PictureBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblCountInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picWaitingAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartDevice
            // 
            this.btnStartDevice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartDevice.Location = new System.Drawing.Point(185, 383);
            this.btnStartDevice.Name = "btnStartDevice";
            this.btnStartDevice.Size = new System.Drawing.Size(125, 25);
            this.btnStartDevice.TabIndex = 2;
            this.btnStartDevice.UseVisualStyleBackColor = true;
            this.btnStartDevice.Click += new System.EventHandler(this.btnStartDevice_Click);
            // 
            // timerFinger
            // 
            this.timerFinger.Interval = 200;
            this.timerFinger.Tick += new System.EventHandler(this.timerFinger_Tick);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(229, 507);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(125, 25);
            this.btnNext.TabIndex = 3;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblDeviceStatus
            // 
            this.lblDeviceStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDeviceStatus.AutoSize = true;
            this.lblDeviceStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblDeviceStatus.Location = new System.Drawing.Point(122, 329);
            this.lblDeviceStatus.Name = "lblDeviceStatus";
            this.lblDeviceStatus.Size = new System.Drawing.Size(83, 13);
            this.lblDeviceStatus.TabIndex = 0;
            this.lblDeviceStatus.Text = "Device Status : ";
            // 
            // lblDeviceStatusInfo
            // 
            this.lblDeviceStatusInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDeviceStatusInfo.AutoSize = true;
            this.lblDeviceStatusInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblDeviceStatusInfo.Location = new System.Drawing.Point(205, 329);
            this.lblDeviceStatusInfo.Name = "lblDeviceStatusInfo";
            this.lblDeviceStatusInfo.Size = new System.Drawing.Size(0, 13);
            this.lblDeviceStatusInfo.TabIndex = 1;
            // 
            // lblLogOut
            // 
            this.lblLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.BackColor = System.Drawing.Color.Transparent;
            this.lblLogOut.Location = new System.Drawing.Point(442, 9);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(43, 13);
            this.lblLogOut.TabIndex = 5;
            this.lblLogOut.TabStop = true;
            this.lblLogOut.Text = "Log out";
            this.lblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLogOut_LinkClicked);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(360, 507);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 25);
            this.btnBack.TabIndex = 4;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // picWaitingAnimation
            // 
            this.picWaitingAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picWaitingAnimation.BackColor = System.Drawing.Color.Transparent;
            this.picWaitingAnimation.Location = new System.Drawing.Point(201, 508);
            this.picWaitingAnimation.Name = "picWaitingAnimation";
            this.picWaitingAnimation.Size = new System.Drawing.Size(22, 22);
            this.picWaitingAnimation.TabIndex = 7;
            this.picWaitingAnimation.TabStop = false;
            // 
            // picFingerPrint
            // 
            this.picFingerPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picFingerPrint.BackColor = System.Drawing.Color.Transparent;
            this.picFingerPrint.Location = new System.Drawing.Point(125, 38);
            this.picFingerPrint.Name = "picFingerPrint";
            this.picFingerPrint.Size = new System.Drawing.Size(255, 288);
            this.picFingerPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picFingerPrint.TabIndex = 6;
            this.picFingerPrint.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(235, 22);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 14;
            this.lblCount.BackColor = Color.Transparent;
            // 
            // lblCountInfo
            // 
            this.lblCountInfo.AutoSize = true;
            this.lblCountInfo.Location = new System.Drawing.Point(122, 22);
            this.lblCountInfo.Name = "lblCountInfo";
            this.lblCountInfo.Size = new System.Drawing.Size(107, 13);
            this.lblCountInfo.TabIndex = 13;
            this.lblCountInfo.Text = "Finger prints count : ";
            this.lblCountInfo.BackColor = Color.Transparent;
            // 
            // FrmAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SupplementMall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(497, 544);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblCountInfo);
            this.Controls.Add(this.picWaitingAnimation);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.picFingerPrint);
            this.Controls.Add(this.lblDeviceStatusInfo);
            this.Controls.Add(this.lblDeviceStatus);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnStartDevice);
            this.MinimumSize = new System.Drawing.Size(513, 583);
            this.Name = "FrmAddCustomer";
            this.Text = "Add Customer";
            ((System.ComponentModel.ISupportInitialize)(this.picWaitingAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartDevice;
        private System.Windows.Forms.Timer timerFinger;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblDeviceStatus;
        private System.Windows.Forms.Label lblDeviceStatusInfo;
        private System.Windows.Forms.PictureBox picFingerPrint;
        private System.Windows.Forms.LinkLabel lblLogOut;
        private System.Windows.Forms.Button btnBack;
        private PictureBox picWaitingAnimation;
        private Label lblCount;
        private Label lblCountInfo;
    }
}