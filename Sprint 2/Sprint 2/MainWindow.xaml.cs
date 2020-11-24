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
            if (Tab.SelectedIndex + 1 < Tab.Items.Count)
                Tab.SelectedIndex++;
            /*
            int newTab = Tab.SelectedIndex + 1;
            if (newTab >= Tab.Items.Count)
                newTab = 0;
            Tab.SelectedIndex = newTab;
            */
        }
        private void btnZurueck_Click(object sender, RoutedEventArgs e)
        {
            if (Tab.SelectedIndex - 1 >= 0)
                Tab.SelectedIndex--;
            
            /*
            int newTab = Tab.SelectedIndex - 1;
            if (newTab < 0 )
                newTab = Tab.Items.Count - 1;
            Tab.SelectedIndex = newTab;
            */
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
        
        private void Button_bes(object sender, RoutedEventArgs e)
        {
            if (rb_Stahl.IsChecked == true)
            {
                lbl_Material.Content = "Es wurde Stahl gewählt";

                txtblock_Ausgabe_material.Text = ("Stahl");
            }
            else if (rb_Messing.IsChecked == true)
            {
                lbl_Material.Content = "Es wurde Messing gewählt";

                txtblock_Ausgabe_material.Text = ("Messing");
            }
            else if (rb_Plastik.IsChecked == true)
            {
                lbl_Material.Content = "Es wurde Plastik gewählt";

                txtblock_Ausgabe_material.Text = ("Plastik");
            }
        }
        
        double z;
        double m;
        double d;
        double c = 0.167 ;
        double a = 20;
        double b;

        private void rb_berechnung1_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_EingabeName1.Text = "Modul";
            txtBlock_EingabeName2.Text = "Teilkreisdurchmesser";
            txtBox_Eingabe1.Text = "";
            txtBox_Eingabe2.Text = "";
            txtBlock_Ergebnis.Text = "Ergebnis: ";
        }

        private void rb_berechnung2_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_EingabeName1.Text = "Modul";
            txtBlock_EingabeName2.Text = "Zähnezahl";
            txtBox_Eingabe1.Text = "";
            txtBox_Eingabe2.Text = "";
            txtBlock_Ergebnis.Text = "Ergebnis: ";
        }

        private void rb_berechnung3_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_EingabeName1.Text = "Teilkreisdurchmesser";
            txtBlock_EingabeName2.Text = "Zähnezahl";
            txtBox_Eingabe1.Text = "";
            txtBox_Eingabe2.Text = "";
            txtBlock_Ergebnis.Text = "Ergebnis: ";
        }

        private void btnAuswahl_Click(object sender, RoutedEventArgs e)
        {
            if (rb_berechnung1.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out m);
                Double.TryParse(txtBox_Eingabe2.Text, out d);
                Double.TryParse(txtBox_Dicke.Text, out b);

                z = d / m;

                txtblock_Ausgabe_modul.Text = ("" + m);
                txtblock_Ausgabe_teilkreis.Text = ("" + d);
                txtblock_Ausgabe_zähnezahl.Text = ("" + z);
                
                //txtblock_Ausgabe_kopfspiel.Text = ("" + c);
                txtblock_Ausgabe_zahnflankenspiel.Text = (a + "°");
                txtblock_Ausgabe_dicke.Text = ("" + b);
            }
            else if (rb_berechnung2.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out m);
                Double.TryParse(txtBox_Eingabe2.Text, out z);
                Double.TryParse(txtBox_Dicke.Text, out b);

                d = m * z;

                txtblock_Ausgabe_modul.Text = ("" + m);
                txtblock_Ausgabe_teilkreis.Text = ("" + d);
                txtblock_Ausgabe_zähnezahl.Text = ("" + z);
                //txtblock_Ausgabe_kopfspiel.Text = ("" + c);
                txtblock_Ausgabe_zahnflankenspiel.Text = (a + "°");
                txtblock_Ausgabe_dicke.Text = ("" + b);
            }
            else
            if (rb_berechnung3.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out d);
                Double.TryParse(txtBox_Eingabe2.Text, out z);
                Double.TryParse(txtBox_Dicke.Text, out b);

                m = d / z;

                txtblock_Ausgabe_modul.Text = ("" + m);
                txtblock_Ausgabe_teilkreis.Text = ("" + d);
                txtblock_Ausgabe_zähnezahl.Text = ("" + z);
                //txtblock_Ausgabe_kopfspiel.Text = ("" + c);
                txtblock_Ausgabe_zahnflankenspiel.Text = (a + "°");
                txtblock_Ausgabe_dicke.Text = ("" + b);
            }
        }
        
        private void Stirnrad_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Innenverzahnung_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Kegelrad_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_SchmaleSeite.Visibility = Visibility.Visible;
            txtBlock_BreiteSeite.Visibility = Visibility.Visible;
            txtBox_Schmaleseite.Visibility = Visibility.Visible;
            txtBox_Breiteseite.Visibility = Visibility.Visible;
        }

        private void Kegelrad_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBlock_SchmaleSeite.Visibility = Visibility.Hidden;
            txtBlock_BreiteSeite.Visibility = Visibility.Hidden;
            txtBox_Schmaleseite.Visibility = Visibility.Hidden;
            txtBox_Breiteseite.Visibility = Visibility.Hidden;
        }


        private void Schneckentrieb_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Kegelrad_Unchecked_1(object sender, RoutedEventArgs e)
        {

        }

        private void cBox_Kopfspiel_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Kopfspiel.Visibility = Visibility.Visible;
            txtBlock_Kopfspiel.Visibility = Visibility.Visible;

            double.TryParse(txtBox_Kopfspiel.Text, out c);
            txtblock_Ausgabe_kopfspiel.Text = ("" + c);
        }

        private void cBox_Zahnflankenwinkel_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Zahnflankenwinkel.Visibility = Visibility.Visible;
            txtBlock_Zahnflankenwinkel.Visibility = Visibility.Visible;
        }

        private void cBox_Verdrehen_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Verdrehen.Visibility = Visibility.Visible;
            txtBlock_Verdrehen.Visibility = Visibility.Visible;
        }

        private void cBox_Kopfspiel_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Kopfspiel.Visibility = Visibility.Hidden;
            txtBlock_Kopfspiel.Visibility = Visibility.Hidden;
        }

        private void cBox_Zahnflankenwinkel_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Zahnflankenwinkel.Visibility = Visibility.Hidden;
            txtBlock_Zahnflankenwinkel.Visibility = Visibility.Hidden;
        }

        private void cBox_Verdrehen_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Verdrehen.Visibility = Visibility.Hidden;
            txtBlock_Verdrehen.Visibility = Visibility.Hidden;
        }
    }
}
