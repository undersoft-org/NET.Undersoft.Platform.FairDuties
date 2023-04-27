using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/currencies")]
    public class CurrenciesController : DtoCommandController<long, IEntryStore, Currency, Api.Currency>
    {
        public CurrenciesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/currencies")]
    public class CurrenciesController : DtoQueryController<long, IReportStore, Currency, Api.Currency>
    {
        public CurrenciesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}