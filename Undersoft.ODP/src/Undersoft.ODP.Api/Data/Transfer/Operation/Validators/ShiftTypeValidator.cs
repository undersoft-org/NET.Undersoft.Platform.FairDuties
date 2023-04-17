using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class ShiftTypeValidator : DtoCommandSetValidator<ShiftTypeDto>
    {
        public ShiftTypeValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, ShiftType>((cmd) =>
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
                ValidateExist<IEntryStore, ShiftType>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
