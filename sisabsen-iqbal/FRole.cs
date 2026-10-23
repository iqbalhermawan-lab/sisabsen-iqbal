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
    public partial class FRole : Form
    {
        public FRole()
        {
            InitializeComponent();
        }

        public void tampildata()
        {
            guna2DataGridView1.Rows.Clear();
            db.crud("SELECT * FROM roles");
            int no = 1;
            foreach (DataRow Row in db.ds.Tables[0].Rows)
            {
                string id = "" + Row["id_role"];
                string role = "" + Row["role"];
                guna2DataGridView1.Rows.Add(no, id, role);
                no++;
            }
        }

        public void bersih()
        {
            txtRole.Clear();
        }

        private void FRole_Load(object sender, EventArgs e)
        {
            tampildata();
            guna2DataGridView1.Columns["Column1"].Visible = false;
            guna2HtmlLabel6.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRole.Text == "")
            {
                DialogResult DataKosong = MessageBox.Show("Masukan Data yang Lengkap!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string role = txtRole.Text;
                db.crud($"INSERT INTO roles VALUES (null, '{role}')");
                bersih();
                tampildata();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Baris = e.RowIndex;
            int Kolom = e.ColumnIndex;

            if (Kolom == 3)
            {
                string id = guna2DataGridView1.Rows[Baris].Cells[0].Value.ToString();
                db.crud($"SELECT * FROM roles WHERE id_role = '{id}'");
                foreach (DataRow row in db.ds.Tables[0].Rows)
                {
                    string idR = "" + row["id_role"];
                    string role = "" + row["role"];

                    guna2HtmlLabel6.Text = idR;
                    txtRole.Text = role;
                }
            }

            if (Kolom == 4)
            {
                string idba = guna2DataGridView1.Rows[Baris].Cells[0].Value.ToString();
                DialogResult Hapus = MessageBox.Show("Data Anda Akan Dihapus!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (Hapus == DialogResult.OK)
                {
                    db.crud($"DELETE FROM roles WHERE id_role = '{idba}' ");
                    tampildata();
                }
            }
            //bersih();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = guna2HtmlLabel6.Text;
            string role = txtRole.Text;

            db.crud($"UPDATE roles SET role = '{role}' WHERE id_role = '{id}'");
            bersih();
            tampildata();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            int no = 1;
            db.crud($"SELECT * FROM roles WHERE role LIKE '%{txtSearch.Text}%'");
            foreach (DataRow row in db.ds.Tables[0].Rows)
            {
                string id = "" + row["id_role"];
                string role = "" + row["role"];
                guna2DataGridView1.Rows.Add(no, id, role);
                no++;
            }
        }
    }
}
