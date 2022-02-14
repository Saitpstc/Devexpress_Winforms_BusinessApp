using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  Npgsql;

namespace SmallBusinessApp
{
    public partial class Employees : DevExpress.XtraEditors.XtraForm
    {
       


        public Employees()
        {
            InitializeComponent();
        } 
       
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "INSERT INTO personeller (yekili_ad, soyad, telefon, tc, mail, il, ilce, adres, gorev) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)",
                           con))
                {
                    cmd.Parameters.AddWithValue("@p1", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p2", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p3", textEdit3.Text);
                    cmd.Parameters.AddWithValue("@p4", textEdit4.Text);
                    cmd.Parameters.AddWithValue("@p5", textEdit6.Text);
                    cmd.Parameters.AddWithValue("@p6", comboBoxEdit1.Text);
                    cmd.Parameters.AddWithValue("@p7", comboBoxEdit2.Text);
                    cmd.Parameters.AddWithValue("@p9", textEdit9.Text);
                    cmd.Parameters.AddWithValue("@p8", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Register is succesfull");
                    utilities.updateTable("personeller", gridControl1);


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
                           "  UPDATE public.personeller  set yekili_ad =@p1, soyad=@p2, telefon=@p3, tc=@p4, mail=@p5, il=@p6, ilce=@p7, adres=@p8, gorev=@p9 WHERE id=@p10;",
                           con))
                {

                    cmd.Parameters.AddWithValue("@p1", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p2", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p3", textEdit3.Text);
                    cmd.Parameters.AddWithValue("@p4", textEdit4.Text);
                    cmd.Parameters.AddWithValue("@p5", textEdit6.Text);
                    cmd.Parameters.AddWithValue("@p6", comboBoxEdit1.Text);
                    cmd.Parameters.AddWithValue("@p7", comboBoxEdit2.Text);
                    cmd.Parameters.AddWithValue("@p9", textEdit9.Text);
                    cmd.Parameters.AddWithValue("@p8", richTextBox1.Text);
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p10", int.Parse(dr["id"].ToString()));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Updated ");
                    utilities.updateTable("personeller", gridControl1);

                }

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.DataRowCount != 0)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                textEdit1.Text = dr["yekili_ad"].ToString();
                textEdit2.Text = dr["soyad"].ToString();
                textEdit3.Text = dr["telefon"].ToString();
                textEdit4.Text = dr["tc"].ToString();
                textEdit6.Text = dr["mail"].ToString();
                comboBoxEdit1.Text = dr["il"].ToString();
                comboBoxEdit2.Text = dr["ilce"].ToString();
                textEdit9.Text = dr["gorev"].ToString();
                richTextBox1.Text = dr["adres"].ToString();
            }

        }

        private void Employees_Load(object sender, EventArgs e)
        {

            utilities.updateTable("personeller", gridControl1);
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

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "delete from personeller where id=@p1",
                           con))
                {


                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p1", int.Parse(dr["id"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    utilities.updateTable("personeller", gridControl1);
                 utilities.ClearTextBoxes(this.Controls);


                }

            }
        }
    }
}