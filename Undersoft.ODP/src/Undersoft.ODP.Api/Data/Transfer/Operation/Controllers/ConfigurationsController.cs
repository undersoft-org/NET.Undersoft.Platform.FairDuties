using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/configurations")]
    public class ConfigurationsController : DtoCommandController<long, IEntryStore, Configuration, ConfigurationDto>
    {
        public ConfigurationsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/configurations")]
    public class ConfigurationsController : DtoQueryController<long, IReportStore, Configuration, ConfigurationDto>
    {
        public ConfigurationsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}