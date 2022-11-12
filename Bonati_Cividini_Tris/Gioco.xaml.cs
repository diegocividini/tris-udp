using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;

namespace Bonati_Cividini_Tris
{
    /// <summary>
    /// Logica di interazione per Gioco.xaml
    /// </summary>
    public partial class Gioco : Window
    {
        IPAddress ip;
        int porta;
        private UdpClient client;
        private UdpClient server = null;
        private char Giocatore;
        private char Avversario;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        public Gioco(bool isHost, IPAddress ip = null)
        {
            this.ip = ip;
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            if (isHost)
            {
                Giocatore = 'X';
                Avversario = 'O';
                server = new UdpClient(10000);
                porta = 11000;
            }
            else
            {
                Giocatore = 'O';
                Avversario = 'X';
                porta = 10000;
                try
                {
                    client = new UdpClient(11000);
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckState())
                return;
            FreezeBoard();
            label1.Content = "Opponent's Turn!";
            ReceiveMove();
            label1.Content = "Your Trun!";
            if (!CheckState())
                UnfreezeBoard();
        }

        private bool CheckState()
        {
            //Horizontals
            if (button1.Content == button2.Content && button2.Content == button3.Content && button3.Content != "")
            {
                if (button1.Content.ToString().Contains(Giocatore))
                {
                    label1.Content = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Content = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button4.Content == button5.Content && button5.Content == button6.Content && button6.Content != "")
            {
                if (button4.Content.ToString().Contains(Giocatore))
                {
                    label1.Content = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Content = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button7.Content == button8.Content && button8.Content == button9.Content && button9.Content != "")
            {
                if (button7.Content.ToString().Contains(Giocatore))
                {
                    label1.Content = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Content = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            //Verticals
            else if (button1.Content == button4.Content && button4.Content == button7.Content && button7.Content != "")
            {
                if (button1.Content.ToString().Contains(Giocatore))
                {
                    label1.Content = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Content = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button2.Content == button5.Content && button5.Content == button8.Content && button8.Content != "")
            {
                if (button2.Content.ToString().Contains(Giocatore))
                {
                    label1.Content = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Content = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Content == button6.Content && button6.Content == button9.Content && button9.Content != "")
            {
                if (button3.Content.ToString().Contains(Giocatore))
                {
                    label1.Content = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Content = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button1.Content == button5.Content && button5.Content == button9.Content && button9.Content != "")
            {
                if (button1.Content.ToString().Contains(Giocatore))
                {
                    label1.Content = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Content = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Content == button5.Content && button5.Content == button7.Content && button7.Content != "")
            {
                if (button3.Content.ToString().Contains(Giocatore))
                {
                    label1.Content = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Content = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            //Draw
            else if (button1.Content.ToString() != "" && button2.Content.ToString() != "" && button3.Content.ToString() != "" && button4.Content.ToString() != "" && button5.Content.ToString() != "" && button6.Content.ToString() != "" && button7.Content.ToString() != "" && button8.Content.ToString() != "" && button9.Content.ToString() != "")
            {
                label1.Content = "It's a draw!";
                if (Giocatore == 'X')
                    server.Close();
                if (Giocatore == 'O')
                    client.Close();
                MessageBox.Show("It's a draw!");
                return true;
            }
            return false;
        }
        private void FreezeBoard()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
        }

        private void UnfreezeBoard()
        {
            if (button1.Content.ToString() == "")
                button1.IsEnabled = true;
            if (button2.Content.ToString() == "")
                button2.IsEnabled = true;
            if (button3.Content.ToString() == "")
                button3.IsEnabled = true;
            if (button4.Content.ToString() == "")
                button4.IsEnabled = true;
            if (button5.Content.ToString() == "")
                button5.IsEnabled = true;
            if (button6.Content.ToString() == "")
                button6.IsEnabled = true;
            if (button7.Content.ToString() == "")
                button7.IsEnabled = true;
            if (button8.Content.ToString() == "")
                button8.IsEnabled = true;
            if (button9.Content.ToString() == "")
                button9.IsEnabled = true;
        }

        private void ReceiveMove()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, Giocatore == 'X' ? 10000 : 11000);
            byte[] buffer = new byte[1];
            buffer = Giocatore == 'X' ? server.Receive(ref ep) : client.Receive(ref ep);
            if (buffer[0] == 1)
                button1.Content = Avversario.ToString();
            if (buffer[0] == 2)
                button2.Content = Avversario.ToString();
            if (buffer[0] == 3)
                button3.Content = Avversario.ToString();
            if (buffer[0] == 4)
                button4.Content = Avversario.ToString();
            if (buffer[0] == 5)
                button5.Content = Avversario.ToString();
            if (buffer[0] == 6)
                button6.Content = Avversario.ToString();
            if (buffer[0] == 7)
                button7.Content = Avversario.ToString();
            if (buffer[0] == 8)
                button8.Content = Avversario.ToString();
            if (buffer[0] == 9)
                button9.Content = Avversario.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 1 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button1.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 2 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button2.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 3 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button3.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 4 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button4.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 5 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button5.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 6 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button6.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 7 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button7.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 8 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button8.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 9 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button9.Content = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }
    }
}
