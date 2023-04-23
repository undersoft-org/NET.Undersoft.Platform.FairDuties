using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/countryLanguages")]
    public class
        CountryLanguagesController : DtoCommandController<long, IEntryStore, Language, Api.Language>
    {
        public CountryLanguagesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/countryLanguages")]
    public class CountryLanguagesController : DtoQueryController<long, IReportStore, Language, Api.Language>
    {
        public CountryLanguagesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}