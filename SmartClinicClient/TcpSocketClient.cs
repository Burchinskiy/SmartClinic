using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SmartClinicClient
{
    class TcpSocketClient
    {
        public static string GetServerIP()
        {
            return File.ReadAllText("ClientIP.txt");
        }

        public static string Client(string message)
        {
            try
            {
                var ipPoint = new IPEndPoint(IPAddress.Parse(GetServerIP()), 8005);

                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);

                var data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                data = new byte[256];
                var builder = new StringBuilder();
                var bytes = 0;

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                return builder.ToString();
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }

        public static void ClientRun(string input, Action<string> callback)
        {
            ThreadStart threadStart = () =>
            {
                callback(Client(input));
            };
            var thread = new Thread(threadStart);
            thread.Start();
        }
    }
}