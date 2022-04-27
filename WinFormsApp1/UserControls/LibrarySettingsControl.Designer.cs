namespace CodeCompilerServiceManager.UserControls
{
    partial class LibrarySettingsControl
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
            this.components = new System.ComponentModel.Container();
            this.labelInputPath = new MaterialSkin.Controls.MaterialLabel();
            this.labelIOutputPath = new MaterialSkin.Controls.MaterialLabel();
            this.materialRadioButtonMakeDll = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButtonMakeExe = new MaterialSkin.Controls.MaterialRadioButton();
            this.labelRestartRequired = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxInputPath = new MaterialSkin.Controls.MaterialTextBox2();
            this.textBoxOutputPath = new MaterialSkin.Controls.MaterialTextBox2();
            this.buttonSaveAndRestart = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancelChanges = new MaterialSkin.Controls.MaterialButton();
            this.buttonSetDefaultServiceSettings = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonChooseInputFolder = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonChooseOutputFolder = new MaterialSkin.Controls.MaterialButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelInputPath
            // 
            this.labelInputPath.AutoSize = true;
            this.labelInputPath.Depth = 0;
            this.labelInputPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelInputPath.Location = new System.Drawing.Point(13, 13);
            this.labelInputPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelInputPath.Name = "labelInputPath";
            this.labelInputPath.Size = new System.Drawing.Size(271, 19);
            this.labelInputPath.TabIndex = 44;
            this.labelInputPath.Text = "Folder wejściowy plików do kompilacji";
            // 
            // labelIOutputPath
            // 
            this.labelIOutputPath.AutoSize = true;
            this.labelIOutputPath.Depth = 0;
            this.labelIOutputPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelIOutputPath.Location = new System.Drawing.Point(13, 107);
            this.labelIOutputPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelIOutputPath.Name = "labelIOutputPath";
            this.labelIOutputPath.Size = new System.Drawing.Size(292, 19);
            this.labelIOutputPath.TabIndex = 45;
            this.labelIOutputPath.Text = "Folder wyściowy skompilowanych plików";
            // 
            // materialRadioButtonMakeDll
            // 
            this.materialRadioButtonMakeDll.AutoSize = true;
            this.materialRadioButtonMakeDll.Depth = 0;
            this.materialRadioButtonMakeDll.Location = new System.Drawing.Point(13, 192);
            this.materialRadioButtonMakeDll.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButtonMakeDll.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButtonMakeDll.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButtonMakeDll.Name = "materialRadioButtonMakeDll";
            this.materialRadioButtonMakeDll.Ripple = true;
            this.materialRadioButtonMakeDll.Size = new System.Drawing.Size(224, 37);
            this.materialRadioButtonMakeDll.TabIndex = 48;
            this.materialRadioButtonMakeDll.TabStop = true;
            this.materialRadioButtonMakeDll.Text = "Kompiluj do biblioteki (.dll)";
            this.materialRadioButtonMakeDll.UseVisualStyleBackColor = true;
            this.materialRadioButtonMakeDll.CheckedChanged += new System.EventHandler(this.materialRadioButtonMakeDll_CheckedChanged);
            // 
            // materialRadioButtonMakeExe
            // 
            this.materialRadioButtonMakeExe.AutoSize = true;
            this.materialRadioButtonMakeExe.Depth = 0;
            this.materialRadioButtonMakeExe.Location = new System.Drawing.Point(13, 229);
            this.materialRadioButtonMakeExe.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButtonMakeExe.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButtonMakeExe.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButtonMakeExe.Name = "materialRadioButtonMakeExe";
            this.materialRadioButtonMakeExe.Ripple = true;
            this.materialRadioButtonMakeExe.Size = new System.Drawing.Size(310, 37);
            this.materialRadioButtonMakeExe.TabIndex = 49;
            this.materialRadioButtonMakeExe.TabStop = true;
            this.materialRadioButtonMakeExe.Text = "Kompiluj do aplikacji konsolowej (.exe)";
            this.materialRadioButtonMakeExe.UseVisualStyleBackColor = true;
            this.materialRadioButtonMakeExe.CheckedChanged += new System.EventHandler(this.materialRadioButtonMakeExe_CheckedChanged);
            // 
            // labelRestartRequired
            // 
            this.labelRestartRequired.AutoSize = true;
            this.labelRestartRequired.Depth = 0;
            this.labelRestartRequired.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelRestartRequired.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.labelRestartRequired.ForeColor = System.Drawing.Color.Black;
            this.labelRestartRequired.HighEmphasis = true;
            this.labelRestartRequired.Location = new System.Drawing.Point(18, 280);
            this.labelRestartRequired.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelRestartRequired.Name = "labelRestartRequired";
            this.labelRestartRequired.Size = new System.Drawing.Size(738, 29);
            this.labelRestartRequired.TabIndex = 50;
            this.labelRestartRequired.Text = "Po zmianie opcji biblioteki kompilującej wymagany jest restart usługi!";
            this.labelRestartRequired.UseAccent = true;
            // 
            // textBoxInputPath
            // 
            this.textBoxInputPath.AnimateReadOnly = false;
            this.textBoxInputPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxInputPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxInputPath.Depth = 0;
            this.textBoxInputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxInputPath.HideSelection = true;
            this.textBoxInputPath.LeadingIcon = null;
            this.textBoxInputPath.Location = new System.Drawing.Point(13, 35);
            this.textBoxInputPath.MaxLength = 32767;
            this.textBoxInputPath.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxInputPath.Name = "textBoxInputPath";
            this.textBoxInputPath.PasswordChar = '\0';
            this.textBoxInputPath.PrefixSuffixText = null;
            this.textBoxInputPath.ReadOnly = false;
            this.textBoxInputPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxInputPath.SelectedText = "";
            this.textBoxInputPath.SelectionLength = 0;
            this.textBoxInputPath.SelectionStart = 0;
            this.textBoxInputPath.ShortcutsEnabled = true;
            this.textBoxInputPath.Size = new System.Drawing.Size(728, 48);
            this.textBoxInputPath.TabIndex = 52;
            this.textBoxInputPath.TabStop = false;
            this.textBoxInputPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxInputPath.TrailingIcon = null;
            this.textBoxInputPath.UseSystemPasswordChar = false;
            this.textBoxInputPath.Enter += new System.EventHandler(this.textBoxInputPath_Enter);
            this.textBoxInputPath.TextChanged += new System.EventHandler(this.textBoxInputPath_TextChanged);
            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.AnimateReadOnly = false;
            this.textBoxOutputPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxOutputPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxOutputPath.Depth = 0;
            this.textBoxOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxOutputPath.HideSelection = true;
            this.textBoxOutputPath.LeadingIcon = null;
            this.textBoxOutputPath.Location = new System.Drawing.Point(13, 136);
            this.textBoxOutputPath.MaxLength = 32767;
            this.textBoxOutputPath.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.PasswordChar = '\0';
            this.textBoxOutputPath.PrefixSuffixText = null;
            this.textBoxOutputPath.ReadOnly = false;
            this.textBoxOutputPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxOutputPath.SelectedText = "";
            this.textBoxOutputPath.SelectionLength = 0;
            this.textBoxOutputPath.SelectionStart = 0;
            this.textBoxOutputPath.ShortcutsEnabled = true;
            this.textBoxOutputPath.Size = new System.Drawing.Size(728, 48);
            this.textBoxOutputPath.TabIndex = 53;
            this.textBoxOutputPath.TabStop = false;
            this.textBoxOutputPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxOutputPath.TrailingIcon = null;
            this.textBoxOutputPath.UseSystemPasswordChar = false;
            this.textBoxOutputPath.Enter += new System.EventHandler(this.textBoxOutputPath_Enter);
            this.textBoxOutputPath.TextChanged += new System.EventHandler(this.textBoxOutputPath_TextChanged);
            // 
            // buttonSaveAndRestart
            // 
            this.buttonSaveAndRestart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSaveAndRestart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSaveAndRestart.Depth = 0;
            this.buttonSaveAndRestart.HighEmphasis = true;
            this.buttonSaveAndRestart.Icon = global::CodeCompilerServiceManager.Properties.Resources.content_save;
            this.buttonSaveAndRestart.Location = new System.Drawing.Point(18, 327);
            this.buttonSaveAndRestart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSaveAndRestart.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSaveAndRestart.Name = "buttonSaveAndRestart";
            this.buttonSaveAndRestart.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSaveAndRestart.Size = new System.Drawing.Size(259, 36);
            this.buttonSaveAndRestart.TabIndex = 54;
            this.buttonSaveAndRestart.Text = "Zapisz i zrestartuj usługę";
            this.buttonSaveAndRestart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSaveAndRestart.UseAccentColor = false;
            this.buttonSaveAndRestart.UseVisualStyleBackColor = true;
            this.buttonSaveAndRestart.Click += new System.EventHandler(this.buttonSaveAndRestart_Click);
            // 
            // buttonCancelChanges
            // 
            this.buttonCancelChanges.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancelChanges.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonCancelChanges.Depth = 0;
            this.buttonCancelChanges.HighEmphasis = true;
            this.buttonCancelChanges.Icon = global::CodeCompilerServiceManager.Properties.Resources.cancel;
            this.buttonCancelChanges.Location = new System.Drawing.Point(285, 327);
            this.buttonCancelChanges.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCancelChanges.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCancelChanges.Name = "buttonCancelChanges";
            this.buttonCancelChanges.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonCancelChanges.Size = new System.Drawing.Size(164, 36);
            this.buttonCancelChanges.TabIndex = 55;
            this.buttonCancelChanges.Text = "Anuluj zmiany";
            this.buttonCancelChanges.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonCancelChanges.UseAccentColor = false;
            this.buttonCancelChanges.UseVisualStyleBackColor = true;
            this.buttonCancelChanges.Click += new System.EventHandler(this.buttonCancelChanges_Click);
            // 
            // buttonSetDefaultServiceSettings
            // 
            this.buttonSetDefaultServiceSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetDefaultServiceSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSetDefaultServiceSettings.Depth = 0;
            this.buttonSetDefaultServiceSettings.HighEmphasis = true;
            this.buttonSetDefaultServiceSettings.Icon = global::CodeCompilerServiceManager.Properties.Resources.refresh;
            this.buttonSetDefaultServiceSettings.Location = new System.Drawing.Point(457, 327);
            this.buttonSetDefaultServiceSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSetDefaultServiceSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSetDefaultServiceSettings.Name = "buttonSetDefaultServiceSettings";
            this.buttonSetDefaultServiceSettings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSetDefaultServiceSettings.Size = new System.Drawing.Size(403, 36);
            this.buttonSetDefaultServiceSettings.TabIndex = 56;
            this.buttonSetDefaultServiceSettings.Text = "Przywróć ustawienia biblioteki na domyślne";
            this.buttonSetDefaultServiceSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSetDefaultServiceSettings.UseAccentColor = false;
            this.buttonSetDefaultServiceSettings.UseVisualStyleBackColor = true;
            this.buttonSetDefaultServiceSettings.Click += new System.EventHandler(this.buttonSetDefaultServiceSettings_Click);
            // 
            // materialButtonChooseInputFolder
            // 
            this.materialButtonChooseInputFolder.AutoSize = false;
            this.materialButtonChooseInputFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonChooseInputFolder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonChooseInputFolder.Depth = 0;
            this.materialButtonChooseInputFolder.HighEmphasis = true;
            this.materialButtonChooseInputFolder.Icon = global::CodeCompilerServiceManager.Properties.Resources.folder_edit;
            this.materialButtonChooseInputFolder.Location = new System.Drawing.Point(759, 47);
            this.materialButtonChooseInputFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonChooseInputFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonChooseInputFolder.Name = "materialButtonChooseInputFolder";
            this.materialButtonChooseInputFolder.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonChooseInputFolder.Size = new System.Drawing.Size(41, 36);
            this.materialButtonChooseInputFolder.TabIndex = 57;
            this.toolTip1.SetToolTip(this.materialButtonChooseInputFolder, "Wybierz folder");
            this.materialButtonChooseInputFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonChooseInputFolder.UseAccentColor = true;
            this.materialButtonChooseInputFolder.UseVisualStyleBackColor = true;
            this.materialButtonChooseInputFolder.Click += new System.EventHandler(this.materialButtonChooseInputFolder_Click);
            // 
            // materialButtonChooseOutputFolder
            // 
            this.materialButtonChooseOutputFolder.AutoSize = false;
            this.materialButtonChooseOutputFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonChooseOutputFolder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonChooseOutputFolder.Depth = 0;
            this.materialButtonChooseOutputFolder.HighEmphasis = true;
            this.materialButtonChooseOutputFolder.Icon = global::CodeCompilerServiceManager.Properties.Resources.folder_edit;
            this.materialButtonChooseOutputFolder.Location = new System.Drawing.Point(759, 148);
            this.materialButtonChooseOutputFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonChooseOutputFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonChooseOutputFolder.Name = "materialButtonChooseOutputFolder";
            this.materialButtonChooseOutputFolder.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonChooseOutputFolder.Size = new System.Drawing.Size(41, 36);
            this.materialButtonChooseOutputFolder.TabIndex = 58;
            this.toolTip1.SetToolTip(this.materialButtonChooseOutputFolder, "Wybierz folder");
            this.materialButtonChooseOutputFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonChooseOutputFolder.UseAccentColor = true;
            this.materialButtonChooseOutputFolder.UseVisualStyleBackColor = true;
            this.materialButtonChooseOutputFolder.Click += new System.EventHandler(this.materialButtonChooseOutputFolder_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.WindowText;
            this.toolTip1.ForeColor = System.Drawing.Color.White;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_draw);
            // 
            // LibrarySettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialButtonChooseOutputFolder);
            this.Controls.Add(this.materialButtonChooseInputFolder);
            this.Controls.Add(this.buttonSetDefaultServiceSettings);
            this.Controls.Add(this.buttonCancelChanges);
            this.Controls.Add(this.buttonSaveAndRestart);
            this.Controls.Add(this.textBoxOutputPath);
            this.Controls.Add(this.textBoxInputPath);
            this.Controls.Add(this.labelRestartRequired);
            this.Controls.Add(this.materialRadioButtonMakeExe);
            this.Controls.Add(this.materialRadioButtonMakeDll);
            this.Controls.Add(this.labelIOutputPath);
            this.Controls.Add(this.labelInputPath);
            this.Name = "LibrarySettingsControl";
            this.Size = new System.Drawing.Size(866, 618);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel labelInputPath;
        private MaterialSkin.Controls.MaterialLabel labelIOutputPath;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButtonMakeDll;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButtonMakeExe;
        private MaterialSkin.Controls.MaterialLabel labelRestartRequired;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxInputPath;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxOutputPath;
        private MaterialSkin.Controls.MaterialButton buttonSaveAndRestart;
        private MaterialSkin.Controls.MaterialButton buttonCancelChanges;
        private MaterialSkin.Controls.MaterialButton buttonSetDefaultServiceSettings;
        private MaterialSkin.Controls.MaterialButton materialButtonChooseInputFolder;
        private MaterialSkin.Controls.MaterialButton materialButtonChooseOutputFolder;
        private ToolTip toolTip1;
    }
}
