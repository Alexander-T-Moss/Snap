namespace Snap;

class Program
{
    public static void QuickMessage(string message, bool startWithClear = true, int messageDuration = 1000)
    {
        if (startWithClear)
        {
            Console.Clear();
        }
        Console.WriteLine(message);
        Thread.Sleep(messageDuration);
        Console.Clear();
    }

    public static bool SnapPresent(List<int?> numbersOnCurrentTopCards)
    {
        if (numbersOnCurrentTopCards.Count != numbersOnCurrentTopCards.Distinct().Count())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Main()
    {
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine("");
        Console.WriteLine("WELCOME TO SUPER SNAP");
        Console.WriteLine("");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine("");
        Console.WriteLine("Gameplay:");
        Console.WriteLine("");
        Console.WriteLine("Keep drawing cards until the cards at the top of");
        Console.WriteLine("each players pile is the same, then first person");
        Console.WriteLine("to call snap ( when the top cards are the same");
        Console.WriteLine("number ) wins all the cards that have been drawn");
        Console.WriteLine("that round, winner is the one who is left with");
        Console.WriteLine("all the cards at the end...");
        Console.WriteLine("");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine("");
        Console.WriteLine("Controls:");
        Console.WriteLine("");
        Console.WriteLine("Spacebar - Next player draws card");
        Console.WriteLine("Enter - Player ONE calls snap!");
        Console.WriteLine("Tab - Player TWO calls snap!");
        Console.WriteLine("Escape - End game");
        Console.WriteLine("");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine("");
        Console.WriteLine("Press enter to start the game...");

        ConsoleKey waitToStart = ConsoleKey.Spacebar;

        while(waitToStart != ConsoleKey.Enter)
        {
            waitToStart = Console.ReadKey().Key;
        }

        Random randInt = new();
        bool playing = true;

        List<Player> Players = new() { new("Player ONE"), new("Player TWO") };

        Deck playingDeck = new();
        playingDeck.Shuffle();

        Table game = new(playingDeck, Players);

        game.DealCards();

        while (playing)
        {
            game.DisplayTable();
            ConsoleKey input = Console.ReadKey().Key;
            

            if (input == ConsoleKey.Spacebar)
            {
                game.NextMove();
            }

            else if(input == ConsoleKey.Enter)
            {
                if (game.SnapPresent())
                {
                    QuickMessage("\n" + game.PlayerName(0) + " correctly identified the snap", false);
                    game.CollectCards(0);
                }
                else
                {
                    QuickMessage("\n" + game.PlayerName(0) + ", there's no snap here silly, you should've gone to specsavers", false);
                }
            }

            else if (input == ConsoleKey.Tab)
            {
                if (game.SnapPresent())
                {
                    QuickMessage("\n" + game.PlayerName(1) + " correctly identified the snap", false);
                    game.CollectCards(1);
                }
                else
                {
                    QuickMessage("\n" + game.PlayerName(1) + ", there's no snap here silly, you should've gone to specsavers", false);
                }
            }

            else if(input == ConsoleKey.Escape)
            {
                Console.WriteLine("Game ended, thanks for playing...");
                playing = false;
                break;
            }

            
            if(game.IfPlayerOut())
            {
                playing = false;
                Console.WriteLine("Game Over");
                Console.WriteLine("Your winner is: " + game.Winner().GetName());

            }
            Console.Clear();
        }
        
    }
}