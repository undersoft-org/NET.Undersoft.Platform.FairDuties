﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Entries
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.EntryStore)]
    public class CountryStateController : DsoController<long, IEntryStore, CountryState>
    {
        public CountryStateController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Reports
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.ReportStore)]
    public class CountryStateController : DsoController<long, IReportStore, CountryState>
    {
        public CountryStateController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}