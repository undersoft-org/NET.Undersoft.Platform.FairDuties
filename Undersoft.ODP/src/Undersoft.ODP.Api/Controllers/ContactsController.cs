using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/contacts")]
    public class ContactsController : DtoCommandController<long, IEntryStore, Contact, Api.Locale>
    {
        public ContactsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/contacts")]
    public class ContactsController : DtoQueryController<long, IReportStore, Contact, Api.Locale>
    {
        public ContactsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}