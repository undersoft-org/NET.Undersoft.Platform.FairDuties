﻿using NicmanGroup.AuditLogging.Events;
namespace Undersoft.IDP.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserProviderRequestedEvent<TUserProviderDto> : AuditEvent
    {
        public TUserProviderDto Provider { get; set; }

        public UserProviderRequestedEvent(TUserProviderDto provider)
        {
            Provider = provider;
        }
    }
}