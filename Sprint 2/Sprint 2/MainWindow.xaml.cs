using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Sprint_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnWeiter_Click(object sender, RoutedEventArgs e)
        {
            int newTab = Tab.SelectedIndex + 1;
            if (newTab >= Tab.Items.Count)
                newTab = 0;
            Tab.SelectedIndex = newTab;
        }
        private void btnZurueck_Click(object sender, RoutedEventArgs e)
        {
            int newTab = Tab.SelectedIndex - 1;
            if (newTab < 0 )
                newTab = Tab.Items.Count - 1;
            Tab.SelectedIndex = newTab;
        }
        //Zahnradauswahl        
        public int zahnradAuswahl()
        {
            if (Stirnrad.IsChecked == true)
            {
                return 1;
            }
            else if (Innenverzahnung.IsChecked == true)
            {
                return 2;
            }
            else if (Kegelrad.IsChecked == true)
            {
                return 3;
            }
            else if (Schneckentrieb.IsChecked == true)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
        private void stirnrad_Checked(object sender, RoutedEventArgs e)
        {
            if(Stirnrad.IsChecked == true)
            {
                Innenverzahnung.IsChecked = false;
                Kegelrad.IsChecked = false;
                Schneckentrieb.IsChecked = false;
            }
        }
        private void innenverzahnung_Checked(object sender, RoutedEventArgs e)
        {
            if (Innenverzahnung.IsChecked == true)
            {
                Stirnrad.IsChecked = false;
                Kegelrad.IsChecked = false;
                Schneckentrieb.IsChecked = false;
            }
        }
        private void kegelrad_Checked(object sender, RoutedEventArgs e)
        {
            if (Kegelrad.IsChecked == true)
            {
                Stirnrad.IsChecked = false;
                Innenverzahnung.IsChecked = false;
                Schneckentrieb.IsChecked = false;
            }
        }
        private void schneckentrieb_Checked(object sender, RoutedEventArgs e)
        {
            if (Schneckentrieb.IsChecked == true)
            {
                Stirnrad.IsChecked = false;
                Innenverzahnung.IsChecked = false;
                Kegelrad.IsChecked = false;
            }
        }


        private void Button_bes(object sender, RoutedEventArgs e)
        {
            if (rb_Stahl.IsChecked == true)
            {
                lbl_Material.Content = "Es wurde Stahl gewählt";
            }
            else if (rb_Messing.IsChecked == true)
            {
                lbl_Material.Content = "Es wurde Messing gewählt";
            }
            else if (rb_Plastik.IsChecked == true)
            {
                lbl_Material.Content = "Es wurde Plastik gewählt";
            }
            else if (rb_Sonstige.IsChecked == true)
            {
                lbl_Material.Content = "Es wurde Sonstige gewählt:\n" + txt_sonstige.Text;
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        double z;
        double m;
        double d;
        private void txtBox_Modul_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (zahnradAuswahl() != 0)
            {
                
                string eingabeModul = txtBox_Modul.Text;
                string eingabeTeilkreis = txtBox_Teilkreis.Text;
                string eingabeZaehnezahl = txtBox_Zähnezahl.Text;

                if(eingabeModul.Length > 0 && eingabeTeilkreis.Length > 0)
                {
                    Double.TryParse(eingabeModul, out m);
                    Double.TryParse(eingabeTeilkreis, out d);

                    if( m <= 0 || d <= 0)
                    {
                        MessageBox.Show("Werte können nicht negativ sein.\n Eingabe bitte wiederholen", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    z = d / m;
                    txtBox_Zähnezahl.Text = Convert.ToString(z);
                    lbl_Modul.Content = "Modul:" + m;
                    lbl_Teilekreis.Content = "Teilkreis:" + d;
                    lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                    ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
                }else if(eingabeModul.Length > 0 && eingabeZaehnezahl.Length > 0)
                {
                    Double.TryParse(eingabeModul, out m);
                    Double.TryParse(eingabeZaehnezahl, out z);

                    d = m * z;
                    if (m <= 0 || z <= 0)
                    {
                        MessageBox.Show("Werte können nicht negativ sein.\n Eingabe bitte wiederholen", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    txtBox_Teilkreis.Text = Convert.ToString(d);
                    lbl_Modul.Content = "Modul:" + m;
                    lbl_Teilekreis.Content = "Teilkreis:" + d;
                    lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                    ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
                }
                else
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("Zahnradtyp wurde nicht ausgewählt", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtBox_Teilkreis_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (zahnradAuswahl() != 0)
            {

                string eingabeModul = txtBox_Modul.Text;
                string eingabeTeilkreis = txtBox_Teilkreis.Text;
                string eingabeZaehnezahl = txtBox_Zähnezahl.Text;

                if (eingabeTeilkreis.Length > 0 && eingabeModul.Length > 0)
                {
                    Double.TryParse(eingabeTeilkreis, out d);
                    Double.TryParse(eingabeModul, out m);
                    

                    z = d / m;

                    if (m <= 0 || d <= 0)
                    {
                        MessageBox.Show("Werte können nicht negativ sein.\n Eingabe bitte wiederholen", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    txtBox_Zähnezahl.Text = Convert.ToString(z);
                    lbl_Modul.Content = "Modul:" + m;
                    lbl_Teilekreis.Content = "Teilkreis:" + d;
                    lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                    ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
                }
                else if (eingabeTeilkreis.Length > 0 && eingabeZaehnezahl.Length > 0)
                {
                    Double.TryParse(eingabeTeilkreis, out d);
                    Double.TryParse(eingabeZaehnezahl, out z);

                    m = d / z;

                    if (z <= 0 || d <= 0)
                    {
                        MessageBox.Show("Werte können nicht negativ sein.\n Eingabe bitte wiederholen", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    txtBox_Modul.Text = Convert.ToString(m);
                    lbl_Modul.Content = "Modul:" + m;
                    lbl_Teilekreis.Content = "Teilkreis:" + d;
                    lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                    ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
                }
                else
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("Zahnradtyp wurde nicht ausgewählt", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtBox_Zähnezahl_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (zahnradAuswahl() != 0)
            {

                string eingabeModul = txtBox_Modul.Text;
                string eingabeTeilkreis = txtBox_Teilkreis.Text;
                string eingabeZaehnezahl = txtBox_Zähnezahl.Text;

                if ( eingabeZaehnezahl.Length > 0 && eingabeModul.Length > 0)
                {
                    Double.TryParse(eingabeZaehnezahl, out z);
                    Double.TryParse(eingabeModul, out m);

                    d = z * m;

                    if (z <= 0 || m <= 0)
                    {
                        MessageBox.Show("Werte können nicht negativ sein.\n Eingabe bitte wiederholen", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    txtBox_Teilkreis.Text = Convert.ToString(d);
                    lbl_Modul.Content = "Modul:" + m;
                    lbl_Teilekreis.Content = "Teilkreis:" + d;
                    lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                    ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
                }
                else if (eingabeZaehnezahl.Length > 0 && eingabeTeilkreis.Length > 0)
                {
                    Double.TryParse(eingabeZaehnezahl, out z);
                    Double.TryParse(eingabeTeilkreis, out d);

                    m = d / z;

                    if (z <= 0 || d <= 0)
                    {
                        MessageBox.Show("Werte können nicht negativ sein.\n Eingabe bitte wiederholen", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    txtBox_Modul.Text = Convert.ToString(m);
                    lbl_Modul.Content = "Modul:" + m;
                    lbl_Teilekreis.Content = "Teilkreis:" + d;
                    lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                    ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
                }
                else
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("Zahnradtyp wurde nicht ausgewählt", "FehlerMeldung!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
