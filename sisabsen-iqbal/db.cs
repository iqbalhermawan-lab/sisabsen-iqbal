using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace sisabsen_iqbal
{
    class db
    {
        public static MySqlConnection koneksi = new MySqlConnection("server=127.0.0.1;username=root;password=;database=absensi_siswa");
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand perintah;

        public static void crud(string query)
        {
            Console.WriteLine(query);
            ds.Tables.Clear();

            try
            {
                if (koneksi.State != ConnectionState.Open)
                    koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                da = new MySqlDataAdapter(perintah);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }
        }

        // Untuk query dengan parameter
        public static void crud(string query, params MySqlParameter[] parameters)
        {
            Console.WriteLine(query);
            ds.Tables.Clear();

            try
            {
                if (koneksi.State != ConnectionState.Open)
                    koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);

                if (parameters != null)
                {
                    perintah.Parameters.AddRange(parameters);
                }

                da = new MySqlDataAdapter(perintah);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }
        }
    }
}
