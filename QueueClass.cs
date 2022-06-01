namespace Snap
{
    public class Queue
	{
        private List<Card> queue;

        public Queue()
		{
            this.queue = new();
		}

        public bool Empty()
        {
            if (queue.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Card? First()
        {
            if (Empty())
            {
                return null;
            }
            else
            {
                return queue[0];
            }
        }

        public int Size()
        {
            return queue.Count;
        }

        public void Enqueue(Card card)
        {
            queue.Add(card);
        }

        public void Dequeue()
        {
            queue.RemoveAt(0);
        }
	}
}

