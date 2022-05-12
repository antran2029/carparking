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
    public partial class frmPhiGuiXe : Form
    {
        public frmPhiGuiXe()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhiGuiXe.Text))
            {
                MessageBox.Show("Không được bỏ trống phí gửi xe");
            }
            else
            {
                frmGiaoDien.PhiGuiXe = txtPhiGuiXe.Text;
                MessageBox.Show("Lưu thành công");
            }
        }

        private void frmPhiGuiXe_Load(object sender, EventArgs e)
        {
            txtPhiGuiXe.Text = frmGiaoDien.PhiGuiXe;
        }
    }
}
