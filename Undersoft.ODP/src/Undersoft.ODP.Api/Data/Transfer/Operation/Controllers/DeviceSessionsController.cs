using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator")]
    [Route("/deviceSessions")]
    public class DeviceSessionsController : DtoCommandController<long, IEntryStore, DeviceSession, Api.DeviceSession>
    {
        public DeviceSessionsController(IRadicalr uservice) : base(uservice)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize(Roles = "Administrator")]
    [Route("/deviceSessions")]
    public class DeviceSessionsController : DtoQueryController<long, IReportStore, DeviceSession, Api.DeviceSession>
    {
        public DeviceSessionsController(IRadicalr uservice) : base(uservice)
        {
        }
    }
}