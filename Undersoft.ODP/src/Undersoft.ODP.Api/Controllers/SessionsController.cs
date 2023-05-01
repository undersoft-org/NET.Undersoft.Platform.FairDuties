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
    public class SessionController : OpenDataController<long, IEntryStore, IReportStore, Session, Api.Session>
    {
        public SessionController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class SessionsController : CrudDataController<long, IEntryStore, IReportStore, Session, Api.Session>
    {
        public SessionsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class SessionStreamController : StreamDataController<long, IEntryStore, IReportStore, Session, Api.Session>, IStreamDataController<Api.Session>
    {
        public SessionStreamController() : base() { }
    }
}