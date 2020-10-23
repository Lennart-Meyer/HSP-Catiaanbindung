﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Double alpha;   //Nachnorm 20 
            Double dg;      //dg = Grundkreisdurchmesser

            alpha = 20; //Zum testen
            c = 0.167; //vorgabe

            int Eingabe = 0; //Eingabe als Int deklarieren

            do
            {
                Console.WriteLine("\n\t\t\tZahnradberechnungsprogramm von Gruppe H");
                Console.WriteLine("\n\t\tWollen sie die Modul und Teilkreisdurchmesser vorgeben press 1");
                Console.WriteLine("\n\t\tWollen sie die Modul und Zähnezahl vorgeben press 2");
                Console.WriteLine("\n\t\tWollen sie die Zähnezahl und Teilkreisdurchmesser vorgeben press 3");
                Console.WriteLine("\n\t\t\tund bestätigen sie ihre Eingabe mit Enter");

                Eingabe = Convert.ToInt32(Console.ReadLine());    // Eingabe und convert

                if (Eingabe >= 4 || Eingabe <= 0) //Fehlermeldung
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t\tFehler! Falsche Eingabe!\n\t\t\t\t Eingabe Wiederholen!\n");

                }


            }

            while (Eingabe >= 4 || Eingabe <= 0); //Wenn Eingabe Falsch: Neustart


            if (Eingabe == 1)
            {
                Console.WriteLine("\n\t\t\tBitte geben sie das Modul ein.");
                m = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\n\t\t\tBitte geben sie den Teilkreisdurchmesser in mm an");
                d = Convert.ToDouble(Console.ReadLine());
                z = d / m;

                berechnung();
                ausgabe();

            }
            else if (Eingabe == 2)
            {
                Console.WriteLine("\n\t\t\tBitte geben sie das Modul ein.");
                m = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\n\t\t\tBitte geben sie die Zähnezahl an:");
                z = Convert.ToDouble(Console.ReadLine());
                d = m * z;

                berechnung();
                ausgabe();

            }
            else if (Eingabe == 3)
            {
                Console.WriteLine("\n\t\t\tBitte geben sie das Teilkreisdurchmesser in mm ein.");
                d = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\n\t\t\tBitte geben sie die Zähnezahl an:");
                z = Convert.ToDouble(Console.ReadLine());
                m = d / z;

                berechnung();
                ausgabe();

            }

            //Unterprogramme
            void ausgabe()
            {
                Console.WriteLine("\n\t\t\t"+Eingabe);
                Console.WriteLine("\t\t\tZähnezahl: " + z);
                Console.WriteLine("\t\t\tTeilkreisdurchmesser: " + d);
                Console.WriteLine("\t\t\tModul: " + m);
                Console.WriteLine("\t\t\tTeilung: " + p);
                Console.WriteLine("\t\t\tFußkreisdurchmesser: " + df);
                Console.WriteLine("\t\t\tZahnhöhe: " + h);
                Console.WriteLine("\t\t\tGrundkreisdurchmesser: " + dg);
            }

            void berechnung()
            {
                //Zahnhöhe
                h = 2 * m + c;
                //Teilung
                //Pi genauer eingeben?
                p = Math.PI * m;
                //Fußkreisdurchmesser
                df = d - (2 * (m + c));
                //Grundkreisdurchmesser
                alpha = Math.PI / 180 * alpha;
                dg = d * Math.Cos(alpha);
            }
            Console.ReadKey();
        }

    }
}

