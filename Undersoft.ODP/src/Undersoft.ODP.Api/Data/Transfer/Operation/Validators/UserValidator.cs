using RadicalR;

namespace Undersoft.ODP.Api
{
    public class UserValidator : DtoCommandSetValidator<User>
    {
        public UserValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Any, () => ValidateEmail(p => p.Data.Email));

            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.User>((cmd) =>
                (e) => e.Email == cmd.Email
                || e.UserName == cmd.UserName
                || e.PhoneNumber == cmd.PhoneNumber, "same Name, Email or PhoneNumber");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.UserName);
                ValidateLength(3, 100, a => a.Data.UserName);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.User>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}