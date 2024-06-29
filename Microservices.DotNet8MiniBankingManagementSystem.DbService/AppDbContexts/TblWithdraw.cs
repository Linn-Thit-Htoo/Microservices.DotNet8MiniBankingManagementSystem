namespace Microservices.DotNet8MiniBankingManagementSystem.DbService.AppDbContexts;

public partial class TblWithdraw
{
    public long WithDrawId { get; set; }

    public string AccountNo { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime WithDrawDate { get; set; }
}
