using System;
using System.Threading.Tasks;
using Kerberos.NET;
using Kerberos.NET.Client;
using Kerberos.NET.Credentials;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 for username and password athontication");
            Console.WriteLine("2 for service authontication without username and password");
            string ans = Console.ReadLine();
            if (ans == "1") { 
                 Console.WriteLine("Enter username like oren_ba@lcard.corp");
                 var user1=Console.ReadLine();
                 Console.WriteLine(user1);
                
                 Console.WriteLine("Enter password");
                 var password1 = Console.ReadLine();
                 Console.WriteLine(password1);
                           
                 try
                 {
                     var a = DMain(user1, password1);
                     a.Wait();
                 }
                
                 catch (Exception e) 
                 { 
                       Console.WriteLine("YOU SHALL NOT PASS!@#!@$. This is the exeption. --> {0}", e);
                 }
            }
            if (ans == "2") {
                Console.WriteLine("GetServiceTicket?");
                var ans1 = Console.ReadLine();
                var b = dMainService(ans1);
                b.Wait();



            }

        }


        static  async Task DMain(string user, string pass)
        {

            var client = new KerberosClient();

            var kerbCred = new KerberosPasswordCredential(user, pass); //"user@domain.com", "userP@ssw0rd!"

            await client.Authenticate(kerbCred);

            // var ticket = await client.GetServiceTicket("krbtgt/LCARD.LOCAL@LCARD.LOCAL"); 
            //var ticket = await client.GetServiceTicket("host/appservice.corp.identityintervention.com");
            // Console.WriteLine(ticket.ToString());
            // Console.WriteLine("yoyo");

        }

        static async Task dMainService(string spn) //service principal name
        {
            var client = new KerberosClient();
            var kerbCred1 = new KerberosPasswordCredential("administrator@lcard.local", "Pa$$w0rd"); //"user@domain.com", "userP@ssw0rd!"
            await client.Authenticate(kerbCred1);
            var ticket = await client.GetServiceTicket(spn);
            var ticket1 = await client.GetServiceTicket("srvice");
            Console.WriteLine(ticket.ToString()) ;
            Console.WriteLine("the secontd");
            Console.WriteLine(ticket.MessageType.ToString()); 


        }

    }
    
}
