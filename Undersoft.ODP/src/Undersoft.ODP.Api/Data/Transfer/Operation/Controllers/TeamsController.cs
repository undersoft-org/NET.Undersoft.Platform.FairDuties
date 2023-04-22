using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    //[Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/teams")]
    public class TeamsController : DtoCommandController<long, IEntryStore, Team, Api.Team>
    {
        public TeamsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    //[Authorize]
    [Route("/teams")]
    public class TeamsController : DtoQueryController<long, IReportStore, Team, Api.Team>
    {
        public TeamsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}