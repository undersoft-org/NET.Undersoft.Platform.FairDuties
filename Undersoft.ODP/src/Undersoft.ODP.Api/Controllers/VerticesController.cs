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
    public class VertexController : OpenDataController<long, IEntryStore, IReportStore, Vertex, Api.Vertex>
    {
        public VertexController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class VerticesController : CrudDataController<long, IEntryStore, IReportStore, Vertex, Api.Vertex>
    {
        public VerticesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class VertexStreamController : StreamDataController<long, IEntryStore, IReportStore, Vertex, Api.Vertex>, IStreamDataController<Api.Vertex>
    {
        public VertexStreamController() : base() { }
    }
}