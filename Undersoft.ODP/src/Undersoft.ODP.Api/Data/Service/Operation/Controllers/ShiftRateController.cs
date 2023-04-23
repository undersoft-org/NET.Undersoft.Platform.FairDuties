using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Entries
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.EntryStore)]
    public class ShiftRateController : DsoController<long, IEntryStore, Estimate>
    {
        public ShiftRateController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Reports
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.ReportStore)]
    public class ShiftRateController : DsoController<long, IReportStore, Estimate>
    {
        public ShiftRateController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}