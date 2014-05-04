using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Themes;
//using Orchard.UI.Notify;
//using Orchard.ContentManagement;
using Orchard;
using Orchard.Mvc;
using Orchard.Localization;
using PusdKop.Questionnaire.Models;

namespace PusdKop.Questionnaire.Controllers
{
    [HandleError, Themed]
    public class HomeController : Controller
    {
        public HomeController()
        {
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        private readonly IOrchardServices _orchardServices;
        public ActionResult Index()
        {
            //var shape = _orchardServices.New.Index();
            return View("Questionnaire");

        }

        [HttpPost]
        public ActionResult Index(string Name, string Surname, string Interests, string Kitchen, string City, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                ValidateQuestionnaire(Name, Surname, Interests, Kitchen, City);
            }
            return View("Questionnaire");
        }

        private bool ValidateQuestionnaire(string name, string surname, string interests, string kitchen, string city)
        {
            bool validate = true;

            if (String.IsNullOrEmpty(name))
            {
                //ModelState.AddModelError("name", T("You must specify a name."));

                validate = false;
            }
            else
            {
                if (name.Length >= 255)
                {
                    // ModelState.AddModelError("name", T("The name you provided is too long."));
                    validate = false;
                }
            }

            if (String.IsNullOrEmpty(surname))
            {
                //ModelState.AddModelError("surname", T("You must specify a surname."));

                validate = false;
            }
            else
            {
                if (surname.Length >= 255)
                {
                    //ModelState.AddModelError("surname", T("The surname you provided is too long."));
                    validate = false;
                }
            }

            if (String.IsNullOrEmpty(interests))
            {
                //ModelState.AddModelError("surname", T("You must specify a surname."));

                validate = false;
            }
            else
            {
                if (interests.Length >= 255)
                {
                    //ModelState.AddModelError("surname", T("The surname you provided is too long."));
                    validate = false;
                }
            }

            if (String.IsNullOrEmpty(kitchen))
            {
                //ModelState.AddModelError("surname", T("You must specify a surname."));

                validate = false;
            }
            else
            {
                if (kitchen.Length >= 255)
                {
                    //ModelState.AddModelError("surname", T("The surname you provided is too long."));
                    validate = false;
                }
            }

            if (String.IsNullOrEmpty(city))
            {
                //ModelState.AddModelError("surname", T("You must specify a surname."));

                validate = false;
            }
            else
            {
                if (city.Length >= 255)
                {
                    //ModelState.AddModelError("surname", T("The surname you provided is too long."));
                    validate = false;
                }
            }


            return ModelState.IsValid;
        }
    }


}