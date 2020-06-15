using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SeleniumSpecflow.Utils
{
    class HttpRequests
    {

        public string GetCodeOfGetRequest(string uri)
        {
            try { 
                // Headers to access the resource
                WebRequest webRequest = WebRequest.Create(uri);
                webRequest.Method = "GET";

                HttpWebRequest request = (HttpWebRequest)webRequest;
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                return response.StatusCode.ToString();
            }
            catch(WebException e)
            {
                return ((HttpWebResponse)e.Response).StatusCode.ToString();
            }
        }
    }
}
