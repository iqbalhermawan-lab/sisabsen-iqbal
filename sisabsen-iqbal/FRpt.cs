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

namespace sisabsen_iqbal
{
    public partial class FRpt : Form
    {
        private ReportDocument DokumenLaporan;
        public FRpt()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string reportPath = Path.Combine(Application.StartupPath, "REPORT ABSENSI HARIAN.rpt");

            try
            {
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show(
                        "File report tidak ditemukan:\n" + reportPath,
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                DokumenLaporan = new ReportDocument();
                DokumenLaporan.Load(reportPath);

                crystalReportViewer1.ReportSource = DokumenLaporan;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan report:\n" + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                if (DokumenLaporan != null)
                {
                    DokumenLaporan.Close();
                    DokumenLaporan.Dispose();
                    DokumenLaporan = null;
                }
            }
        }
    }
}
