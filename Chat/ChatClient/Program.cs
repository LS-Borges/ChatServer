using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ChatClient");
            TheClient client = new TheClient();
            client.ConnectToServer();
        }
    }
}