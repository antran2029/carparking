using AForge.Video;
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
    public partial class CameraPhone : Form
    {
        MJPEGStream stream;
        public CameraPhone()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            stream = new MJPEGStream(txtIP.Text);
            stream.NewFrame += stream_NewFrame;
            stream.Start();
        }

        private void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bmp;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stream.Stop();
        }

        private void CameraPhone_Load(object sender, EventArgs e)
        {

        }
    }
}
