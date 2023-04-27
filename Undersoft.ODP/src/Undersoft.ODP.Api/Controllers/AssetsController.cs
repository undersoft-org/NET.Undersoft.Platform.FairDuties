using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Entries
{
    using Domain;

    [Authorize(Roles = "Administrator, Leader, Manager")]
    [Route("/shiftTypes")]
    public class AssetsController : DtoCommandController<long, IEntryStore, Asset, Api.Asset>
    {
        public AssetsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Reports
{
    using Domain;

    [Authorize]
    [Route("/shiftTypes")]
    public class ShiftTypesController : DtoQueryController<long, IReportStore, Asset, Api.Asset>
    {
        public ShiftTypesController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}