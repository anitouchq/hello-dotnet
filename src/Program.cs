using System.Runtime.InteropServices;
using HelloDotnet;

var version = typeof(Program).Assembly.GetName().Version?.ToString() ?? "dev";

Console.WriteLine($"hello-dotnet v{version}");
Console.WriteLine("Hello from C# and .NET! 🎯");
Console.WriteLine($"OS: {RuntimeInformation.OSDescription}");
Console.WriteLine($"Architecture: {RuntimeInformation.OSArchitecture}");
Console.WriteLine(Greeting.Greet("GitHub Actions"));
Console.WriteLine($"Sum 1..10 = {Greeting.SumRange(1, 10)}");

if (args.Length > 0)
{
    Console.WriteLine($"Arguments: {string.Join(", ", args)}");
}
