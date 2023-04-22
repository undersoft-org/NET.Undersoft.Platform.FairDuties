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

    public class DeviceSessionMapping : EntityTypeMapping<DeviceSession>
    {
        const string TABLE_NAME = "DeviceSessions";

        public override void Configure(EntityTypeBuilder<DeviceSession> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);
        }
    }
}
