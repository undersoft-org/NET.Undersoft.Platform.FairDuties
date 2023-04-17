﻿using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;

    public class UserValidator : DtoCommandSetValidator<UserDto>
    {
        public UserValidator(IUltimatr ultimatr) : base(ultimatr)
        {
            ValidationScope(CommandMode.Any, () => ValidateEmail(p => p.Data.Email));

            ValidationScope(CommandMode.Create, () =>
            {
                ValidateNotExist<IEntryStore, User>((cmd) =>
                (e) => e.Email == cmd.Email
                || e.UserName == cmd.UserName
                || e.PhoneNumber == cmd.PhoneNumber, "same Name, Email or PhoneNumber");
            });
            ValidationScope(CommandMode.Create | CommandMode.Upsert | CommandMode.Update, () =>
            {
                ValidateRequired(p => p.Data.UserName);
                ValidateLength(3, 100, a => a.Data.UserName);
            });
            ValidationScope(CommandMode.Delete | CommandMode.Update | CommandMode.Change, () =>
            {
                ValidateRequired(a => a.Data.Id);
                ValidateExist<IEntryStore, User>((cmd) => (e) => e.Id == cmd.Id);
            });
        }
    }
}