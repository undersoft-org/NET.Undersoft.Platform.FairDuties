using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/attributes")]
    public class AttributesController : DtoCommandController<long, IEntryStore, Attribute, AttributeDto>
    {
        public AttributesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/attributes")]
    public class AttributesController : DtoQueryController<long, IReportStore, Attribute, AttributeDto>
    {
        public AttributesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}