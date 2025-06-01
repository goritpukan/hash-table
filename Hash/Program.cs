namespace Hash;

public static class Program
{
    public static void Main(string[] args)
    {
        var hashTable = new HashTable();
        hashTable.Add("Hello", 290);
        hashTable.Add("String", 257870);
        hashTable.Add("KPI", 666);
        hashTable.Add("remove", 6);
        Console.WriteLine(hashTable["Hello"]);
        Console.WriteLine(hashTable["String"]);
        Console.WriteLine(hashTable["KPI"]);
        Console.WriteLine(hashTable["remove"]);
        hashTable.Remove("remove");
        try
        {
            Console.WriteLine(hashTable["remove"]);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        
    }
}