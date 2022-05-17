namespace Snap
{
	public class Deck
	{
        private readonly List<string> defualtSorts = new() { "hearts", "spades", "diamonds", "clubs" };

        Stack deck = new(); 

        public Deck(int cardsPerSort = 13, List<string>? sorts = null)
		{
            if(sorts == null)
            {
                sorts = defualtSorts;
            }

            foreach(string sort in sorts)
            {
                for(int x = 1; x < cardsPerSort + 1; x++)
                {
                    Card card = new(x, sort);
                    deck.Push(card);
                }
            }
		}

        public Card? GetTopCard()
        {
            return deck.Top();
        }

        public void RemoveTopCard()
        {
            deck.Pop();
        }

        public void Shuffle()
        {
            Stack tempDeck = new();
            Random randInt = new();

            while(!deck.Empty())
            {
                int randomNumber = randInt.Next(0, deck.Size());
                tempDeck.Push(deck.GetCardAt(Convert.ToInt32(randomNumber)));
                deck.RemoveCardAt(randomNumber);
            }
            deck = tempDeck;
        }
	}
}

