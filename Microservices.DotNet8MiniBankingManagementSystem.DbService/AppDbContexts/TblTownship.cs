namespace Microservices.DotNet8MiniBankingManagementSystem.DbService.AppDbContexts;

public partial class TblTownship
{
    public long TownshipId { get; set; }

    public string TownshipCode { get; set; } = null!;

    public string TownshipName { get; set; } = null!;

    public string StateCode { get; set; } = null!;
}
