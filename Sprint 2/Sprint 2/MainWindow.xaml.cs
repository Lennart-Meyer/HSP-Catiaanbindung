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

        }
        private void btnZurueck_Click(object sender, RoutedEventArgs e)
        {
            if (Tab.SelectedIndex - 1 >= 0)
                Tab.SelectedIndex--;
        }
        //Zahnradauswahl        
        public int zahnradAuswahl()
        {
            if (Stirnrad.IsChecked == true)
            {
                return 1;
            }
            else if (Kegelrad.IsChecked == true)
            {
                return 2;
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
                lbl_Material.Content = "Es wurde Kunststoff gewählt";

                txtblock_Ausgabe_material.Text = ("Kunststoff");
            }
        }

        double z; //Zähnezahl
        double m; //Modul
        double d; //Teilkreisdurchmesser
        double c = 0.167; //Kopfspiel
        double a = 20; //Zahnflankenwinkel
        double b; //Breite
        double h; //Zahnhöhe
        double p; //Teilung
        double df; //Fußkreisdurchmesser
        double dg; //Grundkreisdurchmesser
        double ha; //Zahnkopfhöhe
        double hf; //Zahnfußhöhe
        double alpha; // a in Rad
        double beta; // Schrägungswinkel
        double mt; //Stirnmodul
        double pt; //Stirnteilung
        double gamma; // beta in Rad
        double o; //Teilkegelwinkel
        double y; //Kopfkegelwinkel
        double da; //Kopfkreisdurchmesser

        private void Rb_berechnung1_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_EingabeName1.Text = "Modul";
            txtBlock_EingabeName2.Text = "Teilkreisdurchmesser";
            txtBox_Eingabe1.Text = "";
            txtBox_Eingabe2.Text = "";
            txtBlock_Ergebnis.Text = "Ergebnis: ";
            txtBlock_Eingabe1Einheit.Text = "";
            txtBlock_Eingabe2Einheit.Text = "mm";
            cBox_Verdrehen.IsChecked = false;
            cBox_Verdrehen.Visibility = Visibility.Hidden;
        }

        private void rb_berechnung2_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_EingabeName1.Text = "Modul";
            txtBlock_EingabeName2.Text = "Zähnezahl";
            txtBox_Eingabe1.Text = "";
            txtBox_Eingabe2.Text = "";
            txtBlock_Ergebnis.Text = "Ergebnis: ";
            txtBlock_Eingabe1Einheit.Text = "";
            txtBlock_Eingabe2Einheit.Text = "";

            cBox_Verdrehen.Visibility = Visibility.Visible;
        }

        private void rb_berechnung3_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_EingabeName1.Text = "Teilkreisdurchmesser";
            txtBlock_EingabeName2.Text = "Zähnezahl";
            txtBox_Eingabe1.Text = "";
            txtBox_Eingabe2.Text = "";
            txtBlock_Ergebnis.Text = "Ergebnis: ";
            txtBlock_Eingabe1Einheit.Text = "mm";
            txtBlock_Eingabe2Einheit.Text = "";

            cBox_Verdrehen.Visibility = Visibility.Visible;
        }

        public void berechnung() //Unterprogramm für die Berechnung
        {
            //Zahnhöhe
            h = 2 * m + c;
            //Teilung
            p = Math.PI * m;
            //Fußkreisdurchmesser
            df = d - (2 * (m + c));
            //Grundkreisdurchmesser
            alpha = Math.PI / 180 * a; // Winkel in Radiant umrechnen
            dg = d * Math.Cos(alpha);
            //Zahnkopfhöhe
            ha = m;
            //Zahnfußhöhe
            hf = m + c;
            //Kopfkreisdurchmesser
            da = d + 2 * m * Math.Cos(o);
        }


        public void ausgabe() //Unterprogramm für die Ausgabe
        {
            txtblock_Ausgabe_modul.Text = (m + "mm");
            txtblock_Ausgabe_teilkreis.Text = (d + "mm");
            txtblock_Ausgabe_zähnezahl.Text = ("" + z);
            txtblock_Ausgabe_kopfspiel.Text = (c + "mm");
            txtblock_Ausgabe_zahnflankenwinkel.Text = (a + "°");
            txtblock_Ausgabe_dicke.Text = (b + "mm");
            txtblock_Ausgabe_fußkreisdurchmesser.Text = (df + "mm");
            txtblock_Ausgabe_grundkreisdurchmesser.Text = (dg + "mm");
            txtblock_Ausgabe_teilung.Text = (p + "");
            txtblock_Ausgabe_zahnhöhe.Text = (h + "mm");
            txtblock_Ausgabe_zahnkopfhöhe.Text = (ha + "mm");
            txtblock_Ausgabe_zahnfußhöhe.Text = (hf + "mm");
            txtblock_Ausgabe_kopfkreisdurchmesser_2.Text = (da + "mm");
        }




        private void btnAuswahl_Click(object sender, RoutedEventArgs e)
        {
            if (rb_berechnung1.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out m);
                Double.TryParse(txtBox_Eingabe2.Text, out d);
                Double.TryParse(txtBox_Dicke.Text, out b);
                Double.TryParse(txtBlock_Teilkegelwinkel.Text, out o);
                Double.TryParse(txtBlock_Kopfkegelwinkel.Text, out y);
                
                if (m <= 0 || d <= 0 || b <= 0)
                {
                    MessageBox.Show("Eine der Eingaben ist nicht positiv. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                    txtblock_Ausgabe_zähnezahl.Text = "";
                }
                else
                {
                    if (cBox_Verdrehen.IsChecked == true)
                    {
                        double.TryParse(txtBox_Verdrehen.Text, out beta);

                        gamma = beta * (Math.PI / 180);

                        mt = m / Math.Cos(gamma);

                        z = d / mt;

                        Int32.TryParse(Convert.ToString(z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Schrägverzahnung. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            z = Convert.ToDouble(i);
                        }

                        berechnung();

                        pt = p / Math.Cos(beta);
                        ausgabe();
                    }

                    else
                    {
                        z = d / m;

                        Int32.TryParse(Convert.ToString(z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Die Anzahl der Zähne ist keine ganze Zahl. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            z = Convert.ToDouble(i);
                        }
                        berechnung();
                        ausgabe();
                    }
                }
            }
            else if (rb_berechnung2.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out m);
                Double.TryParse(txtBox_Eingabe2.Text, out z);
                Double.TryParse(txtBox_Dicke.Text, out b);
                Double.TryParse(txtBlock_Teilkegelwinkel.Text, out o);
                Double.TryParse(txtBlock_Kopfkegelwinkel.Text, out y);

                if (m <= 0 || z <= 0 || b <= 0)
                {
                    MessageBox.Show("Eine der Eingaben ist nicht positiv. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                    txtblock_Ausgabe_zähnezahl.Text = "";
                }
                else
                {
                    if (cBox_Verdrehen.IsChecked == true)
                    {
                        double.TryParse(txtBox_Verdrehen.Text, out beta);

                        gamma = beta * (Math.PI / 180);

                        mt = m / Math.Cos(gamma);

                        d = mt * z;

                        Int32.TryParse(Convert.ToString(z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Schrägverzahnung. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            z = Convert.ToDouble(i);
                        }

                        berechnung();

                        pt = p / Math.Cos(gamma);
                        ausgabe();
                    }

                    else
                    {
                        d = m * z;

                        Int32.TryParse(Convert.ToString(z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Die Anzahl der Zähne ist keine ganze Zahl. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            z = Convert.ToDouble(i);
                        }
                        berechnung();
                        ausgabe();

                    }
                }
            }

            else if (rb_berechnung3.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out d);
                Double.TryParse(txtBox_Eingabe2.Text, out z);
                Double.TryParse(txtBox_Dicke.Text, out b);
                Double.TryParse(txtBlock_Teilkegelwinkel.Text, out o);
                Double.TryParse(txtBlock_Kopfkegelwinkel.Text, out y);


                if (d <= 0 || z <= 0 || b <= 0)
                {
                    MessageBox.Show("Eine der Eingaben ist nicht positiv. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                    txtblock_Ausgabe_zähnezahl.Text = "";
                }
                else
                {
                    if (cBox_Verdrehen.IsChecked == true)
                    {
                        double.TryParse(txtBox_Verdrehen.Text, out beta);

                        gamma = beta * (Math.PI / 180);

                        mt = m / Math.Cos(gamma);

                        mt = d / z;

                        Int32.TryParse(Convert.ToString(z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Schrägverzahnung. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            z = Convert.ToDouble(i);
                        }
                        berechnung();

                        pt = p / Math.Cos(beta);
                        
                        ausgabe();
                    }
                    else
                    {
                        m = d / z;

                        Int32.TryParse(Convert.ToString(z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Die Anzahl der Zähne ist keine ganze Zahl. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            z = Convert.ToDouble(i);
                        }
                        
                        berechnung();
                        ausgabe();
                    }
                }

            }

            if (cBox_Kopfspiel.IsChecked == true)
            {
                double.TryParse(txtBox_Kopfspiel.Text, out c);

                df = d - (2 * (m + c));
                h = 2 * m + c;
                hf = m + c;

                txtblock_Ausgabe_kopfspiel.Text = (c + "mm");
                txtblock_Ausgabe_zahnfußhöhe.Text = (hf + "mm");
                txtblock_Ausgabe_zahnhöhe.Text = (h + "mm");
                txtblock_Ausgabe_fußkreisdurchmesser.Text = (df + "mm");
            }

            if (cBox_Zahnflankenwinkel.IsChecked == true)
            {
                double.TryParse(txtBox_Zahnflankenwinkel.Text, out a);

                alpha = Math.PI / 180 * a;
                dg = d * Math.Cos(alpha);

                txtblock_Ausgabe_zahnflankenwinkel.Text = (a + "°");
                txtblock_Ausgabe_grundkreisdurchmesser.Text = (dg + "mm");
            }

            if (cBox_Verdrehen.IsChecked == true) 
            {
            

            }
        }
        


        private void Stirnrad_Checked(object sender, RoutedEventArgs e)
        {
            
        }


        private void Stirnrad_Unchecked(object sender, RoutedEventArgs e)

        {
        

        }
        private void Kegelrad_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_Teilkegelwinkel.Visibility = Visibility.Visible;
            txtBlock_Kopfkegelwinkel.Visibility = Visibility.Visible;
            txtBox_Teilkegelwinkel.Visibility = Visibility.Visible;
            txtBox_Kopfkegelwinkel.Visibility = Visibility.Visible;
            txtBlock_KopfkegelwinkelEinheit.Visibility = Visibility.Visible;
            txtBlock_TeilkegelwinkelEinheit.Visibility = Visibility.Visible;
            cBox_Verdrehen.Visibility = Visibility.Hidden;
            txtblock_Ausgabe_kopfkreisdurchmesser_1.Visibility = Visibility.Visible;
            txtblock_Ausgabe_kopfkreisdurchmesser_2.Visibility = Visibility.Visible;
        }

        private void Kegelrad_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBlock_Teilkegelwinkel.Visibility = Visibility.Hidden;
            txtBlock_Kopfkegelwinkel.Visibility = Visibility.Hidden;
            txtBox_Teilkegelwinkel.Visibility = Visibility.Hidden;
            txtBox_Kopfkegelwinkel.Visibility = Visibility.Hidden;
            txtBlock_KopfkegelwinkelEinheit.Visibility = Visibility.Hidden;
            txtBlock_TeilkegelwinkelEinheit.Visibility = Visibility.Hidden;
            cBox_Verdrehen.Visibility = Visibility.Visible;
            txtblock_Ausgabe_kopfkreisdurchmesser_1.Visibility = Visibility.Visible;
            txtblock_Ausgabe_kopfkreisdurchmesser_2.Visibility = Visibility.Visible;
        }

        private void cBox_Kopfspiel_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Kopfspiel.Visibility = Visibility.Visible;
            txtBlock_Kopfspiel.Visibility = Visibility.Visible;
            txtBlock_KopfspielEinheit.Visibility = Visibility.Visible;
        }

        private void cBox_Zahnflankenwinkel_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Zahnflankenwinkel.Visibility = Visibility.Visible;
            txtBlock_Zahnflankenwinkel.Visibility = Visibility.Visible;
            txtBlock_ZahnflankenwinkelEinheit.Visibility = Visibility.Visible;
        }

        private void cBox_Verdrehen_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Verdrehen.Visibility = Visibility.Visible;
            txtBlock_Verdrehen.Visibility = Visibility.Visible;
            txtBlock_VerdrehenEinheit.Visibility = Visibility.Visible;
        }

        private void cBox_Kopfspiel_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Kopfspiel.Visibility = Visibility.Hidden;
            txtBlock_Kopfspiel.Visibility = Visibility.Hidden;
            txtBlock_KopfspielEinheit.Visibility = Visibility.Hidden;
        }

        private void cBox_Zahnflankenwinkel_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Zahnflankenwinkel.Visibility = Visibility.Hidden;
            txtBlock_Zahnflankenwinkel.Visibility = Visibility.Hidden;
            txtBlock_ZahnflankenwinkelEinheit.Visibility = Visibility.Hidden;
        }

        private void cBox_Verdrehen_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Verdrehen.Visibility = Visibility.Hidden;
            txtBlock_Verdrehen.Visibility = Visibility.Hidden;
            txtBlock_VerdrehenEinheit.Visibility = Visibility.Hidden;
        }
    }
}
