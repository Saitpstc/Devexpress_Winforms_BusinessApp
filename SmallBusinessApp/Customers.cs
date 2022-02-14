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
    public partial class Customers : DevExpress.XtraEditors.XtraForm
    {

        private void updateTable()
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "select * from musteriler",
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


        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {

            updateTable();
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select * from iller", con))
                {
                    
                    NpgsqlDataReader reader
                        = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxEdit1.Properties.Items.Add(reader[1]);
                    }
          
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
                           "delete from musteriler where id=@p1",
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
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "INSERT INTO public.musteriler(ad, soyad, telefon, telefon2, tc, mail, il, ilce, adres, vergidaire) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8,@p9,@p10)",
                           con))
                {
                    cmd.Parameters.AddWithValue("@p1", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p2", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p3", textEdit3.Text);
                    cmd.Parameters.AddWithValue("@p4", textEdit4.Text);
                    cmd.Parameters.AddWithValue("@p5", textEdit5.Text);
                    cmd.Parameters.AddWithValue("@p6", textEdit6.Text);
                    cmd.Parameters.AddWithValue("@p7", comboBoxEdit1.Text);
                    cmd.Parameters.AddWithValue("@p8", comboBoxEdit2.Text);
                    cmd.Parameters.AddWithValue("@p9", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p10", textEdit9.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Register is succesfull");
                    updateTable();


                }

            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.DataRowCount != 0)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                textEdit1.Text = dr["ad"].ToString();
                textEdit2.Text = dr["soyad"].ToString();
                textEdit3.Text = dr["telefon"].ToString();
                textEdit4.Text = dr["telefon2"].ToString();
                textEdit5.Text = dr["tc"].ToString();
                textEdit6.Text = dr["mail"].ToString();
                comboBoxEdit1.Text = dr["il"].ToString();
                comboBoxEdit2.Text = dr["ilce"].ToString();
                textEdit9.Text = dr["vergidaire"].ToString();
                richTextBox1.Text = dr["adres"].ToString();
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
                           "  UPDATE public.musteriler SET  ad=@p1, soyad=@p2, telefon=@p3, telefon2=@p4, tc=@p5, mail=@p6, il=@p7, ilce=@p8, adres=@p10, vergidaire=@p11 WHERE id=@p9;",
                           con))
                {

                    cmd.Parameters.AddWithValue("@p1", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p2", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p3", textEdit3.Text);
                    cmd.Parameters.AddWithValue("@p4", textEdit4.Text);
                    cmd.Parameters.AddWithValue("@p5", textEdit5.Text);
                    cmd.Parameters.AddWithValue("@p6", textEdit6.Text);
                    cmd.Parameters.AddWithValue("@p7", comboBoxEdit1.Text);
                    cmd.Parameters.AddWithValue("@p8",   comboBoxEdit2.Text);
                    cmd.Parameters.AddWithValue("@p10", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p11", textEdit9.Text);
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p9", int.Parse(dr["id"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Updated ");
                    updateTable();


                }

            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select isim from ilceler where il_no=(select il_no from iller where isim=@p1)", con))
                {
                    cmd.Parameters.AddWithValue("@p1", comboBoxEdit1.Text);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBoxEdit2.Properties.Items.Add(reader[0]);
                    }

                }
            }
        }
    }
}