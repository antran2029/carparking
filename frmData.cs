using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lib.Image;
using System.IO.Ports;
using log4net;
using log4net.Config;
using log4net.Core;

namespace Auto_parking
{
    public partial class frmData : Form
    {
        delegate void SetTextCallback(String text);
        String dataIn = String.Empty;

        #region logger  
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        event EventHandler EventCard = null;
        public frmData()
        {
            InitializeComponent();
            EventCard += FrmData_EventCard;
        }

        private void FrmData_EventCard(object sender, EventArgs e)
        {
            string strUART = "none;none;20";
            string ID = "";
            string[] lines = strUART.Split(';');
            for (int i = 0; i < lines.Length -1 ; i++)
            {
                if (lines[i] != "none")
                {
                    ID = lines[i];
                }
            }
            txtCardID.Text = ID;
            id += 1;
            this.dataGridView1.Rows.Add(id, txtCardID.Text, "Unknow");
            IImage.AddCard(txtCardID.Text);
        }

        static int id = 0;
        private void frmData_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            string[] cards = IImage.ReadAllLine("./Card/CardID.txt");
            if (cards != null)
            {
                foreach (string card in cards)
                {
                    string[] cardPlate = card.Split(';');
                    if (!string.IsNullOrEmpty(card))
                    {
                        if (cardPlate.Length >=2 )
                        {
                            this.dataGridView1.Rows.Add("id", cardPlate[0], cardPlate[1]);
                        }
                    }
                }
            }
            id = dataGridView1.Rows.Count - 1;
            for (int i = 0; i < id; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string[] cards = IImage.ReadAllLine("./Card/CardID.txt");
            foreach (string item in cards)
            {
                string[] sp = item.Split(';');
                if (txtCardID.Text == sp[0])
                {
                    MessageBox.Show("Mã thẻ đã được đăng ký");
                    txtBienSo.Text = "";
                    txtCardID.Text = "";
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txtCardID.Text) || !string.IsNullOrEmpty(txtBienSo.Text))
            {
                id += 1;
                this.dataGridView1.Rows.Add(id, txtCardID.Text, txtBienSo.Text);
                IImage.AddCard(txtCardID.Text + ";" + txtBienSo.Text);
                MessageBox.Show("Thêm thẻ mới thành công");
            }
            else
            {
                MessageBox.Show("Yêu cầu nhập đủ thông tin mã thẻ, biển số");
            }
            txtBienSo.Text = "";
            txtCardID.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string IDCard = dataGridView1.CurrentRow.Cells[1].Value.ToString() + ";" + dataGridView1.CurrentRow.Cells[2].Value.ToString();
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa thẻ này ra khỏi danh sách?", "Thông báo", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    IImage.DeleteIDCard("./Card/CardID.txt", IDCard);
                    //cập nhật lại stt
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                    id = dataGridView1.Rows.Count - 1;
                }
            }
            catch(Exception)
            {
                return;
            }
        }

        private void frmData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                if (EventCard != null)
                {
                    EventCard(sender, e);
                }
            }
        }
        private bool CheckConnect()
        {
            try
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                }
                sp.PortName = frmGiaoDien.Port;
                sp.BaudRate = Convert.ToInt32(frmGiaoDien.BaudRate);
                sp.DataBits = 8;
                sp.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void btnDangkytudong_Click(object sender, EventArgs e)
        {
            if (btnDangkytudong.Text == "Đăng ký tự động")
            {
                btnDangkytudong.Text = "Dừng";
                if (CheckConnect())
                {
                    timer1.Enabled = true;
                }
                else 
                { 
                    MessageBox.Show("Kiểm tra lại cấu hình thiết bị");
                    btnDangkytudong.Text = "Đăng ký tự động";
                } 
                    
            }
            else
            {
                sp.Close();
                timer1.Enabled = false;
                btnDangkytudong.Text = "Đăng ký tự động";
            }
            
        }

        private void frmData_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmGiaoDien.cards = Lib.Image.IImage.ReadAllLine("./Card/CardID.txt");
            frmGiaoDien.lstCard = new List<CardInfo>();
            foreach (var item in frmGiaoDien.cards)
            {
                string[] lines = item.Split(';');
                if (lines.Length > 1)
                {
                    CardInfo objCard = new CardInfo();
                    objCard.MaThe = lines[0];
                    objCard.BienSo = lines[1];
                    frmGiaoDien.lstCard.Add(objCard);
                }
            }
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIn = sp.ReadLine();
            this.Invoke(new EventHandler(SetText));
        }
        private void SetText(object sender, EventArgs e)
        {
            string[] bienSo = dataIn.Split(';');
            if (bienSo.Length > 2)
            {
                if (bienSo[0] != "none")
                {
                    txtCardID.Text = bienSo[0];
                }
                if (bienSo[1] != "none")
                {
                    txtCardID.Text = bienSo[1];
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckConnect();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
