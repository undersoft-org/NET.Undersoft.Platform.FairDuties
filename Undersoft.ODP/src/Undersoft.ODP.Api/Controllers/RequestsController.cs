using Microsoft.AspNetCore.Authorization;
using RadicalR.Server;
using RadicalR;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;
    using Microsoft.AspNetCore.OData.Routing.Attributes;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenDataStore)]
    public class RequestController : OpenDataController<long, IEntryStore, IReportStore, Request, Api.Request>
    {
        public RequestController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class RequestsController : CrudDataController<long, IEntryStore, IReportStore, Request, Api.Request>
    {
        public RequestsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class RequestStreamController : StreamDataController<long, IEntryStore, IReportStore, Request, Api.Request>, IStreamDataController<Api.Request>
    {
        public RequestStreamController() : base() { }
    }
}