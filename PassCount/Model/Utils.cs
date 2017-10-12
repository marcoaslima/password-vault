using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PassCount.Model
{
    public class Utils
    {
        public static String CURRENT_LOCATION 
        {
            get
            {
                return System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            }
        }

        public static void OpenPage(String page)
        {
            System.Diagnostics.Process.Start(page);
        }

        public static String ToLocalPath(String semi)
        {
            return String.Concat(CURRENT_LOCATION, @"\", semi);
        }
    }
}
