using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplementMall
{
    public static class Logger
    {
        private static readonly string LogFilePath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "exceptions.log";

        public static void LogException(Exception ex, string errorMessage)
        {
            try
            {
                if (!File.Exists(LogFilePath))
                    File.Create(LogFilePath);

                var stringBuilder = new StringBuilder();
                stringBuilder.Append("------------------------------------------------------------------\n");
                stringBuilder.Append(errorMessage);
                stringBuilder.AppendLine();
                stringBuilder.Append(ex);
                stringBuilder.AppendLine();

                File.AppendAllText(LogFilePath, stringBuilder.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    


    }
}
