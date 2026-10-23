using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sisabsen_iqbal
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_TextChanged(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = $"SELECT * FROM users WHERE username = '{username}'";
            db.crud(query);

            if (db.ds.Tables[0].Rows.Count > 0)
            {
                string passwordHash =
                    db.ds.Tables[0].Rows[0]["password"].ToString();

                // VERIFIKASI PASSWORD
                bool passwordBenar =
                    BCrypt.Net.BCrypt.Verify(password, passwordHash);

                if (passwordBenar)
                {
                    MessageBox.Show(
                        "Login Berhasil!",
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    FDashboard dashboard = new FDashboard();
                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Username atau Password salah!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "Username atau Password salah!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = $"SELECT * FROM users WHERE username = @username";
            db.crud(
                query,
                new MySqlParameter("@username", username)
            );

            if (db.ds.Tables[0].Rows.Count > 0)
            {
                string passwordHash = db.ds.Tables[0].Rows[0]["password"].ToString();
                // CEK PASSWORD DENGAN BCRYPT
                bool passwordBenar = BCrypt.Net.BCrypt.Verify(password, passwordHash);

                if (passwordBenar)
                {
                    MessageBox.Show("Login Berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UserSession.IdUser = Convert.ToInt32(db.ds.Tables[0].Rows[0]["id_user"]);
                    UserSession.Username = db.ds.Tables[0].Rows[0]["username"].ToString();
                    UserSession.IdRole = Convert.ToInt32(db.ds.Tables[0].Rows[0]["id_role"]);

                    if (UserSession.IdRole == 2 || UserSession.IdRole == 3)
                    {
                        string queryGuru = $"SELECT id_guru FROM guru WHERE id_user = '{UserSession.IdUser}'";
                        db.crud(queryGuru);

                        if (db.ds.Tables[0].Rows.Count > 0)
                        {
                            UserSession.IdGuru = Convert.ToInt32(db.ds.Tables[0].Rows[0]["id_guru"]);
                        }
                    }

                    FDashboard dashboard = new FDashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username atau Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
