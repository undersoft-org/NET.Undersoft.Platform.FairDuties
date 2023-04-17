using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class AttributeValidator : DtoCommandSetValidator<AttributeDto>
    {
        public AttributeValidator(IUltimatr ultimatr) : base(ultimatr)
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
                ValidateExist<IEntryStore, Attribute>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Attribute>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
