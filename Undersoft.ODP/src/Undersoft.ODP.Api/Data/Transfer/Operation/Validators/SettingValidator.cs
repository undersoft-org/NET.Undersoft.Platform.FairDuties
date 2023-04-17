using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class SettingValidator : DtoCommandSetValidator<SettingDto>
    {
        public SettingValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Setting>((cmd) =>
                (e) => e.Name == cmd.Name, "same type name already exists");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(3, 80, a => a.Data.Name);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Change | CommandMode.Update, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Setting>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
