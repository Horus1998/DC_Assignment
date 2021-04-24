using ServerProg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.IO;
using Path = System.IO.Path;

namespace WPFClient
{
    
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();


            /*
            try
            {


                ChannelFactory<ServerProg.authenticatorInterface> foobFactory;
                NetTcpBinding tcp = new NetTcpBinding();
                //Set the URL and create the connection!
                string URL = "net.tcp://localhost:8100/AuthenticationService";
                foobFactory = new ChannelFactory<authenticatorInterface>(tcp, URL);

                foob = foobFactory.CreateChannel();
            }
            catch
            {

                Console.WriteLine("Exception caught: {0}");
            }
            finally
            {
                Console.WriteLine("Result final");
            }
            */

            TcpChannel channel = new TcpChannel(8100);  // port no. 9999

            // Register channel 
            ChannelServices.RegisterChannel(channel, false);

            // Register as an available service with the name hello
            try {
                authenticatorInterface.AuthenticationService obj = (authenticatorInterface.AuthenticationService)Activator.GetObject(
                     typeof(authenticatorInterface.AuthenticationService),
                     "net.tcp://localhost:8100/AuthenticationService"
                 );
            }
            catch
            {

                Console.WriteLine("Exception caught: {0}");
            }
            finally
            {
                Console.WriteLine("Result final");
            }
            

        }

        private void register_btn_Click(object sender, RoutedEventArgs e)
        {

           
            string name = "", Password = "";

            name = namebox.Text;
            Password = Passwordbox.Password;
            //Then, run our RPC function, using the out mode parameters...
            //
            Authenticator.GetValuesForRegister(in name,in Password);
            //And now, set the values in the GUI!
           



        }
    }
}
