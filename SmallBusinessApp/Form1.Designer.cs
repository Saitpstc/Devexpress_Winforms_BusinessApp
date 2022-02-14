namespace SmallBusinessApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnMain = new DevExpress.XtraBars.BarButtonItem();
            this.btnProduct = new DevExpress.XtraBars.BarButtonItem();
            this.btnInventor = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnSupplier = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnExpenses = new DevExpress.XtraBars.BarButtonItem();
            this.btnAccount = new DevExpress.XtraBars.BarButtonItem();
            this.btnBanks = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotes = new DevExpress.XtraBars.BarButtonItem();
            this.btnContacts = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaleInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ButtonGroupsLayout = DevExpress.XtraBars.ButtonGroupsLayout.Auto;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnMain,
            this.btnProduct,
            this.btnInventor,
            this.btnCustomer,
            this.btnSupplier,
            this.btnEmployee,
            this.btnExpenses,
            this.btnAccount,
            this.btnBanks,
            this.btnNotes,
            this.btnContacts,
            this.btnSaleInvoice,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1442, 150);
            // 
            // btnMain
            // 
            this.btnMain.Caption = "Main Page";
            this.btnMain.Id = 1;
            this.btnMain.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMain.ImageOptions.Image")));
            this.btnMain.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMain.ImageOptions.LargeImage")));
            this.btnMain.Name = "btnMain";
            this.btnMain.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMain_ItemClick);
            // 
            // btnProduct
            // 
            this.btnProduct.Caption = "Products";
            this.btnProduct.Id = 2;
            this.btnProduct.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.ImageOptions.Image")));
            this.btnProduct.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProduct.ImageOptions.LargeImage")));
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProduct_ItemClick);
            // 
            // btnInventor
            // 
            this.btnInventor.Caption = "Inventory";
            this.btnInventor.Id = 3;
            this.btnInventor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInventor.ImageOptions.Image")));
            this.btnInventor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInventor.ImageOptions.LargeImage")));
            this.btnInventor.Name = "btnInventor";
            this.btnInventor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInventor_ItemClick);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Caption = "Suppliers";
            this.btnCustomer.Id = 4;
            this.btnCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.ImageOptions.Image")));
            this.btnCustomer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomer.ImageOptions.LargeImage")));
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomer_ItemClick);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Caption = "Employees";
            this.btnSupplier.Id = 5;
            this.btnSupplier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.ImageOptions.Image")));
            this.btnSupplier.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSupplier.ImageOptions.LargeImage")));
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSupplier_ItemClick);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Caption = "Expenses";
            this.btnEmployee.Id = 6;
            this.btnEmployee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.Image")));
            this.btnEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.LargeImage")));
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployee_ItemClick);
            // 
            // btnExpenses
            // 
            this.btnExpenses.Caption = "Account";
            this.btnExpenses.Id = 7;
            this.btnExpenses.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExpenses.ImageOptions.Image")));
            this.btnExpenses.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExpenses.ImageOptions.LargeImage")));
            this.btnExpenses.Name = "btnExpenses";
            // 
            // btnAccount
            // 
            this.btnAccount.Caption = "Banks";
            this.btnAccount.Id = 8;
            this.btnAccount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAccount.ImageOptions.Image")));
            this.btnAccount.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAccount.ImageOptions.LargeImage")));
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAccount_ItemClick);
            // 
            // btnBanks
            // 
            this.btnBanks.Caption = "Notes";
            this.btnBanks.Id = 9;
            this.btnBanks.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBanks.ImageOptions.Image")));
            this.btnBanks.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBanks.ImageOptions.LargeImage")));
            this.btnBanks.Name = "btnBanks";
            this.btnBanks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBanks_ItemClick);
            // 
            // btnNotes
            // 
            this.btnNotes.Caption = "Contacts";
            this.btnNotes.Id = 10;
            this.btnNotes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNotes.ImageOptions.Image")));
            this.btnNotes.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNotes.ImageOptions.LargeImage")));
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNotes_ItemClick);
            // 
            // btnContacts
            // 
            this.btnContacts.Caption = "Invoices";
            this.btnContacts.Id = 11;
            this.btnContacts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnContacts.ImageOptions.Image")));
            this.btnContacts.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnContacts.ImageOptions.LargeImage")));
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnContacts_ItemClick);
            // 
            // btnSaleInvoice
            // 
            this.btnSaleInvoice.Caption = "Settings";
            this.btnSaleInvoice.Id = 12;
            this.btnSaleInvoice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaleInvoice.ImageOptions.Image")));
            this.btnSaleInvoice.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSaleInvoice.ImageOptions.LargeImage")));
            this.btnSaleInvoice.Name = "btnSaleInvoice";
            this.btnSaleInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaleInvoice_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Customers";
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Business Application";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMain);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnProduct);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnInventor);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCustomer);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSupplier);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEmployee);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExpenses);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAccount);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBanks);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNotes);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnContacts);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSaleInvoice);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "barButtonItem13";
            this.barButtonItem13.Id = 14;
            this.barButtonItem13.Name = "barButtonItem13";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.Appearance.Options.UseImage = true;
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.UseFormIconAsPageImage = DevExpress.Utils.DefaultBoolean.True;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(748, 89);
            this.toggleSwitch1.MenuManager = this.ribbonControl1;
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.toggleSwitch1.Properties.Appearance.BackColor2 = System.Drawing.Color.LightGray;
            this.toggleSwitch1.Properties.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.toggleSwitch1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.toggleSwitch1.Properties.Appearance.Options.UseBackColor = true;
            this.toggleSwitch1.Properties.Appearance.Options.UseBorderColor = true;
            this.toggleSwitch1.Properties.Appearance.Options.UseForeColor = true;
            this.toggleSwitch1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.toggleSwitch1.Properties.OffText = "Dark Mode Off";
            this.toggleSwitch1.Properties.OnText = "Dark Mode On";
            this.toggleSwitch1.Size = new System.Drawing.Size(125, 18);
            this.toggleSwitch1.TabIndex = 2;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 708);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnMain;
        private DevExpress.XtraBars.BarButtonItem btnProduct;
        private DevExpress.XtraBars.BarButtonItem btnInventor;
        private DevExpress.XtraBars.BarButtonItem btnCustomer;
        private DevExpress.XtraBars.BarButtonItem btnSupplier;
        private DevExpress.XtraBars.BarButtonItem btnEmployee;
        private DevExpress.XtraBars.BarButtonItem btnExpenses;
        private DevExpress.XtraBars.BarButtonItem btnAccount;
        private DevExpress.XtraBars.BarButtonItem btnBanks;
        private DevExpress.XtraBars.BarButtonItem btnNotes;
        private DevExpress.XtraBars.BarButtonItem btnContacts;
        private DevExpress.XtraBars.BarButtonItem btnSaleInvoice;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
    }
}

