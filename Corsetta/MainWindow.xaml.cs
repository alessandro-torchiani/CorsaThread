using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Corsetta
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static object x = new object();
        Thread pilot1;
        Thread pilot2;
        Thread pilot3;
        int pos1 = 27;
        int pos2 = 27;
        int pos3 = 27;
        int arrivo = 1;
        string res = "";
        int pos0 = 27;

        public void Car1()
        {
            lock (x)
            {
                while (pos1 < 624)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        car1.Margin = new Thickness(pos1, 83, 0, 0);
                    }));
                    pos1 = pos1 + 5;
                    if(pos1-pos0 == 50)
                    Thread.Sleep(300);
                }
                if (arrivo <= 3)
                {
                    res += "\npilota1 è arrivato " + arrivo + "°";
                    arrivo++;
                }
                else
                {
                    MessageBox.Show(res);
                }
            }
        }
        public void Car2()
        {
            lock (x)
            {
                while (pos2 < 624)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        car2.Margin = new Thickness(pos2, 143, 0, 0);
                    }));
                    pos2 = pos2 + 5;
                    if (pos2 - pos0 == 50)
                        Thread.Sleep(300);
                }
                if (arrivo <= 3)
                {
                    res += "\npilota2 è arrivato " + arrivo + "°";
                    arrivo++;
                }
                else
                {
                    MessageBox.Show(res);
                }
            }
        }
        public void Car3()
        {
            lock (x)
            {
                while (pos3 < 624)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        car3.Margin = new Thickness(pos3, 204, 0, 0);
                    }));
                    pos3 = pos3 + 5;
                    if (pos3 - pos0 == 50)
                        Thread.Sleep(300);
                }
                if (arrivo <= 3)
                {
                    res += "\npilota3 è arrivato " + arrivo + "°";
                    arrivo++;
                }
                else
                {
                    MessageBox.Show(res);
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pilot1 = new Thread(Car1);
            pilot2 = new Thread(Car2);
            pilot3 = new Thread(Car3);
            pilot1.Start();
            pilot2.Start();
            pilot3.Start();
        }
    }
}
