using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/teams")]
    public class TeamsController : DtoCommandController<long, IEntryStore, Team, TeamDto>
    {
        public TeamsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/teams")]
    public class TeamsController : DtoQueryController<long, IReportStore, Team, TeamDto>
    {
        public TeamsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}