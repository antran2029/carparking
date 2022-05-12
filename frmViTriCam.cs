using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Auto_parking
{
    public partial class frmViTriCam : Form
    {
        public frmViTriCam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGiaoDien.camera1 = Int32.Parse(nruCam1.Value.ToString());
            frmGiaoDien.camera2 = Int32.Parse(nruCam2.Value.ToString());
            Save(nruCam1.Value.ToString(), nruCam2.Value.ToString());
            this.Close();
        }
        private void Save(string m, string n)
        {
            if (File.Exists("./Config/Camera.txt"))
            {
                using (StreamWriter writetext = new StreamWriter("./Config/Camera.txt"))
                {
                    writetext.WriteLine(m + ";" + n);
                }
            }
        }
        private string Read()
        {
            string value = null;
            if (File.Exists("./Config/Camera.txt"))
            {
                using (StreamReader readtext = new StreamReader("./Config/Camera.txt"))
                {
                    value = readtext.ReadLine();
                    readtext.Close();
                }
            }
            return value;
        }

        private void frmViTriCam_Load(object sender, EventArgs e)
        {
            nruCam1.Maximum = frmGiaoDien.S - 1;
            nruCam2.Maximum = frmGiaoDien.S - 1;
            string[] lines = Read().Split(';');
            if (frmGiaoDien.S - 1 < Int32.Parse(lines[0]))
            {
                lines[0] = "0";
            }
            if (frmGiaoDien.S - 1 < Int32.Parse(lines[1]))
            {
                lines[1] = "0";
            }
            nruCam1.Value = Int32.Parse(lines[0]);
            
            nruCam2.Value = Int32.Parse(lines[1]);
        }
    }
}
