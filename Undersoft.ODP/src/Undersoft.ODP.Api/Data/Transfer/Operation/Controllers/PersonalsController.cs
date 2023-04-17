using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/personals")]
    public class PersonalsController : DtoCommandController<long, IEntryStore, Personal, PersonalDto>
    {
        public PersonalsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/personals")]
    public class PersonalsController : DtoQueryController<long, IReportStore, Personal, PersonalDto>
    {
        public PersonalsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}