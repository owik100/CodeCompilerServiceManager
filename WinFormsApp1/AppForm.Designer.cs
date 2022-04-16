namespace CodeCompilerServiceManager
{
    partial class AppForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnReStartService = new System.Windows.Forms.Button();
            this.labelServiceStatus = new System.Windows.Forms.Label();
            this.pictureServiceStatus = new System.Windows.Forms.PictureBox();
            this.numericOperationTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelOperationTimeout = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownIntervalRefresh = new System.Windows.Forms.NumericUpDown();
            this.txtOutputConsole = new System.Windows.Forms.RichTextBox();
            this.btnSaveManagerSettings = new System.Windows.Forms.Button();
            this.btnResetManagerSettings = new System.Windows.Forms.Button();
            this.btnClearManagerConsole = new System.Windows.Forms.Button();
            this.checkBoxRefreshEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOperationTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(87, 78);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(174, 23);
            this.btnStartService.TabIndex = 0;
            this.btnStartService.Text = "Uruchom usługę";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(87, 107);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(175, 23);
            this.btnStopService.TabIndex = 1;
            this.btnStopService.Text = "Zatrzymaj usługę";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnReStartService
            // 
            this.btnReStartService.Location = new System.Drawing.Point(87, 136);
            this.btnReStartService.Name = "btnReStartService";
            this.btnReStartService.Size = new System.Drawing.Size(175, 23);
            this.btnReStartService.TabIndex = 2;
            this.btnReStartService.Text = "Uruchom ponowne usługę";
            this.btnReStartService.UseVisualStyleBackColor = true;
            this.btnReStartService.Click += new System.EventHandler(this.btnReStartService_Click);
            // 
            // labelServiceStatus
            // 
            this.labelServiceStatus.AutoSize = true;
            this.labelServiceStatus.Location = new System.Drawing.Point(87, 50);
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(68, 15);
            this.labelServiceStatus.TabIndex = 3;
            this.labelServiceStatus.Text = "Stan usługi:";
            // 
            // pictureServiceStatus
            // 
            this.pictureServiceStatus.Image = global::CodeCompilerServiceManager.Properties.Resources.yellow;
            this.pictureServiceStatus.Location = new System.Drawing.Point(87, 12);
            this.pictureServiceStatus.Name = "pictureServiceStatus";
            this.pictureServiceStatus.Size = new System.Drawing.Size(68, 35);
            this.pictureServiceStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureServiceStatus.TabIndex = 4;
            this.pictureServiceStatus.TabStop = false;
            // 
            // numericOperationTimeout
            // 
            this.numericOperationTimeout.Location = new System.Drawing.Point(96, 260);
            this.numericOperationTimeout.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numericOperationTimeout.Name = "numericOperationTimeout";
            this.numericOperationTimeout.Size = new System.Drawing.Size(70, 23);
            this.numericOperationTimeout.TabIndex = 6;
            this.numericOperationTimeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericOperationTimeout.ValueChanged += new System.EventHandler(this.numericOperationTimeout_ValueChanged);
            // 
            // labelOperationTimeout
            // 
            this.labelOperationTimeout.AutoSize = true;
            this.labelOperationTimeout.Location = new System.Drawing.Point(96, 242);
            this.labelOperationTimeout.Name = "labelOperationTimeout";
            this.labelOperationTimeout.Size = new System.Drawing.Size(233, 15);
            this.labelOperationTimeout.TabIndex = 7;
            this.labelOperationTimeout.Text = "Timeout wykonanej akcji na usłudze (ms):  ";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(96, 193);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(213, 15);
            this.labelInterval.TabIndex = 8;
            this.labelInterval.Text = "Interwał odświeżania stanu usługi (ms):";
            // 
            // numericUpDownIntervalRefresh
            // 
            this.numericUpDownIntervalRefresh.Location = new System.Drawing.Point(96, 211);
            this.numericUpDownIntervalRefresh.Maximum = new decimal(new int[] {
            180000,
            0,
            0,
            0});
            this.numericUpDownIntervalRefresh.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownIntervalRefresh.Name = "numericUpDownIntervalRefresh";
            this.numericUpDownIntervalRefresh.Size = new System.Drawing.Size(70, 23);
            this.numericUpDownIntervalRefresh.TabIndex = 9;
            this.numericUpDownIntervalRefresh.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownIntervalRefresh.ValueChanged += new System.EventHandler(this.numericUpDownIntervalRefresh_ValueChanged);
            // 
            // txtOutputConsole
            // 
            this.txtOutputConsole.Location = new System.Drawing.Point(96, 306);
            this.txtOutputConsole.Name = "txtOutputConsole";
            this.txtOutputConsole.ReadOnly = true;
            this.txtOutputConsole.Size = new System.Drawing.Size(648, 96);
            this.txtOutputConsole.TabIndex = 10;
            this.txtOutputConsole.Text = "";
            // 
            // btnSaveManagerSettings
            // 
            this.btnSaveManagerSettings.Location = new System.Drawing.Point(364, 209);
            this.btnSaveManagerSettings.Name = "btnSaveManagerSettings";
            this.btnSaveManagerSettings.Size = new System.Drawing.Size(108, 23);
            this.btnSaveManagerSettings.TabIndex = 11;
            this.btnSaveManagerSettings.Text = "Zapisz ustawienia";
            this.btnSaveManagerSettings.UseVisualStyleBackColor = true;
            this.btnSaveManagerSettings.Click += new System.EventHandler(this.btnSaveManagerSettings_Click);
            // 
            // btnResetManagerSettings
            // 
            this.btnResetManagerSettings.Location = new System.Drawing.Point(364, 242);
            this.btnResetManagerSettings.Name = "btnResetManagerSettings";
            this.btnResetManagerSettings.Size = new System.Drawing.Size(108, 23);
            this.btnResetManagerSettings.TabIndex = 12;
            this.btnResetManagerSettings.Text = "Restart ustawień";
            this.btnResetManagerSettings.UseVisualStyleBackColor = true;
            this.btnResetManagerSettings.Click += new System.EventHandler(this.btnResetManagerSettings_Click);
            // 
            // btnClearManagerConsole
            // 
            this.btnClearManagerConsole.Location = new System.Drawing.Point(96, 415);
            this.btnClearManagerConsole.Name = "btnClearManagerConsole";
            this.btnClearManagerConsole.Size = new System.Drawing.Size(117, 23);
            this.btnClearManagerConsole.TabIndex = 13;
            this.btnClearManagerConsole.Text = "Wyczyść konsole";
            this.btnClearManagerConsole.UseVisualStyleBackColor = true;
            this.btnClearManagerConsole.Click += new System.EventHandler(this.btnClearManagerConsole_Click);
            // 
            // checkBoxRefreshEnabled
            // 
            this.checkBoxRefreshEnabled.AutoSize = true;
            this.checkBoxRefreshEnabled.Checked = true;
            this.checkBoxRefreshEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefreshEnabled.Location = new System.Drawing.Point(95, 168);
            this.checkBoxRefreshEnabled.Name = "checkBoxRefreshEnabled";
            this.checkBoxRefreshEnabled.Size = new System.Drawing.Size(139, 19);
            this.checkBoxRefreshEnabled.TabIndex = 14;
            this.checkBoxRefreshEnabled.Text = "Odświeżaj stan usługi";
            this.checkBoxRefreshEnabled.UseVisualStyleBackColor = true;
            this.checkBoxRefreshEnabled.CheckedChanged += new System.EventHandler(this.checkBoxRefreshEnabled_CheckedChanged);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxRefreshEnabled);
            this.Controls.Add(this.btnClearManagerConsole);
            this.Controls.Add(this.btnResetManagerSettings);
            this.Controls.Add(this.btnSaveManagerSettings);
            this.Controls.Add(this.txtOutputConsole);
            this.Controls.Add(this.numericUpDownIntervalRefresh);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelOperationTimeout);
            this.Controls.Add(this.numericOperationTimeout);
            this.Controls.Add(this.pictureServiceStatus);
            this.Controls.Add(this.labelServiceStatus);
            this.Controls.Add(this.btnReStartService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Name = "AppForm";
            this.Text = "Code Compiler Service Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOperationTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartService;
        private Button btnStopService;
        private Button btnReStartService;
        private Label labelServiceStatus;
        private PictureBox pictureServiceStatus;
        private NumericUpDown numericOperationTimeout;
        private Label labelOperationTimeout;
        private Label labelInterval;
        private NumericUpDown numericUpDownIntervalRefresh;
        private RichTextBox txtOutputConsole;
        private Button btnSaveManagerSettings;
        private Button btnResetManagerSettings;
        private Button btnClearManagerConsole;
        private CheckBox checkBoxRefreshEnabled;
    }
}