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
    public class CountryStateController : OpenDataController<long, IEntryStore, IReportStore, CountryState, Api.CountryState>
    {
        public CountryStateController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class CountryStatesController : CrudDataController<long, IEntryStore, IReportStore, CountryState, Api.CountryState>
    {
        public CountryStatesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class CountryStateStreamController : StreamDataController<long, IEntryStore, IReportStore, CountryState, Api.CountryState>, IStreamDataController<Api.CountryState>
    {
        public CountryStateStreamController() : base() { }
    }
}