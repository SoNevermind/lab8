using System;
using System.IO;
using System.Collections.Generic;

namespace Lab8Vol1
{
    //интерфейс для реализации сортировки
    public class C1 : IComparable
    {
        public string names;
        public int ciphers;

        public int CompareTo(object obj)
        {
            C1 c1 = obj as C1;

            if (c1 != null)
            {
                if (ciphers < c1.ciphers)
                {
                    return -1;
                }
                else if (ciphers > c1.ciphers)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = new List<string>(File.ReadAllLines(@"/Users/nevernimdpieceofshit/Projects/Lab8Vol1/names.txt"));
            List<C1> c1s = new List<C1>();

            foreach(var list in str)
            {
                Console.WriteLine("names: " + list);
            }

            Console.WriteLine();

            int cipher()
            {
                Random random = new Random();
                string cip = " ";

                for(int i = 0; i < str.Count; i++)
                {
                    cip += random.Next(0, 100).ToString();
                    Console.WriteLine("ciphers: " + cip);
                }
                return Convert.ToInt32(cip);
            }

            for(int i = 0; i < str.Count; i++)
            {
                c1s.Add(new C1() { names = str[i].Trim(), ciphers = cipher() });
            }

            Console.WriteLine();

            Console.WriteLine("Names and ciphers: ");
            foreach(var list in c1s)
            {
                Console.WriteLine(list.names + " is " + list.ciphers);
            }

            c1s.Sort();
            Console.WriteLine();

            Console.WriteLine("Afeter sorting: ");
            foreach(var list in c1s)
            {
                Console.WriteLine(list.names + " is " + list.ciphers);
            }

            for(int i = 0; i < c1s.Count; i++)
            {
                for(int j = 0; j < c1s.Count; j++)
                {
                    if(j != i)
                    {
                        try
                        {
                            if(c1s[i].names == c1s[j].names)
                            {
                                c1s.RemoveAt(j);
                            }
                        }
                        catch { }
                    }
                }
            }

            Console.WriteLine();

            Console.WriteLine("After deleting: ");
            foreach(var list in c1s)
            {
                Console.WriteLine(list.names + " if " + list.ciphers);
            }

            Console.ReadLine();
        }
    }
}

