using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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

            tbTo.Text = string.IsNullOrWhiteSpace(tbFrom.Text) ? EmailSending.People.GetMail() : tbTo.Text;
        }

        private void SendButton_Click(object sender, EventArgs e)
        { 
           
            MailModel model = new MailModel();
            model.MailFrom = tbFrom.Text;
            model.SetMailTo(tbTo.Text);
            model.Title = tbTitle.Text;
            model.Body = rtbBody.Text;

            if ((EmailCheck(tbTo, "Niepoprawny format email Adresatów")==true)      
                &&(EmailCheck(tbFrom, "Niepoprawny format email Wysyłającego")==true)
                &&(TitleCheck(tbTitle, "Czy tytuł ma pozostać pusty")==true))
            {
                MailService.Send(model);
            }   
            
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
        private bool EmailCheck(TextBox field, string errorText)
        {
            bool decision = true;
            string emailTo = field.Text;
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(emailTo);
            if (match.Success) { decision = true; }
            else
            {
                MessageBox.Show(errorText, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                decision = false;
            }
            return decision;
            //to zadziała jesli wpiszemy pojedyny eamil.
            //Nie wiem jak utworzyc regex dla emaili wprowadzanych z mojej listy PeopleList z metody GetMail...
        }

        private bool TitleCheck(TextBox field, string errorText)
        {

            bool decision = true;
            if (string.IsNullOrWhiteSpace(field.Text))
            {
                DialogResult dr = MessageBox.Show(errorText, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        decision = true;
                        break;

                    case DialogResult.No:
                        decision = false;
                        break;

                }
            }
            return decision;

            //field.Text = string.IsNullOrWhiteSpace(field.Text) ? MessageBox.Show(errorText, "", MessageBoxButtons.OK) : field.Text;

            //dlaczego ten zapis nie działa? Roziemiem ze przez konwersje, ale nie wiem jak to naprawic.            
        }
    }

}

