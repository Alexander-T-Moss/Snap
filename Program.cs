namespace Snap;

class Program
{
    // Simple subroutine to only show a message temporarily in the console
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

    // Subroutine that checks if there is a possible SNAP
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
        // ---------------------- INITIALIZATION ---------------------- //

        // Create independant variables for future use
        Random randInt = new();
        bool playing = true;

        // Create two test players
        List<Player> Players = new() { new("EnterPlayer", 0), new("TabPlayer", 1) };

        // Create deck and shuffle it
        Deck playingDeck = new();
        playingDeck.Shuffle();

        Table game = new(playingDeck, Players);

        // Deal cards out evenly to all players
        game.DealCards();
        QuickMessage("Cards Dealt And Game Ready To Commence");

        // ---------------------- GAME-LOOP ---------------------- //

        while (playing)
        {
            ConsoleKey input = Console.ReadKey().Key;
            Console.Clear();

            if (input == ConsoleKey.Spacebar)
            {
                game.NextMove();
            }

            else if(input == ConsoleKey.Enter)
            {
                if (game.SnapPresent())
                {
                    QuickMessage("EnterPlayer correctly identified the snap");
                    game.CollectCards(0);
                    game.NextMove();
                }
                else
                {
                    QuickMessage("There's no snap here silly, you should've gone to specsavers");
                    game.NextMove();
                }
            }

            else if (input == ConsoleKey.Tab)
            {
                if (game.SnapPresent())
                {
                    QuickMessage("TabPlayer correctly identified the snap");
                    game.CollectCards(1);
                    game.NextMove();
                }
                else
                {
                    QuickMessage("There's no snap here silly, you should've gone to specsavers");
                    game.NextMove();
                }
            }

            else if(input == ConsoleKey.Escape)
            {
                QuickMessage("Game ended, thanks for playing...");
                playing = false;
                break;
            }

            game.DisplayTable();
        }
        
    }
}