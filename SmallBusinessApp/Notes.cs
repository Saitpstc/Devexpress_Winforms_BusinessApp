using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Npgsql;

namespace SmallBusinessApp
{
    public partial class Notes : DevExpress.XtraEditors.XtraForm
    {
        public Notes()
        {
            InitializeComponent();
        }
  
        private void Notes_Load(object sender, EventArgs e)
        {
        

           
            utilities.updateTable("ajanda", gridControl1);
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                           "select CONCAT(yekili_ad,' ',soyad) as full_name from personeller",
                           con))
                {

                    NpgsqlDataReader read
                        = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        comboBoxEdit1.Properties.Items.Add(read[0].ToString());
                    }
                   


                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                           "INSERT INTO public.ajanda( not_tarih, not_baslik, not_detay, not_olusturan)VALUES (@p1, @p2, @p3, @p4);",
                           con))
                {

                    cmd.Parameters.AddWithValue("@p1", dateEdit1.DateTime);
                    cmd.Parameters.AddWithValue("@p2", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p3", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p4", comboBoxEdit1.Text);
   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Note succesfully registered");
                    utilities.updateTable("ajanda", gridControl1);
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
                           "delete from ajanda where id=@p1",
                           con))
                {


                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p1", int.Parse(dr["id"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    utilities.updateTable("ajanda", gridControl1);
                    utilities.ClearTextBoxes(this.Controls);

                }

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           " UPDATE public.ajandaSET  not_tarih=@p1, not_baslik=@p2, not_detay=@p3, not_olusturan=@p4 WHERE id=@p5;",
                           con))
                {


                    cmd.Parameters.AddWithValue("@p1", dateEdit1.DateTime);
                    cmd.Parameters.AddWithValue("@p2", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@p3", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p4", comboBoxEdit1.Text);

                    
                    DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p5", r["id"]);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Company succesfully registered");
                    utilities.updateTable("ajanda", gridControl1);
                    utilities.ClearTextBoxes(this.Controls);
                    // ClearTextBoxes(this.Controls);


                }

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (r != null)
            {
                comboBoxEdit1.Text = r["not_olusturan"].ToString();
                dateEdit1.DateTime= (DateTime) r["not_tarih"];
                textEdit1.Text = r["not_baslik"].ToString();
                richTextBox1.Text = r["not_detay"].ToString();
             
            } 
               
               
               //labelControl1.Text=col.ColumnName;
               //labelControl1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"not_detay").ToString();

        }
    
        Point p = new Point();
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            p =this.PointToClient(MousePosition);
            if (e.Column.Name=="colnot_detay") 
            {
                richTextBox2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "not_detay").ToString() + p.ToString();
                popupContainerControl2.Location = p;
               popupContainerControl2.Show();
               
            }
            else
            {
                popupContainerControl2.Hide();
            }



        }

    

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            popupContainerControl2.Hide();
        }
    }
}
