using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/shiftRequests")]
    public class RequestsController : DtoCommandController<long, IEntryStore, Request, Api.Request>
    {
        public RequestsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/shiftRequests")]
    public class ShiftRequestsController : DtoQueryController<long, IReportStore, Request, Api.Request>
    {
        public ShiftRequestsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}