using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class BasicTeamValidator : DtoCommandSetValidator<BasicTeam>
    {
        public BasicTeamValidator(IUltimatr ultimatr) : base(ultimatr)
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
                ValidateExist<IEntryStore, Domain.Team>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Team>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
