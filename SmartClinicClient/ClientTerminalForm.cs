using System;
using System.Windows.Forms;

namespace SmartClinicClient
{
    public partial class ClientTerminalForm : Form
    {
        public ClientTerminalForm()
        {
            InitializeComponent();
        }

        private void OnClickAddTicketButton(object sender, EventArgs e)
        {
            TcpSocketClient.ClientRun("AddTicket", (string str) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Ваш талон:\t{str}");
                });
            });
        }
    }
}
