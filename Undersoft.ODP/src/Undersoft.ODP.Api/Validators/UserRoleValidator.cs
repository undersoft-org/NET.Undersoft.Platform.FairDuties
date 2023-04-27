using RadicalR;

namespace Undersoft.ODP.Api
{
    public class UserRoleValidator : CommandSetValidator<Role>
    {
        public UserRoleValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.Role>((cmd) =>
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
                ValidateExist<IEntryStore, Domain.Role>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
