using System;
using System.Windows.Forms;

namespace SmartClinicClient
{
    public partial class ClientRegistryForm : Form
    {
        public ClientRegistryForm()
        {
            InitializeComponent();
        }

        private void OnClickGetTicketListButton(object sender, EventArgs e)
        {
            ticketListBox.Items.Clear();

            var messageToSend = "GetTicketList";

            TcpSocketClient.ClientRun(messageToSend, (string str) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ticketListBox.Items.AddRange(str.Split('\n'));
                });
            });
        }

        private void LetTicketAction(string keyWord, string answerToUser, Action<string> onDone)
        {
            try
            {
                var selectedTicketInfo = ticketListBox.SelectedItem.ToString().Split('\t');
                var selectedTicketId = selectedTicketInfo[selectedTicketInfo.Length - 2];
                var selectedTalon = ticketListBox.SelectedItem.ToString();
                var messageToSend = $"{keyWord}\n{selectedTicketId}\n";

                TcpSocketClient.ClientRun(messageToSend, (string str) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"{answerToUser}:\t{str}");
                    });
                });

                onDone(selectedTalon);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void OnClickRemoveTicketButton(object sender, EventArgs e)
        {
            LetTicketAction("RemoveTicket", "Талон(ов) удален(о)", (string str) =>
            {
                getTicketListButton.PerformClick();
            });
        }

        private void OnClickTicketToWindowButton(object sender, EventArgs e)
        {
            var windowNumber = windowNumberTextBox.Text;

            LetTicketAction($"TicketToWindow\n{windowNumber}",
                "Подозвано талон(а/ов)", (string str) =>
                {
                    ticketListBox.Items.Clear();
                    ticketListBox.Items.Add(str);
                    ticketListBox.SetSelected(0, true);
                });
        }

        private void OnClickTicketToQueueButton(object sender, EventArgs e)
        {
            LetTicketAction("TicketToQueue", "Отозвано талон(а/ов)", (string str) =>
            {
                getTicketListButton.PerformClick();
            });
        }

        private void OnClickGetPatientListButton(object sender, EventArgs e)
        {
            patientListBox.Items.Clear();
            TcpSocketClient.ClientRun
                ($"GetPatientList\n{patientSearchTextBox.Text}", (string str) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        patientListBox.Items.AddRange(str.Split('\n'));
                    });
                });
        }

        private void OnClickAddPatientButton(object sender, EventArgs e)
        {
            TcpSocketClient.ClientRun
                ($"AddPatient\n" +
                $"{passportTextBox.Text}\n" +
                $"{lastNameTextBox.Text}\n" +
                $"{firstNameTextBox.Text}\n" +
                $"{patronymicTextBox.Text}\n" +
                $"{birthdateMaskedTextBox.Text}",
                (string str) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Добавлено {str} пациент(а/ов)");
                    });
                });

            clearPatientInfoButton.PerformClick();
        }

        private void OnClickСlearPatientInfoButton(object sender, EventArgs e)
        {
            passportTextBox.Clear();
            lastNameTextBox.Clear();
            firstNameTextBox.Clear();
            patronymicTextBox.Clear();
            birthdateMaskedTextBox.Clear();
        }

        private void OnClickGetScheduleButton(object sender, EventArgs e)
        {
            scheduleListBox.Items.Clear();

            TcpSocketClient.ClientRun
                ($"GetSchedule\n" +
                $"{scheduleSearchTextBox.Text}",
                (string str) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        scheduleListBox.Items.AddRange(str.Split('\n'));
                    });
                });
        }

        private void OnClickAddAssignmentButton(object sender, EventArgs e)
        {
            try
            {
                var selectedTicketInfo = ticketListBox.SelectedItem.ToString().Split('\t');
                var selectedTicketId = selectedTicketInfo[selectedTicketInfo.Length - 2];

                var selectedPatientInfo = patientListBox.SelectedItem.ToString().Split('\t');
                var selectedPatientId = selectedPatientInfo[selectedPatientInfo.Length - 2];

                var selectedScheduleInfo = scheduleListBox.SelectedItem.ToString().Split('\t');
                var selectedScheduleId = selectedScheduleInfo[selectedScheduleInfo.Length - 2];

                var messageToSend =
                    "AddAssignment\n" +
                    $"{selectedTicketId}\n" +
                    $"{selectedPatientId}\n" +
                    $"{selectedScheduleId}\n";

                TcpSocketClient.ClientRun(messageToSend, (string str) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        var numberOfUpdatedTables = 2;
                        if (Convert.ToInt32(str) == numberOfUpdatedTables)
                        {
                            MessageBox.Show
                            ($"Пациент:\t{string.Join(string.Empty, selectedPatientInfo)}\n" +
                            $"На прием:\t{string.Join(string.Empty, selectedScheduleInfo)}\n" +
                            $"Успешно записан.");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка. Ну удалось произвести запись на приём.");
                        }
                    });
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            getScheduleButton.PerformClick();
        }
    }
}
