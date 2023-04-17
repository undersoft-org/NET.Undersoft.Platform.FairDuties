using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class PlanValidator : DtoCommandSetValidator<PlanDto>
    {
        public PlanValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(3, 100, a => a.Data.Name);
            });
            ValidationScope(CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(p => p.Data.Name);
                ValidateLength(3, 100, a => a.Data.Name);
                ValidateExist<IEntryStore, Plan>((cmd) => (e) => e.Id == cmd.Id);
            });
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Plan>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
