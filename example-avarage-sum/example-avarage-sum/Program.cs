using System;

namespace example_avarage_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int summa = 0;
            int i = 1;
            Console.Write("Ohjelma lastee keskiarvon syöttämien lukujesi perusteella. " +
                "Kuinka monta lukua syötät? ");
            int lkm = int.Parse(Console.ReadLine());
            while (i <= lkm)
            {
                int x = int.Parse(Console.ReadLine());
                summa = summa + x;
                i = i + 1;
            }

            if (lkm > 0)
            {
                double ka = summa / lkm;
                Console.WriteLine("Lukujen keskiarvo on: " +ka);
            }
            else
            {
                Console.WriteLine("Lukuja ei ole syötetty!");
            }

            

        }
    }
}
