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
                    Email="mis.uszatek@bajka.pl"
                },
                new PersonalData
                {
                    Name = "Miś",
                    LastName="Koralgol",
                    Email="m.koralgol.postac@gmail.com"
                },
                new PersonalData
                {
                    Name = "Koziołek",
                    LastName="Matołek",
                    Email="k.matolek@gmail.com"
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

           var emailArray = PeopleList.Where(p => p.Name == "Miś").Select(p => p.Email).ToArray();
           var email =string.Join(";",emailArray);
           return email;
        }

    }
}


