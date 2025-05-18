using BankManager.Model;

namespace BankManager;

public static class ClientActions
{
    public static void RegisterClient()
    {
        Utils.Title("Menu - Cadastrar novo cliente");

        string clientName;
        int clientBank;

        if (Database.Banks.Count == 0)
        {
            Console.WriteLine("Não é possível cadastrar um cliente sem um banco registrado.");
            //Utils.Dash("-");
            //Console.WriteLine("Presisone qualquer tecla para continuar.");
            //Console.ReadKey();
            Utils.Exit();
            return;
        }

        while (true)
        {
            string sign = "-";
            Utils.Dash(sign);
            Console.Write("Digite o nome do cliente: ");
            clientName = Console.ReadLine().Trim();
            Utils.Dash(sign);

            if (clientName != string.Empty)
            {
                break;
            }

            Utils.Title("Nome do cliente não pode ser vazio.");
            Thread.Sleep(1000);
        }

        while (true)
        {
            BankActions.ShowAllBanks();
            Console.Write("Selecione o banco do cliente: ");
            var bankSelected = Console.ReadLine().Trim();

            try
            {
                clientBank = Convert.ToInt32(bankSelected);

                Console.WriteLine($"!Debug! ClientBank: {clientBank}");
                Thread.Sleep(3000);

                if (clientBank < 0 || clientBank > Database.Banks.Count)
                {
                    throw new Exception("Valor inválido. Selecione um dos bancos exibidos.");
                }

                break;
            }
            catch (Exception ex)
            {
                Utils.Title(ex.Message);
                Thread.Sleep(1000);
            }
        }

        var client = new ClientModel()
        {
            Id = Guid.NewGuid().ToString().ToUpper().Substring(0, 8),
            Name = clientName,
            Bank = Database.Banks[clientBank - 1]
        };

        Database.Clients.Add(client);

        Utils.Title("Cadastrando cliente...");
        Thread.Sleep(1000);

        Utils.Title($"{clientName} foi cadastrado com sucesso!");
        Thread.Sleep(2000);
    }

    public static void ShowClients()
    {
        Utils.Title("Lista de clientes cadastrados");

        var allClients = Database.Clients;

        if (allClients.Count == 0)
            Console.WriteLine("Nenhum cliente cadastrado no sistema.");

        for (var i = 0; i < allClients.Count; i++)
        {
            var currentClient = allClients[i];
            var msg = $"ID: {currentClient.Id} - Cliente: {currentClient.Name} - Banco: {currentClient.Bank.Name}";

            if (i == 0)
                Utils.Dash("-", msg.Length);

            Console.WriteLine(msg);
            Utils.Dash("-", msg.Length);
        }

        //Console.WriteLine();
        //Console.Write("Pressione qualquer tecla para continuar.");
        //Console.ReadKey();
        Utils.Exit();
    }
}