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

namespace Bonati_Cividini_Tris
{
    public partial class MainWindow : Window
    {
        private UdpClient client2;
        private UdpClient client;
        private string NickServer, NickClient;
        IPAddress ipsender;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ipsender = IPAddress.Parse(tb_IP_ospite.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            NickClient = tb_Nickname.Text==""?"Giocatore1":tb_Nickname.Text;
            client = new UdpClient(13000);
            IPEndPoint ep = new IPEndPoint(ipsender, 12000);
            var hostname = Dns.GetHostName();
            string myIP = Dns.GetHostEntry(hostname).AddressList.First(addr => addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            byte[] buf = Encoding.ASCII.GetBytes(myIP.ToString());
            client.Send(buf, buf.Length, ep);
            Gioco nuovaPartita = new Gioco(false, ipsender, NickClient);
            this.Visibility = Visibility.Hidden;
            this.Close();
            if (!nuovaPartita.IsVisible == false)
                nuovaPartita.ShowDialog();
            nuovaPartita.Visibility = Visibility.Visible;
            client.Close();
        }

        private void button_host_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer;
            NickServer = tb_Nickname.Text == "" ? NickServer = "Giocatore2" :tb_Nickname.Text;
            client2 = new UdpClient(12000);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 12000);
            do
            {
                buffer = client2.Receive(ref ep);
            } while (client2.Available < 0);
            var ipGiocatore2 = IPAddress.Parse(Encoding.ASCII.GetString(buffer));
            if (ipGiocatore2 != null)
            {
                Gioco nuovaPartita = new Gioco(true, ipGiocatore2, NickServer);
                this.Visibility = Visibility.Hidden;
                this.Close();
                if (!nuovaPartita.IsVisible == false)
                    nuovaPartita.ShowDialog();
                nuovaPartita.Visibility = Visibility.Visible;
            }
            client2.Close();
        }
    }
}
