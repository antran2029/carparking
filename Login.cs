using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace Auto_parking
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\WindowsFormsApp1\BookingData.mdf;Integrated Security=True;Connect Timeout=30");
        
        public static string[,] A = new string[,]
       {
            {"0","0","0","0","0"},
            {"0","0","0","0","0"},
            {"0","0","0","0","0"},
            {"0","0","0","0","0"},
       };
                  
        private void button1_Click_1(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from Staff_tbl where Staffname='" + usernametb.Text + "' and Staffpassword='" + passwordtb.Text + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MainFormBook mf = new MainFormBook();
                mf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ClientCheck Resinfo = new ClientCheck();
            Resinfo.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmGiaoDien Resinfo = new frmGiaoDien();
            Resinfo.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}

