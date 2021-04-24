using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Authenticator
{
    [ServiceContract]
    public interface authenticatorInterface
    {
        [OperationContract]
        String GetRegisterDetails(String name, String Password);
        [OperationContract]
        void GetValuesForRegister(String name, String Password);
    }


    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]

    internal class DataServer : authenticatorInterface
    {

        public DataServer() { }
        public void GetRegisterDetails() { }

        
        public string GetRegisterDetails(string name, string Password)
        {
            string uname = "", psw = "";


            uname = name;
            psw = Password;


            string[] lines = { uname + psw };

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Register.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
            throw new NotImplementedException();
        }

        public void GetValuesForRegister(String name, String Password) { }

    }


}







