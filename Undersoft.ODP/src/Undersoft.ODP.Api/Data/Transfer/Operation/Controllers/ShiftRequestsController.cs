using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/shiftRequests")]
    public class ShiftRequestsController : DtoCommandController<long, IEntryStore, ShiftRequest, ShiftRequestDto>
    {
        public ShiftRequestsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/shiftRequests")]
    public class ShiftRequestsController : DtoQueryController<long, IReportStore, ShiftRequest, ShiftRequestDto>
    {
        public ShiftRequestsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}