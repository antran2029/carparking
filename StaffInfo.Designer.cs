
namespace Auto_parking
{
    partial class StaffInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Datelbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.staffphonetb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.Staffnametb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.Staffidtbl = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.staffgendercb = new System.Windows.Forms.ComboBox();
            this.StaffGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.StaffSearchtb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.StaffEditbtn = new System.Windows.Forms.Button();
            this.AddStaffBtn = new System.Windows.Forms.Button();
            this.passwordtb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaffGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.TabIndex = 1;
            // 
            // Datelbl
            // 
            this.Datelbl.AutoSize = true;
            this.Datelbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label1.Location = new System.Drawing.Point(343, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Staff Information";
            // 
            // staffphonetb
            // 
            this.staffphonetb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.staffphonetb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffphonetb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.staffphonetb.HintForeColor = System.Drawing.Color.Empty;
            this.staffphonetb.HintText = "";
            this.staffphonetb.isPassword = false;
            this.staffphonetb.LineFocusedColor = System.Drawing.Color.Red;
            this.staffphonetb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.staffphonetb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.staffphonetb.LineThickness = 3;
            this.staffphonetb.Location = new System.Drawing.Point(33, 318);
            this.staffphonetb.Margin = new System.Windows.Forms.Padding(4);
            this.staffphonetb.Name = "staffphonetb";
            this.staffphonetb.Size = new System.Drawing.Size(189, 31);
            this.staffphonetb.TabIndex = 6;
            this.staffphonetb.Text = "Phone Num";
            this.staffphonetb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Staffnametb
            // 
            this.Staffnametb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Staffnametb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Staffnametb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Staffnametb.HintForeColor = System.Drawing.Color.Empty;
            this.Staffnametb.HintText = "";
            this.Staffnametb.isPassword = false;
            this.Staffnametb.LineFocusedColor = System.Drawing.Color.Red;
            this.Staffnametb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.Staffnametb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.Staffnametb.LineThickness = 3;
            this.Staffnametb.Location = new System.Drawing.Point(33, 255);
            this.Staffnametb.Margin = new System.Windows.Forms.Padding(4);
            this.Staffnametb.Name = "Staffnametb";
            this.Staffnametb.Size = new System.Drawing.Size(189, 31);
            this.Staffnametb.TabIndex = 5;
            this.Staffnametb.Text = "StaffName";
            this.Staffnametb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Staffidtbl
            // 
            this.Staffidtbl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Staffidtbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Staffidtbl.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Staffidtbl.HintForeColor = System.Drawing.Color.Empty;
            this.Staffidtbl.HintText = "";
            this.Staffidtbl.isPassword = false;
            this.Staffidtbl.LineFocusedColor = System.Drawing.Color.Red;
            this.Staffidtbl.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.Staffidtbl.LineMouseHoverColor = System.Drawing.Color.Red;
            this.Staffidtbl.LineThickness = 3;
            this.Staffidtbl.Location = new System.Drawing.Point(33, 195);
            this.Staffidtbl.Margin = new System.Windows.Forms.Padding(4);
            this.Staffidtbl.Name = "Staffidtbl";
            this.Staffidtbl.Size = new System.Drawing.Size(189, 31);
            this.Staffidtbl.TabIndex = 4;
            this.Staffidtbl.Text = "StaffId";
            this.Staffidtbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // staffgendercb
            // 
            this.staffgendercb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffgendercb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.staffgendercb.FormattingEnabled = true;
            this.staffgendercb.Items.AddRange(new object[] {
            "MALE",
            "FEMALE"});
            this.staffgendercb.Location = new System.Drawing.Point(33, 433);
            this.staffgendercb.Name = "staffgendercb";
            this.staffgendercb.Size = new System.Drawing.Size(189, 27);
            this.staffgendercb.TabIndex = 7;
            this.staffgendercb.Text = "Gender";
            // 
            // StaffGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.StaffGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.StaffGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StaffGridView.BackgroundColor = System.Drawing.Color.White;
            this.StaffGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StaffGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.StaffGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StaffGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.StaffGridView.ColumnHeadersHeight = 24;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StaffGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.StaffGridView.EnableHeadersVisualStyles = false;
            this.StaffGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.StaffGridView.Location = new System.Drawing.Point(369, 174);
            this.StaffGridView.Name = "StaffGridView";
            this.StaffGridView.RowHeadersVisible = false;
            this.StaffGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StaffGridView.Size = new System.Drawing.Size(559, 451);
            this.StaffGridView.TabIndex = 12;
            this.StaffGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.StaffGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.StaffGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.StaffGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.StaffGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.StaffGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.StaffGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.StaffGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.StaffGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.StaffGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.StaffGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StaffGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.StaffGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.StaffGridView.ThemeStyle.HeaderStyle.Height = 24;
            this.StaffGridView.ThemeStyle.ReadOnly = false;
            this.StaffGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.StaffGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.StaffGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.StaffGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.StaffGridView.ThemeStyle.RowsStyle.Height = 22;
            this.StaffGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.StaffGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.StaffGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StaffGridView_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(789, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Location = new System.Drawing.Point(680, 127);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 31);
            this.button4.TabIndex = 14;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // StaffSearchtb
            // 
            this.StaffSearchtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.StaffSearchtb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffSearchtb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.StaffSearchtb.HintForeColor = System.Drawing.Color.Empty;
            this.StaffSearchtb.HintText = "";
            this.StaffSearchtb.isPassword = false;
            this.StaffSearchtb.LineFocusedColor = System.Drawing.Color.Red;
            this.StaffSearchtb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.StaffSearchtb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.StaffSearchtb.LineThickness = 3;
            this.StaffSearchtb.Location = new System.Drawing.Point(536, 127);
            this.StaffSearchtb.Margin = new System.Windows.Forms.Padding(4);
            this.StaffSearchtb.Name = "StaffSearchtb";
            this.StaffSearchtb.Size = new System.Drawing.Size(151, 31);
            this.StaffSearchtb.TabIndex = 13;
            this.StaffSearchtb.Text = "StaffSearch";
            this.StaffSearchtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.StaffSearchtb.OnValueChanged += new System.EventHandler(this.ClientSearchtb_OnValueChanged);
            // 
            // Deletebtn
            // 
            this.Deletebtn.FlatAppearance.BorderSize = 0;
            this.Deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deletebtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Deletebtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Deletebtn.Location = new System.Drawing.Point(155, 489);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(116, 37);
            this.Deletebtn.TabIndex = 18;
            this.Deletebtn.Text = "DELETE";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // StaffEditbtn
            // 
            this.StaffEditbtn.FlatAppearance.BorderSize = 0;
            this.StaffEditbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaffEditbtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffEditbtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.StaffEditbtn.Location = new System.Drawing.Point(84, 489);
            this.StaffEditbtn.Name = "StaffEditbtn";
            this.StaffEditbtn.Size = new System.Drawing.Size(75, 37);
            this.StaffEditbtn.TabIndex = 17;
            this.StaffEditbtn.Text = "EDIT";
            this.StaffEditbtn.UseVisualStyleBackColor = true;
            this.StaffEditbtn.Click += new System.EventHandler(this.StaffEditbtn_Click);
            // 
            // AddStaffBtn
            // 
            this.AddStaffBtn.FlatAppearance.BorderSize = 0;
            this.AddStaffBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddStaffBtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddStaffBtn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.AddStaffBtn.Location = new System.Drawing.Point(12, 489);
            this.AddStaffBtn.Name = "AddStaffBtn";
            this.AddStaffBtn.Size = new System.Drawing.Size(75, 37);
            this.AddStaffBtn.TabIndex = 16;
            this.AddStaffBtn.Text = "ADD";
            this.AddStaffBtn.UseVisualStyleBackColor = true;
            this.AddStaffBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // passwordtb
            // 
            this.passwordtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordtb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.passwordtb.HintForeColor = System.Drawing.Color.Empty;
            this.passwordtb.HintText = "";
            this.passwordtb.isPassword = false;
            this.passwordtb.LineFocusedColor = System.Drawing.Color.Red;
            this.passwordtb.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.passwordtb.LineMouseHoverColor = System.Drawing.Color.Red;
            this.passwordtb.LineThickness = 3;
            this.passwordtb.Location = new System.Drawing.Point(33, 369);
            this.passwordtb.Margin = new System.Windows.Forms.Padding(4);
            this.passwordtb.Name = "passwordtb";
            this.passwordtb.Size = new System.Drawing.Size(189, 31);
            this.passwordtb.TabIndex = 19;
            this.passwordtb.Text = "Password";
            this.passwordtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(84, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 37);
            this.button1.TabIndex = 27;
            this.button1.Text = "BACK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCyan;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 100);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(849, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightCyan;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(343, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "Staff Information";
            // 
            // StaffInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 673);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordtb);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.StaffEditbtn);
            this.Controls.Add(this.AddStaffBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.StaffSearchtb);
            this.Controls.Add(this.StaffGridView);
            this.Controls.Add(this.staffgendercb);
            this.Controls.Add(this.staffphonetb);
            this.Controls.Add(this.Staffnametb);
            this.Controls.Add(this.Staffidtbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffInfo";
            this.Load += new System.EventHandler(this.StaffInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaffGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Datelbl;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox staffphonetb;
        private Bunifu.Framework.UI.BunifuMaterialTextbox Staffnametb;
        private Bunifu.Framework.UI.BunifuMaterialTextbox Staffidtbl;
        private System.Windows.Forms.ComboBox staffgendercb;
        private Guna.UI2.WinForms.Guna2DataGridView StaffGridView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox StaffSearchtb;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button StaffEditbtn;
        private System.Windows.Forms.Button AddStaffBtn;
        private Bunifu.Framework.UI.BunifuMaterialTextbox passwordtb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}