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

    public string GetSuit()
    {
        return cardSuit;
    }

    public int GetNumber()
    {
        return cardNumber;
    }
}