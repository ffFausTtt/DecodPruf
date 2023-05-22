using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Resh a = new Resh();
            a.Vvod();
            a.Reshenie();
        }
    }

    internal class Resh
    {
        int[] ms1 = { };

        public void Vvod()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Pruf.csv"))
                {
                    while (sr.EndOfStream != true)
                    {
                        string
                        str1 = sr
                        .ReadLine(); // считываем в 2 строчки т.к. в условии всего 2 строчки и это самый оптимальный вариант
                        ms1 = Array.ConvertAll(str1.Split(';'), int.Parse); // парсим в массив
                        for (int i = 0; i < ms1.Length; i++)
                        {
                            Debug.WriteLine(ms1[i]);
                        }

                        Console.WriteLine(str1);
                    }
                }
            }
            catch
            {
                Debug.WriteLine("Не верно заданы входные значения");
                Environment.Exit(0);
            }
        }

        public bool Vivod(List<int> r, List<int> r2)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Pruf2.csv", false, Encoding.Default, 10))
                {
                    foreach (var t in r)
                    {
                        sw.Write(t + ";");
                        Debug.Write(t + ";");
                    }
                    sw.WriteLine();
                    foreach (var t2 in r2)
                    {
                        sw.Write(t2 + ";");
                        Debug.Write(t2 + ";");
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Запись прервана: " + e.Message);
                return false;
            }
        }

        public void Reshenie()
        {
            int[] ms2 = new int[ms1.Length + 2];
            for (int i = 0; i < ms2.Length; i++)
            {
                ms2[i] = i + 1;
            }

            var result1 = new List<int>();
            var result2 = new List<int>();

            bool f = true;
            int r = 0;
            while (result2.Count < 8)
            {
                result1.Add(ms1[r]);
                List<int> rr = new List<int>();
                List<int> rrr = new List<int>();
                for (var j = 0; j < ms2.Length; j++)
                {
                    for (var i = 0; i < ms1.Length; i++)
                    {
                        if (ms1[i] == ms2[j])
                        {
                            f = false;
                        }
                    }

                    if (f == true && ms2[j] != 0)
                    {
                        rrr.Add(j);
                        rr.Add(ms2[j]);
                    }
                    f = true;
                }

                try
                {
                    int minimumIndexInrr = rr.IndexOf(rr.Min());
                    int o = rrr[minimumIndexInrr];
                    result2.Add(ms2[o]);
                    if (r < ms1.Length)
                    {
                        ms1[r] = 0;
                        r++;
                    }
                    ms2[o] = 0;
                }
                catch (Exception e)
                {
                }
            }
            result1.Add(ms2.FirstOrDefault(x => x != 0));
            result2.Add(ms2.LastOrDefault(x => x != 0));
            Console.WriteLine("Ответ");
            Vivod(result1, result2);
            foreach (var t in result1)
            {
                Console.Write(t);
            }

            Console.WriteLine();
            foreach (var t2 in result2)
            {
                Console.Write(t2);
            }
        }
    }
}