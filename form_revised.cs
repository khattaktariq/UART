using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace COM_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (!mySerialPort.IsOpen)
            {
                mySerialPort.Open();
                tbRx.Text = "Serial Port Opened :)";
            }
            else
                tbRx.Text = "Serial Port is busy :(";
        }

        private void displayText(object o, EventArgs e)
        {
            tbRx.AppendText(rxString);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            mySerialPort.Write(tbTx.Text);
            if (mySerialPort.IsOpen && checkBox1.Checked)
            {
                string text;
                var fs = new FileStream("D:\\Redirect.txt", FileMode.Open, FileAccess.Read, FileShare.None);
                using (var streamReader = new StreamReader(fs, Encoding.ASCII))
                {
                    text = streamReader.ReadToEnd();
                }
                byte[] textByte = File.ReadAllBytes(text);
                mySerialPort.Write(textByte, 0, textByte.Length);
                tbTx.Text = ("Done with file transmission :) ");
                


            }
        }

        private string rxString;
        private void MySerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            rxString = mySerialPort.ReadExisting();
            this.Invoke(new EventHandler(displayText));
        }

        private void Bclear_Click(object sender, EventArgs e)
        {
            tbTx.Clear();
            tbRx.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mySerialPort.Close();
        }

        
    }
}
