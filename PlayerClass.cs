namespace Snap;

public class Player
{
	public Deck HiddenDeck;
	public Deck ShownDeck;
	public string Name;

	public Player(string name)
	{
		Name = name;
		HiddenDeck = new(true);
		ShownDeck = new(true);
	}

	public string GetName()
    {
		return Name;
    }

	public bool ShownDeckEmpty()
    {
		if(ShownDeck.Empty())
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
		if (HiddenDeck.Empty())
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
		Deck tempDeck = ShownDeck;
		ShownDeck = new(true);
		return tempDeck;
    }

	public void CollectDeck(Deck deck)
    {
		HiddenDeck.Merge(deck);
    }

	public int GetHiddenDeckSize()
    {
		return HiddenDeck.Size();
    }

	public int GetShownDeckSize()
	{
		return ShownDeck.Size();
	}

	public int CardsCount()
    {
		return HiddenDeck.Size() + ShownDeck.Size();
    }

	public void DrawCard() 
    {
		if(HiddenDeck.Empty())
        {
			Console.WriteLine(Name + " Hidden Deck Is Empty");
			ShownDeck.Flip();
			HiddenDeck.Merge(ShownDeck);
			ShownDeck = new(true);
        }
		ShownDeck.AddToTop(HiddenDeck.GetTopCard());
		HiddenDeck.RemoveTopCard();
    }

	public void AddToHiddenDeck(Card card)
    {
		HiddenDeck.AddToTop(card);
    }

	public Card? GetTopHiddenCard()
    {
		if (!HiddenDeck.Empty())
		{
			return HiddenDeck.GetTopCard();
		}
		return null;
    }

	public Card? GetTopShownCard()
	{
		if (!ShownDeck.Empty())
		{
			return ShownDeck.GetTopCard();
		}
		return null;
	}
}