using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RadicalR.Server
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class IgnoreApiAttribute : ActionFilterAttribute { }
}

