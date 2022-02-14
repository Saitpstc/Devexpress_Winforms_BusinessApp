using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace SmallBusinessApp
{
    public partial class SendMail : DevExpress.XtraEditors.XtraForm
    {
        public string mail;
        public SendMail()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("saitpostaci8@gmail.com");
            ePosta.To.Add(textEdit1.Text);
            ePosta.Subject = textEdit2.Text;
            ePosta.Body = richTextBox1.Text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl=true;
            smtp.Credentials = new System.Net.NetworkCredential("mail", "passowrd");
            smtp.Send(ePosta);
            MessageBox.Show("Mail Sent");
        }

        private void SendMail_Load(object sender, EventArgs e)
        {
            textEdit1.Text = mail;
        }
    }
}