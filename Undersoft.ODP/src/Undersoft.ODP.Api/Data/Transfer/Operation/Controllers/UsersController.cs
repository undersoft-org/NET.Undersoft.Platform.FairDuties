using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using RadicalR;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenCqrsStore)]
    public class UserController : OpenDataServiceController<long, IEntryStore, IReportStore, Member, Api.Member>
    {
        public UserController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Grpc.Data.Service.Controllers
{
    using Domain;

    public class UserStreamController : GrpcDataServiceController<long, IEntryStore, IReportStore, Member, BasicUser>
    {
        public UserStreamController() : base() { }
    }
}

namespace Undersoft.ODP.Api.Rest.Data.Service.Controllers
{
    using Domain;

    [ApiController]
    [Route($"{StoreRoutes.Constant.RestCqrsStore}/[controller]")]
    public class UsersController : RestDataServiceController<long, IEntryStore, IReportStore, Member, Api.Member>
    {
        public UsersController(IRadicalr ultimatr) : base(ultimatr) { }
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