using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace SmallBusinessApp
{
    internal static class utilities
    {
        public static void ClearTextBoxes(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(ctrl.Controls);
                }
            }
        }

        public static void updateTable(string tbl_name, DevExpress.XtraGrid.GridControl control )
        {
            using (NpgsqlConnection con =
                   new NpgsqlConnection("Host=localhost;User Id=postgres;Password=sifre12345;Database=DboTicari"))
            {
                con.Open();
                using (NpgsqlCommand cmd =
                       new NpgsqlCommand(
                           $"select * from {tbl_name} ",
                           con))
                {
                    DataTable dt = new DataTable();
                    NpgsqlDataReader reader
                        = cmd.ExecuteReader();
                    dt.Load(reader);
                    control.DataSource = dt;
                }

            }
        }
    }
}
