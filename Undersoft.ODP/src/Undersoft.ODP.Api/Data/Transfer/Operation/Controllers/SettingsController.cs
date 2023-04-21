using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/settings")]
    public class SettingsController : DtoCommandController<long, IEntryStore, Setting, Api.Setting>
    {
        public SettingsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/settings")]
    public class SettingsController : DtoQueryController<long, IReportStore, Setting, Api.Setting>
    {
        public SettingsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}