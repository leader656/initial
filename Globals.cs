using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplementMall
{
    public static class Globals
    {
        public static bool IsAdmin { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static int Id { get; set; }

        private static readonly string AllowedPeriodFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +  Path.DirectorySeparatorChar + "allowedPeriod.txt";
        private static AllowedCustomerPeriod _allowedCustomerPeriod = AllowedCustomerPeriod.NotSet;
        public static AllowedCustomerPeriod AllowedPeriod 
        {
            get
            {
                try
                {
                    if (_allowedCustomerPeriod == AllowedCustomerPeriod.NotSet)
                    {
                        if (File.Exists(AllowedPeriodFileLocation))
                        {
                            int number;
                            if (int.TryParse(File.ReadAllText(AllowedPeriodFileLocation), out number))
                            {
                                _allowedCustomerPeriod = (AllowedCustomerPeriod) number;
                            }
                        }
                        else
                        {
                            AllowedPeriod = AllowedCustomerPeriod.OneYear;
                        }
                    }

                    return _allowedCustomerPeriod;
                }
                catch (Exception ex)
                {
                    var errorMessage = "error getting allowed customer period";
                    Logger.LogException(ex, errorMessage);
                    MessageBox.Show(errorMessage, "Error!");
                }

                return AllowedCustomerPeriod.OneYear;
            }
            set
            {
                try
                {
                    if (File.Exists(AllowedPeriodFileLocation))
                        File.Delete(AllowedPeriodFileLocation);

                    _allowedCustomerPeriod = value;
                    var strAllowedCustomerPeriod = ((int) _allowedCustomerPeriod) + "";
                    File.WriteAllText(AllowedPeriodFileLocation, strAllowedCustomerPeriod);
                }
                catch (Exception ex)
                {
                    var errorMessage = "error saving allowed customer period";
                    Logger.LogException(ex, errorMessage);
                    MessageBox.Show(errorMessage, "Error!");
                }
            } 
        }

    }

    public enum AllowedCustomerPeriod
    {
        NotSet = -1,
        OneMonth = 0,
        ThreeMonths = 1,
        SixMonths = 2,
        OneYear = 3,
        ToTheEndOfTheYear = 4,
    }
}
