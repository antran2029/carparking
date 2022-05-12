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
    public partial class BookingAdmin : Form
    {
        public BookingAdmin()
        {
            InitializeComponent();
        }

        private void BookingAdmin_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\WindowsFormsApp1\BookingData.mdf;Integrated Security=True;Connect Timeout=30");
        DateTime today;
        public void populate()
        {
            Con.Open();
            string Myquery = "select * from ClientForm";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReservationGridView.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void ReservationInfo_Load(object sender, EventArgs e)
        {
            today = Datein.Value;

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


        private void AddRoomBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into ClientForm values(" + PlateID.Text + ",'" + PhoneNumber.Text + "','" + fromto.Text + "','" + Datein.Value + "','" + Dateout.Text + "')", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added");
            Con.Close();

            populate();

        }

        private void ReservationGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PlateID.Text = ReservationGridView.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void RoomDeletebtn_Click(object sender, EventArgs e)
        {
            if (PlateID.Text == "")
            {
                MessageBox.Show("Enter the Reservation to be deleted");
            }
            else
            {
                Con.Open();
                string query = "delete from ClientForm where PlateID = " + PlateID.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                Con.Close();

                populate();
            }
        }

        private void RoomEditbtn_Click(object sender, EventArgs e)
        {
            if (PlateID.Text == "")
            {
                MessageBox.Show("Empty PlateID,Enter The Reservation Id");
            }
            else
            {
                Con.Open();
                string myquery = "UPDATE ClientForm set Phone ='" + PhoneNumber.Text + "',Room ='" + fromto.Text + "',Datein='" + Datein.Value.ToString() + "',Dateout ='" + Dateout.Value.ToString() + "' where PlateID = " + PlateID.Text + ";";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Edited");
                Con.Close();
                populate();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string Myquery = "select * from ClientForm where PlateID = '" + Reservationsearchtb.Text + "'";
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
            MainFormBook mform = new MainFormBook();
            mform.Show();
            this.Hide();
        }
    }
}
