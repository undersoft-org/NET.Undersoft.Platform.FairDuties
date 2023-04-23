using Microsoft.EntityFrameworkCore;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Contexts
{
    public class EventDb : EventDb<IEventStore, EventDb>
    {
        public EventDb(DbContextOptions<EventDb> options) : base(options)
        {
        }
    }
}
