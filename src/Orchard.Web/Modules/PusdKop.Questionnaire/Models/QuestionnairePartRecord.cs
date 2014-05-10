using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace PusdKop.Questionnaire.Models
{
    public class QuestionnairePartRecord : ContentPartRecord 
    {
        //PusdKop project questionnaire's addition properties
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Interests { get; set; }
        public virtual string Kitchen { get; set; }
        public virtual string City { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }


        
    }
}