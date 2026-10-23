using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisabsen_iqbal
{
    public partial class FAbsenK : Form
    {
        public FAbsenK()
        {
            InitializeComponent();
        }

        private void LoadKelasWali()
        {
            // filter untuk kelas sesuai wali
            string query = $"SELECT id_kelas, nama_kelas FROM kelas WHERE id_guru = '{UserSession.IdGuru}'";
            db.crud(query);

            if (db.ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtKelas = db.ds.Tables[0].Copy();
                cmbKelas.DataSource = dtKelas;
                cmbKelas.DisplayMember = "nama_kelas";
                cmbKelas.ValueMember = "id_kelas";

                // data kelas sesuai walikelas
                cmbKelas.SelectedIndex = 0;
                cmbKelas.Enabled = false;

                if (cmbKelas.SelectedValue != null)
                {
                    loadsiswa(cmbKelas.SelectedValue.ToString());
                }
            }
            else
            {
                MessageBox.Show("Anda belum ditugaskan sebagai Wali Kelas di kelas manapun.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbKelas.Enabled = false;
            }
        }

        private void FAbsenK_Load(object sender, EventArgs e)
        {
            dtpTanggal.Value = DateTime.Now;
            dtpTanggal.Enabled = false;

            LoadKelasWali();
        }

        private void loadsiswa(string idKelas)
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;

            db.crud($"SELECT id_siswa, nis, nama FROM siswa WHERE id_kelas = '{idKelas}'");

            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string id = "" + row["id_siswa"];
                string nis = "" + row["nis"];
                string nama = "" + row["nama"];

                guna2DataGridView1.Rows.Add(no, id, nis, nama, "Hadir");
                no++;
            }
        }

        private void cmbKelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKelas.SelectedIndex != -1 && cmbKelas.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                loadsiswa(cmbKelas.SelectedValue.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string namaKegiatan = txtKe.Text.Trim();

            if (guna2DataGridView1.Rows.Count == 0 || cmbKelas.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih kelas dan pastikan data siswa tersedia!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(namaKegiatan))
            {
                MessageBox.Show("Nama kegiatan tidak boleh kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string tgl = dtpTanggal.Value.ToString("yyyy-MM-dd");
            string idKelas = cmbKelas.SelectedValue.ToString();
            string idGuru = UserSession.IdGuru.ToString();

            string queryCek = $"SELECT COUNT(*) FROM absensi_kegiatan WHERE tanggal = '{tgl}' AND id_kelas = '{idKelas}' AND nama_kegiatan = '{namaKegiatan}'";
            db.crud(queryCek);

            int jumlahAbsen = Convert.ToInt32(db.ds.Tables[0].Rows[0][0]);
            if (jumlahAbsen > 0)
            {
                MessageBox.Show($"Absensi untuk kegiatan '{namaKegiatan}' pada tanggal tersebut sudah dilakukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    string idSiswa = row.Cells[1].Value.ToString();
                    string ket = row.Cells[4].Value.ToString();

                    string queryInsert = $"INSERT INTO absensi_kegiatan (tanggal, nama_kegiatan, id_kelas, id_siswa, keterangan, id_guru) " +
                                         $"VALUES ('{tgl}', '{namaKegiatan}', '{idKelas}', '{idSiswa}', '{ket}', '{idGuru}')";
                    db.crud(queryInsert);
                }
            }
            MessageBox.Show("Data absensi kegiatan berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtKe.Clear();
            loadsiswa(cmbKelas.SelectedValue.ToString());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.CurrentCell = null;
            string kataKunci = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string nisSiswa = row.Cells[2].Value != null ? row.Cells[2].Value.ToString().ToLower() : "";
                string namaSiswa = row.Cells[3].Value != null ? row.Cells[3].Value.ToString().ToLower() : "";

                if (namaSiswa.Contains(kataKunci) || nisSiswa.Contains(kataKunci))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FRpt CBL = new FRpt();
            CBL.ShowDialog();
        }
    }
}
