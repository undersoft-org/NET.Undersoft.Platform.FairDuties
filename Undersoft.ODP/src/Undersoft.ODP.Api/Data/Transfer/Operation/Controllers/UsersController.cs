using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/users")]
    public class UsersController : DtoCommandController<long, IEntryStore, User, UserDto>
    {
        public UsersController(IUltimatr ultimatr) : base(ultimatr)
        {
        }


    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/users")]
    public class UsersController : DtoQueryController<long, IReportStore, User, UserDto>
    {
        public UsersController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}