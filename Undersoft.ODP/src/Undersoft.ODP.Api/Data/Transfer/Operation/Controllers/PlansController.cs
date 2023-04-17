using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/plans")]
    public class PlansController : DtoCommandController<long, IEntryStore, Plan, PlanDto>
    {
        public PlansController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/plans")]
    public class PlansController : DtoQueryController<long, IReportStore, Plan, PlanDto>
    {
        public PlansController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}