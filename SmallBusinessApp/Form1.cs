using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SmallBusinessApp
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Companies cm = new Companies();
            cm.MdiParent = this;
            cm.Show();
        }

        private void btnSaleInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Products frm
                = new Products();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customers cm = new Customers();
            cm.MdiParent = this;
            cm.Show();
        }

        private void btnSupplier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Employees em = new Employees();
            em.MdiParent = this;
            em.Show();
        }

        private void btnNotes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Contacts c = new Contacts();
            c.MdiParent = this;
            c.Show();
        }

        private void btnEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Expenses frm = new Expenses();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Banks b = new Banks();
            b.MdiParent = this;
            b.Show();
        }

        private void btnContacts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var invoices = new Invoices();
            invoices.MdiParent = this;
            invoices.Show();

        }

        private void btnBanks_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Notes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnInventor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stocks st = new Stocks();
            st.MdiParent = this;
            st.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Main_Page mp=new Main_Page();
            mp.MdiParent = this;
            mp.Show();
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (WindowsFormsSettings.DefaultLookAndFeel.SkinName == "DevExpress Dark Style")
            {
                WindowsFormsSettings.DefaultLookAndFeel.SkinName = "Basic";
                toggleSwitch1.LookAndFeel.SkinName = "Basic";

            }
            else
            {

                WindowsFormsSettings.DefaultLookAndFeel.SkinName = "DevExpress Dark Style";
                toggleSwitch1.LookAndFeel.SkinName = "DevExpress Dark Style";
            }



        }

        private void btnMain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Main_Page mp = new Main_Page();
            mp.MdiParent = this;
            mp.Show();
        }
    }
}
