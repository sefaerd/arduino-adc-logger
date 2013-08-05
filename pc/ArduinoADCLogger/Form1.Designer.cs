namespace WindowsFormsApplication1
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxSerialPort = new System.Windows.Forms.TextBox();
            this.numericUpDownSerialBaud = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDownSamplesToShow = new System.Windows.Forms.NumericUpDown();
            this.labelSPS = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelTotalSampled = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.numericUpDownStartSample = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBoxDraw = new System.Windows.Forms.CheckBox();
            this.labelBytes = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.checkBoxGenerateRandom = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSerialBaud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSamplesToShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartSample)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(94, 10);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(76, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 415);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 106);
            this.textBox1.TabIndex = 1;
            // 
            // textBoxSerialPort
            // 
            this.textBoxSerialPort.Location = new System.Drawing.Point(13, 12);
            this.textBoxSerialPort.Name = "textBoxSerialPort";
            this.textBoxSerialPort.Size = new System.Drawing.Size(75, 20);
            this.textBoxSerialPort.TabIndex = 2;
            this.textBoxSerialPort.Text = "COM3";
            // 
            // numericUpDownSerialBaud
            // 
            this.numericUpDownSerialBaud.Location = new System.Drawing.Point(13, 38);
            this.numericUpDownSerialBaud.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownSerialBaud.Name = "numericUpDownSerialBaud";
            this.numericUpDownSerialBaud.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownSerialBaud.TabIndex = 3;
            this.numericUpDownSerialBaud.Value = new decimal(new int[] {
            9600,
            0,
            0,
            0});
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(12, 527);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(178, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 436);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // numericUpDownSamplesToShow
            // 
            this.numericUpDownSamplesToShow.Location = new System.Drawing.Point(785, 88);
            this.numericUpDownSamplesToShow.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownSamplesToShow.Name = "numericUpDownSamplesToShow";
            this.numericUpDownSamplesToShow.Size = new System.Drawing.Size(107, 20);
            this.numericUpDownSamplesToShow.TabIndex = 7;
            this.numericUpDownSamplesToShow.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSamplesToShow.ValueChanged += new System.EventHandler(this.numericUpDownSamplesToShow_ValueChanged);
            // 
            // labelSPS
            // 
            this.labelSPS.AutoSize = true;
            this.labelSPS.Location = new System.Drawing.Point(175, 96);
            this.labelSPS.Name = "labelSPS";
            this.labelSPS.Size = new System.Drawing.Size(37, 13);
            this.labelSPS.TabIndex = 8;
            this.labelSPS.Text = "0 SPS";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // labelTotalSampled
            // 
            this.labelTotalSampled.AutoSize = true;
            this.labelTotalSampled.Location = new System.Drawing.Point(268, 96);
            this.labelTotalSampled.Name = "labelTotalSampled";
            this.labelTotalSampled.Size = new System.Drawing.Size(56, 13);
            this.labelTotalSampled.TabIndex = 9;
            this.labelTotalSampled.Text = "0 Samples";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(178, 25);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(714, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // numericUpDownStartSample
            // 
            this.numericUpDownStartSample.Location = new System.Drawing.Point(656, 88);
            this.numericUpDownStartSample.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownStartSample.Name = "numericUpDownStartSample";
            this.numericUpDownStartSample.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownStartSample.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(94, 527);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Pause";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBoxDraw
            // 
            this.checkBoxDraw.AutoSize = true;
            this.checkBoxDraw.Checked = true;
            this.checkBoxDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDraw.Location = new System.Drawing.Point(178, 76);
            this.checkBoxDraw.Name = "checkBoxDraw";
            this.checkBoxDraw.Size = new System.Drawing.Size(51, 17);
            this.checkBoxDraw.TabIndex = 13;
            this.checkBoxDraw.Text = "Draw";
            this.checkBoxDraw.UseVisualStyleBackColor = true;
            this.checkBoxDraw.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // labelBytes
            // 
            this.labelBytes.AutoSize = true;
            this.labelBytes.Location = new System.Drawing.Point(475, 96);
            this.labelBytes.Name = "labelBytes";
            this.labelBytes.Size = new System.Drawing.Size(65, 13);
            this.labelBytes.TabIndex = 14;
            this.labelBytes.Text = "0 bytes read";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(94, 35);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(76, 23);
            this.buttonDisconnect.TabIndex = 15;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBoxGenerateRandom
            // 
            this.checkBoxGenerateRandom.AutoSize = true;
            this.checkBoxGenerateRandom.Location = new System.Drawing.Point(235, 76);
            this.checkBoxGenerateRandom.Name = "checkBoxGenerateRandom";
            this.checkBoxGenerateRandom.Size = new System.Drawing.Size(132, 17);
            this.checkBoxGenerateRandom.TabIndex = 16;
            this.checkBoxGenerateRandom.Text = "Generate random data";
            this.checkBoxGenerateRandom.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Show from sample #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(782, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Num samples to show";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(591, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "PNG";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(94, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "Load";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 562);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxGenerateRandom);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.labelBytes);
            this.Controls.Add(this.checkBoxDraw);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numericUpDownStartSample);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.labelTotalSampled);
            this.Controls.Add(this.labelSPS);
            this.Controls.Add(this.numericUpDownSamplesToShow);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numericUpDownSerialBaud);
            this.Controls.Add(this.textBoxSerialPort);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonConnect);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ArduinoADCLogger";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSerialBaud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSamplesToShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartSample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxSerialPort;
        private System.Windows.Forms.NumericUpDown numericUpDownSerialBaud;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownSamplesToShow;
        private System.Windows.Forms.Label labelSPS;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelTotalSampled;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.NumericUpDown numericUpDownStartSample;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBoxDraw;
        private System.Windows.Forms.Label labelBytes;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.CheckBox checkBoxGenerateRandom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

