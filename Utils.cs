namespace BankManager;

public static class Utils
{
    public static void Dash(string sign = "=", int n = 30)
    {
        for (var i = 0; i < n; i++)
        {
            Console.Write(sign);
        }
        Console.WriteLine();
    }

    public static void Title(string text)
    {
        Console.Clear();
        var size = text.Length + 2;
        Dash(n: size);
        Console.WriteLine($" {text} ");
        Dash(n: size);
        Console.WriteLine();
    }

    public static void Exit()
    {
        Utils.Dash("-", 40);
        Console.Write("Pressione qualquer tecla para continuar.");
        Console.ReadKey();
    }
}