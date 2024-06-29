using Microservices.DotNet8MiniBankingManagementSystem.DbService.AppDbContexts;
using Microservices.DotNet8MiniBankingManagementSystem.Mapper;
using Microservices.DotNet8MiniBankingManagementSystem.Models.Features;
using Microservices.DotNet8MiniBankingManagementSystem.Models.Features.State;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace State.Microservice.Features.State
{
    public class DA_State
    {
        #region Initializations

        private readonly AppDbContext _appDbContext;

        public DA_State(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #endregion

        #region Get State List Async

        public async Task<Result<StateListResponseModel>> GetStateListAsync()
        {
            Result<StateListResponseModel> responseModel;
            try
            {
                var states = await _appDbContext
                    .TblStates.AsNoTracking()
                    .OrderByDescending(x => x.StateId)
                    .ToListAsync();

                var lst = states.Select(x => x.Change()).ToList();
                var model = new StateListResponseModel { DataLst = lst };

                responseModel = Result<StateListResponseModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                responseModel = Result<StateListResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        #endregion

        #region Create States Async

        public async Task<Result<StateResponseModel>> CreateStatesAsync()
        {
            Result<StateResponseModel> responseModel;
            try
            {
                string jsonStr = await File.ReadAllTextAsync("Data/StateList.json");
                List<TblState> lst = JsonConvert.DeserializeObject<
                    List<TblState>
                >(jsonStr)!;
                await _appDbContext.TblStates.AddRangeAsync(lst);
                int result = await _appDbContext.SaveChangesAsync();

                responseModel = Result<StateResponseModel>.ExecuteResult(result);
            }
            catch (Exception ex)
            {
                responseModel = Result<StateResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        #endregion
    }
}
