namespace BankManager;

using BankManager.Model;

//public static class Database
//{
//    public static List<BankModel> Banks = new();
//    public static List<ClientModel> Clients = new();
//}

public static class Database
{
    public static List<BankModel> Banks = new() {
        new BankModel() {Id = "123", Name = "Santander" },
        new BankModel() {Id = "321", Name = "Itau" }
    };

    public static List<ClientModel> Clients = new() {
        new ClientModel() { Id = "12", Name = "Ana", Bank = Banks[0] } ,
        new ClientModel() { Id = "29", Name = "João", Bank = Banks[1] }
    };
}