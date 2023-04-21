using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/countryLanguages")]
    public class
        CountryLanguagesController : DtoCommandController<long, IEntryStore, CountryLanguage, Api.CountryLanguage>
    {
        public CountryLanguagesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/countryLanguages")]
    public class CountryLanguagesController : DtoQueryController<long, IReportStore, CountryLanguage, Api.CountryLanguage>
    {
        public CountryLanguagesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}