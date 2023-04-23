using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/settings")]
    public class SettingsController : DtoCommandController<long, IEntryStore, Option, Api.Option>
    {
        public SettingsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/settings")]
    public class SettingsController : DtoQueryController<long, IReportStore, Option, Api.Option>
    {
        public SettingsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}