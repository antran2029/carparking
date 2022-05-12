using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using log4net.Core;

namespace Auto_parking
{
    public partial class frmBaoCaoVaoRa : Form
    {
        #region logger  
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        public frmBaoCaoVaoRa()
        {
            InitializeComponent();
        }

        private void frmBaoCaoVaoRa_Load(object sender, EventArgs e)
        {
            if (frmGiaoDien.Test())
            {
            }
            TimKiem();
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            int vao;
            vao = System.IO.Directory.GetFiles("./IN").Length;

            int ra = 0;

            DateTime StartDate = dateTimePicker1.Value;
            DateTime EndDate = dateTimePicker2.Value;

            foreach (DateTime day in EachDay(StartDate, EndDate))
            {
                string strDate = day.ToString("dd_MM_yyyy");
                if (System.IO.Directory.Exists("./OutCompleted/" + strDate))
                {
                    ra += System.IO.Directory.GetFiles("./OutCompleted/" + strDate).Length;
                }
            }

            int tong = vao + ra;

            dataGridView1.Rows[0].Cells[0].Value = vao;
            dataGridView1.Rows[0].Cells[1].Value = ra;
            dataGridView1.Rows[0].Cells[2].Value = tong;

        }
    }
}
