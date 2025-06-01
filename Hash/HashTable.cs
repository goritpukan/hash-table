namespace Hash;

public class HashEntry
{
    public string Key;
    public int Value;
    public bool IsDeleted;

    public HashEntry(string key, int value)
    {
        Key = key;
        Value = value;
        IsDeleted = false;
    }
}
public class HashTable
{
    private byte[] T1;
    private byte[] T2;
    private HashEntry[] table;
    private int size = 1031;
    public HashTable()
    {
        table = new HashEntry[size];
        do
        {
            T1 = new byte[256];
            T2 = new byte[256];
            GenerateRandomT(T1);
            GenerateRandomT(T2);
        }while(T1.SequenceEqual(T2));
    }

    public int this[string key]
    {
        get => Get(key);
    }

    private void GenerateRandomT(byte[] T)
    {
        var random = new Random();
        for (int i = 0; i < 256; i++)
        {
            T[i] = (byte)random.Next(0, 256);
        }
    }

    private byte PearsonHashing(string input, byte[] T)
    {
        var hash = (byte)input.Length;
        foreach (char c in input)
        {
            hash = T[hash ^ (byte)c];
        }
        
        return hash;
    }

    private int Probe(string key, int i)
    {
        int h1 = PearsonHashing(key, T1) % size;
        int h2 = 1 + (PearsonHashing(key, T2) % (size - 1));
        return (h1 + i * h2) % size;
    }

    public void Add(string key, int value)
    {
        for (int i = 0; i < size; i++)
        {
            int index = Probe(key, i);
            
            if (table[index] is null || table[index].IsDeleted || table[index].Key == key)
            {
                table[index] = new HashEntry(key, value);
                return;
            }
        }
        throw new Exception("Hash table is full");
    }
    private int Get(string key)
    {
        for (int i = 0; i < size; i++)
        {
            int index = Probe(key, i);

            if (table[index] is null)
                break;

            if (!table[index].IsDeleted && table[index].Key == key)
                return table[index].Value;
        }
        throw new KeyNotFoundException("Key not found");
    }

    public void Remove(string key)
    {
        for (int i = 0; i < size; i++)
        {
            int index = Probe(key, i);

            if (table[index] is null)
                return;

            if (!table[index].IsDeleted && table[index].Key == key)
            {
                table[index].IsDeleted = true;
                return;
            }
        }
    }
}