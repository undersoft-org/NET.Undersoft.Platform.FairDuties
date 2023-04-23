using RadicalR;

namespace Undersoft.ODP.Api
{
    public class AttributeValidator : DtoCommandSetValidator<Property>
    {
        public AttributeValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.Value);
                ValidateRequired(p => p.Data.Key);
            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.Value);
                ValidateRequired(p => p.Data.Key);
                ValidateExist<IEntryStore, Domain.Property>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Property>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
