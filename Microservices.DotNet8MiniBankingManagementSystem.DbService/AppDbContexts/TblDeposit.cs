using System;
using System.Collections.Generic;

namespace Microservices.DotNet8MiniBankingManagementSystem.DbService.AppDbContexts;

public partial class TblDeposit
{
    public long DepositId { get; set; }

    public string AccountNo { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime DepositDate { get; set; }
}
