using BankManager.Model;

namespace BankManager;

public static class BankActions
{
    private static List<BankModel> allBanks = Database.Banks;

    public static void RegisterBank()
    {
        string bankName;

        while (true)
        {
            try
            {
                Utils.Title("[Menu] Registrar novo banco");
                Console.Write("Digite o nome do banco: ");
                bankName = Console.ReadLine().Trim();

                if (!(bankName == string.Empty))
                    break;

                throw new Exception("Nome do banco não pode ser vazio.");
            }
            catch (Exception ex)
            {
                Utils.Message(ex.Message);
            }
        }

        var bank = new BankModel() { Id = Guid.NewGuid().ToString().ToUpper().Substring(0, 8), Name = bankName };
        Database.Banks.Add(bank);

        Utils.Message("Salvando banco...");
        Utils.Message($"{bankName} foi registrado com sucesso!", 2);
    }

    public static void ShowAllBanks()
    {
        Utils.Title("Lista de bancos registrados");

        if (allBanks.Count == 0)
        {
            Console.WriteLine("Nenhum banco encontrado.");
        }

        for (var i = 0; i < allBanks.Count; i++)
        {
            var currentBank = allBanks[i];
            var bankName = currentBank.Name;
            var msg = $"Banco {i + 1}: {bankName} - Registro: {currentBank.Id}";

            if (i == 0)
                Utils.Dash("-", msg.Length);

            Console.WriteLine(msg);
            Utils.Dash("-", msg.Length);
        }
    }

    public static void ShowBanks()
    {
        ShowAllBanks();
        Utils.Exit();
        //Console.Write("Pressione qualquer tecla para sair.");
        //Console.ReadKey();
        return;
    }

    public static void UpdateBank()
    {
        ShowAllBanks();

        int numberBank;

        if (Database.Banks.Count == 0)
        {
            //Console.WriteLine();
            //Console.Write("Pressione qualquer tecla para continuar.");
            //Console.ReadKey();
            Utils.Exit();
            return;
        }

        while (true)
        {
            ShowAllBanks();
            Console.WriteLine();
            Console.Write("Selecione um banco: ");
            var bankSelected = Console.ReadLine();

            try
            {
                numberBank = Convert.ToInt32(bankSelected);
                break;
            }
            catch (Exception ex)
            {
                Utils.Message(ex.Message);
            }
        }

        Console.Clear();

        while (true)
        {
            Utils.Dash();
            Console.Write("Digite o nome do banco: ");
            var textInput = Console.ReadLine().Trim();

            if (!(textInput == string.Empty))
            {
                Database.Banks[numberBank - 1].Name = textInput;

                Utils.Message("Atualizando...");
                Utils.Message("Nome atualizado com sucesso!");
                break;
            }

            Utils.Dash();
            Console.WriteLine();
            Utils.Message("Nome do banco não pode estar em branco.");
            Console.Clear();
        }
    }
}