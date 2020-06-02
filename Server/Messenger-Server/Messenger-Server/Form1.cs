using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Messenger_Server
{
    public partial class Form : System.Windows.Forms.Form
    {
        private TcpListener server = null;
        private bool server_listening = false;
        private delegate void SetTextCallBack(string text);
        private delegate void SetScrollCallBack();
        private int cursorPosition = 0;
        private string Client_color = "#ffb700";
        private string Server_color = "#19FFB0";
        private Dictionary<string, TcpClient> clientDict;
        private Dictionary<string, NetworkStream> clientStream;
       
        

        public Form()
        {
            InitializeComponent();
            ClearWebBrowser();
            //cb_clients.Items.Add("Wszyscy");
            //cb_clients.SelectedItem = "Wszyscy";
        }

        private void ClearWebBrowser()
        {
            messages_wb.Navigate("about:blank");
            HtmlDocument doc = messages_wb.Document;
            doc.Write(String.Empty);
            messages_wb.DocumentText = "<!DOCTYPE html> <html> <head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" /> </head> <body> </body></html>";
        }

        private void SetTextHTML(string text)
        {
            if (messages_wb.InvokeRequired)
            {
                Form.SetTextCallBack method = new Form.SetTextCallBack(SetTextHTML);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                messages_wb.Document.Write(text);
            }
        }

        private void WriteText(string who, string message, string color, bool isMe=false)
        {

            if (message.Length >= 4)
            {
                string checkstr = message.Substring(0, 4);
                if (checkstr == "<br>")
                {
                    message = message.Remove(0, 4);
                }
            }
            if (isMe)
            {
                SetTextHTML(string.Concat(new string[]
{
              "<div style=\"float:right; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; display: flex; margin-bottom: 15px; padding: 10px 15px 5px 15px; width: fit-content; flex-direction: column; background-color: "+color+";\">",
              "<div style=\"word-wrap: break-word;  \">",
              message,
              "</div>",
              "<div style=\"text-align: right; font-size: 13px; margin-right: 2px; margin-top: 5px; \">",
              who,
              " o ",
              DateTime.Now.ToShortTimeString(),
              "</div></div>",
              "<div style=\"clear: both;\"></div>"
                }));
            }
            else
            {
                SetTextHTML(string.Concat(new string[]
{
              "<div style=\"float:left; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; display: flex; margin-bottom: 15px; padding: 10px 15px 5px 15px; width: fit-content; flex-direction: column; background-color: "+color+";\">",
              "<div style=\"word-wrap: break-word; \">",
              message,
              "</div>",
              "<div style=\"text-align: right; font-size: 13px; margin-right: 2px; margin-top: 5px; \">",
              who,
              " o ",
              DateTime.Now.ToShortTimeString(),
              "</div></div>",
              "<div style=\"clear: both;\"></div>"
                }));
            }
            SetScroll();
        }

        private void SetText(string text)
        {
            if (lb_logs.InvokeRequired)
            {
                Form.SetTextCallBack method = new Form.SetTextCallBack(SetText);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                lb_logs.Items.Add("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: "+text);
                lb_logs.SelectedIndex = lb_logs.Items.Count - 1;
                lb_logs.SelectedIndex = -1;
            }
        }

        private void SetScroll()
        {
            if (messages_wb.InvokeRequired)
            {
                Form.SetScrollCallBack method = new Form.SetScrollCallBack(SetScroll);
                base.Invoke(method);
            }
            else
            {
                messages_wb.Document.Body.ScrollIntoView(false);
            }
        }


        private async void  btn_start_Click(object sender, EventArgs e)
        {
            if (!server_listening)
            {
                SetText("Inicjacja serwera!");
                SetText("Czekam na klientów ...");
                ClearWebBrowser();
                bgw_init_server.RunWorkerAsync();
            }
            else
            {
                server_listening = false;
                server.Stop();
                bgw_init_server.CancelAsync();
                if(clientStream != null)
                {
                    foreach (KeyValuePair<string, NetworkStream> entry in clientStream)
                    {
                        if (entry.Key != "Serwer")
                        {
                            var clients_writer = new BinaryWriter(entry.Value);
                            clients_writer.Write("---KONIEC---");
                        }
                    }
                }

                SetText("Zakończono pracę serwera!");
                btn_start.Invoke(new MethodInvoker(delegate () { btn_start.Text = "Start"; }));
                clientDict = null;
                clientStream = null;
            }

         }

        private void bgw_init_server_DoWork(object sender, DoWorkEventArgs e)
        {
            // Check ip address
            IPAddress adresIP;
            try
            {
                adresIP = IPAddress.Parse(tb_ip.Text);
            }
            catch
            {
                SetText("Błędny format adresu IP!");
                return;
            }

            // Get port
            int port = System.Convert.ToInt16(n_port.Value);
            btn_start.Invoke(new MethodInvoker(delegate () { btn_start.Text = "Stop"; }));
            try
            {
                server_listening = true;
                server = new TcpListener(adresIP, port);
                server.Start();

                while (server_listening)
                {
                    if (server.Pending())
                    {
                        TcpClient client = server.AcceptTcpClient();
                        if (clientDict == null && clientStream == null)
                        {
                            //It's null - create it
                            clientDict = new Dictionary<string, TcpClient>();
                            clientStream = new Dictionary<string, NetworkStream>();
                        }

                        NetworkStream stream = client.GetStream();
                        var nick_reader = new BinaryReader(stream).ReadString();
                        if (nick_reader.Contains("---WELCOME---"))
                        {
                            string nick = nick_reader.Substring(13);
                            clientStream.Add(nick, stream);
                            clientDict.Add(nick, client);
                            //cb_clients.Invoke(new MethodInvoker(delegate () { cb_clients.Items.Add(nick); }));
                            var new_nick_writer = new BinaryWriter(stream);
                            foreach (KeyValuePair<string, NetworkStream> entry in clientStream)
                            {
                                if (entry.Key != nick && entry.Key != "Serwer")
                                {
                                    new_nick_writer.Write("---USERADD---" + entry.Key);
                                }
                            }

                            foreach (KeyValuePair<string, NetworkStream> entry in clientStream)
                            {
                                if (entry.Key != nick)
                                {
                                    var clients_writer = new BinaryWriter(entry.Value);
                                    clients_writer.Write("---USERADD---"+nick);
                                }
                            }
                            new Thread(() => handleClient(nick)).Start();
                        }
                    }
                }            
            }
            catch (Exception ex)
            {
                lb_logs.Invoke(new MethodInvoker(delegate () { lb_logs.Items.RemoveAt(lb_logs.Items.Count - 1); }));
                SetText("Bład inicjacji serwera!");
                if (ex.Message.ToString() == "Operacja zablokowana") return;
                MessageBox.Show(ex.ToString(), "Błąd");
            }
        }

 
        private void handleClient(string nickname)
        {
            TcpClient client = clientDict[nickname];
            IPEndPoint IP = (IPEndPoint)client.Client.RemoteEndPoint;
            var reader = new BinaryReader(clientStream[nickname]);
            var writer = new BinaryWriter(clientStream[nickname]);
            if (reader.ReadString().Contains("---START---"))
            {
                SetText("Nawiązano połącznie: [" + IP.ToString() + "]");
                try
                {
                    string message;
                    while ((message = reader.ReadString()) != "---KONIEC---")
                    {
                        //if (message.Contains("---PRIVATE---"))
                        //{
                        //    message = message.Substring(13);
                        //    string[] tmp_message = message.Split(new[] { "@@@" }, StringSplitOptions.None);
                        //    if (tmp_message[1] == "Serwer")
                        //    {
                        //        WriteText("(Prywatnie) "+tmp_message[0], tmp_message[2], Client_color); 
                        //    }
                        //    else
                        //    {
                        //        var client_writer = new BinaryWriter(clientStream[tmp_message[1]]);
                        //        client_writer.Write("---PRIVATE---"+tmp_message[0] + "@@@" + tmp_message[2]);
                        //    }
                        //}
                        //else
                        //{
                            string[] tmp_message = message.Split(new[] { "@@@" }, StringSplitOptions.None);
                            WriteText(tmp_message[0], tmp_message[1], Client_color);
                            foreach (KeyValuePair<string, NetworkStream> entry in clientStream)
                            {
                                if (entry.Key != nickname)
                                {
                                    var clients_writer = new BinaryWriter(entry.Value);
                                    clients_writer.Write(tmp_message[0] + "@@@" + tmp_message[1]);
                                }
                            }
                        //}

                    }
                    foreach (KeyValuePair<string, NetworkStream> entry in clientStream)
                    {
                        if (entry.Key != nickname && entry.Key != "Serwer")
                        {
                            var clients_writer = new BinaryWriter(entry.Value);
                            clients_writer.Write("---USERREMOVE---" + nickname);
                        }
                    }
                    clientDict.Remove(nickname);
                    clientStream.Remove(nickname);
                    //cb_clients.Invoke(new MethodInvoker(delegate () {  cb_clients.Items.Remove(nickname);   }));
                    client.Close();
                    SetText("Klient się rozłączył");
                }
                catch
                {
                    string last_value = lb_logs.Items[lb_logs.Items.Count - 1].ToString();

                    if (!last_value.Contains("Zakończono pracę serwera!"))
                    {
                        SetText("Klient się rozłączył");
                    }
                    client.Close();
                }
            }
            else
            {
                SetText("Klient: [" + IP.ToString() + "] nie wykonał odpowiedniej autoryzacji! Błąd połączenia!");
                client.Close();
            }
          
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tb_edit.Text) && string.IsNullOrWhiteSpace(tb_edit.Text)) || tb_edit.Text == "\r\n")
            {
                SetText("Pusta wiadomość!");
                tb_edit.Text = "";
                return;
            }
            if (server_listening && clientStream != null)
            {
                //if ((string)cb_clients.SelectedItem == "Wszyscy")
                //{
                    WriteText("Server", tb_edit.Text, Server_color, true);
                    foreach (KeyValuePair<string, NetworkStream> entry in clientStream)
                    {
                        var writer = new BinaryWriter(entry.Value);
                        writer.Write("Serwer@@@" + tb_edit.Text);
                    }
                //}
                //else
                //{
                //    WriteText("(Prywatnie do "+ (string)cb_clients.SelectedItem + ") Ja", tb_edit.Text, dialog_color,true);
                //    var writer = new BinaryWriter(clientStream[(string)cb_clients.SelectedItem]);
                //    writer.Write("---PRIVATE---Serwer@@@" + tb_edit.Text);
                //}

            }
            else
            {
                if(clientStream == null)
                {
                    SetText("Brak klientów!");
                }
                else
                {
                    SetText("Serwer nie jest włączony!");
                }
            }
            tb_edit.Text = "";
        }

        private void EnterBetweenTag(string tag)
        {
            string tbText = tb_edit.Text;

            tb_edit.Invoke(new MethodInvoker(delegate ()
            {
                tb_edit.Focus();
                cursorPosition = tb_edit.SelectionStart;
            }));

            tb_edit.Invoke(new MethodInvoker(delegate ()
            {
                tb_edit.Text = tbText.Insert(cursorPosition, tag);
            }));

            if (tag == "<br>" || tag == "<hr>")
            {
                tb_edit.Invoke(new MethodInvoker(delegate ()
                {
                    tb_edit.Select(cursorPosition + tag.Length, 0);
                }));
                cursorPosition += tag.Length;
            }
            else
            {
                tb_edit.Invoke(new MethodInvoker(delegate ()
                {
                    tb_edit.Select(cursorPosition + tag.Length / 2, 0);
                }));
                cursorPosition += tag.Length / 2;
            }
        }

        private void TbEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                send_btn_Click(sender, e);
            }
        }

        private void bBold_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<b></b>");
        }

        private void bItalic_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<i></i>");
        }

        private void bBr_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<br>");
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<del></del>");
        }

        private void bIns_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<ins></ins>");
        }

        private void n_port_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
