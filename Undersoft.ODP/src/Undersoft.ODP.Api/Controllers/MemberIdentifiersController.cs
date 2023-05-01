using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR.Server;
using RadicalR;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Domain;
    using Microsoft.AspNetCore.OData.Routing.Attributes;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenDataStore)]
    public class MemberIdentifierController : OpenDataController<long, IEntryStore, IReportStore, Identifier<Member>, IdentifierDto<Api.Member>>
    {
        public MemberIdentifierController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class MemberIdentifiersController : CrudDataController<long, IEntryStore, IReportStore, Identifier<Member>, IdentifierDto<Api.Member>>
    {
        public MemberIdentifiersController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class MemberIdentifierStreamController : StreamDataController<long, IEntryStore, IReportStore, Identifier<Member>, IdentifierDto<Api.Member>>, IStreamDataController<IdentifierDto<Api.Member>>
    {
        public MemberIdentifierStreamController() : base() { }
    }
}