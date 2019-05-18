namespace COM_1
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
            this.bclear = new System.Windows.Forms.Button();
            this.bsend = new System.Windows.Forms.Button();
            this.tbTx = new System.Windows.Forms.RichTextBox();
            this.tbRx = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.mySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // bclear
            // 
            this.bclear.Location = new System.Drawing.Point(608, 303);
            this.bclear.Name = "bclear";
            this.bclear.Size = new System.Drawing.Size(75, 23);
            this.bclear.TabIndex = 0;
            this.bclear.Text = "Clear";
            this.bclear.UseVisualStyleBackColor = true;
            this.bclear.Click += new System.EventHandler(this.Bclear_Click);
            // 
            // bsend
            // 
            this.bsend.Location = new System.Drawing.Point(603, 24);
            this.bsend.Name = "bsend";
            this.bsend.Size = new System.Drawing.Size(75, 23);
            this.bsend.TabIndex = 1;
            this.bsend.Text = "Send";
            this.bsend.UseVisualStyleBackColor = true;
            this.bsend.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tbTx
            // 
            this.tbTx.Location = new System.Drawing.Point(12, 26);
            this.tbTx.Name = "tbTx";
            this.tbTx.Size = new System.Drawing.Size(578, 40);
            this.tbTx.TabIndex = 2;
            this.tbTx.Text = "";
            this.tbTx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbTx_KeyPress);
            // 
            // tbRx
            // 
            this.tbRx.Location = new System.Drawing.Point(12, 72);
            this.tbRx.Name = "tbRx";
            this.tbRx.Size = new System.Drawing.Size(578, 254);
            this.tbRx.TabIndex = 3;
            this.tbRx.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(603, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(38, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "IM";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // mySerialPort
            // 
            this.mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MySerialPort_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tbRx);
            this.Controls.Add(this.tbTx);
            this.Controls.Add(this.bsend);
            this.Controls.Add(this.bclear);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bclear;
        private System.Windows.Forms.Button bsend;
        private System.Windows.Forms.RichTextBox tbTx;
        private System.Windows.Forms.RichTextBox tbRx;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.IO.Ports.SerialPort mySerialPort;
    }
}

