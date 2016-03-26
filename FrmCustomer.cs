
using System;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmCustomer : Form
    {
        private readonly int _id;
        bool _needExitApplication = true;

        public FrmCustomer(int id)
        {
            try
            {
                InitializeComponent();
                InitDesigner();
                this.CenterToScreen();
                _id = id;

                LoadCustomerInfoToForm();
            }
            catch (Exception ex)
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
                this.btnSave.Image = Resources.btnsave;
                this.btnCancel.Image = Resources.btncancel;
            }
            catch (Exception ex)
            {
                var errorMessage = "error : " + ex.Message;
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void LoadCustomerInfoToForm()
        {
            try
            {
                var drCustomerInfo = DataBaseOperations.GetCustomerInfo(_id);
                if (drCustomerInfo == null)
                    return;

                txtName.Text = (string)drCustomerInfo["Name"];
                txtPhone.Text = (string)drCustomerInfo["Phone"];
                dtDate.Value = (DateTime)drCustomerInfo["Date"];
            }
            catch(Exception ex)
            {
                var errorMessage = "error : loading customer info failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var frmCustomers = new FrmCustomers();
                frmCustomers.WindowState = this.WindowState;
                frmCustomers.Location = this.Location;
                frmCustomers.Size = this.Size;
                frmCustomers.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                var errorMessage = "error : go to previuos form failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtName.Text.Trim();
                var phone =  txtPhone.Text.Trim();
                var date = dtDate.Value;


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

                var success = DataBaseOperations.UpdateCustomer(_id, name, phone, date);
                if(success)
                {
                    MessageBox.Show("Customer updated successfully","Success");
                    var frmCustomers = new FrmCustomers();
                    frmCustomers.WindowState = this.WindowState;
                    frmCustomers.Location = this.Location;
                    frmCustomers.Size = this.Size;
                    frmCustomers.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("couldn't update customer\nSomething went worng","Error!");
                }

            }
            catch (Exception ex)
            {
                var errorMessage = "error : saving failed";
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                base.OnFormClosing(e);

                if (!_needExitApplication)
                    return;

                if (e.CloseReason == CloseReason.WindowsShutDown) return;

                var frmCustomers = new FrmCustomers();
                frmCustomers.WindowState = this.WindowState;
                frmCustomers.Location = this.Location;
                frmCustomers.Size = this.Size;
                frmCustomers.Show();
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
