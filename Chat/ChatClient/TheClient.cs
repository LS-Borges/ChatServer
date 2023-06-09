using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace ChatClient
{
    class TheClient
    {
        TcpClient client;
        NetworkStream stream;

        public void ConnectToServer()
        {
            //create a socket

            //create a stream by GetStream()

            //create a thread for receiving

            //create a thread for sending
        }

        public void ReceiveMessages()
        {
            while(true)
            {
                // read from the stream
                //convert to string
                //display on console using WriteLine
            }
        }

        public void SendMessages()
        {
            string message;

            while(true)
            {
                message = Console.ReadLine();
                //convert message to array of bytes
                //write to stream
            }
        }
    }
}
