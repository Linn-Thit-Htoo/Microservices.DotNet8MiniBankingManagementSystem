﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Township.Microservice.Features.Township
{
    [Route("api/v1/township")]
    [ApiController]
    public class TownshipController : BaseController
    {
        #region Initializations

        private readonly BL_Township _bL_Township;

        public TownshipController(BL_Township bL_Township)
        {
            _bL_Township = bL_Township;
        }

        #endregion

        #region GetTownshipList

        [HttpGet]
        public async Task<IActionResult> GetTownshipList()
        {
            try
            {
                return Content(await _bL_Township.GetTownshipListAsync());
            }
            catch (Exception ex)
            {
                return HandleFailure(ex);
            }
        }

        #endregion

        #region CreateTownshipList

        [HttpPost]
        public async Task<IActionResult> CreateTownshipList()
        {
            try
            {
                var responseModel = await _bL_Township.CreateTownshipListAsync();
                return Content(responseModel);
            }
            catch (Exception ex)
            {
                return HandleFailure(ex);
            }
        }

        #endregion
    }
}