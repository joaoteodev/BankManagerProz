using BankManager.Model;

namespace BankManager;

public static class ClientActions
{
    static List<ClientModel> allClients = Database.Clients;

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

            Utils.Message("Nome do cliente não pode ser vazio.");
        }

        while (true)
        {
            BankActions.ShowAllBanks();
            Console.WriteLine();
            Console.Write("Selecione o banco do cliente: ");
            var bankSelected = Console.ReadLine().Trim();

            try
            {
                clientBank = Convert.ToInt32(bankSelected);

                if (clientBank < 0 || clientBank > Database.Banks.Count)
                {
                    throw new Exception("Valor inválido. Selecione um dos bancos exibidos.");
                }

                break;
            }
            catch (Exception ex)
            {
                Utils.Message(ex.Message);
            }
        }

        var client = new ClientModel()
        {
            Id = Guid.NewGuid().ToString().ToUpper().Substring(0, 8),
            Name = clientName,
            Bank = Database.Banks[clientBank - 1]
        };

        Database.Clients.Add(client);

        Utils.Message("Cadastrando cliente...");
        Utils.Message($"{clientName} foi cadastrado com sucesso!", 2);
    }

    private static void ShowAllClients()
    {
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
    }

    public static void ShowClients()
    {
        Utils.Title("Lista de clientes cadastrados");

        ShowAllClients();
        //Console.WriteLine();
        //Console.Write("Pressione qualquer tecla para continuar.");
        //Console.ReadKey();
        Utils.Exit();
    }

    public static void UpdateClientName()
    {
        Utils.Title("Editando nome do cliente");

        ShowAllClients();

        if (allClients.Count == 0)
        {
            Utils.Exit();
            return;
        }

        string newClientName;
        string register;
        ClientModel client;

        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Digite o registro do cliente: ");
                register = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrEmpty(register))
                {
                    Console.Clear();
                    throw new Exception("Registro não pode estar vazio.");
                }

                client = allClients.First(c => c.Id == register);

                if (client == null)
                {
                    throw new Exception("Cliente não encontrado. Tente novamente");
                }

                break;
            }
            catch (Exception ex)
            {
                Utils.Message(ex.Message);
                ShowAllClients();
            }
        }

        while (true)
        {
            try
            {
                Console.Clear();
                Utils.Title($"[Atualizando] Registro: {client.Id} - Nome: {client.Name} - Banco: {client.Bank.Name}");

                Console.Write("Digite o novo nome: ");
                newClientName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(newClientName))
                {
                    throw new Exception("Nome do cliente não pode estar em branco.");
                }

                break;
            }
            catch (Exception ex)
            {
                Utils.Message(ex.Message);
            }
        }

        Utils.Message("Atualizando nome do cliente...");

        Database.Clients = Database.Clients.Select(c =>
        {
            if (c.Id == register)
            {
                c.Name = newClientName;
            }

            return c;
        }).ToList();

        //var updatedList = Database.Clients.Select(c =>
        //{
        //    if (c.Id == register)
        //    {
        //        c.Name = newClientName;
        //    }

        //    return c;
        //}).ToList();

        //updatedList.CopyTo(0, Database.Clients);

        Utils.Message("Nome do cliente atualizado com sucesso!");
    }

    public static void UpdateClientBank()
    {
        Utils.Title("Atualizando banco do cliente");

        ShowAllClients();
        Console.WriteLine();

        if (allClients.Count == 0)
        {
            Utils.Exit();
            return;
        }

        int newClientBank;
        string register;
        ClientModel client;

        while (true)
        {
            try
            {
                Console.Write("Digite o registro do cliente: ");
                register = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrEmpty(register))
                {
                    Console.Clear();
                    throw new Exception("Registro não pode estar vazio.");
                }

                client = allClients.First(c => c.Id == register);

                if (client == null)
                {
                    throw new Exception("Cliente não encontrado. Tente novamente");
                }

                break;
            }
            catch (Exception ex)
            {
                Utils.Message(ex.Message);
                ShowAllClients();
                Console.WriteLine();
            }
        }

        while (true)
        {
            Utils.Title($"[Atualizando] Registro: {client.Id} - Nome: {client.Name} - Banco: {client.Bank.Name}");

            BankActions.ShowAllBanks();
            Console.WriteLine();
            Console.Write("Selecione o banco do cliente: ");
            var newBankSelected = Console.ReadLine().Trim();

            try
            {
                newClientBank = Convert.ToInt32(newBankSelected);

                if (newClientBank < 0 || newClientBank > Database.Banks.Count)
                {
                    throw new Exception("Valor inválido. Selecione um dos bancos exibidos.");
                }

                break;
            }
            catch (Exception ex)
            {
                Utils.Message(ex.Message);
            }
        }

        Utils.Message("Atualizando banco do cliente...");

        Database.Clients = Database.Clients.Select(c =>
        {
            if (c.Id == register)
            {
                c.Bank = Database.Banks[newClientBank - 1];
            }
            return c;
        }).ToList();

        //var updatedList = Database.Clients.Select(c =>
        //{
        //    if (c.Id == register)
        //    {
        //        c.Name = newClientName;
        //    }

        //    return c;
        //}).ToList();

        //updatedList.CopyTo(0, Database.Clients);

        Utils.Message("Banco do cliente atualizado com sucesso!");
    }
}