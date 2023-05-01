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
    public class PropertyController : OpenDataController<long, IEntryStore, IReportStore, Property, Api.Property>
    {
        public PropertyController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class PropertiesController : CrudDataController<long, IEntryStore, IReportStore, Property, Api.Property>
    {
        public PropertiesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class PropertyStreamController : StreamDataController<long, IEntryStore, IReportStore, Property, Api.Property>, IStreamDataController<Api.Property>
    {
        public PropertyStreamController() : base() { }
    }
}