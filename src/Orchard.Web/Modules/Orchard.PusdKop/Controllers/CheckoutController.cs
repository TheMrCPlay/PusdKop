using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Themes;
using Orchard.Security;
using Orchard.PusdKop.ViewModels;
using Orchard.PusdKop.Services;
using Orchard.ContentManagement;
using Orchard.PusdKop.Helpers;

using Orchard.PusdKop.Models;

namespace Orchard.PusdKop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrchardServices _services;
        private readonly ICustomerService _customerService;
        private readonly IMembershipService _membersipService;

        private Localizer T { get; set; }

        public CheckoutController(IOrchardServices services, IAuthenticationService authenticationService, ICustomerService customerService, IMembershipService membersipService)
        {
            _authenticationService = authenticationService;
            _services = services;
            _customerService = customerService;
            _membersipService = membersipService;
            T = NullLocalizer.Instance;
        }

        [Themed]
        public ActionResult SignupOrLogin()
        {
            if (_authenticationService.GetAuthenticatedUser() != null)
                return RedirectToAction("SelectQuestionnaire");

            return new ShapeResult(this, _services.New.Checkout_SignupOrLogin());
        }

        [Themed]
        public ActionResult Signup()
        {
            var shape = _services.New.Checkout_Signup();
            return new ShapeResult(this, shape);
        }

        [HttpPost]
        public ActionResult Signup(SignupViewModel signup)
        {
            if (!ModelState.IsValid)
                return new ShapeResult(this, _services.New.Checkout_Signup(Signup: signup));

            var customer = _customerService.CreateCustomer(signup.Email, signup.Password);
            customer.FirstName = signup.FirstName;
            customer.LastName = signup.LastName;
            customer.Title = signup.Title;

            _authenticationService.SignIn(customer.User, true);

            // TODO: Create a new account for the customer 
            return RedirectToAction("SelectQuestionnaire");
        }

        [Themed]
        public ActionResult Login()
        {
            var shape = _services.New.Checkout_Login();
            return new ShapeResult(this, shape);
        }

        [Themed, HttpPost]
        public ActionResult Login(LoginViewModel login)
        {

            // Validate the specified credentials
            //var user = _membershipService.ValidateUser(login.Email, login.Password);
            var user = _membersipService.ValidateUser(login.Email, login.Password);
           

            // If no user was found, add a model error
            if (user == null)
            {
                ModelState.AddModelError("Email", T("Incorrect username/password combination").ToString());
            }

            // If there are any model errors, redisplay the login form
            if (!ModelState.IsValid)
            {
                var shape = _services.New.Checkout_Login(Login: login);
                return new ShapeResult(this, shape);
            }

            // Create a forms ticket for the user
            _authenticationService.SignIn(user, login.CreatePersistentCookie);

            // Redirect to the next step
            return RedirectToAction("SelectQuestionnaire");
        }

        [Themed]
        public ActionResult SelectQuestionnaire()
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();

            if (currentUser == null)
            {
                throw new OrchardSecurityException(T("Login required"));
                
                //return RedirectToAction("Login");
            }
                

           // else
            //{
                var customer = currentUser.ContentItem.As<CustomerPart>();

                //var UserQuestionnaire = _customerService.GetAddress(customer.Id, "InvoiceAddress");
                var userQuestionnaire = _customerService.GetQuestionnaire(customer.Id, "UserQuestionnaire"); //letit tut

                var questionnairesViewModel = new QuestionnairesViewModel
                {
                    UserQuestionnaire = MapQuestionnaire(userQuestionnaire)
                };

                var shape = _services.New.Checkout_SelectQuestionnaire(Questionnaires: questionnairesViewModel);

                if (string.IsNullOrWhiteSpace(questionnairesViewModel.UserQuestionnaire.Name))
                {
                    questionnairesViewModel.UserQuestionnaire.Name = string.Format("{0} {1} {2}", customer.Title, customer.FirstName, customer.LastName);
                }

                return new ShapeResult(this, shape);
           // }
            
        }

        [Themed, HttpPost]
        public ActionResult SelectQuestionnaire(QuestionnairesViewModel addresses)
        {
            var currentUser = _authenticationService.GetAuthenticatedUser();

            if (currentUser == null)
                throw new OrchardSecurityException(T("Login required"));

            if (!ModelState.IsValid)
            {
                return new ShapeResult(this, _services.New.Checkout_SelectAddress(Addresses: addresses));
            }

            var customer = currentUser.ContentItem.As<CustomerPart>();
            MapQuestionnaire(addresses.UserQuestionnaire, "UserQuestionnaire", customer);
            //MapQuestionnaire(addresses.ShippingAddress, "ShippingAddress", customer);
            
            return RedirectToAction("Summary");
        }

        [Themed]
        public ActionResult Summary()
        {
            var shape = _services.New.Checkout_Summary();
            return new ShapeResult(this, shape);
        }

        private QuestionnaireViewModel MapQuestionnaire(QuestionnairePart questionnairePart)
        {
            dynamic questionnaire = questionnairePart;
            var questionnaireViewModel = new QuestionnaireViewModel();

            if (questionnairePart!= null)
            {
                questionnaireViewModel.Name = questionnaire.Name.Value;
                questionnaireViewModel.Surname = questionnaire.Surname.Value;
                questionnaireViewModel.Interests = questionnaire.Interests.Value;
                questionnaireViewModel.Kitchen = questionnaire.Kitchen.Value;
                questionnaireViewModel.City = questionnaire.City.Value;

            }

            return questionnaireViewModel;
        }

        private QuestionnairePart MapQuestionnaire(QuestionnaireViewModel source, string questionnaireType, CustomerPart customerPart)
        {
            var questionnairePart = _customerService.GetQuestionnaire(customerPart.Id, questionnaireType) ?? _customerService.CreateQuestionnaire(customerPart.Id, questionnaireType);
            
            dynamic address = questionnairePart;

            address.Name.Value = source.Name.TrimSafe();
            address.Surname.Value = source.Surname.TrimSafe();
            address.Interests.Value = source.Interests.TrimSafe();
            address.Kitchen.Value = source.Kitchen.TrimSafe();
            address.City.Value = source.City.TrimSafe();
            

            return questionnairePart;
        }
    }
}