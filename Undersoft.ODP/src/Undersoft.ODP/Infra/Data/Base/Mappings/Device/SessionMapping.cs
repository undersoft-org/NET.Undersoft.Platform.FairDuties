//-----------------------------------------------------------------------
// <copyright file="MemberDeviceSessionMapping.cs" company="Undersoft">
//     Author: Dariusz Hanc
//     Copyright (c) Undersoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class SessionMapping : EntityTypeMapping<Session>
    {
        const string TABLE_NAME = "Sessions";

        public override void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);
        }
    }
}
