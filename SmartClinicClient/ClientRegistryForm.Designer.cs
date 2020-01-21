namespace SmartClinicClient
{
    partial class ClientRegistryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.patronymicTextBox = new System.Windows.Forms.TextBox();
            this.addPatientButton = new System.Windows.Forms.Button();
            this.patientListBox = new System.Windows.Forms.ListBox();
            this.getPatientListButton = new System.Windows.Forms.Button();
            this.patientSearchTextBox = new System.Windows.Forms.TextBox();
            this.scheduleSearchTextBox = new System.Windows.Forms.TextBox();
            this.getScheduleButton = new System.Windows.Forms.Button();
            this.addAssignmentButton = new System.Windows.Forms.Button();
            this.scheduleListBox = new System.Windows.Forms.ListBox();
            this.ticketListBox = new System.Windows.Forms.ListBox();
            this.getTicketListButton = new System.Windows.Forms.Button();
            this.removeTicketButton = new System.Windows.Forms.Button();
            this.clearPatientInfoButton = new System.Windows.Forms.Button();
            this.passportLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.patronymicLabel = new System.Windows.Forms.Label();
            this.birthdateLabel = new System.Windows.Forms.Label();
            this.passportTextBox = new System.Windows.Forms.TextBox();
            this.ticketToWindowButton = new System.Windows.Forms.Button();
            this.ticketToQueueButton = new System.Windows.Forms.Button();
            this.windowNumberTextBox = new System.Windows.Forms.TextBox();
            this.birthdateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.windowNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(386, 330);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(256, 22);
            this.lastNameTextBox.TabIndex = 15;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(386, 363);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(256, 22);
            this.firstNameTextBox.TabIndex = 16;
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.Location = new System.Drawing.Point(386, 396);
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.Size = new System.Drawing.Size(256, 22);
            this.patronymicTextBox.TabIndex = 17;
            // 
            // addPatientButton
            // 
            this.addPatientButton.Location = new System.Drawing.Point(649, 330);
            this.addPatientButton.Name = "addPatientButton";
            this.addPatientButton.Size = new System.Drawing.Size(190, 190);
            this.addPatientButton.TabIndex = 19;
            this.addPatientButton.Text = "Добавить пациента";
            this.addPatientButton.UseVisualStyleBackColor = true;
            this.addPatientButton.Click += new System.EventHandler(this.OnClickAddPatientButton);
            // 
            // patientListBox
            // 
            this.patientListBox.FormattingEnabled = true;
            this.patientListBox.ItemHeight = 16;
            this.patientListBox.Location = new System.Drawing.Point(272, 45);
            this.patientListBox.Name = "patientListBox";
            this.patientListBox.Size = new System.Drawing.Size(567, 276);
            this.patientListBox.TabIndex = 20;
            // 
            // getPatientListButton
            // 
            this.getPatientListButton.Location = new System.Drawing.Point(709, 12);
            this.getPatientListButton.Name = "getPatientListButton";
            this.getPatientListButton.Size = new System.Drawing.Size(130, 27);
            this.getPatientListButton.TabIndex = 21;
            this.getPatientListButton.Text = "Найти пациента";
            this.getPatientListButton.UseVisualStyleBackColor = true;
            this.getPatientListButton.Click += new System.EventHandler(this.OnClickGetPatientListButton);
            // 
            // patientSearchTextBox
            // 
            this.patientSearchTextBox.Location = new System.Drawing.Point(272, 14);
            this.patientSearchTextBox.Name = "patientSearchTextBox";
            this.patientSearchTextBox.Size = new System.Drawing.Size(431, 22);
            this.patientSearchTextBox.TabIndex = 22;
            // 
            // scheduleSearchTextBox
            // 
            this.scheduleSearchTextBox.Location = new System.Drawing.Point(855, 14);
            this.scheduleSearchTextBox.Name = "scheduleSearchTextBox";
            this.scheduleSearchTextBox.Size = new System.Drawing.Size(207, 22);
            this.scheduleSearchTextBox.TabIndex = 23;
            // 
            // getScheduleButton
            // 
            this.getScheduleButton.Location = new System.Drawing.Point(1068, 12);
            this.getScheduleButton.Name = "getScheduleButton";
            this.getScheduleButton.Size = new System.Drawing.Size(122, 27);
            this.getScheduleButton.TabIndex = 24;
            this.getScheduleButton.Text = "Найти записи";
            this.getScheduleButton.UseVisualStyleBackColor = true;
            this.getScheduleButton.Click += new System.EventHandler(this.OnClickGetScheduleButton);
            // 
            // addAssignmentButton
            // 
            this.addAssignmentButton.Location = new System.Drawing.Point(855, 399);
            this.addAssignmentButton.Name = "addAssignmentButton";
            this.addAssignmentButton.Size = new System.Drawing.Size(335, 121);
            this.addAssignmentButton.TabIndex = 25;
            this.addAssignmentButton.Text = "Записать";
            this.addAssignmentButton.UseVisualStyleBackColor = true;
            this.addAssignmentButton.Click += new System.EventHandler(this.OnClickAddAssignmentButton);
            // 
            // scheduleListBox
            // 
            this.scheduleListBox.FormattingEnabled = true;
            this.scheduleListBox.ItemHeight = 16;
            this.scheduleListBox.Location = new System.Drawing.Point(855, 45);
            this.scheduleListBox.Name = "scheduleListBox";
            this.scheduleListBox.Size = new System.Drawing.Size(335, 340);
            this.scheduleListBox.TabIndex = 26;
            // 
            // ticketListBox
            // 
            this.ticketListBox.FormattingEnabled = true;
            this.ticketListBox.ItemHeight = 16;
            this.ticketListBox.Location = new System.Drawing.Point(12, 45);
            this.ticketListBox.Name = "ticketListBox";
            this.ticketListBox.Size = new System.Drawing.Size(245, 340);
            this.ticketListBox.TabIndex = 27;
            // 
            // getTicketListButton
            // 
            this.getTicketListButton.Location = new System.Drawing.Point(12, 12);
            this.getTicketListButton.Name = "getTicketListButton";
            this.getTicketListButton.Size = new System.Drawing.Size(245, 27);
            this.getTicketListButton.TabIndex = 28;
            this.getTicketListButton.Text = "Обновить список талонов";
            this.getTicketListButton.UseVisualStyleBackColor = true;
            this.getTicketListButton.Click += new System.EventHandler(this.OnClickGetTicketListButton);
            // 
            // removeTicketButton
            // 
            this.removeTicketButton.Location = new System.Drawing.Point(12, 493);
            this.removeTicketButton.Name = "removeTicketButton";
            this.removeTicketButton.Size = new System.Drawing.Size(245, 27);
            this.removeTicketButton.TabIndex = 29;
            this.removeTicketButton.Text = "Удалить талон";
            this.removeTicketButton.UseVisualStyleBackColor = true;
            this.removeTicketButton.Click += new System.EventHandler(this.OnClickRemoveTicketButton);
            // 
            // clearPatientInfoButton
            // 
            this.clearPatientInfoButton.Location = new System.Drawing.Point(272, 493);
            this.clearPatientInfoButton.Name = "clearPatientInfoButton";
            this.clearPatientInfoButton.Size = new System.Drawing.Size(370, 27);
            this.clearPatientInfoButton.TabIndex = 30;
            this.clearPatientInfoButton.Text = "Очистить информацию о клиенте";
            this.clearPatientInfoButton.UseVisualStyleBackColor = true;
            this.clearPatientInfoButton.Click += new System.EventHandler(this.OnClickСlearPatientInfoButton);
            // 
            // passportLabel
            // 
            this.passportLabel.AutoSize = true;
            this.passportLabel.Location = new System.Drawing.Point(269, 432);
            this.passportLabel.Name = "passportLabel";
            this.passportLabel.Size = new System.Drawing.Size(68, 17);
            this.passportLabel.TabIndex = 32;
            this.passportLabel.Text = "Паспорт:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(269, 333);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(74, 17);
            this.lastNameLabel.TabIndex = 33;
            this.lastNameLabel.Text = "Фамилия:";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(269, 366);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(39, 17);
            this.firstNameLabel.TabIndex = 34;
            this.firstNameLabel.Text = "Имя:";
            // 
            // patronymicLabel
            // 
            this.patronymicLabel.AutoSize = true;
            this.patronymicLabel.Location = new System.Drawing.Point(269, 399);
            this.patronymicLabel.Name = "patronymicLabel";
            this.patronymicLabel.Size = new System.Drawing.Size(75, 17);
            this.patronymicLabel.TabIndex = 35;
            this.patronymicLabel.Text = "Отчество:";
            // 
            // birthdateLabel
            // 
            this.birthdateLabel.AutoSize = true;
            this.birthdateLabel.Location = new System.Drawing.Point(269, 465);
            this.birthdateLabel.Name = "birthdateLabel";
            this.birthdateLabel.Size = new System.Drawing.Size(115, 17);
            this.birthdateLabel.TabIndex = 36;
            this.birthdateLabel.Text = "Дата рождения:";
            // 
            // passportTextBox
            // 
            this.passportTextBox.Location = new System.Drawing.Point(386, 429);
            this.passportTextBox.Name = "passportTextBox";
            this.passportTextBox.Size = new System.Drawing.Size(256, 22);
            this.passportTextBox.TabIndex = 37;
            // 
            // ticketToWindowButton
            // 
            this.ticketToWindowButton.Location = new System.Drawing.Point(12, 427);
            this.ticketToWindowButton.Name = "ticketToWindowButton";
            this.ticketToWindowButton.Size = new System.Drawing.Size(245, 27);
            this.ticketToWindowButton.TabIndex = 38;
            this.ticketToWindowButton.Text = "Подозвать талон";
            this.ticketToWindowButton.UseVisualStyleBackColor = true;
            this.ticketToWindowButton.Click += new System.EventHandler(this.OnClickTicketToWindowButton);
            // 
            // ticketToQueueButton
            // 
            this.ticketToQueueButton.Location = new System.Drawing.Point(12, 460);
            this.ticketToQueueButton.Name = "ticketToQueueButton";
            this.ticketToQueueButton.Size = new System.Drawing.Size(245, 27);
            this.ticketToQueueButton.TabIndex = 39;
            this.ticketToQueueButton.Text = "Отозвать талон";
            this.ticketToQueueButton.UseVisualStyleBackColor = true;
            this.ticketToQueueButton.Click += new System.EventHandler(this.OnClickTicketToQueueButton);
            // 
            // windowNumberTextBox
            // 
            this.windowNumberTextBox.Location = new System.Drawing.Point(108, 396);
            this.windowNumberTextBox.Name = "windowNumberTextBox";
            this.windowNumberTextBox.Size = new System.Drawing.Size(149, 22);
            this.windowNumberTextBox.TabIndex = 40;
            // 
            // birthdateMaskedTextBox
            // 
            this.birthdateMaskedTextBox.Location = new System.Drawing.Point(386, 462);
            this.birthdateMaskedTextBox.Mask = "0000-00-00";
            this.birthdateMaskedTextBox.Name = "birthdateMaskedTextBox";
            this.birthdateMaskedTextBox.Size = new System.Drawing.Size(256, 22);
            this.birthdateMaskedTextBox.TabIndex = 41;
            // 
            // windowNumberLabel
            // 
            this.windowNumberLabel.AutoSize = true;
            this.windowNumberLabel.Location = new System.Drawing.Point(12, 399);
            this.windowNumberLabel.Name = "windowNumberLabel";
            this.windowNumberLabel.Size = new System.Drawing.Size(90, 17);
            this.windowNumberLabel.TabIndex = 42;
            this.windowNumberLabel.Text = "Номер окна:";
            // 
            // ClientRegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 530);
            this.Controls.Add(this.windowNumberLabel);
            this.Controls.Add(this.birthdateMaskedTextBox);
            this.Controls.Add(this.windowNumberTextBox);
            this.Controls.Add(this.ticketToQueueButton);
            this.Controls.Add(this.ticketToWindowButton);
            this.Controls.Add(this.ticketListBox);
            this.Controls.Add(this.removeTicketButton);
            this.Controls.Add(this.getTicketListButton);
            this.Controls.Add(this.passportTextBox);
            this.Controls.Add(this.birthdateLabel);
            this.Controls.Add(this.patronymicLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.passportLabel);
            this.Controls.Add(this.clearPatientInfoButton);
            this.Controls.Add(this.scheduleListBox);
            this.Controls.Add(this.addAssignmentButton);
            this.Controls.Add(this.getScheduleButton);
            this.Controls.Add(this.scheduleSearchTextBox);
            this.Controls.Add(this.patientSearchTextBox);
            this.Controls.Add(this.getPatientListButton);
            this.Controls.Add(this.patientListBox);
            this.Controls.Add(this.addPatientButton);
            this.Controls.Add(this.patronymicTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ClientRegistryForm";
            this.Text = "ClientRegistryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.Button addPatientButton;
        private System.Windows.Forms.ListBox patientListBox;
        private System.Windows.Forms.Button getPatientListButton;
        private System.Windows.Forms.TextBox patientSearchTextBox;
        private System.Windows.Forms.TextBox scheduleSearchTextBox;
        private System.Windows.Forms.Button getScheduleButton;
        private System.Windows.Forms.Button addAssignmentButton;
        private System.Windows.Forms.ListBox scheduleListBox;
        private System.Windows.Forms.ListBox ticketListBox;
        private System.Windows.Forms.Button getTicketListButton;
        private System.Windows.Forms.Button removeTicketButton;
        private System.Windows.Forms.Button clearPatientInfoButton;
        private System.Windows.Forms.Label passportLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label patronymicLabel;
        private System.Windows.Forms.Label birthdateLabel;
        private System.Windows.Forms.TextBox passportTextBox;
        private System.Windows.Forms.Button ticketToWindowButton;
        private System.Windows.Forms.Button ticketToQueueButton;
        private System.Windows.Forms.TextBox windowNumberTextBox;
        private System.Windows.Forms.MaskedTextBox birthdateMaskedTextBox;
        private System.Windows.Forms.Label windowNumberLabel;
    }
}