namespace Hash;

public static class Program
{
    public static void Main(string[] args)
    {
        var hashTable100 = new HashTable(149);
        var hashTable1000 = new HashTable(1433);
        var hashTable5000 = new HashTable(7151);
        var hashTable10000 = new HashTable(14293);
        var hashTable200000 = new HashTable(28573);
        
        FillTable(hashTable100, 100);
        FillTable(hashTable1000, 1000);
        FillTable(hashTable5000, 5000);
        FillTable(hashTable10000, 10000);
        FillTable(hashTable200000, 20000);
        
        var random = new Random();
        string testString = GenerateRandomString(15);
        
        hashTable100.Add(testString, random.Next(1000));
        hashTable1000.Add(testString, random.Next(1000));
        hashTable5000.Add(testString, random.Next(1000));
        hashTable10000.Add(testString, random.Next(1000));
        hashTable200000.Add(testString, random.Next(1000));

        Console.WriteLine("Size: 100");
        var key100 = hashTable100[testString];
        Console.WriteLine("Size: 1000");
        var key1000 = hashTable1000[testString];
        Console.WriteLine("Size: 5000");
        var key5000=  hashTable5000[testString];
        Console.WriteLine("Size: 10000");
        var key10000 = hashTable10000[testString];
        Console.WriteLine("Size: 20000");
        var key20000 = hashTable200000[testString];

    }
    static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var result = new char[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }

        return new string(result);
    }

    static void FillTable(HashTable table, int size)
    {
        var random = new Random();
        for (int i = 0; i < size - 1; i++)
        {
            table.Add(GenerateRandomString(15), random.Next(100) );
        }
    }
}