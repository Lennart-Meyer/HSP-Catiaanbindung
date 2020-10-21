using System;
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
            Double m  ;  //m=Modul
            Double p  ;  //p=Teilung
            Double d  ;  //d=Teilkreisdurchmesser
            Double da ; //da=Kopfkreisdurchmesser
            Double df ; //df=Fußkreisdurchmesser
            Double z  ;  //z=Zähnezahl
            Double h  ;  //h=Zahnhöhe
            Double ha ; //ha=Zahnkopfhöhe
            Double hf ; //hf=Zahnfußhöhe
            Double c  ;  //c=Kopfspiel
            Double a  ;  //a=Achsenabstand
            Double alpha;//Nachnorm 20 
            Double dg;   //dg=Grundkreisdurchmesser

            alpha = 20; //Zum testen
            c = 0.167; //vorgabe

            Console.WriteLine("Wollen sie die Modul und Teilkreisdurchmesser vorgeben press 1");
            Console.WriteLine("Wollen sie die Modul und Zähnezahl vorgeben press 2");
            Console.WriteLine("Wollen sie die Zähnezahl und Teilkreisdurchmesser vorgeben press 3");
            Console.WriteLine("und bestätigen sie ihre Eingabe mit Enter");

            int ii= Convert.ToInt32(Console.ReadLine());
           
            if (ii == 1)
            {
                Console.WriteLine("Bitte geben sie das Modul ein.");
                m = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Bitte geben sie den Teilkreisdurchmesser in mm an");
                d = Convert.ToDouble(Console.ReadLine());
                z = d / m;
                //Zahnhöhe
                h = 2 * m + c;
                p = Math.PI * m;
                //Fußkreisdurchmesser
                df = d - (2 * (m + c));
                //Grundkreisdurchmesser
                alpha = Math.PI / 180 * alpha;
                dg = d * Math.Cos(alpha);
                //Kontrolle
                Console.WriteLine(ii);
                Console.WriteLine(z);
                Console.WriteLine(d);
                Console.WriteLine(m);
                Console.WriteLine(p);
                Console.WriteLine(df);
                Console.WriteLine(h);
                Console.WriteLine(dg);
            }
            else if (ii == 2)
            {
                Console.WriteLine("Bitte geben sie das Modul ein.");
                m = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Bitte geben sie die Zähnezahl an:");
                z = Convert.ToDouble(Console.ReadLine());
                d = m * z;
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
                //Kontrolle
                Console.WriteLine(ii);
                Console.WriteLine(z);
                Console.WriteLine(d);
                Console.WriteLine(m);
                Console.WriteLine(p);
                Console.WriteLine(df);
                Console.WriteLine(h);
                Console.WriteLine(dg);
            }
            else if (ii == 3)
            {
                Console.WriteLine("Bitte geben sie das Teilkreisdurchmesser in mm ein.");
                d = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Bitte geben sie die Zähnezahl an:");
                z = Convert.ToDouble(Console.ReadLine());
                m = d / z;
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
                //Kontrolle
                Console.WriteLine(ii);
                Console.WriteLine(z);
                Console.WriteLine(d);
                Console.WriteLine(m);
                Console.WriteLine(p);
                Console.WriteLine(df);
                Console.WriteLine(h);
                Console.WriteLine(dg);
            }
            else
            {
                Console.WriteLine("Falsche Eingabe");
            }

            //Teilung
              //Pi genauer eingeben?

            
            

            
            

            
            


            
            

            Console.ReadKey();


        }
    }
}
