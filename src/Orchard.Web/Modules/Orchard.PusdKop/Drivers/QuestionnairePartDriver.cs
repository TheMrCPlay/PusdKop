using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.PusdKop.Models;

namespace Orchard.PusdKop.Drivers
{
    public class QuestionnairePartDriver : ContentPartDriver<QuestionnairePart>
    {
        protected override string Prefix
        {
            get
            {
                return "Questionnaire";
            }
        }

        protected override DriverResult Editor(QuestionnairePart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Questionnaire_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/Questionnaire", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(QuestionnairePart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}