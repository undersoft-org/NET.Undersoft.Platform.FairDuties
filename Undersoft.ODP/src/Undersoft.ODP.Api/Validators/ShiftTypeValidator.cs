using RadicalR;

namespace Undersoft.ODP.Api
{
    public class ShiftTypeValidator : CommandSetValidator<Asset>
    {
        public ShiftTypeValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.Asset>((cmd) =>
                (e) => e.Name == cmd.Name, "same type name already exists");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(3, 80, a => a.Data.Name);
                ValidateLength(3, 100, a => a.Data.Description);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Change | CommandMode.Update, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Asset>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
