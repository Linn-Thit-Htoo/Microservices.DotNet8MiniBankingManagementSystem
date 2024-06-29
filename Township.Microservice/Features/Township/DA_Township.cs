namespace Township.Microservice.Features.Township
{
    public class DA_Township
    {
        #region Initializations

        private readonly AppDbContext _appDbContext;

        public DA_Township(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #endregion

        #region Get Township List Async

        public async Task<Result<TownshipListResponseModel>> GetTownshipListAsync()
        {
            Result<TownshipListResponseModel> responseModel;
            try
            {
                var townships = await _appDbContext
                    .TblTownships.AsNoTracking()
                    .OrderByDescending(x => x.TownshipId)
                    .ToListAsync();

                var lst = townships.Select(x => x.Change()).ToList();
                var model = new TownshipListResponseModel { DataLst = lst };

                responseModel = Result<TownshipListResponseModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                responseModel = Result<TownshipListResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        #endregion

        #region Create Township List Async

        public async Task<Result<TownshipResponseModel>> CreateTownshipListAsync()
        {
            Result<TownshipResponseModel> responseModel;
            try
            {
                string jsonStr = await File.ReadAllTextAsync("Data/TownshipList.json");
                List<TblTownship> lst = JsonConvert.DeserializeObject<
                    List<TblTownship>
                >(jsonStr)!;
                await _appDbContext.TblTownships.AddRangeAsync(lst);
                int result = await _appDbContext.SaveChangesAsync();

                responseModel = Result<TownshipResponseModel>.ExecuteResult(result);
            }
            catch (Exception ex)
            {
                responseModel = Result<TownshipResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        #endregion
    }
}
