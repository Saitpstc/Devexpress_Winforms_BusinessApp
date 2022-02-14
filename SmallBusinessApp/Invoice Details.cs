using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace SmallBusinessApp
{
    public partial class Invoice_Details : DevExpress.XtraEditors.XtraForm
    {
        public Invoice_Details()
        {
            InitializeComponent();
        }

        public int id;
        private void Invoice_Details_Load(object sender, EventArgs e)
        {
            
   
            //utilities.ClearTextBoxes(this.Controls);
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand("select urun_ad from urunler2;select * from faturadetay where faturaid='"+id+"' ",
                           con))
                {

                    NpgsqlDataReader read
                        = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        comboBoxEdit1.Properties.Items.Add(read[0].ToString());

                    }

                    read.NextResult();
                    DataTable dt= new DataTable();
                    dt.Load(read);
                    gridControl1.DataSource= dt;


                }

            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO faturadetay(urunad, satilan_miktar, fiyat, tutar, faturaid)VALUES (@p1, @p2, @p3, @p4, @p5);", con))
                {

                    cmd.Parameters.AddWithValue("@p1", comboBoxEdit1.Text);
                    cmd.Parameters.AddWithValue("@p2", int.Parse(t10.Text));
                    cmd.Parameters.AddWithValue("@p3", double.Parse(textEdit1.Text));
                    cmd.Parameters.AddWithValue("@p4", double.Parse(textEdit6.Text));
                    cmd.Parameters.AddWithValue("@p5", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Invoice succesfully registered");
                    utilities.updateTable("faturadetay", gridControl1);
                    utilities.ClearTextBoxes(this.Controls);
                    // ClearTextBoxes(this.Controls);


                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "delete from faturadetay where faturaurunid=@p1",
                           con))
                {


                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p1", int.Parse(dr["faturaurunid"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    utilities.updateTable("faturadetay", gridControl1);
                    utilities.ClearTextBoxes(this.Controls);

                }

            }
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (r != null)
            {
            
                comboBoxEdit1.Text = r["urunad"].ToString();
                t10.Text = r["satilan_miktar"].ToString();


                textEdit1.Text = r["fiyat"].ToString();
                textEdit6.Text = r["tutar"].ToString();

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
    }
}