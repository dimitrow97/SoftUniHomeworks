using System;

public class ArrayList<T>
{
    public int Count { get; set; }
    public int Capacity { get; set; }
    public T[] arr;

    public ArrayList()
    {
        this.Capacity = 2;
        this.arr = new T[Capacity];
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentOutOfRangeException();
            return this.arr[index];
        }
        set
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentOutOfRangeException();
            this.arr[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Capacity == this.Count)
            this.Grow();
        this.arr[Count] = item;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
            throw new ArgumentOutOfRangeException();
        T item = this.arr[index];
        this.arr[index] = default(T);
        this.MoveLeft(index);
        this.Count--;
        if (this.Count <= this.arr.Length / 4)
            this.Shrink();
        return item;
    }

    private void Grow()
    {
        T[] newArr = new T[this.Capacity * 2];
        this.Capacity *= 2;
        Array.Copy(this.arr, newArr, this.Count);
        this.arr = newArr;
    }

    private void Shrink()
    {
        T[] newArr = new T[this.Capacity / 4];
        this.Capacity /= 4;
        Array.Copy(this.arr, newArr, this.Count);
        this.arr = newArr;
    }

    private void MoveLeft(int index)
    {
        for(int i = index; i < this.Count; i++)
        {
            this.arr[i] = arr[i + 1];
        }
    }
}
