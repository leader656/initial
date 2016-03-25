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
    public partial class FrmCustomer : Form
    {
        private int _id;
        public FrmCustomer(int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            _id = id;

            LoadUserInfoToForm();
        }

        private void LoadUserInfoToForm()
        {
            try
            {
                DataRow drCustomerInfo = DataBaseOperations.GetCustomerInfo(_id);
                if (drCustomerInfo == null)
                    return;

                txtName.Text = (string)drCustomerInfo["Name"];
                txtPhone.Text = (string)drCustomerInfo["Phone"];
                txtProduct.Text = (string)drCustomerInfo["Product"];
                dtDate.Value = (DateTime)drCustomerInfo["Date"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCustomers frmCustomers = new FrmCustomers();
                frmCustomers.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string phone =  txtPhone.Text.Trim();
                string product = txtProduct.Text.Trim();
                DateTime date = dtDate.Value;


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

                bool success = DataBaseOperations.UpdateCustomer(_id, name, phone, product, date);
                if(success)
                {
                    MessageBox.Show("Customer updated successfully","Success");
                    FrmCustomers frmCustomers = new FrmCustomers();
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
                MessageBox.Show(ex.ToString(),"Error!");
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
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (!_needExitApplication)
                return;

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
         
            FrmCustomers frmCustomers = new FrmCustomers();
            frmCustomers.Show();

        }

        
    }
}
