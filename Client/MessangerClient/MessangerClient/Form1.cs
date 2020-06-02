using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MessangerClient
{
	public partial class Form1 : Form
	{

		private TcpClient client = null;

		private BinaryReader reading = null;

		private BinaryWriter writing = null;

		private int cursorPosition = 0;

		private bool activeCall = false;

		private string dialog_color = "#0078FF";

		private delegate void SetTextCallBack(string text);

		private delegate void SetScrollCallBack();

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
		public Form1()
		{
			this.InitializeComponent();
			ClearWebBrowser();
			//cb_clients.Items.Add("Wszyscy");
			//cb_clients.Items.Add("Serwer");
			//cb_clients.SelectedItem = "Wszyscy";
		}

		private void ClearWebBrowser()
		{
			wbConversation.Navigate("about:blank");
			HtmlDocument doc = wbConversation.Document;
			doc.Write(String.Empty);
			wbConversation.DocumentText = "<!DOCTYPE html> <html> <head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" /> </head> <body> </body></html>";
		}



		private void SetText(string text)
		{
			if (this.lbConfig.InvokeRequired)
			{
				Form1.SetTextCallBack method = new Form1.SetTextCallBack(this.SetText);
				base.Invoke(method, new object[]
				{
					text
				});
			}
			else
			{
				this.lbConfig.Items.Add(text);
				lbConfig.SelectedIndex = lbConfig.Items.Count - 1;
				lbConfig.SelectedIndex = -1;
			}
		}

		private void SetTextHTML(string text)
		{
			if (this.wbConversation.InvokeRequired)
			{
				Form1.SetTextCallBack method = new Form1.SetTextCallBack(this.SetTextHTML);
				base.Invoke(method, new object[]
				{
					text
				});
			}
			else
			{
				wbConversation.Document.Write(text);
			}
		}

		private void SetScroll()
		{
			if (this.wbConversation.InvokeRequired)
			{
				Form1.SetScrollCallBack method = new Form1.SetScrollCallBack(this.SetScroll);
				base.Invoke(method);
			}
			else
			{
				wbConversation.Document.Body.ScrollIntoView(false);
			}
		}
		private void WriteText(string who, string message, string color = "#0078FF", bool isMe = false)
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
					ans += word.Replace(tmp_word, "*****");
				}
				else
				{
					ans += original_word + " ";
				}
			}
			message = ans.Remove(ans.Length - 1).Replace("\r\n", "<br>");
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
				this.SetTextHTML(string.Concat(new string[]
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
				this.SetTextHTML(string.Concat(new string[]
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

			this.SetScroll();
		}

		private void bwServerConnection_DoWork(object sender, DoWorkEventArgs e)
		{
			IPAddress adresIP;
			try
			{
				adresIP = IPAddress.Parse(tbIP.Text);
			}
			catch
			{
				MessageBox.Show("Błędny format adresu IP!", "Błąd");
				return;
			}

			try
			{
				this.client = new TcpClient(adresIP.ToString(), (int)this.nudPort.Value);
				NetworkStream stream = this.client.GetStream();
				this.reading = new BinaryReader(stream);
				this.writing = new BinaryWriter(stream);
				this.writing.Write("---WELCOME---" + tb_nickname.Text);
				this.writing.Write("---START---");
				this.SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Autoryzacja...");
				this.activeCall = true;
				this.bStart.Text = "Stop";
				this.bwConversation.RunWorkerAsync();
			}
			catch
			{
				this.SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Nie połączono");
				this.activeCall = false;
				this.bStart.Invoke(new MethodInvoker(delegate ()
				{
					this.bStart.Text = "Start";
				}));
			}
		}

		private void bwConversation_DoWork(object sender, DoWorkEventArgs e)
		{
			this.SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Autoryzacja udana");
			try
			{
				string message;
				while ((message = this.reading.ReadString()) != "---KONIEC---")
				{
					if (message.Contains("---USERADD---"))
					{
						string new_nick = message.Substring(13);
						//if (!cb_clients.Items.Contains(new_nick))
						//{
						//	cb_clients.Invoke(new MethodInvoker(delegate () { cb_clients.Items.Add(new_nick); }));
						//}
					}
					else if (message.Contains("---USERREMOVE---"))
					{
						string remove_nick = message.Substring(16);
						//if (cb_clients.Items.Contains(remove_nick))
						//{
						//	cb_clients.Invoke(new MethodInvoker(delegate () { cb_clients.Items.Remove(remove_nick); }));
						//}
					}
					else if (message.Contains("---PRIVATE---"))
					{
						message = message.Substring(13);
						string[] tmp_message = message.Split(new[] { "@@@" }, StringSplitOptions.None);
						this.WriteText("(Prywatnie) " + tmp_message[0], tmp_message[1], "#fb3c4c");
					}
					else
					{
						string[] tmp_message = message.Split(new[] { "@@@" }, StringSplitOptions.None);
						if (tmp_message[0] == "Serwer")
						{
							this.WriteText(tmp_message[0], tmp_message[1], "#fb3c4c");
						}
						else
						{
							this.WriteText(tmp_message[0], tmp_message[1], dialog_color);
						}
					}
				}
				this.SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Przerwano połączenie!");
				this.activeCall = false;
				this.bStart.Invoke(new MethodInvoker(delegate ()
				{
					this.bStart.Text = "Start";
				}));
				this.client.Close();
			}
			catch
			{
				this.SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Połączenie przerwano!");
				this.activeCall = false;
				this.bStart.Invoke(new MethodInvoker(delegate ()
				{
					this.bStart.Text = "Start";
				}));
				this.client.Close();
			}
		}

		private void bStart_Click(object sender, EventArgs e)
		{
			if (!this.activeCall)
			{
				if (string.IsNullOrWhiteSpace(tb_nickname.Text))
				{
					SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Błędny format nicku!");
					return;
				}
				ClearWebBrowser();
				this.bwServerConnection.RunWorkerAsync();
				this.bStart.Text = "Stop";
				this.activeCall = true;
			}
			else
			{
				this.activeCall = false;
				if (this.client != null)
				{
					this.writing.Write("---KONIEC---");
					//cb_clients.Items.Clear();
					//cb_clients.Items.Add("Wszyscy");
					//cb_clients.Items.Add("Serwer");
					//cb_clients.SelectedItem = "Wszyscy";
					this.client.Close();
				}
				if (this.bwConversation != null && this.bwConversation.IsBusy)
				{
					this.bwConversation.CancelAsync();
				}
				if (this.bwServerConnection != null && this.bwServerConnection.IsBusy)
				{
					this.bwServerConnection.CancelAsync();
				}
				this.bStart.Text = "Start";
			}
		}

		private void bSend_Click(object sender, EventArgs e)
		{
			if ((string.IsNullOrEmpty(tbEdit.Text) && string.IsNullOrWhiteSpace(tbEdit.Text)) || tbEdit.Text == "\r\n")
			{
				SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Pusta wiadomość!");
				tbEdit.Text = "";
				return;
			}
			if (this.bwConversation != null && this.bwConversation.IsBusy)
			{
				this.WriteText("Ja", this.tbEdit.Text, dialog_color, true);
				this.writing.Write(tb_nickname.Text + "@@@" + this.tbEdit.Text);
				//if (cb_clients.SelectedItem == "Wszyscy")
				//{

				//}
				//else
				//{
				//	this.WriteText("(Prywatnie do " + (string)cb_clients.SelectedItem + ") Ja", this.tbEdit.Text, dialog_color, true);
				//	this.writing.Write("---PRIVATE---" + tb_nickname.Text + "@@@" + (string)cb_clients.SelectedItem + "@@@" + this.tbEdit.Text);
				//}
			}
			else
			{
				this.SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Nie nawiązano połączenia");
			}
			this.tbEdit.Text = "";
		}

		private void EnterBetweenTag(string tag)
		{
			string tbText = this.tbEdit.Text;

			this.tbEdit.Invoke(new MethodInvoker(delegate ()
			{
				this.tbEdit.Focus();
				this.cursorPosition = tbEdit.Text.Length;
			}));

			this.tbEdit.Invoke(new MethodInvoker(delegate ()
			{
				this.tbEdit.Text = tbText.Insert(this.cursorPosition, tag);
			}));

			if (tag == "<br>" || tag == "<hr>")
			{
				this.tbEdit.Invoke(new MethodInvoker(delegate ()
				{
					this.tbEdit.Select(this.cursorPosition + tag.Length, 0);
				}));
				this.cursorPosition += tag.Length;
			}
			else
			{
				this.tbEdit.Invoke(new MethodInvoker(delegate ()
				{
					this.tbEdit.Select(this.cursorPosition + tag.Length / 2, 0);
				}));
				this.cursorPosition += tag.Length / 2;
			}
		}

		private void tbEdit_MouseUp(object sender, MouseEventArgs e)
		{
			this.cursorPosition = this.tbEdit.SelectionStart;
		}

		private void tbEdit_KeyUp(object sender, KeyEventArgs e)
		{
			this.cursorPosition = this.tbEdit.SelectionStart;
		}

		private void tbEdit_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				this.bSend_Click(sender, e);
			}
		}

		private void bBold_Click(object sender, EventArgs e)
		{
			this.EnterBetweenTag("<b></b>");
		}

		private void bItalic_Click(object sender, EventArgs e)
		{
			this.EnterBetweenTag("<i></i>");
		}

		private void bBr_Click(object sender, EventArgs e)
		{
			this.EnterBetweenTag("<br />");
		}

		private void bDel_Click(object sender, EventArgs e)
		{
			this.EnterBetweenTag("<del></del>");
		}

		private void bIns_Click(object sender, EventArgs e)
		{
			this.EnterBetweenTag("<ins></ins>");
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void tbIP_TextChanged(object sender, EventArgs e)
		{

		}

		private void nudPort_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}
