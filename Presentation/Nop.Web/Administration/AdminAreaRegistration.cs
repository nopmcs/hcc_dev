﻿using System.Web.Mvc;

namespace Nop.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            ///DEV: ganesha8shiva, Note: change admin route Rollback
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", area = "Admin", id = "" },
                new[] { "Nop.Admin.Controllers" }
            );
        }
    }
}
