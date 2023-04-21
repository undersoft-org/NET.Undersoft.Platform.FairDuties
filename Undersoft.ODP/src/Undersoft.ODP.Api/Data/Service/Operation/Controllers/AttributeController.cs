using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Entries
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.CqrsStore)]
    public class AttributeController : DsoController<long, ICqrsStore, Domain.Attribute>
    {
        public AttributeController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Reports
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.ReportStore)]
    public class AttributeController : DsoController<long, ICqrsStore, Domain.Attribute>
    {
        public AttributeController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}