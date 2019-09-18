using System;

namespace factorial_example
{
    class Program
    {
        static void Main(string[] args)
        {
            int userNumber = 0;
            int fact = 1;

            Console.WriteLine("Kertoman laskenta");
            Console.Write("Syötä luku, jonka kertoma lasketaan: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber < 0)
            {
                Console.WriteLine("Virheellinen syöte.");
            }
            else
            {
                while(userNumber > 0)
                {
                    fact = fact * userNumber;
                    userNumber = userNumber - 1;
                }
                Console.WriteLine("Vastaus:" + fact);
            }




        }
    }
}
