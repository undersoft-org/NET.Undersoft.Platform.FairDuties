using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/contacts")]
    public class ContactsController : DtoCommandController<long, IEntryStore, Contact, ContactDto>
    {
        public ContactsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/contacts")]
    public class ContactsController : DtoQueryController<long, IReportStore, Contact, ContactDto>
    {
        public ContactsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}