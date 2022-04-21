namespace CodeCompilerServiceManager.UserControls
{
    partial class ManagerSettingsControl
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
            this.checkBoxRefreshEnabled = new System.Windows.Forms.CheckBox();
            this.numericUpDownIntervalRefresh = new System.Windows.Forms.NumericUpDown();
            this.labelInterval = new System.Windows.Forms.Label();
            this.labelOperationTimeout = new System.Windows.Forms.Label();
            this.numericOperationTimeout = new System.Windows.Forms.NumericUpDown();
            this.btnResetManagerSettings = new System.Windows.Forms.Button();
            this.btnSaveManagerSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOperationTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxRefreshEnabled
            // 
            this.checkBoxRefreshEnabled.AutoSize = true;
            this.checkBoxRefreshEnabled.Checked = true;
            this.checkBoxRefreshEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefreshEnabled.Location = new System.Drawing.Point(21, 19);
            this.checkBoxRefreshEnabled.Name = "checkBoxRefreshEnabled";
            this.checkBoxRefreshEnabled.Size = new System.Drawing.Size(220, 19);
            this.checkBoxRefreshEnabled.TabIndex = 19;
            this.checkBoxRefreshEnabled.Text = "Odświeżaj stan usługi automatycznie";
            this.checkBoxRefreshEnabled.UseVisualStyleBackColor = true;
            // 
            // numericUpDownIntervalRefresh
            // 
            this.numericUpDownIntervalRefresh.Location = new System.Drawing.Point(21, 59);
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
            this.numericUpDownIntervalRefresh.TabIndex = 18;
            this.numericUpDownIntervalRefresh.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownIntervalRefresh.ValueChanged += new System.EventHandler(this.numericUpDownIntervalRefresh_ValueChanged);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(20, 41);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(213, 15);
            this.labelInterval.TabIndex = 17;
            this.labelInterval.Text = "Interwał odświeżania stanu usługi (ms):";
            // 
            // labelOperationTimeout
            // 
            this.labelOperationTimeout.AutoSize = true;
            this.labelOperationTimeout.Location = new System.Drawing.Point(21, 90);
            this.labelOperationTimeout.Name = "labelOperationTimeout";
            this.labelOperationTimeout.Size = new System.Drawing.Size(233, 15);
            this.labelOperationTimeout.TabIndex = 16;
            this.labelOperationTimeout.Text = "Timeout wykonanej akcji na usłudze (ms):  ";
            // 
            // numericOperationTimeout
            // 
            this.numericOperationTimeout.Location = new System.Drawing.Point(21, 108);
            this.numericOperationTimeout.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numericOperationTimeout.Name = "numericOperationTimeout";
            this.numericOperationTimeout.Size = new System.Drawing.Size(70, 23);
            this.numericOperationTimeout.TabIndex = 15;
            this.numericOperationTimeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericOperationTimeout.ValueChanged += new System.EventHandler(this.numericOperationTimeout_ValueChanged);
            // 
            // btnResetManagerSettings
            // 
            this.btnResetManagerSettings.Location = new System.Drawing.Point(21, 170);
            this.btnResetManagerSettings.Name = "btnResetManagerSettings";
            this.btnResetManagerSettings.Size = new System.Drawing.Size(108, 23);
            this.btnResetManagerSettings.TabIndex = 21;
            this.btnResetManagerSettings.Text = "Restart ustawień";
            this.btnResetManagerSettings.UseVisualStyleBackColor = true;
            this.btnResetManagerSettings.Click += new System.EventHandler(this.btnResetManagerSettings_Click);
            // 
            // btnSaveManagerSettings
            // 
            this.btnSaveManagerSettings.Location = new System.Drawing.Point(21, 137);
            this.btnSaveManagerSettings.Name = "btnSaveManagerSettings";
            this.btnSaveManagerSettings.Size = new System.Drawing.Size(108, 23);
            this.btnSaveManagerSettings.TabIndex = 20;
            this.btnSaveManagerSettings.Text = "Zapisz ustawienia";
            this.btnSaveManagerSettings.UseVisualStyleBackColor = true;
            this.btnSaveManagerSettings.Click += new System.EventHandler(this.btnSaveManagerSettings_Click);
            // 
            // ManagerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnResetManagerSettings);
            this.Controls.Add(this.btnSaveManagerSettings);
            this.Controls.Add(this.checkBoxRefreshEnabled);
            this.Controls.Add(this.numericUpDownIntervalRefresh);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelOperationTimeout);
            this.Controls.Add(this.numericOperationTimeout);
            this.Name = "ManagerSettings";
            this.Size = new System.Drawing.Size(600, 300);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOperationTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBoxRefreshEnabled;
        private NumericUpDown numericUpDownIntervalRefresh;
        private Label labelInterval;
        private Label labelOperationTimeout;
        private NumericUpDown numericOperationTimeout;
        private Button btnResetManagerSettings;
        private Button btnSaveManagerSettings;
    }
}
