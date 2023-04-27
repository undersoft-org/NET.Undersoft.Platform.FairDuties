using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/configurations")]
    public class SetupsController : DtoCommandController<long, IEntryStore, Setup, Api.Setup>
    {
        public SetupsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/configurations")]
    public class ConfigurationsController : DtoQueryController<long, IReportStore, Setup, Api.Setup>
    {
        public ConfigurationsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}