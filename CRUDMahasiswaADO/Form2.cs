using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    public partial class Form2: Form
    {
        DAL dbLogic = new DAL();
        static string connectionString = "Data Source=LAPTOP-PH9T3875\\NAWFAL;Initial Catalog=DBAkademikADO;Integrated Security=True";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlDataAdapter da;
        DataTable dtMahasiswa;

        RekapMahasiswa1 rekapMahasiswa = new RekapMahasiswa1();

        // Sesuaikan dengan nama file .rpt Anda = LaporanMahasiswa
        readonly RekapMahasiswa1 laporanMahasiswa = new RekapMahasiswa1();
        RekapMahasiswa1 listMahasiswa = new RekapMahasiswa1();

        string prodi { get; set; }
        DateTime tglmasuk { get; set; }

        public Form2(string Prodi, DateTime TglMasuk)
        {
            InitializeComponent();

            prodi = Prodi;
            tglmasuk = TglMasuk;

            try
            {
                DataTable dtMahasiswa = dbLogic.getDataRekap(prodi, tglmasuk);

                listMahasiswa.SetDataSource(dtMahasiswa);
                crystalReportViewer1.ReportSource = listMahasiswa;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                //simpanLog(ex.Message);
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
