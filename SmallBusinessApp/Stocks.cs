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
using DevExpress.Data.Controls;
using DevExpress.XtraCharts;
using Npgsql;

namespace SmallBusinessApp
{
    public partial class Stocks : DevExpress.XtraEditors.XtraForm
    {
        public Stocks()
        {
            InitializeComponent();
        }

        private void Stocks_Load(object sender, EventArgs e)
        {
          
             
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {

                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand("select urun_ad, sum(adet) as amount from urunler group by urun_ad ;", con))
                {
                    NpgsqlDataReader reader
                        = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    gridControl1.DataSource = dt;
                   cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        chartControl1.Series["Series"].Points.AddPoint(Convert.ToString(reader[0]),int.Parse(reader[1].ToString()));
                    
                    }


                }


                chartControl1.Legend.MarkerMode = LegendMarkerMode.Marker;

            }
        }
    }
}