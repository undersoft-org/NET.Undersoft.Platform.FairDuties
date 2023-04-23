using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Manager")]
    [Route("/organizations")]
    public class OrganizationsController : DtoCommandController<long, IEntryStore, Union, Api.Union>
    {
        public OrganizationsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/organizations")]
    public class OrganizationsController : DtoQueryController<long, IReportStore, Union, Api.Union>
    {
        public OrganizationsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}