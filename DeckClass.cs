namespace Snap;

public class Deck
{
    private readonly List<string> defualtSorts = new() { "hearts", "spades", "diamonds", "clubs" };

    List<Card> deck = new();

    public Deck(bool emptyDeck = false, int cardsPerSort = 13, List<string>? sorts = null)
    {
        if (!emptyDeck)
        {
            if (sorts == null)
            {
                sorts = defualtSorts;
            }

            foreach (string sort in sorts)
            {
                for (int x = 1; x < cardsPerSort + 1; x++)
                {
                    Card card = new(x, sort);
                    deck.Add(card);
                }
            }
        }
    }

    public int Size()
    {
        return deck.Count;
    }

    public void AddToTop(Card card)
    {
        deck.Add(card);
    }

    public bool Empty()
    {
        if (Size() == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Clear()
    {
        deck = new();
    }

    public Card? GetTopCard()
    {
        if (!Empty())
        {
            return deck[^1];
        }
        return null;
    }

    public void RemoveTopCard()
    {
        if (!Empty())
        {
            deck.RemoveAt(Size() - 1);
        }
    }

    public void Merge(Deck addedCards)
    {
        while (!addedCards.Empty())
        {
            deck.Insert(0, addedCards.GetTopCard());
            addedCards.RemoveTopCard();
        }
    }

    public void Flip()
    {
        List<Card> tempDeck = new();
        while (Size() > 0)
        {
            tempDeck.Add(GetTopCard());
            RemoveTopCard();
        }
        deck = tempDeck;
    }

    public void Shuffle()
    {
        List<Card> tempDeck = new();
        Random randInt = new();

        while (deck.Count != 0)
        {
            int randomNumber = randInt.Next(0, deck.Count);
            tempDeck.Add(deck[Convert.ToInt32(randomNumber)]);
            deck.RemoveAt(randomNumber);
        }
        deck = tempDeck;
    }
}