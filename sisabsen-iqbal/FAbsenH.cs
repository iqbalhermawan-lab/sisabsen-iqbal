using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace sisabsen_iqbal
{
    public partial class FAbsenH : Form
    {
        public FAbsenH()
        {
            InitializeComponent();
        }

        public void loadkelas()
        {
            db.crud("SELECT id_kelas, nama_kelas FROM kelas");

            //agar data tidak hilang saat db.crud dipanggil lagi nanti
            DataTable dtKelas = db.ds.Tables[0].Copy();

            cmbKelas.DataSource = dtKelas;
            cmbKelas.DisplayMember = "nama_kelas";
            cmbKelas.ValueMember = "id_kelas";
            cmbKelas.SelectedIndex = -1;

        }

        private void FAbsenH_Load(object sender, EventArgs e)
        {
            dtpTanggal.Value = DateTime.Now;
            dtpTanggal.Enabled = false;

            loadkelas();
        }

        public void loadsiswa(string idKelas)
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
            if (guna2DataGridView1.Rows.Count == 0 || cmbKelas.SelectedIndex == -1 || cmbJam.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih kelas, jam pelajaran, dan pastikan data siswa tersedia!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string tgl = dtpTanggal.Value.ToString("yyyy-MM-dd");
            string idKelas = cmbKelas.SelectedValue.ToString();
            string jamPelajaran = cmbJam.Text;
            string idGuru = UserSession.IdGuru.ToString();

            // Cek duplikasi
            string queryCek = $"SELECT COUNT(*) FROM absensi WHERE tanggal = '{tgl}' AND id_kelas = '{idKelas}' AND jam_pelajaran = '{jamPelajaran}'";
            db.crud(queryCek);

            int jumlahAbsen = Convert.ToInt32(db.ds.Tables[0].Rows[0][0]);
            if (jumlahAbsen > 0)
            {
                MessageBox.Show($"Kelas ini sudah di-absen untuk {jamPelajaran}!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    string idSiswa = row.Cells[1].Value.ToString();
                    string ket = row.Cells[4].Value.ToString();

                    string queryInsert = $"INSERT INTO absensi (tanggal, id_kelas, jam_pelajaran, id_siswa, keterangan, id_guru) " + $"VALUES ('{tgl}', '{idKelas}', '{jamPelajaran}', '{idSiswa}', '{ket}', '{idGuru}')";
                    db.crud(queryInsert);
                }
            }

            MessageBox.Show("Data absensi berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            guna2DataGridView1.Rows.Clear();
            cmbKelas.SelectedIndex = -1;
            cmbJam.SelectedIndex = -1;
        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbJam_DropDown(object sender, EventArgs e)
        {
            cmbJam.Items.Clear();
            cmbJam.Items.AddRange(new string[] { "Jam ke-01", "Jam ke-02", "Jam ke-03" });
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.CurrentCell = null;

            string kataKunci = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string namaSiswa = row.Cells[3].Value != null ? row.Cells[3].Value.ToString().ToLower() : "";
                string nisSiswa = row.Cells[2].Value != null ? row.Cells[2].Value.ToString().ToLower() : "";

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load("REPORT ABSENSI HARIAN.rpt");

            string pdfPath = Path.Combine(Path.GetTempPath(), "Laporan_Absen.pdf");
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfPath);

            // membuka PDF otomatis
            System.Diagnostics.Process.Start(pdfPath);
        }

        private void guna2Shapes7_Click(object sender, EventArgs e)
        {

        }
    }
}
