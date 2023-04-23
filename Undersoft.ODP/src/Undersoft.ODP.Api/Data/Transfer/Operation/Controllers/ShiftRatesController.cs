using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/shiftRates")]
    public class ShiftRatesController : DtoCommandController<long, IEntryStore, Estimate, Api.Estimate>
    {
        public ShiftRatesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/shiftRates")]
    public class ShiftRatesController : DtoQueryController<long, IReportStore, Estimate, Api.Estimate>
    {
        public ShiftRatesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}