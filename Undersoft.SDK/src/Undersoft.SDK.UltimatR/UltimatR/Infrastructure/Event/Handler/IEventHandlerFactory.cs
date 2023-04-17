using System;
using System.Collections.Generic;

namespace UltimatR
{
    public interface IEventHandlerFactory
    {
        Type HandlerType { get; }

        IEventHandlerDisposeWrapper GetHandler();

        bool IsInFactories(List<IEventHandlerFactory> handlerFactories);
    }
}
