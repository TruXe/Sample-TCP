using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using Server.Utils;

namespace Server
{
    internal class Program
    {
        public static bool authenticationResult;

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            server.Start();

            Helpers.Blank();
            Helpers.WriteLine("TCP Client by ( Discord:kexo0001 )", 2);
            Helpers.Blank();

            Helpers.WriteLine("Server is listening...", 1);

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Helpers.WriteLine("Client connected", 1);

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

                Helpers.WriteLine("Waiting for client data...", 1);

                string username = reader.ReadLine();
                string password = reader.ReadLine();
                string hwid = reader.ReadLine();

                Helpers.WriteLine($"Received data - Username: {username}, Password: {password}, HWID: {hwid}", 1);
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

                Helpers.WriteLine($"Sending response to client: {response}", 1);
                writer.WriteLine(response);
            }

            client.Close();
            Helpers.WriteLine("Client disconnected\n", 0);
        }
    }
}
