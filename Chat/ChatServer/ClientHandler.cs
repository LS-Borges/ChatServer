using System.Text;
using System.Net.Sockets;
using System;

namespace ChatServer
{
    class ClientHandler
    {
        TcpClient tcpClient { get; set; }
        TheServer server;
        NetworkStream stream;

        public ClientHandler(TcpClient c, TheServer s)
        {
            tcpClient = c;
            server = s;
        }

        public void HandleClient()
        {
            byte[] bytes = new byte[1024];
            stream = tcpClient.GetStream();
            string welcomeMessage = "Welcome to the Chat Server";
            string endMessage;
            bytes = Encoding.ASCII.GetBytes(welcomeMessage);
            stream.Write(bytes);

            while(true)
            {
                byte[] buffer = new byte[1024];
                int messageLength = stream.Read(buffer);
                string message = Encoding.ASCII.GetString(buffer, 0, messageLength);

                endMessage = message.ToLower();
                if(endMessage == "end")
                {
                    Console.WriteLine("Leaving Chat Server");
                    break;
                }

                foreach(ClientHandler client in TheServer.clientList)
                {
                    if (client != this)
                    {
                        client.stream.Write(buffer);
                    }
                }
            }

            stream.Close();
            tcpClient.Close();
        }
    }
}
