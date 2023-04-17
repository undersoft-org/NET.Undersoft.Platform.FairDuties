using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/shiftRates")]
    public class ShiftRatesController : DtoCommandController<long, IEntryStore, ShiftRate, ShiftRateDto>
    {
        public ShiftRatesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/shiftRates")]
    public class ShiftRatesController : DtoQueryController<long, IReportStore, ShiftRate, ShiftRateDto>
    {
        public ShiftRatesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}