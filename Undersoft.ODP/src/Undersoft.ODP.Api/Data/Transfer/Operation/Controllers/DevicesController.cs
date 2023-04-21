using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator")]
    [Route("/devices")]
    public class DevicesController : DtoCommandController<long, IEntryStore, Device, Api.Device>
    {
        public DevicesController(IUltimatr uservice) : base(uservice)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize(Roles = "Administrator")]
    [Route("/devices")]
    public class DevicesController : DtoQueryController<long, IReportStore, Device, Api.Device>
    {
        public DevicesController(IUltimatr uservice) : base(uservice)
        {
        }
    }
}