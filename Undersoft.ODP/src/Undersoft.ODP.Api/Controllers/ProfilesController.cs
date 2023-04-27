using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/personals")]
    public class ProfilesController : DtoCommandController<long, IEntryStore, Profile, Api.Profile>
    {
        public ProfilesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/personals")]
    public class PersonalsController : DtoQueryController<long, IReportStore, Profile, Api.Profile>
    {
        public PersonalsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}