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
            Double df ; //df=Frußkreisdurchmesser
            Double z  ;  //z=Zähnezahl
            Double h  ;  //h=Zahnhöhe
            Double ha ; //ha=Zahnkopfhöhe
            Double hf ; //hf=Zahnfußhöhe
            Double c  ;  //c=Kopfspiel
            Double a  ;  //a=Achsenabstand

            Console.WriteLine("Wollen sie die Modul und Teilkreisdurchmesser vorgeben press 1");
            Console.WriteLine("Wollen sie die Msduodul und Zähnezahl vorgeben press 2");
            Console.WriteLine("Wollen sie die Zähnezahl und Teilkreisdurchmesser vorgeben press 3");
            Console.WriteLine("und bestätigen sie ihre Eingabe mit Enter");

            int ii= Convert.ToInt32(Console.ReadLine());
           
            if (ii == 1)
            {
                Console.WriteLine("Bitte geben sie das Modul ein.");
                m = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Bitte geben sie den Teilkreisdurchmesser in mm an");
                d = Convert.ToDouble(Console.ReadLine());


            }
            else if(ii == 2)
            {

            }
            else if (ii == 3)
            {

            }
            else
            {
                Console.WriteLine("Falsche Eingabe");
            }

            Console.WriteLine(ii);
            Console.ReadKey();

          
        }
    }
}
