using Microsoft.AspNetCore.Authorization;
using RadicalR;

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Events
{

    [AllowAnonymous]
    public class EventController : DsoEventController<long, IEventStore, Event>
    {
        public EventController(IRadicalr ultimatr) : base(ultimatr) { }
    }
}