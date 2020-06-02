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
            this.bwServerConnection = new System.ComponentModel.BackgroundWorker();
            this.bwConversation = new System.ComponentModel.BackgroundWorker();
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
            this.bHr = new System.Windows.Forms.Button();
            this.bStrong = new System.Windows.Forms.Button();
            this.bEm = new System.Windows.Forms.Button();
            this.bSmall = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bIns = new System.Windows.Forms.Button();
            this.bSub = new System.Windows.Forms.Button();
            this.bSup = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tb_nickname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.wbConversation = new System.Windows.Forms.WebBrowser();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_clients = new System.Windows.Forms.ComboBox();
            this.btn_changeColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // bwServerConnection
            // 
            this.bwServerConnection.WorkerSupportsCancellation = true;
            this.bwServerConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwServerConnection_DoWork);
            // 
            // bwConversation
            // 
            this.bwConversation.WorkerSupportsCancellation = true;
            this.bwConversation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConversation_DoWork);
            // 
            // lbConfig
            // 
            this.lbConfig.FormattingEnabled = true;
            this.lbConfig.Location = new System.Drawing.Point(12, 33);
            this.lbConfig.Name = "lbConfig";
            this.lbConfig.Size = new System.Drawing.Size(491, 69);
            this.lbConfig.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client configuration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(190, 114);
            this.nudPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(61, 20);
            this.nudPort.TabIndex = 5;
            this.nudPort.Value = new decimal(new int[] {
            420,
            0,
            0,
            0});
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(419, 108);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(84, 31);
            this.bStart.TabIndex = 6;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bBold
            // 
            this.bBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBold.Location = new System.Drawing.Point(28, 476);
            this.bBold.Name = "bBold";
            this.bBold.Size = new System.Drawing.Size(32, 32);
            this.bBold.TabIndex = 8;
            this.bBold.Text = "B";
            this.bBold.UseVisualStyleBackColor = true;
            this.bBold.Click += new System.EventHandler(this.bBold_Click);
            // 
            // bItalic
            // 
            this.bItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItalic.Location = new System.Drawing.Point(131, 476);
            this.bItalic.Name = "bItalic";
            this.bItalic.Size = new System.Drawing.Size(33, 32);
            this.bItalic.TabIndex = 9;
            this.bItalic.Text = "/";
            this.bItalic.UseVisualStyleBackColor = true;
            this.bItalic.Click += new System.EventHandler(this.bItalic_Click);
            // 
            // tbEdit
            // 
            this.tbEdit.Location = new System.Drawing.Point(12, 517);
            this.tbEdit.Multiline = true;
            this.tbEdit.Name = "tbEdit";
            this.tbEdit.Size = new System.Drawing.Size(491, 83);
            this.tbEdit.TabIndex = 10;
            this.tbEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEdit_KeyPress);
            this.tbEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbEdit_KeyUp);
            this.tbEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbEdit_MouseUp);
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(399, 610);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(85, 32);
            this.bSend.TabIndex = 11;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // bBr
            // 
            this.bBr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBr.Location = new System.Drawing.Point(412, 476);
            this.bBr.Name = "bBr";
            this.bBr.Size = new System.Drawing.Size(33, 32);
            this.bBr.TabIndex = 12;
            this.bBr.Text = "br";
            this.bBr.UseVisualStyleBackColor = true;
            this.bBr.Click += new System.EventHandler(this.bBr_Click);
            // 
            // bHr
            // 
            this.bHr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHr.Location = new System.Drawing.Point(451, 476);
            this.bHr.Name = "bHr";
            this.bHr.Size = new System.Drawing.Size(33, 32);
            this.bHr.TabIndex = 13;
            this.bHr.Text = "---";
            this.bHr.UseVisualStyleBackColor = true;
            this.bHr.Click += new System.EventHandler(this.bHr_Click);
            // 
            // bStrong
            // 
            this.bStrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStrong.Location = new System.Drawing.Point(66, 476);
            this.bStrong.Name = "bStrong";
            this.bStrong.Size = new System.Drawing.Size(59, 32);
            this.bStrong.TabIndex = 14;
            this.bStrong.Text = "strong";
            this.bStrong.UseVisualStyleBackColor = true;
            this.bStrong.Click += new System.EventHandler(this.bStrong_Click);
            // 
            // bEm
            // 
            this.bEm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEm.Location = new System.Drawing.Point(170, 476);
            this.bEm.Name = "bEm";
            this.bEm.Size = new System.Drawing.Size(33, 32);
            this.bEm.TabIndex = 15;
            this.bEm.Text = "em";
            this.bEm.UseVisualStyleBackColor = true;
            this.bEm.Click += new System.EventHandler(this.bEm_Click);
            // 
            // bSmall
            // 
            this.bSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSmall.Location = new System.Drawing.Point(209, 476);
            this.bSmall.Name = "bSmall";
            this.bSmall.Size = new System.Drawing.Size(41, 32);
            this.bSmall.TabIndex = 16;
            this.bSmall.Text = "small";
            this.bSmall.UseVisualStyleBackColor = true;
            this.bSmall.Click += new System.EventHandler(this.bSmall_Click);
            // 
            // bDel
            // 
            this.bDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDel.Location = new System.Drawing.Point(256, 476);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(33, 32);
            this.bDel.TabIndex = 17;
            this.bDel.Text = "del";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bIns
            // 
            this.bIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIns.Location = new System.Drawing.Point(295, 476);
            this.bIns.Name = "bIns";
            this.bIns.Size = new System.Drawing.Size(33, 32);
            this.bIns.TabIndex = 18;
            this.bIns.Text = "ins";
            this.bIns.UseVisualStyleBackColor = true;
            this.bIns.Click += new System.EventHandler(this.bIns_Click);
            // 
            // bSub
            // 
            this.bSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSub.Location = new System.Drawing.Point(334, 476);
            this.bSub.Name = "bSub";
            this.bSub.Size = new System.Drawing.Size(33, 32);
            this.bSub.TabIndex = 19;
            this.bSub.Text = "sub";
            this.bSub.UseVisualStyleBackColor = true;
            this.bSub.Click += new System.EventHandler(this.bSub_Click);
            // 
            // bSup
            // 
            this.bSup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSup.Location = new System.Drawing.Point(373, 476);
            this.bSup.Name = "bSup";
            this.bSup.Size = new System.Drawing.Size(33, 32);
            this.bSup.TabIndex = 20;
            this.bSup.Text = "sup";
            this.bSup.UseVisualStyleBackColor = true;
            this.bSup.Click += new System.EventHandler(this.bSup_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(66, 114);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(70, 20);
            this.tbIP.TabIndex = 21;
            this.tbIP.Text = "127.0.0.1";
            // 
            // tb_nickname
            // 
            this.tb_nickname.Location = new System.Drawing.Point(301, 114);
            this.tb_nickname.Margin = new System.Windows.Forms.Padding(2);
            this.tb_nickname.Name = "tb_nickname";
            this.tb_nickname.Size = new System.Drawing.Size(105, 20);
            this.tb_nickname.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Nick:";
            // 
            // wbConversation
            // 
            this.wbConversation.Location = new System.Drawing.Point(12, 149);
            this.wbConversation.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbConversation.Name = "wbConversation";
            this.wbConversation.Size = new System.Drawing.Size(491, 321);
            this.wbConversation.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 620);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Wybierz odbiorców";
            // 
            // cb_clients
            // 
            this.cb_clients.FormattingEnabled = true;
            this.cb_clients.Location = new System.Drawing.Point(241, 617);
            this.cb_clients.Name = "cb_clients";
            this.cb_clients.Size = new System.Drawing.Size(121, 21);
            this.cb_clients.TabIndex = 34;
            // 
            // btn_changeColor
            // 
            this.btn_changeColor.Location = new System.Drawing.Point(37, 615);
            this.btn_changeColor.Name = "btn_changeColor";
            this.btn_changeColor.Size = new System.Drawing.Size(75, 23);
            this.btn_changeColor.TabIndex = 36;
            this.btn_changeColor.Text = "Zmień kolor";
            this.btn_changeColor.UseVisualStyleBackColor = true;
            this.btn_changeColor.Click += new System.EventHandler(this.btn_changeColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 654);
            this.Controls.Add(this.btn_changeColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_clients);
            this.Controls.Add(this.wbConversation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_nickname);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.bSup);
            this.Controls.Add(this.bSub);
            this.Controls.Add(this.bIns);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bSmall);
            this.Controls.Add(this.bEm);
            this.Controls.Add(this.bStrong);
            this.Controls.Add(this.bHr);
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
        private System.ComponentModel.BackgroundWorker bwServerConnection;
        private System.ComponentModel.BackgroundWorker bwConversation;
        private System.Windows.Forms.Button bBr;
        private System.Windows.Forms.Button bHr;
        private System.Windows.Forms.Button bStrong;
        private System.Windows.Forms.Button bEm;
        private System.Windows.Forms.Button bSmall;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bIns;
        private System.Windows.Forms.Button bSub;
        private System.Windows.Forms.Button bSup;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tb_nickname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser wbConversation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_clients;
        private System.Windows.Forms.Button btn_changeColor;
    }
}

