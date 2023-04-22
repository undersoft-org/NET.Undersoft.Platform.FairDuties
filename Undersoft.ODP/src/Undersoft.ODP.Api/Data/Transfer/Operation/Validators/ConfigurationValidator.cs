using RadicalR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class ConfigurationValidator : DtoCommandSetValidator<Configuration>
    {
        public ConfigurationValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Configuration>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}