using RadicalR;

namespace Undersoft.ODP.Api
{
    public class ScheduleValidator : DtoCommandSetValidator<Vector>
    {
        public ScheduleValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateRequired(p => p.Data.GroupId);
                ValidateLength(3, 100, a => a.Data.Name);
            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateRequired(p => p.Data.GroupId);
                ValidateLength(3, 100, a => a.Data.Name);
                ValidateExist<IEntryStore, Domain.Vector>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Vector>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
