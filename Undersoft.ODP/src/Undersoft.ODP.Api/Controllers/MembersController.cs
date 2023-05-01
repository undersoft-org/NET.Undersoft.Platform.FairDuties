using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using RadicalR.Server;
using RadicalR;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenDataStore)]
    public class MemberController : OpenDataController<long, IEntryStore, IReportStore, Member, Api.Member>
    {
        public MemberController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class MembersController : CrudDataController<long, IEntryStore, IReportStore, Member, Api.Member>
    {
        public MembersController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}


namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class MemberStreamController : StreamDataController<long, IEntryStore, IReportStore, Member, Api.Member>, IStreamDataController<Api.Member>
    {
        public MemberStreamController() : base() { }
    }
}