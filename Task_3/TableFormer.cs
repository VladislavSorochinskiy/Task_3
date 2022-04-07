using System;

namespace Task3
{
    internal static class TableFormer
    {
        internal static void FormTable(string[] args)
        {
            for (int i = 0; i < args.Length + 1; i++)
            {
                if (i == 0) Console.Write("{0,10}", "");

                if (i != 0) Console.Write("\n{0, 10}", args[i - 1]);

                for (int j = 0; j < args.Length; j++)
                {
                    if (i == 0) Console.Write("{0, 10}", args[j]);
                    else
                    {
                        Console.Write("{0, 10}", WinnerDeterminator.DetermineWinner(i - 1, j, args.Length));
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
