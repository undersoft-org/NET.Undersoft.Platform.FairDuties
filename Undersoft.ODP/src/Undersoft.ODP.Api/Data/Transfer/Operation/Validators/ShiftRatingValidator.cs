using RadicalR;

namespace Undersoft.ODP.Api
{
    public class ShiftRatingValidator : CommandSetValidatorBase<Estimate>
    {
        public ShiftRatingValidator(IRadicalr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.Estimate>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
