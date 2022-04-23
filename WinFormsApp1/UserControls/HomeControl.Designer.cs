namespace CodeCompilerServiceManager.UserControls
{
    partial class HomeControl
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
            this.buttonRefreshServiceState = new System.Windows.Forms.Button();
            this.buttonAppRestart = new System.Windows.Forms.Button();
            this.pictureServiceStatus = new System.Windows.Forms.PictureBox();
            this.labelServiceStatus = new System.Windows.Forms.Label();
            this.btnReStartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnClearManagerConsole = new System.Windows.Forms.Button();
            this.txtOutputConsole = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRefreshServiceState
            // 
            this.buttonRefreshServiceState.Location = new System.Drawing.Point(85, 12);
            this.buttonRefreshServiceState.Name = "buttonRefreshServiceState";
            this.buttonRefreshServiceState.Size = new System.Drawing.Size(209, 23);
            this.buttonRefreshServiceState.TabIndex = 29;
            this.buttonRefreshServiceState.Text = "Ręcznie odśwież stan usługi";
            this.buttonRefreshServiceState.UseVisualStyleBackColor = true;
            this.buttonRefreshServiceState.Click += new System.EventHandler(this.buttonRefreshServiceState_Click);
            // 
            // buttonAppRestart
            // 
            this.buttonAppRestart.Location = new System.Drawing.Point(221, 107);
            this.buttonAppRestart.Name = "buttonAppRestart";
            this.buttonAppRestart.Size = new System.Drawing.Size(108, 23);
            this.buttonAppRestart.TabIndex = 28;
            this.buttonAppRestart.Text = "Restart aplikacji";
            this.buttonAppRestart.UseVisualStyleBackColor = true;
            this.buttonAppRestart.Click += new System.EventHandler(this.buttonAppRestart_Click);
            // 
            // pictureServiceStatus
            // 
            this.pictureServiceStatus.Image = global::CodeCompilerServiceManager.Properties.Resources.yellow;
            this.pictureServiceStatus.Location = new System.Drawing.Point(11, 12);
            this.pictureServiceStatus.Name = "pictureServiceStatus";
            this.pictureServiceStatus.Size = new System.Drawing.Size(68, 35);
            this.pictureServiceStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureServiceStatus.TabIndex = 27;
            this.pictureServiceStatus.TabStop = false;
            // 
            // labelServiceStatus
            // 
            this.labelServiceStatus.AutoSize = true;
            this.labelServiceStatus.Location = new System.Drawing.Point(11, 50);
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(132, 15);
            this.labelServiceStatus.TabIndex = 26;
            this.labelServiceStatus.Text = " Stan usługi: Nieznany...";
            // 
            // btnReStartService
            // 
            this.btnReStartService.Location = new System.Drawing.Point(11, 136);
            this.btnReStartService.Name = "btnReStartService";
            this.btnReStartService.Size = new System.Drawing.Size(175, 23);
            this.btnReStartService.TabIndex = 25;
            this.btnReStartService.Text = "Uruchom ponowne usługę";
            this.btnReStartService.UseVisualStyleBackColor = true;
            this.btnReStartService.Click += new System.EventHandler(this.btnReStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(11, 107);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(175, 23);
            this.btnStopService.TabIndex = 24;
            this.btnStopService.Text = "Zatrzymaj usługę";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(11, 78);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(174, 23);
            this.btnStartService.TabIndex = 23;
            this.btnStartService.Text = "Uruchom usługę";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnClearManagerConsole
            // 
            this.btnClearManagerConsole.Location = new System.Drawing.Point(347, 107);
            this.btnClearManagerConsole.Name = "btnClearManagerConsole";
            this.btnClearManagerConsole.Size = new System.Drawing.Size(117, 23);
            this.btnClearManagerConsole.TabIndex = 31;
            this.btnClearManagerConsole.Text = "Wyczyść konsole";
            this.btnClearManagerConsole.UseVisualStyleBackColor = true;
            this.btnClearManagerConsole.Click += new System.EventHandler(this.btnClearManagerConsole_Click);
            // 
            // txtOutputConsole
            // 
            this.txtOutputConsole.Location = new System.Drawing.Point(11, 165);
            this.txtOutputConsole.Name = "txtOutputConsole";
            this.txtOutputConsole.ReadOnly = true;
            this.txtOutputConsole.Size = new System.Drawing.Size(586, 332);
            this.txtOutputConsole.TabIndex = 30;
            this.txtOutputConsole.Text = "";
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearManagerConsole);
            this.Controls.Add(this.txtOutputConsole);
            this.Controls.Add(this.buttonRefreshServiceState);
            this.Controls.Add(this.buttonAppRestart);
            this.Controls.Add(this.pictureServiceStatus);
            this.Controls.Add(this.labelServiceStatus);
            this.Controls.Add(this.btnReStartService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(600, 500);
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonRefreshServiceState;
        private Button buttonAppRestart;
        private PictureBox pictureServiceStatus;
        private Label labelServiceStatus;
        private Button btnReStartService;
        private Button btnStopService;
        private Button btnStartService;
        private Button btnClearManagerConsole;
        private RichTextBox txtOutputConsole;
    }
}
