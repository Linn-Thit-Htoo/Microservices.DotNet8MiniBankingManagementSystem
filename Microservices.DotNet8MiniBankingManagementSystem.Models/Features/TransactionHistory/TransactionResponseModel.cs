﻿namespace Microservices.DotNet8MiniBankingManagementSystem.Models.Features.TransactionHistory;

public class TransactionDataModel
{
    public string TransactionHistoryId { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string SenderName { get; set; } = null!;
    public string ReceiverName { get; set; } = null!;
}

public class TransactionResponseModel { }
