﻿using System.Web;
using System.Web.Mvc;

namespace Practical_15_WindowsAuthentication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
