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
            this.components = new System.ComponentModel.Container();
            this.labelRestartRequired = new MaterialSkin.Controls.MaterialLabel();
            this.labelServicePath = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxServicePath = new MaterialSkin.Controls.MaterialTextBox2();
            this.buttonOpenServicePath = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.panelFooterServicePath = new System.Windows.Forms.Panel();
            this.buttonDeleteService = new MaterialSkin.Controls.MaterialButton();
            this.buttonInstallService = new MaterialSkin.Controls.MaterialButton();
            this.checkBoxLogToEventViewer = new MaterialSkin.Controls.MaterialCheckbox();
            this.checkBoxLogToFile = new MaterialSkin.Controls.MaterialCheckbox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonOpenLogFolder = new MaterialSkin.Controls.MaterialButton();
            this.textBoxPathToLogs = new MaterialSkin.Controls.MaterialTextBox2();
            this.labelIntervalService = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxServiceMainInterval = new MaterialSkin.Controls.MaterialTextBox2();
            this.labelInternalBufferSize = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxInternalBufferSize = new MaterialSkin.Controls.MaterialTextBox2();
            this.buttonSaveAndRestart = new MaterialSkin.Controls.MaterialButton();
            this.buttonSetDefaultServiceSettings = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancelChanges = new MaterialSkin.Controls.MaterialButton();
            this.checkBoxSendMessagesToManager = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialTextBoxPortForManagerSendMessages = new MaterialSkin.Controls.MaterialTextBox2();
            this.labelPortForSendManager = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonFindFreePort = new MaterialSkin.Controls.MaterialButton();
            this.panelFooterServicePath.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRestartRequired
            // 
            this.labelRestartRequired.AutoSize = true;
            this.labelRestartRequired.Depth = 0;
            this.labelRestartRequired.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelRestartRequired.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.labelRestartRequired.ForeColor = System.Drawing.Color.Black;
            this.labelRestartRequired.HighEmphasis = true;
            this.labelRestartRequired.Location = new System.Drawing.Point(120, 420);
            this.labelRestartRequired.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelRestartRequired.Name = "labelRestartRequired";
            this.labelRestartRequired.Size = new System.Drawing.Size(587, 29);
            this.labelRestartRequired.TabIndex = 51;
            this.labelRestartRequired.Text = "Po zmianie opcji  serwisu wymagany jest restart usługi!";
            this.labelRestartRequired.UseAccent = true;
            // 
            // labelServicePath
            // 
            this.labelServicePath.AutoSize = true;
            this.labelServicePath.Depth = 0;
            this.labelServicePath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelServicePath.Location = new System.Drawing.Point(7, 27);
            this.labelServicePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelServicePath.Name = "labelServicePath";
            this.labelServicePath.Size = new System.Drawing.Size(107, 19);
            this.labelServicePath.TabIndex = 52;
            this.labelServicePath.Text = "Ścieżka usługi:";
            // 
            // textBoxServicePath
            // 
            this.textBoxServicePath.AnimateReadOnly = false;
            this.textBoxServicePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxServicePath.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxServicePath.Depth = 0;
            this.textBoxServicePath.Enabled = false;
            this.textBoxServicePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxServicePath.HideSelection = true;
            this.textBoxServicePath.LeadingIcon = null;
            this.textBoxServicePath.Location = new System.Drawing.Point(120, 17);
            this.textBoxServicePath.MaxLength = 32767;
            this.textBoxServicePath.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxServicePath.Name = "textBoxServicePath";
            this.textBoxServicePath.PasswordChar = '\0';
            this.textBoxServicePath.PrefixSuffixText = null;
            this.textBoxServicePath.ReadOnly = true;
            this.textBoxServicePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxServicePath.SelectedText = "";
            this.textBoxServicePath.SelectionLength = 0;
            this.textBoxServicePath.SelectionStart = 0;
            this.textBoxServicePath.ShortcutsEnabled = true;
            this.textBoxServicePath.Size = new System.Drawing.Size(694, 36);
            this.textBoxServicePath.TabIndex = 53;
            this.textBoxServicePath.TabStop = false;
            this.textBoxServicePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxServicePath.TrailingIcon = null;
            this.textBoxServicePath.UseSystemPasswordChar = false;
            this.textBoxServicePath.UseTallSize = false;
            // 
            // buttonOpenServicePath
            // 
            this.buttonOpenServicePath.AutoSize = false;
            this.buttonOpenServicePath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenServicePath.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonOpenServicePath.Depth = 0;
            this.buttonOpenServicePath.HighEmphasis = true;
            this.buttonOpenServicePath.Icon = global::CodeCompilerServiceManager.Properties.Resources.folder_open;
            this.buttonOpenServicePath.Location = new System.Drawing.Point(821, 17);
            this.buttonOpenServicePath.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonOpenServicePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOpenServicePath.Name = "buttonOpenServicePath";
            this.buttonOpenServicePath.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonOpenServicePath.Size = new System.Drawing.Size(41, 36);
            this.buttonOpenServicePath.TabIndex = 54;
            this.toolTip1.SetToolTip(this.buttonOpenServicePath, "Otwórz folder zawierający usługę");
            this.buttonOpenServicePath.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonOpenServicePath.UseAccentColor = true;
            this.buttonOpenServicePath.UseVisualStyleBackColor = true;
            this.buttonOpenServicePath.Click += new System.EventHandler(this.buttonOpenServicePath_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(-36, 9);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65535, 2);
            this.materialLabel1.TabIndex = 55;
            // 
            // panelFooterServicePath
            // 
            this.panelFooterServicePath.Controls.Add(this.buttonDeleteService);
            this.panelFooterServicePath.Controls.Add(this.buttonOpenServicePath);
            this.panelFooterServicePath.Controls.Add(this.buttonInstallService);
            this.panelFooterServicePath.Controls.Add(this.materialLabel1);
            this.panelFooterServicePath.Controls.Add(this.textBoxServicePath);
            this.panelFooterServicePath.Controls.Add(this.labelServicePath);
            this.panelFooterServicePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooterServicePath.Location = new System.Drawing.Point(0, 500);
            this.panelFooterServicePath.Name = "panelFooterServicePath";
            this.panelFooterServicePath.Size = new System.Drawing.Size(866, 118);
            this.panelFooterServicePath.TabIndex = 56;
            // 
            // buttonDeleteService
            // 
            this.buttonDeleteService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDeleteService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonDeleteService.Depth = 0;
            this.buttonDeleteService.HighEmphasis = true;
            this.buttonDeleteService.Icon = global::CodeCompilerServiceManager.Properties.Resources.cog_off;
            this.buttonDeleteService.Location = new System.Drawing.Point(458, 62);
            this.buttonDeleteService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonDeleteService.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonDeleteService.Name = "buttonDeleteService";
            this.buttonDeleteService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonDeleteService.Size = new System.Drawing.Size(146, 36);
            this.buttonDeleteService.TabIndex = 68;
            this.buttonDeleteService.Text = "Usuń usługę";
            this.buttonDeleteService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonDeleteService.UseAccentColor = false;
            this.buttonDeleteService.UseVisualStyleBackColor = true;
            this.buttonDeleteService.Click += new System.EventHandler(this.buttonDeleteService_Click);
            // 
            // buttonInstallService
            // 
            this.buttonInstallService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonInstallService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonInstallService.Depth = 0;
            this.buttonInstallService.HighEmphasis = true;
            this.buttonInstallService.Icon = global::CodeCompilerServiceManager.Properties.Resources.content_save_cog;
            this.buttonInstallService.Location = new System.Drawing.Point(244, 62);
            this.buttonInstallService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonInstallService.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonInstallService.Name = "buttonInstallService";
            this.buttonInstallService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonInstallService.Size = new System.Drawing.Size(194, 36);
            this.buttonInstallService.TabIndex = 67;
            this.buttonInstallService.Text = "Zainstaluj usługę";
            this.buttonInstallService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonInstallService.UseAccentColor = false;
            this.buttonInstallService.UseVisualStyleBackColor = true;
            this.buttonInstallService.Click += new System.EventHandler(this.buttonInstallService_Click);
            // 
            // checkBoxLogToEventViewer
            // 
            this.checkBoxLogToEventViewer.AutoSize = true;
            this.checkBoxLogToEventViewer.Depth = 0;
            this.checkBoxLogToEventViewer.Location = new System.Drawing.Point(7, 10);
            this.checkBoxLogToEventViewer.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxLogToEventViewer.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxLogToEventViewer.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxLogToEventViewer.Name = "checkBoxLogToEventViewer";
            this.checkBoxLogToEventViewer.ReadOnly = false;
            this.checkBoxLogToEventViewer.Ripple = true;
            this.checkBoxLogToEventViewer.Size = new System.Drawing.Size(272, 37);
            this.checkBoxLogToEventViewer.TabIndex = 57;
            this.checkBoxLogToEventViewer.Text = "Zapisuj logi do dziennika zdarzeń";
            this.checkBoxLogToEventViewer.UseVisualStyleBackColor = true;
            this.checkBoxLogToEventViewer.CheckedChanged += new System.EventHandler(this.checkBoxLogToEventViewer_CheckedChanged);
            // 
            // checkBoxLogToFile
            // 
            this.checkBoxLogToFile.AutoSize = true;
            this.checkBoxLogToFile.Depth = 0;
            this.checkBoxLogToFile.Location = new System.Drawing.Point(7, 47);
            this.checkBoxLogToFile.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxLogToFile.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxLogToFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxLogToFile.Name = "checkBoxLogToFile";
            this.checkBoxLogToFile.ReadOnly = false;
            this.checkBoxLogToFile.Ripple = true;
            this.checkBoxLogToFile.Size = new System.Drawing.Size(178, 37);
            this.checkBoxLogToFile.TabIndex = 58;
            this.checkBoxLogToFile.Text = "Zapisuj logi do pliku";
            this.checkBoxLogToFile.UseVisualStyleBackColor = true;
            this.checkBoxLogToFile.CheckedChanged += new System.EventHandler(this.checkBoxLogToFile_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.Color.White;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_draw);
            // 
            // buttonOpenLogFolder
            // 
            this.buttonOpenLogFolder.AutoSize = false;
            this.buttonOpenLogFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenLogFolder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonOpenLogFolder.Depth = 0;
            this.buttonOpenLogFolder.HighEmphasis = true;
            this.buttonOpenLogFolder.Icon = global::CodeCompilerServiceManager.Properties.Resources.folder_open;
            this.buttonOpenLogFolder.Location = new System.Drawing.Point(777, 98);
            this.buttonOpenLogFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonOpenLogFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOpenLogFolder.Name = "buttonOpenLogFolder";
            this.buttonOpenLogFolder.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonOpenLogFolder.Size = new System.Drawing.Size(44, 37);
            this.buttonOpenLogFolder.TabIndex = 56;
            this.toolTip1.SetToolTip(this.buttonOpenLogFolder, "Otwórz folder z logami serwisu");
            this.buttonOpenLogFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonOpenLogFolder.UseAccentColor = true;
            this.buttonOpenLogFolder.UseVisualStyleBackColor = true;
            this.buttonOpenLogFolder.Click += new System.EventHandler(this.buttonOpenLogFolder_Click);
            // 
            // textBoxPathToLogs
            // 
            this.textBoxPathToLogs.AnimateReadOnly = false;
            this.textBoxPathToLogs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxPathToLogs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxPathToLogs.Depth = 0;
            this.textBoxPathToLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPathToLogs.HideSelection = true;
            this.textBoxPathToLogs.LeadingIcon = null;
            this.textBoxPathToLogs.Location = new System.Drawing.Point(7, 87);
            this.textBoxPathToLogs.MaxLength = 32767;
            this.textBoxPathToLogs.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPathToLogs.Name = "textBoxPathToLogs";
            this.textBoxPathToLogs.PasswordChar = '\0';
            this.textBoxPathToLogs.PrefixSuffixText = null;
            this.textBoxPathToLogs.ReadOnly = false;
            this.textBoxPathToLogs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPathToLogs.SelectedText = "";
            this.textBoxPathToLogs.SelectionLength = 0;
            this.textBoxPathToLogs.SelectionStart = 0;
            this.textBoxPathToLogs.ShortcutsEnabled = true;
            this.textBoxPathToLogs.Size = new System.Drawing.Size(763, 48);
            this.textBoxPathToLogs.TabIndex = 59;
            this.textBoxPathToLogs.TabStop = false;
            this.textBoxPathToLogs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPathToLogs.TrailingIcon = null;
            this.textBoxPathToLogs.UseSystemPasswordChar = false;
            this.textBoxPathToLogs.Enter += new System.EventHandler(this.textBoxPathToLogs_Enter);
            this.textBoxPathToLogs.TextChanged += new System.EventHandler(this.textBoxPathToLogs_TextChanged);
            // 
            // labelIntervalService
            // 
            this.labelIntervalService.AutoSize = true;
            this.labelIntervalService.Depth = 0;
            this.labelIntervalService.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelIntervalService.Location = new System.Drawing.Point(494, 284);
            this.labelIntervalService.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelIntervalService.Name = "labelIntervalService";
            this.labelIntervalService.Size = new System.Drawing.Size(334, 19);
            this.labelIntervalService.TabIndex = 60;
            this.labelIntervalService.Text = "Interwał odświeżania głównej akcji usługi (ms):";
            // 
            // textBoxServiceMainInterval
            // 
            this.textBoxServiceMainInterval.AnimateReadOnly = false;
            this.textBoxServiceMainInterval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxServiceMainInterval.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxServiceMainInterval.Depth = 0;
            this.textBoxServiceMainInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxServiceMainInterval.HideSelection = true;
            this.textBoxServiceMainInterval.LeadingIcon = null;
            this.textBoxServiceMainInterval.Location = new System.Drawing.Point(578, 317);
            this.textBoxServiceMainInterval.MaxLength = 32767;
            this.textBoxServiceMainInterval.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxServiceMainInterval.Name = "textBoxServiceMainInterval";
            this.textBoxServiceMainInterval.PasswordChar = '\0';
            this.textBoxServiceMainInterval.PrefixSuffixText = null;
            this.textBoxServiceMainInterval.ReadOnly = false;
            this.textBoxServiceMainInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxServiceMainInterval.SelectedText = "";
            this.textBoxServiceMainInterval.SelectionLength = 0;
            this.textBoxServiceMainInterval.SelectionStart = 0;
            this.textBoxServiceMainInterval.ShortcutsEnabled = true;
            this.textBoxServiceMainInterval.Size = new System.Drawing.Size(250, 48);
            this.textBoxServiceMainInterval.TabIndex = 61;
            this.textBoxServiceMainInterval.TabStop = false;
            this.textBoxServiceMainInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxServiceMainInterval.TrailingIcon = null;
            this.textBoxServiceMainInterval.UseSystemPasswordChar = false;
            this.textBoxServiceMainInterval.Enter += new System.EventHandler(this.textBoxServiceMainInterval_Enter);
            this.textBoxServiceMainInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxServiceMainInterval_KeyPress);
            this.textBoxServiceMainInterval.Leave += new System.EventHandler(this.textBoxServiceMainInterval_Leave);
            this.textBoxServiceMainInterval.TextChanged += new System.EventHandler(this.textBoxServiceMainInterval_TextChanged);
            // 
            // labelInternalBufferSize
            // 
            this.labelInternalBufferSize.AutoSize = true;
            this.labelInternalBufferSize.Depth = 0;
            this.labelInternalBufferSize.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelInternalBufferSize.Location = new System.Drawing.Point(7, 284);
            this.labelInternalBufferSize.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelInternalBufferSize.Name = "labelInternalBufferSize";
            this.labelInternalBufferSize.Size = new System.Drawing.Size(305, 19);
            this.labelInternalBufferSize.TabIndex = 62;
            this.labelInternalBufferSize.Text = "Rozmiar (w bajtach) buforu wewnętrznego.";
            // 
            // textBoxInternalBufferSize
            // 
            this.textBoxInternalBufferSize.AnimateReadOnly = false;
            this.textBoxInternalBufferSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxInternalBufferSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxInternalBufferSize.Depth = 0;
            this.textBoxInternalBufferSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxInternalBufferSize.HideSelection = true;
            this.textBoxInternalBufferSize.LeadingIcon = null;
            this.textBoxInternalBufferSize.Location = new System.Drawing.Point(7, 317);
            this.textBoxInternalBufferSize.MaxLength = 32767;
            this.textBoxInternalBufferSize.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxInternalBufferSize.Name = "textBoxInternalBufferSize";
            this.textBoxInternalBufferSize.PasswordChar = '\0';
            this.textBoxInternalBufferSize.PrefixSuffixText = null;
            this.textBoxInternalBufferSize.ReadOnly = false;
            this.textBoxInternalBufferSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxInternalBufferSize.SelectedText = "";
            this.textBoxInternalBufferSize.SelectionLength = 0;
            this.textBoxInternalBufferSize.SelectionStart = 0;
            this.textBoxInternalBufferSize.ShortcutsEnabled = true;
            this.textBoxInternalBufferSize.Size = new System.Drawing.Size(250, 48);
            this.textBoxInternalBufferSize.TabIndex = 63;
            this.textBoxInternalBufferSize.TabStop = false;
            this.textBoxInternalBufferSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxInternalBufferSize.TrailingIcon = null;
            this.textBoxInternalBufferSize.UseSystemPasswordChar = false;
            this.textBoxInternalBufferSize.Enter += new System.EventHandler(this.textBoxInternalBufferSize_Enter);
            this.textBoxInternalBufferSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInternalBufferSize_KeyPress);
            this.textBoxInternalBufferSize.Leave += new System.EventHandler(this.textBoxInternalBufferSize_Leave);
            this.textBoxInternalBufferSize.TextChanged += new System.EventHandler(this.textBoxInternalBufferSize_TextChanged);
            // 
            // buttonSaveAndRestart
            // 
            this.buttonSaveAndRestart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSaveAndRestart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSaveAndRestart.Depth = 0;
            this.buttonSaveAndRestart.HighEmphasis = true;
            this.buttonSaveAndRestart.Icon = global::CodeCompilerServiceManager.Properties.Resources.content_save;
            this.buttonSaveAndRestart.Location = new System.Drawing.Point(7, 455);
            this.buttonSaveAndRestart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSaveAndRestart.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSaveAndRestart.Name = "buttonSaveAndRestart";
            this.buttonSaveAndRestart.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSaveAndRestart.Size = new System.Drawing.Size(259, 36);
            this.buttonSaveAndRestart.TabIndex = 64;
            this.buttonSaveAndRestart.Text = "Zapisz i zrestartuj usługę";
            this.buttonSaveAndRestart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSaveAndRestart.UseAccentColor = false;
            this.buttonSaveAndRestart.UseVisualStyleBackColor = true;
            this.buttonSaveAndRestart.Click += new System.EventHandler(this.buttonSaveAndRestart_Click);
            // 
            // buttonSetDefaultServiceSettings
            // 
            this.buttonSetDefaultServiceSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetDefaultServiceSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSetDefaultServiceSettings.Depth = 0;
            this.buttonSetDefaultServiceSettings.HighEmphasis = true;
            this.buttonSetDefaultServiceSettings.Icon = global::CodeCompilerServiceManager.Properties.Resources.refresh;
            this.buttonSetDefaultServiceSettings.Location = new System.Drawing.Point(450, 455);
            this.buttonSetDefaultServiceSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSetDefaultServiceSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSetDefaultServiceSettings.Name = "buttonSetDefaultServiceSettings";
            this.buttonSetDefaultServiceSettings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSetDefaultServiceSettings.Size = new System.Drawing.Size(378, 36);
            this.buttonSetDefaultServiceSettings.TabIndex = 65;
            this.buttonSetDefaultServiceSettings.Text = "Przywróć ustawienia usługi na domyślne";
            this.buttonSetDefaultServiceSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSetDefaultServiceSettings.UseAccentColor = false;
            this.buttonSetDefaultServiceSettings.UseVisualStyleBackColor = true;
            this.buttonSetDefaultServiceSettings.Click += new System.EventHandler(this.buttonSetDefaultServiceSettings_Click);
            // 
            // buttonCancelChanges
            // 
            this.buttonCancelChanges.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancelChanges.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonCancelChanges.Depth = 0;
            this.buttonCancelChanges.HighEmphasis = true;
            this.buttonCancelChanges.Icon = global::CodeCompilerServiceManager.Properties.Resources.cancel;
            this.buttonCancelChanges.Location = new System.Drawing.Point(274, 455);
            this.buttonCancelChanges.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCancelChanges.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCancelChanges.Name = "buttonCancelChanges";
            this.buttonCancelChanges.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonCancelChanges.Size = new System.Drawing.Size(164, 36);
            this.buttonCancelChanges.TabIndex = 66;
            this.buttonCancelChanges.Text = "Anuluj zmiany";
            this.buttonCancelChanges.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonCancelChanges.UseAccentColor = false;
            this.buttonCancelChanges.UseVisualStyleBackColor = true;
            this.buttonCancelChanges.Click += new System.EventHandler(this.buttonCancelChanges_Click);
            // 
            // checkBoxSendMessagesToManager
            // 
            this.checkBoxSendMessagesToManager.AutoSize = true;
            this.checkBoxSendMessagesToManager.Depth = 0;
            this.checkBoxSendMessagesToManager.Location = new System.Drawing.Point(7, 138);
            this.checkBoxSendMessagesToManager.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSendMessagesToManager.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxSendMessagesToManager.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxSendMessagesToManager.Name = "checkBoxSendMessagesToManager";
            this.checkBoxSendMessagesToManager.ReadOnly = false;
            this.checkBoxSendMessagesToManager.Ripple = true;
            this.checkBoxSendMessagesToManager.Size = new System.Drawing.Size(348, 37);
            this.checkBoxSendMessagesToManager.TabIndex = 67;
            this.checkBoxSendMessagesToManager.Text = "Wysyłaj wiadomości do managera z serwisu";
            this.checkBoxSendMessagesToManager.UseVisualStyleBackColor = true;
            this.checkBoxSendMessagesToManager.CheckedChanged += new System.EventHandler(this.checkBoxSendMessagesToManager_CheckedChanged);
            // 
            // materialTextBoxPortForManagerSendMessages
            // 
            this.materialTextBoxPortForManagerSendMessages.AnimateReadOnly = false;
            this.materialTextBoxPortForManagerSendMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBoxPortForManagerSendMessages.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBoxPortForManagerSendMessages.Depth = 0;
            this.materialTextBoxPortForManagerSendMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBoxPortForManagerSendMessages.HideSelection = true;
            this.materialTextBoxPortForManagerSendMessages.LeadingIcon = null;
            this.materialTextBoxPortForManagerSendMessages.Location = new System.Drawing.Point(7, 204);
            this.materialTextBoxPortForManagerSendMessages.MaxLength = 32767;
            this.materialTextBoxPortForManagerSendMessages.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBoxPortForManagerSendMessages.Name = "materialTextBoxPortForManagerSendMessages";
            this.materialTextBoxPortForManagerSendMessages.PasswordChar = '\0';
            this.materialTextBoxPortForManagerSendMessages.PrefixSuffixText = null;
            this.materialTextBoxPortForManagerSendMessages.ReadOnly = false;
            this.materialTextBoxPortForManagerSendMessages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBoxPortForManagerSendMessages.SelectedText = "";
            this.materialTextBoxPortForManagerSendMessages.SelectionLength = 0;
            this.materialTextBoxPortForManagerSendMessages.SelectionStart = 0;
            this.materialTextBoxPortForManagerSendMessages.ShortcutsEnabled = true;
            this.materialTextBoxPortForManagerSendMessages.Size = new System.Drawing.Size(250, 48);
            this.materialTextBoxPortForManagerSendMessages.TabIndex = 68;
            this.materialTextBoxPortForManagerSendMessages.TabStop = false;
            this.materialTextBoxPortForManagerSendMessages.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBoxPortForManagerSendMessages.TrailingIcon = null;
            this.materialTextBoxPortForManagerSendMessages.UseSystemPasswordChar = false;
            this.materialTextBoxPortForManagerSendMessages.Enter += new System.EventHandler(this.materialTextBoxPortForManagerSendMessages_Enter);
            this.materialTextBoxPortForManagerSendMessages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.materialTextBoxPortForManagerSendMessages_KeyPress);
            this.materialTextBoxPortForManagerSendMessages.Leave += new System.EventHandler(this.materialTextBoxPortForManagerSendMessages_Leave);
            this.materialTextBoxPortForManagerSendMessages.TextChanged += new System.EventHandler(this.materialTextBoxPortForManagerSendMessages_TextChanged);
            // 
            // labelPortForSendManager
            // 
            this.labelPortForSendManager.AutoSize = true;
            this.labelPortForSendManager.Depth = 0;
            this.labelPortForSendManager.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPortForSendManager.Location = new System.Drawing.Point(7, 182);
            this.labelPortForSendManager.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPortForSendManager.Name = "labelPortForSendManager";
            this.labelPortForSendManager.Size = new System.Drawing.Size(283, 19);
            this.labelPortForSendManager.TabIndex = 69;
            this.labelPortForSendManager.Text = "Port używany do połączenia z serwisem";
            // 
            // materialButtonFindFreePort
            // 
            this.materialButtonFindFreePort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonFindFreePort.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonFindFreePort.Depth = 0;
            this.materialButtonFindFreePort.HighEmphasis = true;
            this.materialButtonFindFreePort.Icon = global::CodeCompilerServiceManager.Properties.Resources.magnify;
            this.materialButtonFindFreePort.Location = new System.Drawing.Point(264, 207);
            this.materialButtonFindFreePort.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonFindFreePort.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonFindFreePort.Name = "materialButtonFindFreePort";
            this.materialButtonFindFreePort.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonFindFreePort.Size = new System.Drawing.Size(201, 36);
            this.materialButtonFindFreePort.TabIndex = 70;
            this.materialButtonFindFreePort.Text = "Znajdź wolny port";
            this.materialButtonFindFreePort.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonFindFreePort.UseAccentColor = false;
            this.materialButtonFindFreePort.UseVisualStyleBackColor = true;
            this.materialButtonFindFreePort.Click += new System.EventHandler(this.materialButtonFindFreePort_Click);
            // 
            // ServiceSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialButtonFindFreePort);
            this.Controls.Add(this.labelPortForSendManager);
            this.Controls.Add(this.materialTextBoxPortForManagerSendMessages);
            this.Controls.Add(this.checkBoxSendMessagesToManager);
            this.Controls.Add(this.buttonCancelChanges);
            this.Controls.Add(this.buttonSetDefaultServiceSettings);
            this.Controls.Add(this.buttonSaveAndRestart);
            this.Controls.Add(this.textBoxInternalBufferSize);
            this.Controls.Add(this.labelInternalBufferSize);
            this.Controls.Add(this.textBoxServiceMainInterval);
            this.Controls.Add(this.labelIntervalService);
            this.Controls.Add(this.buttonOpenLogFolder);
            this.Controls.Add(this.textBoxPathToLogs);
            this.Controls.Add(this.checkBoxLogToFile);
            this.Controls.Add(this.labelRestartRequired);
            this.Controls.Add(this.checkBoxLogToEventViewer);
            this.Controls.Add(this.panelFooterServicePath);
            this.Name = "ServiceSettingsControl";
            this.Size = new System.Drawing.Size(866, 618);
            this.panelFooterServicePath.ResumeLayout(false);
            this.panelFooterServicePath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel labelRestartRequired;
        private MaterialSkin.Controls.MaterialLabel labelServicePath;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxServicePath;
        private MaterialSkin.Controls.MaterialButton buttonOpenServicePath;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Panel panelFooterServicePath;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxLogToEventViewer;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxLogToFile;
        private ToolTip toolTip1;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxPathToLogs;
        private MaterialSkin.Controls.MaterialButton buttonOpenLogFolder;
        private MaterialSkin.Controls.MaterialLabel labelIntervalService;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxServiceMainInterval;
        private MaterialSkin.Controls.MaterialLabel labelInternalBufferSize;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxInternalBufferSize;
        private MaterialSkin.Controls.MaterialButton buttonSaveAndRestart;
        private MaterialSkin.Controls.MaterialButton buttonSetDefaultServiceSettings;
        private MaterialSkin.Controls.MaterialButton buttonCancelChanges;
        private MaterialSkin.Controls.MaterialButton buttonInstallService;
        private MaterialSkin.Controls.MaterialButton buttonDeleteService;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxSendMessagesToManager;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBoxPortForManagerSendMessages;
        private MaterialSkin.Controls.MaterialLabel labelPortForSendManager;
        private MaterialSkin.Controls.MaterialButton materialButtonFindFreePort;
    }
}
