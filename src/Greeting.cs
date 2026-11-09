namespace HelloDotnet;

public static class Greeting
{
    public static string Greet(string name) => $"Hello, {name}!";

    public static int SumRange(int from, int to)
    {
        if (from > to)
        {
            return 0;
        }

        var sum = 0;
        for (var value = from; value <= to; value++)
        {
            sum = checked(sum + value);
        }

        return sum;
    }
}
