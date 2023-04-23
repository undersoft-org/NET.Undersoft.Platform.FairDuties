using RadicalR;

namespace Undersoft.ODP.Api
{
    public class BasicUserValidator : DtoCommandSetValidator<BasicUser>
    {
        public BasicUserValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Any, () => ValidateEmail(p => p.Data.Email));

            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.UserName);
                ValidateLength(3, 100, a => a.Data.UserName);
            });
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.Member>((cmd) =>
                (e) => e.Email == cmd.Email
                || e.UserName == cmd.UserName
                || e.PhoneNumber == cmd.PhoneNumber, "same Name, Email or PhoneNumber");
            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.UserName);
                ValidateLength(3, 100, a => a.Data.UserName);
                ValidateExist<IEntryStore, Domain.Member>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Member>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
