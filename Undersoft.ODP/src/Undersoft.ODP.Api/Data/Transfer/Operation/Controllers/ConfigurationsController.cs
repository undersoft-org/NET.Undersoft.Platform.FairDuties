using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/configurations")]
    public class ConfigurationsController : DtoCommandController<long, IEntryStore, Configuration, Api.Configuration>
    {
        public ConfigurationsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/configurations")]
    public class ConfigurationsController : DtoQueryController<long, IReportStore, Configuration, Api.Configuration>
    {
        public ConfigurationsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}