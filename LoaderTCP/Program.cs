using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;


namespace LoaderTCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 8888);

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.AutoFlush = true; // Enable automatic flushing
                Console.Write("\n");
                Console.WriteLine(" [*] TCP Client by ( Discord:kexo0001 ) [*] ");
                Console.Write("\n");
                Console.Write(" [*] Enter your username: ");
                string username = Console.ReadLine();
                writer.WriteLine(username);

                Console.Write(" [*] Enter your password: ");
                string password = Console.ReadLine();
                writer.WriteLine(password);

                Console.Write(" [*] Enter your HWID: ");
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
                    Console.WriteLine($" Welcome, dear {username}");

                    Console.Write("\n");

                    Console.WriteLine(" Your choice:\n [1] Inject 1\n [2] Inject 2\n [3] Exit");

                    Console.Write("\n");

                    Console.Write(" Choice: "); choice = Console.ReadLine();
                    if(choice == "1")
                    {
                        Console.WriteLine($" [TEST] choice: {choice}");
                        Console.WriteLine($" [+] Injecting 1..");
                    }
                    else if(choice == "2")
                    {
                        Console.WriteLine($" [TEST] choice: {choice}");
                        Console.WriteLine($" [+] Injecting 2..");
                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine($" [TEST] choice: {choice}");
                        Console.WriteLine($" [-] Closing application in 3 sec.");
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
