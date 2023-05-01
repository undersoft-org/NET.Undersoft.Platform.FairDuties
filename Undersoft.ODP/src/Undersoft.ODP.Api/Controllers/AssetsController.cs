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
    public class AssetController : OpenDataController<long, IEntryStore, IReportStore, Asset, Api.Asset>
    {
        public AssetController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class AssetsController : CrudDataController<long, IEntryStore, IReportStore, Asset, Api.Asset>
    {
        public AssetsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class AssetStreamController : StreamDataController<long, IEntryStore, IReportStore, Asset, Api.Asset>, IStreamDataController<Api.Asset>
    {
        public AssetStreamController() : base() { }
    }
}