
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplementMall.Properties;

namespace SupplementMall
{
    public partial class FrmAddCustomer : Form
    {
        private int _matsize;
        private byte[] _matbuf;

        private byte[] _currentFingerPrint;
        private int _size;

        public FrmAddCustomer()
        {
            try
            {
                InitializeComponent();
                this.CenterToScreen();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStartDevice_Click(object sender, EventArgs e)
        {
            try
            {
                _currentFingerPrint = null;
                _size = 0;

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
                int wm = fpengine.GetWorkMsg();
                int rm = fpengine.GetRetMsg();

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
                                btnNext.Enabled = true;
                            }
                            else
                            {
                                lblDeviceStatusInfo.Text = "Enrol Fingerprint Template Fail";
                                btnNext.Enabled = false;
                            }
                            timerFinger.Enabled = false;
                        }
                        break;
                    case fpengine.FPM_NEWIMAGE:
                        {
                            var fingerbmp = new Bitmap(picFingerPrint.Width, picFingerPrint.Height);
                            var g = Graphics.FromImage(fingerbmp);
                            fpengine.DrawImage(g.GetHdc(), 0, 0);
                            g.Dispose();
                            _currentFingerPrint = new byte[256];
                            var byteFingerPrint = new byte[256];
                            fpengine.GetFpCharByGen(byteFingerPrint, ref _size);
                            Array.Copy(byteFingerPrint, _currentFingerPrint, byteFingerPrint.Length);

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
            try
            {
                this.picWaitingAnimation.Image = Resources.Animation;
                picWaitingAnimation.SizeMode = PictureBoxSizeMode.StretchImage;
                Task<object[]> taskCheck = Task.Factory.StartNew<object[]>((currentFingerPrint) =>
                {
                    var tmpcurrentFingerPrint = (byte[])currentFingerPrint;
                    var allCustomers = DataBaseOperations.GetAllDataFromCustomers();

                    var result = 0;
                    DataRow resultMatchingRow = null;

                    foreach (DataRow dataRow in allCustomers.Rows)
                    {
                        var tmpFingerPrint = (byte[])dataRow["FingerPrint"];
                        DateTime buyDate = (DateTime)dataRow["Date"];
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
                        var newResult = fpengine.MatchTemplateOne(tmpFingerPrint, tmpcurrentFingerPrint, 256);
                        if (newResult <= result)
                            continue;

                        resultMatchingRow = dataRow;
                        result = newResult;
                    }

                    return new object[]{result, resultMatchingRow};
                }, _currentFingerPrint);

                taskCheck.ContinueWith((antencedent, currentFingerPrint) =>
                {
                    this.picWaitingAnimation.Image = null;
                    if ((int) antencedent.Result[0] == 0)
                    {
                        var frmCustomerInfo = new FrmAddCustomerInfo(picFingerPrint.Image, (byte[]) currentFingerPrint);
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
                                        "Product = " + matchingDataRow["Product"] + "\r\n" +
                                        "Date = " + matchingDataRow["Date"] + "\r\n");
                    }
                }, _currentFingerPrint, TaskScheduler.FromCurrentSynchronizationContext());
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

        bool _needExitApplication = true;
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Globals.IsAdmin)
                {
                    Form callerForm = (Form)Activator.CreateInstance(this.Tag.GetType());
                    callerForm.Show();
                    _needExitApplication = false;
                    this.Close();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        FrmLogin.Instance.Show();
                        _needExitApplication = false;
                        this.Close();
                    }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
