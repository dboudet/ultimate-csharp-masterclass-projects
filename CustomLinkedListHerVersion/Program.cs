using System.Collections;


var myLinkedList = new CustomLinkedList<string>();

myLinkedList.Add("b");
myLinkedList.AddToEnd("c");
myLinkedList.AddToFront("a");

foreach (var item in myLinkedList)
{
    Console.WriteLine(item);
}
Console.WriteLine(new String('-', 30));
Console.WriteLine("Contains b?" + myLinkedList.Contains("b"));
Console.WriteLine("Contains d?" + myLinkedList.Contains("d"));
myLinkedList.Remove("a");
Console.WriteLine(new String('-', 30));
foreach (var item in myLinkedList)
{
    Console.WriteLine(item);
}


var newArray = new string[7];
//myLinkedList.CopyTo(newArray, 7);
myLinkedList.CopyTo(newArray, 2);



Console.ReadKey();

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}

public class CustomLinkedList<T> : ILinkedList<T?>
{
    public bool IsReadOnly { get; } = false;
    private CustomLinkedListNode? _head;
    //private CustomLinkedListNode? _tail;
    private int _count;
    public int Count => _count;


    public void Add(T? item) => AddToEnd(item);

    public void AddToEnd(T? item)
    {
        // IMPORTANT: NOT ASSIGNING A NEXT VALUE TO LAST ITEM
        // SO... LAST NEVER HAS NEXT - EASY TO KNOW WHEN ON LAST
        var newNode = new CustomLinkedListNode(item);
        if (_head is null)
        {
            _head = newNode;
        }
        else
        {
            var tail = GetNodes().Last();
            tail.Next = newNode;
        }
        ++_count;
    }

    public void AddToFront(T? item)
    {
        var newHead = new CustomLinkedListNode(item)
        {
            Next = _head
        };
        _head = newHead;
        ++_count;
    }

    public void Clear()
    {
        CustomLinkedListNode? current = _head;
        while (current is not null)
        {
            CustomLinkedListNode? temp = current;
            current = current.Next;
            temp.Next = null;
        }
        _head = null;
        _count = 0;
    }

    public bool Contains(T? item)
    {
        if (item is null)
        {
            return GetNodes().Any(x => x.Value is null);
        }
        return GetNodes().Any(x => item.Equals(x.Value));
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array is null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0 || arrayIndex >= array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length < _count + arrayIndex)
            throw new ArgumentException("Array is not long enough.");
        foreach (var node in GetNodes())
        {
            array[arrayIndex] = node.Value;
            ++arrayIndex;
        }
    }

    public bool Remove(T? item)
    {
        foreach (var node in GetNodes())
        {
            CustomLinkedListNode? predecessor = null;
            if (
                (node.Value is null && item is null) ||
                (node.Value is not null && node.Value.Equals(item)))
            {
                if (predecessor is null)
                {
                    _head = node.Next;
                }
                else
                {
                    predecessor.Next = node.Next;

                }
                //node.Next = null;
                --_count;
                return true;
            }
            predecessor = node;
        }
        return false;
    }

    public IEnumerator<T?> GetEnumerator()
    {
        foreach (var node in GetNodes())
        {
            yield return node.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    private IEnumerable<CustomLinkedListNode> GetNodes()
    {
        CustomLinkedListNode? current = _head;
        while (current is not null)
        {
            yield return current;
            current = current.Next;
        }
    }
    private class CustomLinkedListNode
    {
        internal T? Value { get; }
        internal CustomLinkedListNode? Next;

        internal CustomLinkedListNode(T? value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Value: {Value}" +
                $"Next: {(Next is null ? "null" : Next.Value)}";
        }
    }
}


