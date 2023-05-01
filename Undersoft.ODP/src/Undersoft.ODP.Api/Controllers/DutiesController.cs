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
    public class DutyController : OpenDataController<long, IEntryStore, IReportStore, Duty, Api.Duty>
    {
        public DutyController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class DutiesController : CrudDataController<long, IEntryStore, IReportStore, Duty, Api.Duty>
    {
        public DutiesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class DutyStreamController : StreamDataController<long, IEntryStore, IReportStore, Duty, Api.Duty>, IStreamDataController<Api.Duty>
    {
        public DutyStreamController() : base() { }
    }
}