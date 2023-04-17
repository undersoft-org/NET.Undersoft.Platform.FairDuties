using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Entries
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.EntryStore)]
    public class CountryLanguageController : DsoController<long, IEntryStore, CountryLanguage>
    {
        public CountryLanguageController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Reports
{
    using Domain;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.ReportStore)]
    public class CountryLanguageController : DsoController<long, IReportStore, CountryLanguage>
    {
        public CountryLanguageController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}