using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Project.Models;
using Web_food.DAO;
using Web_food.EditModel;
using Web_food.Models;
using Login = Web_food.DAO.Login;


namespace Web_food.Controllers
{
    public class HomeController : Controller
    {
        public int lever = 3;
        public ActionResult Index(int? type)
        {
            List<Product> list = ListProduct.Product(type);
            ViewBag.list = list;
            List<ProductType> types = ListProduct.getType();
            ViewBag.type = types;
            if (type == null)
            { 
             list = ListProduct.showProduct();
            }

            return View();
        }
        public ActionResult dang_nhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dang_nhap(EditModelLogin editModel)
        {
            Login login = new Login();
            User user = login.doLogin(editModel.Username,editModel.Password, editModel.Email, editModel.Phone, editModel.Address);
            if (user != null)
            {
                Session["username"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu";
                return View();
            }

        }
        public ActionResult Logout() {
            Session.Remove("username");
            return Redirect("/");
        }
        public ActionResult dang_ky()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult dang_ky(EditModelRegister register)
        {
            Register r = new Register();
            r.doRegister(register.Username, register.Password, register.Email,register.Phone);
            
            return RedirectToAction("dang_nhap","Home");
        }
        
        public ActionResult san_pham(int? type, int? pages)
        {
            List<Product> list = ListProduct.Product(type);
            ViewBag.list = list;
            List<ProductType> types = ListProduct.getType();
            ViewBag.type = types;
            if (type == null)
            {
                list = ListProduct.showProduct();
                ViewBag.list = list;
            }

            // if (pages == null) pages = 1;
            //     List<Product> page = ListProduct.getPage(pages);
            //
            //     int pageSize = 5;
            //     int pageNumber = (pages ?? 1);
            //
            // ViewBag.page = page.ToPagedList(pageNumber, pageSize);

            return View();
        }
        public ActionResult gio_hang()
        {
            return View();
        }

        public ActionResult thanh_toan()
        {
            return View();
        }

        public ActionResult dat_hang()
        {
            return View();
        }

        public ActionResult gioi_thieu()
        {
            return View();
        }

        public ActionResult tin_tuc()
        {
            return View();
        }
        public ActionResult nhat_ky()
        {
            List<Product> list = ListProduct.showProduct();
            ViewBag.pro = list;
         return View();
        }
        public ActionResult lien_he()
        {
            return View();
        }
        public ActionResult chi_tiet_sp(string name)
        {
           List<Product> list = ProductDetail.showProduct(name);
           ViewBag.ct = list;
            return View();
        }

        public ActionResult TKKH()
        {
            return View();
        }

        public ActionResult tim_kiem(string search)
        {
            List<Product> list = Search.seacrh(search);
            ViewBag.search = search;
            ViewBag.pro = list;
            return View();
        }
    }
}