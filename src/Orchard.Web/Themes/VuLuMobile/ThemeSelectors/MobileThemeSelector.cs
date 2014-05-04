using System;
using System.Text.RegularExpressions;
using System.Web.Routing;
using Orchard.Themes;

namespace VuLuMobile.ThemeSelectors {
    public class MobileThemeSelector : IThemeSelector {
        private static readonly Regex _Msie678  = new Regex(@"^Mozilla\/4\.0 \(compatible; MSIE [678]\.0; Windows NT \d\.\d(.*)\)$", RegexOptions.IgnoreCase);
        private ThemeSelectorResult _requestCache;
        private bool _requestCached;
        
        public ThemeSelectorResult GetTheme(RequestContext context) {
            if (_requestCached) return _requestCache;
            _requestCached = true;
            var userAgent = context.HttpContext.Request.UserAgent;
            if (userAgent.IndexOf("phone", StringComparison.OrdinalIgnoreCase) != -1 ||
                _Msie678.IsMatch(userAgent) ||
                userAgent.IndexOf("windows live writer", StringComparison.OrdinalIgnoreCase) != -1) {
                _requestCache = new ThemeSelectorResult {
                    Priority = 10,
                    ThemeName = "VuLuMobile"
                };
            }
            return _requestCache;
        }
    }
}