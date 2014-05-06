using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Orchard;
using Orchard.Mvc;
using Orchard.Localization;
//using PusdKop.Questionnaire.Models;
using Orchard.UI.Notify;
using Orchard.Logging;

namespace PusdKop.Questionnaire.Controllers
{
    public class DependencyInjectionController : Controller
    {
        private IWorkContextAccessor _wca;
        private IHttpContextAccessor _hca;
        private INotifier _notifier;


        public Localizer T { get; set; }

        public ILogger Logger { get; set; }
        public DependencyInjectionController(IWorkContextAccessor wca,IHttpContextAccessor hca,INotifier notifier)
        {
            _wca = wca;
            _hca = hca;
            _notifier = notifier;

            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }

        public ActionResult Index()
        {
            var workContext = _wca.GetContext();
            var httpContext = _hca.Current();

            if(workContext.CurrentUser!=null)
            {
                _notifier.Information(T("Hello {0} ", workContext.CurrentUser.UserName));
                return RedirectToAction("Index", "Home", new { Area = "PusdKop.Questionnaire", UserName = workContext.CurrentUser.UserName });
                //return RedirectToAction("Index","Home");
                

                
            }
            else
            {
                Logger.Error("User is not logged in");//record to log file
                return RedirectToAction("Index", "Home", new { Area = "PusdKop.Questionnaire" });
            }

            

           
        }
    }
}