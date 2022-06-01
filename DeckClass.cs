namespace Snap;

public class Deck
{
    private readonly List<string> defualtSorts = new() { "hearts", "spades", "diamonds", "clubs" };

    List<Card> deck = new();

    // Creates deck with custumization - defualts a standard deck of 52 cards and 4 suits
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


    // Returns how many Card objects a Deck contains
    public int Size()
    {
        return deck.Count;
    }

    // Adds card to the "top" of the Deck's list
    public void AddToTop(Card card)
    {
        deck.Add(card);
    }

    // Returns TRUE if deck contains no elements
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

    // Removes all cards from the deck
    public void Clear()
    {
        deck = new();
    }

    // Returns top card in deck or "null" if it is empty
    public Card? GetTopCard()
    {
        if (!Empty())
        {
            return deck[^1]; // deck[^1] is the same as deck[deck.Count -1]
        }
        return null;
    }

    // Removes card at "top" of the deck
    public void RemoveTopCard()
    {
        if (!Empty())
        {
            deck.RemoveAt(Size() - 1);
        }
    }

    // Adds another deck of cards to "bottom" of this deck
    public void Merge(Deck addedCards)
    {
        while (!addedCards.Empty())
        {
            deck.Insert(0, addedCards.GetTopCard());
            addedCards.RemoveTopCard();
        }
    }

    // Splits deck up sequentially between players
    

    // Shuffles the card order for self
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
