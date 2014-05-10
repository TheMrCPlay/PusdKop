using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.PusdKop.Models;

namespace Orchard.PusdKop.Handlers
{
    public class QuestionnairePartHandler : ContentHandler
    {
        public QuestionnairePartHandler(IRepository<QuestionnairePartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}