using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

namespace sisabsen_iqbal
{
    public partial class FAbsenH : Form
    {
        private bool sedangMemuatJadwal = false;

        public FAbsenH()
        {
            InitializeComponent();
        }

        private void IsiDaftarJam()
        {
            cmbJam.Items.Clear();
            cmbJam.Items.AddRange(new string[] {
                "Jam ke-01", "Jam ke-02", "Jam ke-03", "Jam ke-04",
                "Jam ke-05", "Jam ke-06", "Jam ke-07", "Jam ke-08"
            });
        }

        public void loadkelas()
        {
            db.crud("SELECT id_kelas, nama_kelas FROM kelas ORDER BY nama_kelas ASC");

            if (db.ds.Tables.Count > 0)
            {
                DataTable dtKelas = db.ds.Tables[0].Copy();
                cmbKelas.DataSource = dtKelas;
                cmbKelas.DisplayMember = "nama_kelas";
                cmbKelas.ValueMember = "id_kelas";
                cmbKelas.SelectedIndex = -1;
            }
        }

        private string GetHariIndonesia(DateTime tanggal)
        {
            switch (tanggal.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Senin";
                case DayOfWeek.Tuesday: return "Selasa";
                case DayOfWeek.Wednesday: return "Rabu";
                case DayOfWeek.Thursday: return "Kamis";
                case DayOfWeek.Friday: return "Jumat";
                case DayOfWeek.Saturday: return "Sabtu";
                default: return "Minggu";
            }
        }

        public void LoadJadwalHariIni()
        {
            sedangMemuatJadwal = true;

            string hariIni = GetHariIndonesia(dtpTanggal.Value);
            string query = @"
                SELECT 
                    j.id_jadwal,
                    j.id_kelas,
                    j.jam_pelajaran,
                    CONCAT(j.jam_pelajaran, ' | ', k.nama_kelas, ' - ', m.nama_mapel) AS info_jadwal
                FROM jadwal_mengajar j
                INNER JOIN kelas k ON j.id_kelas = k.id_kelas
                INNER JOIN mapel m ON j.id_mapel = m.id_mapel
                WHERE j.hari = @hari ";

            if (UserSession.IdRole != 1 && UserSession.IdGuru != null)
            {
                query += "AND j.id_guru = @idGuru ORDER BY j.jam_pelajaran ASC";
                db.crud(query,
                    new MySqlParameter("@hari", hariIni),
                    new MySqlParameter("@idGuru", UserSession.IdGuru));
            }
            else
            {
                query += "ORDER BY j.jam_pelajaran ASC, k.nama_kelas ASC";
                db.crud(query, new MySqlParameter("@hari", hariIni));
            }

            DataTable dtJadwal = db.ds.Tables.Count > 0
                ? db.ds.Tables[0].Copy()
                : new DataTable();

            if (dtJadwal.Rows.Count == 0)
            {
                // Tampilkan info jika hari ini tidak ada jadwal di database
                if (!dtJadwal.Columns.Contains("id_jadwal"))
                {
                    dtJadwal.Columns.Add("id_jadwal", typeof(int));
                    dtJadwal.Columns.Add("id_kelas", typeof(int));
                    dtJadwal.Columns.Add("jam_pelajaran", typeof(string));
                    dtJadwal.Columns.Add("info_jadwal", typeof(string));
                }

                dtJadwal.Rows.Add(0, 0, "", $"-- Tidak ada jadwal hari {hariIni} --");
                cmbJadwal.DataSource = dtJadwal;
                cmbJadwal.DisplayMember = "info_jadwal";
                cmbJadwal.ValueMember = "id_jadwal";
                cmbJadwal.SelectedIndex = 0;

                sedangMemuatJadwal = false;
                return;
            }

            cmbJadwal.DataSource = dtJadwal;
            cmbJadwal.DisplayMember = "info_jadwal";
            cmbJadwal.ValueMember = "id_jadwal";

            sedangMemuatJadwal = false;

            // Otomatis pilih jadwal pertama hari ini dan isi Kelas, Jam, & Siswa
            cmbJadwal.SelectedIndex = 0;
            TerapkanJadwalTerpilih();
        }

        private void TerapkanJadwalTerpilih()
        {
            if (sedangMemuatJadwal || cmbJadwal.SelectedIndex == -1) return;

            if (cmbJadwal.SelectedItem is DataRowView drv)
            {
                int idJadwal = Convert.ToInt32(drv["id_jadwal"]);
                if (idJadwal == 0)
                {
                    cmbKelas.SelectedIndex = -1;
                    cmbJam.SelectedIndex = -1;
                    guna2DataGridView1.Rows.Clear();
                    return;
                }

                int idKelas = Convert.ToInt32(drv["id_kelas"]);
                string jam = drv["jam_pelajaran"].ToString();

                cmbKelas.SelectedValue = idKelas;
                cmbJam.SelectedItem = jam;
                if (cmbJam.SelectedIndex == -1)
                {
                    cmbJam.Items.Add(jam);
                    cmbJam.SelectedItem = jam;
                }

                loadsiswa(idKelas.ToString());
            }
        }

        private void FAbsenH_Load(object sender, EventArgs e)
        {
            dtpTanggal.Value = DateTime.Now;
            dtpTanggal.Enabled = false;

            IsiDaftarJam();
            loadkelas();
            LoadJadwalHariIni();
        }

        private void cmbJadwal_SelectedIndexChanged(object sender, EventArgs e)
        {
            TerapkanJadwalTerpilih();
        }

        public void loadsiswa(string idKelas)
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;

            db.crud("SELECT id_siswa, nis, nama FROM siswa WHERE id_kelas = @idKelas ORDER BY nama ASC",
                new MySqlParameter("@idKelas", idKelas));

            if (db.ds.Tables.Count > 0)
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    string id = row["id_siswa"].ToString();
                    string nis = row["nis"].ToString();
                    string nama = row["nama"].ToString();

                    guna2DataGridView1.Rows.Add(no, id, nis, nama, "Hadir");
                    no++;
                }
            }
        }

        private void cmbKelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKelas.SelectedIndex != -1 && cmbKelas.SelectedValue != null &&
                cmbKelas.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                loadsiswa(cmbKelas.SelectedValue.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0 || cmbKelas.SelectedIndex == -1 || cmbJam.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih jadwal/kelas, jam pelajaran, dan pastikan data siswa tersedia!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (UserSession.IdGuru == null)
            {
                MessageBox.Show("Akun ini belum terhubung ke data Guru! Hubungkan id_user pada menu Data Guru.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tgl = dtpTanggal.Value.ToString("yyyy-MM-dd");
            string idKelas = cmbKelas.SelectedValue.ToString();
            string jamPelajaran = cmbJam.Text;
            string idGuru = UserSession.IdGuru.ToString();

            object idJadwalParam = DBNull.Value;
            if (cmbJadwal.SelectedValue != null && int.TryParse(cmbJadwal.SelectedValue.ToString(), out int idJ) && idJ > 0)
            {
                idJadwalParam = idJ;
            }

            // Cek duplikasi
            db.crud(
                "SELECT COUNT(*) FROM absensi WHERE tanggal = @tgl AND id_kelas = @kelas AND jam_pelajaran = @jam",
                new MySqlParameter("@tgl", tgl),
                new MySqlParameter("@kelas", idKelas),
                new MySqlParameter("@jam", jamPelajaran)
            );

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

                    db.crud(
                        @"INSERT INTO absensi (tanggal, id_kelas, jam_pelajaran, id_siswa, keterangan, id_guru, id_jadwal) 
                          VALUES (@tgl, @kelas, @jam, @siswa, @ket, @guru, @jadwal)",
                        new MySqlParameter("@tgl", tgl),
                        new MySqlParameter("@kelas", idKelas),
                        new MySqlParameter("@jam", jamPelajaran),
                        new MySqlParameter("@siswa", idSiswa),
                        new MySqlParameter("@ket", ket),
                        new MySqlParameter("@guru", idGuru),
                        new MySqlParameter("@jadwal", idJadwalParam)
                    );
                }
            }

            MessageBox.Show("Data absensi berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            guna2DataGridView1.Rows.Clear();
            cmbKelas.SelectedIndex = -1;
            cmbJam.SelectedIndex = -1;
        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {
            LoadJadwalHariIni();
        }

        private void cmbJam_DropDown(object sender, EventArgs e)
        {
            if (cmbJam.Items.Count == 0)
            {
                IsiDaftarJam();
            }
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

                row.Visible = namaSiswa.Contains(kataKunci) || nisSiswa.Contains(kataKunci);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load("REPORT ABSENSI HARIAN.rpt");

            string pdfPath = Path.Combine(Path.GetTempPath(), "Laporan_Absen.pdf");
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfPath);

            System.Diagnostics.Process.Start(pdfPath);
        }

        private void guna2Shapes7_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FRpt CBL = new FRpt();
            CBL.ShowDialog();
        }
    }
}