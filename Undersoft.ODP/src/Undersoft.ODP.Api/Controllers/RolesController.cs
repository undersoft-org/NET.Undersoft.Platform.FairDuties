using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/userRoles")]
    public class RolesController : DtoCommandController<long, IEntryStore, Role, Api.Role>
    {
        public RolesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/userRoles")]
    public class UserRolesController : DtoQueryController<long, IReportStore, Role, Api.Role>
    {
        public UserRolesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}