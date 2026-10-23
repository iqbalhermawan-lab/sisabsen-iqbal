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
    public partial class FSiswa : Form
    {
        public FSiswa()
        {
            InitializeComponent();
        }

        public void tampildata()
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;
            db.crud("SELECT * FROM siswa INNER JOIN kelas ON siswa.id_kelas = kelas.id_kelas");
            foreach (DataRow Row in db.ds.Tables[0].Rows)
            {
                string id = "" + Row["id_siswa"];
                string nis = "" + Row["nis"];
                string Nama = "" + Row["nama"];
                string jk = "" + Row["jenis_kelamin"];
                string kls = "" + Row["nama_kelas"];
                guna2DataGridView1.Rows.Add(no, id, nis, Nama, jk, kls);
                no++;
            }
        }

        public void bersih()
        {
            txtNis.Clear();
            txtNama.Clear();
            cmbJK.Text = "";
            cmbKls.Text = "";
        }

        private void FSiswa_Load(object sender, EventArgs e)
        {
            tampildata();
            guna2DataGridView1.Columns["Column1"].Visible = false;
            guna2HtmlLabel6.Visible = false;
            loadkelas();
        }

        private void cmbJK_DropDown(object sender, EventArgs e)
        {
            cmbJK.Items.Clear();
            cmbJK.Items.AddRange(new string[] { "L", "P" });
        }

        private void cmbKls_DropDown(object sender, EventArgs e)
        {
            db.crud("SELECT * FROM kelas");
            cmbKls.Items.Clear();

            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string role = "" + row["nama_kelas"];
                cmbKls.Items.Add(role);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNis.Text == "" || txtNama.Text == "" || cmbJK.SelectedIndex == -1 || cmbKls.SelectedIndex == -1)
            {
                DialogResult DataKosong = MessageBox.Show("Masukan Data yang Lengkap!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string nis = txtNis.Text;
                string Nama = txtNama.Text;
                string jk = cmbJK.Text;
                string kls = cmbKls.Text;
                db.crud($"INSERT INTO siswa VALUES (null, '{nis}', '{Nama}', '{jk}', (SELECT id_kelas FROM kelas WHERE nama_kelas = '{kls}'));");
                bersih();
                tampildata();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Baris = e.RowIndex;
            int Kolom = e.ColumnIndex;

            if (Kolom == 6)
            {
                string id = guna2DataGridView1.Rows[Baris].Cells[0].Value.ToString();
                db.crud($"SELECT s.*, k.nama_kelas FROM siswa s JOIN kelas k ON s.id_kelas = k.id_kelas WHERE s.id_siswa = '{id}'");
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    string idS = "" + row["id_siswa"];
                    string nis = "" + row["nis"];
                    string nama = "" + row["nama"];
                    string jk = "" + row["jenis_kelamin"];
                    string kls = "" + row["nama_kelas"];

                    guna2HtmlLabel6.Text = idS;
                    txtNis.Text = nis;
                    txtNama.Text = nama;
                    cmbJK.Text = jk;
                    cmbKls.Text = kls;
                }
            }

            if (Kolom == 7)
            {
                string idsi = guna2DataGridView1.Rows[Baris].Cells[0].Value.ToString();
                DialogResult Hapus = MessageBox.Show("Data Anda Akan Dihapus!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (Hapus == DialogResult.OK)
                {
                    db.crud($"DELETE FROM siswa WHERE id_siswa = '{idsi}' ");
                    tampildata();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = guna2HtmlLabel6.Text;
            string nis = txtNis.Text;
            string nama = txtNama.Text;
            string jk = cmbJK.Text;
            string kls = cmbKls.Text;

            db.crud($"UPDATE siswa SET nis = '{nis}', nama = '{nama}', jenis_kelamin = '{jk}', id_kelas = (SELECT id_kelas FROM kelas WHERE nama_kelas = '{kls}') WHERE id_siswa = '{id}'");
            bersih();
            tampildata();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;
            db.crud($"SELECT * FROM siswa INNER JOIN kelas ON siswa.id_kelas = kelas.id_kelas WHERE siswa.nama LIKE '%{txtSearch.Text}%' OR kelas.nama_kelas LIKE '%{txtSearch.Text}%'");
            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string id = "" + row["id_siswa"];
                string nis = "" + row["nis"];
                string nama = "" + row["nama"];
                string jk = "" + row["jenis_kelamin"];
                string kls = "" + row["nama_kelas"];
                guna2DataGridView1.Rows.Add(no, id, nis, nama, jk, kls);
                no++;
            }
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

        public void loadkelas()
        {
            db.crud("SELECT id_kelas, nama_kelas FROM kelas");

            // kode agar datanya tidak hilang saat db.crud dipanggil lagi nanti
            DataTable dtKelas = db.ds.Tables[0].Copy();

            cmbKelas.DataSource = dtKelas;
            cmbKelas.DisplayMember = "nama_kelas";
            cmbKelas.ValueMember = "id_kelas";
            cmbKelas.SelectedIndex = -1;
        }
    }
}
