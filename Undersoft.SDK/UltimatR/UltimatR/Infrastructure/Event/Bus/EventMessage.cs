﻿using System;
using System.Text.Json;

namespace UltimatR
{
    public class EventMessage : Event
    {
        public EventMessage(object eventData, Type eventType)
        {
            EventData = JsonSerializer.SerializeToUtf8Bytes(eventData);
            EventType = eventType.FullName;
        }
    }
}