using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using RadicalR;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenDataStore)]
    public class MemberController : OpenDataService<long, IEntryStore, IReportStore, Member, Api.Member>
    {
        public MemberController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Grpc.Data.Service.Controllers
{
    using Domain;

    public class MemberStreamController : StreamDataService<long, IEntryStore, IReportStore, Member, BasicMember>
    {
        public MemberStreamController() : base() { }
    }
}

namespace Undersoft.ODP.Api.Rest.Data.Service.Controllers
{
    using Domain;

    public class MembersController : CrudDataService<long, IEntryStore, IReportStore, Member, Api.Member>
    {
        public MembersController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

//namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
//{
//    using Domain;

//    [Authorize(Roles = "Administrator, Leader, Manager")]
//    [Route("/users")]
//    public class UsersController : DtoCommandController<long, IEntryStore, User, UserDto>
//    {
//        public UsersController(IUltimatr ultimatr) : base(ultimatr)
//        {
//        }
//    }
//}

//namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
//{
//    using Domain;

//    [Authorize]
//    [Route("/users")]
//    public class UsersController : DtoQueryController<long, IReportStore, User, UserDto>
//    {
//        public UsersController(IUltimatr ultimatr) : base(ultimatr)
//        {
//        }
//    }
//}