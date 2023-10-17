using System.Collections;


var myLinkedList = new CustomLinkedList<string>();

myLinkedList.Add("a");
myLinkedList.AddToEnd("b");
myLinkedList.AddToFront("c");

foreach (var item in myLinkedList) Console.WriteLine(item);
myLinkedList.Remove("a");
Console.WriteLine(myLinkedList);





Console.ReadKey();

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}

public class CustomLinkedList<T> : ILinkedList<T?>
{
    public bool IsReadOnly { get; } = false;
    private CustomLinkedListNode<T>? _head;
    private CustomLinkedListNode<T>? _tail;
    private int _count;
    public int Count => _count;

    public CustomLinkedList()
    {
    }

    //public int GetCount()
    //{
    //    int count = 0;
    //    //while ()
    //    return count;
    //}
    public void Add(T? item) => AddToEnd(item);

    public void AddToEnd(T? item)
    {
        var newItem = new CustomLinkedListNode<T>(this, item);

        if (_head is null)
        {
            AddToEmpty(newItem);
        }
        else
        {
            _tail!.Next = newItem;
            _tail = newItem;
            newItem.Next = null;
        }
        _count++;
    }

    public void AddToFront(T? item)
    {
        var newItem = new CustomLinkedListNode<T>(this, item);

        if (_head is null)
        {
            AddToEmpty(newItem);
        }
        else
        {
            newItem.Next = _head;
            _head = newItem;
        }
        _count++;
    }

    public void AddToEmpty(CustomLinkedListNode<T> newNode)
    {
        _head = newNode;
        _tail = newNode;
        newNode.Next = newNode;
    }
    public void Clear()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public bool Contains(T? value) => Find(value) is not null;
    public CustomLinkedListNode<T>? Find(T? value)
    {
        CustomLinkedListNode<T>? node = _head;
        if (node is null || node.Value is null) return null;
        do
        {
            if (node.Value!.Equals(value)) return node;
            node = node.Next;
        }
        while (node!.Next != _head);
        return null;
    }

    public CustomLinkedListNode<T>? FindPrevious(T? value)
    {
        CustomLinkedListNode<T>? node = _head;
        if (node is null || node.Value is null || node.Next is null) return null;
        do
        {
            if (node.Next!.Value!.Equals(value)) return node;
            node = node.Next;
        }
        while (node != _head);
        return null;
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (arrayIndex < 0 || arrayIndex >= array.Length)
            throw new ArgumentOutOfRangeException("index out of range");

        CustomLinkedListNode<T> node = _head;
        do
        {
            array[arrayIndex] = node.Value;
            node = node.Next;
        }
        while (node != _head);
    }

    public CustomEnumerator GetEnumerator()
    {
        return new CustomEnumerator(this);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    IEnumerator<T> IEnumerable<T?>.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Remove(T? item)
    {
        CustomLinkedListNode<T>? itemToRemove = Find(item);
        if (itemToRemove == null) return false;
        else
        {
            CustomLinkedListNode<T>? prevItem = FindPrevious(item);
            if (prevItem is not null) prevItem.Next = itemToRemove.Next;
            itemToRemove.Next = null;
            _count--;
            return true;
        }
    }

    public struct CustomEnumerator : IEnumerator<T>, IEnumerator
    {
        private readonly CustomLinkedList<T> _customLinkedList;
        private readonly int initialIndex = -1;
        private int _currentIndex;
        private T? _current;

        public CustomEnumerator(CustomLinkedList<T> linkedList)
        {
            _customLinkedList = linkedList;
        }

        public T Current => _current!;

        object? IEnumerator.Current => _current;

        public bool MoveNext()
        {
            ++_currentIndex;
            return _currentIndex < _customLinkedList.Count;
        }

        public void Reset() => _currentIndex = initialIndex;
        public void Dispose()
        {
        }
    }
}

public class CustomLinkedListNode<T>
{
    public CustomLinkedList<T>? NodeList;
    public T? Value;
    public CustomLinkedListNode<T>? Next;

    public CustomLinkedListNode(CustomLinkedList<T> nodeList, T value)
    {
        NodeList = nodeList;
        Value = value;
    }

    public override string ToString()
    {
        return $"Value: {Value}" +
            $"Next: {(Next is null ? "null" : Next.Value)}";
    }
}

