using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Orchard.PusdKop.Models
{
    public class QuestionnairePart: ContentPart<QuestionnairePartRecord>
    {
        public int CustomerId
        {
            get { return Record.CustomerId; }
            set { Record.CustomerId = value; }
            
        }

        public string Type
        {
            get { return Record.Type; }
            set { Record.Type = value; }
        }
    }
}