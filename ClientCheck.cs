using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Auto_parking
{
    public partial class ClientCheck : Form
    {
        public ClientCheck()
        {
            InitializeComponent();
        }

        
        
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\WindowsFormsApp1\BookingData.mdf;Integrated Security=True;Connect Timeout=30");
        public void populate()
        {
            Con.Open();
            string Myquery = "select * from Room_tbl";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RoomGridView.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void AddRoomBtn_Click(object sender, EventArgs e)
        {
            string isfree;
            if (Yesradio.Checked == true)
                isfree = "free";
            else
                isfree = "busy";

            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into Room_tbl values(" + Roomnumtbl.Text + ",'" + Roomphonetb.Text + "','" + isfree + "')", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added");
            Con.Close();
            populate();
        }

        private void RoomInfo_Load(object sender, EventArgs e)
        {
            populate();
            Datelbl.Text = DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString();
        }

        private void RoomGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Roomnumtbl.Text = RoomGridView.SelectedRows[0].Cells[0].Value.ToString();
            Roomphonetb.Text = RoomGridView.SelectedRows[0].Cells[1].Value.ToString();

        }
        private void RoomDeletebtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "delete from Room_tbl where SlotId = " + Roomnumtbl.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            Con.Close();
            populate();
        }

        private void RoomEditbtn_Click(object sender, EventArgs e)
        {
            string isfree;
            if (Yesradio.Checked == true)
                isfree = "free";
            else
                isfree = "busy";
            Con.Open();
            string myquery = "UPDATE Room_tbl set PlateId ='" + Roomphonetb.Text + "',FreeorBusy ='" + isfree + "' where SlotId = " + Roomnumtbl.Text + ";";
            SqlCommand cmd = new SqlCommand(myquery, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Edited");
            Con.Close();
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string Myquery = "select * from Room_tbl where SlotId = '" + RoomSearchtb.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RoomGridView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login mform = new Login();
            mform.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ClientBooking Resinfo = new ClientBooking();
            Resinfo.Show();
            this.Hide();
        }
    }
}
