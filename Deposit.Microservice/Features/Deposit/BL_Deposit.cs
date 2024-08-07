﻿namespace Deposit.Microservice.Features.Deposit;

public class BL_Deposit
{
    #region Initializations

    private readonly DA_Deposit _dA_Deposit;

    public BL_Deposit(DA_Deposit dA_Deposit)
    {
        _dA_Deposit = dA_Deposit;
    }

    #endregion

    #region Get Deposit List By Account No Async

    public async Task<Result<DepositListResponseModel>> GetDepositListByAccountNoAsync(
        string accountNo
    )
    {
        if (string.IsNullOrWhiteSpace(accountNo))
            throw new Exception("Account No cannot be empty.");

        return await _dA_Deposit.GetDepositListByAccountNoAsync(accountNo);
    }

    #endregion

    #region Create Deposit Async

    public async Task<Result<DepositResponseModel>> CreateDepositAsync(
        DepositRequestModel requestModel
    )
    {
        return await _dA_Deposit.CreateDepositAsync(requestModel);
    }

    #endregion
}
