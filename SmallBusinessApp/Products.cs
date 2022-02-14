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
    public partial class Products : DevExpress.XtraEditors.XtraForm
    {
        private void updateTable()
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "select * from urunler2",
                           con))
                {
                    DataTable dt = new DataTable();
                    NpgsqlDataReader reader
                        = cmd.ExecuteReader();
                    dt.Load(reader);
                    gridControl1.DataSource = dt;
                }

            }
        }
        public Products()
        {
            InitializeComponent();
        }

    

        private void Products_Load(object sender, EventArgs e)
        {
            updateTable();
        }

  
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "INSERT INTO public.urunler(urun_ad, marka, model, yil, adet, alis_fiyati, satis_fiyat, detay) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)",
                           con))
                {
                    cmd.Parameters.AddWithValue("@p1", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p2", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p3", textEdit3.Text);
                    cmd.Parameters.AddWithValue("@p4", textEdit4.Text);
                    cmd.Parameters.AddWithValue("@p5", int.Parse(textEdit5.Text));
                    cmd.Parameters.AddWithValue("@p6", double.Parse(textEdit6.Text));
                    cmd.Parameters.AddWithValue("@p7", double.Parse(textEdit7.Text));
                    cmd.Parameters.AddWithValue("@p8", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Register is succesfull");
                    updateTable();


                }

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "UPDATE public.urunler SET  urun_ad=@p1, marka=@p2, model=@p3, yil=@p4, adet=@p5, alis_fiyati=@p6, satis_fiyat=@p7, detay=@p8 WHERE id=@p9;",
                           con))
                {
              
                    cmd.Parameters.AddWithValue("@p1", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p2", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p3", textEdit3.Text);
                    cmd.Parameters.AddWithValue("@p4", textEdit4.Text);
                    cmd.Parameters.AddWithValue("@p5", int.Parse(textEdit5.Text));
                    cmd.Parameters.AddWithValue("@p6", double.Parse(textEdit6.Text));
                    cmd.Parameters.AddWithValue("@p7", double.Parse(textEdit7.Text));
                    cmd.Parameters.AddWithValue("@p8", richTextBox1.Text);
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p9", int.Parse(dr["id"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Updated ");
                    updateTable();


                }

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textEdit1.Text=dr["urun_ad"].ToString();
            textEdit3.Text=dr["model"].ToString();
            textEdit7.Text=dr["satis_fiyat"].ToString();
            richTextBox1.Text=dr["detay"].ToString();
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "delete from urunler where id=@p1",
                           con))
                {

                    
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p1", int.Parse(dr["id"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    updateTable();


                }

            }
        }
    }
}