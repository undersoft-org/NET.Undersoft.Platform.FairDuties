using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class UserRoleValidator : DtoCommandSetValidator<UserRoleDto>
    {
        public UserRoleValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, UserRole>((cmd) =>
                (e) => e.Name == cmd.Name, "same Name");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(3, 100, a => a.Data.Name);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, UserRole>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
