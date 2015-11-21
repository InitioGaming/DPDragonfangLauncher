using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net;
using System.Collections.Generic;


namespace DPRENALauncher.Classes
{
    public class CGWebClient : WebClient
    {
        private System.Net.CookieContainer cookieContainer;
        private string userAgent;
        private int timeout;

        public System.Net.CookieContainer CookieContainer
        {
            get { return cookieContainer; }
            set { cookieContainer = value; }
        }

        public string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }

        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        public CGWebClient()
        {
            timeout = -1;
            userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727)";
            cookieContainer = new CookieContainer();
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            RefreshUserAgent();

            if (request.GetType() == typeof(HttpWebRequest))
            {
                ((HttpWebRequest)request).CookieContainer = cookieContainer;
                ((HttpWebRequest)request).UserAgent = userAgent;
                ((HttpWebRequest)request).Timeout = timeout;
            }

            return request;
        }

        private void RefreshUserAgent()
        {
            List<string> UserAgents = new List<string>();
            UserAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; ja; rv:1.9.2a1pre) Gecko/20090402 Firefox/3.6a1pre (.NET CLR 3.5.30729)");
            UserAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1b4) Gecko/20090423 Firefox/3.5b4 GTB5 (.NET CLR 3.5.30729)");
            Random r = new Random();
            this.UserAgent = UserAgents[r.Next(0, UserAgents.Count)];

            UserAgents = null;
        }
    }
}