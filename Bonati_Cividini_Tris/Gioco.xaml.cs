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
using System.Diagnostics;

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
        private BackgroundWorker RicevitoreMossa = new BackgroundWorker();
        private Stopwatch timerMossa = new Stopwatch();

        public Gioco(bool isHost, IPAddress ip = null, string nickname=null)
        {
            this.ip = ip;
            
            InitializeComponent();
            label2.Content= nickname;
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
            RicevitoreMossa.DoWork += new DoWorkEventHandler(CheckRiceviMossa);
            if (isHost)
            {
                Giocatore = 'X';
                Avversario = 'O';
                server = new UdpClient(10000);
                server.Client.ReceiveTimeout= 30000;
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
                    client.Client.ReceiveTimeout = 30000;
                    RicevitoreMossa.RunWorkerAsync();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
        private void CheckRiceviMossa(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (CheckState())
                    return;
                FreezeBoard();
                Dispatcher.Invoke(() => label1.Content = "Turno dell'avversario!");
                RiceviMossa();
                Dispatcher.Invoke(() => label1.Content = "Tuo turno!");
                if (!CheckState())
                    UnfreezeBoard();
            } catch (SocketException ex)
            {
                MessageBox.Show("L'avversario si è disconnesso,abbandonare il gioco!", "Disconnessione", MessageBoxButton.OK, MessageBoxImage.Error);
                FreezeBoard();
            }

           
        }

        private bool CheckState()
        {
            //Controllo per la vittoria orizzontale 
            if (this.Dispatcher.Invoke(() => button1.Background.ToString() == button2.Background.ToString() && button2.Background.ToString() == button3.Background.ToString() && button3.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button1.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Vinto!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Perso!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button4.Background.ToString() == button5.Background.ToString() && button5.Background.ToString() == button6.Background.ToString() && button6.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button4.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Vinto!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Perso!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button7.Background.ToString() == button8.Background.ToString() && button8.Background.ToString() == button9.Background.ToString() && button9.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button7.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Vinto!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Perso!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            //Controllo per la vittoria verticale
            else if (Dispatcher.Invoke(() => button1.Background.ToString() == button4.Background.ToString() && button4.Background.ToString() == button7.Background.ToString() && button7.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button1.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Vinto!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Perso!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button2.Background.ToString() == button5.Background.ToString() && button5.Background.ToString() == button8.Background.ToString() && button8.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button2.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Vinto!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Perso!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button3.Background.ToString() == button6.Background.ToString() && button6.Background.ToString() == button9.Background.ToString() && button9.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button3.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Vinto!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Perso!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }
            //Controllo per la vittoria obliqua
            else if (Dispatcher.Invoke(() => button1.Background.ToString() == button5.Background.ToString() && button5.Background.ToString() == button9.Background.ToString() && button9.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button1.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Vinto!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Perso!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            else if (Dispatcher.Invoke(() => button3.Background.ToString() == button5.Background.ToString() && button5.Background.ToString() == button7.Background.ToString() && button7.Background != this.Background))
            {
                if (Dispatcher.Invoke(() => button3.Content.ToString() == Giocatore.ToString()))
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Vinto!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                else
                {
                    Dispatcher.Invoke(() => label1.Content = "Hai Perso!");
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                }
                FreezeBoard();
                return true;
            }

            //Controllo per il pareggio
            else if (Dispatcher.Invoke(() => button1.Background != this.Background && button2.Background != this.Background  && button3.Background != this.Background && button4.Background != this.Background && button5.Background != this.Background && button6.Background != this.Background && button7.Background != this.Background && button8.Background != this.Background && button9.Background != this.Background))
            {
                Dispatcher.Invoke(() => label1.Content = "Pareggio!");
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
                if (button1.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button1.IsHitTestVisible = true;
                if (button2.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button2.IsHitTestVisible = true;
                if (button3.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button3.IsHitTestVisible = true;
                if (button4.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button4.IsHitTestVisible = true;
                if (button5.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button5.IsHitTestVisible = true;
                if (button6.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button6.IsHitTestVisible = true;
                if (button7.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button7.IsHitTestVisible = true;
                if (button8.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button8.IsHitTestVisible = true;
                if (button9.Background != new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)))
                    button9.IsHitTestVisible = true;
            });
        }

        private void RiceviMossa()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, Giocatore == 'X' ? 10000 : 11000);
            byte[] buffer = new byte[1];
            buffer = Giocatore == 'X' ? server.Receive(ref ep) : client.Receive(ref ep);
            
            
            if (buffer[0] == 1)
                Dispatcher.Invoke(() => { button1.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button1.Content = Avversario.ToString(); });
            if (buffer[0] == 2)
                Dispatcher.Invoke(() => { button2.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button2.Content = Avversario.ToString(); });
            if (buffer[0] == 3)
                Dispatcher.Invoke(() => { button3.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button3.Content = Avversario.ToString(); });
            if (buffer[0] == 4)
                Dispatcher.Invoke(() => { button4.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button4.Content = Avversario.ToString(); });
            if (buffer[0] == 5)
                Dispatcher.Invoke(() => { button5.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button5.Content = Avversario.ToString(); });
            if (buffer[0] == 6)
                Dispatcher.Invoke(() => { button6.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button6.Content = Avversario.ToString(); });
            if (buffer[0] == 7)
                Dispatcher.Invoke(() => { button7.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button7.Content = Avversario.ToString(); });
            if (buffer[0] == 8)
                Dispatcher.Invoke(() => { button8.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button8.Content = Avversario.ToString(); });
            if (buffer[0] == 9)
                Dispatcher.Invoke(() => { button9.Background = new SolidColorBrush(Color.FromArgb(100, 250, 70, 70)); button9.Content = Avversario.ToString(); });

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
            button1.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button1.Foreground = Brushes.White;
            button1.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
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
            button2.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button2.Foreground = Brushes.White;
            button2.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
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
            button3.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button3.Foreground = Brushes.White;
            button3.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
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
            button4.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button4.Foreground = Brushes.White;
            button4.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
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
            button5.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button5.Foreground = Brushes.White;
            button5.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
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
            button6.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button6.Foreground = Brushes.White;
            button6.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
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
            button7.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button7.Foreground = Brushes.White;
            button7.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
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
            button8.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button8.Foreground = Brushes.White;
            button8.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
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
            button9.Background = new SolidColorBrush(Color.FromArgb(100,95,186,60));
            button9.Foreground = Brushes.White;
            button9.Content = Giocatore;
            RicevitoreMossa.RunWorkerAsync();
        }
    }
}
