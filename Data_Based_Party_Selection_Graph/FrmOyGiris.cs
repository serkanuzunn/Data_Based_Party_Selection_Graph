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
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection=new SqlConnection(@"Data Source=DESKTOP-BALF27M\SQLEXPRESS;Initial Catalog=ElectionProjectDB;Integrated Security=True");

        private void BtnOyGiris_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLILCE(ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values (@P1,@P2,@P3,@P4,@P5,@P6)", sqlConnection);
            cmd.Parameters.AddWithValue("@P1", TxtIlceAd.Text);
            cmd.Parameters.AddWithValue("@P2", TxtA.Text);
            cmd.Parameters.AddWithValue("@P3", TxtB.Text);
            cmd.Parameters.AddWithValue("@P4", TxtC.Text);
            cmd.Parameters.AddWithValue("@P5", TxtD.Text);
            cmd.Parameters.AddWithValue("@P6", TxtE.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti.");
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm=new FrmGrafikler();
            frm.Show();
        }
    }
}
