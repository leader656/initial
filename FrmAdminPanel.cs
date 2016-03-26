
using System;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmAdminPanel : Form
    {
        bool _needExitApplication = true;

        public FrmAdminPanel()
        {
            try
            {
                InitializeComponent();
                InitDesinger();

                this.CenterToScreen();
            }
            catch (Exception ex)
            {
                var errorMessage = "error : " + ex.Message;
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void InitDesinger()
        {
            try
            {
                this.Icon = Resources.ico_logo;
                this.btnUsers.Image = Resources.btnusers;
                this.btnCustomers.Image = Resources.btncustomers;
                this.btnAddCustomer.Image = Resources.btnaddcustomer;
                this.btnEditAccount.Image = Resources.btneditaccount;
            }
            catch (Exception ex)
            {
                var errorMessage = "error : " + ex.Message;
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void lblLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes) 
                    return;

                FrmLogin.Instance.WindowState = this.WindowState;
                FrmLogin.Instance.Location = this.Location;
                FrmLogin.Instance.Size = this.Size;
                FrmLogin.Instance.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                var errorMessage = "error : logging out failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAddCustomer = new FrmAddCustomer();
                frmAddCustomer.WindowState = this.WindowState;
                frmAddCustomer.Location = this.Location;
                frmAddCustomer.Size = this.Size;
                frmAddCustomer.Tag = this;
                frmAddCustomer.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                var errorMessage = "error : opening add customer failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                var frmUsers = new FrmUsers();
                frmUsers.WindowState = this.WindowState;
                frmUsers.Location = this.Location;
                frmUsers.Size = this.Size;
                frmUsers.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                var errorMessage = "error : opening users failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                var frmCustomers = new FrmCustomers();
                frmCustomers.WindowState = this.WindowState;
                frmCustomers.Location = this.Location;
                frmCustomers.Size = this.Size;
                frmCustomers.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                var errorMessage = "error : opening customers failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                var frmUser = new FrmUser(Globals.Id);
                frmUser.WindowState = this.WindowState;
                frmUser.Location = this.Location;
                frmUser.Size = this.Size;
                frmUser.Show();
                frmUser.Tag = this;
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                var errorMessage = "error : opening edit account failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                base.OnFormClosing(e);

                if (!_needExitApplication)
                    return;

                if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall)
                    return;

                var result = MessageBox.Show("Are you sure you want to exist the application", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                var errorMessage = "error : closing form failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }
    }
}
