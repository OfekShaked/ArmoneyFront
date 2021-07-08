using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Helpers
{
    public static class ActionHighlighterHelper
    {
        public static bool IsCurrentControllerAndAction(string controllerName, string actionName, ViewContext viewContext)
        {
            var currentControllerName = viewContext.RouteData.Values["Controller"];
            var currentActionrName = viewContext.RouteData.Values["Action"];
            return (currentControllerName.Equals(controllerName) && actionName.Equals(currentActionrName));
        }
    }
}
