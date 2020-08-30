using System.Web;
using System.Web.Mvc;
using Web_food.Controllers;
using Web_food.Models;

namespace Web_food.filter
{
    public class AccountFilter : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            WebController controller = filterContext.Controller as WebController;
            User u = (User) HttpContext.Current.Session["user"];
            bool check = false;
            if ((controller.lever == 2 || controller.lever == 3)) {
                if (u != null) {
//                User u = (User) HttpContext.Current.Session["user"];
                    string actionName = filterContext.ActionDescriptor.ActionName;
                    string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    foreach (Role role in u.roles) {
                        if (role.contain(controllerName, actionName)) check = true;
                    }
                }

                if (check == false)
                    controller.HttpContext.Response.Redirect("/");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}