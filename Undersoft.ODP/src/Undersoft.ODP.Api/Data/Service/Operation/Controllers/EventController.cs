using Microsoft.AspNetCore.Authorization;
using UltimatR;

namespace Undersoft.ODP.Api.Data.Service.Operation.Controllers.Events
{

    [AllowAnonymous]
    public class EventController : DsoEventController<long, IEventStore, Event>
    {
        public EventController(IUltimatr ultimatr) : base(ultimatr) { }
    }
}