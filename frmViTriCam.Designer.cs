
namespace Auto_parking
{
    partial class frmViTriCam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nruCam1 = new System.Windows.Forms.NumericUpDown();
            this.nruCam2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nruCam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nruCam2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera 1:";
            // 
            // button1
            // 
            this.button1.Image = global::Auto_parking.Properties.Resources.accept;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(120, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nruCam1
            // 
            this.nruCam1.Location = new System.Drawing.Point(74, 11);
            this.nruCam1.Name = "nruCam1";
            this.nruCam1.Size = new System.Drawing.Size(40, 20);
            this.nruCam1.TabIndex = 3;
            // 
            // nruCam2
            // 
            this.nruCam2.Location = new System.Drawing.Point(74, 39);
            this.nruCam2.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nruCam2.Name = "nruCam2";
            this.nruCam2.Size = new System.Drawing.Size(40, 20);
            this.nruCam2.TabIndex = 3;
            this.nruCam2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Camera 2:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 65);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(152, 28);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Thiết lập vị trí camera vào ra";
            // 
            // frmViTriCam
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(197, 107);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.nruCam2);
            this.Controls.Add(this.nruCam1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViTriCam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập camera";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmViTriCam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nruCam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nruCam2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nruCam1;
        private System.Windows.Forms.NumericUpDown nruCam2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}