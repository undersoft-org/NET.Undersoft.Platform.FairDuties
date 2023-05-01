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
    public class CurrencyController : OpenDataController<long, IEntryStore, IReportStore, Currency, Api.Currency>
    {
        public CurrencyController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class CurrenciesController : CrudDataController<long, IEntryStore, IReportStore, Currency, Api.Currency>
    {
        public CurrenciesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class CurrencyStreamController : StreamDataController<long, IEntryStore, IReportStore, Currency, Api.Currency>, IStreamDataController<Api.Currency>
    {
        public CurrencyStreamController() : base() { }
    }
}