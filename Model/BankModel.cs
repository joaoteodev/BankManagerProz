namespace BankManager.Model;

public class BankModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public BankModel Bank { get; set; }
}