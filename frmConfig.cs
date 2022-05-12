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
using System.IO.Ports;
using log4net;
using log4net.Config;
using log4net.Core;

namespace Auto_parking
{
    public partial class frmConfig : Form
    {
        delegate void SetTextCallback(String text);
        String dataIn = String.Empty;
        #region logger  
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        public frmConfig()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            string path = "./Config/Config.txt";
            if (!IImage.CheckFile(path))
            {
                File.Create(path);
            }
            else
            {
                string[] lines = IImage.ReadAllLine(path);
                if (lines.Length >=2)
                {
                    cboPort.Text = lines[0];
                    cboBaud.Text = lines[1];
                    txtPhiGuiXe.Text = lines[2];
                }
            }
        }
        private bool CheckConnect()
        {
            try
            {
                sp.PortName = cboPort.Text;
                sp.BaudRate = Convert.ToInt32(cboBaud.Text);
                sp.DataBits = 8;
                sp.Open();
                sp.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboPort.Text == "" || cboBaud.Text == "" || txtPhiGuiXe.Text == "")
            {
                MessageBox.Show("Nhập đủ dữ liệu");
            }
            else
            {
                frmGiaoDien.Port = cboPort.Text;
                frmGiaoDien.BaudRate = cboBaud.Text;
                frmGiaoDien.PhiGuiXe = txtPhiGuiXe.Text;
                using (StreamWriter writetext = new StreamWriter("./Config/Config.txt"))
                {
                    writetext.WriteLine(cboPort.Text);
                    writetext.WriteLine(cboBaud.Text);
                    writetext.WriteLine(txtPhiGuiXe.Text);
                }
                MessageBox.Show("Đã lưu cấu hình hệ thống");
                this.Close();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (CheckConnect())
            {
                MessageBox.Show("Kết nối thành công");
                sp.Close();
            }
            else MessageBox.Show("Kết nối thất bại");
        }
    }
}
