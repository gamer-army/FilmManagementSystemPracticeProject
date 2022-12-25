public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Input:");
        var temp = Console.ReadLine();
        var duration = TimeSpan.Parse(temp!);

        Console.WriteLine(duration);
    }
}