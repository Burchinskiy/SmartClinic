namespace SmartClinicClient
{
    partial class ClientChoiceForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.clientChoiceLabel = new System.Windows.Forms.Label();
            this.clientTerminalButton = new System.Windows.Forms.Button();
            this.clientRegistryButton = new System.Windows.Forms.Button();
            this.clientChiefMedicalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientChoiceLabel
            // 
            this.clientChoiceLabel.AutoSize = true;
            this.clientChoiceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientChoiceLabel.Location = new System.Drawing.Point(92, 68);
            this.clientChoiceLabel.Name = "clientChoiceLabel";
            this.clientChoiceLabel.Size = new System.Drawing.Size(448, 32);
            this.clientChoiceLabel.TabIndex = 0;
            this.clientChoiceLabel.Text = "Выберите необходимый модуль:";
            // 
            // clientTerminalButton
            // 
            this.clientTerminalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientTerminalButton.Location = new System.Drawing.Point(63, 144);
            this.clientTerminalButton.Name = "clientTerminalButton";
            this.clientTerminalButton.Size = new System.Drawing.Size(500, 60);
            this.clientTerminalButton.TabIndex = 1;
            this.clientTerminalButton.Text = "Терминал";
            this.clientTerminalButton.UseVisualStyleBackColor = true;
            this.clientTerminalButton.Click += new System.EventHandler(this.OnClickClientTerminalButton);
            // 
            // clientRegistryButton
            // 
            this.clientRegistryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientRegistryButton.Location = new System.Drawing.Point(63, 210);
            this.clientRegistryButton.Name = "clientRegistryButton";
            this.clientRegistryButton.Size = new System.Drawing.Size(500, 60);
            this.clientRegistryButton.TabIndex = 2;
            this.clientRegistryButton.Text = "Регистратура";
            this.clientRegistryButton.UseVisualStyleBackColor = true;
            this.clientRegistryButton.Click += new System.EventHandler(this.OnClickClientRegistryButton);
            // 
            // clientChiefMedicalButton
            // 
            this.clientChiefMedicalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientChiefMedicalButton.Location = new System.Drawing.Point(63, 276);
            this.clientChiefMedicalButton.Name = "clientChiefMedicalButton";
            this.clientChiefMedicalButton.Size = new System.Drawing.Size(500, 60);
            this.clientChiefMedicalButton.TabIndex = 3;
            this.clientChiefMedicalButton.Text = "Главный врач";
            this.clientChiefMedicalButton.UseVisualStyleBackColor = true;
            this.clientChiefMedicalButton.Click += new System.EventHandler(this.OnClickClientChiefMedicalButton);
            // 
            // ClientChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 433);
            this.Controls.Add(this.clientChiefMedicalButton);
            this.Controls.Add(this.clientRegistryButton);
            this.Controls.Add(this.clientTerminalButton);
            this.Controls.Add(this.clientChoiceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ClientChoiceForm";
            this.Text = "Выбор модуля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientChoiceLabel;
        private System.Windows.Forms.Button clientTerminalButton;
        private System.Windows.Forms.Button clientRegistryButton;
        private System.Windows.Forms.Button clientChiefMedicalButton;
    }
}

