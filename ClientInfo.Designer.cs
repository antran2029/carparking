
namespace Auto_parking
{
    partial class ClientInfo
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Datelbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientidtbl = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.clientnametb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.clientphonetb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.clientctrycb = new System.Windows.Forms.ComboBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.Editbtn = new System.Windows.Forms.Button();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.ClientSearchtb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ClientGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.Datelbl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 100);
            this.panel1.TabIndex = 0;
            // 
            // Datelbl
            // 
            this.Datelbl.AutoSize = true;
            this.Datelbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Datelbl.Location = new System.Drawing.Point(849, 65);
            this.Datelbl.Name = "Datelbl";
            this.Datelbl.Size = new System.Drawing.Size(44, 21);
            this.Datelbl.TabIndex = 1;
            this.Datelbl.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(343, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Information";
            // 
            // clientidtbl
            // 
            this.clientidtbl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.clientidtbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientidtbl.ForeColor = System.Drawing.Color.DodgerBlue;
            this.clientidtbl.HintForeColor = System.Drawing.Color.Empty;
            this.clientidtbl.HintText = "";
            this.clientidtbl.isPassword = false;
            this.clientidtbl.LineFocusedColor = System.Drawing.Color.Red;
            this.clientidtbl.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.clientidtbl.LineMouseHoverColor = System.Drawing.Color.Red;
            this.clientidtbl.LineThickness = 3;
            this.clientidtbl.Location = new System.Drawing.Point(43, 126);
            this.clientidtbl.Margin = new System.Windows.Forms.Padding(4);
            this.clientidtbl.Name = "clientidtbl";
            this.clientidtbl.Size = new System.Drawing.Size(189, 31);
            this.clientidtbl.TabIndex = 1;
            this.clientidtbl.Text = "ClientId";
            this.clientidtbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // clientnametb
            // 
            this.clientnametb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.clientnametb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientnametb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.clientnametb.HintForeColor = System.Drawing.Color.Empty;
            this.clientnametb.HintText = "";
            this.clientnametb.isPassword = false;
            this.clientnametb.LineFocusedColor = System.Drawing.Color.Red;
            this.clientnametb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.clientnametb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.clientnametb.LineThickness = 3;
            this.clientnametb.Location = new System.Drawing.Point(43, 186);
            this.clientnametb.Margin = new System.Windows.Forms.Padding(4);
            this.clientnametb.Name = "clientnametb";
            this.clientnametb.Size = new System.Drawing.Size(189, 31);
            this.clientnametb.TabIndex = 2;
            this.clientnametb.Text = "ClientName";
            this.clientnametb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // clientphonetb
            // 
            this.clientphonetb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.clientphonetb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientphonetb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.clientphonetb.HintForeColor = System.Drawing.Color.Empty;
            this.clientphonetb.HintText = "";
            this.clientphonetb.isPassword = false;
            this.clientphonetb.LineFocusedColor = System.Drawing.Color.Red;
            this.clientphonetb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.clientphonetb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.clientphonetb.LineThickness = 3;
            this.clientphonetb.Location = new System.Drawing.Point(43, 261);
            this.clientphonetb.Margin = new System.Windows.Forms.Padding(4);
            this.clientphonetb.Name = "clientphonetb";
            this.clientphonetb.Size = new System.Drawing.Size(189, 31);
            this.clientphonetb.TabIndex = 3;
            this.clientphonetb.Text = "FromTo";
            this.clientphonetb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // clientctrycb
            // 
            this.clientctrycb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientctrycb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.clientctrycb.FormattingEnabled = true;
            this.clientctrycb.Items.AddRange(new object[] {
            "INDIA",
            "SPAIN",
            "USA",
            "CHINA",
            "FRANCE",
            "VIETNAM",
            "ZAMBIA",
            "NIGERIA",
            "CONGO"});
            this.clientctrycb.Location = new System.Drawing.Point(43, 327);
            this.clientctrycb.Name = "clientctrycb";
            this.clientctrycb.Size = new System.Drawing.Size(189, 27);
            this.clientctrycb.TabIndex = 4;
            this.clientctrycb.Text = "Country";
            // 
            // AddBtn
            // 
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.AddBtn.Location = new System.Drawing.Point(12, 376);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 37);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "ADD";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Editbtn
            // 
            this.Editbtn.FlatAppearance.BorderSize = 0;
            this.Editbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editbtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Editbtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Editbtn.Location = new System.Drawing.Point(80, 376);
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.Size = new System.Drawing.Size(75, 37);
            this.Editbtn.TabIndex = 7;
            this.Editbtn.Text = "EDIT";
            this.Editbtn.UseVisualStyleBackColor = true;
            this.Editbtn.Click += new System.EventHandler(this.Editbtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.FlatAppearance.BorderSize = 0;
            this.Deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deletebtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Deletebtn.Location = new System.Drawing.Point(157, 376);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(110, 37);
            this.Deletebtn.TabIndex = 8;
            this.Deletebtn.Text = "DELETE";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // ClientSearchtb
            // 
            this.ClientSearchtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ClientSearchtb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSearchtb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ClientSearchtb.HintForeColor = System.Drawing.Color.Empty;
            this.ClientSearchtb.HintText = "";
            this.ClientSearchtb.isPassword = false;
            this.ClientSearchtb.LineFocusedColor = System.Drawing.Color.Red;
            this.ClientSearchtb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.ClientSearchtb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.ClientSearchtb.LineThickness = 3;
            this.ClientSearchtb.Location = new System.Drawing.Point(555, 88);
            this.ClientSearchtb.Margin = new System.Windows.Forms.Padding(4);
            this.ClientSearchtb.Name = "ClientSearchtb";
            this.ClientSearchtb.Size = new System.Drawing.Size(151, 31);
            this.ClientSearchtb.TabIndex = 9;
            this.ClientSearchtb.Text = "ClientSearch";
            this.ClientSearchtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Location = new System.Drawing.Point(699, 88);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 31);
            this.button4.TabIndex = 10;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ClientGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.ClientGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ClientGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientGridView.BackgroundColor = System.Drawing.Color.White;
            this.ClientGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ClientGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ClientGridView.ColumnHeadersHeight = 24;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ClientGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClientGridView.EnableHeadersVisualStyles = false;
            this.ClientGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ClientGridView.Location = new System.Drawing.Point(349, 124);
            this.ClientGridView.Name = "ClientGridView";
            this.ClientGridView.RowHeadersVisible = false;
            this.ClientGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientGridView.Size = new System.Drawing.Size(559, 451);
            this.ClientGridView.TabIndex = 11;
            this.ClientGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.ClientGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ClientGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ClientGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ClientGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ClientGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ClientGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ClientGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ClientGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ClientGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.ClientGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ClientGridView.ThemeStyle.HeaderStyle.Height = 24;
            this.ClientGridView.ThemeStyle.ReadOnly = false;
            this.ClientGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ClientGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ClientGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.ClientGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ClientGridView.ThemeStyle.RowsStyle.Height = 22;
            this.ClientGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ClientGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ClientGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientGridView_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(805, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(80, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 37);
            this.button1.TabIndex = 34;
            this.button1.Text = "BACK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 673);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ClientGridView);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ClientSearchtb);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.Editbtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.clientctrycb);
            this.Controls.Add(this.clientphonetb);
            this.Controls.Add(this.clientnametb);
            this.Controls.Add(this.clientidtbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientInfo";
            this.Load += new System.EventHandler(this.ClientInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox clientidtbl;
        private Bunifu.Framework.UI.BunifuMaterialTextbox clientnametb;
        private Bunifu.Framework.UI.BunifuMaterialTextbox clientphonetb;
        private System.Windows.Forms.ComboBox clientctrycb;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button Editbtn;
        private System.Windows.Forms.Button Deletebtn;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ClientSearchtb;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label Datelbl;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2DataGridView ClientGridView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}