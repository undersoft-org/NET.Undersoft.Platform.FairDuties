using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class DeviceValidator : DtoCommandSetValidator<DeviceDto>
    {
        public DeviceValidator(IUltimatr ultimatr) : base(ultimatr)
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
                ValidateExist<IEntryStore, Device>((cmd) => (e) => e.Id == cmd.Id);
            });

            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Device>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
