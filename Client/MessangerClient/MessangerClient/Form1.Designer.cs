using System;

namespace MessangerClient
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
            this.bwServer = new System.ComponentModel.BackgroundWorker();
            this.bwChat = new System.ComponentModel.BackgroundWorker();
            this.lbConfig = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.bStart = new System.Windows.Forms.Button();
            this.bBold = new System.Windows.Forms.Button();
            this.bItalic = new System.Windows.Forms.Button();
            this.tbEdit = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.bBr = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bIns = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.wbChat = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // bwServer
            // 
            this.bwServer.WorkerSupportsCancellation = true;
            this.bwServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwServerConnection_DoWork);
            // 
            // bwChat
            // 
            this.bwChat.WorkerSupportsCancellation = true;
            this.bwChat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConversation_DoWork);
            // 
            // lbConfig
            // 
            this.lbConfig.FormattingEnabled = true;
            this.lbConfig.Location = new System.Drawing.Point(12, 33);
            this.lbConfig.Name = "lbConfig";
            this.lbConfig.Size = new System.Drawing.Size(504, 69);
            this.lbConfig.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client options:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(264, 7);
            this.nudPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(61, 20);
            this.nudPort.TabIndex = 5;
            this.nudPort.Value = new decimal(new int[] {
            830,
            0,
            0,
            0});
            this.nudPort.ValueChanged += new System.EventHandler(this.nudPort_ValueChanged);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(232, 108);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(81, 31);
            this.bStart.TabIndex = 6;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bBold
            // 
            this.bBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBold.Location = new System.Drawing.Point(12, 478);
            this.bBold.Margin = new System.Windows.Forms.Padding(4);
            this.bBold.Name = "bBold";
            this.bBold.Size = new System.Drawing.Size(80, 32);
            this.bBold.TabIndex = 8;
            this.bBold.Text = "b";
            this.bBold.UseVisualStyleBackColor = true;
            this.bBold.Click += new System.EventHandler(this.bBold_Click);
            // 
            // bItalic
            // 
            this.bItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItalic.Location = new System.Drawing.Point(100, 478);
            this.bItalic.Margin = new System.Windows.Forms.Padding(4);
            this.bItalic.Name = "bItalic";
            this.bItalic.Size = new System.Drawing.Size(81, 32);
            this.bItalic.TabIndex = 9;
            this.bItalic.Text = "i";
            this.bItalic.UseVisualStyleBackColor = true;
            this.bItalic.Click += new System.EventHandler(this.bItalic_Click);
            // 
            // tbEdit
            // 
            this.tbEdit.Location = new System.Drawing.Point(12, 517);
            this.tbEdit.Multiline = true;
            this.tbEdit.Name = "tbEdit";
            this.tbEdit.Size = new System.Drawing.Size(504, 83);
            this.tbEdit.TabIndex = 10;
            this.tbEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEdit_KeyPress);
            this.tbEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbEdit_KeyUp);
            this.tbEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbEdit_MouseUp);
            // 
            // bSend
            // 
            this.bSend.FlatAppearance.BorderSize = 2;
            this.bSend.Location = new System.Drawing.Point(142, 609);
            this.bSend.Margin = new System.Windows.Forms.Padding(4);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(257, 32);
            this.bSend.TabIndex = 11;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // bBr
            // 
            this.bBr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBr.Location = new System.Drawing.Point(232, 478);
            this.bBr.Margin = new System.Windows.Forms.Padding(4);
            this.bBr.Name = "bBr";
            this.bBr.Size = new System.Drawing.Size(81, 32);
            this.bBr.TabIndex = 12;
            this.bBr.Text = "br";
            this.bBr.UseVisualStyleBackColor = true;
            this.bBr.Click += new System.EventHandler(this.bBr_Click);
            // 
            // bDel
            // 
            this.bDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDel.Location = new System.Drawing.Point(346, 478);
            this.bDel.Margin = new System.Windows.Forms.Padding(4);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(81, 32);
            this.bDel.TabIndex = 17;
            this.bDel.Text = "del";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bIns
            // 
            this.bIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIns.Location = new System.Drawing.Point(435, 478);
            this.bIns.Margin = new System.Windows.Forms.Padding(4);
            this.bIns.Name = "bIns";
            this.bIns.Size = new System.Drawing.Size(81, 32);
            this.bIns.TabIndex = 18;
            this.bIns.Text = "ins";
            this.bIns.UseVisualStyleBackColor = true;
            this.bIns.Click += new System.EventHandler(this.bIns_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(151, 7);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(70, 20);
            this.tbIP.TabIndex = 21;
            this.tbIP.Text = "25.49.191.102";
            this.tbIP.TextChanged += new System.EventHandler(this.tbIP_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(388, 7);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(128, 20);
            this.tbName.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Name:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // wbChat
            // 
            this.wbChat.Location = new System.Drawing.Point(12, 145);
            this.wbChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbChat.Name = "wbChat";
            this.wbChat.Size = new System.Drawing.Size(504, 325);
            this.wbChat.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 654);
            this.Controls.Add(this.wbChat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.bIns);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bBr);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tbEdit);
            this.Controls.Add(this.bItalic);
            this.Controls.Add(this.bBold);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Communicator Client";
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void nudPort_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ListBox lbConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bBold;
        private System.Windows.Forms.Button bItalic;
        private System.Windows.Forms.TextBox tbEdit;
        private System.Windows.Forms.Button bSend;
        private System.ComponentModel.BackgroundWorker bwServer;
        private System.ComponentModel.BackgroundWorker bwChat;
        private System.Windows.Forms.Button bBr;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bIns;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser wbChat;
    }
}

