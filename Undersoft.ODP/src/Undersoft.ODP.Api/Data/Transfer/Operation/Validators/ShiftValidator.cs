using UltimatR;

namespace Undersoft.ODP.Api
{
    public class ShiftValidator : DtoCommandSetValidator<Shift>
    {
        public ShiftValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.Shift>((cmd) =>
                (e) => (e.StartTime == cmd.StartTime || e.EndTime == cmd.EndTime)
                && e.ShiftTypeId == cmd.ShiftTypeId, "same shift type already exists in this time frame");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.TeamId);
                ValidateRequired(p => p.Data.ShiftTypeId);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Shift>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
