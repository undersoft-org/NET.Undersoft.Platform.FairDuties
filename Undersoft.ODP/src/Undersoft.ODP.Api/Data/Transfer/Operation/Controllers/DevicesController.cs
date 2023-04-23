using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator")]
    [Route("/devices")]
    public class DevicesController : DtoCommandController<long, IEntryStore, Client, Api.Client>
    {
        public DevicesController(IRadicalr uservice) : base(uservice)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize(Roles = "Administrator")]
    [Route("/devices")]
    public class DevicesController : DtoQueryController<long, IReportStore, Client, Api.Client>
    {
        public DevicesController(IRadicalr uservice) : base(uservice)
        {
        }
    }
}