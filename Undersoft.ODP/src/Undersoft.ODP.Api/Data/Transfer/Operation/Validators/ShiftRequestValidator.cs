﻿using UltimatR;

namespace Undersoft.ODP.Api
{
    public class ShiftRequestValidator : DtoCommandSetValidator<ShiftRequest>
    {
        public ShiftRequestValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.Reason);
                ValidateLength(3, 80, a => a.Data.Reason);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Change | CommandMode.Update, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, Domain.ShiftRequest>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}
