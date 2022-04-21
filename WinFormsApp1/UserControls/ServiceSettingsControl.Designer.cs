namespace CodeCompilerServiceManager.UserControls
{
    partial class ServiceSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownServiceMainInterval = new System.Windows.Forms.NumericUpDown();
            this.labelIntervalService = new System.Windows.Forms.Label();
            this.labelInternalBufferSize = new System.Windows.Forms.Label();
            this.numericUpDownInternalBufferSize = new System.Windows.Forms.NumericUpDown();
            this.textBoxPathToLogs = new System.Windows.Forms.TextBox();
            this.checkBoxLogToFile = new System.Windows.Forms.CheckBox();
            this.checkBoxLogToEventViewer = new System.Windows.Forms.CheckBox();
            this.buttonOpenLogFolder = new System.Windows.Forms.Button();
            this.labelRestartRequired = new System.Windows.Forms.Label();
            this.labelServicePath = new System.Windows.Forms.Label();
            this.textBoxServicePath = new System.Windows.Forms.TextBox();
            this.buttonCancelChanges = new System.Windows.Forms.Button();
            this.buttonSaveAndRestart = new System.Windows.Forms.Button();
            this.buttonSetDefaultServiceSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownServiceMainInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInternalBufferSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownServiceMainInterval
            // 
            this.numericUpDownServiceMainInterval.Location = new System.Drawing.Point(3, 130);
            this.numericUpDownServiceMainInterval.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDownServiceMainInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownServiceMainInterval.Name = "numericUpDownServiceMainInterval";
            this.numericUpDownServiceMainInterval.Size = new System.Drawing.Size(253, 23);
            this.numericUpDownServiceMainInterval.TabIndex = 37;
            this.numericUpDownServiceMainInterval.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownServiceMainInterval.ValueChanged += new System.EventHandler(this.numericUpDownServiceMainInterval_ValueChanged);
            // 
            // labelIntervalService
            // 
            this.labelIntervalService.AutoSize = true;
            this.labelIntervalService.Location = new System.Drawing.Point(3, 112);
            this.labelIntervalService.Name = "labelIntervalService";
            this.labelIntervalService.Size = new System.Drawing.Size(253, 15);
            this.labelIntervalService.TabIndex = 36;
            this.labelIntervalService.Text = "Interwał odświeżania głównej akcji usługi (ms):";
            // 
            // labelInternalBufferSize
            // 
            this.labelInternalBufferSize.AutoSize = true;
            this.labelInternalBufferSize.Location = new System.Drawing.Point(3, 165);
            this.labelInternalBufferSize.Name = "labelInternalBufferSize";
            this.labelInternalBufferSize.Size = new System.Drawing.Size(234, 15);
            this.labelInternalBufferSize.TabIndex = 35;
            this.labelInternalBufferSize.Text = "Rozmiar (w bajtach) buforu wewnętrznego.";
            // 
            // numericUpDownInternalBufferSize
            // 
            this.numericUpDownInternalBufferSize.Location = new System.Drawing.Point(3, 183);
            this.numericUpDownInternalBufferSize.Maximum = new decimal(new int[] {
            -478150656,
            139961312,
            16263,
            0});
            this.numericUpDownInternalBufferSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInternalBufferSize.Name = "numericUpDownInternalBufferSize";
            this.numericUpDownInternalBufferSize.Size = new System.Drawing.Size(253, 23);
            this.numericUpDownInternalBufferSize.TabIndex = 34;
            this.numericUpDownInternalBufferSize.Value = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericUpDownInternalBufferSize.ValueChanged += new System.EventHandler(this.numericUpDownInternalBufferSize_ValueChanged);
            // 
            // textBoxPathToLogs
            // 
            this.textBoxPathToLogs.Location = new System.Drawing.Point(3, 53);
            this.textBoxPathToLogs.Name = "textBoxPathToLogs";
            this.textBoxPathToLogs.Size = new System.Drawing.Size(398, 23);
            this.textBoxPathToLogs.TabIndex = 33;
            this.textBoxPathToLogs.WordWrap = false;
            this.textBoxPathToLogs.TextChanged += new System.EventHandler(this.textBoxPathToLogs_TextChanged);
            // 
            // checkBoxLogToFile
            // 
            this.checkBoxLogToFile.AutoSize = true;
            this.checkBoxLogToFile.Location = new System.Drawing.Point(3, 28);
            this.checkBoxLogToFile.Name = "checkBoxLogToFile";
            this.checkBoxLogToFile.Size = new System.Drawing.Size(133, 19);
            this.checkBoxLogToFile.TabIndex = 32;
            this.checkBoxLogToFile.Text = "Zapisuj logi do pliku";
            this.checkBoxLogToFile.UseVisualStyleBackColor = true;
            this.checkBoxLogToFile.CheckedChanged += new System.EventHandler(this.checkBoxLogToFile_CheckedChanged);
            // 
            // checkBoxLogToEventViewer
            // 
            this.checkBoxLogToEventViewer.AutoSize = true;
            this.checkBoxLogToEventViewer.Location = new System.Drawing.Point(3, 3);
            this.checkBoxLogToEventViewer.Name = "checkBoxLogToEventViewer";
            this.checkBoxLogToEventViewer.Size = new System.Drawing.Size(200, 19);
            this.checkBoxLogToEventViewer.TabIndex = 31;
            this.checkBoxLogToEventViewer.Text = "Zapisuj logi do dziennika zdarzeń";
            this.checkBoxLogToEventViewer.UseVisualStyleBackColor = true;
            this.checkBoxLogToEventViewer.CheckedChanged += new System.EventHandler(this.checkBoxLogToEventViewer_CheckedChanged);
            // 
            // buttonOpenLogFolder
            // 
            this.buttonOpenLogFolder.Location = new System.Drawing.Point(4, 82);
            this.buttonOpenLogFolder.Name = "buttonOpenLogFolder";
            this.buttonOpenLogFolder.Size = new System.Drawing.Size(233, 23);
            this.buttonOpenLogFolder.TabIndex = 30;
            this.buttonOpenLogFolder.Text = "Otwórz folder z logami serwisu";
            this.buttonOpenLogFolder.UseVisualStyleBackColor = true;
            this.buttonOpenLogFolder.Click += new System.EventHandler(this.buttonOpenLogFolder_Click);
            // 
            // labelRestartRequired
            // 
            this.labelRestartRequired.AutoSize = true;
            this.labelRestartRequired.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRestartRequired.ForeColor = System.Drawing.Color.Red;
            this.labelRestartRequired.Location = new System.Drawing.Point(3, 238);
            this.labelRestartRequired.Name = "labelRestartRequired";
            this.labelRestartRequired.Size = new System.Drawing.Size(582, 25);
            this.labelRestartRequired.TabIndex = 38;
            this.labelRestartRequired.Text = "Po zmianie opcji serwisu lub biblioteki wymagany jest restart usługi!";
            // 
            // labelServicePath
            // 
            this.labelServicePath.AutoSize = true;
            this.labelServicePath.Location = new System.Drawing.Point(4, 215);
            this.labelServicePath.Name = "labelServicePath";
            this.labelServicePath.Size = new System.Drawing.Size(83, 15);
            this.labelServicePath.TabIndex = 40;
            this.labelServicePath.Text = "Ścieżka usługi:";
            // 
            // textBoxServicePath
            // 
            this.textBoxServicePath.Location = new System.Drawing.Point(93, 212);
            this.textBoxServicePath.Name = "textBoxServicePath";
            this.textBoxServicePath.ReadOnly = true;
            this.textBoxServicePath.Size = new System.Drawing.Size(489, 23);
            this.textBoxServicePath.TabIndex = 39;
            this.textBoxServicePath.WordWrap = false;
            // 
            // buttonCancelChanges
            // 
            this.buttonCancelChanges.Location = new System.Drawing.Point(275, 111);
            this.buttonCancelChanges.Name = "buttonCancelChanges";
            this.buttonCancelChanges.Size = new System.Drawing.Size(199, 23);
            this.buttonCancelChanges.TabIndex = 42;
            this.buttonCancelChanges.Text = "Anuluj zmiany";
            this.buttonCancelChanges.UseVisualStyleBackColor = true;
            this.buttonCancelChanges.Click += new System.EventHandler(this.buttonCancelChanges_Click);
            // 
            // buttonSaveAndRestart
            // 
            this.buttonSaveAndRestart.Location = new System.Drawing.Point(275, 82);
            this.buttonSaveAndRestart.Name = "buttonSaveAndRestart";
            this.buttonSaveAndRestart.Size = new System.Drawing.Size(199, 23);
            this.buttonSaveAndRestart.TabIndex = 41;
            this.buttonSaveAndRestart.Text = "Zapisz i zrestartuj usługę";
            this.buttonSaveAndRestart.UseVisualStyleBackColor = true;
            this.buttonSaveAndRestart.Click += new System.EventHandler(this.buttonSaveAndRestart_Click);
            // 
            // buttonSetDefaultServiceSettings
            // 
            this.buttonSetDefaultServiceSettings.Location = new System.Drawing.Point(275, 157);
            this.buttonSetDefaultServiceSettings.Name = "buttonSetDefaultServiceSettings";
            this.buttonSetDefaultServiceSettings.Size = new System.Drawing.Size(287, 23);
            this.buttonSetDefaultServiceSettings.TabIndex = 43;
            this.buttonSetDefaultServiceSettings.Text = "Przywróć ustawienia usługi na domyślne";
            this.buttonSetDefaultServiceSettings.UseVisualStyleBackColor = true;
            this.buttonSetDefaultServiceSettings.Click += new System.EventHandler(this.buttonSetDefaultServiceSettings_Click);
            // 
            // ServiceSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSetDefaultServiceSettings);
            this.Controls.Add(this.buttonCancelChanges);
            this.Controls.Add(this.buttonSaveAndRestart);
            this.Controls.Add(this.labelServicePath);
            this.Controls.Add(this.textBoxServicePath);
            this.Controls.Add(this.labelRestartRequired);
            this.Controls.Add(this.numericUpDownServiceMainInterval);
            this.Controls.Add(this.labelIntervalService);
            this.Controls.Add(this.labelInternalBufferSize);
            this.Controls.Add(this.numericUpDownInternalBufferSize);
            this.Controls.Add(this.textBoxPathToLogs);
            this.Controls.Add(this.checkBoxLogToFile);
            this.Controls.Add(this.checkBoxLogToEventViewer);
            this.Controls.Add(this.buttonOpenLogFolder);
            this.Name = "ServiceSettingsControl";
            this.Size = new System.Drawing.Size(600, 300);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownServiceMainInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInternalBufferSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown numericUpDownServiceMainInterval;
        private Label labelIntervalService;
        private Label labelInternalBufferSize;
        private NumericUpDown numericUpDownInternalBufferSize;
        private TextBox textBoxPathToLogs;
        private CheckBox checkBoxLogToFile;
        private CheckBox checkBoxLogToEventViewer;
        private Button buttonOpenLogFolder;
        private Label labelRestartRequired;
        private Label labelServicePath;
        private TextBox textBoxServicePath;
        private Button buttonCancelChanges;
        private Button buttonSaveAndRestart;
        private Button buttonSetDefaultServiceSettings;
    }
}
