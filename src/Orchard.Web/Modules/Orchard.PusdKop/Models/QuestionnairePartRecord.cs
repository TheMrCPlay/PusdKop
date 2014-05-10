using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Orchard.PusdKop.Models
{
    public class QuestionnairePartRecord : ContentPartRecord
    {
        public virtual int CustomerId { get; set; }
        public virtual string Type { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Interests { get; set; }
        public virtual string Kitchen { get; set; }
        public virtual string City { get; set; }
    }
}