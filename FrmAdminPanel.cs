using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplementMall
{
    public partial class FrmAdminPanel : Form
    {
        public FrmAdminPanel()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void lblLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FrmLogin.Instance.Show();
                _needExitApplication = false;
                this.Close();
            }
        }
        bool _needExitApplication = true;
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var frmAddCustomer = new FrmAddCustomer();
            frmAddCustomer.Tag = this;
            frmAddCustomer.Show();
            _needExitApplication = false;
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var frmUsers = new FrmUsers();
            frmUsers.Show();
            _needExitApplication = false;
            this.Close();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var frmCustomers = new FrmCustomers();
            frmCustomers.Show();
            _needExitApplication = false;
            this.Close();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            var frmUser = new FrmUser(Globals.Id);
            frmUser.Show();
            frmUser.Tag = this;
            _needExitApplication = false;
            this.Close();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (!_needExitApplication)
                return;

            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall)
                return;

            DialogResult result = MessageBox.Show("Are you sure you want to exist the application", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
            else
                e.Cancel = true;
        }
    }
}
