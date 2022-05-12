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
    public partial class Checkin2 : Form

    {
        public static Checkin2 instance;

        public Checkin2()
        {
            InitializeComponent();
            instance = this;
            
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\WindowsFormsApp1\BookingData.mdf;Integrated Security=True;Connect Timeout=30");
        DateTime today;
        public void populate()
        {
            Con.Open();
            string Myquery = "select * from Reservation_tbl";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReservationGridView.DataSource = ds.Tables[0];
            Con.Close();
        }
        public void fillRoomcombo()
        {
            Con.Open();
            string roomstate = "free";
            SqlCommand cmd = new SqlCommand("select SlotId from Room_tbl where FreeorBusy = '" + roomstate + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SlotId", typeof(int));
            dt.Load(rdr);
            slotcb.ValueMember = "SlotId";
            slotcb.DataSource = dt;
            Con.Close();
        }
        public void fillClientcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select ClientName from Client_tbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ClientName", typeof(string));
            dt.Load(rdr);
            Clientcb.ValueMember = "ClientName";
            Clientcb.DataSource = dt;
            Con.Close();
        }
        private void ReservationInfo_Load(object sender, EventArgs e)
        {
            today = Datein.Value;
            fillRoomcombo();
            fillClientcombo();
            populate();
            Datelbl.Text = DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString();
        }

        private void Datein_ValueChanged(object sender, EventArgs e)
        {
            int res = DateTime.Compare(Datein.Value, today);
            if (res < 0)
                MessageBox.Show("Wrong Date");
        }

        private void Dateout_ValueChanged(object sender, EventArgs e)
        {
            int res = DateTime.Compare(Dateout.Value, Datein.Value);
            if (res < 0)
                MessageBox.Show("Wrong Dateout");
        }
        public void updateroomstate()
        {
            Con.Open();
            string newstate = "busy";
            string myquery = "UPDATE Room_tbl set FreeorBusy ='" + newstate + "' where SlotId = " + Convert.ToInt32(slotcb.SelectedValue.ToString()) + ";";
            SqlCommand cmd = new SqlCommand(myquery, Con);
            cmd.ExecuteNonQuery();
            // MessageBox.Show("Reservation Successfully Edited");
            Con.Close();
            fillRoomcombo();
        }
        public void updateroomondelete()
        {
            Con.Open();
            string newstate = "free";
            int roomid = Convert.ToInt32(ReservationGridView.SelectedRows[0].Cells[2].Value.ToString());
            string myquery = "UPDATE Room_tbl set FreeorBusy ='" + newstate + "' where SlotId = " + roomid + ";";
            SqlCommand cmd = new SqlCommand(myquery, Con);
            cmd.ExecuteNonQuery();
            // MessageBox.Show("Reservation Successfully Edited");
            Con.Close();
            fillRoomcombo();
        }
        private void AddRoomBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into Reservation_tbl values(" + ReserIdtb.Text + ",'" + Clientcb.SelectedValue.ToString() + "','" + slotcb.SelectedValue.ToString() + "','" + Datein.Value + "','" + Dateout.Text + "')", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added");
            Con.Close();
            updateroomstate();
            populate();
        }

        private void ReservationGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ReserIdtb.Text = ReservationGridView.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void RoomDeletebtn_Click(object sender, EventArgs e)
        {
            if (ReserIdtb.Text == "")
            {
                // MessageBox.Show("Enter the Reservation to be deleted");
            }
            else
            {
                //Con.Open();
                //string query = "delete from Reservation_tbl where ResId = " + ReserIdtb.Text + "";
                //SqlCommand cmd = new SqlCommand(query, Con);
                //cmd.ExecuteNonQuery();
                //MessageBox.Show("Reservation Successfully Deleted");
                //Con.Close();
                //updateroomondelete();
                //populate();
            }
        }

        private void RoomEditbtn_Click(object sender, EventArgs e)
        {
            if (ReserIdtb.Text == "")
            {
                //MessageBox.Show("Empty ResId,Enter The Reservation Id");
            }
            else
            {
                //Con.Open();
                //string myquery = "UPDATE Reservation_tbl set Client ='" + Clientcb.SelectedValue.ToString() + "',Room ='" + slotcb.SelectedValue.ToString() + "',Datein='" + Datein.Value.ToString() + "',Dateout ='" + Dateout.Value.ToString() + "' where ResId = " + ReserIdtb.Text + ";";
                // SqlCommand cmd = new SqlCommand(myquery, Con);
                //cmd.ExecuteNonQuery();
                //MessageBox.Show("Reservation Successfully Edited");
                //Con.Close();
                //populate();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string Myquery = "select * from Reservation_tbl where ResId = '" + Reservationsearchtb.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReservationGridView.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login mform = new Login();
            mform.Show();
            this.Hide();
        }
    }
}
