using Microsoft.AspNetCore.Authorization;
using RadicalR;
using RadicalR.Server;

namespace Undersoft.ODP.Api.Open.Data.Service.Controllers
{
    using Microsoft.AspNetCore.OData.Routing.Attributes;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.Constant.OpenEventStore)]
    public class EventController : OpenEventController<long, IEventStore, Event, EventDto>
    {
        public EventController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Crud.Data.Service.Controllers
{
    public class EventsController : CrudEventController<long, IEventStore, Event, EventDto>
    {
        public EventsController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.ODP.Api.Stream.Data.Service.Controllers
{
    public class StreamEventController : StreamEventController<long, IEventStore, Event, EventDto>, IStreamEventController<EventDto>
    {
        public StreamEventController() : base() { }
    }
}