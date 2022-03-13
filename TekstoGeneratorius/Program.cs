using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekstoGeneratorius
{
    internal class Program
    {
        static List<string> SkaiciuNaikinimas = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Iklijuokite transkribuota teksta I PradinisTekstas faila ir spauskite Enter");
            Console.ReadLine();
            Console.WriteLine("Pasiruosus generuoti parasykite slaptazodi 2");
            var slaptazodis = Convert.ToInt32(Console.ReadLine());
            while (slaptazodis != 2)
            {
                Console.WriteLine("ISMOK SKAITYTI, LOPETA TU");
                Console.WriteLine("Pasiruosus generuoti parasykite slaptazodi 2");
                slaptazodis = Convert.ToInt32(Console.ReadLine());
            }   
                if (slaptazodis == 2)
                {
                    Console.WriteLine("NA BENT SLAPTAZODI ZINAI");
                    string path = @"C:\Users\Namai\OneDrive\Desktop\C#\TekstoGeneratorius\PradinisTekstas.txt";
                    string Rezultatas = @"C:\Users\Namai\OneDrive\Desktop\C#\TekstoGeneratorius\Rezultatas.txt";
                    PerskaitomeFaila(path);
                    NuskaitytiDuomenis(Rezultatas);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("oi paperdziau; ISMOK SKAITYTI LOPETA, TU");
                }
            
            Console.ReadLine();
        }
            static void PerskaitomeFaila(string path)
            {
                string duomenys;
                try
                {
                    using (StreamReader fr = File.OpenText(path))
                    {
                    if ((duomenys = fr.ReadLine()) == null)
                    {
                        Console.WriteLine("Pirmiau iklijuok teksta, tada gal ir dirbsiu, o dabar pasol nx salava");
                    }
                        else
                        {
                            while ((duomenys = fr.ReadLine()) != null)
                            {
                                if (!duomenys.Contains(":") && !duomenys.Contains("[Music]"))
                                {
                                    SkaiciuNaikinimas.Add(duomenys);
                                    Console.WriteLine("... \n kaip sunkiai dirbame...");
                                }
                            }
                            if (duomenys == null)
                            {
                                Console.WriteLine("METAS PAILSETI\nPatikrinkite Rezultatai faila!");
                            }
                        }
                     }    
                     
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ivyko klaida{e.Message}");
                }
            }
    
                static void NuskaitytiDuomenis(string Rezultatas)
                {
        
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(Rezultatas))
                        {
                                foreach (var s in SkaiciuNaikinimas)
                                {                                 
                                   sw.Write($" {s}");
                                }
                            
                                sw.Close();
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ivyko klaida{e.Message}");
                    }
                }

     } 
}
