using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR.Server;
using RadicalR;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;
    using Microsoft.AspNetCore.OData.Routing.Attributes;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenDataStore)]
    public class RoleController : OpenDataController<long, IEntryStore, IReportStore, Role, Api.Role>
    {
        public RoleController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class RolesController : CrudDataController<long, IEntryStore, IReportStore, Role, Api.Role>
    {
        public RolesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class RoleStreamController : StreamDataController<long, IEntryStore, IReportStore, Role, Api.Role>, IStreamDataController<Api.Role>
    {
        public RoleStreamController() : base() { }
    }
}