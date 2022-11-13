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
            this.Background = new SolidColorBrush(Color.FromArgb(100, 29, 55, 19));
            button1.Background = this.Background;
            button2.Background = this.Background;
            button3.Background = this.Background;
            button4.Background = this.Background;
            button5.Background = this.Background;
            button6.Background = this.Background;
            button7.Background = this.Background;
            button8.Background = this.Background;
            button9.Background = this.Background;
            MessageReceiver.DoWork += new DoWorkEventHandler(MessageReceiver_DoWork);
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
            Dispatcher.Invoke(() => label1.Content = "Opponent's Turn!");
            ReceiveMove();
            Dispatcher.Invoke(() => label1.Content = "Your Trun!");
            if (!CheckState())
                UnfreezeBoard();
        }

        private bool CheckState()
        {
            //Horizontals
            if (this.Dispatcher.Invoke(() => button1.Background == button2.Background && button2.Background == button3.Background && button3.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button1.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "You Won!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();

                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "You Lost!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button4.Background == button5.Background && button5.Background == button6.Background && button6.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button4.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "You Won!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "You Lost!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button7.Background == button8.Background && button8.Background == button9.Background && button9.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button7.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "You Won!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "You Lost!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            //Verticals
            else if (Dispatcher.Invoke(() => button1.Background == button4.Background && button4.Background == button7.Background && button7.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button1.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "You Won!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "You Lost!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button2.Background == button5.Background && button5.Background == button8.Background && button8.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button2.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "You Won!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "You Lost!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button3.Background == button6.Background && button6.Background == button9.Background && button9.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button3.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "You Won!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "You Lost!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button1.Background == button5.Background && button5.Background == button9.Background && button9.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button1.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "You Won!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "You Lost!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button3.Background == button5.Background && button5.Background == button7.Background && button7.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button3.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "You Won!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "You Lost!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            //Draw
            else if (Dispatcher.Invoke(() => button1.Background != this.Background && button2.Background != this.Background  && button3.Background != this.Background && button4.Background != this.Background && button5.Background != this.Background && button6.Background != this.Background && button7.Background != this.Background && button8.Background != this.Background && button9.Background != this.Background))
            {
                Dispatcher.Invoke(() => label1.Content = "You it's a draw!");
                if (Giocatore == 'X')
                    server.Close();
                if (Giocatore == 'O')
                    client.Close();
                FreezeBoard();
                return true;
            }
            return false;
        }
        private void FreezeBoard()
        {
            Dispatcher.Invoke(() =>
            {
                button1.IsHitTestVisible = false;
                button2.IsHitTestVisible = false;
                button3.IsHitTestVisible = false;
                button4.IsHitTestVisible = false;
                button5.IsHitTestVisible = false;
                button6.IsHitTestVisible = false;
                button7.IsHitTestVisible = false;
                button8.IsHitTestVisible = false;
                button9.IsHitTestVisible = false;
            });
        }

        private void UnfreezeBoard()
        {
            Dispatcher.Invoke(() =>
            {
                if (button1.Background != Brushes.Red)
                    button1.IsHitTestVisible = true;
                if (button2.Background != Brushes.Red)
                    button2.IsHitTestVisible = true;
                if (button3.Background != Brushes.Red)
                    button3.IsHitTestVisible = true;
                if (button4.Background != Brushes.Red)
                    button4.IsHitTestVisible = true;
                if (button5.Background != Brushes.Red)
                    button5.IsHitTestVisible = true;
                if (button6.Background != Brushes.Red)
                    button6.IsHitTestVisible = true;
                if (button7.Background != Brushes.Red)
                    button7.IsHitTestVisible = true;
                if (button8.Background != Brushes.Red)
                    button8.IsHitTestVisible = true;
                if (button9.Background != Brushes.Red)
                    button9.IsHitTestVisible = true;
            });
        }

        private void ReceiveMove()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, Giocatore == 'X' ? 10000 : 11000);
            byte[] buffer = new byte[1];
            buffer = Giocatore == 'X' ? server.Receive(ref ep) : client.Receive(ref ep);
            if (buffer[0] == 1)
                Dispatcher.Invoke(() => button1.Background = Brushes.Red);
            if (buffer[0] == 2)
                Dispatcher.Invoke(() => button2.Background = Brushes.Red);
            if (buffer[0] == 3)
                Dispatcher.Invoke(() => button3.Background = Brushes.Red);
            if (buffer[0] == 4)
                Dispatcher.Invoke(() => button4.Background = Brushes.Red);
            if (buffer[0] == 5)
                Dispatcher.Invoke(() => button5.Background = Brushes.Red);
            if (buffer[0] == 6)
                Dispatcher.Invoke(() => button6.Background = Brushes.Red);
            if (buffer[0] == 7)
                Dispatcher.Invoke(() => button7.Background = Brushes.Red);
            if (buffer[0] == 8)
                Dispatcher.Invoke(() => button8.Background = Brushes.Red);
            if (buffer[0] == 9)
                Dispatcher.Invoke(() => button9.Background = Brushes.Red);

        }
        private void button1_Click(object sender, RoutedEventArgs e)
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
            button1.Background = Brushes.Green;
            button1.Foreground = button1.Background;
            button1.Content = Giocatore;
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
            button2.Background = Brushes.Green;
            button2.Foreground = button2.Background;
            button2.Content = Giocatore;
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
            button3.Background = Brushes.Green;
            button3.Foreground = button3.Background;
            button3.Content = Giocatore;
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
            button4.Background = Brushes.Green;
            button4.Foreground = button4.Background;
            button4.Content = Giocatore;
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
            button5.Background = Brushes.Green;
            button5.Foreground = button5.Background;
            button5.Content = Giocatore;
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
            button6.Background = Brushes.Green;
            button6.Foreground = button6.Background;
            button6.Content = Giocatore;
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
            button7.Background = Brushes.Green;
            button7.Foreground = button7.Background;
            button7.Content = Giocatore;
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
            button8.Background = Brushes.Green;
            button8.Foreground = button8.Background;
            button8.Content = Giocatore;
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
            button9.Background = Brushes.Green;
            button9.Foreground = button9.Background;
            button9.Content = Giocatore;
            MessageReceiver.RunWorkerAsync();
        }
    }
}
