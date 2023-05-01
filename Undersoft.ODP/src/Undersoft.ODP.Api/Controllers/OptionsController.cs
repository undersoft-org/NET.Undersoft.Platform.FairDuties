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
    public class OptionController : OpenDataController<long, IEntryStore, IReportStore, Option, Api.Option>
    {
        public OptionController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class OptionsController : CrudDataController<long, IEntryStore, IReportStore, Option, Api.Option>
    {
        public OptionsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class OptionStreamController : StreamDataController<long, IEntryStore, IReportStore, Option, Api.Option>, IStreamDataController<Api.Option>
    {
        public OptionStreamController() : base() { }
    }
}