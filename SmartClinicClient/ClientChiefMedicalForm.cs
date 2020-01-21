using System;
using System.Windows.Forms;

namespace SmartClinicClient
{
    public partial class ClientChiefMedicalForm : Form
    {
        public ClientChiefMedicalForm()
        {
            InitializeComponent();
        }

        private void OnClickGetStaffListButton(object sender, EventArgs e)
        {
            staffSearchListBox.Items.Clear();

            TcpSocketClient.ClientRun($"GetStaffList\n{staffSearchTextBox.Text}", (string str) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    staffSearchListBox.Items.AddRange(str.Split('\n'));
                });
            });
        }

        private void OnClickAddStaffButton(object sender, EventArgs e)
        {
            TcpSocketClient.ClientRun
                ($"AddStaff\n" +
                $"{lastNameTextBox.Text}\n" +
                $"{firstNameTextBox.Text}\n" +
                $"{patronymicTextBox.Text}\n" +
                $"{departmentTextBox.Text}\n" +
                $"{typeTextBox.Text}\n" +
                $"{categoryTextBox.Text}\n" +
                $"{degreeTextBox.Text}\n" +
                $"{postTextBox.Text}", (string str) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Добавлено {str} сотрудник(ов).");
                    });
                });
        }

        private void OnClickCalculateAppointmentButton(object sender, EventArgs e)
        {
            try
            {
                var wasCalculatedDT = Appointment.Calculate(
                    Convert.ToDateTime(startAppointmentMaskedTextBox.Text),
                    Convert.ToDateTime(endAppointmentMaskedTextBox.Text),
                    Convert.ToInt32(minIntervalTextBox.Text));

                TcpSocketClient.ClientRun
                ($"AddSchedule\n" +
                $"{staffSearchListBox.SelectedItem.ToString().Split('\t')[0]}\n" +
                $"{wasCalculatedDT}", (string str) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Добавлено {str} прием(ов) пациента(ов).");
                    });
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }            
        }
    }
}