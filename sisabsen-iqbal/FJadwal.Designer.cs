namespace sisabsen_iqbal
{
    partial class FJadwal
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIdJadwal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardForm = new Guna.UI2.WinForms.Guna2Shapes();
            this.lblHari = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbHari = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblJam = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbJam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblKelas = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbKelas = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMapel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbMapel = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblGuru = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbGuru = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.cardTable = new Guna.UI2.WinForms.Guna2Shapes();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvJadwal = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMapel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();

            // guna2Panel1
            this.guna2Panel1.Controls.Add(this.dgvJadwal);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.btnReset);
            this.guna2Panel1.Controls.Add(this.btnEdit);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.cmbGuru);
            this.guna2Panel1.Controls.Add(this.lblGuru);
            this.guna2Panel1.Controls.Add(this.cmbMapel);
            this.guna2Panel1.Controls.Add(this.lblMapel);
            this.guna2Panel1.Controls.Add(this.cmbKelas);
            this.guna2Panel1.Controls.Add(this.lblKelas);
            this.guna2Panel1.Controls.Add(this.cmbJam);
            this.guna2Panel1.Controls.Add(this.lblJam);
            this.guna2Panel1.Controls.Add(this.cmbHari);
            this.guna2Panel1.Controls.Add(this.lblHari);
            this.guna2Panel1.Controls.Add(this.lblIdJadwal);
            this.guna2Panel1.Controls.Add(this.lblTitle);
            this.guna2Panel1.Controls.Add(this.cardTable);
            this.guna2Panel1.Controls.Add(this.cardForm);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(800, 692);

            // lblTitle
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 20);
            this.lblTitle.Text = "Jadwal Mengajar";

            this.lblIdJadwal.Visible = false;

            // cardForm
            this.cardForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cardForm.BorderColor = System.Drawing.Color.White;
            this.cardForm.FillColor = System.Drawing.Color.White;
            this.cardForm.Location = new System.Drawing.Point(12, 60);
            this.cardForm.RoundedRadius = 10;
            this.cardForm.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            this.cardForm.Size = new System.Drawing.Size(776, 210);

            // Baris 1: Hari, Jam Pelajaran, Kelas
            this.lblHari.BackColor = System.Drawing.Color.White;
            this.lblHari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblHari.Location = new System.Drawing.Point(35, 76);
            this.lblHari.Text = "Hari";

            this.cmbHari.BorderRadius = 5;
            this.cmbHari.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHari.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbHari.ItemHeight = 28;
            this.cmbHari.Location = new System.Drawing.Point(35, 100);
            this.cmbHari.Size = new System.Drawing.Size(170, 34);

            this.lblJam.BackColor = System.Drawing.Color.White;
            this.lblJam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblJam.Location = new System.Drawing.Point(225, 76);
            this.lblJam.Text = "Jam Pelajaran";

            this.cmbJam.BorderRadius = 5;
            this.cmbJam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbJam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJam.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbJam.ItemHeight = 28;
            this.cmbJam.Location = new System.Drawing.Point(225, 100);
            this.cmbJam.Size = new System.Drawing.Size(170, 34);

            this.lblKelas.BackColor = System.Drawing.Color.White;
            this.lblKelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblKelas.Location = new System.Drawing.Point(415, 76);
            this.lblKelas.Text = "Kelas";

            this.cmbKelas.BorderRadius = 5;
            this.cmbKelas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbKelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKelas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbKelas.ItemHeight = 28;
            this.cmbKelas.Location = new System.Drawing.Point(415, 100);
            this.cmbKelas.Size = new System.Drawing.Size(170, 34);

            // Baris 2: Mata Pelajaran & Guru Pengampu
            this.lblMapel.BackColor = System.Drawing.Color.White;
            this.lblMapel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblMapel.Location = new System.Drawing.Point(35, 152);
            this.lblMapel.Text = "Mata Pelajaran";

            this.cmbMapel.BorderRadius = 5;
            this.cmbMapel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMapel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMapel.ItemHeight = 28;
            this.cmbMapel.Location = new System.Drawing.Point(35, 176);
            this.cmbMapel.Size = new System.Drawing.Size(260, 34);

            this.lblGuru.BackColor = System.Drawing.Color.White;
            this.lblGuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblGuru.Location = new System.Drawing.Point(315, 152);
            this.lblGuru.Text = "Guru Pengampu";

            this.cmbGuru.BorderRadius = 5;
            this.cmbGuru.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuru.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbGuru.ItemHeight = 28;
            this.cmbGuru.Location = new System.Drawing.Point(315, 176);
            this.cmbGuru.Size = new System.Drawing.Size(270, 34);

            // Tombol Aksi
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(625, 98);
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.Text = "Tambah";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BorderRadius = 5;
            this.btnEdit.FillColor = System.Drawing.Color.Blue;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(625, 142);
            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.Text = "Ubah";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnReset.BorderRadius = 5;
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(625, 186);
            this.btnReset.Size = new System.Drawing.Size(120, 32);
            this.btnReset.Text = "Batal";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // cardTable
            this.cardTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cardTable.BorderColor = System.Drawing.Color.White;
            this.cardTable.FillColor = System.Drawing.Color.White;
            this.cardTable.Location = new System.Drawing.Point(16, 285);
            this.cardTable.RoundedRadius = 10;
            this.cardTable.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            this.cardTable.Size = new System.Drawing.Size(772, 385);

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(35, 302);
            this.txtSearch.PlaceholderText = "Cari hari, kelas, mapel, atau guru...";
            this.txtSearch.Size = new System.Drawing.Size(280, 32);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // dgvJadwal
            this.dgvJadwal.AllowUserToAddRows = false;
            this.dgvJadwal.AllowUserToDeleteRows = false;
            this.dgvJadwal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            headerStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            this.dgvJadwal.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvJadwal.ColumnHeadersHeight = 36;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvJadwal.DefaultCellStyle = rowStyle;
            this.dgvJadwal.Location = new System.Drawing.Point(35, 346);
            this.dgvJadwal.ReadOnly = true;
            this.dgvJadwal.RowHeadersVisible = false;
            this.dgvJadwal.RowTemplate.Height = 30;
            this.dgvJadwal.Size = new System.Drawing.Size(728, 305);
            this.dgvJadwal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNo, this.colId, this.colHari, this.colJam, this.colKelas, this.colMapel, this.colGuru, this.colEdit, this.colHapus
            });
            this.dgvJadwal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJadwal_CellClick);

            this.colNo.HeaderText = "No";
            this.colNo.Width = 40;
            this.colId.HeaderText = "ID";
            this.colId.Visible = false;
            this.colHari.HeaderText = "Hari";
            this.colHari.Width = 75;
            this.colJam.HeaderText = "Jam";
            this.colJam.Width = 90;
            this.colKelas.HeaderText = "Kelas";
            this.colKelas.Width = 90;
            this.colMapel.HeaderText = "Mata Pelajaran";
            this.colMapel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGuru.HeaderText = "Guru";
            this.colGuru.Width = 145;

            this.colEdit.HeaderText = "Edit";
            this.colEdit.Text = "Edit";
            this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.Width = 55;

            this.colHapus.HeaderText = "Hapus";
            this.colHapus.Text = "Hapus";
            this.colHapus.UseColumnTextForButtonValue = true;
            this.colHapus.Width = 60;

            // FJadwal
            this.ClientSize = new System.Drawing.Size(800, 692);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FJadwal";
            this.Text = "Jadwal Mengajar";
            this.Load += new System.EventHandler(this.FJadwal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIdJadwal;
        private Guna.UI2.WinForms.Guna2Shapes cardForm;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHari;
        private Guna.UI2.WinForms.Guna2ComboBox cmbHari;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblJam;
        private Guna.UI2.WinForms.Guna2ComboBox cmbJam;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKelas;
        private Guna.UI2.WinForms.Guna2ComboBox cmbKelas;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMapel;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMapel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGuru;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGuru;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Shapes cardTable;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvJadwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMapel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuru;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colHapus;
    }
}