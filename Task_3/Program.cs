using System;
using System.Text;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || (args.Length % 2 == 0) || args.Length < 3)
            {
                Console.WriteLine("\nWrong input! (Arguments count must be an odd number and not null one)");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 1; j < args.Length; j++)
                {
                    if (args[j].Equals(args[j - 1]))
                    {
                        Console.WriteLine("Each arhument must be unique");
                        return;
                    }
                }
            }

            string condition = null;
            Random rnd = new Random();

            while (true)
            {
                byte[] key = CryptoKeyGenerator.GenSalt(64);

                int aiMove = rnd.Next(0, args.Length);
                byte[] aiMoveInBytes = Encoding.ASCII.GetBytes(args[aiMove]);

                byte[] hmac = CryptoKeyGenerator.ComputeHmacsha1(aiMoveInBytes, key);

                ShowAppMenu(args, hmac);
                Console.Write("Enter your move: ");
                condition = Console.ReadLine();

                if (condition.Equals("0"))
                {
                    Console.WriteLine("Your move: exit");
                    break;
                }

                if (condition.Equals("?"))
                {
                    Console.WriteLine("Your move: help");
                    TableFormer.FormTable(args);
                    continue;
                }

                if (int.TryParse(condition, out int elementNumber))
                {
                    if (elementNumber < 1 || elementNumber > args.Length)
                    {
                        Console.WriteLine("Wrong input! Please input a point from menu ");
                        continue;
                    }

                    Console.Write($"Your move: {args[elementNumber - 1]}");
                    Console.Write($"\nAI move: {args[aiMove]}");
                    string moveResult = WinnerDeterminator.DetermineWinner(elementNumber - 1, aiMove, args.Length);
                    Console.WriteLine($"\nYour result: {moveResult}!");
                    Console.WriteLine($"HMAC key: {Convert.ToBase64String(key)}");
                }
                else
                {
                    Console.WriteLine("Input is wrong! Please input a point from menu!");
                    continue;
                }
            }

            Console.ReadKey();
        }

        private static void ShowAppMenu(string[] args, byte[] hmacKey)
        {
            Console.WriteLine($"\nHMAC: {GetStringHMAC(hmacKey)}");
            Console.WriteLine("Available moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {args[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        private static string GetStringHMAC(byte[] buffer)
        {
            var finalHex = new StringBuilder(buffer.Length * 2);
            foreach (var b in buffer)
            {
                finalHex.AppendFormat("{0:x2}", b);
            }
            return finalHex.ToString();
        }
    }
}