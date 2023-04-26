using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RadicalR
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class IgnoreApiAttribute : ActionFilterAttribute { }
}

