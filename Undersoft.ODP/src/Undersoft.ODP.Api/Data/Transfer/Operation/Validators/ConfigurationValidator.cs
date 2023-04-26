using RadicalR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class ConfigurationValidator : CommandSetValidatorBase<Setup>
    {
        public ConfigurationValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Setup>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}