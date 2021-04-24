using Nancy.Json;
using System;
using System.IO;
using System.Net;

namespace ConsoleProg
{
    class Program
    {
        static void Main(string[] args)
        { 

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("net.tcp://localhost:8100/AuthenticationService");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    Username = "myusername",
                    Password = "pass"
                });
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
