﻿using UltimatR;

namespace Undersoft.ODP.Api
{
    public class ShiftRatingValidator : DtoCommandSetValidator<ShiftRate>
    {
        public ShiftRatingValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Delete, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.ShiftRate>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
