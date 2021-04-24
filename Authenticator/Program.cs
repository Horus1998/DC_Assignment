using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("hey so like welcome to my server");
            ServiceHost host;
            
            NetTcpBinding tcp = new NetTcpBinding();
            
            host = new ServiceHost(typeof(DataServer));

             host.AddServiceEndpoint(typeof(authenticatorInterface), tcp, "net.tcp://localhost:8100/AuthenticationService");
        
        host.Open();
 Console.WriteLine("System Online");
 Console.ReadLine();
 
 host.Close();

          
        }
    }
}
