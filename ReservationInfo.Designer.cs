
namespace Auto_parking
{
    partial class ReservationInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Datelbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ReserIdtb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.Datein = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Dateout = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ReservationGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Reservationsearchtb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.RoomDeletebtn = new System.Windows.Forms.Button();
            this.RoomEditbtn = new System.Windows.Forms.Button();
            this.AddRoomBtn = new System.Windows.Forms.Button();
            this.Clientcb = new System.Windows.Forms.ComboBox();
            this.slotcb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Datelbl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 100);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCyan;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 100);
            this.panel2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(849, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightCyan;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(231, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(305, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "Booking Information";
            // 
            // Datelbl
            // 
            this.Datelbl.AutoSize = true;
            this.Datelbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Datelbl.Location = new System.Drawing.Point(760, 70);
            this.Datelbl.Name = "Datelbl";
            this.Datelbl.Size = new System.Drawing.Size(44, 21);
            this.Datelbl.TabIndex = 1;
            this.Datelbl.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(315, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservation Informations";
            // 
            // ReserIdtb
            // 
            this.ReserIdtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ReserIdtb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReserIdtb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ReserIdtb.HintForeColor = System.Drawing.Color.Empty;
            this.ReserIdtb.HintText = "";
            this.ReserIdtb.isPassword = false;
            this.ReserIdtb.LineFocusedColor = System.Drawing.Color.Red;
            this.ReserIdtb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.ReserIdtb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.ReserIdtb.LineThickness = 3;
            this.ReserIdtb.Location = new System.Drawing.Point(31, 160);
            this.ReserIdtb.Margin = new System.Windows.Forms.Padding(4);
            this.ReserIdtb.Name = "ReserIdtb";
            this.ReserIdtb.Size = new System.Drawing.Size(189, 31);
            this.ReserIdtb.TabIndex = 8;
            this.ReserIdtb.Text = "Reservation Id";
            this.ReserIdtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Datein
            // 
            this.Datein.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datein.Location = new System.Drawing.Point(112, 351);
            this.Datein.Name = "Datein";
            this.Datein.Size = new System.Drawing.Size(170, 27);
            this.Datein.TabIndex = 11;
            this.Datein.ValueChanged += new System.EventHandler(this.Datein_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(26, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "DateIn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(26, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "DateOut";
            // 
            // Dateout
            // 
            this.Dateout.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dateout.Location = new System.Drawing.Point(113, 398);
            this.Dateout.Name = "Dateout";
            this.Dateout.Size = new System.Drawing.Size(170, 27);
            this.Dateout.TabIndex = 13;
            this.Dateout.ValueChanged += new System.EventHandler(this.Dateout_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(867, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ReservationGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.ReservationGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ReservationGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReservationGridView.BackgroundColor = System.Drawing.Color.White;
            this.ReservationGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReservationGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ReservationGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReservationGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ReservationGridView.ColumnHeadersHeight = 24;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ReservationGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReservationGridView.EnableHeadersVisualStyles = false;
            this.ReservationGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ReservationGridView.Location = new System.Drawing.Point(378, 160);
            this.ReservationGridView.Name = "ReservationGridView";
            this.ReservationGridView.RowHeadersVisible = false;
            this.ReservationGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReservationGridView.Size = new System.Drawing.Size(559, 451);
            this.ReservationGridView.TabIndex = 26;
            this.ReservationGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.ReservationGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ReservationGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ReservationGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ReservationGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ReservationGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ReservationGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ReservationGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ReservationGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.ReservationGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ReservationGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReservationGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.ReservationGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ReservationGridView.ThemeStyle.HeaderStyle.Height = 24;
            this.ReservationGridView.ThemeStyle.ReadOnly = false;
            this.ReservationGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ReservationGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ReservationGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.ReservationGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ReservationGridView.ThemeStyle.RowsStyle.Height = 22;
            this.ReservationGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ReservationGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ReservationGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReservationGridView_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(750, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 31);
            this.button1.TabIndex = 31;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reservationsearchtb
            // 
            this.Reservationsearchtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Reservationsearchtb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reservationsearchtb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Reservationsearchtb.HintForeColor = System.Drawing.Color.Empty;
            this.Reservationsearchtb.HintText = "";
            this.Reservationsearchtb.isPassword = false;
            this.Reservationsearchtb.LineFocusedColor = System.Drawing.Color.Red;
            this.Reservationsearchtb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.Reservationsearchtb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.Reservationsearchtb.LineThickness = 3;
            this.Reservationsearchtb.Location = new System.Drawing.Point(606, 113);
            this.Reservationsearchtb.Margin = new System.Windows.Forms.Padding(4);
            this.Reservationsearchtb.Name = "Reservationsearchtb";
            this.Reservationsearchtb.Size = new System.Drawing.Size(151, 31);
            this.Reservationsearchtb.TabIndex = 30;
            this.Reservationsearchtb.Text = "ReservationSearch";
            this.Reservationsearchtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // RoomDeletebtn
            // 
            this.RoomDeletebtn.FlatAppearance.BorderSize = 0;
            this.RoomDeletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RoomDeletebtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RoomDeletebtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.RoomDeletebtn.Location = new System.Drawing.Point(194, 486);
            this.RoomDeletebtn.Name = "RoomDeletebtn";
            this.RoomDeletebtn.Size = new System.Drawing.Size(107, 37);
            this.RoomDeletebtn.TabIndex = 35;
            this.RoomDeletebtn.Text = "DELETE";
            this.RoomDeletebtn.UseVisualStyleBackColor = true;
            this.RoomDeletebtn.Click += new System.EventHandler(this.RoomDeletebtn_Click);
            // 
            // RoomEditbtn
            // 
            this.RoomEditbtn.FlatAppearance.BorderSize = 0;
            this.RoomEditbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RoomEditbtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RoomEditbtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.RoomEditbtn.Location = new System.Drawing.Point(113, 486);
            this.RoomEditbtn.Name = "RoomEditbtn";
            this.RoomEditbtn.Size = new System.Drawing.Size(75, 37);
            this.RoomEditbtn.TabIndex = 34;
            this.RoomEditbtn.Text = "EDIT";
            this.RoomEditbtn.UseVisualStyleBackColor = true;
            this.RoomEditbtn.Click += new System.EventHandler(this.RoomEditbtn_Click);
            // 
            // AddRoomBtn
            // 
            this.AddRoomBtn.FlatAppearance.BorderSize = 0;
            this.AddRoomBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRoomBtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddRoomBtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.AddRoomBtn.Location = new System.Drawing.Point(31, 486);
            this.AddRoomBtn.Name = "AddRoomBtn";
            this.AddRoomBtn.Size = new System.Drawing.Size(75, 37);
            this.AddRoomBtn.TabIndex = 33;
            this.AddRoomBtn.Text = "ADD";
            this.AddRoomBtn.UseVisualStyleBackColor = true;
            this.AddRoomBtn.Click += new System.EventHandler(this.AddRoomBtn_Click);
            // 
            // Clientcb
            // 
            this.Clientcb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clientcb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Clientcb.FormattingEnabled = true;
            this.Clientcb.Location = new System.Drawing.Point(105, 227);
            this.Clientcb.Name = "Clientcb";
            this.Clientcb.Size = new System.Drawing.Size(189, 27);
            this.Clientcb.TabIndex = 36;
            this.Clientcb.Text = "ClientName";
            // 
            // slotcb
            // 
            this.slotcb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slotcb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.slotcb.FormattingEnabled = true;
            this.slotcb.Location = new System.Drawing.Point(105, 288);
            this.slotcb.Name = "slotcb";
            this.slotcb.Size = new System.Drawing.Size(189, 27);
            this.slotcb.TabIndex = 37;
            this.slotcb.Text = "SlotNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(27, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 22);
            this.label4.TabIndex = 38;
            this.label4.Text = "Client";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(27, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 22);
            this.label5.TabIndex = 39;
            this.label5.Text = "Slot";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button2.Location = new System.Drawing.Point(105, 529);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 37);
            this.button2.TabIndex = 40;
            this.button2.Text = "BACK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ReservationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 673);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.slotcb);
            this.Controls.Add(this.Clientcb);
            this.Controls.Add(this.RoomDeletebtn);
            this.Controls.Add(this.RoomEditbtn);
            this.Controls.Add(this.AddRoomBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Reservationsearchtb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ReservationGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Dateout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Datein);
            this.Controls.Add(this.ReserIdtb);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReservationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReservationInfo";
            this.Load += new System.EventHandler(this.ReservationInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Datelbl;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ReserIdtb;
        private System.Windows.Forms.DateTimePicker Datein;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Dateout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView ReservationGridView;
        private System.Windows.Forms.Button button1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox Reservationsearchtb;
        private System.Windows.Forms.Button RoomDeletebtn;
        private System.Windows.Forms.Button RoomEditbtn;
        private System.Windows.Forms.Button AddRoomBtn;
        private System.Windows.Forms.ComboBox Clientcb;
        private System.Windows.Forms.ComboBox slotcb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}