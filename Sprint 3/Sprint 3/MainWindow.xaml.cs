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
using INFITF;
using MECMOD;
using PARTITF;
using HybridShapeTypeLib;
using KnowledgewareTypeLib;
using ProductStructureTypeLib;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Sprint_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        Zahnrad Zahnrad1 = new Zahnrad();
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
                Zahnrad1.material("Stahl");
            }
            else if (rb_Messing.IsChecked == true)
            {
                Zahnrad1.material("Messing");
            }
            else if (rb_Plastik.IsChecked == true)
            {
                Zahnrad1.material("Kunststoff");
            }
            else if (rb_EigenesMaterial.IsChecked == true)
            {
                Zahnrad1.materialName = txtBox_materialNameEingabe.Text;
                Zahnrad1.materialDichte = Convert.ToDouble(txtBox_materialDichteEingabe.Text);
            }
            txtblock_Ausgabe_material.Text = (Zahnrad1.materialName);
            lbl_Material.Content = "Es wurde " + Zahnrad1.materialName + " gewählt";
            Zahnrad1.berechnungMaterial();
            ausgabe();
        }

        private void rb_EigenesMaterial_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_materialName.Visibility = Visibility.Visible;
            txtBox_materialNameEingabe.Visibility = Visibility.Visible;

            txtBlock_materialDichte.Visibility = Visibility.Visible;
            txtBox_materialDichteEingabe.Visibility = Visibility.Visible;
            txtBlock_materialDichteEinheit.Visibility = Visibility.Visible;
        }
        private void rb_EigenesMaterial_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBlock_materialName.Visibility = Visibility.Hidden;
            txtBox_materialNameEingabe.Visibility = Visibility.Hidden;

            txtBlock_materialDichte.Visibility = Visibility.Hidden;
            txtBox_materialDichteEingabe.Visibility = Visibility.Hidden;
            txtBlock_materialDichteEinheit.Visibility = Visibility.Hidden;
        }

        private void Rb_berechnung1_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_EingabeName1.Text = "Modul:";
            txtBlock_EingabeName2.Text = "Teilkreisdurchmesser:";
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
            txtBlock_EingabeName1.Text = "Modul:";
            txtBlock_EingabeName2.Text = "Zähnezahl:";
            txtBox_Eingabe1.Text = "";
            txtBox_Eingabe2.Text = "";
            txtBlock_Ergebnis.Text = "Ergebnis: ";
            txtBlock_Eingabe1Einheit.Text = "";
            txtBlock_Eingabe2Einheit.Text = "";

            cBox_Verdrehen.Visibility = Visibility.Visible;
        }

        private void rb_berechnung3_Checked(object sender, RoutedEventArgs e)
        {
            txtBlock_EingabeName1.Text = "Teilkreisdurchmesser:";
            txtBlock_EingabeName2.Text = "Zähnezahl:";
            txtBox_Eingabe1.Text = "";
            txtBox_Eingabe2.Text = "";
            txtBlock_Ergebnis.Text = "Ergebnis: ";
            txtBlock_Eingabe1Einheit.Text = "mm";
            txtBlock_Eingabe2Einheit.Text = "";

            cBox_Verdrehen.Visibility = Visibility.Visible;
        }

        
        public void ausgabe() //Unterprogramm für die Ausgabe
        {
            txtblock_Ausgabe_modul.Text = (Zahnrad1.m + "mm");
            txtblock_Ausgabe_teilkreis.Text = (Zahnrad1.d + "mm");
            txtblock_Ausgabe_zähnezahl.Text = ("" + Zahnrad1.z);
            txtblock_Ausgabe_kopfspiel.Text = (Zahnrad1.c + "mm");
            txtblock_Ausgabe_zahnflankenwinkel.Text = (Zahnrad1.a + "°");
            txtblock_Ausgabe_dicke.Text = (Zahnrad1.b + "mm");
            txtblock_Ausgabe_fußkreisdurchmesser.Text = (Zahnrad1.df + "mm");
            txtblock_Ausgabe_grundkreisdurchmesser.Text = (Zahnrad1.dg + "mm");
            txtblock_Ausgabe_teilung.Text = (Zahnrad1.p + "");
            txtblock_Ausgabe_zahnhöhe.Text = (Zahnrad1.h + "mm");
            txtblock_Ausgabe_zahnkopfhöhe.Text = (Zahnrad1.ha + "mm");
            txtblock_Ausgabe_zahnfußhöhe.Text = (Zahnrad1.hf + "mm");
            txtblock_Ausgabe_kopfkreisdurchmesser_2.Text = (Zahnrad1.a + "mm");
            txtblock_Ausgabe_bohrungsdurchmesser.Text = (Zahnrad1.bd + "mm");
            txtblock_Ausgabe_volumen.Text = (Zahnrad1.V + "cm^3");
            txtblock_Ausgabe_gewicht.Text = (Zahnrad1.G + "kg");
        }




        private void btnAuswahl_Click(object sender, RoutedEventArgs e)
        {
            if (rb_berechnung1.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out Zahnrad1.m);
                Double.TryParse(txtBox_Eingabe2.Text, out Zahnrad1.d);
                Double.TryParse(txtBox_Dicke.Text, out Zahnrad1.b);
                Double.TryParse(txtBlock_Teilkegelwinkel.Text, out Zahnrad1.o);
                Double.TryParse(txtBlock_Kopfkegelwinkel.Text, out Zahnrad1.y);
                Double.TryParse(txtBox_Bohrungsdurchmesser.Text, out Zahnrad1.bd);

                if (Zahnrad1.bd > Zahnrad1.d * 0.9 || Zahnrad1.bd <= 0)
                {
                    MessageBox.Show("Der Durchmesser der Bohrung ist zu klein oder zu groß!. Bitte wiederholen Sie die Eingabe!", "Fehler!", MessageBoxButton.OK);

                }

                if (Zahnrad1.m <= 0 || Zahnrad1.d <= 0 || Zahnrad1.b <= 0)
                {
                    MessageBox.Show("Eine der Eingaben ist nicht positiv. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                    txtblock_Ausgabe_zähnezahl.Text = "";
                }
                else
                {
                    if (cBox_Verdrehen.IsChecked == true)
                    {
                        double.TryParse(txtBox_Verdrehen.Text, out Zahnrad1.beta);

                        Zahnrad1.gamma = Zahnrad1.beta * (Math.PI / 180);

                        Zahnrad1.mt = Zahnrad1.m / Math.Cos(Zahnrad1.gamma);

                        Zahnrad1.z = Zahnrad1.d / Zahnrad1.mt;

                        Int32.TryParse(Convert.ToString(Zahnrad1.z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Schrägverzahnung. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            Zahnrad1.z = Convert.ToDouble(i);
                        }

                        Zahnrad1.berechnung();

                        Zahnrad1.pt = Zahnrad1.p / Math.Cos(Zahnrad1.beta);
                        ausgabe();
                    }

                    else
                    {
                        Zahnrad1.z = Zahnrad1.d / Zahnrad1.m;

                        Int32.TryParse(Convert.ToString(Zahnrad1.z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Die Anzahl der Zähne ist keine ganze Zahl. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            Zahnrad1.z = Convert.ToDouble(i);
                        }
                        Zahnrad1.berechnung();
                        ausgabe();
                    }
                }
            }
            else if (rb_berechnung2.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out Zahnrad1.m);
                Double.TryParse(txtBox_Eingabe2.Text, out Zahnrad1.z);
                Double.TryParse(txtBox_Dicke.Text, out Zahnrad1.b);
                Double.TryParse(txtBlock_Teilkegelwinkel.Text, out Zahnrad1.o);
                Double.TryParse(txtBlock_Kopfkegelwinkel.Text, out Zahnrad1.y);
                Double.TryParse(txtBox_Bohrungsdurchmesser.Text, out Zahnrad1.bd);

                if(Zahnrad1.bd > Zahnrad1.d*0.9  || Zahnrad1.bd <= 0 )
                {
                    MessageBox.Show("Der Durchmesser der Bohrung ist zu klein oder zu groß!. Bitte wiederholen Sie die Eingabe!", "Fehler!", MessageBoxButton.OK );

                }


                if (Zahnrad1.m <= 0 || Zahnrad1.z <= 0 || Zahnrad1.b <= 0)
                {
                    MessageBox.Show("Eine der Eingaben ist nicht positiv. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                    txtblock_Ausgabe_zähnezahl.Text = "";
                }
                else
                {
                    if (cBox_Verdrehen.IsChecked == true)
                    {
                        double.TryParse(txtBox_Verdrehen.Text, out Zahnrad1.beta);

                        Zahnrad1.gamma = Zahnrad1.beta * (Math.PI / 180);

                        Zahnrad1.mt = Zahnrad1.m / Math.Cos(Zahnrad1.gamma);

                        Zahnrad1.d = Zahnrad1.mt * Zahnrad1.z;

                        Int32.TryParse(Convert.ToString(Zahnrad1.z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Schrägverzahnung. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            Zahnrad1.z = Convert.ToDouble(i);
                        }

                        Zahnrad1.berechnung();

                        Zahnrad1.pt = Zahnrad1.p / Math.Cos(Zahnrad1.gamma);
                        ausgabe();
                    }

                    else
                    {
                        Zahnrad1.d = Zahnrad1.m * Zahnrad1.z;

                        Int32.TryParse(Convert.ToString(Zahnrad1.z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Die Anzahl der Zähne ist keine ganze Zahl. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            Zahnrad1.z = Convert.ToDouble(i);
                        }
                        Zahnrad1.berechnung();
                        ausgabe();

                    }
                }
            }

            else if (rb_berechnung3.IsChecked == true)
            {
                Double.TryParse(txtBox_Eingabe1.Text, out Zahnrad1.d);
                Double.TryParse(txtBox_Eingabe2.Text, out Zahnrad1.z);
                Double.TryParse(txtBox_Dicke.Text, out Zahnrad1.b);
                Double.TryParse(txtBlock_Teilkegelwinkel.Text, out Zahnrad1.o);
                Double.TryParse(txtBlock_Kopfkegelwinkel.Text, out Zahnrad1.y);
                Double.TryParse(txtBox_Bohrungsdurchmesser.Text, out Zahnrad1.bd);

                if (Zahnrad1.bd > Zahnrad1.d * 0.9 || Zahnrad1.bd <= 0)
                {
                    MessageBox.Show("Der Durchmesser der Bohrung ist zu klein oder zu groß!. Bitte wiederholen Sie die Eingabe!", "Fehler!", MessageBoxButton.OK);

                }

                if (Zahnrad1.d <= 0 || Zahnrad1.z <= 0 || Zahnrad1.b <= 0)
                {
                    MessageBox.Show("Eine der Eingaben ist nicht positiv. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                    txtblock_Ausgabe_zähnezahl.Text = "";
                }
                else
                {
                    if (cBox_Verdrehen.IsChecked == true)
                    {
                        double.TryParse(txtBox_Verdrehen.Text, out Zahnrad1.beta);

                        Zahnrad1.gamma = Zahnrad1.beta * (Math.PI / 180);

                        Zahnrad1.mt = Zahnrad1.m / Math.Cos(Zahnrad1.gamma);

                        Zahnrad1.mt = Zahnrad1.d / Zahnrad1.z;

                        Int32.TryParse(Convert.ToString(Zahnrad1.z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Schrägverzahnung. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            Zahnrad1.z = Convert.ToDouble(i);
                        }
                        Zahnrad1.berechnung();

                        Zahnrad1.pt = Zahnrad1.p / Math.Cos(Zahnrad1.beta);

                        ausgabe();
                    }
                    else
                    {
                        Zahnrad1.m = Zahnrad1.d / Zahnrad1.z;

                        Int32.TryParse(Convert.ToString(Zahnrad1.z), out int i);
                        if (i == 0)
                        {
                            MessageBox.Show("Die Anzahl der Zähne ist keine ganze Zahl. Bitte wiederholen sie die Eingabe!", "Fehler!", MessageBoxButton.OK);
                            txtblock_Ausgabe_zähnezahl.Text = "";
                        }
                        else
                        {
                            Zahnrad1.z = Convert.ToDouble(i);
                        }

                        Zahnrad1.berechnung();
                        ausgabe();
                    }
                }

            }

            if (cBox_Kopfspiel.IsChecked == true)
            {
                double.TryParse(txtBox_Kopfspiel.Text, out Zahnrad1.c);

                Zahnrad1.df = Zahnrad1.d - (2 * (Zahnrad1.m + Zahnrad1.c));
                Zahnrad1.h = 2 * Zahnrad1.m + Zahnrad1.c;
                Zahnrad1.hf = Zahnrad1.m + Zahnrad1.c;

                txtblock_Ausgabe_kopfspiel.Text = (Zahnrad1.c + "mm");
                txtblock_Ausgabe_zahnfußhöhe.Text = (Zahnrad1.hf + "mm");
                txtblock_Ausgabe_zahnhöhe.Text = (Zahnrad1.h + "mm");
                txtblock_Ausgabe_fußkreisdurchmesser.Text = (Zahnrad1.df + "mm");
            }

            if (cBox_Zahnflankenwinkel.IsChecked == true)
            {
                double.TryParse(txtBox_Zahnflankenwinkel.Text, out Zahnrad1.a);

                Zahnrad1.alpha = Math.PI / 180 * Zahnrad1.a;
                Zahnrad1.dg = Zahnrad1.d * Math.Cos(Zahnrad1.alpha);

                txtblock_Ausgabe_zahnflankenwinkel.Text = (Zahnrad1.a + "°");
                txtblock_Ausgabe_grundkreisdurchmesser.Text = (Zahnrad1.dg + "mm");
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

        private void btn_Vis_Click(object sender, RoutedEventArgs e)
        {
            
                try
                {

                    CatiaConnection cc = new CatiaConnection();

                    // Finde Catia Prozess
                    if (cc.CATIALaeuft())
                    {

                        cc.ErzeugePart();

                        cc.ErstelleLeereSkizze();

                        cc.ErzeugeProfil(Zahnrad1);

                    }
                    else
                    {
                    MessageBox.Show("");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception aufgetreten");
                }
                Console.WriteLine("Fertig - Taste drücken.");
            }

        private void btn_Mus_Click(object sender, RoutedEventArgs e)
        {
            CatiaConnection cc = new CatiaConnection();

                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {
                    // Öffne ein neues Part
                    cc.ErzeugePart();

                    // Generiere ein Profil
                    cc.ErzeugeProfil(Zahnrad1);
                }
                else
                {
                MessageBoxResult result = MessageBox.Show("Catia Anwendung wurde noch nicht  gestartet.\nWollen sie Catia starten?", "Berechnungprogramm für Zahnräder", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                switch(result)
                {
                    case MessageBoxResult.Yes:
                        Process Catia = new Process();
                        Catia.StartInfo.FileName = "CNEXT.exe";
                        Catia.Start();
                        break;
                    case MessageBoxResult.No:

                        break;

                }
                }
        }

        
    }
}
