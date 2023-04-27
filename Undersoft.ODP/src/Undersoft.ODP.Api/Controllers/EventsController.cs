using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Transfer.Operation.Controllers.Events
{
    [Authorize(Roles = "Administrator")]
    [Route("/events")]
    public class EventsController : CrudEventController<long, IEventStore, Event, EventDto>
    {
        public EventsController(IRadicalr ultimatr) : base(ultimatr)
        {
        }
    }
}