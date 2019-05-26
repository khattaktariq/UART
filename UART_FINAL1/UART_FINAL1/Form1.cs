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

namespace UART_FINAL1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (!mySerialPort.IsOpen)
            {
                mySerialPort.Open();
                tbTx.Text = "Serial Port Opened :)";
            }
            else
                tbTx.Text = "Serial Port is busy :(";
        }

        private void displayText(object o, EventArgs e)
        {
            tbRx.AppendText(rxString);
        }
        private Int32 txbytes;
        private Int32 rxbytes;
        private void Btn_Send_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen && !checkBox1.Checked)
                tbTx.Text = "Please check the checkbox to send data to serial port";
            if (mySerialPort.IsOpen && checkBox1.Checked)
            {
                
                byte[] textByte = File.ReadAllBytes("D:\\Redirect.txt");
                int filelength = textByte.Length;
                tbTx.AppendText("size of array is " + filelength);
                mySerialPort.Write(textByte, 0, textByte.Length);
                txbytes = mySerialPort.BytesToRead;
                rxbytes = mySerialPort.BytesToWrite;
                tbTx.AppendText("\n\nthere are total " + txbytes + " number of bytes to send and " + rxbytes + " to write");
                tbTx.AppendText("\n\n\nDone with file transmission :) ");
            }
        }

        private string rxString;
        private void MySerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            rxString = mySerialPort.ReadExisting();
            this.Invoke(new EventHandler(displayText));
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
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