using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sisabsen_iqbal
{
    public partial class FMapel : Form
    {
        public FMapel()
        {
            InitializeComponent();
        }

        public void TampilData(string keyword = "")
        {
            dgvMapel.Rows.Clear();
            int no = 1;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                db.crud("SELECT id_mapel, kode_mapel, nama_mapel FROM mapel ORDER BY nama_mapel ASC");
            }
            else
            {
                db.crud(
                    "SELECT id_mapel, kode_mapel, nama_mapel FROM mapel WHERE kode_mapel LIKE @kw OR nama_mapel LIKE @kw ORDER BY nama_mapel ASC",
                    new MySqlParameter("@kw", $"%{keyword}%")
                );
            }

            if (db.ds.Tables.Count > 0)
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    dgvMapel.Rows.Add(
                        no++,
                        row["id_mapel"].ToString(),
                        row["kode_mapel"].ToString(),
                        row["nama_mapel"].ToString()
                    );
                }
            }
        }

        public void Bersih()
        {
            lblIdMapel.Text = "";
            txtKodeMapel.Clear();
            txtNamaMapel.Clear();
            txtKodeMapel.Focus();
        }

        private void FMapel_Load(object sender, EventArgs e)
        {
            TampilData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKodeMapel.Text) || string.IsNullOrWhiteSpace(txtNamaMapel.Text))
            {
                MessageBox.Show("Masukkan Kode dan Nama Mata Pelajaran!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Cek duplikasi kode mapel
            db.crud("SELECT COUNT(*) FROM mapel WHERE kode_mapel = @kode",
                new MySqlParameter("@kode", txtKodeMapel.Text.Trim().ToUpper()));
            if (Convert.ToInt32(db.ds.Tables[0].Rows[0][0]) > 0)
            {
                MessageBox.Show("Kode Mapel sudah terdaftar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.crud(
                "INSERT INTO mapel (kode_mapel, nama_mapel) VALUES (@kode, @nama)",
                new MySqlParameter("@kode", txtKodeMapel.Text.Trim().ToUpper()),
                new MySqlParameter("@nama", txtNamaMapel.Text.Trim())
            );

            MessageBox.Show("Mata pelajaran berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bersih();
            TampilData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblIdMapel.Text))
            {
                MessageBox.Show("Pilih data pada tabel yang ingin diubah terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtKodeMapel.Text) || string.IsNullOrWhiteSpace(txtNamaMapel.Text))
            {
                MessageBox.Show("Kode dan Nama Mapel tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            db.crud(
                "UPDATE mapel SET kode_mapel = @kode, nama_mapel = @nama WHERE id_mapel = @id",
                new MySqlParameter("@kode", txtKodeMapel.Text.Trim().ToUpper()),
                new MySqlParameter("@nama", txtNamaMapel.Text.Trim()),
                new MySqlParameter("@id", lblIdMapel.Text)
            );

            MessageBox.Show("Data mata pelajaran berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bersih();
            TampilData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Bersih();
        }

        private void dgvMapel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string idMapel = dgvMapel.Rows[e.RowIndex].Cells[1].Value.ToString();

            // Kolom 4 = Edit
            if (e.ColumnIndex == 4)
            {
                lblIdMapel.Text = idMapel;
                txtKodeMapel.Text = dgvMapel.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNamaMapel.Text = dgvMapel.Rows[e.RowIndex].Cells[3].Value.ToString();
            }

            // Kolom 5 = Hapus
            if (e.ColumnIndex == 5)
            {
                DialogResult konfirmasi = MessageBox.Show(
                    "Menghapus mata pelajaran juga akan menghapus jadwal terkait. Lanjutkan?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (konfirmasi == DialogResult.OK)
                {
                    db.crud("DELETE FROM mapel WHERE id_mapel = @id", new MySqlParameter("@id", idMapel));
                    Bersih();
                    TampilData();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            TampilData(txtSearch.Text.Trim());
        }
    }
}