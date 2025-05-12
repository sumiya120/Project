using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Book_Shope_project3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summar
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
          
        }
    }
}
