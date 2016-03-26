
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmAddCustomerInfo : Form
    {

        bool _needExitApplication = true;
        private readonly List<byte[]> _lstFingerPrintsBytes;

        public FrmAddCustomerInfo(Image fingerPrintImage, List<byte[]> lstFingerPrintsBytes)
        {
            try
            {
                InitializeComponent();
                InitDesigner();
                this.CenterToScreen();
                this.picFingerPrint.Image = fingerPrintImage;
                this._lstFingerPrintsBytes = lstFingerPrintsBytes;
            }
            catch(Exception ex)
            {
                var errorMessage = "error : " + ex.Message;
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void InitDesigner()
        {
            try
            {
                this.Icon = Resources.ico_logo;
                this.btnCancel.Image = Resources.btncancel;
                this.btnSave.Image = Resources.btnsave;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAddCustomer = new FrmAddCustomer();
                frmAddCustomer.WindowState = this.WindowState;
                frmAddCustomer.Location = this.Location;
                frmAddCustomer.Size = this.Size;
                frmAddCustomer.Tag = this.Tag;
                frmAddCustomer.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                var errorMessage = "error : go to the previous form failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtName.Text.Trim();
                var phone = txtPhone.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Name field is empty");
                    return;
                }

                if (string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Phone field is empty");
                    return;
                }

                int number;
                var isNumeric = int.TryParse(phone, out number);
                if (!isNumeric)
                {
                    MessageBox.Show("Please enter a valid number");
                    return;
                }

                var success = DataBaseOperations.InsertIntoCustomers(name, phone, _lstFingerPrintsBytes);
                if (success)
                {
                    MessageBox.Show("Customer saved successfuly");

                    var frmAddCustomer = new FrmAddCustomer();
                    frmAddCustomer.WindowState = this.WindowState;
                    frmAddCustomer.Location = this.Location;
                    frmAddCustomer.Size = this.Size;
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
                var errorMessage = "error : saving failed";
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
            catch(Exception ex)
            {
                var errorMessage = "error : closing form failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }
    }
}
