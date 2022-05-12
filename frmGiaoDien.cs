using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Diagnostics;
using Emgu.CV.CvEnum;
using System.IO;
using System.IO.Ports;
using tesseract;
using System.Collections;
using System.Threading;
using System.Media;
using System.Runtime.InteropServices;
using AForge.Video;
using AForge.Video.DirectShow;
using Lib.Image;
using log4net;
using log4net.Config;
using log4net.Core;

namespace Auto_parking
{
    public partial class frmGiaoDien : Form
    {
        public static frmGiaoDien instance; 
        #region định nghĩa
        static int i = 0;
        List<Image<Bgr, byte>> PlateImagesList = new List<Image<Bgr, byte>>();
        Image Plate_Draw;
        List<string> PlateTextList = new List<string>();
        List<Rectangle> listRect = new List<Rectangle>();
        PictureBox[] box = new PictureBox[12];

        public TesseractProcessor full_tesseract = null;
        public TesseractProcessor ch_tesseract = null;
        public TesseractProcessor num_tesseract = null;
        private string m_path = Application.StartupPath + @"\data\";
        private List<string> lstimages = new List<string>();
        private const string m_lang = "eng";
        ImageForm IF;
        //int current = 0;
        FilterInfoCollection filterInfo;
        Capture capture = null;
        Capture capture2 = null;
        public static int camera1 = 0;
        public static int camera2 = 1;
        #endregion

        delegate void SetTextCallback(String text);
        String dataIn = String.Empty;

        #region Contr
        public static string Port { get; set; }
        public static string BaudRate { get; set; }
        public static string TheVao { get; set; }
        public static string TheRa { get; set; }
        public static string PhiGuiXe { get; set; }
        public static string[] cards { get; set; }

        public static List<CardInfo> lstCard = new List<CardInfo>();
        //private static string[] viTriChoTrong = new string[12];
        int soChoDeXe = 12;
        string[] cardIns = null;
        string[] lstFiles = Lib.Image.IImage.ReadAllFileName("./Location");
        string[] lstPanelViTri = { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4", };
        public static bool Login { get; set; } = false;
        bool isGiaLap = false;
        bool isGioiHanXeTrongBai = true;
        bool isKiemTraChoTrong = true;
        #endregion

        #region logger  
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        event EventHandler EventInCard = null;
        event EventHandler EventOutCard = null;
        
        public frmGiaoDien()
        {
            InitializeComponent();
            EventInCard += FrmGiaoDien_EventInCard;
            EventOutCard += FrmGiaoDien_EventOutCard;
            instance = this; 
        }

        private void FrmGiaoDien_EventOutCard(object sender, EventArgs e)
        {
            frmNhapMaThe frm = new frmNhapMaThe();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                if (TheVao != "none")
                {
                    XeRa(TheRa);
                }
            }
        }

        private void FrmGiaoDien_EventInCard(object sender, EventArgs e)
        {
            frmNhapMaThe frm = new frmNhapMaThe();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                if (TheVao != "none")
                {
                    XeVao(TheVao);
                }
            }
        }
        #region Form Load 
        public static int S = 0;
        private void frmGiaoDien_Load(object sender, EventArgs e)
        {
            logger.Info("Start Program");
            logger.Info("---------------------------------------------");

            #region .
            //timer1.Enabled = false;
            frmRegister frm = new frmRegister();
            frm.ShowDialog(this);
            if (frm.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            //timer1.Enabled = true;
            miCauHinh.Enabled = false;
            miDuLieu.Enabled = false;
            miBaoCao.Enabled = false;
            miVaoRa.Enabled = false;
            btnMoBarrierRa.Enabled = false;
            btnMoBarrierVao.Enabled = false;
            miLogin.Enabled = true;
            miLogin.Text = "Đăng nhập";
            #endregion

            #region Khởi tạo

            filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in filterInfo)
            {
                S++;
            }


            IF = new ImageForm();

            full_tesseract = new TesseractProcessor();
            bool succeed = full_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            full_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFHKLMNPRSTVXY1234567890").ToString();

            ch_tesseract = new TesseractProcessor();
            succeed = ch_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            ch_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFHKLMNPRSTUVXY").ToString();

            num_tesseract = new TesseractProcessor();
            succeed = num_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            num_tesseract.SetVariable("tessedit_char_whitelist", "1234567890").ToString();


            m_path = System.Environment.CurrentDirectory + "\\";
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < box.Length; i++)
            {
                box[i] = new PictureBox();
            }
            #endregion
            Lib.Image.IImage.CreatePathDThu(DateTime.Now);
            cards = Lib.Image.IImage.ReadAllLine("./Card/CardID.txt");
            foreach (string item in cards)
            {
                //MessageBox.Show(item);
                string[] str = item.Split(';');
                if (str != null)
                {
                    //MessageBox.Show(str[0] +  " " +str[1]);
                    if (str.Length >= 2)
                    {
                        CardInfo objCard = new CardInfo();
                        objCard.MaThe = str[0];
                        objCard.BienSo = str[1];
                        lstCard.Add(objCard);
                    }

                }
            }
            try
            {
                if (S > 1)
                {
                    frmViTriCam frm2 = new frmViTriCam();
                    frm2.ShowDialog();
                    //MessageBox.Show(camera1 + " " + camera2);
                    capture = new Emgu.CV.Capture(camera1);
                    capture2 = new Emgu.CV.Capture(camera2);
                    timer1.Enabled = true;
                }

                string[] lines = Lib.Image.IImage.ReadAllLine("./Config/Config.txt");
                if (lines.Length >= 3)
                {
                    Port = lines[0];
                    BaudRate = lines[1];
                    PhiGuiXe = lines[2];
                }
                this.KeyPreview = true;
                lblFee.Text = "";
                string fileN = Lib.Image.IImage.GetPathDThu(DateTime.Now);
                if (!File.Exists(fileN))
                {
                    File.Create(fileN);
                }
                if (CheckConnect())
                {
                    lblStatus.Text = "Port: " + Port + " OK";
                    lblStatus.ForeColor = Color.Blue;
                }
                else
                {
                    lblStatus.Text = "Port: " + Port + " Fail";
                    lblStatus.ForeColor = Color.Red;
                }
                //Màu vị trí chỗ trống
                
                //KiemTraViTriTrongXeVao("1");
                LoadViTri();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void SetText(object sender, EventArgs e)
        {
            timerCheck.Enabled = false;
            textBox1.Text = dataIn;
            if (dataIn.Length > 25)
            {
                return;
            }
            string[] lines = dataIn.Split(';');
            if (lines.Length > 2)
            {
                if (lines[0] != "none") //12345;none;gas
                {
                    isGiaLap = false;
                    //wplayer2.controls.play();
                    XeVao(lines[0]);
                    logger.Info("Quẹt thẻ xe vào");
                }
                if (lines[1] != "none")
                {
                    isGiaLap = false;
                    //wplayer2.controls.play();
                    XeRa(lines[1]);
                    logger.Info("Quẹt thẻ xe ra");
                }
                if (lines[2].Trim() == "GAS")
                {
                    logger.Info("Cảnh báo cháy");
                    lblGas.Text = "Cảnh báo cháy";
                    lblGas.ForeColor = Color.Red;
                    btnTatCanhBao.Text = "Tắt cảnh báo";
                    btnTatCanhBao.Visible = true;

                }
                else
                {
                    lblGas.Text = "Ổn định";
                    lblGas.ForeColor = Color.Blue;
                }
            }
            timerCheck.Enabled = true;
        }
        #endregion
        #region Vị trí trống xe trong bãi
        private void KiemTraViTriTrongXeVao(string idTheVao)
        {
            List<int> lstViTris = new List<int>();
            //string[] lstPanelViTri
            for (int i = 0; i < soChoDeXe; i++)
            {
                string content = "" + Lib.Image.IImage.ReadFile(lstFiles[i]);
                if (string.IsNullOrEmpty(content.Trim()))
                {
                    lstViTris.Add(i);
                }
            }
            Random random = new Random();
            //MessageBox.Show(lstViTris.Count.ToString());
            int viTri = random.Next(lstViTris.Count);
            //MessageBox.Show(viTri.ToString());
            var value = lstViTris[viTri]; //Vị trí panel ngẫu nhiên trong list
            //MessageBox.Show(viTri + " -- " + value + " -- " + lstFiles[value]);
            Lib.Image.IImage.WriteFile(idTheVao, lstFiles[value]);
            
        }
        private void KiemTraViTriTrongXeRa(string idTheRa)
        {
            foreach (var item in lstFiles)
            {
                string content = "" + Lib.Image.IImage.ReadFile(item);
                if (content.Trim() == idTheRa)
                {
                    Lib.Image.IImage.WriteFile("", item);

                    if (item.Contains("panelA1"))
                    {
                        panel1A.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelA2"))
                    {
                        panel2A.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelA3"))
                    {
                        panel3A.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelA4"))
                    {
                        panel4A.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelB1"))
                    {
                        panel1B.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelB2"))
                    {
                        panel2B.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelB3"))
                    {
                        panel3B.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelB4"))
                    {
                        panel4B.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelC1"))
                    {
                        panel1C.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelC2"))
                    {
                        panel2C.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelC3"))
                    {
                        panel3C.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelC4"))
                    {
                        panel4C.BackColor = Color.Lime;
                    }
                    break;
                }
            }
        }
        private void LoadViTri()
        {
            foreach (var item in lstFiles)
            {
                //MessageBox.Show(item);
                string content = "" + Lib.Image.IImage.ReadFile(item);
                if (string.IsNullOrEmpty(content.Trim()))
                {
                   // MessageBox.Show(content);
                    if (item.Contains("panelA1"))
                    {
                        panel1A.BackColor = Color.Lime;
                    }
                     else if (item.Contains("panelA2"))
                    {
                        panel2A.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelA3"))
                    {
                        panel3A.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelA4"))
                    {
                        panel4A.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelB1"))
                    {
                        panel1B.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelB2"))
                    {
                        panel2B.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelB3"))
                    {
                        panel3B.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelB4"))
                    {
                        panel4B.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelC1"))
                    {
                        panel1C.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelC2"))
                    {
                        panel2C.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelC3"))
                    {
                        panel3C.BackColor = Color.Lime;
                    }
                    else if (item.Contains("panelC4"))
                    {
                        panel4C.BackColor = Color.Lime;
                    }
                }
                else
                {
                    if (item.Contains("panelA1"))
                    {
                        panel1A.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelA2"))
                    {
                        panel2A.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelA3"))
                    {
                        panel3A.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelA4"))
                    {
                        panel4A.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelB1"))
                    {
                        panel1B.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelB2"))
                    {
                        panel2B.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelB3"))
                    {
                        panel3B.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelB4"))
                    {
                        panel4B.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelC1"))
                    {
                        panel1C.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelC2"))
                    {
                        panel2C.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelC3"))
                    {
                        panel3C.BackColor = Color.Red;
                    }
                    else if (item.Contains("panelC4"))
                    {
                        panel4C.BackColor = Color.Red;
                    }
                }
            }
        }
        private void ClearViTri()
        {
            foreach (var item in lstFiles)
            {
                Lib.Image.IImage.WriteFile("", item);
            }
            //Xóa xe đang trong bãi
            System.IO.DirectoryInfo di = new DirectoryInfo("./In");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        #endregion
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void miCauHinh_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
            }
            timerCheck.Enabled = false;
            frmConfig frm = new frmConfig();
            frm.ShowDialog(this);
            timerCheck.Enabled = true;
        }
        private void miBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();
            frm.ShowDialog(this);
        }
        bool success = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (success == true)
            {
                success = false;
                new Thread(() =>
                {
                    try
                    {
                        if (S > 1)
                        {
                            capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 640);
                            capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 480);
                            //--------------------------//
                            capture2.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 640);
                            capture2.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 480);
                            Image<Bgr, byte> cap2 = capture2.QueryFrame();
                            //--------------------------//
                            Image<Bgr, byte> cap = capture.QueryFrame();
                            if (cap != null)
                            {
                                MethodInvoker mi = delegate
                                {
                                    try
                                    {
                                        Bitmap bmp = cap.ToBitmap();
                                        pictureBox_VAO.Image = bmp;
                                        IF.pictureBox4.Image = bmp;
                                        pictureBox_VAO.Update();
                                        IF.pictureBox4.Update();
                                    }
                                    catch (Exception ex)
                                    { }
                                };
                                if (InvokeRequired)
                                    Invoke(mi);
                            }
                            if (cap2 != null)
                            {
                                MethodInvoker mi = delegate
                                {
                                    try
                                    {
                                        Bitmap bmp = cap2.ToBitmap();
                                        pictureBox_RA.Image = bmp;
                                        IF.pictureBox4.Image = bmp;
                                        pictureBox_RA.Update();
                                        IF.pictureBox4.Update();
                                    }
                                    catch (Exception ex)
                                    { }
                                };
                                if (InvokeRequired)
                                    Invoke(mi);
                            }
                        }


                    }
                    catch (Exception) { }
                    success = true;
                }).Start();

            }
        }
        Devices[] cam = new Devices[3];
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < cam.Length; i++)
                {
                    if (cam[i] != null && cam[i].status == "run" && cam[i].image != null)
                    {
                        MethodInvoker mi = delegate
                        {
                            PictureBox pb = this.Controls.Find(cam[i].pb, true).FirstOrDefault() as PictureBox;
                            pb.Image = cam[i].image;
                            pb.Update();
                            pb.Invalidate();
                        };
                        if (InvokeRequired)
                        {
                            Invoke(mi);
                            return;
                        }

                        PictureBox pb2 = this.Controls.Find(cam[i].pb, true).FirstOrDefault() as PictureBox;
                        pb2.Image = cam[i].image;
                        pb2.Update();
                        pb2.Invalidate();
                    }
                }
            }
            catch (Exception) { }
        }
        private void XeVao(string cardID, string pathImage)
        {
            bool theDaDangKy = false;
            bool xeDangTrongBai = false;
            txtSoTheVao.Text = cardID;
            try
            {
                cardIns = Lib.Image.IImage.ReadAllFileName("./IN/");

                foreach (string item in cardIns)
                {
                    if (item.Replace(".txt", "").Replace("./IN/", "") == cardID)
                    {
                        xeDangTrongBai = true;
                    }
                }
                if (lstCard != null)//cards chứa cả thẻ, cả biển số
                {
                    foreach (CardInfo item in lstCard)
                    {
                        if (item.MaThe == cardID)
                        {
                            theDaDangKy = true;
                        }
                    }
                }
                if (theDaDangKy)
                {
                    if (!xeDangTrongBai)
                    {
                        i = 0;
                        lblTimeIn.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        txtSoTheVao.Text = TheVao;
                        if (true)
                        {
                            timer1.Enabled = false;
                            pictureBox_VAO_2.Image = null;
                            //IF.pictureBox2.Image = null;
                            //capture.QueryFrame().Save("aa.bmp");
                            
                          
                           
                            //int z = con.count;
                            //pictureBox_PlateIn.Image = color;
                            FileStream fs = new FileStream(pathImage, FileMode.Open, FileAccess.Read);
                            Image temp = Image.FromStream(fs);
                            fs.Close();
                            pictureBox_VAO_2.Image = temp;
                            pictureBox_VAO_2.Update();

                            timer1.Enabled = true;

                            Image temp1;
                            string temp2, temp3;
                            Reconize(pathImage, out temp1, out temp2, out temp3);
                            //pictureBox_VAO_2.Image = temp1;
                            string temp4 = "";
                            string newstring =  temp3.Substring(0, 3);
                            string newstring1 = temp3.Substring(temp3.Length - 4, 4);
                            string newstring2 = temp3.Substring(temp3.Length - 5, 5);

                            if (temp3 == "")
                                txtBienSoVao.Text = "Unknow";
                            else
                            {
                                if(temp3.Length > 7)
                                {
                                    text_PlateIn.Text = newstring;
                                    text_PlateIn2.Text = newstring2;

                                }
                                if (temp3.Length < 8)
                                {
                                    text_PlateIn.Text = newstring;
                                    text_PlateIn2.Text = newstring1;
                                }

                                if (temp3.Length > 3)
                                {

                                    if (Lib.Image.IImage.CheckPlate1(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate2(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate3(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate4(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate5(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }

                                    else txtBienSoVao.Text = temp3;
                                }
                                else txtBienSoVao.Text = "Unknow";
                            }                            
                            foreach (CardInfo item in lstCard)
                            {
                                if (item.MaThe == cardID && (Lib.Image.IImage.CheckNumber(item.BienSo, txtBienSoVao.Text.Trim(), 6) || item.BienSo == txtBienSoVao.Text.Trim()))
                                {
                                    lblStatusBarrierVao.Text = "Barrier đang mở";
                                    timerVao.Enabled = true;
                                    txtBienSoVao.Text = item.BienSo;
                                    string fName = "Vao_" + DateTime.Now.ToString("HHmmss") + ".jpg";
                                    string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                                    Bitmap bitmap = new Bitmap(pictureBox_VAO_2.Image);
                                    //MessageBox.Show(path);
                                    bitmap.Save(path);
                                    Lib.Image.IImage.AddInfoCarIn(cardID, txtBienSoVao.Text.Trim('\n').Trim('\r'), DateTime.Now, path);

                                    //Kiểm tra chỗ trống, đẩy số ngẫu nhiên
                                    if (isKiemTraChoTrong)
                                    {
                                        KiemTraViTriTrongXeVao(cardID);
                                        LoadViTri();
                                    }

                                    break;
                                }
                                else if (item.MaThe == cardID && item.BienSo != txtBienSoVao.Text.Trim())
                                {
                                    DialogResult dr = MessageBox.Show("Xe chưa đặt trước. Cho xe vào?", "Thông báo", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.Yes)
                                    {
                                        lblStatusBarrierVao.Text = "Barrier đang mở";
                                        timerVao.Enabled = true;
                                        string fName = "Vao_" + DateTime.Now.ToString("HHmmss") + ".jpg";
                                        string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                                        Bitmap bitmap = new Bitmap(pictureBox_VAO_2.Image);
                                        //MessageBox.Show(path);
                                        bitmap.Save(path);
                                        Lib.Image.IImage.AddInfoCarIn(cardID, txtBienSoVao.Text.Trim('\n').Trim('\r'), DateTime.Now, path);

                                        //Kiểm tra chỗ trống, đẩy số ngẫu nhiên
                                        if (isKiemTraChoTrong)
                                        {
                                            KiemTraViTriTrongXeVao(cardID);
                                            LoadViTri();
                                        }
                                    }
                                    break;
                                }
                            }
                            timerIn.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thẻ xe này đang trong bãi gửi xe");
                    }

                }
                else
                {
                    MessageBox.Show("Thẻ chưa được đăng ký");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void XeRa(string theRa, string pathImage)
        {
            string[] lines = null;
            lblTimeOut.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtSoTheRa.Text = theRa;
            if (File.Exists("./IN/" + theRa + ".txt"))
            {
                lines = Lib.Image.IImage.ReadAllLine("./IN/" + theRa + ".txt");
                if (lines.Length >= 3)
                {
                    DateTime dt = DateTime.Parse(lines[1]);
                    txtDoiChieuBienSoVao.Text = lines[0];
                    lblCompare_TimeOut.Text = dt.ToString("dd/MM/yyyy HH:mm:ss");
                    pictureBox_DoiChieuVao.Image = Image.FromFile(lines[2]);

                    try
                    {
                        lblTimeOut.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        lblThoiGianGuiXe.Text = "Thời gian gửi xe trong bãi: " + Lib.Image.IImage.TimeSub(lines[1], DateTime.Now.ToString());
                        lblFee.Text = PhiGuiXe + " vnd";

                        txtSoTheRa.Text = TheRa;
                        i = 1;
                        if (true)
                        {
                            timer1.Enabled = false;
                            pictureBox_RA_2.Image = null;
                            IF.pictureBox2.Image = null;
                            //capture2.QueryFrame().Save("bb.bmp");
                            FileStream fs = new FileStream(pathImage, FileMode.Open, FileAccess.Read);
                            Image temp = Image.FromStream(fs);
                            fs.Close();
                            pictureBox_RA_2.Image = temp;
                            pictureBox_RA_2.Update();
                            timer1.Enabled = true;
                            Image temp1;
                            string temp2, temp3;
                            Reconize(pathImage, out temp1, out temp2, out temp3);
                            string newstring =  temp3.Substring(0, 3);
                            string newstring1 = temp3.Substring(temp3.Length - 4, 4);
                            string newstring2 = temp3.Substring(temp3.Length - 5, 5);
                            
                            //pictureBox_RA_3.Image = temp1;
                            if (temp3 == "")
                                txtBienSoRa.Text = "Unknow";
                            else
                            {
                                if (temp3.Length > 3)
                                {
                                    string temp4 = "";
                                    if (temp3.Length > 7)
                                    {
                                        text_PlateIn3.Text = newstring;
                                        text_PlateIn4.Text = newstring2;

                                    }
                                    if (temp3.Length < 8)
                                    {
                                        text_PlateIn3.Text = newstring;
                                        text_PlateIn4.Text = newstring1;
                                    }
                                    if (Lib.Image.IImage.CheckPlate1(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate2(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate3(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate4(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate5(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else txtBienSoRa.Text = temp3;
                                }
                                else
                                {
                                    txtBienSoRa.Text = "Unknow";
                                }

                            }

                            if (Lib.Image.IImage.CheckNumber(lines[0], txtBienSoRa.Text.Trim('\n').Trim('\r'), 6) || txtBienSoRa.Text.Trim('\n').Trim('\r') == lines[0])
                            {
                                lblStatusBarrierRa.Text = "Barrier đang mở";
                                timerRa.Enabled = true;

                                #region Hiển thị đối chiếu
                                string doanhThu = Lib.Image.IImage.LayDoanhThu(DateTime.Now);
                                txtBienSoRa.Text = lines[0];
                                if (string.IsNullOrEmpty(doanhThu))
                                {
                                    doanhThu = "0";
                                }
                                string doanhThuMoi = (Int32.Parse(doanhThu) + Int32.Parse(PhiGuiXe)).ToString();
                                //MessageBox.Show(doanhThuMoi);
                                Lib.Image.IImage.LuuDoanhThu(DateTime.Now, doanhThuMoi);
                                #endregion

                                string fName = "Ra_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".jpg";
                                string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                                Bitmap bitmap = new Bitmap(pictureBox_RA_2.Image);

                                bitmap.Save(path);
                                Lib.Image.IImage.AddInfoCarOut(TheRa, txtBienSoRa.Text.Trim('\n').Trim('\r'), DateTime.Now, path, lblThoiGianGuiXe.Text);
                                if (File.Exists("./OutCompleted/" + theRa + ".txt"))
                                {
                                    Lib.Image.IImage.MoveFileInfo(Application.StartupPath + "/IN/" + theRa + ".txt", Application.StartupPath + "/OutCompleted/" + theRa + "_" + DateTime.Now.ToString("HHmmss") + ".txt");
                                }
                                else
                                {
                                    if (!Directory.Exists("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy")))
                                    {
                                        Directory.CreateDirectory("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy"));
                                    }
                                    Lib.Image.IImage.MoveFileInfo(Application.StartupPath + "/IN/" + theRa + ".txt", Application.StartupPath + "/OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy") + "/" + DateTime.Now.ToString("HH_mm_ss") + theRa + ".txt");
                                }

                                //Kiểm tra chỗ trống trong bãi
                                if (isKiemTraChoTrong)
                                {
                                    KiemTraViTriTrongXeRa(theRa);

                                    LoadViTri();
                                }
                            }
                            else
                            {
                                DialogResult dr = MessageBox.Show("Khác biển số lúc vào, bạn có muốn cho ra?", "Thông báo", MessageBoxButtons.YesNo);
                                if (dr == DialogResult.Yes)
                                {
                                    #region Hiển thị đối chiếu
                                    lblStatusBarrierRa.Text = "Barrier đang mở";
                                    timerRa.Enabled = true;
                                    string doanhThu = Lib.Image.IImage.LayDoanhThu(DateTime.Now);

                                    if (string.IsNullOrEmpty(doanhThu))
                                    {
                                        doanhThu = "0";
                                    }
                                    string doanhThuMoi = (Int32.Parse(doanhThu) + Int32.Parse(PhiGuiXe)).ToString();
                                    //MessageBox.Show(doanhThuMoi);
                                    Lib.Image.IImage.LuuDoanhThu(DateTime.Now, doanhThuMoi);
                                    #endregion
                                    string fName = "Ra_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".jpg";
                                    string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                                    Bitmap bitmap = new Bitmap(pictureBox_RA_2.Image);

                                    bitmap.Save(path);
                                    Lib.Image.IImage.AddInfoCarOut(TheRa, txtBienSoRa.Text.Trim('\n').Trim('\r'), DateTime.Now, path, lblThoiGianGuiXe.Text);
                                    if (File.Exists("./OutCompleted/" + theRa + ".txt"))
                                    {
                                        Lib.Image.IImage.MoveFileInfo(Application.StartupPath + "/IN/" + theRa + ".txt", Application.StartupPath + "/OutCompleted/" + theRa + "_" + DateTime.Now.ToString("HHmmss") + ".txt");
                                    }
                                    else
                                    {
                                        if (!Directory.Exists("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy")))
                                        {
                                            Directory.CreateDirectory("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy"));
                                        }
                                        Lib.Image.IImage.MoveFileInfo(Application.StartupPath + "/IN/" + theRa + ".txt", Application.StartupPath + "/OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy") + "/" + DateTime.Now.ToString("HH_mm_ss") + theRa + ".txt");
                                    }

                                    //Kiểm tra chỗ trống trong bãi
                                    if (isKiemTraChoTrong)
                                    {
                                        KiemTraViTriTrongXeRa(theRa);
                                        LoadViTri();
                                    }
                                }
                            }
                            timerOut.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw ex;
                    }

                }

            }
            else MessageBox.Show("Thẻ chưa gửi trong bãi");

        }
        private void btnChupAnhVao_Click(object sender, EventArgs e)
        {
            if (isGioiHanXeTrongBai)
            {
                string[] soXeTrongBai = Lib.Image.IImage.ReadAllFileName("./IN");
                if (soXeTrongBai.Length >= soChoDeXe)
                {
                    MessageBox.Show("Số lượng xe trong bãi đã vượt giới hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            isGiaLap = true;
            i = 0;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image (*.bmp; *.jpg; *.jpeg; *.png) |*.bmp; *.jpg; *.jpeg; *.png|All files (*.*)|*.*||";
            dlg.InitialDirectory = Application.StartupPath + "\\ImageTest";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string startupPath = dlg.FileName;
            frmNhapMaThe frm = new frmNhapMaThe();
            frm.ShowDialog(this);

            if (string.IsNullOrEmpty(TheVao))
            {
                return;
            }

            pictureBox_VAO.Image = Image.FromFile(startupPath);
            
            if (TheVao.Trim() != null)
            {
                XeVao(TheVao, startupPath);
            }
            else pictureBox_VAO.Image = null;
            logger.Info("Giả lập xe vào");
        }
        
        private void Reconize(string link, out Image hinhbienso, out string bienso, out string bienso_text)
        {
            for (int i = 0; i < box.Length; i++)
            {
                this.Controls.Remove(box[i]);
            }

            hinhbienso = null;
            bienso = "";
            bienso_text = "";
            ProcessImage(link);
            if (PlateImagesList.Count != 0)
            {
                Image<Bgr, byte> src = new Image<Bgr, byte>(PlateImagesList[0].ToBitmap());
                Bitmap grayframe;
                FindContours con = new FindContours();
                Bitmap color;
                int c = con.IdentifyContours(src.ToBitmap(), 50, false, out grayframe, out color, out listRect);  // find contour
                //int z = con.count;
                if (i % 2 == 0)
                {
                    pictureBox_VAO_2.Image = color;
                    pictureBox_VAO_3.Image = grayframe;
                    IF.pictureBox1.Image = color;
                    //pictureBox_BiensoRA.Image = grayframe; - nottt
                }
                else
                {
                    pictureBox_RA_2.Image = color;
                    pictureBox_RA_3.Image = grayframe;
                    IF.pictureBox1.Image = color;
                    //pictureBox_BiensoRA1.Image = grayframe; - nottt
                }
                IF.pictureBox1.Image = color;
                hinhbienso = Plate_Draw;

                IF.pictureBox3.Image = grayframe;
                //textBox2.Text = c.ToString();
                Image<Gray, byte> dst = new Image<Gray, byte>(grayframe);
                //dst = dst.Dilate(2);
                //dst = dst.Erode(3);
                grayframe = dst.ToBitmap();
                //pictureBox2.Image = grayframe.Clone(listRect[2], grayframe.PixelFormat);
                string zz = "";

                // lọc và sắp xếp số
                List<Bitmap> bmp = new List<Bitmap>();
                List<int> erode = new List<int>();
                List<Rectangle> up = new List<Rectangle>();
                List<Rectangle> dow = new List<Rectangle>();
                int up_y = 0, dow_y = 0;
                bool flag_up = false;

                int di = 0;

                if (listRect == null) return;

                for (int i = 0; i < listRect.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(listRect[i], grayframe.PixelFormat);
                    int cou = 0;
                    full_tesseract.Clear();
                    full_tesseract.ClearAdaptiveClassifier();
                    string temp = full_tesseract.Apply(ch);
                    while (temp.Length > 3)
                    {
                        Image<Gray, byte> temp2 = new Image<Gray, byte>(ch);
                        temp2 = temp2.Erode(2);
                        ch = temp2.ToBitmap();
                        full_tesseract.Clear();
                        full_tesseract.ClearAdaptiveClassifier();
                        temp = full_tesseract.Apply(ch);
                        cou++;
                        if (cou > 10)
                        {
                            listRect.RemoveAt(i);
                            i--;
                            di = 0;
                            break;
                        }
                        di = cou;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    for (int j = i; j < listRect.Count; j++)
                    {
                        if (listRect[i].Y > listRect[j].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[j].Y;
                            dow_y = listRect[i].Y;
                            break;
                        }
                        else if (listRect[j].Y > listRect[i].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[i].Y;
                            dow_y = listRect[j].Y;
                            break;
                        }
                        if (flag_up == true) break;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    if (listRect[i].Y < up_y + 50 && listRect[i].Y > up_y - 50)
                    {
                        up.Add(listRect[i]);
                    }
                    else if (listRect[i].Y < dow_y + 50 && listRect[i].Y > dow_y - 50)
                    {
                        dow.Add(listRect[i]);
                    }
                }

                if (flag_up == false) dow = listRect;

                for (int i = 0; i < up.Count; i++)
                {
                    for (int j = i; j < up.Count; j++)
                    {
                        if (up[i].X > up[j].X)
                        {
                            Rectangle w = up[i];
                            up[i] = up[j];
                            up[j] = w;
                        }
                    }
                }
                for (int i = 0; i < dow.Count; i++)
                {
                    for (int j = i; j < dow.Count; j++)
                    {
                        if (dow[i].X > dow[j].X)
                        {
                            Rectangle w = dow[i];
                            dow[i] = dow[j];
                            dow[j] = w;
                        }
                    }
                }

                int x = 12;
                int c_x = 0;

                for (int i = 0; i < up.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(up[i], grayframe.PixelFormat);
                    Bitmap o = ch;
                    //ch = con.Erodetion(ch);
                    string temp;
                    if (i < 2)
                    {
                        temp = Ocr(ch, false, true); // nhan dien so
                    }
                    else
                    {
                        temp = Ocr(ch, false, false);// nhan dien chu
                    }

                    zz += temp;
                    box[i].Location = new Point(x + i * 50, 290);
                    box[i].Size = new Size(50, 100);
                    box[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i].Image = ch;
                    box[i].Update();
                    //this.Controls.Add(box[i]);
                    IF.Controls.Add(box[i]);
                    c_x++;
                }
                //zz += "\r\n";
                for (int i = 0; i < dow.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(dow[i], grayframe.PixelFormat);
                    //ch = con.Erodetion(ch);
                    string temp = Ocr(ch, false, true); // nhan dien so
                    zz += temp;
                    box[i + c_x].Location = new Point(x + i * 50, 390);
                    box[i + c_x].Size = new Size(50, 100);
                    box[i + c_x].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i + c_x].Image = ch;
                    box[i + c_x].Update();
                    //this.Controls.Add(box[i + c_x]);
                    IF.Controls.Add(box[i + c_x]);
                }
                bienso = zz.Replace("\n", "");
                bienso = bienso.Replace("\r", "");
                IF.textBox6.Text = zz;
                bienso_text = bienso;

            }
        }
        private string Ocr(Bitmap image_s, bool isFull, bool isNum = false)
        {
            string temp = "";
            Image<Gray, byte> src = new Image<Gray, byte>(image_s);
            double ratio = 1;
            while (true)
            {
                ratio = (double)CvInvoke.cvCountNonZero(src) / (src.Width * src.Height);
                if (ratio > 0.5) break;
                src = src.Dilate(2);
            }
            Bitmap image = src.ToBitmap();

            TesseractProcessor ocr;
            if (isFull)
                ocr = full_tesseract;
            else if (isNum)
                ocr = num_tesseract;
            else
                ocr = ch_tesseract;

            int cou = 0;
            ocr.Clear();
            ocr.ClearAdaptiveClassifier();
            temp = ocr.Apply(image);
            while (temp.Length > 3)
            {
                Image<Gray, byte> temp2 = new Image<Gray, byte>(image);
                temp2 = temp2.Erode(2);
                image = temp2.ToBitmap();
                ocr.Clear();
                ocr.ClearAdaptiveClassifier();
                temp = ocr.Apply(image);
                cou++;
                if (cou > 10)
                {
                    temp = "";
                    break;
                }
            }
            return temp;

        }
        public void ProcessImage(string urlImage)
        {
            PlateImagesList.Clear();
            PlateTextList.Clear();
            FileStream fs = new FileStream(urlImage, FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(fs);
            Bitmap image = new Bitmap(img);
            //pictureBox2.Image = image;
            IF.pictureBox2.Image = image;
            fs.Close();

            FindLicensePlate4(image, out Plate_Draw);

        }
        public static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            PointF offset = new PointF((float)image.Width / 2, (float)image.Height / 2);

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }
        #region FindLicensePlate
        public void FindLicensePlate2(Bitmap image)
        {
            if (image == null)
                return;
            Bitmap src;
            Image dst = image;
            Image<Bgr, byte> frame_b = null;
            Image<Bgr, byte> plate_b = null;
            double sum_b = 0;
            for (float i = -45; i <= 45; i = i + 5)
            {
                src = RotateImage(dst, i);
                PlateImagesList.Clear();
                Image<Bgr, byte> frame = new Image<Bgr, byte>(src);
                using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src))
                {


                    var faces = grayframe.DetectHaarCascade(new HaarCascade(Application.StartupPath + "\\output-hv-33-x25.xml"), 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(0, 0))[0];
                    foreach (var face in faces)
                    {
                        Image<Bgr, byte> tmp = frame.Copy();
                        tmp.ROI = face.rect;

                        frame.Draw(face.rect, new Bgr(Color.Red), 4);

                        PlateImagesList.Add(tmp.Resize(500, 500, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC, true));


                    }

                }
                if (PlateImagesList.Count != 0)
                {
                    Image<Gray, byte> gr = new Image<Gray, byte>(PlateImagesList[0].Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR).ToBitmap());
                    Gray cannyThreshold = new Gray(gr.GetAverage().Intensity);
                    Gray cannyThresholdLinking = new Gray(gr.GetAverage().Intensity);
                    Image<Gray, byte> cannyEdges = gr.Canny(cannyThreshold, cannyThresholdLinking);

                    double sum = 0;
                    for (int j = 0; j < cannyEdges.Height - 1; j++)
                    {
                        for (int k = 0; k < cannyEdges.Width - 1; k++)
                        {
                            if (j < 20 || j > 180 || k < 20 || k > 180)
                            {
                                sum += cannyEdges.Data[j, k, 0]; // tính tổng các điểm trắng ở viền ngoài
                            }
                            //else
                            //{
                            //    cannyEdges.Data[j, k, 0] = 0;
                            //}
                        }
                    }
                    //pictureBox4.Image = cannyEdges.ToBitmap();
                    //pictureBox4.Update();
                    if (sum_b == 0 || sum > sum_b)
                    {
                        frame_b = frame.Clone();
                        plate_b = PlateImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR).Clone();
                        sum_b = sum;
                    }
                }

            }
            if (plate_b != null)
            {
                PlateImagesList.Add(plate_b);
                pictureBox_VAO.Image = frame_b.ToBitmap();
                pictureBox_VAO.Update();
            }

        }
        public void FindLicensePlate(Bitmap image, out Image plateDraw)
        {
            plateDraw = null;
            Image<Bgr, byte> frame = new Image<Bgr, byte>(image);
            bool isface = false;
            using (Image<Gray, byte> grayframe = new Image<Gray, byte>(image))
            {


                var faces =
                       grayframe.DetectHaarCascade(new HaarCascade(Application.StartupPath + "\\output-hv-33-x25.xml"), 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(0, 0))[0];
                foreach (var face in faces)
                {
                    Image<Bgr, byte> tmp = frame.Copy();
                    tmp.ROI = face.rect;

                    frame.Draw(face.rect, new Bgr(Color.Blue), 2);

                    PlateImagesList.Add(tmp);

                    isface = true;
                }
                if (isface)
                {
                    Image<Bgr, byte> showimg = frame.Clone();
                    plateDraw = (Image)showimg.ToBitmap();
                    //showimg = frame.Resize(imageBox1.Width, imageBox1.Height, 0);
                    //pictureBox1.Image = showimg.ToBitmap();
                    IF.pictureBox2.Image = showimg.ToBitmap();
                    if (PlateImagesList.Count > 1)
                    {
                        for (int i = 1; i < PlateImagesList.Count; i++)
                        {
                            if (PlateImagesList[0].Width < PlateImagesList[i].Width)
                            {
                                PlateImagesList[0] = PlateImagesList[i];
                            }
                        }
                    }
                    PlateImagesList[0] = PlateImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                }


            }
        }
        public void FindLicensePlate4(Bitmap image, out Image plateDraw)
        {
            plateDraw = null;
            Image<Bgr, byte> frame;
            bool isface = false;
            Bitmap src;
            //pictureBox2.Image = new Image<Gray, byte>(image).ToBitmap();
            Image dst = image;
            HaarCascade haar = new HaarCascade(Application.StartupPath + "\\output-hv-33-x25.xml");
            for (float i = 0; i <= 20; i = i + 3)
            {
                for (float s = -1; s <= 1 && s + i != 1; s += 2)
                {
                    src = RotateImage(dst, i * s);
                    PlateImagesList.Clear();
                    frame = new Image<Bgr, byte>(src);
                    using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src))
                    {
                        var faces =
                       grayframe.DetectHaarCascade(haar, 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(0, 0))[0];
                        foreach (var face in faces)
                        {
                            Image<Bgr, byte> tmp = frame.Copy();
                            tmp.ROI = face.rect;

                            frame.Draw(face.rect, new Bgr(Color.Red), 4);

                            PlateImagesList.Add(tmp);

                            isface = true;
                        }
                        if (isface)
                        {
                            Image<Bgr, byte> showimg = frame.Clone();
                            plateDraw = (Image)showimg.ToBitmap();
                            //showimg = frame.Resize(imageBox1.Width, imageBox1.Height, 0);
                            //pictureBox1.Image = showimg.ToBitmap();
                            IF.pictureBox2.Image = showimg.ToBitmap();
                            if (PlateImagesList.Count > 1)
                            {
                                for (int k = 1; k < PlateImagesList.Count; k++)
                                {
                                    if (PlateImagesList[0].Width < PlateImagesList[k].Width)
                                    {
                                        PlateImagesList[0] = PlateImagesList[k];
                                    }
                                }
                            }
                            PlateImagesList[0] = PlateImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                            return;
                        }


                    }
                }
            }


        }
        public void FindLicensePlate3(Bitmap image)
        {
            if (image == null)
                return;
            Bitmap src;
            Image dst = image;
            Image<Bgr, byte> frame_b = null;
            Image<Bgr, byte> plate_b = null;
            double sum_b = 1000;
            HaarCascade haar = new HaarCascade(Application.StartupPath + "\\output-hv-33-x25.xml");
            for (float i = 0; i <= 35; i = i + 3)
            {
                for (float s = -1; s <= 1 && s + i != 1; s += 2)
                {
                    src = RotateImage(dst, i * s);
                    PlateImagesList.Clear();
                    Image<Bgr, byte> frame = new Image<Bgr, byte>(src);
                    using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src))
                    {


                        var faces = grayframe.DetectHaarCascade(haar, 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(0, 0))[0];
                        foreach (var face in faces)
                        {
                            Image<Bgr, byte> tmp = frame.Copy();
                            tmp.ROI = face.rect;

                            frame.Draw(face.rect, new Bgr(Color.Blue), 2);

                            PlateImagesList.Add(tmp.Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));

                            //imageBox1.Image = tmp;
                            //imageBox1.Update();

                        }
                        //Image<Bgr, Byte> showimg = new Image<Bgr, Byte>(image.Size);
                        //showimg = frame.Resize(imageBox1.Width, imageBox1.Height, 0);
                        //pictureBox1.Image = grayframe.ToBitmap();
                    }
                    if (PlateImagesList.Count != 0)
                    {
                        Image<Gray, byte> src2 = new Image<Gray, byte>(PlateImagesList[0].ToBitmap());
                        double thr = src2.GetAverage().Intensity;

                        double min = 0, max = 255;
                        if (thr - 50 > 0)
                        {
                            min = thr - 50;
                        }
                        if (thr + 50 < 255)
                        {
                            max = thr + 50;
                        }
                        for (double value = min; value <= max; value += 5)
                        {
                            src2 = new Image<Gray, byte>(PlateImagesList[0].ToBitmap());
                            int c = 0;
                            List<Rectangle> listR = new List<Rectangle>();
                            using (MemStorage storage = new MemStorage())
                            {
                                src2 = src2.ThresholdBinary(new Gray(value), new Gray(255));
                                Contour<Point> contours = src2.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage);
                                while (contours != null)
                                {

                                    Rectangle rect = contours.BoundingRectangle;
                                    double ratio = (double)rect.Width / rect.Height;
                                    if (rect.Width > 20 && rect.Width < 150
                                        && rect.Height > 80 && rect.Height < 180
                                        && ratio > 0.2 && ratio < 1.1)
                                    {
                                        c++;
                                        listR.Add(contours.BoundingRectangle);
                                    }
                                    contours = contours.HNext;
                                }
                            }
                            double sum = 1000;
                            if (c >= 2)
                            {
                                for (int u = 0; u < c; u++)
                                {
                                    for (int v = u + 1; v < c; v++)
                                    {
                                        if (Math.Abs(listR[u].Y - listR[v].Y) < sum)
                                        {

                                            sum = Math.Abs(listR[u].Y - listR[v].Y);
                                            if (sum < 4)
                                            {
                                                PlateImagesList.Add(PlateImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR).Clone());
                                                pictureBox_VAO.Image = frame.ToBitmap();
                                                pictureBox_VAO.Update();
                                                return;
                                            }
                                        }
                                    }
                                }

                            }

                            if (sum < sum_b)
                            {
                                frame_b = frame.Clone();
                                plate_b = PlateImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR).Clone();
                                sum_b = sum;
                            }
                        }
                    }
                }


            }
            if (plate_b != null)
            {
                PlateImagesList.Add(plate_b);
                pictureBox_VAO.Image = frame_b.ToBitmap();
                pictureBox_VAO.Update();
            }

        }
        #endregion

        #region Xe vao
        private void XeVao(string cardID)
        {
            if (isGioiHanXeTrongBai)
            {
                string[] soXeTrongBai = Lib.Image.IImage.ReadAllFileName("./IN");
                if (soXeTrongBai.Length >= soChoDeXe)
                {
                    MessageBox.Show("Số lượng xe trong bãi đã vượt giới hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            

            bool theDaDangKy = false;
            bool xeDangTrongBai = false;
            
            txtSoTheVao.Text = cardID;
            try
            {
                cardIns = Lib.Image.IImage.ReadAllFileName("./IN/");

                foreach (string item in cardIns)
                {
                    if (item.Replace(".txt", "").Replace("./IN/", "") == cardID)
                    {
                        xeDangTrongBai = true;
                    }
                }
                if (lstCard != null)//cards chứa cả thẻ, cả biển số
                {
                    foreach (CardInfo item in lstCard)
                    {
                        if (item.MaThe == cardID)
                        {
                            theDaDangKy = true;
                        }
                    }
                }
                if (theDaDangKy)
                {
                    if (!xeDangTrongBai)
                    {
                        i = 0;
                        lblTimeIn.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        txtSoTheVao.Text = TheVao;
                        if (capture != null)
                        {
                            timer1.Enabled = false;
                            pictureBox_VAO_2.Image = null;
                            IF.pictureBox2.Image = null;
                            capture.QueryFrame().Save("aa.bmp");
                            FileStream fs = new FileStream(m_path + "aa.bmp", FileMode.Open, FileAccess.Read);
                            Image temp = Image.FromStream(fs);
                            fs.Close();
                            pictureBox_VAO_2.Image = temp;
                            pictureBox_VAO_2.Update();

                            timer1.Enabled = true;
                       
                            Image temp1;
                            string temp2, temp3;
                            Reconize(m_path + "aa.bmp", out temp1, out temp2, out temp3);
                            pictureBox_VAO_3.Image = temp1; 
                            string temp4 = "";
                            if (temp3 == "")
                                txtBienSoVao.Text = "Unknow";
                            else
                            {

                                if (temp3.Length > 3)
                                {

                                    if (Lib.Image.IImage.CheckPlate1(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate2(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate3(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate4(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate5(temp3, ref temp4))
                                    {
                                        txtBienSoVao.Text = temp4;
                                    }
                                    else txtBienSoVao.Text = temp3;
                                }
                                else txtBienSoVao.Text = "Unknow";
                            }
                            foreach (CardInfo item in lstCard)
                            {
                                if (item.MaThe == cardID && (Lib.Image.IImage.CheckNumber(item.BienSo, txtBienSoVao.Text.Trim(), 6) || item.BienSo == txtBienSoVao.Text.Trim()))
                                {
                                    if (sp.IsOpen)
                                    {
                                        sp.WriteLine("Barrier_Vao_1");
                                        lblStatusBarrierVao.Text = "Barrier đang mở";
                                        timerVao.Enabled = true;
                                    }
                                    txtBienSoVao.Text = item.BienSo;
                                    string fName = "Vao_" + DateTime.Now.ToString("HHmmss") + ".jpg";
                                    string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                                    Bitmap bitmap = new Bitmap(pictureBox_VAO_2.Image);
                                    //MessageBox.Show(path);
                                    bitmap.Save(path);
                                    Lib.Image.IImage.AddInfoCarIn(cardID, txtBienSoVao.Text.Trim('\n').Trim('\r'), DateTime.Now, path);

                                    if (isKiemTraChoTrong)
                                    {
                                        //Kiểm tra chỗ trống, đẩy số ngẫu nhiên
                                        KiemTraViTriTrongXeVao(cardID);
                                        LoadViTri();
                                    }
                                    break;
                                }
                                else if (item.MaThe == cardID && item.BienSo != txtBienSoVao.Text.Trim())
                                {
                                    DialogResult dr = MessageBox.Show("Xe chưa đặt trước. Cho xe vào?", "Thông báo", MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.Yes)
                                    {
                                        if (sp.IsOpen)
                                        {
                                            sp.WriteLine("Barrier_Vao_1");
                                            lblStatusBarrierVao.Text = "Barrier đang mở";
                                            timerVao.Enabled = true;
                                        }
                                        string fName = "Vao_" + DateTime.Now.ToString("HHmmss") + ".jpg";
                                        string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                                        Bitmap bitmap = new Bitmap(pictureBox_VAO_2.Image);
                                        //MessageBox.Show(path);
                                        bitmap.Save(path);
                                        Lib.Image.IImage.AddInfoCarIn(cardID, txtBienSoVao.Text.Trim('\n').Trim('\r'), DateTime.Now, path);

                                        if (isKiemTraChoTrong)
                                        {
                                            //Kiểm tra chỗ trống, đẩy số ngẫu nhiên
                                            KiemTraViTriTrongXeVao(cardID);
                                            LoadViTri();
                                        }
                                    }
                                    break;
                                }
                            }
                            
                        }
                    }
                    else
                    {
                        panelVao.Visible = true;
                        lblWarningVao.Text = "Thẻ đang trong bãi";
                    }

                }
                else
                {
                    panelVao.Visible = true;
                    lblWarningVao.Text = "Thẻ chưa đăng ký";
                }
                timerIn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void ChupAnhXeVao(string cardID)
        {
            bool theDaDangKy = false;
            bool xeDangTrongBai = false;
            try
            {
                cardIns = Lib.Image.IImage.ReadAllFileName("./IN/");

                foreach (string item in cardIns)
                {

                    if (item.Replace(".txt", "").Replace("./IN/", "") == cardID)
                    {
                        xeDangTrongBai = true;
                    }
                }
                if (cards != null)
                {
                    foreach (string item in cards)
                    {
                        if (item == cardID)
                        {
                            theDaDangKy = true;
                        }
                    }
                }
                if (theDaDangKy)
                {
                    if (!xeDangTrongBai)
                    {
                        lblTimeIn.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        txtSoTheVao.Text = TheVao;
                        string fName = "Vao_" + DateTime.Now.ToString("HHmmss") + ".jpg";
                        string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                        Bitmap bitmap = new Bitmap(pictureBox_VAO_2.Image);
                        bitmap.Save(path);
                        Lib.Image.IImage.AddInfoCarIn(cardID, txtBienSoVao.Text.Trim('\n').Trim('\r'), DateTime.Now, path);
                        timerIn.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thẻ xe này đang trong bãi gửi xe");
                    }

                }
                else
                {
                    MessageBox.Show("Thẻ chưa được đăng ký");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        #endregion
        #region Xe ra
        private void XeRa(string theRa)
        {
            string[] lines = null;
            lblTimeOut.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtSoTheRa.Text = theRa;
            if (File.Exists("./IN/" + theRa + ".txt"))
            {
                lines = Lib.Image.IImage.ReadAllLine("./IN/" + theRa + ".txt");
                if (lines.Length >= 3)
                {
                    DateTime dt = DateTime.Parse(lines[1]);
                    txtDoiChieuBienSoVao.Text = lines[0];
                    lblCompare_TimeOut.Text = dt.ToString("dd/MM/yyyy HH:mm:ss");
                    pictureBox_DoiChieuVao.Image = Image.FromFile(lines[2]);

                    try
                    {
                        lblTimeOut.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        lblThoiGianGuiXe.Text = "Thời gian gửi xe trong bãi: " + Lib.Image.IImage.TimeSub(lines[1], DateTime.Now.ToString());
                        lblFee.Text = PhiGuiXe + " vnd";

                        txtSoTheRa.Text = TheRa;
                        i = 1;
                        if (capture2 != null)
                        {
                            timer1.Enabled = false;
                            pictureBox_RA_2.Image = null;
                            IF.pictureBox2.Image = null;
                            capture2.QueryFrame().Save("bb.bmp");
                            FileStream fs = new FileStream(m_path + "bb.bmp", FileMode.Open, FileAccess.Read);
                            Image temp = Image.FromStream(fs);
                            fs.Close();
                            pictureBox_RA_2.Image = temp;
                            pictureBox_RA_2.Update();
                            timer1.Enabled = true;
                            Image temp1;
                            string temp2, temp3;
                            Reconize(m_path + "bb.bmp", out temp1, out temp2, out temp3);
                            //pictureBox_RA_3.Image = temp;
                            if (temp3 == "")
                                txtBienSoRa.Text = "Unknow";
                            else
                            {
                                if (temp3.Length > 3)
                                {
                                    string temp4 = "";
                                    if (Lib.Image.IImage.CheckPlate1(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate2(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate3(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate4(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else if (Lib.Image.IImage.CheckPlate5(temp3, ref temp4))
                                    {
                                        txtBienSoRa.Text = temp4;
                                    }
                                    else txtBienSoRa.Text = temp3;
                                }
                                else
                                {
                                    txtBienSoRa.Text = "Unknow";
                                }

                            }
                            //Nếu đúng biển số khi vào thì ...
                            if (Lib.Image.IImage.CheckNumber(lines[0], txtBienSoRa.Text.Trim('\n').Trim('\r'), 6) || txtBienSoRa.Text.Trim('\n').Trim('\r') == lines[0])
                            {
                                if (sp.IsOpen)
                                {
                                    sp.WriteLine("Barrier_Ra_1");
                                    lblStatusBarrierRa.Text = "Barrier đang mở";
                                    timerRa.Enabled = true;
                                }

                                #region Hiển thị đối chiếu
                                string doanhThu = Lib.Image.IImage.LayDoanhThu(DateTime.Now);
                                txtBienSoRa.Text = lines[0];
                                if (string.IsNullOrEmpty(doanhThu))
                                {
                                    doanhThu = "0";
                                }
                                string doanhThuMoi = (Int32.Parse(doanhThu) + Int32.Parse(PhiGuiXe)).ToString();
                                //MessageBox.Show(doanhThuMoi);
                                Lib.Image.IImage.LuuDoanhThu(DateTime.Now, doanhThuMoi);
                                #endregion

                                string fName = "Ra_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".jpg";
                                string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                                Bitmap bitmap = new Bitmap(pictureBox_RA_2.Image);

                                bitmap.Save(path);
                                Lib.Image.IImage.AddInfoCarOut(TheRa, txtBienSoRa.Text.Trim('\n').Trim('\r'), DateTime.Now, path, lblThoiGianGuiXe.Text);
                                if (File.Exists("./OutCompleted/" + theRa + ".txt"))
                                {
                                    Lib.Image.IImage.MoveFileInfo(Application.StartupPath + "/IN/" + theRa + ".txt", Application.StartupPath + "/OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy") + "/" + DateTime.Now.ToString("HH_mm_ss") + theRa + ".txt");
                                }
                                else
                                {
                                    if (!Directory.Exists("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy")))
                                    {
                                        Directory.CreateDirectory("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy"));
                                    }
                                    Lib.Image.IImage.MoveFileInfo(Application.StartupPath + "/IN/" + theRa + ".txt", Application.StartupPath + "/OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy") + "/" + DateTime.Now.ToString("HH_mm_ss") + theRa + ".txt");
                                }    
                                    
                            }
                            else
                            {
                                DialogResult dr = MessageBox.Show("Khác biển số lúc vào, bạn có muốn cho ra?", "Thông báo", MessageBoxButtons.YesNo);
                                if (dr == DialogResult.Yes)
                                {
                                    #region Hiển thị đối chiếu
                                    if (sp.IsOpen)
                                    {
                                        sp.WriteLine("Barrier_Ra_1");
                                        lblStatusBarrierRa.Text = "Barrier đang mở";
                                        timerRa.Enabled = true;
                                    }
                                    string doanhThu = Lib.Image.IImage.LayDoanhThu(DateTime.Now);

                                    if (string.IsNullOrEmpty(doanhThu))
                                    {
                                        doanhThu = "0";
                                    }
                                    string doanhThuMoi = (Int32.Parse(doanhThu) + Int32.Parse(PhiGuiXe)).ToString();
                                    //MessageBox.Show(doanhThuMoi);
                                    Lib.Image.IImage.LuuDoanhThu(DateTime.Now, doanhThuMoi);
                                    #endregion
                                    string fName = "Ra_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".jpg";
                                    string path = Lib.Image.IImage.ImageOriginFolderPath(fName, @".\DuLieuAnh");
                                    Bitmap bitmap = new Bitmap(pictureBox_RA_2.Image);

                                    bitmap.Save(path);
                                    Lib.Image.IImage.AddInfoCarOut(TheRa, txtBienSoRa.Text.Trim('\n').Trim('\r'), DateTime.Now, path, lblThoiGianGuiXe.Text);
                                    if (File.Exists("./OutCompleted/" + theRa + ".txt"))
                                    {
                                        Lib.Image.IImage.MoveFileInfo(Application.StartupPath + "/IN/" + theRa + ".txt", Application.StartupPath + "/OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy") + "/" + DateTime.Now.ToString("HH_mm_ss") + theRa + ".txt");
                                    }
                                    else
                                    {
                                        if (!Directory.Exists("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy")))
                                        {
                                            Directory.CreateDirectory("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy"));
                                        }
                                        Lib.Image.IImage.MoveFileInfo(Application.StartupPath + "/IN/" + theRa + ".txt", Application.StartupPath + "/OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy") + "/" + DateTime.Now.ToString("HH_mm_ss") + theRa + ".txt");
                                    }
                                }
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw ex;
                    }

                }

            }
            else
            {
                panelRa.Visible = true;
                lblWarningRa.Text = "Thẻ chưa gửi trong bãi";
            }
            timerOut.Enabled = true;

        }
        #endregion
        public static bool Test()
        {
            bool ret = false;
            if (!Directory.Exists("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy")))
            {
                Directory.CreateDirectory("./OutCompleted/" + DateTime.Now.ToString("dd_MM_yyyy"));
                ret = true;
            }
            return ret;
        }
        private void btnChupAnhRa_Click(object sender, EventArgs e)
        {
            isGiaLap = true;
            i = 1;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image (*.bmp; *.jpg; *.jpeg; *.png) |*.bmp; *.jpg; *.jpeg; *.png|All files (*.*)|*.*||";
            dlg.InitialDirectory = Application.StartupPath + "\\ImageTest";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string startupPath = dlg.FileName;
            frmNhapMaThe frm = new frmNhapMaThe();
            frm.ShowDialog(this);

            if (string.IsNullOrEmpty(TheRa))
            {
                return;
            }

            pictureBox_RA.Image = Image.FromFile(startupPath);
            
            if (TheRa.Trim() != null)
            {
                XeRa(TheRa, startupPath);
            }
            else pictureBox_RA.Image = null;
            logger.Info("Giả lập xe ra");
        }

        #region Key
        private void frmGiaoDien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {

            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                ClearViTri();
                LoadViTri();
            }
            if (e.Control && e.KeyCode == Keys.I)
            {
                //if (EventInCard != null)
                //{
                //    EventInCard(sender, e);
                //}
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                //if (EventOutCard != null)
                //{
                //    EventOutCard(sender, e);
                //}
            }
        }
        #endregion

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmGiaoDien_Resize(object sender, EventArgs e)
        {
            panel12.Height = menuStrip1.Height;
        }

        private void thẻXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
            }
            timerCheck.Enabled = false;
            frmData frm = new frmData();
            frm.ShowDialog(this);
            CheckConnect();
            timerCheck.Enabled = true;
        }
        void ClearLaneIn()
        {
            if (isGiaLap)
            {
                pictureBox_VAO.Image = null;
                lblStatusBarrierVao.Text = "Barrier đang đóng";
            }
            pictureBox_VAO_2.Image = null;
            pictureBox_VAO_3.Image = null;
            panelVao.Visible = false;
            txtBienSoVao.Text = "";
            txtSoTheVao.Text = "";
            lblTimeIn.Text = "__/__/____ __:__:__";
        }
        void ClearLaneOut()
        {
            if (isGiaLap)
            {
                pictureBox_RA.Image = null;
                lblStatusBarrierRa.Text = "Barrier đang đóng";
            }

            pictureBox_RA_2.Image = null;
            pictureBox_RA_3.Image = null;
            panelRa.Visible = false;
            txtBienSoRa.Text = "";
            txtSoTheRa.Text = "";
            txtDoiChieuBienSoVao.Text = "";
            lblTimeOut.Text = "__/__/____ __:__:__";
        }
        void ClearLaneCompare()
        {
            pictureBox_DoiChieuVao.Image = null;
            lblFee.Text = "";
            lblThoiGianGuiXe.Text = "Thời gian gửi xe trong bãi: ";
            lblCompare_TimeOut.Text = "__/__/____ __:__:__";
        }

        private bool CheckConnect()
        {
            try
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                }
                sp.PortName = Port;
                sp.BaudRate = Convert.ToInt32(BaudRate);
                sp.DataBits = 8;
                sp.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                dataIn = sp.ReadLine();
                this.Invoke(new EventHandler(SetText));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (CheckConnect())
            {
                MessageBox.Show("Cổng serial đang mở");
            }
            else MessageBox.Show("Kiểm tra lại cổng serial hoặc thiết bị");
        }

        private void frmGiaoDien_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Close();
            logger.Info("Stop Program");
            logger.Info("------------------------------------------");
        }

        private void lblGas_Click(object sender, EventArgs e)
        {
            //foreach (var item in lstCard)
            //{
            //    MessageBox.Show(item.BienSo + " " + item.MaThe);
            //}
        }

        private void btnMoBarrierVao_Click(object sender, EventArgs e)
        {
            if (CheckConnect())
            {
                if (btnMoBarrierVao.Text == "Mở barrier")
                {
                    sp.WriteLine("Barrier_Vao_1");
                    lblStatusBarrierVao.Text = "Barrier đang mở";
                    btnMoBarrierVao.Text = "Đóng barrier";
                    logger.Info("Mở barrier vào");
                }
                else
                {
                    sp.WriteLine("Barrier_Vao_0");
                    lblStatusBarrierVao.Text = "Barrier đang đóng";
                    btnMoBarrierVao.Text = "Mở barrier";
                    logger.Info("Đóng barrier vào");
                }
            }

        }
        private void btnMoBarrierRa_Click(object sender, EventArgs e)
        {
            if (CheckConnect())
            {
                if (btnMoBarrierRa.Text == "Mở barrier")
                {
                    sp.WriteLine("Barrier_Ra_1");
                    lblStatusBarrierRa.Text = "Barrier đang mở";
                    btnMoBarrierRa.Text = "Đóng barrier";
                    logger.Info("Mở barrier ra");
                }
                else
                {
                    sp.WriteLine("Barrier_Ra_0");
                    lblStatusBarrierRa.Text = "Barrier đang đóng";
                    btnMoBarrierRa.Text = "Mở barrier";
                    logger.Info("Đóng barrier ra");
                }
            }
        }
        private void btnTatCanhBao_Click(object sender, EventArgs e)
        {

        }

        #region timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            //this.Text = "Smart Parking Version" + this.ProductVersion + " - " + DateTime.Now.ToString("HH:mm:ss");
        }
        private void timerCanhBao_Tick(object sender, EventArgs e)
        {
            timerCanhBao.Enabled = false;
            lblGas.Text = "Ổn định";
            lblGas.ForeColor = Color.Blue;
            btnTatCanhBao.Visible = false;
        }

        private void timerVao_Tick(object sender, EventArgs e)
        {
            if (CheckConnect())
            {
                sp.WriteLine("Barrier_Vao_0");
                lblStatusBarrierVao.Text = "Barrier đang đóng";
                timerVao.Enabled = false;
                logger.Info("Close barrier");
            }
        }

        private void timerRa_Tick(object sender, EventArgs e)
        {
            if (CheckConnect())
            {
                sp.WriteLine("Barrier_Ra_0");
                lblStatusBarrierRa.Text = "Barrier đang đóng";
                timerRa.Enabled = false;
            }
        }

        private void timerOut_Tick(object sender, EventArgs e)
        {
            ClearLaneOut();
            ClearLaneCompare();
            timerOut.Enabled = false;
        }

        private void timerIn_Tick(object sender, EventArgs e)
        {
            ClearLaneIn();
            timerIn.Enabled = false;
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (CheckConnect())
            {
                lblStatus.Text = "Port: " + Port + " OK";
                lblStatus.ForeColor = Color.Blue;
            }
            else
            {
                lblStatus.Text = "Port: " + Port + " Fail";
                lblStatus.ForeColor = Color.Red;
            }
        }
        #endregion

        private void lblStatusBarrierVao_TextChanged(object sender, EventArgs e)
        {
            if (lblStatusBarrierVao.Text == "Barrier đang đóng")
            {
                panelBarrierVao.BackColor = Color.Yellow;
            }
            else
            {
                panelBarrierVao.BackColor = Color.Green;
            }
        }

        private void lblStatusBarrierRa_TextChanged(object sender, EventArgs e)
        {
            if (lblStatusBarrierRa.Text == "Barrier đang đóng")
            {
                panelBarrierRa.BackColor = Color.Yellow;
            }
            else
            {
                panelBarrierRa.BackColor = Color.Green;
            }
        }

        private void lblGas_TextChanged(object sender, EventArgs e)
        {

        }

        private void miLogin_Click(object sender, EventArgs e)
        {
            if (miLogin.Text == "Đăng nhập")
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog(this);
                if (Login)
                {
                    miCauHinh.Enabled = true;
                    miBaoCao.Enabled = true;
                    miDuLieu.Enabled = true;
                    miVaoRa.Enabled = true;

                    btnMoBarrierVao.Enabled = true;
                    btnMoBarrierRa.Enabled = true;
                    miLogin.Text = "Đăng xuất";

                    logger.Info("Login success");
                }

            }
            else if (miLogin.Text == "Đăng xuất")
            {
                miCauHinh.Enabled = false;
                miBaoCao.Enabled = false;
                miDuLieu.Enabled = false;
                miVaoRa.Enabled = false;

                btnMoBarrierVao.Enabled = false;
                btnMoBarrierRa.Enabled = false;
                Login = false;

                miLogin.Text = "Đăng nhập";
                logger.Info("Logout success");
            }
        }

        private void báoCáoLượtXeVàoRaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Open counting report");
            frmBaoCaoVaoRa frm = new frmBaoCaoVaoRa();
            frm.Show();
        }

        private void miDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_VAO_3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_VAO_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login mform = new Login();
            mform.Show();
            this.Hide();
        }

        private void text_PlateIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_VAO_2_Click(object sender, EventArgs e)
        {

        }
    }
}
