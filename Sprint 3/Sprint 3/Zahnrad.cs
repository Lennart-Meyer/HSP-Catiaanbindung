using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_3
{
    public class Zahnrad
    {
        public double z;                                    //Zähnezahl
        public double m;                                    //Modul
        public double d;                                    //Teilkreisdurchmesser
        public double c = 0.167;                            //Kopfspiel
        public double a = 20;                               //Zahnflankenwinkel
        public double b;                                    //Breite
        public double h;                                    //Zahnhöhe
        public double p;                                    //Teilung
        public double df;                                   //Fußkreisdurchmesser
        public double dg;                                   //Grundkreisdurchmesser
        public double ha;                                   //Zahnkopfhöhe
        public double hf;                                   //Zahnfußhöhe
        public double alpha;                                // a in Rad
        public double beta;                                 // Schrägungswinkel
        public double mt;                                   //Stirnmodul
        public double pt;                                   //Stirnteilung
        public double gamma;                                // beta in Rad
        public double o;                                    //Teilkegelwinkel
        public double y;                                    //Kopfkegelwinkel
        public double da;                                   //Kopfkreisdurchmesser
        public double bd = 2;                                   //Bohrungsdurchmesser
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
    }
}
