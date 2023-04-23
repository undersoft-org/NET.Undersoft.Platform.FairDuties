using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/plans")]
    public class PlansController : DtoCommandController<long, IEntryStore, Vertex, Api.Vertex>
    {
        public PlansController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/plans")]
    public class PlansController : DtoQueryController<long, IReportStore, Vertex, Api.Vertex>
    {
        public PlansController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}