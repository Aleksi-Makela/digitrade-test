using System;

namespace ReadWriteExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReadWriteExample");
            Console.Write("Hei. Ole yhvä ja kirjoita nimesi: ");
            string  userInput = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Moi {userInput}!");

        }
    }
}
