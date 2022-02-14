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
    public partial class Contacts : DevExpress.XtraEditors.XtraForm
    {
        public Contacts()
        {
            InitializeComponent();
        }

        private void Contacts_Load(object sender, EventArgs e)
        {

            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           $"select ad,soyad,telefon,telefon2,mail,il,ilce,adres from musteriler; select; select firma_ad, firma_yetkili_adsoyad,telefon1,telefon2,telefon3,mail,fax,il,ilce,adres from firmalar",
                           con))
                {
                    DataTable dt = new DataTable();
                    NpgsqlDataReader reader
                        = cmd.ExecuteReader();
                    dt.Load(reader);
                    gridControl1.DataSource = dt;
                   DataTable dt2 = new DataTable();
                    reader.NextResult();
                    dt2.Load(reader);
                    gridControl2.DataSource = dt2;
                }

            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SendMail s=new SendMail();
            DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (r != null) s.mail = r["mail"].ToString();
            
            s.Show();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SendMail s = new SendMail();
            DataRow r = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (r != null) s.mail = r["mail"].ToString();

            s.Show();
        }
    }
}