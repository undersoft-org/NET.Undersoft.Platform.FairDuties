using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/organizations")]
    public class OrganizationsController : DtoCommandController<long, IEntryStore, Organization, OrganizationDto>
    {
        public OrganizationsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/organizations")]
    public class OrganizationsController : DtoQueryController<long, IReportStore, Organization, OrganizationDto>
    {
        public OrganizationsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}