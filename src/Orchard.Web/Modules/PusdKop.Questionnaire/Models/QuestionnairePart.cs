using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using Orchard.ContentManagement;
using Orchard.Security;

//PusdKop project 
namespace PusdKop.Questionnaire.Models
{
    public class QuestionnairePart: ContentPart<QuestionnairePartRecord>,IUser
    {
        

        public string Name
        {
            get { return Retrieve(x => x.Name); }
            set { Store(x => x.Name, value); }
        }
        public string Surname
        {
            get { return Retrieve(x => x.Surname); }
            set { Store(x => x.Surname, value); }
        }

        public string Interests
        {
            get { return Retrieve(x => x.Interests); }
            set { Store(x => x.Interests, value); }
        }

        public string Kitchen
        {
            get { return Retrieve(x => x.Kitchen); }
            set { Store(x => x.Kitchen, value); }
        }

        public string City
        {
            get { return Retrieve(x => x.City); }
            set { Store(x => x.City, value); }
        }

        public string UserName
        {
            get { return Retrieve(x => x.UserName); }
            set { Store(x => x.UserName, value); }
        }

        public string Email
        {
            get { return Retrieve(x => x.Email); }
            set { Store(x => x.Email, value); }
        }

    }
}