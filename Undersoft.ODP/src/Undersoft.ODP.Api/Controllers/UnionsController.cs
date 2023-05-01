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
    public class UnionController : OpenDataController<long, IEntryStore, IReportStore, Union, Api.Union>
    {
        public UnionController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class UnionsController : CrudDataController<long, IEntryStore, IReportStore, Union, Api.Union>
    {
        public UnionsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class UnionStreamController : StreamDataController<long, IEntryStore, IReportStore, Union, Api.Union>, IStreamDataController<Api.Union>
    {
        public UnionStreamController() : base() { }
    }
}