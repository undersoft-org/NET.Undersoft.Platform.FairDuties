using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/personals")]
    public class PersonalsController : DtoCommandController<long, IEntryStore, Personal, Api.Personal>
    {
        public PersonalsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/personals")]
    public class PersonalsController : DtoQueryController<long, IReportStore, Personal, Api.Personal>
    {
        public PersonalsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}