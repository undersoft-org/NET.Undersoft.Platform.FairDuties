using Microsoft.EntityFrameworkCore;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Contexts
{
    public class EntryDb : EntityDb<IEntryStore, EntryDb>
    {
        public EntryDb(DbContextOptions<EntryDb> options) : base(options) { }
    }
}
