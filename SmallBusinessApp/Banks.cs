using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Npgsql;

namespace SmallBusinessApp
{
    public partial class Banks : DevExpress.XtraEditors.XtraForm
    {
        public Banks()
        {
            InitializeComponent();
        }

        private void updatetable()
        { 
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           $"select * from bankabilgileri1() ",
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

        
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
               {
                   con.Open();
                   using (NpgsqlCommand cmd =
                          new NpgsqlCommand(
                              "INSERT INTO public.bankalar(banka_adi, sube, iban, hesapno, yetkili, hesapturu, tarih,  il, ilce,  firma_isim,firma_id)VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10,@p11);",
                              con))
                   {
                       

                       cmd.Parameters.AddWithValue("@p1", txtName.Text);
                       cmd.Parameters.AddWithValue("@p2", txtBranch.Text);
                       cmd.Parameters.AddWithValue("@p3", txtIban.Text);
                       cmd.Parameters.AddWithValue("@p4", txyAccountNo.Text);
                       cmd.Parameters.AddWithValue("@p5", txtOfficialname.Text);
                       cmd.Parameters.AddWithValue("@p6", txtAccountType.Text);
                       cmd.Parameters.AddWithValue("@p7", txtAccountDate.Text);
                       cmd.Parameters.AddWithValue("@p8", comboBoxEdit1.Text);
                       cmd.Parameters.AddWithValue("@p9", comboBoxEdit2.Text);
                       cmd.Parameters.AddWithValue("@p10", gridLookUpEdit1.Text);
                       cmd.Parameters.AddWithValue("@p11", gridLookUpEdit1.EditValue);

                       cmd.ExecuteNonQuery();
                       MessageBox.Show("Register is succesfull");
                updatetable();


                   }

               }
        }
        

        private void Banks_Load(object sender, EventArgs e)
        {
            updatetable();
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select id,firma_ad from firmalar;select isim from iller;", con))
                {
                    
                    NpgsqlDataReader reader
                        = cmd.ExecuteReader();
                 
                    DataTable dt2= new DataTable();
                  dt2.Load(reader);
                 
                  gridLookUpEdit1.Properties.ValueMember = "id";
                  gridLookUpEdit1.Properties.DisplayMember = "firma_ad";
                  gridLookUpEdit1.Properties.DataSource = dt2;
                   
                    while (reader.Read())
                    {
                        comboBoxEdit1.Properties.Items.Add(reader[0].ToString());
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

       

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (r != null)
            {
               txtAccountDate.Text = r["date"].ToString();
              txtAccountType.Text = r["Account Type"].ToString();
                txtBranch.Text = r["branch"].ToString();
                txtIban.Text = r["iban"].ToString();
                txtName.Text = r["name"].ToString();
                txtOfficialname.Text = r["official"].ToString();
                txyAccountNo.Text = r["Account Number"].ToString();
                comboBoxEdit1.Text = r["city"].ToString();
                comboBoxEdit2.Text = r["province"].ToString();
                gridLookUpEdit1.Text = r["Company Name"].ToString();
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
                           "delete from bankalar where id=(select id from bankalar where banka_adi=@p2);",
                           con))
                {


                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    string name = dr["name"].ToString();
                    cmd.Parameters.AddWithValue("@p2", name);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    updatetable();
                    utilities.ClearTextBoxes(this.Controls);

                }

            }
        }
    }
}
