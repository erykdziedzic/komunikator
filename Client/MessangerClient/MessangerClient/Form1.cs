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

		private string CLIENT_COLOR = "#ffb700";
		private string SERVER_COLOR = "#19FFB0";

		private delegate void SetTextCallBack(string text);

		private delegate void SetScrollCallBack();

		public Form1()
		{
			this.InitializeComponent();
			ClearWebBrowser();
		}

		private void ClearWebBrowser()
		{
			wbChat.Navigate("about:blank");
			HtmlDocument doc = wbChat.Document;
			doc.Write(String.Empty);
			wbChat.DocumentText = "<!DOCTYPE html> <html> <head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" /> </head> <body> </body></html>";
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
			if (this.wbChat.InvokeRequired)
			{
				Form1.SetTextCallBack method = new Form1.SetTextCallBack(this.SetTextHTML);
				base.Invoke(method, new object[]
				{
					text
				});
			}
			else
			{
				wbChat.Document.Write(text);
			}
		}

		private void SetScroll()
		{
			if (this.wbChat.InvokeRequired)
			{
				Form1.SetScrollCallBack method = new Form1.SetScrollCallBack(this.SetScroll);
				base.Invoke(method);
			}
			else
			{
				wbChat.Document.Body.ScrollIntoView(false);
			}
		}
		private void WriteText(string who, string message, string color, bool isMe = false)
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
				this.SetTextHTML(string.Concat(new string[]
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
				this.SetTextHTML(string.Concat(new string[]
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
				this.writing.Write("---WELCOME---" + tbName.Text);
				this.writing.Write("---START---");
				this.SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Autoryzacja...");
				this.activeCall = true;
				this.bStart.Text = "Stop";
				this.bwChat.RunWorkerAsync();
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
					}
					else if (message.Contains("---USERREMOVE---"))
					{
						string remove_nick = message.Substring(16);
					}
					else
					{
						string[] tmp_message = message.Split(new[] { "@@@" }, StringSplitOptions.None);
						if (tmp_message[0] == "Serwer")
						{
							this.WriteText(tmp_message[0], tmp_message[1], SERVER_COLOR);
						}
						else
						{
							this.WriteText(tmp_message[0], tmp_message[1], CLIENT_COLOR);
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
				if (string.IsNullOrWhiteSpace(tbName.Text))
				{
					SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Błędny format nicku!");
					return;
				}
				ClearWebBrowser();
				this.bwServer.RunWorkerAsync();
				this.bStart.Text = "Stop";
				this.activeCall = true;
			}
			else
			{
				this.activeCall = false;
				if (this.client != null)
				{
					this.writing.Write("---KONIEC---");
					this.client.Close();
				}
				if (this.bwChat != null && this.bwChat.IsBusy)
				{
					this.bwChat.CancelAsync();
				}
				if (this.bwServer != null && this.bwServer.IsBusy)
				{
					this.bwServer.CancelAsync();
				}
				this.bStart.Text = "Start";
			}
		}

		private void bSend_Click(object sender, EventArgs e)
		{
			bool isTextInvalid = string.IsNullOrEmpty(tbEdit.Text) && string.IsNullOrWhiteSpace(tbEdit.Text) || tbEdit.Text == "\r\n";
			if (isTextInvalid)
			{
				SetText("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]: Pusta wiadomość!");
				tbEdit.Text = "";
				return;
			}

			if (this.bwChat != null && this.bwChat.IsBusy)
			{
				this.WriteText("Ja", this.tbEdit.Text, CLIENT_COLOR, true);
				this.writing.Write(tbName.Text + "@@@" + this.tbEdit.Text);
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
			this.EnterBetweenTag("<br>");
		}

		private void bDel_Click(object sender, EventArgs e)
		{
			this.EnterBetweenTag("<del></del>");
		}

		private void bIns_Click(object sender, EventArgs e)
		{
			this.EnterBetweenTag("<ins></ins>");
		}
	}
}
