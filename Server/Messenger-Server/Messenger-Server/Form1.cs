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
        private string dialog_color = "#0078FF";
        private Dictionary<string, TcpClient> clientDict;
        private Dictionary<string, NetworkStream> clientStream;
       
        // Bad words array:
        private readonly string[] bad_words = new string[] { "chuj","chuja", "chujek", "chuju", "chujem", "chujnia",
"chujowy", "chujowa", "chujowe", "cipa", "cipę", "cipe", "cipą",
"cipie", "dojebać","dojebac", "dojebie", "dojebał", "dojebal",
"dojebała", "dojebala", "dojebałem", "dojebalem", "dojebałam",
"dojebalam", "dojebię", "dojebie", "dopieprzać", "dopieprzac",
"dopierdalać", "dopierdalac", "dopierdala", "dopierdalał",
"dopierdalal", "dopierdalała", "dopierdalala", "dopierdoli",
"dopierdolił", "dopierdolil", "dopierdolę", "dopierdole", "dopierdoli",
"dopierdalający", "dopierdalajacy", "dopierdolić", "dopierdolic",
"dupa", "dupie", "dupą", "dupcia", "dupeczka", "dupy", "dupe", "huj",
"hujek", "hujnia", "huja", "huje", "hujem", "huju", "jebać", "jebac",
"jebał", "jebal", "jebie", "jebią", "jebia", "jebak", "jebaka", "jebal",
"jebał", "jebany", "jebane", "jebanka", "jebanko", "jebankiem",
"jebanymi", "jebana", "jebanym", "jebanej", "jebaną", "jebana",
"jebani", "jebanych", "jebanymi", "jebcie", "jebiący", "jebiacy",
"jebiąca", "jebiaca", "jebiącego", "jebiacego", "jebiącej", "jebiacej",
"jebia", "jebią", "jebie", "jebię", "jebliwy", "jebnąć", "jebnac",
"jebnąc", "jebnać", "jebnął", "jebnal", "jebną", "jebna", "jebnęła",
"jebnela", "jebnie", "jebnij", "jebut", "koorwa", "kórwa", "kurestwo",
"kurew", "kurewski", "kurewska", "kurewskiej", "kurewską", "kurewska",
"kurewsko", "kurewstwo", "kurwa", "kurwaa", "kurwami", "kurwą", "kurwe",
"kurwę", "kurwie", "kurwiska", "kurwo", "kurwy", "kurwach", "kurwami",
"kurewski", "kurwiarz", "kurwiący", "kurwica", "kurwić", "kurwic",
"kurwidołek", "kurwik", "kurwiki", "kurwiszcze", "kurwiszon",
"kurwiszona", "kurwiszonem", "kurwiszony", "kutas", "kutasa", "kutasie",
"kutasem", "kutasy", "kutasów", "kutasow", "kutasach", "kutasami",
"matkojebca", "matkojebcy", "matkojebcą", "matkojebca", "matkojebcami",
"matkojebcach", "nabarłożyć", "najebać", "najebac", "najebał",
"najebal", "najebała", "najebala", "najebane", "najebany", "najebaną",
"najebana", "najebie", "najebią", "najebia", "naopierdalać",
"naopierdalac", "naopierdalał", "naopierdalal", "naopierdalała",
"naopierdalala", "naopierdalała", "napierdalać", "napierdalac",
"napierdalający", "napierdalajacy", "napierdolić", "napierdolic",
"nawpierdalać", "nawpierdalac", "nawpierdalał", "nawpierdalal",
"nawpierdalała", "nawpierdalala", "obsrywać", "obsrywac", "obsrywający",
"obsrywajacy", "odpieprzać", "odpieprzac", "odpieprzy", "odpieprzył",
"odpieprzyl", "odpieprzyła", "odpieprzyla", "odpierdalać",
"odpierdalac", "odpierdol", "odpierdolił", "odpierdolil",
"odpierdoliła", "odpierdolila", "odpierdoli", "odpierdalający",
"odpierdalajacy", "odpierdalająca", "odpierdalajaca", "odpierdolić",
"odpierdolic", "odpierdoli", "odpierdolił", "opieprzający",
"opierdalać", "opierdalac", "opierdala", "opierdalający",
"opierdalajacy", "opierdol", "opierdolić", "opierdolic", "opierdoli",
"opierdolą", "opierdola", "piczka", "pieprznięty", "pieprzniety",
"pieprzony", "pierdel", "pierdlu", "pierdolą", "pierdola", "pierdolący",
"pierdolacy", "pierdoląca", "pierdolaca", "pierdol", "pierdole",
"pierdolenie", "pierdoleniem", "pierdoleniu", "pierdolę", "pierdolec",
"pierdola", "pierdolą", "pierdolić", "pierdolicie", "pierdolic",
"pierdolił", "pierdolil", "pierdoliła", "pierdolila", "pierdoli",
"pierdolnięty", "pierdolniety", "pierdolisz", "pierdolnąć",
"pierdolnac", "pierdolnął", "pierdolnal", "pierdolnęła", "pierdolnela",
"pierdolnie", "pierdolnięty", "pierdolnij", "pierdolnik", "pierdolona",
"pierdolone", "pierdolony", "pierdołki", "pierdzący", "pierdzieć",
"pierdziec", "pizda", "pizdą", "pizde", "pizdę", "piździe", "pizdzie",
"pizdnąć", "pizdnac", "pizdu", "podpierdalać", "podpierdalac",
"podpierdala", "podpierdalający", "podpierdalajacy", "podpierdolić",
"podpierdolic", "podpierdoli", "pojeb", "pojeba", "pojebami",
"pojebani", "pojebanego", "pojebanemu", "pojebani", "pojebany",
"pojebanych", "pojebanym", "pojebanymi", "pojebem", "pojebać",
"pojebac", "pojebalo", "popierdala", "popierdalac", "popierdalać",
"popierdolić", "popierdolic", "popierdoli", "popierdolonego",
"popierdolonemu", "popierdolonym", "popierdolone", "popierdoleni",
"popierdolony", "porozpierdalać", "porozpierdala", "porozpierdalac",
"poruchac", "poruchać", "przejebać", "przejebane", "przejebac",
"przyjebali", "przepierdalać", "przepierdalac", "przepierdala",
"przepierdalający", "przepierdalajacy", "przepierdalająca",
"przepierdalajaca", "przepierdolić", "przepierdolic", "przyjebać",
"przyjebac", "przyjebie", "przyjebała", "przyjebala", "przyjebał",
"przyjebal", "przypieprzać", "przypieprzac", "przypieprzający",
"przypieprzajacy", "przypieprzająca", "przypieprzajaca",
"przypierdalać", "przypierdalac", "przypierdala", "przypierdoli",
"przypierdalający", "przypierdalajacy", "przypierdolić",
"przypierdolic", "qrwa", "rozjebać", "rozjebac", "rozjebie",
"rozjebała", "rozjebią", "rozpierdalać", "rozpierdalac", "rozpierdala",
"rozpierdolić", "rozpierdolic", "rozpierdole", "rozpierdoli",
"rozpierducha", "skurwić", "skurwiel", "skurwiela", "skurwielem",
"skurwielu", "skurwysyn", "skurwysynów", "skurwysynow", "skurwysyna",
"skurwysynem", "skurwysynu", "skurwysyny", "skurwysyński",
"skurwysynski", "skurwysyństwo", "skurwysynstwo", "spieprzać",
"spieprzac", "spieprza", "spieprzaj", "spieprzajcie", "spieprzają",
"spieprzaja", "spieprzający", "spieprzajacy", "spieprzająca",
"spieprzajaca", "spierdalać", "spierdalac", "spierdala", "spierdalał",
"spierdalała", "spierdalal", "spierdalalcie", "spierdalala",
"spierdalający", "spierdalajacy", "spierdolić", "spierdolic",
"spierdoli", "spierdoliła", "spierdoliło", "spierdolą", "spierdola",
"srać", "srac", "srający", "srajacy", "srając", "srajac", "sraj",
"sukinsyn", "sukinsyny", "sukinsynom", "sukinsynowi", "sukinsynów",
"sukinsynow", "śmierdziel", "udupić", "ujebać", "ujebac", "ujebał",
"ujebal", "ujebana", "ujebany", "ujebie", "ujebała", "ujebala",
"upierdalać", "upierdalac", "upierdala", "upierdoli", "upierdolić",
"upierdolic", "upierdoli", "upierdolą", "upierdola", "upierdoleni",
"wjebać", "wjebac", "wjebie", "wjebią", "wjebia", "wjebiemy",
"wjebiecie", "wkurwiać", "wkurwiac", "wkurwi", "wkurwia", "wkurwiał",
"wkurwial", "wkurwiający", "wkurwiajacy", "wkurwiająca", "wkurwiajaca",
"wkurwić", "wkurwic", "wkurwi", "wkurwiacie", "wkurwiają", "wkurwiali",
"wkurwią", "wkurwia", "wkurwimy", "wkurwicie", "wkurwiacie", "wkurwić",
"wkurwic", "wkurwia", "wpierdalać", "wpierdalac", "wpierdalający",
"wpierdalajacy", "wpierdol", "wpierdolić", "wpierdolic", "wpizdu",
"wyjebać", "wyjebac", "wyjebali", "wyjebał", "wyjebac", "wyjebała",
"wyjebały", "wyjebie", "wyjebią", "wyjebia", "wyjebiesz", "wyjebie",
"wyjebiecie", "wyjebiemy", "wypieprzać", "wypieprzac", "wypieprza",
"wypieprzał", "wypieprzal", "wypieprzała", "wypieprzala", "wypieprzy",
"wypieprzyła", "wypieprzyla", "wypieprzył", "wypieprzyl", "wypierdal",
"wypierdalać", "wypierdalac", "wypierdala", "wypierdalaj",
"wypierdalał", "wypierdalal", "wypierdalała", "wypierdalala",
"wypierdalać", "wypierdolić", "wypierdolic", "wypierdoli",
"wypierdolimy", "wypierdolicie", "wypierdolą", "wypierdola",
"wypierdolili", "wypierdolił", "wypierdolil", "wypierdoliła",
"wypierdolila", "zajebać", "zajebac", "zajebie", "zajebią", "zajebia",
"zajebiał", "zajebial", "zajebała", "zajebiala", "zajebali", "zajebana",
"zajebani", "zajebane", "zajebany", "zajebanych", "zajebanym",
"zajebanymi", "zajebiste", "zajebisty", "zajebistych", "zajebista",
"zajebistym", "zajebistymi", "zajebiście", "zajebiscie", "zapieprzyć",
"zapieprzyc", "zapieprzy", "zapieprzył", "zapieprzyl", "zapieprzyła",
"zapieprzyla", "zapieprzą", "zapieprza", "zapieprzy", "zapieprzymy",
"zapieprzycie", "zapieprzysz", "zapierdala", "zapierdalać",
"zapierdalac", "zapierdalaja", "zapierdalał", "zapierdalaj",
"zapierdalajcie", "zapierdalała", "zapierdalala", "zapierdalali",
"zapierdalający", "zapierdalajacy", "zapierdolić", "zapierdolic",
"zapierdoli", "zapierdolił", "zapierdolil", "zapierdoliła",
"zapierdolila", "zapierdolą", "zapierdola", "zapierniczać",
"zapierniczający", "zasrać", "zasranym", "zasrywać", "zasrywający",
"zesrywać", "zesrywający", "zjebać", "zjebac", "zjebał", "zjebal",
"zjebała", "zjebala", "zjebana", "zjebią", "zjebali", "zjeby", "zjeb" };


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

        private void WriteText(string who, string message, string color= "#0078FF", bool isMe=false)
        {
            // Check bad words
            string[] new_message = message.Split(' ');
            string ans = "";
            foreach (String word in new_message)
            {
                string original_word = word;
                string tmp_word = word.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                int pos = Array.IndexOf(bad_words, tmp_word);
                if (pos > -1)
                {
                    ans += word.Replace(tmp_word,"*****");
                }
                else
                {
                    ans += original_word + " ";
                }
            }
            message = ans.Remove(ans.Length - 1).Replace("\r\n","<br>");
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
              "<div style=\"float:right; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; display: flex; margin-bottom: 15px; padding: 10px 15px 5px 15px; border-radius: 20px; width: fit-content; flex-direction: column; background-color: "+color+";\">",
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
              "<div style=\"float:left; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; display: flex; margin-bottom: 15px; padding: 10px 15px 5px 15px; border-radius: 20px; width: fit-content; flex-direction: column; background-color: "+color+";\">",
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
                        if (message.Contains("---PRIVATE---"))
                        {
                            message = message.Substring(13);
                            string[] tmp_message = message.Split(new[] { "@@@" }, StringSplitOptions.None);
                            if (tmp_message[1] == "Serwer")
                            {
                                WriteText("(Prywatnie) "+tmp_message[0], tmp_message[2], "#fb3c4c"); 
                            }
                            else
                            {
                                var client_writer = new BinaryWriter(clientStream[tmp_message[1]]);
                                client_writer.Write("---PRIVATE---"+tmp_message[0] + "@@@" + tmp_message[2]);
                            }
                        }
                        else
                        {
                            string[] tmp_message = message.Split(new[] { "@@@" }, StringSplitOptions.None);
                            WriteText(tmp_message[0], tmp_message[1],dialog_color);
                            foreach (KeyValuePair<string, NetworkStream> entry in clientStream)
                            {
                                if (entry.Key != nickname)
                                {
                                    var clients_writer = new BinaryWriter(entry.Value);
                                    clients_writer.Write(tmp_message[0] + "@@@" + tmp_message[1]);
                                }
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
                    WriteText("Server", tb_edit.Text, dialog_color,true);
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
                cursorPosition = tb_edit.Text.Length;
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
