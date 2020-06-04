using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Server
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
        }
        private void ClearWebBrowser()
        {
            webBrowserMain.Navigate("about:blank");
            HtmlDocument doc = webBrowserMain.Document;
            doc.Write(String.Empty);
            webBrowserMain.DocumentText = "<!DOCTYPE html> <html> <head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" /> </head> <body> </body></html>";
        }
        private void SetTextHTML(string text)
        {
            if (webBrowserMain.InvokeRequired)
            {
                Form.SetTextCallBack method = new Form.SetTextCallBack(SetTextHTML);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                webBrowserMain.Document.Write(text);
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
              "</div>","<div style=\"text-align: right; font-size: 13px; margin-right: 2px; margin-top: 5px; \">",
              who,
              " o ",
              DateTime.Now.ToShortTimeString(),
              "</div></div>","<div style=\"clear: both;\"></div>"
                }));
            }
            else
            {
                SetTextHTML(string.Concat(new string[]
{
              "<div style=\"float:left; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; display: flex; margin-bottom: 15px; padding: 10px 15px 5px 15px; width: fit-content; flex-direction: column; background-color: "+color+";\">",
              "<div style=\"word-wrap: break-word; \">",
              message,
              "</div>","<div style=\"text-align: right; font-size: 13px; margin-right: 2px; margin-top: 5px; \">",
              who,
              " o ",
              DateTime.Now.ToShortTimeString(),
              "</div></div>","<div style=\"clear: both;\"></div>"
                }));
            }
            SetScroll();
        }

        private void SetText(string text)
        {
            if (listBox_Console.InvokeRequired)
            {
                Form.SetTextCallBack method = new Form.SetTextCallBack(SetText);
                base.Invoke(method, new object[]{text});
            }
            else
            {
                listBox_Console.Items.Add("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: "+text);
                listBox_Console.SelectedIndex = listBox_Console.Items.Count - 1;
                listBox_Console.SelectedIndex = -1;
            }
        }

        private void SetScroll()
        {
            if (webBrowserMain.InvokeRequired)
            {
                Form.SetScrollCallBack method = new Form.SetScrollCallBack(SetScroll);
                base.Invoke(method);
            }
            else
            {
                webBrowserMain.Document.Body.ScrollIntoView(false);
            }
        }


        private async void  btn_start_Click(object sender, EventArgs e)
        {
            if (!server_listening)
            {
                SetText("Server Started, awaiting...");
                ClearWebBrowser();
                backgroundWorkerStartServer.RunWorkerAsync();
            }
            else
            {
                server_listening = false;
                server.Stop();
                backgroundWorkerStartServer.CancelAsync();
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
                SetText("Server closed");
                buttonStart.Invoke(new MethodInvoker(delegate () { buttonStart.Text = "Start"; }));
                clientDict = null;
                clientStream = null;
            }
         }

        private void backgroundWorkerStartServer_DoWork(object sender, DoWorkEventArgs e)
        {
            // Check ip address
            IPAddress adresIP;
            try
            {
                adresIP = IPAddress.Parse(textBoxAddress.Text);
            }
            catch
            {
                SetText("Bad IP format");
                return;
            }
            // Get port
            int port = System.Convert.ToInt16(numericUpDownPort.Value);
            buttonStart.Invoke(new MethodInvoker(delegate () { buttonStart.Text = "Stop"; }));
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
                listBox_Console.Invoke(new MethodInvoker(delegate () { listBox_Console.Items.RemoveAt(listBox_Console.Items.Count - 1); }));
                SetText("Error, cant start server");
                if (ex.Message.ToString() == "Operacja zablokowana") return;
                MessageBox.Show(ex.ToString(), "error");
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
                SetText("Connected: [" + IP.ToString() + "]");
                try
                {
                    string message;
                    while ((message = reader.ReadString()) != "---KONIEC---")
                    {
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
                    client.Close();
                    SetText("Client Disconnected");
                }
                catch
                {
                    string last_value = listBox_Console.Items[listBox_Console.Items.Count - 1].ToString();
                    if (!last_value.Contains("Server closed"))
                    {
                        SetText("Client Disconnected");
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
            if ((string.IsNullOrEmpty(textBoxMessage.Text) && string.IsNullOrWhiteSpace(textBoxMessage.Text)) || textBoxMessage.Text == "\r\n")
            {
                SetText("Empty!");
                textBoxMessage.Text = "";
                return;
            }
            if (server_listening && clientStream != null)
            {
                    WriteText("Server", textBoxMessage.Text, Server_color, true);
                    foreach (KeyValuePair<string, NetworkStream> entry in clientStream)
                    {
                        var writer = new BinaryWriter(entry.Value);
                        writer.Write("Serwer@@@" + textBoxMessage.Text);
                    }
            }
            else
            {
                if(clientStream == null)
                {
                    SetText("No Clients");
                }
                else
                {
                    SetText("Server is off");
                }
            }
            textBoxMessage.Text = "";
        }
        private void EnterBetweenTag(string tag)
        {
            string tbText = textBoxMessage.Text;
            textBoxMessage.Invoke(new MethodInvoker(delegate ()
            {
                textBoxMessage.Focus();
                cursorPosition = textBoxMessage.SelectionStart;
            }));
            textBoxMessage.Invoke(new MethodInvoker(delegate ()
            {
                textBoxMessage.Text = tbText.Insert(cursorPosition, tag);
            }));
            if (tag == "<br>" || tag == "<hr>")
            {
                textBoxMessage.Invoke(new MethodInvoker(delegate ()
                {
                    textBoxMessage.Select(cursorPosition + tag.Length, 0);
                }));
                cursorPosition += tag.Length;
            }
            else
            {
                textBoxMessage.Invoke(new MethodInvoker(delegate ()
                {
                    textBoxMessage.Select(cursorPosition + tag.Length / 2, 0);
                }));
                cursorPosition += tag.Length / 2;
            }
        }

        private void textBoxMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                send_btn_Click(sender, e);
            }
        }
        private void buttonBold_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<b></b>");
        }
        private void buttonItalic_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<i></i>");
        }
        private void buttonBr_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<br>");
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<del></del>");
        }
        private void buttonIns_Click(object sender, EventArgs e)
        {
            EnterBetweenTag("<ins></ins>");
        }

        private void listBox_Console_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
