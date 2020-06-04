namespace Server
{
    partial class Form
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
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.listBox_Console = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.backgroundWorkerStartServer = new System.ComponentModel.BackgroundWorker();
            this.webBrowserMain = new System.Windows.Forms.WebBrowser();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonIns = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonBr = new System.Windows.Forms.Button();
            this.buttonItalic = new System.Windows.Forms.Button();
            this.buttonBold = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(37, 35);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(60, 17);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "Address";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(103, 35);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(194, 22);
            this.textBoxAddress.TabIndex = 1;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(303, 35);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(34, 17);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Port";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(343, 35);
            this.numericUpDownPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65550,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(102, 22);
            this.numericUpDownPort.TabIndex = 3;
            this.numericUpDownPort.Value = new decimal(new int[] {
            830,
            0,
            0,
            0});
            // 
            // listBox_Console
            // 
            this.listBox_Console.FormattingEnabled = true;
            this.listBox_Console.ItemHeight = 16;
            this.listBox_Console.Location = new System.Drawing.Point(16, 69);
            this.listBox_Console.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_Console.Name = "listBox_Console";
            this.listBox_Console.Size = new System.Drawing.Size(608, 100);
            this.listBox_Console.TabIndex = 4;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(451, 27);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(160, 38);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // backgroundWorkerStartServer
            // 
            this.backgroundWorkerStartServer.WorkerSupportsCancellation = true;
            this.backgroundWorkerStartServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStartServer_DoWork);
            // 
            // webBrowserMain
            // 
            this.webBrowserMain.Location = new System.Drawing.Point(15, 182);
            this.webBrowserMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowserMain.MinimumSize = new System.Drawing.Size(13, 12);
            this.webBrowserMain.Name = "webBrowserMain";
            this.webBrowserMain.Size = new System.Drawing.Size(609, 405);
            this.webBrowserMain.TabIndex = 7;
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(142, 744);
            this.buttonSendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(348, 95);
            this.buttonSendMessage.TabIndex = 10;
            this.buttonSendMessage.Text = "Send";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(15, 639);
            this.textBoxMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(608, 101);
            this.textBoxMessage.TabIndex = 11;
            this.textBoxMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbEdit_KeyPress);
            // 
            // buttonIns
            // 
            this.buttonIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIns.Location = new System.Drawing.Point(521, 594);
            this.buttonIns.Margin = new System.Windows.Forms.Padding(4);
            this.buttonIns.Name = "buttonIns";
            this.buttonIns.Size = new System.Drawing.Size(102, 39);
            this.buttonIns.TabIndex = 29;
            this.buttonIns.Text = "ins";
            this.buttonIns.UseVisualStyleBackColor = true;
            this.buttonIns.Click += new System.EventHandler(this.bIns_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDel.Location = new System.Drawing.Point(411, 594);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(102, 39);
            this.buttonDel.TabIndex = 28;
            this.buttonDel.Text = "del";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // buttonBr
            // 
            this.buttonBr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBr.Location = new System.Drawing.Point(267, 594);
            this.buttonBr.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBr.Name = "buttonBr";
            this.buttonBr.Size = new System.Drawing.Size(113, 39);
            this.buttonBr.TabIndex = 23;
            this.buttonBr.Text = "br";
            this.buttonBr.UseVisualStyleBackColor = true;
            this.buttonBr.Click += new System.EventHandler(this.bBr_Click);
            // 
            // buttonItalic
            // 
            this.buttonItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonItalic.Location = new System.Drawing.Point(125, 592);
            this.buttonItalic.Margin = new System.Windows.Forms.Padding(4);
            this.buttonItalic.Name = "buttonItalic";
            this.buttonItalic.Size = new System.Drawing.Size(108, 39);
            this.buttonItalic.TabIndex = 22;
            this.buttonItalic.Text = "i";
            this.buttonItalic.UseVisualStyleBackColor = true;
            this.buttonItalic.Click += new System.EventHandler(this.bItalic_Click);
            // 
            // buttonBold
            // 
            this.buttonBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBold.Location = new System.Drawing.Point(15, 592);
            this.buttonBold.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBold.Name = "buttonBold";
            this.buttonBold.Size = new System.Drawing.Size(102, 39);
            this.buttonBold.TabIndex = 21;
            this.buttonBold.Text = "b";
            this.buttonBold.UseVisualStyleBackColor = true;
            this.buttonBold.Click += new System.EventHandler(this.bBold_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 850);
            this.Controls.Add(this.webBrowserMain);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listBox_Console);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.buttonIns);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonBr);
            this.Controls.Add(this.buttonItalic);
            this.Controls.Add(this.buttonBold);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonSendMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form";
            this.Text = "Messenger Server";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerStartServer;
        private System.Windows.Forms.ListBox listBox_Console;
        private System.Windows.Forms.WebBrowser webBrowserMain;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonIns;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonBr;
        private System.Windows.Forms.Button buttonItalic;
        private System.Windows.Forms.Button buttonBold;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;

    }
}

