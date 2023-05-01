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
    public class VectorController : OpenDataController<long, IEntryStore, IReportStore, Vector, Api.Vector>
    {
        public VectorController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class VectorsController : CrudDataController<long, IEntryStore, IReportStore, Vector, Api.Vector>
    {
        public VectorsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class VectorStreamController : StreamDataController<long, IEntryStore, IReportStore, Vector, Api.Vector>, IStreamDataController<Api.Vector>
    {
        public VectorStreamController() : base() { }
    }
}