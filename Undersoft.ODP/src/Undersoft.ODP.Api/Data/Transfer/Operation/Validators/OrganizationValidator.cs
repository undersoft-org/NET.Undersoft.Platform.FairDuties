using RadicalR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class OrganizationValidator : DtoCommandSetValidator<Organization>
    {
        public OrganizationValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(2, 100, a => a.Data.Name);

            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(2, 100, a => a.Data.Name);
                ValidateExist<IEntryStore, Domain.Organization>((cmd) => (e) => e.Id == cmd.Id);
            });
           
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Organization>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
