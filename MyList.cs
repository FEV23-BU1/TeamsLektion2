namespace Lists;

public class MyList
{
    private string[] items;

    public MyList()
    {
        this.items = new string[0];
    }

    public void Add(string value)
    {
        string[] newArray = new string[this.items.Length + 1];
        for (int i = 0; i < this.items.Length; i++)
        {
            newArray[i] = this.items[i];
        }

        newArray[newArray.Length - 1] = value;
        this.items = newArray;
    }

    public void Remove(string value)
    {
        for (int i = this.items.Length - 1; i >= 0; i--)
        {
            if (this.items[i] == value)
            {
                this.RemoveAt(i);
            }
        }
    }

    public bool Contains(string value)
    {
        for (int i = this.items.Length - 1; i >= 0; i--)
        {
            if (this.items[i] == value)
            {
                return true;
            }
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (this.items.Length == 0)
        {
            return;
        }

        string[] newArray = new string[this.items.Length - 1];

        for (int i = 0; i < index; i++)
        {
            newArray[i] = this.items[i];
        }

        for (int i = index + 1; i < this.items.Length; i++)
        {
            newArray[i - 1] = this.items[i];
        }

        this.items = newArray;
    }

    public void Print()
    {
        for (int i = 0; i < this.items.Length; i++)
        {
            Console.WriteLine(this.items[i]);
        }
    }
}
