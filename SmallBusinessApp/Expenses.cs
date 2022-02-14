using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using Npgsql;

namespace SmallBusinessApp
{
    public partial class Expenses : DevExpress.XtraEditors.XtraForm
    {
        public Expenses()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.giderler(elektrik, su, dogalgaz, internet, maaslar, notlar, ay, yil)VALUES (@p1, @p2, @p3, @p4, @p5,@p6, @p7, @p8);", con))
                {

                    cmd.Parameters.AddWithValue("@p1", double.Parse(textEdit1.Text));
                    cmd.Parameters.AddWithValue("@p2", double.Parse(textEdit2.Text));
                    cmd.Parameters.AddWithValue("@p3", double.Parse(textEdit3.Text));
                    cmd.Parameters.AddWithValue("@p4", double.Parse(textEdit4.Text));
                    cmd.Parameters.AddWithValue("@p5", double.Parse(textEdit5.Text));
                    cmd.Parameters.AddWithValue("@p6", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p7", comboBoxEdit1.Text);
                    cmd.Parameters.AddWithValue("@p8", int.Parse(comboBoxEdit2.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expenses succesfully registered");
                    utilities.updateTable("giderler", gridControl1);
                    utilities.ClearTextBoxes(this.Controls);
                    // ClearTextBoxes(this.Controls);


                }
            }
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            utilities.updateTable("giderler",gridControl1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "delete from giderler where id=@p1",
                           con))
                {


                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p1", int.Parse(dr["id"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    utilities.updateTable("giderler", gridControl1);
                    utilities.ClearTextBoxes(this.Controls);


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
                           "  UPDATE public.giderler SET  elektrik=@p1, su=@p2, dogalgaz=@p3, internet=@p4, maaslar=@p5, notlar=@p6, ay=@p7, yil=@p8 WHERE id=@p9;",
                           con))
                {

                    cmd.Parameters.AddWithValue("@p1", double.Parse(textEdit1.Text));
                    cmd.Parameters.AddWithValue("@p2", double.Parse(textEdit2.Text));
                    cmd.Parameters.AddWithValue("@p3", double.Parse(textEdit3.Text));
                    cmd.Parameters.AddWithValue("@p4", double.Parse(textEdit4.Text));
                    cmd.Parameters.AddWithValue("@p5", double.Parse(textEdit5.Text));
                    cmd.Parameters.AddWithValue("@p6", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p7", comboBoxEdit1.Text);
                    cmd.Parameters.AddWithValue("@p8", int.Parse(comboBoxEdit2.Text));
                    cmd.ExecuteNonQuery();
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p9", int.Parse(dr["id"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Updated ");
               utilities.updateTable("giderler",gridControl1);


                }

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.DataRowCount != 0)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                textEdit1.Text = dr["elektrik"].ToString();
                textEdit2.Text = dr["su"].ToString();
                textEdit3.Text = dr["dogalgaz"].ToString();
                textEdit4.Text = dr["internet"].ToString();
                textEdit5.Text = dr["maaslar"].ToString();
           
                comboBoxEdit1.Text = dr["ay"].ToString();
                comboBoxEdit2.Text = dr["yil"].ToString();
         
                richTextBox1.Text = dr["notlar"].ToString();
            }
        }
    }
}