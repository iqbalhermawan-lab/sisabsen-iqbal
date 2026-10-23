using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace sisabsen_iqbal
{
    public partial class FDashboard : Form
    {
        private bool isLogout = false;

        public FDashboard()
        {
            InitializeComponent();
        }

        private void AturHakAkses()
        {
            btnDataM.Visible = false;
            btnAbsenH.Visible = false;

            switch (UserSession.IdRole)
            {
                case 1: // admin
                    btnDataM.Visible = true;
                    btnAbsenH.Visible = true;
                    break;

                case 2: // Walikelas
                    btnAbsenH.Visible = true;
                    break;

                case 3: // Guru
                    btnAbsenH.Visible = true;
                    break;
            }
        }

        private void LoadStatistik()
        {
            // Total Siswa
            db.crud("SELECT COUNT(*) AS total FROM siswa");
            if (db.ds.Tables[0].Rows.Count > 0)
                lblTotalSiswa.Text = db.ds.Tables[0].Rows[0]["total"].ToString();

            // Total Kelas
            db.crud("SELECT COUNT(*) AS total FROM kelas");
            if (db.ds.Tables[0].Rows.Count > 0)
                lblTotalKelas.Text = db.ds.Tables[0].Rows[0]["total"].ToString();

            // Total Guru
            db.crud("SELECT COUNT(*) AS total FROM guru");
            if (db.ds.Tables[0].Rows.Count > 0)
                lblTotalGuru.Text = db.ds.Tables[0].Rows[0]["total"].ToString();

            // Hadir Hari Ini
            db.crud($"SELECT COUNT(*) AS total FROM absensi WHERE tanggal = CURDATE() AND keterangan = 'Hadir'");
            if (db.ds.Tables[0].Rows.Count > 0)
                lblHadirHariIni.Text = db.ds.Tables[0].Rows[0]["total"].ToString();

            // Tidak Hadir Hari Ini (Izin + Sakit + Alpa)
            db.crud($"SELECT COUNT(*) AS total FROM absensi WHERE tanggal = CURDATE() AND keterangan != 'Hadir'");
            if (db.ds.Tables[0].Rows.Count > 0)
                lblTidakHadir.Text = db.ds.Tables[0].Rows[0]["total"].ToString();
        }

        private void LoadAbsensiTerbaru()
        {
            string query = @"
                SELECT 
                    s.nama AS nama_siswa,
                    k.nama_kelas,
                    a.jam_pelajaran,
                    a.keterangan,
                    g.nama_guru
                FROM absensi a
                INNER JOIN siswa s ON a.id_siswa = s.id_siswa
                INNER JOIN kelas k ON a.id_kelas = k.id_kelas
                INNER JOIN guru g ON a.id_guru = g.id_guru
                WHERE a.tanggal = CURDATE()
                ORDER BY a.id_absensi DESC
                LIMIT 10";

            db.crud(query);
            dgvAbsensiTerbaru.Rows.Clear();

            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string nama = row["nama_siswa"].ToString();
                string kelas = row["nama_kelas"].ToString();
                string jam = row["jam_pelajaran"].ToString();
                string status = row["keterangan"].ToString();
                string guru = row["nama_guru"].ToString();

                int rowIdx = dgvAbsensiTerbaru.Rows.Add(nama, kelas, jam, status, guru);

                // Warna baris berdasarkan keterangan
                Color rowColor = Color.White;
                switch (status)
                {
                    case "Hadir":  rowColor = Color.FromArgb(220, 252, 231); break;
                    case "Izin":   rowColor = Color.FromArgb(219, 234, 254); break;
                    case "Sakit":  rowColor = Color.FromArgb(254, 249, 195); break;
                    case "Alpa":   rowColor = Color.FromArgb(254, 226, 226); break;
                }

                foreach (DataGridViewCell cell in dgvAbsensiTerbaru.Rows[rowIdx].Cells)
                    cell.Style.BackColor = rowColor;
            }

            if (dgvAbsensiTerbaru.Rows.Count == 0)
            {
                lblNoData.Visible = true;
            }
            else
            {
                lblNoData.Visible = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // kembali ke dashboard (refresh)
            LoadStatistik();
            LoadAbsensiTerbaru();
            FDashboard dashboard = new FDashboard();
            dashboard.Visible = true;
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FUser user = new FUser() { TopLevel = false, TopMost = true };
            KF.untukForm(user, pnlContent);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlDP.Visible = !pnlDP.Visible;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FRole role = new FRole() { TopLevel = false, TopMost = true };
            KF.untukForm(role, pnlContent);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FSiswa siswa = new FSiswa() { TopLevel = false, TopMost = true };
            KF.untukForm(siswa, pnlContent);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            FKelas kelas = new FKelas() { TopLevel = false, TopMost = true };
            KF.untukForm(kelas, pnlContent);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            FGuru guru = new FGuru() { TopLevel = false, TopMost = true };
            KF.untukForm(guru, pnlContent);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            FAbsenH absenH = new FAbsenH() { TopLevel = false, TopMost = true };
            KF.untukForm(absenH, pnlContent);
        }

        private void FAbsenK_Click(object sender, EventArgs e)
        {
            FAbsenK absenK = new FAbsenK() { TopLevel = false, TopMost = true };
            KF.untukForm(absenK, pnlContent);
        }

        private void FDashboard_Load(object sender, EventArgs e)
        {
            AturHakAkses();
            timerWaktu.Start();

            // Tampilkan nama user yang login
            string namaUser = !string.IsNullOrEmpty(UserSession.Username)
                ? UserSession.Username
                : "User";
            lblGreeting.Text = $"Selamat Datang, {namaUser}!";

            LoadStatistik();
            LoadAbsensiTerbaru();
        }

        private void timerWaktu_Tick(object sender, EventArgs e)
        {
            CultureInfo budayaIndonesia = new CultureInfo("id-ID");
            lblWaktu.Text = DateTime.Now.ToString("dddd, dd MMM yyyy  |  HH:mm:ss", budayaIndonesia);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                isLogout = true;
                UserSession.Logout();
                FLogin formLogin = new FLogin();
                formLogin.Show();
                this.Close();
            }
        }

        private void FDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLogout)
            {
                Application.Exit();
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            FRpt report = new FRpt() { TopLevel = false, TopMost = true };
            KF.untukForm(report, pnlContent);
        }
    }
}
