using RadicalR;

namespace Undersoft.ODP.Api
{
    public class ShiftValidator : CommandSetValidator<Duty>
    {
        public ShiftValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.Duty>((cmd) =>
                (e) => (e.StartTime == cmd.StartTime || e.EndTime == cmd.EndTime)
                && e.Id == cmd.Id, "same shift type already exists in this time frame");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.GroupId);
                ValidateRequired(p => p.Data.Id);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Duty>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
