using RadicalR;
using RadicalR.Server;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.OData.Routing.Attributes;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenDataStore)]
    public class GroupController : OpenDataController<long, IEntryStore, IReportStore, Group, Api.Group>
    {
        public GroupController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class GroupsController : CrudDataController<long, IEntryStore, IReportStore, Group, Api.Group>
    {
        public GroupsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class GroupStreamController : StreamDataController<long, IEntryStore, IReportStore, Group, Api.Group>, IStreamDataController<Api.Group>
    {
        public GroupStreamController() : base() { }
    }
}