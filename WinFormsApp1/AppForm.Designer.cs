namespace CodeCompilerServiceManager
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
            this.numericOperationTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelOperationTimeout = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownIntervalRefresh = new System.Windows.Forms.NumericUpDown();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOperationTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(87, 78);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(174, 23);
            this.btnStartService.TabIndex = 0;
            this.btnStartService.Text = "Uruchom usługę";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(87, 107);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(175, 23);
            this.btnStopService.TabIndex = 1;
            this.btnStopService.Text = "Zatrzymaj usługę";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnReStartService
            // 
            this.btnReStartService.Location = new System.Drawing.Point(87, 136);
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
            this.labelServiceStatus.Location = new System.Drawing.Point(87, 50);
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(68, 15);
            this.labelServiceStatus.TabIndex = 3;
            this.labelServiceStatus.Text = "Stan usługi:";
            // 
            // pictureServiceStatus
            // 
            this.pictureServiceStatus.Image = global::CodeCompilerServiceManager.Properties.Resources.yellow;
            this.pictureServiceStatus.Location = new System.Drawing.Point(87, 12);
            this.pictureServiceStatus.Name = "pictureServiceStatus";
            this.pictureServiceStatus.Size = new System.Drawing.Size(68, 35);
            this.pictureServiceStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureServiceStatus.TabIndex = 4;
            this.pictureServiceStatus.TabStop = false;
            // 
            // numericOperationTimeout
            // 
            this.numericOperationTimeout.Location = new System.Drawing.Point(96, 260);
            this.numericOperationTimeout.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numericOperationTimeout.Name = "numericOperationTimeout";
            this.numericOperationTimeout.Size = new System.Drawing.Size(70, 23);
            this.numericOperationTimeout.TabIndex = 6;
            this.numericOperationTimeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericOperationTimeout.ValueChanged += new System.EventHandler(this.numericOperationTimeout_ValueChanged);
            // 
            // labelOperationTimeout
            // 
            this.labelOperationTimeout.AutoSize = true;
            this.labelOperationTimeout.Location = new System.Drawing.Point(96, 242);
            this.labelOperationTimeout.Name = "labelOperationTimeout";
            this.labelOperationTimeout.Size = new System.Drawing.Size(233, 15);
            this.labelOperationTimeout.TabIndex = 7;
            this.labelOperationTimeout.Text = "Timeout wykonanej akcji na usłudze (ms):  ";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(96, 193);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(213, 15);
            this.labelInterval.TabIndex = 8;
            this.labelInterval.Text = "Interwał odświeżania stanu usługi (ms):";
            // 
            // numericUpDownIntervalRefresh
            // 
            this.numericUpDownIntervalRefresh.Location = new System.Drawing.Point(96, 211);
            this.numericUpDownIntervalRefresh.Maximum = new decimal(new int[] {
            180000,
            0,
            0,
            0});
            this.numericUpDownIntervalRefresh.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownIntervalRefresh.Name = "numericUpDownIntervalRefresh";
            this.numericUpDownIntervalRefresh.Size = new System.Drawing.Size(70, 23);
            this.numericUpDownIntervalRefresh.TabIndex = 9;
            this.numericUpDownIntervalRefresh.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownIntervalRefresh.ValueChanged += new System.EventHandler(this.numericUpDownIntervalRefresh_ValueChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(96, 306);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(648, 96);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Zapisz ustawienia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(364, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Restart ustawień";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.numericUpDownIntervalRefresh);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelOperationTimeout);
            this.Controls.Add(this.numericOperationTimeout);
            this.Controls.Add(this.pictureServiceStatus);
            this.Controls.Add(this.labelServiceStatus);
            this.Controls.Add(this.btnReStartService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Name = "AppForm";
            this.Text = "Code Compiler Service Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureServiceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOperationTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartService;
        private Button btnStopService;
        private Button btnReStartService;
        private Label labelServiceStatus;
        private PictureBox pictureServiceStatus;
        private NumericUpDown numericOperationTimeout;
        private Label labelOperationTimeout;
        private Label labelInterval;
        private NumericUpDown numericUpDownIntervalRefresh;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
    }
}