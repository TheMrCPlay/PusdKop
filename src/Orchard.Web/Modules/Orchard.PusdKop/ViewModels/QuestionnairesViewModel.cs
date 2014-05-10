using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Orchard.PusdKop.ViewModels
{
    public class QuestionnairesViewModel : IValidatableObject //changed, need to test
    {

        //[UIHint("Address")]
        //public AddressViewModel InvoiceAddress { get; set; }

        [UIHint("Questionnaire")]
        public QuestionnaireViewModel UserQuestionnaire { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var questionnaire = UserQuestionnaire;

            if (string.IsNullOrWhiteSpace(questionnaire.Name))
                yield return new ValidationResult("Name is a required field", new[] { "UserQuestionnaire.Name" });

            if (string.IsNullOrWhiteSpace(questionnaire.Surname))
                yield return new ValidationResult("Surname is a required field", new[] { "UserQuestionnaire.Surname" });

            if (string.IsNullOrWhiteSpace(questionnaire.Interests))
                yield return new ValidationResult("Interests is a required field", new[] { "UserQuestionnaire.Interests" });

            if (string.IsNullOrWhiteSpace(questionnaire.Kitchen))
                yield return new ValidationResult("Kitchen is a required field", new[] { "UserQuestionnaire.Kitchen" });

            if (string.IsNullOrWhiteSpace(questionnaire.City))
                yield return new ValidationResult("City is a required field", new[] { "UserQuestionnaire.City" });

            
        }
    }
}