using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/userIdentifiers")]
    public class
        MemberIdentifiersController : DtoCommandController<long, IEntryStore, Identifier<Member>, IdentifierDto<Api.Member>>
    {
        public MemberIdentifiersController(IRadicalr ultimatr) : base(ultimatr)
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
        UserIdentifiersController : DtoQueryController<long, IReportStore, Identifier<Member>, IdentifierDto<Api.Member>>
    {
        public UserIdentifiersController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}