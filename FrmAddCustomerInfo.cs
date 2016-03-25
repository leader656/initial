
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SupplementMall
{
    public partial class FrmAddCustomerInfo : Form
    {
        private readonly byte[] _fingerPrintBytes;

        public FrmAddCustomerInfo(Image fingerPrintImage, byte[] fingerPrintBytes)
        {
            try
            {
                InitializeComponent();
                this.CenterToScreen();
                this.picFingerPrint.Image = fingerPrintImage;
                this._fingerPrintBytes = fingerPrintBytes;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool _needExitApplication = true;
        private void lblLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FrmLogin.Instance.Show();
                    _needExitApplication = false;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAddCustomer = new FrmAddCustomer();
                frmAddCustomer.Tag = this.Tag;
                frmAddCustomer.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string product = txtProduct.Text.Trim();
                string phone = txtPhone.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Name field is empty");
                    return;
                }

                if (string.IsNullOrEmpty(product))
                {
                    MessageBox.Show("Product field is empty");
                    return;
                }

                if (string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Phone field is empty");
                    return;
                }

                bool success = DataBaseOperations.InsertIntoCustomers(name, phone, product, _fingerPrintBytes);
                if (success)
                {
                    MessageBox.Show("Customer saved successfuly");

                    var frmAddCustomer = new FrmAddCustomer();
                    frmAddCustomer.Tag = this.Tag;
                    frmAddCustomer.Show();
                    _needExitApplication = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Couldn't Save Customer\nSomething went wrong");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
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

                DialogResult result = MessageBox.Show("Are you sure you want to exist the application", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
