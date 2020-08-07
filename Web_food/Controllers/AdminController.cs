using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Project.Models;
using Web_food.DAO;
using Web_food.EditModel;
using Web_food.Models;

namespace Web_food.Controllers
{
    public class AdminController : Controller
    { // GET
        public ActionResult gio_hang()
        {
            return View();
        }

        public ActionResult them_gio_hang()
        {
            return View();
        }

        public ActionResult them_sp()
        {
            return View();
        }

        public ActionResult chi_tiet_sp()
        {
            return View();
        }

        public ActionResult chinh_sua_donhang()
        {
            return View();
        }

        public ActionResult chinh_sua_kh()
        {
            return View();
        }

        public ActionResult chinh_sua_loaiSP()
        {
            return View();
        }

        public ActionResult chinh_sua_sp()
        {
            return View();
        }

        public ActionResult xoa_sp()
        {
            return RedirectToAction("danh_sach_sp", "Admin");
        }

        public ActionResult Index()

        {
            // DaoRegister re = new DaoRegister();
            // bool a = false;
            // a = re.doRegister("aac", "ad", "ahhaa@gmail.com");
            // Console.Write(a);
            return View();
        }

        public ActionResult khach_hang()
        {
            return View();
        }

        public ActionResult ql_loai_sp()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(EditModelRegister EditModelRegister)
        {
            DaoRegister daoRegister = new DaoRegister();
            // if (EditModelRegister.Email.Equals(EditModelRegister.Repeatemail) &&
            //     EditModelRegister.Password.Equals(EditModelRegister.Repeatpwd))
            // {
                daoRegister.doRegister(EditModelRegister.Username, EditModelRegister.Password, EditModelRegister.Email);
                return RedirectToAction("Login", "Admin");
            // }

            return View();
        }

        public ActionResult them_khach_hang()
        {
            return View();
        }

        public ActionResult them_loai_sp()
        {
            return View();
        }

        public ActionResult thanh_toan()
        {
            return View();
        }

        public ActionResult danh_sach_sp()
        {
            List<Product> listProduct = DAOProduct.getListProducts();
            return View(listProduct);
        }

        public ActionResult Login()
        {
            // DBConnection conn = new DBConnection();
            // conn.ConnectionSql();
            // Session["FirstName"] ;
            Session.Remove("FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Login(EditModelLogin editModel)
        {
            Login login = new Login();
            User user = login.doLogin(editModel.Username,editModel.Password, editModel.Email, editModel.Phone, editModel.Address);
            if (user != null)
            {
                Session["username"] = user;
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu";
                return View();
            }
        }
    }
}