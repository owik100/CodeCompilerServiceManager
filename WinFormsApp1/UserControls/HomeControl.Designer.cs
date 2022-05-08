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
            this.components = new System.ComponentModel.Container();
            this.btnClearManagerConsole = new MaterialSkin.Controls.MaterialButton();
            this.panelStatusInfo = new System.Windows.Forms.Panel();
            this.labelServiceStatus = new MaterialSkin.Controls.MaterialLabel();
            this.pictureServiceStatus = new System.Windows.Forms.PictureBox();
            this.panelServiceButtons = new System.Windows.Forms.Panel();
            this.panelServiceButtonContainer = new System.Windows.Forms.Panel();
            this.btnStartService = new MaterialSkin.Controls.MaterialButton();
            this.btnReStartService = new MaterialSkin.Controls.MaterialButton();
            this.buttonRefreshServiceState = new MaterialSkin.Controls.MaterialButton();
            this.btnStopService = new MaterialSkin.Controls.MaterialButton();
            this.panelConsole = new System.Windows.Forms.Panel();
            this.txtOutputConsole = new System.Windows.Forms.RichTextBox();
            this.panelClearConsole = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelStatusInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).BeginInit();
            this.panelServiceButtons.SuspendLayout();
            this.panelServiceButtonContainer.SuspendLayout();
            this.panelConsole.SuspendLayout();
            this.panelClearConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearManagerConsole
            // 
            this.btnClearManagerConsole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearManagerConsole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearManagerConsole.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearManagerConsole.Depth = 0;
            this.btnClearManagerConsole.HighEmphasis = true;
            this.btnClearManagerConsole.Icon = null;
            this.btnClearManagerConsole.Location = new System.Drawing.Point(334, 7);
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
            // panelStatusInfo
            // 
            this.panelStatusInfo.Controls.Add(this.labelServiceStatus);
            this.panelStatusInfo.Controls.Add(this.pictureServiceStatus);
            this.panelStatusInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatusInfo.Location = new System.Drawing.Point(0, 0);
            this.panelStatusInfo.Name = "panelStatusInfo";
            this.panelStatusInfo.Size = new System.Drawing.Size(866, 123);
            this.panelStatusInfo.TabIndex = 42;
            // 
            // labelServiceStatus
            // 
            this.labelServiceStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServiceStatus.AutoSize = true;
            this.labelServiceStatus.Depth = 0;
            this.labelServiceStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelServiceStatus.Location = new System.Drawing.Point(357, 100);
            this.labelServiceStatus.Margin = new System.Windows.Forms.Padding(3, 100, 3, 0);
            this.labelServiceStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(171, 19);
            this.labelServiceStatus.TabIndex = 40;
            this.labelServiceStatus.Text = " Stan usługi: Nieznany...";
            this.labelServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureServiceStatus
            // 
            this.pictureServiceStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureServiceStatus.Enabled = false;
            this.pictureServiceStatus.Image = global::CodeCompilerServiceManager.Properties.Resources.cogAnimation;
            this.pictureServiceStatus.Location = new System.Drawing.Point(388, 14);
            this.pictureServiceStatus.Name = "pictureServiceStatus";
            this.pictureServiceStatus.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pictureServiceStatus.Size = new System.Drawing.Size(107, 81);
            this.pictureServiceStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureServiceStatus.TabIndex = 39;
            this.pictureServiceStatus.TabStop = false;
            // 
            // panelServiceButtons
            // 
            this.panelServiceButtons.Controls.Add(this.panelServiceButtonContainer);
            this.panelServiceButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelServiceButtons.Location = new System.Drawing.Point(0, 123);
            this.panelServiceButtons.Name = "panelServiceButtons";
            this.panelServiceButtons.Size = new System.Drawing.Size(866, 63);
            this.panelServiceButtons.TabIndex = 43;
            // 
            // panelServiceButtonContainer
            // 
            this.panelServiceButtonContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelServiceButtonContainer.Controls.Add(this.btnStartService);
            this.panelServiceButtonContainer.Controls.Add(this.btnReStartService);
            this.panelServiceButtonContainer.Controls.Add(this.buttonRefreshServiceState);
            this.panelServiceButtonContainer.Controls.Add(this.btnStopService);
            this.panelServiceButtonContainer.Location = new System.Drawing.Point(265, 1);
            this.panelServiceButtonContainer.Name = "panelServiceButtonContainer";
            this.panelServiceButtonContainer.Size = new System.Drawing.Size(341, 66);
            this.panelServiceButtonContainer.TabIndex = 42;
            // 
            // btnStartService
            // 
            this.btnStartService.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartService.AutoSize = false;
            this.btnStartService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStartService.Depth = 0;
            this.btnStartService.HighEmphasis = true;
            this.btnStartService.Icon = global::CodeCompilerServiceManager.Properties.Resources.play;
            this.btnStartService.Location = new System.Drawing.Point(77, 10);
            this.btnStartService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStartService.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStartService.Size = new System.Drawing.Size(38, 36);
            this.btnStartService.TabIndex = 39;
            this.btnStartService.Text = "Uruchom usługę";
            this.toolTip1.SetToolTip(this.btnStartService, "Uruchom usługę");
            this.btnStartService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStartService.UseAccentColor = false;
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnReStartService
            // 
            this.btnReStartService.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReStartService.AutoSize = false;
            this.btnReStartService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReStartService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReStartService.Depth = 0;
            this.btnReStartService.HighEmphasis = true;
            this.btnReStartService.Icon = global::CodeCompilerServiceManager.Properties.Resources.restart;
            this.btnReStartService.Location = new System.Drawing.Point(169, 10);
            this.btnReStartService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReStartService.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReStartService.Name = "btnReStartService";
            this.btnReStartService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReStartService.Size = new System.Drawing.Size(38, 36);
            this.btnReStartService.TabIndex = 41;
            this.btnReStartService.Text = "Uruchom ponowne usługę";
            this.toolTip1.SetToolTip(this.btnReStartService, "Uruchom ponowne usługę");
            this.btnReStartService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReStartService.UseAccentColor = false;
            this.btnReStartService.UseVisualStyleBackColor = true;
            this.btnReStartService.Click += new System.EventHandler(this.btnReStartService_Click);
            // 
            // buttonRefreshServiceState
            // 
            this.buttonRefreshServiceState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRefreshServiceState.AutoSize = false;
            this.buttonRefreshServiceState.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefreshServiceState.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonRefreshServiceState.Depth = 0;
            this.buttonRefreshServiceState.HighEmphasis = true;
            this.buttonRefreshServiceState.Icon = global::CodeCompilerServiceManager.Properties.Resources.refresh;
            this.buttonRefreshServiceState.Location = new System.Drawing.Point(225, 10);
            this.buttonRefreshServiceState.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonRefreshServiceState.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefreshServiceState.Name = "buttonRefreshServiceState";
            this.buttonRefreshServiceState.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonRefreshServiceState.Size = new System.Drawing.Size(38, 36);
            this.buttonRefreshServiceState.TabIndex = 38;
            this.buttonRefreshServiceState.Text = "Ręcznie odśwież stan usługi";
            this.toolTip1.SetToolTip(this.buttonRefreshServiceState, "Ręcznie odśwież stan usługi");
            this.buttonRefreshServiceState.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonRefreshServiceState.UseAccentColor = false;
            this.buttonRefreshServiceState.UseVisualStyleBackColor = true;
            this.buttonRefreshServiceState.Click += new System.EventHandler(this.buttonRefreshServiceState_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStopService.AutoSize = false;
            this.btnStopService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStopService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStopService.Depth = 0;
            this.btnStopService.HighEmphasis = true;
            this.btnStopService.Icon = global::CodeCompilerServiceManager.Properties.Resources.stop;
            this.btnStopService.Location = new System.Drawing.Point(123, 10);
            this.btnStopService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStopService.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStopService.Size = new System.Drawing.Size(38, 36);
            this.btnStopService.TabIndex = 40;
            this.btnStopService.Text = "Zatrzymaj usługę";
            this.toolTip1.SetToolTip(this.btnStopService, "Zatrzymaj usługę");
            this.btnStopService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStopService.UseAccentColor = false;
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // panelConsole
            // 
            this.panelConsole.Controls.Add(this.txtOutputConsole);
            this.panelConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConsole.Location = new System.Drawing.Point(0, 186);
            this.panelConsole.Name = "panelConsole";
            this.panelConsole.Padding = new System.Windows.Forms.Padding(10);
            this.panelConsole.Size = new System.Drawing.Size(866, 383);
            this.panelConsole.TabIndex = 44;
            // 
            // txtOutputConsole
            // 
            this.txtOutputConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutputConsole.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutputConsole.Location = new System.Drawing.Point(10, 10);
            this.txtOutputConsole.Name = "txtOutputConsole";
            this.txtOutputConsole.ReadOnly = true;
            this.txtOutputConsole.Size = new System.Drawing.Size(846, 363);
            this.txtOutputConsole.TabIndex = 42;
            this.txtOutputConsole.Text = "";
            // 
            // panelClearConsole
            // 
            this.panelClearConsole.Controls.Add(this.btnClearManagerConsole);
            this.panelClearConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelClearConsole.Location = new System.Drawing.Point(0, 569);
            this.panelClearConsole.Name = "panelClearConsole";
            this.panelClearConsole.Size = new System.Drawing.Size(866, 49);
            this.panelClearConsole.TabIndex = 42;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.WindowText;
            this.toolTip1.ForeColor = System.Drawing.Color.White;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_draw);
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelConsole);
            this.Controls.Add(this.panelClearConsole);
            this.Controls.Add(this.panelServiceButtons);
            this.Controls.Add(this.panelStatusInfo);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(866, 618);
            this.panelStatusInfo.ResumeLayout(false);
            this.panelStatusInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).EndInit();
            this.panelServiceButtons.ResumeLayout(false);
            this.panelServiceButtonContainer.ResumeLayout(false);
            this.panelConsole.ResumeLayout(false);
            this.panelClearConsole.ResumeLayout(false);
            this.panelClearConsole.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnClearManagerConsole;
        private Panel panelStatusInfo;
        private MaterialSkin.Controls.MaterialLabel labelServiceStatus;
        private PictureBox pictureServiceStatus;
        private Panel panelServiceButtons;
        private MaterialSkin.Controls.MaterialButton btnReStartService;
        private MaterialSkin.Controls.MaterialButton btnStopService;
        private MaterialSkin.Controls.MaterialButton btnStartService;
        private MaterialSkin.Controls.MaterialButton buttonRefreshServiceState;
        private Panel panelConsole;
        private Panel panelClearConsole;
        private Panel panelServiceButtonContainer;
        private ToolTip toolTip1;
        private RichTextBox txtOutputConsole;
    }
}
