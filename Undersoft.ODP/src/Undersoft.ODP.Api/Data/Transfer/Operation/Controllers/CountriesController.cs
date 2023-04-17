using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/countries")]
    public class CountriesController : DtoCommandController<long, IEntryStore, Country, CountryDto>
    {
        public CountriesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/countries")]
    public class CountriesController : DtoQueryController<long, IReportStore, Country, CountryDto>
    {
        public CountriesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}