using RadicalR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class PersonalValidator : DtoCommandSetValidator<Personal>
    {
        public PersonalValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.FirstName);
                ValidateRequired(p => p.Data.LastName);
            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.FirstName);
                ValidateRequired(p => p.Data.LastName);
                ValidateExist<IEntryStore, Domain.Personal>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.Personal>((cmd) =>
                (e) => e.Email == cmd.Email
                || e.PhoneNumber == cmd.PhoneNumber, "same Email or PhoneNumber");
            });
            ValidationScope(CommandMode.Any, () => ValidateEmail(p => p.Data.Email));
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Personal>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
