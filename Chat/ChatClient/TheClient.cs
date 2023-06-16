using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatClient
{
    class TheClient
    {
        TcpClient client;
        NetworkStream stream;

        public void ConnectToServer()
        {
            //create a socket
            IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            client = new TcpClient();
            client.Connect(ipAdress, port);

            Console.WriteLine("Connected to the Server");

            //create a stream by GetStream()
            stream = client.GetStream();

            //create a thread for receiving
            Thread receivingThread = new Thread(ReceiveMessages);
            receivingThread.Start();

            //create a thread for sending
            Thread sendingThread = new Thread(SendMessages);
            sendingThread.Start();
        }

        public void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                // read from the stream
                int messageLength = stream.Read(buffer);


                //convert to string
                string message = Encoding.ASCII.GetString(buffer, 0, messageLength);

                if (messageLength == 1)
                {
                    break;
                }

                //display on console using WriteLine
                Console.WriteLine(message);
            }
        }

        public void SendMessages()
        {
            string message;

            while(true)
            {
                message = Console.ReadLine();

                //convert message to array of bytes
                byte[] buffer = Encoding.ASCII.GetBytes(message);

                //write to stream
                stream.Write(buffer);
            }
        }
    }
}
