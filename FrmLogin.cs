
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmLogin : Form
    {
        private static FrmLogin _instacne;
        public static FrmLogin Instance
        {
            get { return _instacne ?? (_instacne = new FrmLogin()); }
        }


        private FrmLogin()
        {
            try
            {
                InitializeComponent();
                InitDesigner();
                this.CenterToScreen();

                AddDefaultUsersIfNeeded();
                
            }
            catch (Exception ex)
            {
                var errorMessage = "error : "+ ex.Message;
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private void InitDesigner()
        {
            try
            {
                this.Icon = Resources.ico_logo;
                this.btnLogin.Image = Resources.btnlogin;
                this.picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                this.picLogo.Image = Resources.logo;
            }
            catch (Exception ex)
            {
                var errorMessage = "error : " + ex.Message;
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

        private static void AddDefaultUsersIfNeeded()
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
                var errorMessage = "error : couldn't add the default users";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = txtUserName.Text.Trim();
                var password = txtPassword.Text.Trim();  
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

                var userInfo = DataBaseOperations.IsValidUser(userName, password);
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
                    frmAdminPanel.WindowState = this.WindowState;
                    frmAdminPanel.Location = this.Location;
                    frmAdminPanel.Size = this.Size;
                    frmAdminPanel.Show();
                    this.Hide();
                }
                else
                {
                    Globals.IsAdmin = false;
                    var frmAddCustomer = new FrmAddCustomer();
                    frmAddCustomer.WindowState = this.WindowState;
                    frmAddCustomer.Location = this.Location;
                    frmAddCustomer.Size = this.Size;
                    frmAddCustomer.Tag = this;
                    frmAddCustomer.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                var errorMessage = "error : login failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
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
                var errorMessage = "error : closing application";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
        }

    }
}
