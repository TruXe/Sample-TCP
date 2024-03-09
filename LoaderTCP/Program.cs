using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
using Server.Utils;
using System.Windows.Forms;


namespace LoaderTCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            //TcpClient client = new TcpClient("127.0.0.1", 8888);
            try
            {
                client.Connect("127.0.0.1", 8888);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.AutoFlush = true; // Enable automatic flushing
                Helpers.Blank();
                Helpers.WriteLine("TCP Client by ( Discord:kexo0001 )", 2);
                Helpers.Blank();

                Helpers.WriteReadLine("Enter your username: ", 2);
                string username = Console.ReadLine();
                writer.WriteLine(username);

                Helpers.WriteReadLine("Enter your password: ", 2);
                string password = Console.ReadLine();
                writer.WriteLine(password);

                Helpers.WriteReadLine("Enter your HWID: ", 3);
                string hwid = Console.ReadLine();
                writer.WriteLine(hwid);

                // Ensure DATA.
                writer.Flush();

                // Response from server
                string serverResponse = reader.ReadLine();
              //  Console.WriteLine($" [+] Server response: {serverResponse}");

                if(serverResponse == "ALLOWED")
                {
                    string choice = null;
                    Helpers.Welcome($"{username}");
                    Helpers.Blank();

                    Console.WriteLine(" Your choice:\n [1] Inject 1\n [2] Inject 2\n [3] Exit");

                    Helpers.Blank();

                    Console.Write(" Choice: "); choice = Console.ReadLine();
                    if(choice == "1")
                    {

                        Helpers.WriteLine($"Injecting 1..", 1);
                    }
                    else if(choice == "2")
                    {
                        Helpers.WriteLine($"Injecting 2..", 1);
                    }
                    else if (choice == "3")
                    {
                        Helpers.WriteLine($"Closing application in 3 sec.", 0);
                        Thread.Sleep(3000);

                        Environment.Exit(0);
                    }

                }

                Console.ReadLine();
            }
            Console.ReadKey();
            client.Close();
        }
    }
}
