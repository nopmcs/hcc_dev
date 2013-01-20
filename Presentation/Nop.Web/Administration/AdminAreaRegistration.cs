using System.Web.Mvc;

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
            ///user: ganesha8shiva, Note: change admin route
            context.MapRoute(
                "Admin_default",
                "C0nfluence@22163917/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", area = "Admin", id = "" },
                new[] { "Nop.Admin.Controllers" }
            );
        }
    }
}
