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
    public class EstimateController : OpenDataController<long, IEntryStore, IReportStore, Estimate, Api.Estimate>
    {
        public EstimateController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class EstimatesController : CrudDataController<long, IEntryStore, IReportStore, Estimate, Api.Estimate>
    {
        public EstimatesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class EstimateStreamController : StreamDataController<long, IEntryStore, IReportStore, Estimate, Api.Estimate>, IStreamDataController<Api.Estimate>
    {
        public EstimateStreamController() : base() { }
    }
}