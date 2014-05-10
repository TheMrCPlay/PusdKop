using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Orchard.PusdKop.ViewModels
{
    public class QuestionnaireViewModel
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(256)]
        public string Interests { get; set; }

        [StringLength(50)]
        public string Kitchen { get; set; }

        [StringLength(50)]
        public string City { get; set; }
    }
}