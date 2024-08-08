namespace BlazorAppSpendRegister.Models;

public class Spend
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Value { get; set; }
}
