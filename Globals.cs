using System;
using System.Collections.Generic;
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

        public static AllowedCustomerPeriod AllowedPeriod { get; set; }

       
    }
    public enum AllowedCustomerPeriod
    {
        OneMonth = 0,
        ThreeMonths = 1,
        SixMonths = 2,
        OneYear = 3
    }
}
