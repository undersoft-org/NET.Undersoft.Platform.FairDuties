using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/userIdentifiers")]
    public class
        UserIdentifiersController : DtoCommandController<long, IEntryStore, Identifier<User>, IdentifierDto<Api.User>>
    {
        public UserIdentifiersController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/userIdentifiers")]
    public class
        UserIdentifiersController : DtoQueryController<long, IReportStore, Identifier<User>, IdentifierDto<Api.User>>
    {
        public UserIdentifiersController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}