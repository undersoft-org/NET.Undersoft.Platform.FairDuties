using UltimatR;

namespace Undersoft.ODP.Api
{
    public class SettingValidator : DtoCommandSetValidator<Setting>
    {
        public SettingValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, (Action)(() =>
            {
                base.ValidateNotExist<IEntryStore, Domain.Setting>(((cmd) =>
                ((e) => e.Name == cmd.Name)), "same type name already exists");
            }));
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(3, 80, a => a.Data.Name);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Change | CommandMode.Update, (Action)(() =>
            {
                ValidateRequired((a => (object)a.Data.Id));
                base.ValidateExist<IEntryStore, Domain.Setting>(((cmd) => ((e) => e.Id == cmd.Id)));
            }));
        }
    }
}
