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
            this.labelAddress = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.n_port = new System.Windows.Forms.NumericUpDown();
            this.lb_logs = new System.Windows.Forms.ListBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.bgw_init_server = new System.ComponentModel.BackgroundWorker();
            this.messages_wb = new System.Windows.Forms.WebBrowser();
            this.send_btn = new System.Windows.Forms.Button();
            this.tb_edit = new System.Windows.Forms.TextBox();
            this.bIns = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bBr = new System.Windows.Forms.Button();
            this.bItalic = new System.Windows.Forms.Button();
            this.bBold = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.n_port)).BeginInit();
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
            this.labelAddress.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(103, 35);
            this.tb_ip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(194, 22);
            this.tb_ip.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // n_port
            // 
            this.n_port.Location = new System.Drawing.Point(343, 35);
            this.n_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.n_port.Maximum = new decimal(new int[] {
            65550,
            0,
            0,
            0});
            this.n_port.Name = "n_port";
            this.n_port.Size = new System.Drawing.Size(102, 22);
            this.n_port.TabIndex = 3;
            this.n_port.Value = new decimal(new int[] {
            830,
            0,
            0,
            0});
            this.n_port.ValueChanged += new System.EventHandler(this.n_port_ValueChanged);
            // 
            // lb_logs
            // 
            this.lb_logs.FormattingEnabled = true;
            this.lb_logs.ItemHeight = 16;
            this.lb_logs.Location = new System.Drawing.Point(16, 69);
            this.lb_logs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_logs.Name = "lb_logs";
            this.lb_logs.Size = new System.Drawing.Size(608, 100);
            this.lb_logs.TabIndex = 4;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(451, 27);
            this.btn_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(160, 38);
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
            this.messages_wb.Location = new System.Drawing.Point(15, 182);
            this.messages_wb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.messages_wb.MinimumSize = new System.Drawing.Size(13, 12);
            this.messages_wb.Name = "messages_wb";
            this.messages_wb.Size = new System.Drawing.Size(609, 405);
            this.messages_wb.TabIndex = 7;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(142, 744);
            this.send_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(348, 50);
            this.send_btn.TabIndex = 10;
            this.send_btn.Text = "Send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // tb_edit
            // 
            this.tb_edit.Location = new System.Drawing.Point(15, 639);
            this.tb_edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_edit.Multiline = true;
            this.tb_edit.Name = "tb_edit";
            this.tb_edit.Size = new System.Drawing.Size(608, 101);
            this.tb_edit.TabIndex = 11;
            this.tb_edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbEdit_KeyPress);
            // 
            // bIns
            // 
            this.bIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIns.Location = new System.Drawing.Point(521, 594);
            this.bIns.Margin = new System.Windows.Forms.Padding(4);
            this.bIns.Name = "bIns";
            this.bIns.Size = new System.Drawing.Size(102, 39);
            this.bIns.TabIndex = 29;
            this.bIns.Text = "ins";
            this.bIns.UseVisualStyleBackColor = true;
            this.bIns.Click += new System.EventHandler(this.bIns_Click);
            // 
            // bDel
            // 
            this.bDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDel.Location = new System.Drawing.Point(411, 594);
            this.bDel.Margin = new System.Windows.Forms.Padding(4);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(102, 39);
            this.bDel.TabIndex = 28;
            this.bDel.Text = "del";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bBr
            // 
            this.bBr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBr.Location = new System.Drawing.Point(267, 594);
            this.bBr.Margin = new System.Windows.Forms.Padding(4);
            this.bBr.Name = "bBr";
            this.bBr.Size = new System.Drawing.Size(113, 39);
            this.bBr.TabIndex = 23;
            this.bBr.Text = "br";
            this.bBr.UseVisualStyleBackColor = true;
            this.bBr.Click += new System.EventHandler(this.bBr_Click);
            // 
            // bItalic
            // 
            this.bItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItalic.Location = new System.Drawing.Point(125, 592);
            this.bItalic.Margin = new System.Windows.Forms.Padding(4);
            this.bItalic.Name = "bItalic";
            this.bItalic.Size = new System.Drawing.Size(108, 39);
            this.bItalic.TabIndex = 22;
            this.bItalic.Text = "i";
            this.bItalic.UseVisualStyleBackColor = true;
            this.bItalic.Click += new System.EventHandler(this.bItalic_Click);
            // 
            // bBold
            // 
            this.bBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBold.Location = new System.Drawing.Point(15, 592);
            this.bBold.Margin = new System.Windows.Forms.Padding(4);
            this.bBold.Name = "bBold";
            this.bBold.Size = new System.Drawing.Size(102, 39);
            this.bBold.TabIndex = 21;
            this.bBold.Text = "b";
            this.bBold.UseVisualStyleBackColor = true;
            this.bBold.Click += new System.EventHandler(this.bBold_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 805);
            this.Controls.Add(this.bIns);
            this.Controls.Add(this.bDel);
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
            this.Controls.Add(this.labelAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form";
            this.Text = "Messenger Server";
            ((System.ComponentModel.ISupportInitialize)(this.n_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown n_port;
        private System.Windows.Forms.ListBox lb_logs;
        private System.Windows.Forms.Button btn_start;
        private System.ComponentModel.BackgroundWorker bgw_init_server;
        private System.Windows.Forms.WebBrowser messages_wb;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.TextBox tb_edit;
        private System.Windows.Forms.Button bIns;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bBr;
        private System.Windows.Forms.Button bItalic;
        private System.Windows.Forms.Button bBold;
    }
}

