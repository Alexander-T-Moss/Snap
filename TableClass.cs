namespace Snap;

public class Table
{
    private List<Player> Players;
    private Deck Deck;
    private int StartingDeckSize;
    private int CurrentPlayer = 0;

    public Table(Deck deck, List<Player> players)
    {
        Deck = deck;
        StartingDeckSize = deck.Size();
        Players = players;
    }

    public void DealCards()
    {
        while (!Deck.Empty())
        {
            foreach (Player player in Players)
            {
                if (!Deck.Empty())
                {
                    player.AddToHiddenDeck(Deck.GetTopCard());
                    Deck.RemoveTopCard();
                }
            }
        }
    }

    public string PlayerName(int playerID)
    {
        return Players[playerID].GetName();
    }

    public void NextMove()
    {

        if (CurrentPlayer >= Players.Count())
        {
            CurrentPlayer = 0;
        }

        Players[CurrentPlayer].DrawCard();

        CurrentPlayer++;
    }

    
    
    public bool SnapPresent()
    {
        List<int> topCardNumbers = new();

        foreach (Player player in Players)
        {
            if(player.GetTopShownCard() != null)
            {
                topCardNumbers.Add(player.GetTopShownCard().GetNumber());
            }
            else
            {
                return false;
            }
        }

        if (topCardNumbers.Count != topCardNumbers.Distinct().Count())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CollectCards(int playerID)
    {
        foreach(Player player in Players)
        {
            Players[playerID].CollectDeck(player.PassOverShownDeck());
        }
    }

    public bool IfPlayerOut()
    {
        foreach(Player player in Players)
        {
            if(player.GetHiddenDeckSize() == 0 && player.GetShownDeckSize() == 0)
            {
                return true;
            }
        }
        return false;
    }

    public Player? Winner()
    {
        foreach(Player player in Players)
        {
            if(player.GetHiddenDeckSize() == StartingDeckSize)
            {
                return player;
            }
        }
        return null;
    }


    public void DisplayTable()
    {
        Console.Clear();
        foreach (Player player in Players)
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine();
            Console.WriteLine(player.GetName());
            Console.WriteLine();

            if (!player.ShownDeckEmpty())
            {
                Console.WriteLine("Last Drawn Card: " + player.GetTopShownCard().GetNumber() + " of " + player.GetTopShownCard().GetSuit());
            }
            else
            {
                Console.WriteLine("Yet to draw a card this round");
            }
            Console.WriteLine("\nThey have " + player.CardsCount() + " cards in total,\nand " + player.GetHiddenDeckSize() + " in their hidden pile\n");
        }
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

        if(CurrentPlayer >= Players.Count())
        {
            Console.WriteLine("\nPress spacebar to make " + Players[0].GetName() + " draw a card");
        }
        else
        {
            Console.WriteLine("\nPress spacebar to make " + Players[CurrentPlayer].GetName() + " draw a card");
        }
        
    }

}