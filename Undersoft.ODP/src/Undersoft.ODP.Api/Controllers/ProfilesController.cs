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
    public class ProfileController : OpenDataController<long, IEntryStore, IReportStore, Profile, Api.Profile>
    {
        public ProfileController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class ProfilesController : CrudDataController<long, IEntryStore, IReportStore, Profile, Api.Profile>
    {
        public ProfilesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class ProfileStreamController : StreamDataController<long, IEntryStore, IReportStore, Profile, Api.Profile>, IStreamDataController<Api.Profile>
    {
        public ProfileStreamController() : base() { }
    }
}