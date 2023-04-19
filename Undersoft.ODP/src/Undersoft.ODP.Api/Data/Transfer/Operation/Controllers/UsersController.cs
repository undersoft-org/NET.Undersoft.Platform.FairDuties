using UltimatR;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;

    public class UserController : OpenDataServiceController<long, IEntryStore, IReportStore, User, UserDto>
    {
        public UserController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Grpc.Data.Service.Controllers
{
    using Domain;

    public class UserController : GrpcDataServiceController<long, IEntryStore, IReportStore, User, UserDto>
    {
        public UserController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Rest.Data.Service.Controllers
{
    using Domain;


    public class UsersController : RestDataServiceController<long, IEntryStore, IReportStore, User, UserDto>
    {
        public UsersController(IUltimatr ultimatr) : base(ultimatr) { }
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