using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sisabsen_iqbal
{
    public partial class FJadwal : Form
    {
        public FJadwal()
        {
            InitializeComponent();
        }

        private void LoadDropdown()
        {
            cmbHari.Items.Clear();
            cmbHari.Items.AddRange(new string[] { "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu" });

            cmbJam.Items.Clear();
            cmbJam.Items.AddRange(new string[] {
                "Jam ke-01", "Jam ke-02", "Jam ke-03", "Jam ke-04",
                "Jam ke-05", "Jam ke-06", "Jam ke-07", "Jam ke-08"
            });

            // Load Kelas
            db.crud("SELECT id_kelas, nama_kelas FROM kelas ORDER BY nama_kelas ASC");
            DataTable dtKelas = db.ds.Tables[0].Copy();
            cmbKelas.DataSource = dtKelas;
            cmbKelas.DisplayMember = "nama_kelas";
            cmbKelas.ValueMember = "id_kelas";
            cmbKelas.SelectedIndex = -1;

            // Load Mapel
            db.crud("SELECT id_mapel, CONCAT(kode_mapel, ' - ', nama_mapel) AS label_mapel FROM mapel ORDER BY nama_mapel ASC");
            DataTable dtMapel = db.ds.Tables[0].Copy();
            cmbMapel.DataSource = dtMapel;
            cmbMapel.DisplayMember = "label_mapel";
            cmbMapel.ValueMember = "id_mapel";
            cmbMapel.SelectedIndex = -1;

            // Load Guru
            db.crud("SELECT id_guru, nama_guru FROM guru ORDER BY nama_guru ASC");
            DataTable dtGuru = db.ds.Tables[0].Copy();
            cmbGuru.DataSource = dtGuru;
            cmbGuru.DisplayMember = "nama_guru";
            cmbGuru.ValueMember = "id_guru";
            cmbGuru.SelectedIndex = -1;
        }

        public void TampilData(string keyword = "")
        {
            dgvJadwal.Rows.Clear();
            int no = 1;

            string baseQuery = @"
                SELECT 
                    j.id_jadwal,
                    j.hari,
                    j.jam_pelajaran,
                    k.nama_kelas,
                    m.nama_mapel,
                    g.nama_guru
                FROM jadwal_mengajar j
                INNER JOIN kelas k ON j.id_kelas = k.id_kelas
                INNER JOIN mapel m ON j.id_mapel = m.id_mapel
                INNER JOIN guru g ON j.id_guru = g.id_guru ";

            if (string.IsNullOrWhiteSpace(keyword))
            {
                db.crud(baseQuery + "ORDER BY FIELD(j.hari,'Senin','Selasa','Rabu','Kamis','Jumat','Sabtu'), j.jam_pelajaran, k.nama_kelas");
            }
            else
            {
                db.crud(
                    baseQuery + @"WHERE j.hari LIKE @kw OR k.nama_kelas LIKE @kw OR m.nama_mapel LIKE @kw OR g.nama_guru LIKE @kw
                                  ORDER BY FIELD(j.hari,'Senin','Selasa','Rabu','Kamis','Jumat','Sabtu'), j.jam_pelajaran",
                    new MySqlParameter("@kw", $"%{keyword}%")
                );
            }

            if (db.ds.Tables.Count > 0)
            {
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    dgvJadwal.Rows.Add(
                        no++,
                        row["id_jadwal"].ToString(),
                        row["hari"].ToString(),
                        row["jam_pelajaran"].ToString(),
                        row["nama_kelas"].ToString(),
                        row["nama_mapel"].ToString(),
                        row["nama_guru"].ToString()
                    );
                }
            }
        }

        public void Bersih()
        {
            lblIdJadwal.Text = "";
            cmbHari.SelectedIndex = -1;
            cmbJam.SelectedIndex = -1;
            cmbKelas.SelectedIndex = -1;
            cmbMapel.SelectedIndex = -1;
            cmbGuru.SelectedIndex = -1;
        }

        private bool IsBentrok(string hari, string jam, string idKelas, string idGuru, string excludeIdJadwal = "0")
        {
            // 1. Cek bentrok kelas (1 kelas tidak boleh punya 2 mapel di hari & jam sama)
            db.crud(
                "SELECT COUNT(*) FROM jadwal_mengajar WHERE hari = @hari AND jam_pelajaran = @jam AND id_kelas = @kelas AND id_jadwal != @id",
                new MySqlParameter("@hari", hari),
                new MySqlParameter("@jam", jam),
                new MySqlParameter("@kelas", idKelas),
                new MySqlParameter("@id", excludeIdJadwal)
            );
            if (Convert.ToInt32(db.ds.Tables[0].Rows[0][0]) > 0)
            {
                MessageBox.Show("Jadwal bentrok! Kelas ini sudah memiliki pelajaran pada hari dan jam tersebut.", "Jadwal Bentrok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            // 2. Cek bentrok guru (1 guru tidak boleh mengajar 2 kelas berbeda di hari & jam sama)
            db.crud(
                "SELECT COUNT(*) FROM jadwal_mengajar WHERE hari = @hari AND jam_pelajaran = @jam AND id_guru = @guru AND id_jadwal != @id",
                new MySqlParameter("@hari", hari),
                new MySqlParameter("@jam", jam),
                new MySqlParameter("@guru", idGuru),
                new MySqlParameter("@id", excludeIdJadwal)
            );
            if (Convert.ToInt32(db.ds.Tables[0].Rows[0][0]) > 0)
            {
                MessageBox.Show("Jadwal bentrok! Guru tersebut sudah terjadwal mengajar di kelas lain pada hari dan jam yang sama.", "Jadwal Bentrok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        private void FJadwal_Load(object sender, EventArgs e)
        {
            LoadDropdown();
            TampilData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbHari.SelectedIndex == -1 || cmbJam.SelectedIndex == -1 ||
                cmbKelas.SelectedIndex == -1 || cmbMapel.SelectedIndex == -1 || cmbGuru.SelectedIndex == -1)
            {
                MessageBox.Show("Lengkapi seluruh pilihan jadwal mengajar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string hari = cmbHari.Text;
            string jam = cmbJam.Text;
            string idKelas = cmbKelas.SelectedValue.ToString();
            string idMapel = cmbMapel.SelectedValue.ToString();
            string idGuru = cmbGuru.SelectedValue.ToString();

            if (IsBentrok(hari, jam, idKelas, idGuru)) return;

            db.crud(
                "INSERT INTO jadwal_mengajar (hari, jam_pelajaran, id_kelas, id_mapel, id_guru) VALUES (@hari, @jam, @kelas, @mapel, @guru)",
                new MySqlParameter("@hari", hari),
                new MySqlParameter("@jam", jam),
                new MySqlParameter("@kelas", idKelas),
                new MySqlParameter("@mapel", idMapel),
                new MySqlParameter("@guru", idGuru)
            );

            MessageBox.Show("Jadwal mengajar berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bersih();
            TampilData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblIdJadwal.Text))
            {
                MessageBox.Show("Pilih jadwal pada tabel yang ingin diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string hari = cmbHari.Text;
            string jam = cmbJam.Text;
            string idKelas = cmbKelas.SelectedValue.ToString();
            string idMapel = cmbMapel.SelectedValue.ToString();
            string idGuru = cmbGuru.SelectedValue.ToString();

            if (IsBentrok(hari, jam, idKelas, idGuru, lblIdJadwal.Text)) return;

            db.crud(
                @"UPDATE jadwal_mengajar 
                  SET hari = @hari, jam_pelajaran = @jam, id_kelas = @kelas, id_mapel = @mapel, id_guru = @guru 
                  WHERE id_jadwal = @id",
                new MySqlParameter("@hari", hari),
                new MySqlParameter("@jam", jam),
                new MySqlParameter("@kelas", idKelas),
                new MySqlParameter("@mapel", idMapel),
                new MySqlParameter("@guru", idGuru),
                new MySqlParameter("@id", lblIdJadwal.Text)
            );

            MessageBox.Show("Jadwal mengajar berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bersih();
            TampilData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Bersih();
        }

        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string idJadwal = dgvJadwal.Rows[e.RowIndex].Cells[1].Value.ToString();

            // Kolom 7 = Edit
            if (e.ColumnIndex == 7)
            {
                db.crud("SELECT * FROM jadwal_mengajar WHERE id_jadwal = @id", new MySqlParameter("@id", idJadwal));
                if (db.ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = db.ds.Tables[0].Rows[0];
                    lblIdJadwal.Text = r["id_jadwal"].ToString();
                    cmbHari.Text = r["hari"].ToString();
                    cmbJam.Text = r["jam_pelajaran"].ToString();
                    cmbKelas.SelectedValue = Convert.ToInt32(r["id_kelas"]);
                    cmbMapel.SelectedValue = Convert.ToInt32(r["id_mapel"]);
                    cmbGuru.SelectedValue = Convert.ToInt32(r["id_guru"]);
                }
            }

            // Kolom 8 = Hapus
            if (e.ColumnIndex == 8)
            {
                DialogResult konfirmasi = MessageBox.Show("Hapus jadwal mengajar ini?", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (konfirmasi == DialogResult.OK)
                {
                    db.crud("DELETE FROM jadwal_mengajar WHERE id_jadwal = @id", new MySqlParameter("@id", idJadwal));
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