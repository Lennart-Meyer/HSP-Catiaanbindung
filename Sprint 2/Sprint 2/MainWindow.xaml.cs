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

            if (newTab < 0)
                newTab = Tab.Items.Count - 1;
            Tab.SelectedIndex = newTab;
        }
        private void rb_m_t_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Modul_1.IsEnabled = true;
            txtBox_Teilkreis_1.IsEnabled = true;

            txtBox_Modul_2.Clear();
            txtBox_Zähnezahl_1.Clear();
            txtBox_Teilkreis_2.Clear();
            txtBox_Zähnezahl_2.Clear();

        }

        private void rb_m_t_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Modul_1.IsEnabled = false;
            txtBox_Teilkreis_1.IsEnabled = false;
        }

        private void rb_m_z_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Modul_2.IsEnabled = true;
            txtBox_Zähnezahl_1.IsEnabled = true;

            txtBox_Modul_1.Clear();
            txtBox_Teilkreis_1.Clear();
            txtBox_Teilkreis_2.Clear();
            txtBox_Zähnezahl_2.Clear();
        }

        private void rb_m_z_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Modul_2.IsEnabled = false;
            txtBox_Zähnezahl_1.IsEnabled = false;
        }

        private void rb_t_z_Checked(object sender, RoutedEventArgs e)
        {
            txtBox_Teilkreis_2.IsEnabled = true;
            txtBox_Zähnezahl_2.IsEnabled = true;

            txtBox_Modul_1.Clear();
            txtBox_Teilkreis_1.Clear();
            txtBox_Modul_2.Clear();
            txtBox_Zähnezahl_1.Clear();
        }

        private void rb_t_z_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox_Teilkreis_2.IsEnabled = false;
            txtBox_Zähnezahl_2.IsEnabled = false;
        }

        double z;
        double m;
        double d;

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (rb_m_t.IsChecked == true)
            {
                Double.TryParse(txtBox_Modul_1.Text, out m);
                Double.TryParse(txtBox_Teilkreis_1.Text, out d);

                z = d / m;

                lbl_Modul.Content = "Modul:" + m;
                lbl_Teilekreis.Content = "Teilkreis:" + d;
                lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
            }

            if (rb_m_z.IsChecked == true)
            {
                Double.TryParse(txtBox_Modul_2.Text, out m);
                Double.TryParse(txtBox_Zähnezahl_1.Text, out z);

                d = z * m;

                lbl_Modul.Content = "Modul:" + m;
                lbl_Teilekreis.Content = "Teilkreis:" + d;
                lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
            }

            if (rb_t_z.IsChecked == true)
            {
                Double.TryParse(txtBox_Teilkreis_2.Text, out d);
                Double.TryParse(txtBox_Zähnezahl_2.Text, out z);

                m = d / z;

                lbl_Modul.Content = "Modul:" + m;
                lbl_Teilekreis.Content = "Teilkreis:" + d;
                lbl_Zähnezahl.Content = "Zähnezahl:" + z;
                ergebnis.Text = ("Ergebnis: \n" + "Modul: " + m + "\nTeilkreis: " + d + "\nZähnezahl: " + z);
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
                lbl_Material.Content = "Es wurde Sonstige gewählt";
            }
        }
    }
}
