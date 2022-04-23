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
            this.checkBoxCompileToConsoleApp = new System.Windows.Forms.CheckBox();
            this.labelIOutputPath = new System.Windows.Forms.Label();
            this.labelInputPath = new System.Windows.Forms.Label();
            this.textBoxOutputPath = new System.Windows.Forms.TextBox();
            this.textBoxInputPath = new System.Windows.Forms.TextBox();
            this.labelRestartRequired = new System.Windows.Forms.Label();
            this.buttonSetDefaultServiceSettings = new System.Windows.Forms.Button();
            this.buttonCancelChanges = new System.Windows.Forms.Button();
            this.buttonSaveAndRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxCompileToConsoleApp
            // 
            this.checkBoxCompileToConsoleApp.AutoSize = true;
            this.checkBoxCompileToConsoleApp.Location = new System.Drawing.Point(3, 119);
            this.checkBoxCompileToConsoleApp.Name = "checkBoxCompileToConsoleApp";
            this.checkBoxCompileToConsoleApp.Size = new System.Drawing.Size(200, 19);
            this.checkBoxCompileToConsoleApp.TabIndex = 39;
            this.checkBoxCompileToConsoleApp.Text = "Kompiluj do aplikacji konsolowej";
            this.checkBoxCompileToConsoleApp.UseVisualStyleBackColor = true;
            this.checkBoxCompileToConsoleApp.CheckedChanged += new System.EventHandler(this.checkBoxCompileToConsoleApp_CheckedChanged);
            // 
            // labelIOutputPath
            // 
            this.labelIOutputPath.AutoSize = true;
            this.labelIOutputPath.Location = new System.Drawing.Point(3, 56);
            this.labelIOutputPath.Name = "labelIOutputPath";
            this.labelIOutputPath.Size = new System.Drawing.Size(207, 15);
            this.labelIOutputPath.TabIndex = 38;
            this.labelIOutputPath.Text = "Folder wyściowy plików do kompilacji";
            // 
            // labelInputPath
            // 
            this.labelInputPath.AutoSize = true;
            this.labelInputPath.Location = new System.Drawing.Point(3, 9);
            this.labelInputPath.Name = "labelInputPath";
            this.labelInputPath.Size = new System.Drawing.Size(210, 15);
            this.labelInputPath.TabIndex = 37;
            this.labelInputPath.Text = "Folder wejściowy plików do kompilacji";
            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.Location = new System.Drawing.Point(3, 81);
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.Size = new System.Drawing.Size(276, 23);
            this.textBoxOutputPath.TabIndex = 36;
            this.textBoxOutputPath.WordWrap = false;
            this.textBoxOutputPath.TextChanged += new System.EventHandler(this.textBoxOutputPath_TextChanged);
            // 
            // textBoxInputPath
            // 
            this.textBoxInputPath.Location = new System.Drawing.Point(3, 27);
            this.textBoxInputPath.Name = "textBoxInputPath";
            this.textBoxInputPath.Size = new System.Drawing.Size(276, 23);
            this.textBoxInputPath.TabIndex = 35;
            this.textBoxInputPath.WordWrap = false;
            this.textBoxInputPath.TextChanged += new System.EventHandler(this.textBoxInputPath_TextChanged);
            // 
            // labelRestartRequired
            // 
            this.labelRestartRequired.AutoSize = true;
            this.labelRestartRequired.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRestartRequired.ForeColor = System.Drawing.Color.Red;
            this.labelRestartRequired.Location = new System.Drawing.Point(3, 156);
            this.labelRestartRequired.Name = "labelRestartRequired";
            this.labelRestartRequired.Size = new System.Drawing.Size(582, 25);
            this.labelRestartRequired.TabIndex = 40;
            this.labelRestartRequired.Text = "Po zmianie opcji serwisu lub biblioteki wymagany jest restart usługi!";
            // 
            // buttonSetDefaultServiceSettings
            // 
            this.buttonSetDefaultServiceSettings.Location = new System.Drawing.Point(298, 85);
            this.buttonSetDefaultServiceSettings.Name = "buttonSetDefaultServiceSettings";
            this.buttonSetDefaultServiceSettings.Size = new System.Drawing.Size(287, 23);
            this.buttonSetDefaultServiceSettings.TabIndex = 43;
            this.buttonSetDefaultServiceSettings.Text = "Przywróć ustawienia usługi na domyślne";
            this.buttonSetDefaultServiceSettings.UseVisualStyleBackColor = true;
            this.buttonSetDefaultServiceSettings.Click += new System.EventHandler(this.buttonSetDefaultServiceSettings_Click);
            // 
            // buttonCancelChanges
            // 
            this.buttonCancelChanges.Location = new System.Drawing.Point(303, 56);
            this.buttonCancelChanges.Name = "buttonCancelChanges";
            this.buttonCancelChanges.Size = new System.Drawing.Size(199, 23);
            this.buttonCancelChanges.TabIndex = 42;
            this.buttonCancelChanges.Text = "Anuluj zmiany";
            this.buttonCancelChanges.UseVisualStyleBackColor = true;
            this.buttonCancelChanges.Click += new System.EventHandler(this.buttonCancelChanges_Click);
            // 
            // buttonSaveAndRestart
            // 
            this.buttonSaveAndRestart.Location = new System.Drawing.Point(303, 27);
            this.buttonSaveAndRestart.Name = "buttonSaveAndRestart";
            this.buttonSaveAndRestart.Size = new System.Drawing.Size(199, 23);
            this.buttonSaveAndRestart.TabIndex = 41;
            this.buttonSaveAndRestart.Text = "Zapisz i zrestartuj usługę";
            this.buttonSaveAndRestart.UseVisualStyleBackColor = true;
            this.buttonSaveAndRestart.Click += new System.EventHandler(this.buttonSaveAndRestart_Click);
            // 
            // LibrarySettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSetDefaultServiceSettings);
            this.Controls.Add(this.buttonCancelChanges);
            this.Controls.Add(this.buttonSaveAndRestart);
            this.Controls.Add(this.labelRestartRequired);
            this.Controls.Add(this.checkBoxCompileToConsoleApp);
            this.Controls.Add(this.labelIOutputPath);
            this.Controls.Add(this.labelInputPath);
            this.Controls.Add(this.textBoxOutputPath);
            this.Controls.Add(this.textBoxInputPath);
            this.Name = "LibrarySettingsControl";
            this.Size = new System.Drawing.Size(600, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBoxCompileToConsoleApp;
        private Label labelIOutputPath;
        private Label labelInputPath;
        private TextBox textBoxOutputPath;
        private TextBox textBoxInputPath;
        private Label labelRestartRequired;
        private Button buttonSetDefaultServiceSettings;
        private Button buttonCancelChanges;
        private Button buttonSaveAndRestart;
    }
}
