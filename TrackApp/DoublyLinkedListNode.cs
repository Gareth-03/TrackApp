public class DoublyLinkedListNode
{
    public Track Data { get; set; }
    public DoublyLinkedListNode Next { get; set; }
    public DoublyLinkedListNode Previous { get; set; }

    public DoublyLinkedListNode(Track data)
    {
        Data = data;
    }
}

public class Playlist
{
    private DoublyLinkedListNode head;
    private DoublyLinkedListNode tail;
    private DoublyLinkedListNode current;

    public void AddTrack(Track track)
    {
        var newNode = new DoublyLinkedListNode(track);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            current = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
    }

    public void RemoveTrack(string trackName)
    {
        var node = FindNode(trackName);
        if (node != null)
        {
            if (node == head)
            {
                head = node.Next;
                if (head != null) head.Previous = null;
            }
            else if (node == tail)
            {
                tail = node.Previous;
                if (tail != null) tail.Next = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }
        }
    }

    public Track FindTrack(string trackName)
    {
        var node = FindNode(trackName);
        return node?.Data;
    }

    public void MoveNext()
    {
        if (current?.Next != null)
        {
            current = current.Next;
        }
    }

    public void MovePrevious()
    {
        if (current?.Previous != null)
        {
            current = current.Previous;
        }
    }

    public Track GetCurrentTrack()
    {
        return current?.Data;
    }

    private DoublyLinkedListNode FindNode(string trackName)
    {
        var node = head;
        while (node != null)
        {
            if (node.Data.Name.Equals(trackName, StringComparison.OrdinalIgnoreCase))
            {
                return node;
            }
            node = node.Next;
        }
        return null;
    }

    public void Shuffle()
    {
        var rand = new Random();
        var nodes = new List<DoublyLinkedListNode>();
        var node = head;

        while (node != null)
        {
            nodes.Add(node);
            node = node.Next;
        }

        nodes = nodes.OrderBy(x => rand.Next()).ToList();

        head = nodes.First();
        tail = nodes.Last();

        for (int i = 0; i < nodes.Count; i++)
        {
            if (i == 0)
            {
                nodes[i].Previous = null;
            }
            else
            {
                nodes[i].Previous = nodes[i - 1];
            }

            if (i == nodes.Count - 1)
            {
                nodes[i].Next = null;
            }
            else
            {
                nodes[i].Next = nodes[i + 1];
            }
        }

        current = head;
    }
}
