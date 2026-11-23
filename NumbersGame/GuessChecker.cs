using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersGame
{
    internal class GuessChecker
    {

        // Metoden kontrollerar gissningen och ger en ledtråd.
        public static void CheckGuess(int userInput, int number, Random random, int maxNumber)
        {
            string[] lowAnswers =
            {
                "Tyvärr, du gissade för lågt!",
                "Lite högre behöver du gissa!",
                "Bra försök, men talet är större!",
                "För lågt! Sikta högre!"
            };

            string[] highAnswers =
            {
                "Tyvärr, du gissade för högt!",
                "Lite lägre behöver du gissa!",
                "Bra försök, men talet är mindre!",
                "För högt! Sikta lägre!"
            };

            if (userInput == number)
            {
                Console.WriteLine("Wohoo! Du klarade det!");
            }
            else if (userInput < number)
            {
                // Slumpar en plats och skriver ut texten på den platsen.
                int answer = random.Next(0, lowAnswers.Length);
                Console.WriteLine(lowAnswers[answer]);
            }
            else
            {
                int answer = random.Next(0, highAnswers.Length);
                Console.WriteLine(highAnswers[answer]);
            }

            if (userInput != number)
            {
                // Här räknas avståndet till rätt tal.
                int difference;

                if (userInput > number)
                {
                    difference = userInput - number;
                }
                else
                {
                    difference = number - userInput;
                }

                // Ledtråden beror på hur nära gissningen är.
                if (difference <= 2)
                {
                    Console.WriteLine("Det bränns! Du är väldigt nära!");
                }
                else if (difference >= maxNumber / 2)
                {
                    Console.WriteLine("Oj, det var långt ifrån!");
                }
                else
                {
                    Console.WriteLine("Du är en bit ifrån.");
                }
            }
        }

    }
}
