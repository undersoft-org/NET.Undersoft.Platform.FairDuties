using RadicalR;

namespace Undersoft.ODP.Api
{
    public class BasicDeviceSessionValidator : CommandSetValidator<BasicSession>
    {
        public BasicDeviceSessionValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.ClientId);

            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.ClientId);
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
