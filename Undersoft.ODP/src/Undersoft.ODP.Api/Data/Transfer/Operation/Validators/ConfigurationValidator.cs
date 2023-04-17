using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class ConfigurationValidator : DtoCommandSetValidator<ConfigurationDto>
    {
        public ConfigurationValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Configuration>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}