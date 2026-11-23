namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Här skapas slumpgeneratorn.
            Random random = new Random();

            // Här sparas svaret på om användaren vill spela igen.
            string playAgain;

            do
            {
                Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");
                Console.WriteLine();

                // Svårighetsnivån kan ändra antalet försök.
                Console.WriteLine("Välj svårighetsnivå:");
                Console.WriteLine("1. Lätt: 1-10, sex försök");
                Console.WriteLine("2. Mellan: 1-25, fem försök");
                Console.WriteLine("3. Svår: 1-50, tre försök");
                Console.WriteLine("Ange 1, 2 eller 3");

                string difficulty = Console.ReadLine() ?? "";

                // Användaren får välja igen om svaret inte är 1, 2 eller 3.
                while (difficulty != "1" && difficulty != "2" && difficulty != "3")
                {
                    Console.WriteLine("Ange 1, 2 eller 3");
                    difficulty = Console.ReadLine() ?? "";
                }

                int maxNumber = 0;
                int attempts = 0;

                // Nivån bestämmer högsta talet och antalet försök.
                switch (difficulty)
                {
                    case "1":
                        maxNumber = 10;
                        attempts = 6;
                        break;

                    case "2":
                        maxNumber = 25;
                        attempts = 5;
                        break;

                    case "3":
                        maxNumber = 50;
                        attempts = 3;
                        break;
                }

                int number = random.Next(1, maxNumber + 1);

                Console.WriteLine($"Jag tänker på ett tal mellan 1 och {maxNumber}. Du får {attempts} försök.");

                // Här räknas försöken.
                for (int guess = 1; guess <= attempts; guess = guess + 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Försök {guess} av {attempts}. Ange din gissning:");

                    int userInput = 0;

                    // Frågar igen tills svaret är ett heltal inom intervallet.
                    while (userInput < 1 || userInput > maxNumber)
                    {
                        if (!int.TryParse(Console.ReadLine(), out userInput))
                        {
                            Console.WriteLine("Du måste skriva ett heltal.");
                        }
                        else if (userInput < 1 || userInput > maxNumber)
                        {
                            Console.WriteLine($"Skriv ett tal mellan 1 och {maxNumber}.");
                        }
                    }

                    // Här anropas min egen metod som ger svar på gissningen.
                    GuessChecker.CheckGuess(userInput, number, random, maxNumber);

                    // Rätt gissning avslutar försöksloopen.
                    if (userInput == number)
                    {
                        break;
                    }

                    if (guess == attempts)
                    {
                        Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på {attempts} försök!");
                    }
                }

                // Frågan kommer först när spelomgången är slut.
                Console.WriteLine();
                Console.WriteLine("Vill du spela igen? Skriv \"Ja\" eller \"Nej\".");

                playAgain = (Console.ReadLine() ?? "nej").ToLower();

                while (playAgain != "ja" && playAgain != "nej")
                {
                    Console.WriteLine("Skriv \"Ja\" eller \"Nej\".");
                    playAgain = (Console.ReadLine() ?? "nej").ToLower();
                }

                Console.WriteLine();
            }
            // Spelet börjar om ifall svaret är ja.
            while (playAgain == "ja");

            Console.WriteLine("Tack för att du spelade!");
        }


    }
}