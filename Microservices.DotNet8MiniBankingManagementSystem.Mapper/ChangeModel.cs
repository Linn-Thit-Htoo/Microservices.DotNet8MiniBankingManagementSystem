namespace Microservices.DotNet8MiniBankingManagementSystem.Mapper;

public static class ChangeModel
{
    #region Account

    public static AccountModel Change(this TblAccount dataModel)
    {
        return new AccountModel()
        {
            AccountId = dataModel.AccountId,
            AccountLevel = dataModel.AccountLevel,
            AccountNo = dataModel.AccountNo,
            Balance = dataModel.Balance,
            CustomerCode = dataModel.CustomerCode,
            CustomerName = dataModel.CustomerName,
            IsActive = dataModel.IsActive,
            StateCode = dataModel.StateCode,
            TownshipCode = dataModel.TownshipCode,
        };
    }

    public static TblAccount Change(this AccountRequestModel requestModel)
    {
        return new TblAccount()
        {
            AccountNo = Ulid.NewUlid().ToString(),
            AccountLevel = requestModel.AccountLevel,
            CustomerCode = requestModel.CustomerCode!,
            CustomerName = requestModel.CustomerName,
            Balance = requestModel.Balance,
            StateCode = requestModel.StateCode,
            TownshipCode = requestModel.TownshipCode,
            IsActive = true
        };
    }

    #endregion

    #region State

    public static StateModel Change(this TblState dataModel)
    {
        return new StateModel()
        {
            StateId = dataModel.StateId,
            StateCode = dataModel.StateCode,
            StateName = dataModel.StateName
        };
    }

    public static TownshipModel Change(this TblTownship dataModel)
    {
        return new TownshipModel()
        {
            TownshipId = dataModel.TownshipId,
            StateCode = dataModel.StateCode,
            TownshipCode = dataModel.TownshipCode
        };
    }

    #endregion

    #region Deposit

    public static DepositModel Change(this TblDeposit dataModel)
    {
        return new DepositModel()
        {
            DepositId = dataModel.DepositId,
            AccountNo = dataModel.AccountNo,
            Amount = Convert.ToInt32(dataModel.Amount),
            DepositDate = dataModel.DepositDate
        };
    }

    public static TblDeposit Change(this DepositRequestModel requestModel)
    {
        return new TblDeposit()
        {
            AccountNo = requestModel.AccountNo,
            Amount = requestModel.Amount,
            DepositDate = DateTime.Now
        };
    }

    #endregion

    #region WithDraw

    public static WithdrawModel Change(this TblWithdraw dataModel)
    {
        return new WithdrawModel()
        {
            AccountNo = dataModel.AccountNo,
            WithDrawId = dataModel.WithDrawId,
            Amount = Convert.ToInt32(dataModel.Amount),
            WithDrawDate = dataModel.WithDrawDate
        };
    }

    public static TblWithdraw Change(this WithdrawRequestModel requestModel)
    {
        return new TblWithdraw()
        {
            AccountNo = requestModel.AccountNo,
            Amount = requestModel.Amount,
            WithDrawDate = DateTime.Now,
        };
    }

    #endregion

    #region Transaction History

    public static TransactionHistoryModel Change(this TblTransactionHistory dataModel)
    {
        return new TransactionHistoryModel
        {
            Amount = Convert.ToInt32(dataModel.Amount),
            FromAccountNo = dataModel.FromAccountNo,
            ToAccountNo = dataModel.ToAccountNo,
            TransactionDate = dataModel.TransactionDate,
            TransactionHistoryId = dataModel.TransactionHistoryId
        };
    }

    public static TblTransactionHistory Change(this TransactionRequestModel requestModel)
    {
        return new TblTransactionHistory
        {
            TransactionHistoryId = Ulid.NewUlid().ToString(),
            FromAccountNo = requestModel.FromAccountNo,
            ToAccountNo = requestModel.ToAccountNo,
            Amount = requestModel.Amount,
            TransactionDate = DateTime.Now
        };
    }

    #endregion
}