using System;
using System.Windows.Forms;

namespace SmartClinicClient
{
    public partial class ClientChoiceForm : Form
    {
        public ClientChoiceForm()
        {
            InitializeComponent();
        }

        private void ChangeMainForm(Form newForm)
        {
            Program.Context.MainForm = newForm;
            this.Close();
            Program.Context.MainForm.Show();
        }

        private void OnClickClientTerminalButton(object sender, EventArgs e)
        {
            ChangeMainForm(new ClientTerminalForm());
        }

        private void OnClickClientRegistryButton(object sender, EventArgs e)
        {
            ChangeMainForm(new ClientRegistryForm());
        }

        private void OnClickClientChiefMedicalButton(object sender, EventArgs e)
        {
            ChangeMainForm(new ClientChiefMedicalForm());
        }
    }
}
