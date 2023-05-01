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
    public class ContactController : OpenDataController<long, IEntryStore, IReportStore, Contact, Api.Contact>
    {
        public ContactController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class ContactsController : CrudDataController<long, IEntryStore, IReportStore, Contact, Api.Contact>
    {
        public ContactsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class ContactStreamController : StreamDataController<long, IEntryStore, IReportStore, Contact, Api.Contact>, IStreamDataController<Api.Contact>
    {
        public ContactStreamController() : base() { }
    }
}