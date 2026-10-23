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
    public partial class FGuru : Form
    {
        public FGuru()
        {
            InitializeComponent();
        }

        public void tampildata()
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;
            db.crud("SELECT * FROM guru INNER JOIN users ON guru.id_user = users.id_user");
            foreach (DataRow Row in db.ds.Tables[0].Rows)
            {
                string id = "" + Row["id_guru"];
                string nip = "" + Row["nip"];
                string ng = "" + Row["nama_guru"];
                string user = "" + Row["username"];
                guna2DataGridView1.Rows.Add(no, id, nip, ng, user);
                no++;
            }
        }

        public void bersih()
        {
            txtNip.Clear();
            txtNG.Clear();
            cmbUser.Text = "";
        }

        private void FGuru_Load(object sender, EventArgs e)
        {
            tampildata();
            guna2DataGridView1.Columns["Column1"].Visible = false;
            guna2HtmlLabel6.Visible = false;
        }

        private void cmbUser_DropDown(object sender, EventArgs e)
        {
            db.crud("SELECT * FROM users");
            cmbUser.Items.Clear();

            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string role = "" + row["username"];
                cmbUser.Items.Add(role);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNip.Text == "" || txtNG.Text == "" || cmbUser.SelectedIndex == -1)
            {
                DialogResult DataKosong = MessageBox.Show("Masukan Data yang Lengkap!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string nip = txtNip.Text;
                string ng = txtNG.Text;
                string user = cmbUser.Text;
                db.crud($"INSERT INTO guru VALUES (null, '{nip}', '{ng}', (SELECT id_user FROM users WHERE username = '{user}'))"); bersih();
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
                db.crud($"SELECT g.*, u.username FROM guru g JOIN users u ON g.id_user = u.id_user WHERE g.id_guru = '{id}'");
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    string idG = "" + row["id_guru"];
                    string nip = "" + row["nip"];
                    string ng = "" + row["nama_guru"];
                    string user = "" + row["username"];

                    guna2HtmlLabel6.Text = idG;
                    txtNip.Text = nip;
                    txtNG.Text = ng;
                    cmbUser.Text = user;
                }
            }

            if (Kolom == 6)
            {
                string idgu = guna2DataGridView1.Rows[Baris].Cells[0].Value.ToString();
                DialogResult Hapus = MessageBox.Show("Data Anda Akan Dihapus!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (Hapus == DialogResult.OK)
                {
                    db.crud($"DELETE FROM guru WHERE id_guru = '{idgu}' ");
                    tampildata();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = guna2HtmlLabel6.Text;
            string nip = txtNip.Text;
            string ng = txtNG.Text;
            string user = cmbUser.Text;

            db.crud($"UPDATE guru SET nip = '{nip}', nama_guru = '{ng}', id_user = (SELECT id_user FROM users WHERE username = '{user}') WHERE id_guru = '{id}'"); bersih();
            tampildata();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;
            db.crud($"SELECT * FROM guru INNER JOIN users ON guru.id_user = users.id_user WHERE guru.nama_guru LIKE '%{txtSearch.Text}%' OR users.username LIKE '%{txtSearch.Text}%'");
            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string id = "" + row["id_guru"];
                string nip = "" + row["nip"];
                string ng = "" + row["nama_guru"];
                string user = "" + row["username"];
                guna2DataGridView1.Rows.Add(no, id, nip, ng, user);
                no++;
            }
        }
    }
}
