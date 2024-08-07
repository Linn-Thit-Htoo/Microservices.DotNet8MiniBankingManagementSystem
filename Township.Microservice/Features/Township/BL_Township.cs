﻿namespace Township.Microservice.Features.Township;

public class BL_Township
{
    #region Initializations

    private readonly DA_Township _dA_Township;

    public BL_Township(DA_Township dA_Township)
    {
        _dA_Township = dA_Township;
    }

    #endregion

    #region Get Township List Async

    public async Task<Result<TownshipListResponseModel>> GetTownshipListAsync()
    {
        return await _dA_Township.GetTownshipListAsync();
    }

    #endregion

    #region Create Township List Async

    public async Task<Result<TownshipResponseModel>> CreateTownshipListAsync()
    {
        return await _dA_Township.CreateTownshipListAsync();
    }

    #endregion
}
