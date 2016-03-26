
using System;
using System.Data;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmUser : Form
    {
        bool _needExitApplication = true;

        private readonly int _id;

        public FrmUser(int id)
        {
            try
            {
                InitializeComponent();
                InitDesigner();
                this.CenterToScreen();

                _id = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id == -1)
                    return;

                var dataRow = DataBaseOperations.GetUserInfo(_id);
                if (dataRow == null)
                {
                    MessageBox.Show("couldn't load user info\nSomething went wrong", "Error!");
                    return;
                }

                txtName.Text = (string)dataRow["Name"];
                txtUserName.Text = (string)dataRow["UserName"];
                txtPassword.Text = (string)dataRow["Password"];
                txtEmail.Text = (string)dataRow["Email"];
                var isAdmin = (bool)dataRow["IsAdmin"];


                if (isAdmin)
                    rbtnAdmin.Checked = true;
                else
                    rbtnUser.Checked = true;

                if (_id == Globals.Id)
                {
                    rbtnAdmin.Enabled = false;
                    rbtnUser.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtName.Text.Trim();
                var username = txtUserName.Text.Trim();
                var password = txtPassword.Text.Trim();
                var email = txtEmail.Text.Trim();


                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Name field is empty");
                    return;
                }

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("UserName field is empty");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Password field is empty");
                    return;
                }

                if(string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Email field is empty");
                    return;
                }

                if(!email.Contains("@") || email.Contains(".com"))
                {
                    MessageBox.Show("Please enter a valid email");
                    return;
                }

                var isAdmin = rbtnAdmin.Checked;
                var resultTable = DataBaseOperations.SerachUsersTableForValue("UserName", username);

                if (_id == -1)
                {
                    if (resultTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Username already exist", "Error!");
                        return;
                    }

                    var success = DataBaseOperations.InsertIntoUsers(name, username, password, isAdmin, email);
                    if (success)
                    {
                        MessageBox.Show("User saved successfully", "Success Message");
                        Form callerForm = (Form)Activator.CreateInstance(this.Tag.GetType());
                        callerForm.Show();
                        _needExitApplication = false;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("couldn't save user info\nSomething went wrong", "Success Message");
                    }

                }
                else
                {
                    if (resultTable.Rows.Count > 0 && ((int)resultTable.Rows[0]["ID"] != _id))
                    {
                        MessageBox.Show("Username already exist", "Error!");
                        return;
                    }

                    var success = DataBaseOperations.UpdateUser(_id, name, username, password, isAdmin, email);

                    if (success)
                    {
                        MessageBox.Show("User updated successfully", "Success Message");
                        var callerForm = (Form)Activator.CreateInstance(this.Tag.GetType());
                        callerForm.WindowState = this.WindowState;
                        callerForm.Location = this.Location;
                        callerForm.Size = this.Size;
                        callerForm.Show();
                        _needExitApplication = false;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("couldn't update user info\nSomething went wrong", "Success Message");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            try
            {
                var callerForm = (Form)Activator.CreateInstance(this.Tag.GetType());
                callerForm.WindowState = this.WindowState;
                callerForm.Location = this.Location;
                callerForm.Size = this.Size;
                callerForm.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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

                if (this.Tag.GetType() == typeof(FrmUsers))
                {
                    var frmUsers = new FrmUsers();
                    frmUsers.WindowState = this.WindowState;
                    frmUsers.Location = this.Location;
                    frmUsers.Size = this.Size;
                    frmUsers.Show();
                }
                else
                {
                    var result = MessageBox.Show("Are you sure you want to exist the application", "Warning!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        Application.Exit();
                    else
                        e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
