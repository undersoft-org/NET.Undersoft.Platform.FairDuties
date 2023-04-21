using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize]
    [Route("/addresses")]
    public class AddressesController : DtoCommandController<long, IEntryStore, Address, Api.Address>
    {
        public AddressesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/addresses")]
    public class AddressesController : DtoQueryController<long, IReportStore, Address, Api.Address>
    {
        public AddressesController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}