using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/schedules")]
    public class SchedulesController : DtoCommandController<long, IEntryStore, Schedule, Api.Schedule>
    {
        public SchedulesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/schedules")]
    public class SchedulesController : DtoQueryController<long, IReportStore, Schedule, Api.Schedule>
    {
        public SchedulesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}