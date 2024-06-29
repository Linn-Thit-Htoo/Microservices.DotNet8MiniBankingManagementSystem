namespace Withdraw.Microservice.Features.Withdraw
{
    public class BL_Withdraw
    {
        #region Initialization

        private readonly DA_Withdraw _dA_Withdraw;

        public BL_Withdraw(DA_Withdraw dAWithdraw)
        {
            _dA_Withdraw = dAWithdraw;
        }

        #endregion

        #region Get With Draw List By Account No Async

        public async Task<Result<WithdrawListResponseModel>> GetWithDrawListByAccountNoAsync(
            string accountNo
        )
        {
            if (string.IsNullOrWhiteSpace(accountNo))
                throw new Exception("Account No cannot be empty.");

            return await _dA_Withdraw.GetWithDrawListByAccountNoAsync(accountNo);
        }

        #endregion

        #region Create With draw Async

        public async Task<Result<WithdrawResponseModel>> CreateWithDrawAsync(
            WithdrawRequestModel requestModel
        )
        {
            return await _dA_Withdraw.CreateWithDrawAsync(requestModel);
        }

        #endregion
    }
}
