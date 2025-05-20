namespace BankManager;

public static class Menu
{
    public static void Start()
    {
        while (true)
        {
            Show();
            var selectedOption = GetOption();
            Execute(selectedOption);
        }
    }

    public static void Show()
    {
        Utils.Title("Sistema de Gerenciamento Bancário");
        Console.WriteLine("1 - Registrar um banco");
        Console.WriteLine("2 - Cadastrar um cliente");
        Console.WriteLine("3 - Exibir bancos");
        Console.WriteLine("4 - Exibir clientes");
        Console.WriteLine("5 - Editar nome do banco");
        Console.WriteLine("6 - Editar nome de cliente");
        Console.WriteLine("7 - Atualizar banco do cliente");
        Console.WriteLine("X - Sair");
        Console.WriteLine();
        Console.Write("Selecione uma opção: ");
    }

    public static string GetOption()
    {
        var options = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "X" };

        while (true)
        {
            try
            {
                var option = Console.ReadKey().KeyChar.ToString().ToUpper();

                if (options.Contains(option))
                {
                    return option;
                }

                throw new Exception("Opção Inválida.");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Utils.Dash();
                Console.WriteLine($"Erro: {ex.Message}");
                Utils.Dash();
                Console.WriteLine("\nTente novamente.");
                Thread.Sleep(1000);
                Show();
            }
        }
    }

    public static void Execute(string option)
    {
        Console.Clear();
        switch (option)
        {
            case "1": BankActions.RegisterBank(); break;
            case "2": ClientActions.RegisterClient(); break;
            case "3": BankActions.ShowBanks(); break;
            case "4": ClientActions.ShowClients(); break;
            case "5": BankActions.UpdateBank(); break;
            case "6": ClientActions.UpdateClientName(); break;
            case "7": ClientActions.UpdateClientBank(); break;
            case "X":
                {
                    Utils.Title("Saindo...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                }
        }
    }
}