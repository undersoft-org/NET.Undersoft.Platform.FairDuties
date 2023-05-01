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
    public class CountryController : OpenDataController<long, IEntryStore, IReportStore, Country, Api.Country>
    {
        public CountryController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class CountriesController : CrudDataController<long, IEntryStore, IReportStore, Country, Api.Country>
    {
        public CountriesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class CountryStreamController : StreamDataController<long, IEntryStore, IReportStore, Country, Api.Country>, IStreamDataController<Api.Country>
    {
        public CountryStreamController() : base() { }
    }
}