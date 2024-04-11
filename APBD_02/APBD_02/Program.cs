class Program
{
    public static void Main(string[] args)
    {
        int[] tab = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        Console.WriteLine();
        Console.WriteLine("Średnia: " + Srednia(tab));
        Console.WriteLine("Max: " + Max(tab));

        Show(tab);
    }

    static double Srednia(int[] tab)
    {
        double sum = 0;
        foreach (var x in tab)
            sum += x;

        return sum / tab.Length;
    }
    static int Max(int[] tab)
    {
        int max = tab[0];
        foreach (var i in tab)
            if (i > max)
                max = i;

        return max;
    }
    static void Show(int[] tab)
    {
        foreach (var i in tab)
            Console.Write(i + " ");
        Console.WriteLine();
    }
}