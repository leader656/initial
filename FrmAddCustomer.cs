
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmAddCustomer : Form
    {
        private int _matsize;
        private byte[] _matbuf;

        private List<byte[]> _lstCurrentFingerPrints;
        private int _size;
        
        bool _needExitApplication = true;

        public FrmAddCustomer()
        {
            try
            {
                InitializeComponent();
                InitDesigner();
                this.CenterToScreen();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void InitDesigner()
        {
            try
            {
                this.Icon = Resources.ico_logo;
                this.btnStartDevice.Image = Resources.btnstartdevice;
                this.btnNext.Image = Resources.btnnext;
                this.btnBack.Image = Resources.btnback;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStartDevice_Click(object sender, EventArgs e)
        {
            try
            {
                _lstCurrentFingerPrints = new List<byte[]>();
                _size = 0;
                lblCount.Text = "0";
                _matsize = 0;
                _matbuf = new byte[256];

                picFingerPrint.Image = null;
                timerFinger.Enabled = false;
                btnNext.Enabled = false;

                if (fpengine.OpenDevice(0, 0, 0) == 1)
                {
                    if (fpengine.LinkDevice() == 1)
                    {
                        lblDeviceStatusInfo.Text = "Open Fingerprint Reader Succeed";
                        fpengine.GenFpChar();

                        timerFinger.Enabled = true; 
                        btnStartDevice.Enabled = false;
                    }
                    else
                        lblDeviceStatusInfo.Text = "Link Fingerprint Reader Fail";
                }
                else
                    lblDeviceStatusInfo.Text = "Open Fingerprint Reader Fail";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timerFinger_Tick(object sender, EventArgs e)
        {
            try
            {
                var wm = fpengine.GetWorkMsg();
                var rm = fpengine.GetRetMsg();

                switch (wm)
                {
                    case fpengine.FPM_DEVICE:
                        lblDeviceStatusInfo.Text = "Not Open Reader";
                        break;
                    case fpengine.FPM_PLACE:
                        lblDeviceStatusInfo.Text = "Please Plase Finger";
                        break;
                    case fpengine.FPM_LIFT:
                        lblDeviceStatusInfo.Text = "Please Lift Finger";
                        break;
                    case fpengine.FPM_GENCHAR:
                        {

                            if (rm == 1)
                            {
                                lblDeviceStatusInfo.Text = "Enrol Fingerprint Template Succeed";
                                fpengine.GetFpCharByGen(_matbuf, ref _matsize);
                                lblCount.Text = _lstCurrentFingerPrints.Count + "";
                            }
                            else
                            {
                                lblDeviceStatusInfo.Text = "Enrol Fingerprint Template Fail";
                                btnNext.Enabled = false;
                            }
                            if (_lstCurrentFingerPrints.Count == 6)
                            {
                                if (rm == 1)
                                    btnNext.Enabled = true;

                                timerFinger.Enabled = false;
                                btnStartDevice.Enabled = true;
                            }
                            else
                            {
                                _size = 0;

                                _matsize = 0;
                                _matbuf = new byte[256];

                                if (fpengine.OpenDevice(0, 0, 0) == 1)
                                {
                                    if (fpengine.LinkDevice() == 1)
                                    {
                                        lblDeviceStatusInfo.Text = "Open Fingerprint Reader Succeed";
                                        fpengine.GenFpChar();
                                        timerFinger.Enabled = true;
                                    }
                                    else
                                        lblDeviceStatusInfo.Text = "Link Fingerprint Reader Fail";
                                }
                                else
                                    lblDeviceStatusInfo.Text = "Open Fingerprint Reader Fail";
                            }
                        }
                        break;
                    case fpengine.FPM_NEWIMAGE:
                        {
                            var fingerbmp = new Bitmap(picFingerPrint.Width, picFingerPrint.Height);
                            var g = Graphics.FromImage(fingerbmp);

                            fpengine.DrawImage(g.GetHdc(), 0, 0);
                            g.Dispose();

                            var newFingerPrint = new byte[256];
                            var byteFingerPrint = new byte[256];

                            fpengine.GetFpCharByGen(byteFingerPrint, ref _size);
                            Array.Copy(byteFingerPrint, newFingerPrint, byteFingerPrint.Length);

                            _lstCurrentFingerPrints.Add(newFingerPrint);
                            picFingerPrint.Image = fingerbmp;
                        }
                        break;
                    case fpengine.FPM_TIMEOUT:
                        {
                            lblDeviceStatusInfo.Text = "Time Out";
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CheckFingerPrintAndNext();
        }

        [HandleProcessCorruptedStateExceptions]
        private void CheckFingerPrintAndNext() 
        {
            try
            {
                this.picWaitingAnimation.Image = Resources.Animation;
                picWaitingAnimation.SizeMode = PictureBoxSizeMode.StretchImage;
                var taskCheck = Task.Factory.StartNew(lstCurrentFingerPrints =>
                {
                    var lstFingerPrints = (List<byte[]>) lstCurrentFingerPrints;
                    var allCustomers = DataBaseOperations.GetAllDataFromCustomers();

                    var result = 0;
                    DataRow resultMatchingRow = null;

                    foreach (DataRow dataRow in allCustomers.Rows)
                    {
                        var tmpFingerPrints = new List<byte[]>();
                        tmpFingerPrints.Add((byte[]) dataRow["FingerPrint1"]);
                        tmpFingerPrints.Add((byte[]) dataRow["FingerPrint2"]);
                        tmpFingerPrints.Add((byte[]) dataRow["FingerPrint3"]);
                        tmpFingerPrints.Add((byte[]) dataRow["FingerPrint4"]);
                        tmpFingerPrints.Add((byte[]) dataRow["FingerPrint5"]);
                        tmpFingerPrints.Add((byte[]) dataRow["FingerPrint6"]);

                        var buyDate = (DateTime) dataRow["Date"];
                        switch (Globals.AllowedPeriod)
                        {
                            case AllowedCustomerPeriod.OneMonth:
                                if (buyDate.AddMonths(1) < DateTime.Now)
                                    continue;
                                break;
                            case AllowedCustomerPeriod.ThreeMonths:
                                if (buyDate.AddMonths(3) < DateTime.Now)
                                    continue;
                                break;
                            case AllowedCustomerPeriod.SixMonths:
                                if (buyDate.AddMonths(6) < DateTime.Now)
                                    continue;
                                break;
                            case AllowedCustomerPeriod.OneYear:
                                if (buyDate.AddYears(1) < DateTime.Now)
                                    continue;
                                break;
                        }

                        foreach (var currentFingerPrint in lstFingerPrints)
                        {
                            foreach (var savedFingerPrint in tmpFingerPrints)
                            {
                                var newResult = fpengine.MatchTemplateOne(savedFingerPrint, currentFingerPrint, 256);
                                if (newResult <= result)
                                    continue;

                                resultMatchingRow = dataRow;
                                result = newResult;
                            }
                        }
                    }

                    return new object[] {result, resultMatchingRow};
                }, _lstCurrentFingerPrints);

                taskCheck.ContinueWith((antencedent, lstCurrentFingerPrint) =>
                {
                    this.picWaitingAnimation.Image = null;
                    if ((int) antencedent.Result[0] == 0)
                    {
                        var frmCustomerInfo = new FrmAddCustomerInfo(picFingerPrint.Image, (List<byte[]>) lstCurrentFingerPrint);
                        frmCustomerInfo.WindowState = this.WindowState;
                        frmCustomerInfo.Location = this.Location;
                        frmCustomerInfo.Size = this.Size;
                        frmCustomerInfo.Tag = this.Tag;
                        frmCustomerInfo.Show();
                        _needExitApplication = false;
                        this.Close();
                    }
                    else
                    {
                        var matchingDataRow = (DataRow) antencedent.Result[1];
                        MessageBox.Show("Customer allready Exist" + "\r\n" +
                                        "Name = " + matchingDataRow["Name"] + "\r\n" +
                                        "Phone = " + matchingDataRow["Phone"] + "\r\n" +
                                        "Date = " + matchingDataRow["Date"] + "\r\n");
                    }
                }, _lstCurrentFingerPrints, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (AggregateException aex)
            {
                aex = aex.Flatten();
                foreach (Exception ex in aex.InnerExceptions)
                {
                    MessageBox.Show("Tasking Exception : " + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Globals.IsAdmin)
                {
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
            }
            catch(Exception ex)
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

                var result = MessageBox.Show("Are you sure you want to exist the application", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
