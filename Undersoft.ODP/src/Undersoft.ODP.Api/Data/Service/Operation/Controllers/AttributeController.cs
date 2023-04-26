using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Entries
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.DataStore)]
    public class AttributeController : DsoController<long, ICqrsStore, Domain.Property>
    {
        public AttributeController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Reports
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.ReportStore)]
    public class AttributeController : DsoController<long, ICqrsStore, Domain.Property>
    {
        public AttributeController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}