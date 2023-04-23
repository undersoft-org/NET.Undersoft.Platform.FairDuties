using RadicalR;

namespace Undersoft.ODP.Api
{
    public class DeviceValidator : DtoCommandSetValidator<Client>
    {
        public DeviceValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(2, 100, a => a.Data.Name);
                ValidateRequired(p => p.Data.HostName);

            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(2, 100, a => a.Data.Name);
                ValidateRequired(p => p.Data.HostName);
                ValidateExist<IEntryStore, Domain.Client>((cmd) => (e) => e.Id == cmd.Id);
            });

            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Client>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
