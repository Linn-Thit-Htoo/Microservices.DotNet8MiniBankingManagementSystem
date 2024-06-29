using Microservices.DotNet8MiniBankingManagementSystem.Models.Features.Account;
using Microservices.DotNet8MiniBankingManagementSystem.Models.Features;

namespace Account.Microservice.Features.Account;

public class BL_Account
{
    #region Initializations

    private readonly DA_Account _dA_Account;

    public BL_Account(DA_Account dA_Account)
    {
        _dA_Account = dA_Account;
    }

    #endregion

    #region Get Account List Async

    public async Task<Result<AccountListResponseModel>> GetAccountListAsync()
    {
        return await _dA_Account.GetAccountListAsync();
    }

    #endregion

    #region Create Account

    public async Task<Result<AccountResponseModel>> CreateAccount(AccountRequestModel requestModel)
    {
        return await _dA_Account.CreateAccount(requestModel);
    }

    #endregion
}