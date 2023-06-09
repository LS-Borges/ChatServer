using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatServer
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ChatServer");
            TheServer server = new TheServer();
            server.Start();
        }
    }
}
