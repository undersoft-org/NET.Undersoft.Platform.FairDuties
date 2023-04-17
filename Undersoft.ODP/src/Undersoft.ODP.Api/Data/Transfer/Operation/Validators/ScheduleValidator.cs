using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class ScheduleValidator : DtoCommandSetValidator<ScheduleDto>
    {
        public ScheduleValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateRequired(p => p.Data.TeamId);
                ValidateLength(3, 100, a => a.Data.Name);
            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateRequired(p => p.Data.TeamId);
                ValidateLength(3, 100, a => a.Data.Name);
                ValidateExist<IEntryStore, Schedule>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Schedule>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
