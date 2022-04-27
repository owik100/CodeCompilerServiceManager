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
            this.checkBoxRefreshEnabled = new MaterialSkin.Controls.MaterialCheckbox();
            this.labelInterval = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxIntervalRefresh = new MaterialSkin.Controls.MaterialTextBox2();
            this.textBoxOperationTimeout = new MaterialSkin.Controls.MaterialTextBox2();
            this.labelOperationTimeout = new MaterialSkin.Controls.MaterialLabel();
            this.btnSaveManagerSettings = new MaterialSkin.Controls.MaterialButton();
            this.btnResetManagerSettings = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // checkBoxRefreshEnabled
            // 
            this.checkBoxRefreshEnabled.AutoSize = true;
            this.checkBoxRefreshEnabled.Checked = true;
            this.checkBoxRefreshEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefreshEnabled.Depth = 0;
            this.checkBoxRefreshEnabled.Location = new System.Drawing.Point(35, 22);
            this.checkBoxRefreshEnabled.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxRefreshEnabled.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxRefreshEnabled.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxRefreshEnabled.Name = "checkBoxRefreshEnabled";
            this.checkBoxRefreshEnabled.ReadOnly = false;
            this.checkBoxRefreshEnabled.Ripple = true;
            this.checkBoxRefreshEnabled.Size = new System.Drawing.Size(299, 37);
            this.checkBoxRefreshEnabled.TabIndex = 22;
            this.checkBoxRefreshEnabled.Text = "Odświeżaj stan usługi automatycznie";
            this.checkBoxRefreshEnabled.UseVisualStyleBackColor = true;
            this.checkBoxRefreshEnabled.CheckedChanged += new System.EventHandler(this.checkBoxRefreshEnabled_CheckedChanged);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Depth = 0;
            this.labelInterval.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelInterval.Location = new System.Drawing.Point(39, 68);
            this.labelInterval.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(282, 19);
            this.labelInterval.TabIndex = 23;
            this.labelInterval.Text = "Interwał odświeżania stanu usługi (ms):";
            // 
            // textBoxIntervalRefresh
            // 
            this.textBoxIntervalRefresh.AnimateReadOnly = false;
            this.textBoxIntervalRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxIntervalRefresh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxIntervalRefresh.Depth = 0;
            this.textBoxIntervalRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxIntervalRefresh.HideSelection = true;
            this.textBoxIntervalRefresh.LeadingIcon = null;
            this.textBoxIntervalRefresh.Location = new System.Drawing.Point(39, 100);
            this.textBoxIntervalRefresh.MaxLength = 50;
            this.textBoxIntervalRefresh.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxIntervalRefresh.Name = "textBoxIntervalRefresh";
            this.textBoxIntervalRefresh.PasswordChar = '\0';
            this.textBoxIntervalRefresh.PrefixSuffixText = null;
            this.textBoxIntervalRefresh.ReadOnly = false;
            this.textBoxIntervalRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxIntervalRefresh.SelectedText = "";
            this.textBoxIntervalRefresh.SelectionLength = 0;
            this.textBoxIntervalRefresh.SelectionStart = 0;
            this.textBoxIntervalRefresh.ShortcutsEnabled = true;
            this.textBoxIntervalRefresh.Size = new System.Drawing.Size(295, 48);
            this.textBoxIntervalRefresh.TabIndex = 24;
            this.textBoxIntervalRefresh.TabStop = false;
            this.textBoxIntervalRefresh.Text = "3000";
            this.textBoxIntervalRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxIntervalRefresh.TrailingIcon = null;
            this.textBoxIntervalRefresh.UseSystemPasswordChar = false;
            this.textBoxIntervalRefresh.Enter += new System.EventHandler(this.textBoxIntervalRefresh_Enter);
            this.textBoxIntervalRefresh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIntervalRefresh_KeyPress);
            this.textBoxIntervalRefresh.Leave += new System.EventHandler(this.textBoxIntervalRefresh_Leave);
            this.textBoxIntervalRefresh.TextChanged += new System.EventHandler(this.textBoxIntervalRefresh_TextChanged);
            // 
            // textBoxOperationTimeout
            // 
            this.textBoxOperationTimeout.AnimateReadOnly = false;
            this.textBoxOperationTimeout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxOperationTimeout.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxOperationTimeout.Depth = 0;
            this.textBoxOperationTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxOperationTimeout.HideSelection = true;
            this.textBoxOperationTimeout.LeadingIcon = null;
            this.textBoxOperationTimeout.Location = new System.Drawing.Point(39, 216);
            this.textBoxOperationTimeout.MaxLength = 50;
            this.textBoxOperationTimeout.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxOperationTimeout.Name = "textBoxOperationTimeout";
            this.textBoxOperationTimeout.PasswordChar = '\0';
            this.textBoxOperationTimeout.PrefixSuffixText = null;
            this.textBoxOperationTimeout.ReadOnly = false;
            this.textBoxOperationTimeout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxOperationTimeout.SelectedText = "";
            this.textBoxOperationTimeout.SelectionLength = 0;
            this.textBoxOperationTimeout.SelectionStart = 0;
            this.textBoxOperationTimeout.ShortcutsEnabled = true;
            this.textBoxOperationTimeout.Size = new System.Drawing.Size(295, 48);
            this.textBoxOperationTimeout.TabIndex = 25;
            this.textBoxOperationTimeout.TabStop = false;
            this.textBoxOperationTimeout.Text = "5001";
            this.textBoxOperationTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxOperationTimeout.TrailingIcon = null;
            this.textBoxOperationTimeout.UseSystemPasswordChar = false;
            this.textBoxOperationTimeout.Enter += new System.EventHandler(this.textBoxOperationTimeout_Enter);
            this.textBoxOperationTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOperationTimeout_KeyPress);
            this.textBoxOperationTimeout.Leave += new System.EventHandler(this.textBoxOperationTimeout_Leave);
            // 
            // labelOperationTimeout
            // 
            this.labelOperationTimeout.AutoSize = true;
            this.labelOperationTimeout.Depth = 0;
            this.labelOperationTimeout.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelOperationTimeout.Location = new System.Drawing.Point(39, 182);
            this.labelOperationTimeout.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelOperationTimeout.Name = "labelOperationTimeout";
            this.labelOperationTimeout.Size = new System.Drawing.Size(307, 19);
            this.labelOperationTimeout.TabIndex = 26;
            this.labelOperationTimeout.Text = "Timeout wykonanej akcji na usłudze (ms):  ";
            // 
            // btnSaveManagerSettings
            // 
            this.btnSaveManagerSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveManagerSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveManagerSettings.Depth = 0;
            this.btnSaveManagerSettings.Enabled = false;
            this.btnSaveManagerSettings.HighEmphasis = true;
            this.btnSaveManagerSettings.Icon = global::CodeCompilerServiceManager.Properties.Resources.content_save;
            this.btnSaveManagerSettings.Location = new System.Drawing.Point(39, 288);
            this.btnSaveManagerSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveManagerSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveManagerSettings.Name = "btnSaveManagerSettings";
            this.btnSaveManagerSettings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveManagerSettings.Size = new System.Drawing.Size(190, 36);
            this.btnSaveManagerSettings.TabIndex = 27;
            this.btnSaveManagerSettings.Text = "Zapisz ustawienia";
            this.btnSaveManagerSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveManagerSettings.UseAccentColor = false;
            this.btnSaveManagerSettings.UseVisualStyleBackColor = true;
            this.btnSaveManagerSettings.Click += new System.EventHandler(this.btnSaveManagerSettings_Click);
            // 
            // btnResetManagerSettings
            // 
            this.btnResetManagerSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResetManagerSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnResetManagerSettings.Depth = 0;
            this.btnResetManagerSettings.HighEmphasis = true;
            this.btnResetManagerSettings.Icon = global::CodeCompilerServiceManager.Properties.Resources.refresh;
            this.btnResetManagerSettings.Location = new System.Drawing.Point(39, 341);
            this.btnResetManagerSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnResetManagerSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnResetManagerSettings.Name = "btnResetManagerSettings";
            this.btnResetManagerSettings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnResetManagerSettings.Size = new System.Drawing.Size(300, 36);
            this.btnResetManagerSettings.TabIndex = 28;
            this.btnResetManagerSettings.Text = "Przywróć ustawienia domyślne";
            this.btnResetManagerSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnResetManagerSettings.UseAccentColor = false;
            this.btnResetManagerSettings.UseVisualStyleBackColor = true;
            this.btnResetManagerSettings.TextChanged += new System.EventHandler(this.btnResetManagerSettings_TextChanged);
            this.btnResetManagerSettings.Click += new System.EventHandler(this.btnResetManagerSettings_Click);
            // 
            // ManagerSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnResetManagerSettings);
            this.Controls.Add(this.btnSaveManagerSettings);
            this.Controls.Add(this.labelOperationTimeout);
            this.Controls.Add(this.textBoxOperationTimeout);
            this.Controls.Add(this.textBoxIntervalRefresh);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.checkBoxRefreshEnabled);
            this.Name = "ManagerSettingsControl";
            this.Size = new System.Drawing.Size(866, 618);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialCheckbox checkBoxRefreshEnabled;
        private MaterialSkin.Controls.MaterialLabel labelInterval;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxIntervalRefresh;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxOperationTimeout;
        private MaterialSkin.Controls.MaterialLabel labelOperationTimeout;
        private MaterialSkin.Controls.MaterialButton btnSaveManagerSettings;
        private MaterialSkin.Controls.MaterialButton btnResetManagerSettings;
    }
}
