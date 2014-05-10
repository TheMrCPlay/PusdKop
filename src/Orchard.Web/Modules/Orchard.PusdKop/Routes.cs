using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Orchard.PusdKop
{

    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "PusdKop",
                        new RouteValueDictionary {
                            {"area", "PusdKop"},
                            {"controller", "Checkout"},
                            {"action", "SignupOrLogin"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "PusdKop"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}