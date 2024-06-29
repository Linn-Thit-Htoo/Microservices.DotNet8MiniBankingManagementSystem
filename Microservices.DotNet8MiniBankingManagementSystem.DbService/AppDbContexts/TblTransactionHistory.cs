using System;
using System.Collections.Generic;

namespace Microservices.DotNet8MiniBankingManagementSystem.DbService.AppDbContexts;

public partial class TblTransactionHistory
{
    public string TransactionHistoryId { get; set; } = null!;

    public string FromAccountNo { get; set; } = null!;

    public string ToAccountNo { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }
}
