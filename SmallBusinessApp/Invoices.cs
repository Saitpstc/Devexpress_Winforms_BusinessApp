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
    public partial class Invoices : DevExpress.XtraEditors.XtraForm
    {
        public Invoices()
        {
            InitializeComponent();
        }

        private void Invoices_Load(object sender, EventArgs e)
        {
            utilities.updateTable("fatura_bilgi", gridControl3);
            //utilities.ClearTextBoxes(this.Controls);
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           

        }

       

    private void simpleButton5_Click(object sender, EventArgs e)
        {
            using(NpgsqlConnection con =
                new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "delete from fatura_bilgi where faturabilgiid=@p1",
                           con))
                {


                    DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p1", int.Parse(dr["faturabilgiid"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    utilities.updateTable("fatura_bilgi", gridControl3);
                    utilities.ClearTextBoxes(this.Controls);

                }

            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "  UPDATE public.fatura_bilgi SET  seri =@p1, sira_no =@p2, tarih =@p3, vergidaire =@p4, alici =@p5, teslimeden =@p6, teslimalan =@p7 WHERE faturabilgiid=@p8; ",
                           con))
                {


                    cmd.Parameters.AddWithValue("@p1", textEdit4.Text);
                    cmd.Parameters.AddWithValue("@p2", textEdit3.Text);
                    cmd.Parameters.AddWithValue("@p3", dateEdit1.DateTime);
                    cmd.Parameters.AddWithValue("@p4", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p5", textEdit5.Text);
                    cmd.Parameters.AddWithValue("@p6", textEdit7.Text);
                    cmd.Parameters.AddWithValue("@p7", textEdit8.Text);
                    DataRow r = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p8", r["faturabilgiid"]);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Company succesfully registered");
                    utilities.updateTable("fatura_bilgi", gridControl3);
                    utilities.ClearTextBoxes(this.Controls);
                    // ClearTextBoxes(this.Controls);


                }

            }
        }

      


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            
            DataRow r = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            if (r != null)
            {
                textEdit4.Text = r["seri"].ToString();
                textEdit3.Text = r["sira_no"].ToString();
                dateEdit2.DateTime = (DateTime)r["tarih"];


                textEdit2.Text = r["vergidaire"].ToString();
                textEdit5.Text = r["alici"].ToString();
                textEdit7.Text = r["teslimeden"].ToString();
                textEdit8.Text = r["teslimalan"].ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

         

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "delete from fatura_bilgi where faturabilgiid=@p1",
                           con))
                {


                    DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                    cmd.Parameters.AddWithValue("@p1", int.Parse(dr["faturabilgiid"].ToString()));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Deleted ");
                    utilities.updateTable("fatura_bilgi", gridControl3);
                    utilities.ClearTextBoxes(this.Controls);

                }

            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                           "INSERT INTO public.fatura_bilgi(seri, sira_no, tarih, vergidaire, alici, teslimeden, teslimalan)VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7);",
                           con))
                {

                    cmd.Parameters.AddWithValue("@p1", textEdit4.Text);
                    cmd.Parameters.AddWithValue("@p2", textEdit3.Text);
                    cmd.Parameters.AddWithValue("@p3", dateEdit1.DateTime);
                    cmd.Parameters.AddWithValue("@p4", textEdit2.Text);
                    cmd.Parameters.AddWithValue("@p5", textEdit5.Text);
                    cmd.Parameters.AddWithValue("@p6", textEdit7.Text);
                    cmd.Parameters.AddWithValue("@p7", textEdit8.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Company succesfully registered");
                    utilities.updateTable("fatura_bilgi", gridControl3);
                    utilities.ClearTextBoxes(this.Controls);
                    // ClearTextBoxes(this.Controls);


                }
            }
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            var frm = new Invoice_Details();


            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            frm.id = int.Parse(dr["faturabilgiid"].ToString());


            frm.ShowDialog();
        }
    }
}
