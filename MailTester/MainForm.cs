using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
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
    }
}
