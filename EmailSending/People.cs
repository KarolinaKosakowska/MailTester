using MailTester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSending
{
    public class People
    {
       
        public static List<PersonalData> PeopleList = new List<PersonalData>()
        {
                new PersonalData
                {
                    Name = "Miś",
                    LastName="Uszatek",
                    Email="mis-uszatek.bajka@fdfdfd.ckh"
                },
                new PersonalData
                {
                    Name = "Miś",
                    LastName="Koralgol",
                    Email="mis-koralgol.bajka@fdfdfd.kk"
                },
                new PersonalData
                {
                    Name = "Koziołek",
                    LastName="Matołek",
                    Email="k.matolek@gu67i7i7.p"
                }
        };
       
        public static string GetMail()
        {

            //string email = null;
            //foreach (EmailSending.PersonalData person in EmailSending.People.PeopleList)
            //{
            //   email += $"{person.Email};";
            //}
            //return email;

           var emailsArray = PeopleList.Where(p => p.Name == "Miś").Select(p => p.Email).ToArray();
           var email =string.Join(";",emailsArray); 
           return email;
        }

    }
}


