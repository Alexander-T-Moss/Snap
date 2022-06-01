namespace Snap;

public class Table
{
    private List<Player> Players;
    private Deck Deck;
    private int CurrentPlayer = 0;

    public Table(Deck deck, List<Player> players)
    {
        Deck = deck;
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

    public void NextMove()
    {
        CurrentPlayer++;

        if(CurrentPlayer >= Players.Count())
        {
            CurrentPlayer = 0;
        }

        Players[CurrentPlayer].DrawCard();
    }

    public void DisplayTable()
    {
        foreach (Player player in Players)
        {
            if (!player.ShownDeckEmpty())
            {
                Console.WriteLine(player.GetName() + "'s top card number is: " + player.GetTopShownCard().GetNumber());
            }
            else
            {
                Console.WriteLine(player.GetName() + "'s has no cards in their shown deck yet");
            }
            Console.WriteLine("They have " + player.GetHiddenDeckSize() + " cards left to reveal\n");
        }
    }
    
    public bool SnapPresent()
    {
        List<int> topCardNumbers = new();

        foreach (Player player in Players)
        {
            topCardNumbers.Add(player.GetTopShownCard().GetNumber());
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
    
}