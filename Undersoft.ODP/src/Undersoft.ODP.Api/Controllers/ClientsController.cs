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
    public class ClientController : OpenDataController<long, IEntryStore, IReportStore, Client, Api.Client>
    {
        public ClientController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class ClientsController : CrudDataController<long, IEntryStore, IReportStore, Client, Api.Client>
    {
        public ClientsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class ClientStreamController : StreamDataController<long, IEntryStore, IReportStore, Client, Api.Client>, IStreamDataController<Api.Client>
    {
        public ClientStreamController() : base() { }
    }
}