﻿namespace CodeCompilerServiceManager
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
            this.txtOutputConsole = new System.Windows.Forms.RichTextBox();
            this.btnClearManagerConsole = new System.Windows.Forms.Button();
            this.buttonInstallService = new System.Windows.Forms.Button();
            this.buttonDeleteService = new System.Windows.Forms.Button();
            this.buttonAppRestart = new System.Windows.Forms.Button();
            this.buttonRefreshServiceState = new System.Windows.Forms.Button();
            this.textBoxInputPath = new System.Windows.Forms.TextBox();
            this.textBoxOutputPath = new System.Windows.Forms.TextBox();
            this.labelInputPath = new System.Windows.Forms.Label();
            this.labelIOutputPath = new System.Windows.Forms.Label();
            this.checkBoxCompileToConsoleApp = new System.Windows.Forms.CheckBox();
            this.labelRestartRequired = new System.Windows.Forms.Label();
            this.buttonSaveAndRestart = new System.Windows.Forms.Button();
            this.buttonCancelChanges = new System.Windows.Forms.Button();
            this.buttonSetDefaultServiceSettings = new System.Windows.Forms.Button();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.labelSplitterMenu = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonLibrarySettings = new System.Windows.Forms.Button();
            this.buttonServiceSettings = new System.Windows.Forms.Button();
            this.buttonManagerSettings = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.labelTitleBar = new System.Windows.Forms.Label();
            this.panelDesktopParent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).BeginInit();
            this.panelSideMenu.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(232, 146);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(174, 23);
            this.btnStartService.TabIndex = 0;
            this.btnStartService.Text = "Uruchom usługę";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(232, 175);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(175, 23);
            this.btnStopService.TabIndex = 1;
            this.btnStopService.Text = "Zatrzymaj usługę";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnReStartService
            // 
            this.btnReStartService.Location = new System.Drawing.Point(232, 204);
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
            this.labelServiceStatus.Location = new System.Drawing.Point(232, 118);
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(68, 15);
            this.labelServiceStatus.TabIndex = 3;
            this.labelServiceStatus.Text = "Stan usługi:";
            // 
            // pictureServiceStatus
            // 
            this.pictureServiceStatus.Image = global::CodeCompilerServiceManager.Properties.Resources.yellow;
            this.pictureServiceStatus.Location = new System.Drawing.Point(232, 80);
            this.pictureServiceStatus.Name = "pictureServiceStatus";
            this.pictureServiceStatus.Size = new System.Drawing.Size(68, 35);
            this.pictureServiceStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureServiceStatus.TabIndex = 4;
            this.pictureServiceStatus.TabStop = false;
            // 
            // txtOutputConsole
            // 
            this.txtOutputConsole.Location = new System.Drawing.Point(241, 415);
            this.txtOutputConsole.Name = "txtOutputConsole";
            this.txtOutputConsole.ReadOnly = true;
            this.txtOutputConsole.Size = new System.Drawing.Size(516, 235);
            this.txtOutputConsole.TabIndex = 10;
            this.txtOutputConsole.Text = "";
            // 
            // btnClearManagerConsole
            // 
            this.btnClearManagerConsole.Location = new System.Drawing.Point(232, 656);
            this.btnClearManagerConsole.Name = "btnClearManagerConsole";
            this.btnClearManagerConsole.Size = new System.Drawing.Size(117, 23);
            this.btnClearManagerConsole.TabIndex = 13;
            this.btnClearManagerConsole.Text = "Wyczyść konsole";
            this.btnClearManagerConsole.UseVisualStyleBackColor = true;
            this.btnClearManagerConsole.Click += new System.EventHandler(this.btnClearManagerConsole_Click);
            // 
            // buttonInstallService
            // 
            this.buttonInstallService.Location = new System.Drawing.Point(543, 200);
            this.buttonInstallService.Name = "buttonInstallService";
            this.buttonInstallService.Size = new System.Drawing.Size(119, 23);
            this.buttonInstallService.TabIndex = 15;
            this.buttonInstallService.Text = "Zainstaluj usługę";
            this.buttonInstallService.UseVisualStyleBackColor = true;
            this.buttonInstallService.Click += new System.EventHandler(this.buttonInstallService_Click);
            // 
            // buttonDeleteService
            // 
            this.buttonDeleteService.Location = new System.Drawing.Point(413, 227);
            this.buttonDeleteService.Name = "buttonDeleteService";
            this.buttonDeleteService.Size = new System.Drawing.Size(119, 23);
            this.buttonDeleteService.TabIndex = 16;
            this.buttonDeleteService.Text = "Usuń usługę";
            this.buttonDeleteService.UseVisualStyleBackColor = true;
            this.buttonDeleteService.Click += new System.EventHandler(this.buttonDeleteService_Click);
            // 
            // buttonAppRestart
            // 
            this.buttonAppRestart.Location = new System.Drawing.Point(442, 175);
            this.buttonAppRestart.Name = "buttonAppRestart";
            this.buttonAppRestart.Size = new System.Drawing.Size(108, 23);
            this.buttonAppRestart.TabIndex = 17;
            this.buttonAppRestart.Text = "Restart aplikacji";
            this.buttonAppRestart.UseVisualStyleBackColor = true;
            this.buttonAppRestart.Click += new System.EventHandler(this.buttonAppRestart_Click);
            // 
            // buttonRefreshServiceState
            // 
            this.buttonRefreshServiceState.Location = new System.Drawing.Point(306, 80);
            this.buttonRefreshServiceState.Name = "buttonRefreshServiceState";
            this.buttonRefreshServiceState.Size = new System.Drawing.Size(209, 23);
            this.buttonRefreshServiceState.TabIndex = 22;
            this.buttonRefreshServiceState.Text = "Ręcznie odśwież stan usługi";
            this.buttonRefreshServiceState.UseVisualStyleBackColor = true;
            this.buttonRefreshServiceState.Click += new System.EventHandler(this.buttonRefreshServiceState_Click);
            // 
            // textBoxInputPath
            // 
            this.textBoxInputPath.Location = new System.Drawing.Point(937, 127);
            this.textBoxInputPath.Name = "textBoxInputPath";
            this.textBoxInputPath.Size = new System.Drawing.Size(276, 23);
            this.textBoxInputPath.TabIndex = 30;
            this.textBoxInputPath.WordWrap = false;
            this.textBoxInputPath.TextChanged += new System.EventHandler(this.textBoxInputPath_TextChanged);
            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.Location = new System.Drawing.Point(937, 181);
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.Size = new System.Drawing.Size(276, 23);
            this.textBoxOutputPath.TabIndex = 31;
            this.textBoxOutputPath.WordWrap = false;
            this.textBoxOutputPath.TextChanged += new System.EventHandler(this.textBoxOutputPath_TextChanged);
            // 
            // labelInputPath
            // 
            this.labelInputPath.AutoSize = true;
            this.labelInputPath.Location = new System.Drawing.Point(937, 109);
            this.labelInputPath.Name = "labelInputPath";
            this.labelInputPath.Size = new System.Drawing.Size(210, 15);
            this.labelInputPath.TabIndex = 32;
            this.labelInputPath.Text = "Folder wejściowy plików do kompilacji";
            // 
            // labelIOutputPath
            // 
            this.labelIOutputPath.AutoSize = true;
            this.labelIOutputPath.Location = new System.Drawing.Point(937, 156);
            this.labelIOutputPath.Name = "labelIOutputPath";
            this.labelIOutputPath.Size = new System.Drawing.Size(207, 15);
            this.labelIOutputPath.TabIndex = 33;
            this.labelIOutputPath.Text = "Folder wyściowy plików do kompilacji";
            // 
            // checkBoxCompileToConsoleApp
            // 
            this.checkBoxCompileToConsoleApp.AutoSize = true;
            this.checkBoxCompileToConsoleApp.Location = new System.Drawing.Point(937, 235);
            this.checkBoxCompileToConsoleApp.Name = "checkBoxCompileToConsoleApp";
            this.checkBoxCompileToConsoleApp.Size = new System.Drawing.Size(200, 19);
            this.checkBoxCompileToConsoleApp.TabIndex = 34;
            this.checkBoxCompileToConsoleApp.Text = "Kompiluj do aplikacji konsolowej";
            this.checkBoxCompileToConsoleApp.UseVisualStyleBackColor = true;
            this.checkBoxCompileToConsoleApp.CheckedChanged += new System.EventHandler(this.checkBoxCompileToConsoleApp_CheckedChanged);
            // 
            // labelRestartRequired
            // 
            this.labelRestartRequired.AutoSize = true;
            this.labelRestartRequired.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRestartRequired.ForeColor = System.Drawing.Color.Red;
            this.labelRestartRequired.Location = new System.Drawing.Point(521, 80);
            this.labelRestartRequired.Name = "labelRestartRequired";
            this.labelRestartRequired.Size = new System.Drawing.Size(582, 25);
            this.labelRestartRequired.TabIndex = 35;
            this.labelRestartRequired.Text = "Po zmianie opcji serwisu lub biblioteki wymagany jest restart usługi!";
            // 
            // buttonSaveAndRestart
            // 
            this.buttonSaveAndRestart.Location = new System.Drawing.Point(442, 109);
            this.buttonSaveAndRestart.Name = "buttonSaveAndRestart";
            this.buttonSaveAndRestart.Size = new System.Drawing.Size(199, 23);
            this.buttonSaveAndRestart.TabIndex = 36;
            this.buttonSaveAndRestart.Text = "Zapisz i zrestartuj usługę";
            this.buttonSaveAndRestart.UseVisualStyleBackColor = true;
            this.buttonSaveAndRestart.Click += new System.EventHandler(this.buttonSaveAndRestart_Click);
            // 
            // buttonCancelChanges
            // 
            this.buttonCancelChanges.Location = new System.Drawing.Point(442, 138);
            this.buttonCancelChanges.Name = "buttonCancelChanges";
            this.buttonCancelChanges.Size = new System.Drawing.Size(199, 23);
            this.buttonCancelChanges.TabIndex = 37;
            this.buttonCancelChanges.Text = "Anuluj zmiany";
            this.buttonCancelChanges.UseVisualStyleBackColor = true;
            this.buttonCancelChanges.Click += new System.EventHandler(this.buttonCancelChanges_Click);
            // 
            // buttonSetDefaultServiceSettings
            // 
            this.buttonSetDefaultServiceSettings.Location = new System.Drawing.Point(937, 260);
            this.buttonSetDefaultServiceSettings.Name = "buttonSetDefaultServiceSettings";
            this.buttonSetDefaultServiceSettings.Size = new System.Drawing.Size(287, 23);
            this.buttonSetDefaultServiceSettings.TabIndex = 38;
            this.buttonSetDefaultServiceSettings.Text = "Przywróć ustawienia usługi na domyślne";
            this.buttonSetDefaultServiceSettings.UseVisualStyleBackColor = true;
            this.buttonSetDefaultServiceSettings.Click += new System.EventHandler(this.buttonSetDefaultServiceSettings_Click);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelSideMenu.Controls.Add(this.labelSplitterMenu);
            this.panelSideMenu.Controls.Add(this.buttonExit);
            this.panelSideMenu.Controls.Add(this.buttonInfo);
            this.panelSideMenu.Controls.Add(this.buttonLibrarySettings);
            this.panelSideMenu.Controls.Add(this.buttonServiceSettings);
            this.panelSideMenu.Controls.Add(this.buttonManagerSettings);
            this.panelSideMenu.Controls.Add(this.buttonHome);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(220, 685);
            this.panelSideMenu.TabIndex = 39;
            // 
            // labelSplitterMenu
            // 
            this.labelSplitterMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSplitterMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelSplitterMenu.ForeColor = System.Drawing.SystemColors.Control;
            this.labelSplitterMenu.Location = new System.Drawing.Point(0, 633);
            this.labelSplitterMenu.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelSplitterMenu.Name = "labelSplitterMenu";
            this.labelSplitterMenu.Size = new System.Drawing.Size(220, 2);
            this.labelSplitterMenu.TabIndex = 7;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonExit.Location = new System.Drawing.Point(0, 635);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(220, 50);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Wyjście";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonInfo.Location = new System.Drawing.Point(0, 300);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(220, 50);
            this.buttonInfo.TabIndex = 5;
            this.buttonInfo.Text = "Informacje";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonLibrarySettings
            // 
            this.buttonLibrarySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLibrarySettings.FlatAppearance.BorderSize = 0;
            this.buttonLibrarySettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLibrarySettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLibrarySettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonLibrarySettings.Location = new System.Drawing.Point(0, 250);
            this.buttonLibrarySettings.Name = "buttonLibrarySettings";
            this.buttonLibrarySettings.Size = new System.Drawing.Size(220, 50);
            this.buttonLibrarySettings.TabIndex = 4;
            this.buttonLibrarySettings.Text = "Ustawienia biblioteki kompilującej";
            this.buttonLibrarySettings.UseVisualStyleBackColor = true;
            this.buttonLibrarySettings.Click += new System.EventHandler(this.buttonLibrarySettings_Click);
            // 
            // buttonServiceSettings
            // 
            this.buttonServiceSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonServiceSettings.FlatAppearance.BorderSize = 0;
            this.buttonServiceSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonServiceSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonServiceSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonServiceSettings.Location = new System.Drawing.Point(0, 200);
            this.buttonServiceSettings.Name = "buttonServiceSettings";
            this.buttonServiceSettings.Size = new System.Drawing.Size(220, 50);
            this.buttonServiceSettings.TabIndex = 3;
            this.buttonServiceSettings.Text = "Ustawienia serwisu";
            this.buttonServiceSettings.UseVisualStyleBackColor = true;
            this.buttonServiceSettings.Click += new System.EventHandler(this.buttonServiceSettings_Click);
            // 
            // buttonManagerSettings
            // 
            this.buttonManagerSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManagerSettings.FlatAppearance.BorderSize = 0;
            this.buttonManagerSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManagerSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonManagerSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonManagerSettings.Location = new System.Drawing.Point(0, 150);
            this.buttonManagerSettings.Name = "buttonManagerSettings";
            this.buttonManagerSettings.Size = new System.Drawing.Size(220, 50);
            this.buttonManagerSettings.TabIndex = 2;
            this.buttonManagerSettings.Text = "Ustawienia menadżera";
            this.buttonManagerSettings.UseVisualStyleBackColor = true;
            this.buttonManagerSettings.Click += new System.EventHandler(this.buttonManagerSettings_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonHome.Location = new System.Drawing.Point(0, 100);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(220, 50);
            this.buttonHome.TabIndex = 1;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.panelTitleBar.Controls.Add(this.labelTitleBar);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1010, 75);
            this.panelTitleBar.TabIndex = 40;
            // 
            // labelTitleBar
            // 
            this.labelTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitleBar.ForeColor = System.Drawing.Color.White;
            this.labelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.labelTitleBar.Name = "labelTitleBar";
            this.labelTitleBar.Size = new System.Drawing.Size(1010, 75);
            this.labelTitleBar.TabIndex = 0;
            this.labelTitleBar.Text = "Home";
            this.labelTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDesktopParent
            // 
            this.panelDesktopParent.Location = new System.Drawing.Point(763, 300);
            this.panelDesktopParent.Name = "panelDesktopParent";
            this.panelDesktopParent.Size = new System.Drawing.Size(455, 373);
            this.panelDesktopParent.TabIndex = 41;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 685);
            this.Controls.Add(this.panelDesktopParent);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.buttonSetDefaultServiceSettings);
            this.Controls.Add(this.buttonCancelChanges);
            this.Controls.Add(this.buttonSaveAndRestart);
            this.Controls.Add(this.labelRestartRequired);
            this.Controls.Add(this.checkBoxCompileToConsoleApp);
            this.Controls.Add(this.labelIOutputPath);
            this.Controls.Add(this.labelInputPath);
            this.Controls.Add(this.textBoxOutputPath);
            this.Controls.Add(this.textBoxInputPath);
            this.Controls.Add(this.buttonRefreshServiceState);
            this.Controls.Add(this.buttonAppRestart);
            this.Controls.Add(this.buttonDeleteService);
            this.Controls.Add(this.buttonInstallService);
            this.Controls.Add(this.btnClearManagerConsole);
            this.Controls.Add(this.txtOutputConsole);
            this.Controls.Add(this.pictureServiceStatus);
            this.Controls.Add(this.labelServiceStatus);
            this.Controls.Add(this.btnReStartService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Name = "AppForm";
            this.Text = "Code Compiler Service Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).EndInit();
            this.panelSideMenu.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartService;
        private Button btnStopService;
        private Button btnReStartService;
        private Label labelServiceStatus;
        private PictureBox pictureServiceStatus;
        private RichTextBox txtOutputConsole;
        private Button btnClearManagerConsole;
        private Button buttonInstallService;
        private Button buttonDeleteService;
        private Button buttonAppRestart;
        private Button buttonRefreshServiceState;
        private TextBox textBoxInputPath;
        private TextBox textBoxOutputPath;
        private Label labelInputPath;
        private Label labelIOutputPath;
        private CheckBox checkBoxCompileToConsoleApp;
        private Label labelRestartRequired;
        private Button buttonSaveAndRestart;
        private Button buttonCancelChanges;
        private Button buttonSetDefaultServiceSettings;
        private Panel panelSideMenu;
        private Button buttonHome;
        private Panel panelLogo;
        private Label labelSplitterMenu;
        private Button buttonExit;
        private Button buttonInfo;
        private Button buttonLibrarySettings;
        private Button buttonServiceSettings;
        private Button buttonManagerSettings;
        private Panel panelTitleBar;
        private Label labelTitleBar;
        private Panel panelDesktopParent;
    }
}