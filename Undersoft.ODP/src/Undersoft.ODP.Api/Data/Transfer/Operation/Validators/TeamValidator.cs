using RadicalR;

namespace Undersoft.ODP.Api
{
    public class TeamValidator : CommandSetValidatorBase<Group>
    {
        public TeamValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, Domain.Group>((cmd) =>
                (e) => e.Name == cmd.Name, "same name already exists");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateRequired(p => p.Data.LeadershipId);
                ValidateLength(3, 80, a => a.Data.Name);
                ValidateLength(1, 50, a => a.Data.ShortName);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Group>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
