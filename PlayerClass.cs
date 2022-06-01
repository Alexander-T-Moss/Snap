namespace Snap;

public class Player
{
	public Deck PlayersHiddenDeck;
	public Deck PlayersShownDeck;
	public string Name;
	private int PlayerID;

	public Player(string name, int playerID)
	{
		Name = name;
		playerID = playerID;
		PlayersHiddenDeck = new(true);
		PlayersShownDeck = new(true);
	}

	public string GetName()
    {
		return Name;
    }

	public int GetPlayerID()
    {
		return PlayerID;
    }

	public bool ShownDeckEmpty()
    {
		if(PlayersShownDeck.Empty())
        {
			return true;
        }
		else
        {
			return false;
        }
    }

	public bool HiddenDeckEmpty()
	{
		if (PlayersHiddenDeck.Empty())
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public Deck PassOverShownDeck()
    {
		Deck tempDeck = PlayersShownDeck;
		PlayersShownDeck = new(true);
		return tempDeck;
    }

	public void CollectDeck(Deck deck)
    {
		PlayersHiddenDeck.Merge(deck);
    }

	public int GetHiddenDeckSize()
    {
		return PlayersHiddenDeck.Size();
    }
	// Returns and removes top card from PlayersHiddenDeck //
	public void DrawCard() 
    {
        PlayersShownDeck.AddToTop(PlayersHiddenDeck.GetTopCard());
        PlayersHiddenDeck.RemoveTopCard();
    }

	// Adds card to top of hidden deck
	public void AddToHiddenDeck(Card card)
    {
		PlayersHiddenDeck.AddToTop(card);
    }

	// Returns "top" card from this.PlayersHiddenDeck unless it's empty and returns null
	public Card? GetTopHiddenCard()
    {
		if (!PlayersHiddenDeck.Empty())
		{
			return PlayersHiddenDeck.GetTopCard();
		}
		return null;
    }

	// Returns "top" card from this.PlayersShownDeck unless it's empty and returns null
	public Card? GetTopShownCard()
	{
		if (!PlayersShownDeck.Empty())
		{
			return PlayersShownDeck.GetTopCard();
		}
		return null;
	}
}