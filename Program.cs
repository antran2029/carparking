using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Image;

namespace Auto_parking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmGiaoDien());
            #region .
            DateTime StartDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));
            DateTime EndDate = DateTime.Parse("2021/12/28");
            #endregion
            if (StartDate.Year <= EndDate.Year)
            {
                if (StartDate.Month <= EndDate.Month)
                {

                }
                

            }
            
        }
    }
}
