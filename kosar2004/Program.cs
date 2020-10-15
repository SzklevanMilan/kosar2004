using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace kosar2004
{
    class Program
    {
        static List<Meccs> meccsek = new List<Meccs>();
        static Dictionary<string, int> stadion = new Dictionary<string, int>();
        static void MasodikFeladat()
        {
            StreamReader sr = new StreamReader("eredmenyek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                meccsek.Add(new Meccs(sr.ReadLine()));
            }
            sr.Close();
        }

        static void HarmadikFeladat()
        {
            int haz = 0;
            int idegen = 0;
            foreach (var m in meccsek)
            {
                if (m.Hazai == "Real Madrid")
                {
                    haz++;
                }
                if (m.Idegen == "Real Madrid")
                {
                    idegen++;
                }
            }
            Console.Write("3.feladat:Real Madrid: Hazai: {0}, Idegen: {1}", haz,idegen);

        }

        static void NegyedikFeladat()
        {
            bool dont = false;
            foreach (var m in meccsek)
            {
                if (m.HPont == m.IPont)
                {
                    dont = true;
                }
                else
                {
                    dont = false;
                }
            }
            if (dont == true)
            {
                Console.Write("\n4.feladat:Volt döntetlen? Igen");
            }
            else
            {
                Console.Write("\n4.feladat:Volt döntetlen? Nem");
            }
        }

        static void OtodikFeladat()
        {
            string nev = "";
            foreach (var m in meccsek)
            {
                if (m.Hazai.Contains("Barcelona"))
                {
                    nev = m.Hazai;
                }
            }
            Console.WriteLine("\n5.feladat:barcelonai csapat neve: {0}",nev);
        }

        static void HatodikFeladat()
        {
            var datum = from m in meccsek
                        where m.Ido == "2004-11-21"
                        select m;
            foreach (var d in datum)
            {
                Console.WriteLine($"{d.Hazai} - {d.Idegen} ({d.HPont}:{d.IPont})");
            }
        }

        static void HetedikFeladat()
        {
            foreach (var m in meccsek)
            {
                if (!stadion.ContainsKey(m.Hely))
                {
                    stadion.Add(m.Hely,0);
                }
            }
            foreach (var i in meccsek)
            {
                stadion[i.Hely]++;
            }
            foreach (var i in stadion)
            {
                if (i.Value > 20)
                {
                    Console.WriteLine($"\t{i.Key}: {i.Value}");
                }
            }
        }

        static void Nyolcadik()
        {
            StreamWriter sw = new StreamWriter("eredmenyek.txt");
            foreach (var m in meccsek)
            {
                sw.WriteLine(m.Atalakit());
            }
            sw.Close();
        }
 


        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            Console.WriteLine("6.feladat:");
            HatodikFeladat();
            Console.WriteLine("7.feladat:");
            HetedikFeladat();
            Console.WriteLine("8.feladat.");
            Nyolcadik();
            Console.ReadLine();
        }
    }
}
