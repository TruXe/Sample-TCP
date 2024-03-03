using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Server
{
    internal class Program
    {
        public static bool authenticationResult;

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            server.Start();

            Console.Write("\n");
            Console.WriteLine(" [*] TCP Client by ( Discord:kexo0001 ) [*] ");
            Console.Write("\n");

            Console.WriteLine(" [+] Server is listening...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine(" [+] Client connected");

                HandleClient(client);
            }
        }

        static void HandleClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.AutoFlush = true; // Enable automatic flushing

                Console.WriteLine(" [+] Waiting for client data...");

                string username = reader.ReadLine();
                string password = reader.ReadLine();
                string hwid = reader.ReadLine();

                Console.WriteLine($" [+] Received data - Username: {username}, Password: {password}, HWID: {hwid}");
                authenticationResult = false;
                //HERE YOU CAN IMPLEMENT API.
                //FOR TESTING
                if (username == "admin")
                {
                    if(password == "admin")
                    {
                        if(hwid == "1")
                        {
                            authenticationResult = true;
                        }
                        else
                        {
                            authenticationResult = false;
                        }
                    }
                    else
                    {
                        authenticationResult = false;
                    }
                }
                else
                {
                    authenticationResult = false;
                }

                //Send Allowed or Denied
                string response = authenticationResult ? "ALLOWED" : "DENIED";

                Console.WriteLine($" [+] Sending response to client: {response}");
                writer.WriteLine(response);
            }

            client.Close();
            Console.WriteLine(" [-] Client disconnected");
        }
    }
}
