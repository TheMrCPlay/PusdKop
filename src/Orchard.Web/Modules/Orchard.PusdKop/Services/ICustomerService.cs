using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard;
using Orchard.PusdKop.Models;

namespace Orchard.PusdKop.Services
{
    public interface ICustomerService : IDependency
    {
        CustomerPart CreateCustomer(string email, string password);
        QuestionnairePart GetQuestionnaire(int customerId, string questionnaireType);

        QuestionnairePart CreateQuestionnaire(int customerId, string questionnaireType);
    }
}