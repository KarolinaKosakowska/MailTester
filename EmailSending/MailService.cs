using FileLogger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailTester
{
    public static class MailService
    {
        static readonly string InfoFileName= "SendMailInfo.txt";
        static readonly string ErrorFileName= "SendMailError.txt";


        public static bool Send(MailModel model)
        {
            try
            {
                LogInfo logInfo = new LogInfo(InfoFileName);
                logInfo.Log("Próba wysłania wiadomości");

                var message = new MailMessage();
                message.From = new MailAddress(model.MailFrom,"Karolina Kosakowska");
                model.MailTo.ForEach(m => message.To.Add(new MailAddress(m)));
                message.Subject = model.Title;
                message.Body = model.Body;

                var smtp = new SmtpClient(); //To do App.config
                //smtp.UseDefaultCredentials = false; //To do App.config
                //smtp.Credentials = new NetworkCredential("sendermail589", ""); //To do App.config
                //smtp.EnableSsl = true; //To do App.config
                //smtp.Port = 587; //To do App.config
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                LogError logError = new LogError(ErrorFileName);
                logError.Log($"{ex.Message}");
                return false;
                
            }
        }
    }
}
