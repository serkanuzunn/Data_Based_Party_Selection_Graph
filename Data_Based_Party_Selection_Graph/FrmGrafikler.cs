using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Data_Based_Party_Selection_Graph
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-BALF27M\SQLEXPRESS;Initial Catalog=ElectionProjectDB;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select ILCEAD from TBLILCE", sqlConnection);
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand cmd2 = new SqlCommand("Select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) from TBLILCE", sqlConnection);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ",dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ",dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ",dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ",dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ",dr2[4]);
            }
            sqlConnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBLILCE where ILCEAD=@P1", sqlConnection);
            cmd.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                LBLA.Text = dr[2].ToString();
                LBLB.Text = dr[3].ToString();
                LBLC.Text = dr[4].ToString();
                LBLD.Text = dr[5].ToString();
                LBLE.Text = dr[6].ToString();
            }
            sqlConnection.Close();
        }
    }
}
