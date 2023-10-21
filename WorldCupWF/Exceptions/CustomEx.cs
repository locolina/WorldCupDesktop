using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupWF.Exceptions
{
    internal class CustomEx
    {
        public static void ShowAlert(string message)
        {
            MessageBox.Show(message);
            return;
        }
    }
}
