using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/schedules")]
    public class VectorsController : DtoCommandController<long, IEntryStore, Vector, Api.Vector>
    {
        public VectorsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/schedules")]
    public class SchedulesController : DtoQueryController<long, IReportStore, Vector, Api.Vector>
    {
        public SchedulesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}