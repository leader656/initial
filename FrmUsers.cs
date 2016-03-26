
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmUsers : Form
    {
        bool _needExitApplication = true;

        public FrmUsers()
        {
            try
            {
                InitializeComponent();
                InitDesigner();
                this.CenterToScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void InitDesigner()
        {
            try
            {
                this.Icon = Resources.ico_logo;
                this.btnAddUser.Image = Resources.btnadduser;
                this.btnBack.Image = Resources.btnback;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void FillGridView()
        {
            try
            {
                this.picWaitingAnimation.Image = Resources.Animation;
                this.picWaitingAnimation.SizeMode = PictureBoxSizeMode.StretchImage;

                var taskGetData = Task.Factory.StartNew(() => DataBaseOperations.GetAllDataFromUsers());

                taskGetData.ContinueWith(antencedent =>
                {
                    this.picWaitingAnimation.Image = null;
                    FillGridViewFromDataTable(antencedent.Result);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void FillGridViewFromDataTable(DataTable usersDataTable)
        {
            try
            {
                dgvUsers.Rows.Clear();
                foreach (DataRow dataRow in usersDataTable.Rows)
                {
                    this.dgvUsers.Rows.Add(dataRow["ID"], dataRow["Name"], dataRow["UserName"], dataRow["Password"],dataRow["Email"],
                        dataRow["IsAdmin"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
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
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void dgvUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right) 
                    return;
                var currentMouseOverRow = e.RowIndex;
                if (currentMouseOverRow == -1)
                    return;

                var currentRowId = (int)dgvUsers.Rows[currentMouseOverRow].Cells["ID"].Value;

                var contextMenu = new ContextMenu();
                var editMenuItem = new MenuItem("Edit", EditItem_Clicked);
                editMenuItem.Tag = currentRowId;
                contextMenu.MenuItems.Add(editMenuItem);

                var deleteMenuItem = new MenuItem("Delete", DeleteItem_Clicked);
                deleteMenuItem.Tag = currentRowId;
                contextMenu.MenuItems.Add(deleteMenuItem);

                var exportMenuItem = new MenuItem("Export to Excel", ExportItem_Clicked);
                exportMenuItem.Tag = currentRowId;
                contextMenu.MenuItems.Add(exportMenuItem);

                var cellRectangle = dgvUsers.GetCellDisplayRectangle(e.ColumnIndex,e.RowIndex, true);
                contextMenu.Show(dgvUsers, new Point(cellRectangle.Location.X + e.X, cellRectangle.Location.Y + e.Y));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void DeleteItem_Clicked(object sender, EventArgs eventArgs)
        {
            try
            {
                var id = (int)((MenuItem)sender).Tag;

                if (id == Globals.Id)
                    return;

                var dialogResult = MessageBox.Show("Are you sure you want to delete this user", "Confirmation  Message", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes) 
                    return;

                if (DataBaseOperations.DeleteFromUsers(id))
                {
                    MessageBox.Show("User deleted successfuly", "Success");
                        
                    FillGridView();
                }
                else
                {
                    MessageBox.Show("couldn't Delete user\nSomething went wrong", "Error!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void EditItem_Clicked(object sender, EventArgs eventArgs)
        {
            try
            {
                var id = (int)((MenuItem)sender).Tag;
                var frmUser = new FrmUser(id);
                frmUser.WindowState = this.WindowState;
                frmUser.Location = this.Location;
                frmUser.Size = this.Size;
                frmUser.Tag = this;
                _needExitApplication = false;
                frmUser.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void CopyAlltoClipboard()
        {
            try
            {
                dgvUsers.SelectAll();
                dgvUsers.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                var dataObj = dgvUsers.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void ExportItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                CopyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                var CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAdminPanel = new FrmAdminPanel();
                frmAdminPanel.WindowState = this.WindowState;
                frmAdminPanel.Location = this.Location;
                frmAdminPanel.Size = this.Size;
                frmAdminPanel.Show();
                _needExitApplication = false;
                this.Close();
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

                var result = MessageBox.Show("Are you sure you want to exist the application", "Warning!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                var frmUser = new FrmUser(-1);
                frmUser.WindowState = this.WindowState;
                frmUser.Location = this.Location;
                frmUser.Size = this.Size;
                frmUser.Tag = this;
                _needExitApplication = false;
                frmUser.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }
    }
}
