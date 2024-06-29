using System;
using System.Collections.Generic;

namespace Microservices.DotNet8MiniBankingManagementSystem.DbService.AppDbContexts;

public partial class TblState
{
    public long StateId { get; set; }

    public string StateCode { get; set; } = null!;

    public string StateName { get; set; } = null!;
}
