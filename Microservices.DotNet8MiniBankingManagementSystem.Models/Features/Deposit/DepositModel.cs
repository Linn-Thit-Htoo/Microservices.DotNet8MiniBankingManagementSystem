namespace Microservices.DotNet8MiniBankingManagementSystem.Models.Features.Deposit;

public class DepositModel
{
    public long DepositId { get; set; }
    public string AccountNo { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime DepositDate { get; set; }
}
