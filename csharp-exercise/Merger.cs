namespace csharp_exercise
{
    public class Merger
    {
        public static Node Merge(Node head1, Node head2)
        {
            Node current = null, previous = null;
            Node merged = null;


            while(head1 != null && head2 != null)
            {
                current = new Node();

                if (head1.data <= head2.data)
                {
                    current.data = head1.data;
                    head1 = head1.next;
                }
                else
                {
                    current.data = head2.data;
                    head2 = head2.next;
                }

                if(merged == null)
                    merged = current;
                else
                    previous.next = current;

                previous = current;

            }


            Node leftover = (head1 == null ? head2 : head1);
            while(leftover != null)
            {
                current = new Node
                {
                    data = leftover.data
                };

                if (merged == null)
                    merged = current;
                else
                    previous.next = current;

                previous = current;
                leftover = leftover.next;
            }

            return merged;
        }
    }
}