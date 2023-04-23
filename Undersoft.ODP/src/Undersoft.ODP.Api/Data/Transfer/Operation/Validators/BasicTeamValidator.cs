using RadicalR;

namespace Undersoft.ODP.Api
{
    public class BasicTeamValidator : DtoCommandSetValidator<BasicGroup>
    {
        public BasicTeamValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateRequired(p => p.Data.LeadershipId);
                ValidateLength(3, 80, a => a.Data.Name);
                ValidateLength(1, 50, a => a.Data.ShortName);
            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateRequired(p => p.Data.LeadershipId);
                ValidateLength(3, 80, a => a.Data.Name);
                ValidateLength(1, 50, a => a.Data.ShortName);
                ValidateExist<IEntryStore, Domain.Group>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Group>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
