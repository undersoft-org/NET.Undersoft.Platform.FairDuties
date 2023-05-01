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
    public class LanguageController : OpenDataController<long, IEntryStore, IReportStore, Language, Api.Language>
    {
        public LanguageController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    using Domain;

    public class LanguagesController : CrudDataController<long, IEntryStore, IReportStore, Language, Api.Language>
    {
        public LanguagesController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    using Domain;

    public class LanguageStreamController : StreamDataController<long, IEntryStore, IReportStore, Language, Api.Language>, IStreamDataController<Api.Language>
    {
        public LanguageStreamController() : base() { }
    }
}