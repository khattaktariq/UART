namespace UART_FINAL1
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
            this.tbTx = new System.Windows.Forms.RichTextBox();
            this.tbRx = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.mySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // tbTx
            // 
            this.tbTx.Location = new System.Drawing.Point(41, 29);
            this.tbTx.Name = "tbTx";
            this.tbTx.Size = new System.Drawing.Size(539, 66);
            this.tbTx.TabIndex = 0;
            this.tbTx.Text = "";
            // 
            // tbRx
            // 
            this.tbRx.Location = new System.Drawing.Point(41, 107);
            this.tbRx.Name = "tbRx";
            this.tbRx.Size = new System.Drawing.Size(539, 208);
            this.tbRx.TabIndex = 1;
            this.tbRx.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(586, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(38, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "IM";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(586, 27);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(586, 292);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 4;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // mySerialPort
            // 
            this.mySerialPort.BaudRate = 115200;
            this.mySerialPort.PortName = "COM6";
            this.mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MySerialPort_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tbRx);
            this.Controls.Add(this.tbTx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbTx;
        private System.Windows.Forms.RichTextBox tbRx;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Clear;
        private System.IO.Ports.SerialPort mySerialPort;
    }
}

