using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatServer
{
    class TheServer
    {
        static TcpListener listener;
        static TheServer server;
        public static List<ClientHandler> clientList = new List<ClientHandler>();

        public void Start()
        {
            IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            listener = new TcpListener(ipAdress, port);
            listener.Start();

            Console.WriteLine("Server started on {0}:{1}", ipAdress, port);

            Thread connectionThread = new Thread(HandleConnections);
            connectionThread.Start();
        }

        private static void HandleConnections()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine($"New client: {client.Client.RemoteEndPoint}");

                ClientHandler clientHandler = new ClientHandler(client, server);
                clientList.Add(clientHandler);

                Thread clientThread = new Thread(clientHandler.HandleClient);
                clientThread.Start();
            }
        }
    }
}
