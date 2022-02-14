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
using System.Xml;
using Npgsql;

namespace SmallBusinessApp
{
    public partial class Main_Page : DevExpress.XtraEditors.XtraForm
    {
        public Main_Page()
        {
            InitializeComponent();
        }

        
        private void Main_Page_Load(object sender, EventArgs e)
        {
            utilities.updateTable("ajanda",gridControl2);
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            XmlTextReader reader = new XmlTextReader("https://www.ntv.com.tr/son-dakika.rss");
            while (reader.Read())
            {
                reader.Read();
                if (reader.Name == "title")
                {

                    listBoxControl1.Items.Add(reader.ReadElementContentAsString());
                   
                }
            }
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                           "select urun_ad,amount,model from urunler2 where amount<'"+200+ "' ;select * from fatura_bilgi order by faturabilgiid desc;",
                           con))
                {

                    NpgsqlDataReader reade
                        = cmd.ExecuteReader();
                    DataTable dt= new DataTable();
                    dt.Load(reade);
             gridControl1.DataSource=dt;
             reade.Read();
                         DataTable dt2= new DataTable();
           
             dt2.Load(reade);
             gridControl3.DataSource = dt2;

             // utilities.updateTable("fatura_bilgi", gridControl3);

             // ClearTextBoxes(this.Controls);


                }
            }

        }

  
        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

         
            if (e.Column.Name == "colnot_detay")
            {

                richTextBox2.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "not_detay").ToString();
             
                popup.Show();

            }
            else
            {
                popup.Hide();
            }

        }

      

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            popup.Hide();
        }
    }
}