using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Web_food.DAO;

namespace Web_food.Models
{
    public class KiemTraQuyenAttribute : AuthorizeAttribute
    {
        // khai báo quyền hay chức năng tương ứng với action viết trong controller
        // public string permissionName { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // lấy thông tin người dùng được lưu vào session
            User user = (User) HttpContext.Current.Session["username"];
            // lấy mã vai trò
            DAOrole d = new DAOrole();

            var rd = httpContext.Request.RequestContext.RouteData;
            string currentAction = rd.GetRequiredString("action");
            string currentController = rd.GetRequiredString("controller");
            if (user != null && user.level != 1)
            {
                List<Role> l = d.getListRole(user.userName);
                l.AddRange(listView(currentController));
                foreach (Role role in l)
                {
                    if (role.contain(currentController, currentAction))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Home/errorpage.cshtml"
            };
        }

        public List<Role> listView(string currentController)
        {
            List<Role> view = new List<Role>();
            view.Add(new Role(currentController, "Index"));
            view.Add(new Role(currentController, "danh_sach_sp"));
            view.Add(new Role(currentController, "khach_hang"));
            view.Add(new Role(currentController, "ql_loai_sp"));
            view.Add(new Role(currentController, "QuanLyDonHang"));
            view.Add(new Role(currentController, "chi_tiet_don_hang"));
            return view;
        }
    }
}