using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/userRoles")]
    public class UserRolesController : DtoCommandController<long, IEntryStore, UserRole, UserRoleDto>
    {
        public UserRolesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/userRoles")]
    public class UserRolesController : DtoQueryController<long, IReportStore, UserRole, UserRoleDto>
    {
        public UserRolesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}