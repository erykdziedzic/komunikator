namespace Messenger_Server
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.n_port = new System.Windows.Forms.NumericUpDown();
            this.lb_logs = new System.Windows.Forms.ListBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.bgw_init_server = new System.ComponentModel.BackgroundWorker();
            this.messages_wb = new System.Windows.Forms.WebBrowser();
            this.send_btn = new System.Windows.Forms.Button();
            this.tb_edit = new System.Windows.Forms.TextBox();
            this.bSup = new System.Windows.Forms.Button();
            this.bSub = new System.Windows.Forms.Button();
            this.bIns = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bSmall = new System.Windows.Forms.Button();
            this.bEm = new System.Windows.Forms.Button();
            this.bStrong = new System.Windows.Forms.Button();
            this.bHr = new System.Windows.Forms.Button();
            this.bBr = new System.Windows.Forms.Button();
            this.bItalic = new System.Windows.Forms.Button();
            this.bBold = new System.Windows.Forms.Button();
            this.cb_clients = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_changeColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.n_port)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(72, 108);
            this.tb_ip.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(127, 20);
            this.tb_ip.TabIndex = 1;
            this.tb_ip.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // n_port
            // 
            this.n_port.Location = new System.Drawing.Point(267, 109);
            this.n_port.Margin = new System.Windows.Forms.Padding(2);
            this.n_port.Maximum = new decimal(new int[] {
            65550,
            0,
            0,
            0});
            this.n_port.Name = "n_port";
            this.n_port.Size = new System.Drawing.Size(60, 20);
            this.n_port.TabIndex = 3;
            this.n_port.Value = new decimal(new int[] {
            420,
            0,
            0,
            0});
            // 
            // lb_logs
            // 
            this.lb_logs.FormattingEnabled = true;
            this.lb_logs.Location = new System.Drawing.Point(11, 11);
            this.lb_logs.Margin = new System.Windows.Forms.Padding(2);
            this.lb_logs.Name = "lb_logs";
            this.lb_logs.Size = new System.Drawing.Size(457, 82);
            this.lb_logs.TabIndex = 4;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(384, 102);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(84, 31);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // bgw_init_server
            // 
            this.bgw_init_server.WorkerSupportsCancellation = true;
            this.bgw_init_server.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_init_server_DoWork);
            // 
            // messages_wb
            // 
            this.messages_wb.Location = new System.Drawing.Point(11, 148);
            this.messages_wb.Margin = new System.Windows.Forms.Padding(2);
            this.messages_wb.MinimumSize = new System.Drawing.Size(10, 10);
            this.messages_wb.Name = "messages_wb";
            this.messages_wb.Size = new System.Drawing.Size(457, 329);
            this.messages_wb.TabIndex = 7;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(371, 611);
            this.send_btn.Margin = new System.Windows.Forms.Padding(2);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(85, 32);
            this.send_btn.TabIndex = 10;
            this.send_btn.Text = "Send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // tb_edit
            // 
            this.tb_edit.Location = new System.Drawing.Point(11, 519);
            this.tb_edit.Margin = new System.Windows.Forms.Padding(2);
            this.tb_edit.Multiline = true;
            this.tb_edit.Name = "tb_edit";
            this.tb_edit.Size = new System.Drawing.Size(457, 83);
            this.tb_edit.TabIndex = 11;
            this.tb_edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbEdit_KeyPress);
            // 
            // bSup
            // 
            this.bSup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSup.Location = new System.Drawing.Point(357, 482);
            this.bSup.Name = "bSup";
            this.bSup.Size = new System.Drawing.Size(33, 32);
            this.bSup.TabIndex = 31;
            this.bSup.Text = "sup";
            this.bSup.UseVisualStyleBackColor = true;
            this.bSup.Click += new System.EventHandler(this.bSup_Click);
            // 
            // bSub
            // 
            this.bSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSub.Location = new System.Drawing.Point(318, 482);
            this.bSub.Name = "bSub";
            this.bSub.Size = new System.Drawing.Size(33, 32);
            this.bSub.TabIndex = 30;
            this.bSub.Text = "sub";
            this.bSub.UseVisualStyleBackColor = true;
            this.bSub.Click += new System.EventHandler(this.bSub_Click);
            // 
            // bIns
            // 
            this.bIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIns.Location = new System.Drawing.Point(279, 482);
            this.bIns.Name = "bIns";
            this.bIns.Size = new System.Drawing.Size(33, 32);
            this.bIns.TabIndex = 29;
            this.bIns.Text = "ins";
            this.bIns.UseVisualStyleBackColor = true;
            this.bIns.Click += new System.EventHandler(this.bIns_Click);
            // 
            // bDel
            // 
            this.bDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDel.Location = new System.Drawing.Point(240, 482);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(33, 32);
            this.bDel.TabIndex = 28;
            this.bDel.Text = "del";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bSmall
            // 
            this.bSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSmall.Location = new System.Drawing.Point(193, 482);
            this.bSmall.Name = "bSmall";
            this.bSmall.Size = new System.Drawing.Size(41, 32);
            this.bSmall.TabIndex = 27;
            this.bSmall.Text = "small";
            this.bSmall.UseVisualStyleBackColor = true;
            this.bSmall.Click += new System.EventHandler(this.bSmall_Click);
            // 
            // bEm
            // 
            this.bEm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEm.Location = new System.Drawing.Point(154, 482);
            this.bEm.Name = "bEm";
            this.bEm.Size = new System.Drawing.Size(33, 32);
            this.bEm.TabIndex = 26;
            this.bEm.Text = "em";
            this.bEm.UseVisualStyleBackColor = true;
            this.bEm.Click += new System.EventHandler(this.bEm_Click);
            // 
            // bStrong
            // 
            this.bStrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStrong.Location = new System.Drawing.Point(50, 482);
            this.bStrong.Name = "bStrong";
            this.bStrong.Size = new System.Drawing.Size(59, 32);
            this.bStrong.TabIndex = 25;
            this.bStrong.Text = "strong";
            this.bStrong.UseVisualStyleBackColor = true;
            this.bStrong.Click += new System.EventHandler(this.bStrong_Click);
            // 
            // bHr
            // 
            this.bHr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHr.Location = new System.Drawing.Point(435, 482);
            this.bHr.Name = "bHr";
            this.bHr.Size = new System.Drawing.Size(33, 32);
            this.bHr.TabIndex = 24;
            this.bHr.Text = "---";
            this.bHr.UseVisualStyleBackColor = true;
            this.bHr.Click += new System.EventHandler(this.bHr_Click);
            // 
            // bBr
            // 
            this.bBr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBr.Location = new System.Drawing.Point(396, 482);
            this.bBr.Name = "bBr";
            this.bBr.Size = new System.Drawing.Size(33, 32);
            this.bBr.TabIndex = 23;
            this.bBr.Text = "br";
            this.bBr.UseVisualStyleBackColor = true;
            this.bBr.Click += new System.EventHandler(this.bBr_Click);
            // 
            // bItalic
            // 
            this.bItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItalic.Location = new System.Drawing.Point(115, 482);
            this.bItalic.Name = "bItalic";
            this.bItalic.Size = new System.Drawing.Size(33, 32);
            this.bItalic.TabIndex = 22;
            this.bItalic.Text = "/";
            this.bItalic.UseVisualStyleBackColor = true;
            this.bItalic.Click += new System.EventHandler(this.bItalic_Click);
            // 
            // bBold
            // 
            this.bBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBold.Location = new System.Drawing.Point(12, 482);
            this.bBold.Name = "bBold";
            this.bBold.Size = new System.Drawing.Size(32, 32);
            this.bBold.TabIndex = 21;
            this.bBold.Text = "B";
            this.bBold.UseVisualStyleBackColor = true;
            this.bBold.Click += new System.EventHandler(this.bBold_Click);
            // 
            // cb_clients
            // 
            this.cb_clients.FormattingEnabled = true;
            this.cb_clients.Location = new System.Drawing.Point(221, 618);
            this.cb_clients.Name = "cb_clients";
            this.cb_clients.Size = new System.Drawing.Size(121, 21);
            this.cb_clients.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 621);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Wybierz odbiorców:";
            // 
            // btn_changeColor
            // 
            this.btn_changeColor.Location = new System.Drawing.Point(26, 616);
            this.btn_changeColor.Name = "btn_changeColor";
            this.btn_changeColor.Size = new System.Drawing.Size(75, 23);
            this.btn_changeColor.TabIndex = 34;
            this.btn_changeColor.Text = "Zmień kolor";
            this.btn_changeColor.UseVisualStyleBackColor = true;
            this.btn_changeColor.Click += new System.EventHandler(this.btn_changeColor_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 654);
            this.Controls.Add(this.btn_changeColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_clients);
            this.Controls.Add(this.bSup);
            this.Controls.Add(this.bSub);
            this.Controls.Add(this.bIns);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bSmall);
            this.Controls.Add(this.bEm);
            this.Controls.Add(this.bStrong);
            this.Controls.Add(this.bHr);
            this.Controls.Add(this.bBr);
            this.Controls.Add(this.bItalic);
            this.Controls.Add(this.bBold);
            this.Controls.Add(this.tb_edit);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.messages_wb);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lb_logs);
            this.Controls.Add(this.n_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form";
            this.Text = "Messenger Server";
            ((System.ComponentModel.ISupportInitialize)(this.n_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown n_port;
        private System.Windows.Forms.ListBox lb_logs;
        private System.Windows.Forms.Button btn_start;
        private System.ComponentModel.BackgroundWorker bgw_init_server;
        private System.Windows.Forms.WebBrowser messages_wb;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.TextBox tb_edit;
        private System.Windows.Forms.Button bSup;
        private System.Windows.Forms.Button bSub;
        private System.Windows.Forms.Button bIns;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bSmall;
        private System.Windows.Forms.Button bEm;
        private System.Windows.Forms.Button bStrong;
        private System.Windows.Forms.Button bHr;
        private System.Windows.Forms.Button bBr;
        private System.Windows.Forms.Button bItalic;
        private System.Windows.Forms.Button bBold;
        private System.Windows.Forms.ComboBox cb_clients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_changeColor;
    }
}

