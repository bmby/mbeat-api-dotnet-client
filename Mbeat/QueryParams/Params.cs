using System;
using System.Linq;
using System.Web;

namespace Mbeat.QueryParams
{
    public abstract class Params
    {
        private string LowercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToLower(a[0]);

            return new string(a);
        }

        public string QueryString
        {

            get 
            {
                string queryString = GetType().GetProperties()
                         .Where(p => p.Name != "QueryString")
                         .Select(p => LowercaseFirst(p.Name) + "=" + HttpUtility.UrlEncode(p.GetValue(this, null).ToString()))
                         .Aggregate("", (current, next) => current + "&" + next);

                return queryString;
            }
        }
    }
}
