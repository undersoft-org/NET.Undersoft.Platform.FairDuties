using RadicalR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class DeviceSessionValidator : DtoCommandSetValidator<Session>
    {
        public DeviceSessionValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.DeviceId);

            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.DeviceId);
                ValidateExist<IEntryStore, Domain.Session>((cmd) => (e) => e.Id == cmd.Id);
            });

            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Session>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
