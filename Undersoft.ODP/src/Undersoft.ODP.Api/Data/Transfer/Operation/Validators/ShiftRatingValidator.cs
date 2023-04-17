using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;
    public class ShiftRatingValidator : DtoCommandSetValidator<ShiftRateDto>
    {
        public ShiftRatingValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, ShiftRate>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
