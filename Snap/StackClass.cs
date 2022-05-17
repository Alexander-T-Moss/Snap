namespace Snap
{
    public class Stack
    {
        private List<Card> stack;

        public Stack()
        {
            this.stack = new();
        }

        public bool Empty()
        {
            if (stack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Size()
        {
            return stack.Count;
        }

        public Card? Top()
        {
            if (Empty())
            {
                return null;
            }
            else
            {
                return stack[^1]; // stack[^1] is the same as stack[stack.Count -1]
            }
        }

        public void Push(Card item)
        {
            stack.Add(item);
        }

        public void Pop()
        {
            if (!Empty())
            {
                stack.RemoveAt(stack.Count - 1);
            }
        }

        public Card GetCardAt(int cardIndex)
        {
            return stack[cardIndex];
        }

        public void RemoveCardAt(int cardIndex)
        {
            stack.RemoveAt(cardIndex);
        }
    }
}

