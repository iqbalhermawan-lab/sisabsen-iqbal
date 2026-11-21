namespace sisabsen_iqbal
{
    partial class FMapel
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
            this.lblIdMapel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardForm = new Guna.UI2.WinForms.Guna2Shapes();
            this.lblKode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtKodeMapel = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNama = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtNamaMapel = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.cardTable = new Guna.UI2.WinForms.Guna2Shapes();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvMapel = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapel)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();

            // guna2Panel1
            this.guna2Panel1.Controls.Add(this.dgvMapel);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.btnReset);
            this.guna2Panel1.Controls.Add(this.btnEdit);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.txtNamaMapel);
            this.guna2Panel1.Controls.Add(this.lblNama);
            this.guna2Panel1.Controls.Add(this.txtKodeMapel);
            this.guna2Panel1.Controls.Add(this.lblKode);
            this.guna2Panel1.Controls.Add(this.lblIdMapel);
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
            this.lblTitle.Location = new System.Drawing.Point(16, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Data Mata Pelajaran";

            // lblIdMapel (Hidden ID holder)
            this.lblIdMapel.Location = new System.Drawing.Point(336, 322);
            this.lblIdMapel.Name = "lblIdMapel";
            this.lblIdMapel.Text = "";
            this.lblIdMapel.Visible = false;

            // cardForm
            this.cardForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cardForm.BorderColor = System.Drawing.Color.White;
            this.cardForm.FillColor = System.Drawing.Color.White;
            this.cardForm.Location = new System.Drawing.Point(12, 72);
            this.cardForm.Name = "cardForm";
            this.cardForm.RoundedRadius = 10;
            this.cardForm.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            this.cardForm.Size = new System.Drawing.Size(776, 175);

            // lblKode & txtKodeMapel
            this.lblKode.BackColor = System.Drawing.Color.White;
            this.lblKode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblKode.Location = new System.Drawing.Point(47, 92);
            this.lblKode.Text = "Kode Mapel";

            this.txtKodeMapel.BorderRadius = 5;
            this.txtKodeMapel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtKodeMapel.Location = new System.Drawing.Point(47, 118);
            this.txtKodeMapel.Name = "txtKodeMapel";
            this.txtKodeMapel.PlaceholderText = "Contoh: MTK-01";
            this.txtKodeMapel.Size = new System.Drawing.Size(180, 34);

            // lblNama & txtNamaMapel
            this.lblNama.BackColor = System.Drawing.Color.White;
            this.lblNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblNama.Location = new System.Drawing.Point(255, 92);
            this.lblNama.Text = "Nama Mata Pelajaran";

            this.txtNamaMapel.BorderRadius = 5;
            this.txtNamaMapel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNamaMapel.Location = new System.Drawing.Point(255, 118);
            this.txtNamaMapel.Name = "txtNamaMapel";
            this.txtNamaMapel.PlaceholderText = "Masukkan nama mata pelajaran...";
            this.txtNamaMapel.Size = new System.Drawing.Size(270, 34);

            // btnAdd, btnEdit, btnReset
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(560, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 36);
            this.btnAdd.Text = "Tambah";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BorderRadius = 5;
            this.btnEdit.FillColor = System.Drawing.Color.Blue;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(665, 116);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 36);
            this.btnEdit.Text = "Ubah";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnReset.BorderRadius = 5;
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(665, 165);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(95, 32);
            this.btnReset.Text = "Batal";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // cardTable
            this.cardTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cardTable.BorderColor = System.Drawing.Color.White;
            this.cardTable.FillColor = System.Drawing.Color.White;
            this.cardTable.Location = new System.Drawing.Point(16, 270);
            this.cardTable.Name = "cardTable";
            this.cardTable.RoundedRadius = 10;
            this.cardTable.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            this.cardTable.Size = new System.Drawing.Size(772, 395);

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(37, 290);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Cari kode atau nama mapel...";
            this.txtSearch.Size = new System.Drawing.Size(260, 32);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // dgvMapel
            this.dgvMapel.AllowUserToAddRows = false;
            this.dgvMapel.AllowUserToDeleteRows = false;
            this.dgvMapel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            headerStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMapel.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvMapel.ColumnHeadersHeight = 36;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvMapel.DefaultCellStyle = rowStyle;
            this.dgvMapel.Location = new System.Drawing.Point(37, 336);
            this.dgvMapel.Name = "dgvMapel";
            this.dgvMapel.ReadOnly = true;
            this.dgvMapel.RowHeadersVisible = false;
            this.dgvMapel.RowTemplate.Height = 32;
            this.dgvMapel.Size = new System.Drawing.Size(724, 305);
            this.dgvMapel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNo, this.colId, this.colKode, this.colNama, this.colEdit, this.colHapus
            });
            this.dgvMapel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMapel_CellClick);

            this.colNo.HeaderText = "No";
            this.colNo.Width = 50;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            this.colKode.HeaderText = "Kode Mapel";
            this.colKode.Width = 140;
            this.colNama.HeaderText = "Nama Mata Pelajaran";
            this.colNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            this.colEdit.HeaderText = "Edit";
            this.colEdit.Text = "Edit";
            this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.Width = 70;

            this.colHapus.HeaderText = "Hapus";
            this.colHapus.Text = "Hapus";
            this.colHapus.UseColumnTextForButtonValue = true;
            this.colHapus.Width = 75;

            // FMapel
            this.ClientSize = new System.Drawing.Size(800, 692);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FMapel";
            this.Text = "Data Mata Pelajaran";
            this.Load += new System.EventHandler(this.FMapel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapel)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIdMapel;
        private Guna.UI2.WinForms.Guna2Shapes cardForm;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKode;
        private Guna.UI2.WinForms.Guna2TextBox txtKodeMapel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNama;
        private Guna.UI2.WinForms.Guna2TextBox txtNamaMapel;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Shapes cardTable;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMapel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNama;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colHapus;
    }
}