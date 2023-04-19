using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Events
{
    [Authorize(Roles = "Administrator")]
    [Route("/events")]
    public class EventsController : RestDataEventController<long, IEventStore, Event, EventDto>
    {
        public EventsController(IUltimatr ultimatr) : base(ultimatr)
        {
        }
    }
}