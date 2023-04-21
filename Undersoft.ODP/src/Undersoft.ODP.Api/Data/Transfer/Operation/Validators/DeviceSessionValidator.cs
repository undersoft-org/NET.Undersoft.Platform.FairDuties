using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class DeviceSessionValidator : DtoCommandSetValidator<DeviceSession>
    {
        public DeviceSessionValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.DeviceId);

            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.DeviceId);
                ValidateExist<IEntryStore, Domain.DeviceSession>((cmd) => (e) => e.Id == cmd.Id);
            });

            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.DeviceSession>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
