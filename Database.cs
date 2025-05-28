namespace BankManager;

using BankManager.Model;

public static class Database
{
    public static List<BankModel> Banks = new();
    public static List<ClientModel> Clients = new();
}

//public static class Database
//{
//    public static List<BankModel> Banks = new() {
//        new BankModel() {Id = Utils.GenerateId(), Name = "Santander" },
//        new BankModel() {Id = Utils.GenerateId(), Name = "Itaú" },
//        new BankModel() {Id = Utils.GenerateId(), Name = "Bradesco" }

//    };

//    public static List<ClientModel> Clients = new() {
//        new ClientModel() { Id = Utils.GenerateId(), Name = "Ana", Bank = Banks[0] } ,
//        new ClientModel() { Id = Utils.GenerateId(), Name = "João", Bank = Banks[1] }
//    };
//}