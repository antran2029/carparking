using Lib.Image;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using log4net.Core;

namespace Auto_parking
{
    public partial class frmBaoCao : Form
    {
        //string fName = 
        //Bitmap bitmapPlate = new Bitmap(lprInfo.plateImage);
        //string image1 = IImage.ImagePlateFolderPath(fName, MainForm.configs.imagePlatePath);
        //bitmapPlate.Save(image1);
        #region logger  
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        public frmBaoCao()
        {
            InitializeComponent();
            DateTime.Now.ToString();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int S = 0; string path = "";
            DateTime StartDate = dtpFrom.Value;
            DateTime EndDate = dtpTo.Value;

            DateTime dt = new DateTime();

            foreach (DateTime day in EachDay(StartDate, EndDate))
            {
                string strDate = day.ToString("yyyy/MM/dd HH:mm:ss");
                dt = DateTime.Parse(strDate);
                string str = "0";
                str = IImage.LayDoanhThu(dt);
                path = IImage.GetPathDThu(dt);
                if (File.Exists(path))
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        str = "0";
                    }
                    S = S + Int32.Parse(str);
                }
            }

            lblDoanhThu.Text = S.ToString();
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            string doanhThu = Lib.Image.IImage.LayDoanhThu(DateTime.Now);
            lblDoanhThu.Text = doanhThu;
        }
    }
}
