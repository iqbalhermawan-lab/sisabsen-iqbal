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
    public partial class FKelas : Form
    {
        public FKelas()
        {
            InitializeComponent();
        }

        public void tampildata()
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;
            db.crud("SELECT * FROM kelas INNER JOIN guru ON kelas.id_guru = guru.id_guru");
            foreach (DataRow Row in db.ds.Tables[0].Rows)
            {
                string id = "" + Row["id_kelas"];
                string tk = "" + Row["tingkat"];
                string nk = "" + Row["nama_kelas"];
                string wk = "" + Row["nama_guru"];
                guna2DataGridView1.Rows.Add(no, id, tk, nk, wk);
                no++;
            }
        }

        public void bersih()
        {
            cmbTk.Text = "";
            txtNK.Clear();
            cmbWK.Text = "";
        }

        private void FKelas_Load(object sender, EventArgs e)
        {
            tampildata();
            guna2DataGridView1.Columns["Column1"].Visible = false;
            guna2HtmlLabel6.Visible = false;
            loadkelas();
        }

        private void cmbTk_DropDown(object sender, EventArgs e)
        {
            cmbTk.Items.Clear();
            cmbTk.Items.AddRange(new string[] { "X", "XI", "XII" });
        }

        private void cmbWK_DropDown(object sender, EventArgs e)
        {
            db.crud("SELECT * FROM guru");
            cmbWK.Items.Clear();

            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string role = "" + row["nama_guru"];
                cmbWK.Items.Add(role);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbTk.SelectedIndex == -1 || txtNK.Text == "" || cmbWK.SelectedIndex == -1)
            {
                DialogResult DataKosong = MessageBox.Show("Masukan Data yang Lengkap!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string tk = cmbTk.Text;
                string nk = txtNK.Text;
                string wk = cmbWK.Text;
                db.crud($"INSERT INTO kelas VALUES (null, '{tk}', '{nk}', (SELECT id_guru FROM guru WHERE nama_guru = '{wk}')) ;");
                bersih();
                tampildata();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Baris = e.RowIndex;
            int Kolom = e.ColumnIndex;

            if (Kolom == 5)
            {
                string id = guna2DataGridView1.Rows[Baris].Cells[0].Value.ToString();
                db.crud($"SELECT k.*, g.nama_guru FROM kelas k JOIN guru g ON k.id_guru = g.id_guru WHERE k.id_kelas = '{id}'");
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    string idK = "" + row["id_kelas"];
                    string tk = "" + row["tingkat"];
                    string nk = "" + row["nama_kelas"];
                    string wk = "" + row["nama_guru"];

                    guna2HtmlLabel6.Text = idK;
                    cmbTk.Text = tk;
                    txtNK.Text = nk;
                    cmbWK.Text = wk;
                }
            }

            if (Kolom == 6)
            {
                string idke = guna2DataGridView1.Rows[Baris].Cells[0].Value.ToString();
                DialogResult Hapus = MessageBox.Show("Data Anda Akan Dihapus!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (Hapus == DialogResult.OK)
                {
                    db.crud($"DELETE FROM kelas WHERE id_kelas = '{idke}' ");
                    tampildata();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = guna2HtmlLabel6.Text;
            string tk = cmbTk.Text;
            string nk = txtNK.Text;
            string wk = cmbWK.Text;

            db.crud($"UPDATE kelas SET tingkat = '{tk}', nama_kelas = '{nk}', id_guru = (SELECT id_guru FROM guru WHERE nama_guru = '{wk}') WHERE id_kelas = '{id}'");
            bersih();
            tampildata();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;
            db.crud($"SELECT * FROM kelas INNER JOIN guru ON kelas.id_guru = guru.id_guru WHERE kelas.nama_kelas LIKE '%{txtSearch.Text}%' OR guru.nama_guru LIKE '%{txtSearch.Text}%'");
            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string id = "" + row["id_kelas"];
                string tk = "" + row["tingkat"];
                string nk = "" + row["nama_kelas"];
                string wk = "" + row["nama_guru"];
                guna2DataGridView1.Rows.Add(no, id, tk, nk, wk);
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

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
