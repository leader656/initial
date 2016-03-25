
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmLogin : Form
    {
        private static FrmLogin _Instacne;
        public static FrmLogin Instance
        {
            get
            {
                if(_Instacne == null)
                    _Instacne = new FrmLogin();

                return _Instacne;
            }
        }


        public FrmLogin()
        {
            try
            {
                InitializeComponent();
                this.CenterToScreen();
                this.pictureBox1.Image = Resources.logo;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                AddDefaultUsersIfNeeded();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddDefaultUsersIfNeeded()
        {
            try
            {
                var taskAddDefaultUsers = Task.Factory.StartNew(() =>
                {
                    if (DataBaseOperations.GetAllDataFromUsers().Rows.Count != 0) 
                        return;

                    DataBaseOperations.InsertIntoUsers("Admin", "Admin", "Admin", true, "Admin@Admin.com");
                    DataBaseOperations.InsertIntoUsers("User", "User", "User", false, "User@User.com");
                });

                Task.WaitAll(new[] {taskAddDefaultUsers});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("UserName field is empty");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Password field is empty");
                    return;
                }

                if (userName.Contains(" "))
                {
                    MessageBox.Show("Invalid username");
                    return;
                }

                if (password.Contains(" "))
                {
                    MessageBox.Show("Invalid password");
                    return;
                }

                DataRow userInfo = DataBaseOperations.IsValidUser(userName, password);
                if (userInfo == null)
                {
                    MessageBox.Show("Invalid username or password");
                    return;
                }

                this.txtUserName.Text = "";
                this.txtPassword.Text = "";

                Globals.Id = (int) userInfo["ID"];
                Globals.UserName = (string) userInfo["UserName"];
                Globals.Password = (string) userInfo["Password"];

                if ((bool) userInfo["IsAdmin"])
                {
                    Globals.IsAdmin = true;
                    var frmAdminPanel = new FrmAdminPanel();
                    frmAdminPanel.Show();
                    this.Hide();
                }
                else
                {
                    Globals.IsAdmin = false;
                    var frmAddCustomer = new FrmAddCustomer();
                    frmAddCustomer.Tag = this;
                    frmAddCustomer.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                base.OnFormClosing(e);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
