using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/shifts")]
    public class DutiesController : DtoCommandController<long, IEntryStore, Duty, Api.Duty>
    {
        public DutiesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/shifts")]
    public class ShiftsController : DtoQueryController<long, IReportStore, Duty, Api.Duty>
    {
        public ShiftsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}