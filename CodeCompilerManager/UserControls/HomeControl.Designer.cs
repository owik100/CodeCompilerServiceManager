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
            this.materialLabelOutputFolder = new MaterialSkin.Controls.MaterialLabel();
            this.labelInputFolder = new MaterialSkin.Controls.MaterialLabel();
            this.panelServiceButtons = new System.Windows.Forms.Panel();
            this.panel1OutputFolder = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.materialButtonDeleteOutputPath = new MaterialSkin.Controls.MaterialButton();
            this.buttonOpenOutputFolder = new MaterialSkin.Controls.MaterialButton();
            this.panelServiceButtonContainer = new System.Windows.Forms.Panel();
            this.panel1InputFolder = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialButtonDeleteInputPath = new MaterialSkin.Controls.MaterialButton();
            this.buttonOpenInputFolder = new MaterialSkin.Controls.MaterialButton();
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
            this.panel1OutputFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelServiceButtonContainer.SuspendLayout();
            this.panel1InputFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // materialLabelOutputFolder
            // 
            this.materialLabelOutputFolder.AutoSize = true;
            this.materialLabelOutputFolder.Depth = 0;
            this.materialLabelOutputFolder.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabelOutputFolder.Location = new System.Drawing.Point(60, 18);
            this.materialLabelOutputFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelOutputFolder.Name = "materialLabelOutputFolder";
            this.materialLabelOutputFolder.Size = new System.Drawing.Size(122, 19);
            this.materialLabelOutputFolder.TabIndex = 46;
            this.materialLabelOutputFolder.Text = "Folder wyjściowy";
            // 
            // labelInputFolder
            // 
            this.labelInputFolder.AutoSize = true;
            this.labelInputFolder.Depth = 0;
            this.labelInputFolder.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelInputFolder.Location = new System.Drawing.Point(72, 18);
            this.labelInputFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelInputFolder.Name = "labelInputFolder";
            this.labelInputFolder.Size = new System.Drawing.Size(122, 19);
            this.labelInputFolder.TabIndex = 45;
            this.labelInputFolder.Text = "Folder wejściowy";
            // 
            // panelServiceButtons
            // 
            this.panelServiceButtons.Controls.Add(this.panel1OutputFolder);
            this.panelServiceButtons.Controls.Add(this.panelServiceButtonContainer);
            this.panelServiceButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelServiceButtons.Location = new System.Drawing.Point(0, 123);
            this.panelServiceButtons.Name = "panelServiceButtons";
            this.panelServiceButtons.Size = new System.Drawing.Size(866, 63);
            this.panelServiceButtons.TabIndex = 43;
            // 
            // panel1OutputFolder
            // 
            this.panel1OutputFolder.BackColor = System.Drawing.SystemColors.Control;
            this.panel1OutputFolder.Controls.Add(this.pictureBox2);
            this.panel1OutputFolder.Controls.Add(this.materialButtonDeleteOutputPath);
            this.panel1OutputFolder.Controls.Add(this.buttonOpenOutputFolder);
            this.panel1OutputFolder.Controls.Add(this.materialLabelOutputFolder);
            this.panel1OutputFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1OutputFolder.Location = new System.Drawing.Point(533, 0);
            this.panel1OutputFolder.Name = "panel1OutputFolder";
            this.panel1OutputFolder.Size = new System.Drawing.Size(333, 63);
            this.panel1OutputFolder.TabIndex = 47;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CodeCompilerServiceManager.Properties.Resources.arrow_collapse_up;
            this.pictureBox2.Location = new System.Drawing.Point(28, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 29);
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // materialButtonDeleteOutputPath
            // 
            this.materialButtonDeleteOutputPath.AutoSize = false;
            this.materialButtonDeleteOutputPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonDeleteOutputPath.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonDeleteOutputPath.Depth = 0;
            this.materialButtonDeleteOutputPath.HighEmphasis = true;
            this.materialButtonDeleteOutputPath.Icon = global::CodeCompilerServiceManager.Properties.Resources.delete;
            this.materialButtonDeleteOutputPath.Location = new System.Drawing.Point(241, 6);
            this.materialButtonDeleteOutputPath.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonDeleteOutputPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonDeleteOutputPath.Name = "materialButtonDeleteOutputPath";
            this.materialButtonDeleteOutputPath.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonDeleteOutputPath.Size = new System.Drawing.Size(44, 37);
            this.materialButtonDeleteOutputPath.TabIndex = 59;
            this.toolTip1.SetToolTip(this.materialButtonDeleteOutputPath, "Usuń pliki w folderze wyjściowym");
            this.materialButtonDeleteOutputPath.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonDeleteOutputPath.UseAccentColor = true;
            this.materialButtonDeleteOutputPath.UseVisualStyleBackColor = true;
            this.materialButtonDeleteOutputPath.Click += new System.EventHandler(this.materialButtonDeleteOutputPath_Click);
            // 
            // buttonOpenOutputFolder
            // 
            this.buttonOpenOutputFolder.AutoSize = false;
            this.buttonOpenOutputFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenOutputFolder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonOpenOutputFolder.Depth = 0;
            this.buttonOpenOutputFolder.HighEmphasis = true;
            this.buttonOpenOutputFolder.Icon = global::CodeCompilerServiceManager.Properties.Resources.folder_open;
            this.buttonOpenOutputFolder.Location = new System.Drawing.Point(189, 6);
            this.buttonOpenOutputFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonOpenOutputFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOpenOutputFolder.Name = "buttonOpenOutputFolder";
            this.buttonOpenOutputFolder.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonOpenOutputFolder.Size = new System.Drawing.Size(44, 37);
            this.buttonOpenOutputFolder.TabIndex = 58;
            this.toolTip1.SetToolTip(this.buttonOpenOutputFolder, "Otwórz folder wyjściowy");
            this.buttonOpenOutputFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonOpenOutputFolder.UseAccentColor = true;
            this.buttonOpenOutputFolder.UseVisualStyleBackColor = true;
            this.buttonOpenOutputFolder.Click += new System.EventHandler(this.buttonOpenOutputFolder_Click);
            // 
            // panelServiceButtonContainer
            // 
            this.panelServiceButtonContainer.BackColor = System.Drawing.SystemColors.Control;
            this.panelServiceButtonContainer.Controls.Add(this.panel1InputFolder);
            this.panelServiceButtonContainer.Controls.Add(this.btnStartService);
            this.panelServiceButtonContainer.Controls.Add(this.btnReStartService);
            this.panelServiceButtonContainer.Controls.Add(this.buttonRefreshServiceState);
            this.panelServiceButtonContainer.Controls.Add(this.btnStopService);
            this.panelServiceButtonContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelServiceButtonContainer.Location = new System.Drawing.Point(0, 0);
            this.panelServiceButtonContainer.Name = "panelServiceButtonContainer";
            this.panelServiceButtonContainer.Size = new System.Drawing.Size(866, 63);
            this.panelServiceButtonContainer.TabIndex = 42;
            // 
            // panel1InputFolder
            // 
            this.panel1InputFolder.BackColor = System.Drawing.SystemColors.Control;
            this.panel1InputFolder.Controls.Add(this.pictureBox1);
            this.panel1InputFolder.Controls.Add(this.materialButtonDeleteInputPath);
            this.panel1InputFolder.Controls.Add(this.buttonOpenInputFolder);
            this.panel1InputFolder.Controls.Add(this.labelInputFolder);
            this.panel1InputFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1InputFolder.Location = new System.Drawing.Point(0, 0);
            this.panel1InputFolder.Name = "panel1InputFolder";
            this.panel1InputFolder.Size = new System.Drawing.Size(333, 63);
            this.panel1InputFolder.TabIndex = 42;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CodeCompilerServiceManager.Properties.Resources.arrow_collapse_down;
            this.pictureBox1.Location = new System.Drawing.Point(40, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 29);
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // materialButtonDeleteInputPath
            // 
            this.materialButtonDeleteInputPath.AutoSize = false;
            this.materialButtonDeleteInputPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonDeleteInputPath.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonDeleteInputPath.Depth = 0;
            this.materialButtonDeleteInputPath.HighEmphasis = true;
            this.materialButtonDeleteInputPath.Icon = global::CodeCompilerServiceManager.Properties.Resources.delete;
            this.materialButtonDeleteInputPath.Location = new System.Drawing.Point(253, 7);
            this.materialButtonDeleteInputPath.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonDeleteInputPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonDeleteInputPath.Name = "materialButtonDeleteInputPath";
            this.materialButtonDeleteInputPath.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonDeleteInputPath.Size = new System.Drawing.Size(44, 37);
            this.materialButtonDeleteInputPath.TabIndex = 58;
            this.toolTip1.SetToolTip(this.materialButtonDeleteInputPath, "Usuń pliki w folderze wejściowym");
            this.materialButtonDeleteInputPath.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonDeleteInputPath.UseAccentColor = true;
            this.materialButtonDeleteInputPath.UseVisualStyleBackColor = true;
            this.materialButtonDeleteInputPath.Click += new System.EventHandler(this.materialButtonDeleteInputPath_Click);
            // 
            // buttonOpenInputFolder
            // 
            this.buttonOpenInputFolder.AutoSize = false;
            this.buttonOpenInputFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenInputFolder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonOpenInputFolder.Depth = 0;
            this.buttonOpenInputFolder.HighEmphasis = true;
            this.buttonOpenInputFolder.Icon = global::CodeCompilerServiceManager.Properties.Resources.folder_open;
            this.buttonOpenInputFolder.Location = new System.Drawing.Point(201, 7);
            this.buttonOpenInputFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonOpenInputFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOpenInputFolder.Name = "buttonOpenInputFolder";
            this.buttonOpenInputFolder.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonOpenInputFolder.Size = new System.Drawing.Size(44, 37);
            this.buttonOpenInputFolder.TabIndex = 57;
            this.toolTip1.SetToolTip(this.buttonOpenInputFolder, "Otwórz folder wejściowy");
            this.buttonOpenInputFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonOpenInputFolder.UseAccentColor = true;
            this.buttonOpenInputFolder.UseVisualStyleBackColor = true;
            this.buttonOpenInputFolder.Click += new System.EventHandler(this.buttonOpenInputFolder_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartService.AutoSize = false;
            this.btnStartService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStartService.Depth = 0;
            this.btnStartService.Enabled = false;
            this.btnStartService.HighEmphasis = true;
            this.btnStartService.Icon = global::CodeCompilerServiceManager.Properties.Resources.play;
            this.btnStartService.Location = new System.Drawing.Point(340, 8);
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
            this.btnReStartService.Location = new System.Drawing.Point(432, 8);
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
            this.buttonRefreshServiceState.Location = new System.Drawing.Point(488, 8);
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
            this.btnStopService.Enabled = false;
            this.btnStopService.HighEmphasis = true;
            this.btnStopService.Icon = global::CodeCompilerServiceManager.Properties.Resources.stop;
            this.btnStopService.Location = new System.Drawing.Point(386, 8);
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
            this.txtOutputConsole.ForeColor = System.Drawing.SystemColors.WindowFrame;
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
            this.panel1OutputFolder.ResumeLayout(false);
            this.panel1OutputFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelServiceButtonContainer.ResumeLayout(false);
            this.panel1InputFolder.ResumeLayout(false);
            this.panel1InputFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private MaterialSkin.Controls.MaterialLabel materialLabelOutputFolder;
        private MaterialSkin.Controls.MaterialLabel labelInputFolder;
        private Panel panel1OutputFolder;
        private Panel panel1InputFolder;
        private MaterialSkin.Controls.MaterialButton buttonOpenOutputFolder;
        private MaterialSkin.Controls.MaterialButton buttonOpenInputFolder;
        private MaterialSkin.Controls.MaterialButton materialButtonDeleteInputPath;
        private MaterialSkin.Controls.MaterialButton materialButtonDeleteOutputPath;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
