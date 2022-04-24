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
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelSlideMenuBottom = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonLibrarySettings = new System.Windows.Forms.Button();
            this.buttonServiceSettings = new System.Windows.Forms.Button();
            this.buttonManagerSettings = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.labelTitleBar = new System.Windows.Forms.Label();
            this.panelDesktopParent = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panelSlideMenuBottom.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelSideMenu.Controls.Add(this.panelSlideMenuBottom);
            this.panelSideMenu.Controls.Add(this.buttonInfo);
            this.panelSideMenu.Controls.Add(this.buttonLibrarySettings);
            this.panelSideMenu.Controls.Add(this.buttonServiceSettings);
            this.panelSideMenu.Controls.Add(this.buttonManagerSettings);
            this.panelSideMenu.Controls.Add(this.buttonHome);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(3, 24);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(220, 693);
            this.panelSideMenu.TabIndex = 39;
            // 
            // panelSlideMenuBottom
            // 
            this.panelSlideMenuBottom.Controls.Add(this.buttonExit);
            this.panelSlideMenuBottom.Controls.Add(this.buttonRestart);
            this.panelSlideMenuBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSlideMenuBottom.Location = new System.Drawing.Point(0, 593);
            this.panelSlideMenuBottom.Name = "panelSlideMenuBottom";
            this.panelSlideMenuBottom.Size = new System.Drawing.Size(220, 100);
            this.panelSlideMenuBottom.TabIndex = 9;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonExit.Location = new System.Drawing.Point(110, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(110, 100);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "Wyjście";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonRestart.FlatAppearance.BorderSize = 0;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRestart.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonRestart.Location = new System.Drawing.Point(0, 0);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(110, 100);
            this.buttonRestart.TabIndex = 9;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
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
            this.panelLogo.BackColor = System.Drawing.Color.White;
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
            this.panelTitleBar.Location = new System.Drawing.Point(223, 24);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(798, 75);
            this.panelTitleBar.TabIndex = 40;
            // 
            // labelTitleBar
            // 
            this.labelTitleBar.BackColor = System.Drawing.Color.Black;
            this.labelTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitleBar.ForeColor = System.Drawing.Color.White;
            this.labelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.labelTitleBar.Name = "labelTitleBar";
            this.labelTitleBar.Size = new System.Drawing.Size(798, 75);
            this.labelTitleBar.TabIndex = 0;
            this.labelTitleBar.Text = "Home";
            this.labelTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDesktopParent
            // 
            this.panelDesktopParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopParent.Location = new System.Drawing.Point(223, 99);
            this.panelDesktopParent.Name = "panelDesktopParent";
            this.panelDesktopParent.Size = new System.Drawing.Size(798, 618);
            this.panelDesktopParent.TabIndex = 41;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(this.panelDesktopParent);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelSideMenu);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "AppForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "Code Compiler Service Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppForm_FormClosing);
            this.panelSideMenu.ResumeLayout(false);
            this.panelSlideMenuBottom.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelSideMenu;
        private Button buttonHome;
        private Panel panelLogo;
        private Button buttonInfo;
        private Button buttonLibrarySettings;
        private Button buttonServiceSettings;
        private Button buttonManagerSettings;
        private Panel panelTitleBar;
        private Label labelTitleBar;
        private Panel panelDesktopParent;
        private Panel panelSlideMenuBottom;
        private Button buttonExit;
        private Button buttonRestart;
    }
}