using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string rxString;
        public int maxNumSamples;
        public int[] samples;
        public int samplesIdx;
        public int lastSamplesIdxForSPS;
        public int bytesRead;
        public int[] tempBytes;
        public int tempBytesIdx;
        public int tempBytesIdxNext;
        //public Point[] points;
        Random random;
        public bool quit;
        int maxSamplesToRender;

        public Form1()
        {
            InitializeComponent();

            maxNumSamples = 1024 * 1024 * 5; // 5Msamples
            samples = new int[maxNumSamples];
            tempBytes = new int[maxNumSamples * 2];
            samplesIdx = 0;
            lastSamplesIdxForSPS = 0;
            bytesRead = 0;
            tempBytesIdx = 0;
            tempBytesIdxNext = 0;
            quit = false;
            random = new Random();
            maxSamplesToRender = pictureBox1.ClientRectangle.Width;
            numericUpDownSamplesToShow.Value = maxSamplesToRender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = textBoxSerialPort.Text;
            serialPort1.BaudRate = (int)numericUpDownSerialBaud.Value;
            serialPort1.DtrEnable = true;
            serialPort1.Open();
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (quit)
            {
                serialPort1.Close();
                return;
            }
            // TODO: Buffer this reading into an array 
            int numRead = 0;
            for (int n = 0; n < serialPort1.BytesToRead; n++)
            {
                tempBytes[tempBytesIdx++] = serialPort1.ReadByte();
                numRead++;
            }
            //rxString = serialPort1.ReadExisting();
            bytesRead += numRead; // rxString.Length;
            //this.Invoke(new EventHandler(DisplayText));
            this.Invoke(new EventHandler(LogData));
        }

        private void LogData(object sender, EventArgs e)
        {
            if (tempBytesIdx - tempBytesIdxNext < 2)
            {
                return;
            }
            int count = ((tempBytesIdx - tempBytesIdxNext) / 2);
            int low, high;
            for (int n = 0; n < count; n++)
            {
                low = tempBytes[tempBytesIdxNext++];
                high = tempBytes[tempBytesIdxNext++];
                //For little-endian, what you want is
                //int i = byte[i] | (byte[i+1] << 8);
                //and for big-endian:
                int i = (high << 8) | low;
                if (i > 1023)
                {
                    tempBytesIdxNext--;
                }
                else
                {
                    if (samplesIdx >= maxNumSamples - 1)
                    {
                        return;
                    }
                    else
                    {
                        samples[samplesIdx++] = 1024 - i;
                    }
                }
            }
            labelBytes.Text = bytesRead + " bytes read";
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox1.AppendText(rxString);
            labelBytes.Text = bytesRead + " bytes read";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBoxGenerateRandom.Checked)
            {
                samples[samplesIdx++] = random.Next(0, 1023);
            }
            if (samplesIdx >= maxNumSamples - 1)
            {
                timer1.Stop();
            }
            //panel1.Invalidate(true);
            if (checkBoxDraw.Checked)
            {
                pictureBox1.Invalidate(true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as PictureBox;
            var g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.Lavender), p.DisplayRectangle);

            if (samplesIdx > 0)
            {
                int n = samplesIdx - (int)numericUpDownSamplesToShow.Value - 1;
                int numSamplesToDraw = (int)numericUpDownSamplesToShow.Value;
                int endIdx = samplesIdx - 1;
                if ((int)numericUpDownStartSample.Value > 0)
                {
                    n = (int)numericUpDownStartSample.Value;
                    endIdx = n + (int)numericUpDownSamplesToShow.Value;
                    if (n > samplesIdx - (int)numericUpDownSamplesToShow.Value)
                    {
                        n = samplesIdx - (int)numericUpDownSamplesToShow.Value;
                    }
                }
                if (n < 0)
                {
                    n = 0;
                    numSamplesToDraw = samplesIdx-1;
                    endIdx = samplesIdx - 1;
                }
                Pen pen;
                bool zoom = numSamplesToDraw > maxSamplesToRender;
                if (zoom)
                {
                    pen = Pens.Red;
                }
                else
                {
                    pen = Pens.Blue;
                }
                //int i = 0;
                //int current = i * numSamplesToDraw / maxSamplesToRender;
                int realNumSamplesToDraw = numSamplesToDraw;
                if (zoom)
                {
                    realNumSamplesToDraw = maxSamplesToRender;
                }
                int m = n;
                //for (; n < endIdx; n++)
                int pW = (p.ClientRectangle.Width - 1);
                int pH = (p.ClientRectangle.Height - 1);

                float x1, x2, y1, y2;
                x1 = 0;
                y1 = (p.Height * samples[m]) / 1024;

                for (int i = 0; i < realNumSamplesToDraw; i++)
                {
                    //x1 = n * p.Width / samplesIdx;
                    //y1 = p.Height * samples[n] / 1024;
                    x2 = ((i + 1) * pW) / realNumSamplesToDraw;
                    y2 = pH * samples[m + 1] / 1024;

                    g.DrawLine(pen, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                    if (zoom)
                    {
                        m = n + (i * numSamplesToDraw) / maxSamplesToRender;
                    }
                    else
                    {
                        m++;
                    }
                    //i++;
                }
            }
            g.DrawLine(Pens.Green, 0, (int)(0.5f * p.ClientRectangle.Height / 1.1f), p.ClientRectangle.Width, (int)(0.5 * p.ClientRectangle.Height / 1.1));

            String drawString = "0.5V with AREF INTERNAL (1.1V)";

            // Create font and brush.
            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(200, Color.Green));

            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(0, (int)(0.5f * p.ClientRectangle.Height / 1.1f));

            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int sps = samplesIdx - lastSamplesIdxForSPS;
            labelSPS.Text = sps + " SPS";
            lastSamplesIdxForSPS = samplesIdx;
            labelTotalSampled.Text = samplesIdx + " Samples";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDownStartSample.Value = trackBar1.Value * (samplesIdx - (int)numericUpDownSamplesToShow.Value) / 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //timer1.Stop();

            /*if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }*/
            quit = true;
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
        }

        private void numericUpDownSamplesToShow_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownSamplesToShow.Value > pictureBox1.Width - 2)
            {
                numericUpDownSamplesToShow.ForeColor = Color.Red;
            }
            else
            {
                numericUpDownSamplesToShow.ForeColor = Color.Black;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //string path = Environment.CurrentDirectory + "
            //pictureBox1.Image.Save(Environment.CurrentDirectory
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.CurrentDirectory;
            save.Filter = "PNG Image|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            save.Title = "Save the File";
            save.FileName = string.Format("graph-{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            if (save.ShowDialog() == DialogResult.OK) //Use this to prevent exception on Cancel click
            {
                string fName = save.FileName;

                if (save.FileName != "")
                {
                    System.IO.Stream fileStream = (System.IO.FileStream)save.OpenFile();
                    Bitmap bitmap = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);
                    pictureBox1.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
                    switch (save.FilterIndex)
                    {
                        case 1:
                            bitmap.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case 2:
                            bitmap.Save(fileStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 3:
                            bitmap.Save(fileStream, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case 4:
                            bitmap.Save(fileStream, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                    bitmap.Dispose();
                    fileStream.Close();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = Environment.CurrentDirectory;
            //savefile.Filter = "PNG Image|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            savefile.Title = "Save raw data";
            // set a default file name
            savefile.FileName = string.Format("data-{0:yyyy-MM-dd_HH-mm-ss}.txt", DateTime.Now);
            // set filters - this can be done in properties as well
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                {
                    for (int n = 0; n < samplesIdx; n++)
                    {
                        sw.WriteLine("" + samples[n]);
                    }
                    sw.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = Environment.CurrentDirectory;
            DialogResult result = openfile.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openfile.FileName;
                try
                {
                    //string text = File.ReadAllText(file);
                    string[] lines = File.ReadAllLines(file);
                    samplesIdx = 0;
                    foreach (string line in lines)
                    {
                        samples[samplesIdx++] = int.Parse(line);
                    }
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
