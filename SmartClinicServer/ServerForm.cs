using System;
using System.Threading;
using System.Windows.Forms;

namespace SmartClinicServer
{
    delegate void DelegateForServer();

    public partial class ServerForm : Form
    {
        Thread ThreadForServer;        

        public ServerForm()
        {
            InitializeComponent();

            var myServer = new SocketTcpServer();
            var availabilityServer = myServer.CheckServerIP();

            if (availabilityServer.Equals("True"))
            {
                DelegateForServer delegateForServer = myServer.Server;

                ThreadForServer = new Thread(new ThreadStart(delegateForServer));
                ThreadForServer.IsBackground = true;

                myServer.FlagStart();
                ThreadForServer.Start();

                UpdateQueue();

                Message.UpdateScoreboard += UpdateQueueInvoke;
            }
            else
            {
                MessageBox.Show(availabilityServer);
            }
        }

        private void UpdateQueueInvoke()
        {
            BeginInvoke(new Action(() => UpdateQueue()));
        }

        public void UpdateQueue()
        {
            try
            {
                var ticketLabels = new[]
               {
                    ticket1NumberLabel, ticket1WindowLabel,
                    ticket2NumberLabel, ticket2WindowLabel,
                    ticket3NumberLabel, ticket3WindowLabel,
                    ticket4NumberLabel, ticket4WindowLabel,
                    ticket5NumberLabel, ticket5WindowLabel,
                };

                var queueArray = Ticket.GetQueueArray();

                for (int i = 0; i < ticketLabels.Length; i++)
                {
                    ticketLabels[i].Text = null;
                }

                for (int i = 0; i < ticketLabels.Length; i++)
                {
                    ticketLabels[i].Text = queueArray[i];
                }
            }
            catch (Exception exception)
            {

            }
        }
    }
}