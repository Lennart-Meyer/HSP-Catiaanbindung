using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CatiaAnbindung
{
    class Program
    {


        static void Main(string[] args)
        {
            Double m;       //m = Modul
            Double p;       //p = Teilung
            Double d;       //d = Teilkreisdurchmesser
            Double da;      //da = Kopfkreisdurchmesser
            Double df;      //df = Fußkreisdurchmesser
            Double z;       //z = Zähnezahl
            Double h;       //h = Zahnhöhe   
            Double ha;      //ha = Zahnkopfhöhe
            Double hf;      //hf = Zahnfußhöhe
            Double c;       //c = Kopfspiel
            Double a;       //a = Achsenabstand
            Double alpha;   //Nachnorm 20°
            Double dg;      //dg = Grundkreisdurchmesser
            Double br;      //Br = Breite des Zahnrades
            string material;


            int berechnungsWahl = 0;     //späterer Speicherort für die Eingabe als Int


            bool isValid = false;
            Console.WriteLine("\n\t\tZahnradkonfigurator von Gruppe H");
            Console.WriteLine("\n\t\tWählen sie die Eingabeparameter:");
            Console.WriteLine("\n\t\t1 - Modul und Teilkreisdurchmesser");
            Console.WriteLine("\n\t\t2 - Modul und Zähnezahl");
            Console.WriteLine("\n\t\t3 - Zähnezahl und Teilkreisdurchmesser");
            Console.WriteLine("\n\t\t4 - Abbrechen");
            Console.WriteLine("\n\t\tBestätigen sie ihre Eingabe mit Enter");
            do
            {

                Int32.TryParse(Console.ReadLine(), out berechnungsWahl);

                isValid = (berechnungsWahl > 0 && berechnungsWahl < 5);

                if (!isValid) //Fehlermeldung
                {
                    
                    Console.WriteLine("\n\t\t\t\tFehler! Falsche Eingabe!\n\t\t\t\tEingabe Wiederholen!\n");
                }
            }
            while (!isValid); //Wenn Eingabe Falsch: Neustart

            if (berechnungsWahl == 1)
            {
                modul();
                teilkreisdurchmesser();
                z = d / m;

                Winkel();
                Kopfspiel();
                berechnung();
                breite();
                materialAuswahl();
                ausgabe();
            }
            else if (berechnungsWahl == 2)
            {
                modul();
                zaehnezahl();
                d = m * z;

                Winkel();
                Kopfspiel();
                berechnung();
                breite();
                materialAuswahl();
                ausgabe();
            }
            else if (berechnungsWahl == 3)
            {
                teilkreisdurchmesser();
                zaehnezahl();
                m = d / z;

                Winkel();
                Kopfspiel();
                berechnung();
                breite();
                materialAuswahl();
                ausgabe();
            }
            else if (berechnungsWahl == 4)
            {
                return;
            }
            



            //Unterprogramme
            void ausgabe()
            {
                Console.WriteLine("\n\t\tZähnezahl: " + z);
                Console.WriteLine("\t\tTeilkreisdurchmesser: " + d + "mm");
                Console.WriteLine("\t\tModul: " + m);
                Console.WriteLine("\t\tTeilung: " + p);
                Console.WriteLine("\t\tFußkreisdurchmesser: " + df + "mm");
                Console.WriteLine("\t\tZahnhöhe: " + h + "mm");
                Console.WriteLine("\t\tGrundkreisdurchmesser: " + dg + "mm");
                Console.WriteLine("\t\tBreite: " + br + "mm");
                Console.WriteLine("\t\tMaterial: " + material);
            }

            void berechnung()
            {
                //Zahnhöhe
                h = 2 * m + c;
                //Teilung
                p = Math.PI * m;
                //Fußkreisdurchmesser
                df = d - (2 * (m + c));
                //Grundkreisdurchmesser
                alpha = Math.PI / 180 * alpha; // Winkel in Radiant umrechnen
                dg = d * Math.Cos(alpha);
            }
            Console.ReadKey();


            void Kopfspiel()
            {

                string gg; //Eingabe als string deklarieren
                int ggInt = 0;     //späterer Speicherort für die Eingabe als Int

                do
                {
                    Console.WriteLine("\n\t\tWollen sie:");
                    Console.WriteLine("\n\t\t1 - das Kopfspiel selbst bestimmen?");
                    Console.WriteLine("\n\t\t2 - den Normwert 0,167mm verwenden?");

                    Console.WriteLine("\n\t\tBestätigen sie ihre Eingabe mit Enter");

                    gg = Console.ReadLine();    // Eingabe und convert
                    Int32.TryParse(gg, out ggInt);

                    if (ggInt >= 3 || ggInt <= 0) //Fehlermeldung
                    {
                        Console.WriteLine("\n\t\t\tFehler! Falsche Eingabe!\n\t\t\tEingabe Wiederholen!\n");
                    }
                }
                while (ggInt >= 3 || ggInt <= 0); //Wenn Eingabe Falsch: Neustart

                if (ggInt == 1)
                {
                    do
                    {
                        Console.WriteLine("\n\t\t\tBitte geben sie das Kopfspiel in mm ein. Empfohlen ist 0,1 bis 0,3mm");
                        Double.TryParse(Console.ReadLine(), out c);
                        if (c <= 0)
                        {
                            Console.WriteLine("Eingabe Wiederholen!");
                        }

                    } while (c <= 0);
                }
                else 
                {
                     c = 0.167;
                }


            }

             void Winkel()
            {
                string ww; //Eingabe als string deklarieren
                int wwInt = 0;     //späterer Speicherort für die Eingabe als Int

                do
                {
                    Console.WriteLine("\n\t\tWollen sie:");
                    Console.WriteLine("\n\t\t1 - den Zahnflankenwinkel selbst bestimmen?");
                    Console.WriteLine("\n\t\t2 - den Standardwert 20° verwenden?");

                    Console.WriteLine("\n\t\tBestätigen sie ihre Eingabe mit Enter");

                    ww = Console.ReadLine();     // Eingabe und convert
                    Int32.TryParse(ww, out wwInt);

                    if (wwInt >= 3 || wwInt <= 0) //Fehlermeldung
                    {
                        Console.WriteLine("\n\t\tFehler! Falsche Eingabe!\n\t\tEingabe Wiederholen!\n");
                    }
                }
                while (wwInt >= 3 || wwInt <= 0); //Wenn Eingabe Falsch: Neustart

                if (wwInt == 1)
                {
                    do
                    {
                        Console.WriteLine("\n\t\tBitte geben sie den Zahnflanken Winkel in Grad an. Norm ist 20°");
                        Double.TryParse(Console.ReadLine(), out alpha);
                        if (alpha <= 0)
                        {
                            Console.WriteLine("Eingabe Wiederholen!");
                        }

                    } while (alpha <= 0);
                }
                else
                {
                    alpha = 20;
                }
                
                
            }

            //Unterprogramm zur Kontrolle der Moduleingabe
            void modul()
            {
                do
                {
                    Console.WriteLine("\n\t\tBitte geben sie das Modul ein.");
                    Double.TryParse(Console.ReadLine(), out m);
                    if (m <= 0)
                    {
                        Console.WriteLine("Fehler! Falsche Eingabe!\n\t\tEingabe Wiederholen!");
                    }

                } while (m <= 0);
            }

            //Unterprogramm zur Kontrolle der Zähnezahleingabe
            void zaehnezahl()
            {
                do
                {
                    Console.WriteLine("\n\t\tBitte geben sie die Zähnezahl an:");
                    Double.TryParse(Console.ReadLine(), out z);
                    if (z <= 0)
                    {
                        Console.WriteLine("Fehler! Falsche Eingabe!\n\t\tEingabe Wiederholen!");
                    }

                } while (z <= 0);
            }

            //Unterprogramm zur Kontrolle der Teilkreisdurchmessereingabe
            void teilkreisdurchmesser()
            {
                do
                {
                    Console.WriteLine("\n\t\tBitte geben sie den Teilkreisdurchmesser in mm ein.");
                    Double.TryParse(Console.ReadLine(), out d);
                    if (d <= 0)
                    {
                        Console.WriteLine("Eingabe Wiederholen!");
                    }

                } while (d <= 0);
            }
            
            void materialAuswahl()
            {
                //Eingabe Material
                Console.WriteLine("\n\t\tBitte geben Sie das Material ein:");
                material = Console.ReadLine();
            }

            void breite()
            {
                // Eingabe der Breite des Zahnrades
                Console.WriteLine("\n\t\tGeben Sie die Breite des Zahnrades an:");
                br = Convert.ToDouble(Console.ReadLine());
            }
        }

        
    }
}