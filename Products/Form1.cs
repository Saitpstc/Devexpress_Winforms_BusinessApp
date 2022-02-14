using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Products
{
    
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private void UpdateTable()
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           "select * from urunler",
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
