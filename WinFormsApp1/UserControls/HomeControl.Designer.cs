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
            this.pictureServiceStatus = new System.Windows.Forms.PictureBox();
            this.buttonRefreshServiceState = new MaterialSkin.Controls.MaterialButton();
            this.btnClearManagerConsole = new MaterialSkin.Controls.MaterialButton();
            this.btnStartService = new MaterialSkin.Controls.MaterialButton();
            this.btnStopService = new MaterialSkin.Controls.MaterialButton();
            this.btnReStartService = new MaterialSkin.Controls.MaterialButton();
            this.labelServiceStatus = new MaterialSkin.Controls.MaterialLabel();
            this.txtOutputConsole = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureServiceStatus
            // 
            this.pictureServiceStatus.Image = global::CodeCompilerServiceManager.Properties.Resources.yellow;
            this.pictureServiceStatus.Location = new System.Drawing.Point(3, 3);
            this.pictureServiceStatus.Name = "pictureServiceStatus";
            this.pictureServiceStatus.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pictureServiceStatus.Size = new System.Drawing.Size(798, 51);
            this.pictureServiceStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureServiceStatus.TabIndex = 27;
            this.pictureServiceStatus.TabStop = false;
            // 
            // buttonRefreshServiceState
            // 
            this.buttonRefreshServiceState.AutoSize = false;
            this.buttonRefreshServiceState.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefreshServiceState.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonRefreshServiceState.Depth = 0;
            this.buttonRefreshServiceState.HighEmphasis = true;
            this.buttonRefreshServiceState.Icon = null;
            this.buttonRefreshServiceState.Location = new System.Drawing.Point(274, 127);
            this.buttonRefreshServiceState.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonRefreshServiceState.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefreshServiceState.Name = "buttonRefreshServiceState";
            this.buttonRefreshServiceState.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonRefreshServiceState.Size = new System.Drawing.Size(243, 36);
            this.buttonRefreshServiceState.TabIndex = 32;
            this.buttonRefreshServiceState.Text = "Ręcznie odśwież stan usługi";
            this.buttonRefreshServiceState.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonRefreshServiceState.UseAccentColor = false;
            this.buttonRefreshServiceState.UseVisualStyleBackColor = true;
            this.buttonRefreshServiceState.Click += new System.EventHandler(this.buttonRefreshServiceState_Click);
            // 
            // btnClearManagerConsole
            // 
            this.btnClearManagerConsole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearManagerConsole.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearManagerConsole.Depth = 0;
            this.btnClearManagerConsole.HighEmphasis = true;
            this.btnClearManagerConsole.Icon = null;
            this.btnClearManagerConsole.Location = new System.Drawing.Point(305, 576);
            this.btnClearManagerConsole.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClearManagerConsole.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearManagerConsole.Name = "btnClearManagerConsole";
            this.btnClearManagerConsole.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClearManagerConsole.Size = new System.Drawing.Size(159, 36);
            this.btnClearManagerConsole.TabIndex = 33;
            this.btnClearManagerConsole.Text = "Wyczyść konsole";
            this.btnClearManagerConsole.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClearManagerConsole.UseAccentColor = false;
            this.btnClearManagerConsole.UseVisualStyleBackColor = true;
            this.btnClearManagerConsole.Click += new System.EventHandler(this.btnClearManagerConsole_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStartService.Depth = 0;
            this.btnStartService.HighEmphasis = true;
            this.btnStartService.Icon = null;
            this.btnStartService.Location = new System.Drawing.Point(152, 79);
            this.btnStartService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStartService.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStartService.Size = new System.Drawing.Size(151, 36);
            this.btnStartService.TabIndex = 35;
            this.btnStartService.Text = "Uruchom usługę";
            this.btnStartService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStartService.UseAccentColor = false;
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStopService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStopService.Depth = 0;
            this.btnStopService.HighEmphasis = true;
            this.btnStopService.Icon = null;
            this.btnStopService.Location = new System.Drawing.Point(311, 79);
            this.btnStopService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStopService.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStopService.Size = new System.Drawing.Size(165, 36);
            this.btnStopService.TabIndex = 36;
            this.btnStopService.Text = "Zatrzymaj usługę";
            this.btnStopService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStopService.UseAccentColor = false;
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnReStartService
            // 
            this.btnReStartService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReStartService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReStartService.Depth = 0;
            this.btnReStartService.HighEmphasis = true;
            this.btnReStartService.Icon = null;
            this.btnReStartService.Location = new System.Drawing.Point(484, 79);
            this.btnReStartService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReStartService.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReStartService.Name = "btnReStartService";
            this.btnReStartService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReStartService.Size = new System.Drawing.Size(227, 36);
            this.btnReStartService.TabIndex = 37;
            this.btnReStartService.Text = "Uruchom ponowne usługę";
            this.btnReStartService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReStartService.UseAccentColor = false;
            this.btnReStartService.UseVisualStyleBackColor = true;
            this.btnReStartService.Click += new System.EventHandler(this.btnReStartService_Click);
            // 
            // labelServiceStatus
            // 
            this.labelServiceStatus.AutoSize = true;
            this.labelServiceStatus.Depth = 0;
            this.labelServiceStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelServiceStatus.Location = new System.Drawing.Point(293, 54);
            this.labelServiceStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(171, 19);
            this.labelServiceStatus.TabIndex = 38;
            this.labelServiceStatus.Text = " Stan usługi: Nieznany...";
            // 
            // txtOutputConsole
            // 
            this.txtOutputConsole.Location = new System.Drawing.Point(13, 172);
            this.txtOutputConsole.Multiline = true;
            this.txtOutputConsole.Name = "txtOutputConsole";
            this.txtOutputConsole.ReadOnly = true;
            this.txtOutputConsole.Size = new System.Drawing.Size(779, 395);
            this.txtOutputConsole.TabIndex = 41;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOutputConsole);
            this.Controls.Add(this.labelServiceStatus);
            this.Controls.Add(this.btnReStartService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.btnClearManagerConsole);
            this.Controls.Add(this.buttonRefreshServiceState);
            this.Controls.Add(this.pictureServiceStatus);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(798, 618);
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureServiceStatus;
        private MaterialSkin.Controls.MaterialButton buttonRefreshServiceState;
        private MaterialSkin.Controls.MaterialButton btnClearManagerConsole;
        private MaterialSkin.Controls.MaterialButton btnStartService;
        private MaterialSkin.Controls.MaterialButton btnStopService;
        private MaterialSkin.Controls.MaterialButton btnReStartService;
        private MaterialSkin.Controls.MaterialLabel labelServiceStatus;
        private TextBox txtOutputConsole;
    }
}
