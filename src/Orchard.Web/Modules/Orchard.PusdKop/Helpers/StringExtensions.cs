using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.PusdKop.Helpers
{
    public static class StringExtensions
    {
        public static string TrimSafe(this string s)
        {
            return s == null ? string.Empty : s.Trim();
        }
    }
}