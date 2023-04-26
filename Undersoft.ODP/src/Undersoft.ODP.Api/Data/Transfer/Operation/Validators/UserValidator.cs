using RadicalR;

namespace Undersoft.ODP.Api
{   
    public class UserValidator : CommandSetValidatorBase<Member>
    {
        public UserValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Any, () => ValidateEmail(p => p.Data.Email));

            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.Member>((cmd) =>
                (e) => e.Email == cmd.Email
                || e.Name == cmd.Name
                || e.PhoneNumber == cmd.PhoneNumber, "same Name, Email or PhoneNumber");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(3, 100, a => a.Data.Name);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Member>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}