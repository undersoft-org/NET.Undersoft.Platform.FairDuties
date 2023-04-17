using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator")]
    [Route("/deviceSessions")]
    public class DeviceSessionsController : DtoCommandController<long, IEntryStore, DeviceSession, DeviceSessionDto>
    {
        public DeviceSessionsController(IUltimatr uservice) : base(uservice)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize(Roles = "Administrator")]
    [Route("/deviceSessions")]
    public class DeviceSessionsController : DtoQueryController<long, IReportStore, DeviceSession, DeviceSessionDto>
    {
        public DeviceSessionsController(IUltimatr uservice) : base(uservice)
        {
        }
    }
}