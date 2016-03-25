using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            try
            {
                InitializeComponent();
                this.CenterToScreen();

                cmboSearch.SelectedIndex = 0;
                cmboPeriod.SelectedIndex = (int)Globals.AllowedPeriod;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }
     
        bool _needExitApplication = true;
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAdminPanel = new FrmAdminPanel();
                frmAdminPanel.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAddCustomer = new FrmAddCustomer();
                frmAddCustomer.Tag = this;
                frmAddCustomer.Show();
                _needExitApplication = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void FillGridView()
        {
            try
            {
                this.picWaitingAnimation.Image = Resources.Animation;
                picWaitingAnimation.SizeMode = PictureBoxSizeMode.StretchImage;

               var taskGetAllCustomers = Task.Factory.StartNew(() => DataBaseOperations.GetAllDataFromCustomers());
                taskGetAllCustomers.ContinueWith(antencedent =>
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

        private void FillGridViewFromDataTable(DataTable customersDataTable)
        {
            try
            {
                dgvCustomers.Rows.Clear();
                foreach (DataRow dataRow in customersDataTable.Rows)
                {
                    this.dgvCustomers.Rows.Add(dataRow["ID"], dataRow["Name"], dataRow["Phone"], dataRow["Product"],
                        dataRow["Date"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            try
            {
                var selectedIndex = cmboSearch.SelectedIndex;
                this.picWaitingAnimation.Image = Resources.Animation;
                picWaitingAnimation.SizeMode = PictureBoxSizeMode.StretchImage;

                var dtFrom = dtDateFrom.Value;
                var dtTo = dtDateTo.Value;

                var searchFor = cmboSearch.SelectedItem.ToString();
                var value = txtValue.Text.Trim();

                var taskGetData = Task.Factory.StartNew(() => selectedIndex == 3 ?
                    DataBaseOperations.SerachCustomersTableForDate(dtFrom, dtTo) : 
                    DataBaseOperations.SerachCustomersTableForValue(searchFor, value));

                taskGetData.ContinueWith((antencedent) =>
                {
                    this.picWaitingAnimation.Image = null;
                    FillGridViewFromDataTable(antencedent.Result);
                    isFilterUsed = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void cmboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Globals.AllowedPeriod = (AllowedCustomerPeriod)cmboPeriod.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmboSearch.SelectedIndex < 3)
                {
                    dtDateFrom.Visible = false;
                    dtDateTo.Visible = false;
                    lblTo.Visible = false;
                    lblValue.Text = "Value : ";
                    txtValue.Visible = true;
                }
                else
                {
                    dtDateFrom.Visible = true;
                    dtDateTo.Visible = true;
                    txtValue.Visible = false;
                    lblValue.Text = "From : ";
                    lblTo.Visible = true;
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void dgvCustomers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = e.RowIndex;
                    if (currentMouseOverRow == -1)
                        return;
                    int currentRowId =(int)dgvCustomers.Rows[currentMouseOverRow].Cells["ID"].Value;

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

                    var cellRectangle = dgvCustomers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    contextMenu.Show(dgvCustomers, new Point(cellRectangle.Location.X + e.X, cellRectangle.Location.Y + e.Y));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        public void ReFillDataGridView()
        {
            try
            {
                if (isFilterUsed)
                    ApplyFilter();
                else
                    FillGridView();
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
                var id = (int)((MenuItem) sender).Tag;
                var frmCustomer = new FrmCustomer(id);
                frmCustomer.Show();
                _needExitApplication = false;
                this.Close();
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
                var id = (int)((MenuItem) sender).Tag;

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer", "Confirmation  Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (DataBaseOperations.DeleteFromCustomers(id))
                    {
                        MessageBox.Show("Customer deleted successfuly","Success");

                        if(isFilterUsed)
                            ApplyFilter();
                        else
                            FillGridView();
                    }
                    else
                    {
                        MessageBox.Show("couldn't Delete customer\nSomething went wrong", "Error!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void copyAlltoClipboard()
        {
            try
            {
                dgvCustomers.SelectAll();
                dgvCustomers.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                DataObject dataObj = dgvCustomers.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void ExportItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range) xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private bool isFilterUsed = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            FillGridView();
            isFilterUsed = false;
        }
      
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

            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall) 
                return;
           
            DialogResult result = MessageBox.Show("Are you sure you want to exist the application", "Warning!", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
                Application.Exit();
            else
               e.Cancel = true;
        }
    }
}
