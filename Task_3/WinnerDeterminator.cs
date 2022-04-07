using System;

namespace Task3
{
    internal static class WinnerDeterminator
    {
        internal static string DetermineWinner(int number1, int number2, int argsNumber)
        {
            int helper = argsNumber / 2;
            int numberDifference = number1 - number2;

            if (numberDifference == 0) return "Draw";

            if (numberDifference < 0)
            {
                if (Math.Abs(numberDifference) <= helper)
                    return "Win";
                else
                    return "Lose";
            }
            else
            {
                if (numberDifference <= helper)
                    return "Lose";
                else
                    return "Win";
            }
        }
    }
}