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
    public class SetupController : OpenDataController<long, IEntryStore, IReportStore, Setup, Api.Setup>
    {
        public SetupController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class SetupsController : CrudDataController<long, IEntryStore, IReportStore, Setup, Api.Setup>
    {
        public SetupsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class SetupStreamController : StreamDataController<long, IEntryStore, IReportStore, Setup, Api.Setup>, IStreamDataController<Api.Setup>
    {
        public SetupStreamController() : base() { }
    }
}