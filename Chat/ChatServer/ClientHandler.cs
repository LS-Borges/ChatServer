using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

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
            byte[] buffer = new byte[1024];

            stream = tcpClient.GetStream();
            string welcomeMessage = "Welcome to the Chat Server";
            bytes = Encoding.ASCII.GetBytes(welcomeMessage);
            stream.Write(bytes);

            while(true)
            {
                int messageLength = stream.Read(buffer);
                string message = Encoding.ASCII.GetString(buffer, 0, messageLength);

                if(messageLength == 1)
                {
                    break;
                }

                foreach(ClientHandler client in TheServer.clientList)
                {
                    if(client != this)
                    {
                        stream.Write(buffer);
                    }
                }
            }

            stream.Close();
            tcpClient.Close();
        }
    }
}
