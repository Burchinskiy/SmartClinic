using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SmartClinicServer
{
    public class SocketTcpServer
    {
        private bool flag;

        public void Server()
        {
            var ipPoint = new IPEndPoint(IPAddress.Parse(DataBase.GetServerIP()), 8005);

            var listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(ipPoint);
            listenSocket.Listen(10);

            MessageBox.Show(DataBase.Check());

            while (flag)
            {
                Socket handler = listenSocket.Accept();
                var builder = new StringBuilder();
                int bytes = 0;
                var data = new byte[256];

                do
                {
                    bytes = handler.Receive(data);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (handler.Available > 0);

                string message = Message.Decode(builder.ToString());

                data = Encoding.Unicode.GetBytes(message);
                handler.Send(data);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }

        public string CheckServerIP()
        {
            try
            {
                var ipPoint = new IPEndPoint(IPAddress.Parse(DataBase.GetServerIP()), 8005);
                var listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listenSocket.Bind(ipPoint);
                listenSocket.Close();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return "True";
        }

        public void FlagStart()
        {
            flag = true;
        }

        public void FlagStop()
        {
            flag = false;
        }
    }
}