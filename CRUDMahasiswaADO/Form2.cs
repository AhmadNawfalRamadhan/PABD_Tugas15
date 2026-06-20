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
        static string connectionString = "Data Source=LAPTOP-PH9T3875\\NAWFAL;Initial Catalog=DBAkademikADO;Integrated Security=True";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlDataAdapter da;
        DataTable dtMahasiswa;

        RekapMahasiswa1 rekapMahasiswa = new RekapMahasiswa1();

        string prodi { get; set; }
        DateTime tglmasuk { get; set; }

        public Form2(string Prodi, DateTime TglMasuk)
        {
            InitializeComponent();
            prodi = Prodi;
            tglmasuk = TglMasuk;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("sp_Report", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inProdi", prodi);
                cmd.Parameters.AddWithValue("@inTglMsuk", tglmasuk.Year.ToString());

                da = new SqlDataAdapter(cmd);

                dtMahasiswa = new DataTable();
                da.Fill(dtMahasiswa);

                conn.Close();

                rekapMahasiswa.SetDataSource(dtMahasiswa);
                crystalReportViewer1.ReportSource = rekapMahasiswa;
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
