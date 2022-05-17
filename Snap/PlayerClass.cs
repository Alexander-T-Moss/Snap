namespace Snap
{
	public class Player
	{
		public Queue playersHiddenDeck;
		public Stack playersShownDeck;

		public Player()
		{
			this.playersHiddenDeck = new();
			this.playersShownDeck = new();
		}


		// Returns and removes top card from playersHiddenDeck //

		public Card? DrawTopHiddenCard() 
        {
			if(playersHiddenDeck.First() != null)
            {
				Card? topCard = playersHiddenDeck.First();
				playersHiddenDeck.Dequeue();
				return topCard;
            }
            else
            {
				return null;
            }
        }
	}

	public class ComputerPlayer : Player
    {
		public Random reactionTime = new();

    }
}

