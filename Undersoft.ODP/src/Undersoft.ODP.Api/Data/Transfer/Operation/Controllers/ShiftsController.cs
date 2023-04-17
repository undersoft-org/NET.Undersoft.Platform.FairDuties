using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/shifts")]
    public class ShiftsController : DtoCommandController<long, IEntryStore, Shift, ShiftDto>
    {
        public ShiftsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/shifts")]
    public class ShiftsController : DtoQueryController<long, IReportStore, Shift, ShiftDto>
    {
        public ShiftsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}