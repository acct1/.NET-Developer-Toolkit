namespace Donios.DeveloperToolkit.Web
{
    using System;
    using System.Net;
    using System.IO;

    /// <summary>Utility classes for common HTTP operations</summary>
    public class HttpUtility
    {
        //TODO: Cleanup
        /// <summary>HTTP GET a URI and return a response</summary>
        /// <param name="URI">URI to GET</param>
        /// <param name="proxy">Set to null if a proxy will not be used</param>
        /// <returns>Body of the response</returns>
        /// <remarks>Based on code from http://www.hanselman.com/blog/HTTPPOSTsAndHTTPGETsWithWebClientAndCAndFakingAPostBack.aspx</remarks>
        public static string HttpGet(string URI, WebProxy proxy)
        {
            WebRequest req = WebRequest.Create(URI);
            if (proxy != null)
                req.Proxy = proxy;
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        
        //TODO: Cleanup
        /// <summary>HTTP POST to a URI and return a response</summary>
        /// <param name="URI">URI to POST parameters</param>
        /// <param name="proxy">Set to null if a proxy will not be used</param>
        /// <returns>Body of the response</returns>
        /// <remarks>Based on code from http://www.hanselman.com/blog/HTTPPOSTsAndHTTPGETsWithWebClientAndCAndFakingAPostBack.aspx</remarks>
        public static string HttpPost(string URI, string Parameters, WebProxy proxy)
        {
            WebRequest req = WebRequest.Create(URI);
             if (proxy != null)
                req.Proxy = proxy;
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}
