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
    public partial class Companies : DevExpress.XtraEditors.XtraForm
    {
        public Companies()
        {
            InitializeComponent();
        }

        private void Companies_Load(object sender, EventArgs e)
        {

            if (WindowsFormsSettings.DefaultLookAndFeel.SkinName == "DevExpress Dark Style")
            {
               
            }
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            utilities.updateTable("firmalar", gridControl1);
            utilities.ClearTextBoxes(this.Controls);
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
         
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select * from iller;", con))
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.firmalar(firma_ad, firma_yetkili_statu, firma_yetkili_adsoyad, telefon1, telefon2, telefon3, mail, fax, il, ilce, vergidaires, adres, yetkili_tc, ozelkod1, ozelkod2, ozelkod3)VALUES (@p1,@p2 , @p3, @p4, @p5, @p6,@p7, @p8, @p9, @p10,@p10 , @p11, @p12, @p13, @p14, @p15);", con))
                {

                    cmd.Parameters.AddWithValue("@p1", t1.Text);
                    cmd.Parameters.AddWithValue("@p2", t3.Text);
                    cmd.Parameters.AddWithValue("@p3", t2.Text);
                    cmd.Parameters.AddWithValue("@p4", t5.Text);
                    cmd.Parameters.AddWithValue("@p5", t6.Text);
                    cmd.Parameters.AddWithValue("@p6", t7.Text);
                    cmd.Parameters.AddWithValue("@p7", t9.Text);
                    cmd.Parameters.AddWithValue("@p8", t8.Text);
                    cmd.Parameters.AddWithValue("@p9", comboBoxEdit1.Text);
                    cmd.Parameters.AddWithValue("@p10", comboBoxEdit2.Text);
                    cmd.Parameters.AddWithValue("@p11", t10.Text);
                    cmd.Parameters.AddWithValue("@p12", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p13", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p14", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p15", textEdit18.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Company succesfully registered");
                    utilities.updateTable("firmalar", gridControl1);
                    utilities.ClearTextBoxes(this.Controls);
                    // ClearTextBoxes(this.Controls);


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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.DataRowCount != 0)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                t1.Text = dr["firma_ad"].ToString();
                t2.Text = dr["firma_yetkili_adsoyad"].ToString();
                t3.Text = dr["firma_yetkili_statu"].ToString();
                t4.Text = dr["yetkili_tc"].ToString();
                t5.Text = dr["telefon1"].ToString();
                t6.Text = dr["telefon2"].ToString();
                comboBoxEdit1.Text = dr["il"].ToString();
                comboBoxEdit2.Text = dr["ilce"].ToString();
                t7.Text = dr["telefon3"].ToString();
                t8.Text = dr["fax"].ToString();
                t9.Text = dr["mail"].ToString();
                t10.Text = dr["vergidaires"].ToString();
                richTextBox1.Text = dr["adres"].ToString();
                textEdit8.Text = dr["id"].ToString();
                textEdit1.Text = dr["ozelkod1"].ToString();
                textEdit2.Text = dr["ozelkod2"].ToString();
                textEdit18.Text = dr["ozelkod3"].ToString();
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
                           "delete from firmalar where id=@p1",
                           con))
                {


                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p1", int.Parse(dr["id"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    utilities.updateTable("firmalar", gridControl1);
                    utilities.ClearTextBoxes(this.Controls);

                }

            }
        }
    }
}