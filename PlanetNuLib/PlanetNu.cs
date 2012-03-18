using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace PlanetNuLib
{
    class PlanetNu
    {
        static HttpWebRequest GetRequest(string address)
        {
            Uri uri = new Uri(address);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Proxy = null;
            request.Method = "GET";
           request.UserAgent = "PlanetsNuLib/0.1";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return request;
        }
        static HttpWebRequest PostRequest(string address)
        {
            Uri uri = new Uri(address);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Proxy = null;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "PlanetsNuLib/0.1";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return request;
        }
        static void PostContent(HttpWebRequest request, string s)
        {
            byte[] byte_array = Encoding.UTF8.GetBytes(s);
            request.ContentLength = byte_array.Length;
            Stream rs = request.GetRequestStream();
            rs.Write(byte_array, 0, byte_array.Length);
            rs.Close();
        }
        static string Responce(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            return readStream.ReadToEnd();
        }
        public static string GetKey(string username, string password)
        {
            // Have to do a post here.  I hope we get to use https in the future
            string address = "http://api.planets.nu/login";
            string post_data = string.Format("username={0}&password={1}",username,password);
            HttpWebRequest request = PostRequest(address);
            PostContent(request, post_data);
            return Responce(request);
        }
        public static string GetGameList()
        {
            string address = "http://api.planets.nu/games/list";
            return Responce(GetRequest(address));
        }
        public static  string GetTurnData(int gameid, int playerid) {
            string address = string.Format("http://api.planets.nu/game/loadturn?gameid={0}&playerid={1}", gameid, playerid);
            return Responce(GetRequest(address));
        }
        public PlanetNu(string username, string password)
        {
            
        }
    }
}
