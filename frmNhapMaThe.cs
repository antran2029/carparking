using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Auto_parking
{
    public partial class frmNhapMaThe : Form
    {
        public frmNhapMaThe()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtMaThe.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã thẻ");
            }
            else
            {
                frmGiaoDien.TheVao = frmGiaoDien.TheRa = txtMaThe.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmGiaoDien.TheVao = frmGiaoDien.TheRa = "none";
            this.Close();
        }

        private void frmNhapMaThe_Load(object sender, EventArgs e)
        {

        }
    }
}
