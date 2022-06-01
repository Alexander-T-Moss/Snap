namespace Snap;

public class Card
{
    protected int cardNumber;
    protected string cardSuit;
        
	public Card(int number, string suit)
	{
        cardNumber = number;
        cardSuit = suit;
 	}

    // Returns self's cardSuit
    public string GetSuit()
    {
        return cardSuit;
    }

    // Returns self's cardNumber
    public int GetNumber()
    {
        return cardNumber;
    }
}


