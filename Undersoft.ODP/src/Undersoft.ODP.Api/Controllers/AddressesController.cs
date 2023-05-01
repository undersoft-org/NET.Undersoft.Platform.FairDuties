using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using RadicalR.Server;
using RadicalR;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenDataStore)]
    public class AddressController : OpenDataController<long, IEntryStore, IReportStore, Address, Api.Address>
    {
        public AddressController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class AddressesController : CrudDataController<long, IEntryStore, IReportStore, Address, Api.Address>
    {
        public AddressesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class AddressStreamController : StreamDataController<long, IEntryStore, IReportStore, Address, Api.Address>, IStreamDataController<Api.Address>
    {
        public AddressStreamController() : base() { }
    }
}