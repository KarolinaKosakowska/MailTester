using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            tbTo.Text = EmailSending.People.GetMail();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            EmailCheck(tbTo, "Niepoprawny format email Adresatów");
            EmailCheck(tbFrom, "Niepoprawny format email Wysyłającego");

            //string text = Send.Text;
            ////var b = (Button)sender; // Rzuca wyjątkiem w przypadku błędnego typu.
            //var b = sender as Button; // Zwróci null w przypadku nieudanej konwersji.
            //text = b.Text;
            MailModel model = new MailModel();
            model.MailFrom = tbFrom.Text;
            model.SetMailTo(tbTo.Text);
            model.Title = tbTitle.Text;
            model.Body = rtbBody.Text;
            MailService.Send(model);
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label2.Visible = true;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
        private void tbFrom_MouseClick(object sender, MouseEventArgs e)
        {
            SetSender();
        }
        private void tbFrom_Enter(object sender, EventArgs e)
        {
            SetSender();
        }
        private void SetSender()
        {
            SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            tbFrom.Text = string.IsNullOrWhiteSpace(tbFrom.Text) ? $"{section.From}" : tbFrom.Text;
        }
        private void EmailCheck(TextBox field ,string errorText)
        {
            string emailTo =field.Text;
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(emailTo);
            if (match.Success) { }
            else
            {
                MessageBox.Show(errorText, "", MessageBoxButtons.OK);
            }


        }


    }

}

