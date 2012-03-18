using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace PlanetNuLib
{
    class SimpleWeb
    {
        public SimpleWeb()
        {
            byte[] byteArray;
            WebRequest request = WebRequest.Create("http://api.planets.nu/login");
            request.Credentials = CredentialCache.DefaultCredentials;
            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            request.Method = "POST";
           // request.ContentLength = byteArray.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream dataStream = request.GetRequestStream();
         //   dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
           // Stream data = response.GetResponseStream;
            response.Close();
        }
    }
}
