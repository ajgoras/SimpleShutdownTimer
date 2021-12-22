using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;

namespace CzasoweWylaczenieKomputera
{
    public partial class MainWindow : Window
    {
        long time = 600;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OFFButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbhours.Text, @"^[0-9]{1,1000}$") || !Regex.IsMatch(tbmins.Text, @"^[0-9]{1,1000}$"))
            {
                MessageBox.Show("Niepoprawne dane! Wprowadź liczbę np '36'");
                return;
            }
            time = (Int32.Parse(tbhours.Text) * 3600) + (Int32.Parse(tbmins.Text) * 60);
            lbinfo.Visibility = Visibility.Visible;
            lbinfo.Content = "Komputer zostanie wyłączony za: ";
            if (tbhours.Text=="0")
            {
                lbtime.Content = "0 Godzin";
                if (tbmins.Text=="1")
                {
                    lbtime.Content += " i minutę";
                    goto startshutdown;
                }
                if (tbmins.Text=="2"|| tbmins.Text == "3"|| tbmins.Text == "4")
                {
                    lbtime.Content += $" i {tbmins.Text} minuty";
                }
                else
                {
                    lbtime.Content += $" i {tbmins.Text} minut";
                }
                goto startshutdown;
            }
            if (tbhours.Text=="1")
            {
                lbtime.Content = "1 Godzinę";
                if (tbmins.Text == "1")
                {
                    lbtime.Content += " i minutę";
                    goto startshutdown;
                }
                if (tbmins.Text == "2" || tbmins.Text == "3" || tbmins.Text == "4")
                {
                    lbtime.Content += $" i {tbmins.Text} minuty";
                }
                else
                {
                    lbtime.Content += $" i {tbmins.Text} minut";
                }
                goto startshutdown;

            }
            if (tbhours.Text=="2"|| tbhours.Text == "3"|| tbhours.Text == "4")
            {
                lbtime.Content = $"{tbhours.Text} Godziny";
                if (tbmins.Text == "1")
                {
                    lbtime.Content += " i minutę";
                    goto startshutdown;
                }
                if (tbmins.Text == "2" || tbmins.Text == "3" || tbmins.Text == "4")
                {
                    lbtime.Content += $" i {tbmins.Text} minuty";
                }
                else
                {
                    lbtime.Content += $" i {tbmins.Text} minut";
                }
                goto startshutdown;

            }
            else
            {
                lbtime.Content = $"{tbhours.Text} Godzin i {tbmins.Text} minut";
            }

            startshutdown:
            Process.Start("shutdown", $"/s /t {time}");
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("shutdown", "/a");
            lbinfo.Visibility = Visibility.Visible;
            lbinfo.Content = "Anulowano zamknięcie Systemu!";
            lbtime.Content = "";
        }
    }
}
