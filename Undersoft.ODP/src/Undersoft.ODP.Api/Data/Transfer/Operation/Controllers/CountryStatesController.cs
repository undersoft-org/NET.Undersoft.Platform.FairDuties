using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/countryStates")]
    public class CountryStatesController : DtoCommandController<long, IEntryStore, CountryState, CountryStateDto>
    {
        public CountryStatesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/countryStates")]
    public class CountryStatesController : DtoQueryController<long, IReportStore, CountryState, CountryStateDto>
    {
        public CountryStatesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}