using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Web_food.DAO;
using Web_food.EditModel;
using Web_food.Models;

namespace Web_food.Controllers
{
    public class AdminController : Controller
    {
        // public AdminController()
        // {
        //     this.lever = 2;
        // }
        // GET
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            // Session.Remove("FirstName");
            return View();
        }
        public ActionResult Login(EditModelLogin editModel)
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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dang_ky(EditModelRegister register)
        {
            Register r = new Register();
            r.doRegister(register.Username, register.Password, register.Email,register.Phone, register.Address,register.Gender);
            
            return RedirectToAction("dang_nhap","Home");
        }
        [HttpPost]
        public ActionResult Logout() {
            Session.Remove("FirstName");
            return Redirect("/");
        }
        public ActionResult danh_sach_sp()
        {
            List<Product> listProduct = DAOProduct.getListProducts();
            return View(listProduct);
            // DAOProduct dao = new DAOProduct();
            // DataSet ds = dao.show();
            // ViewBag.showSP = ds.Tables[0];
            // return View();
        }
        public ActionResult them_sp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them_sp(FormCollection fc)
        {
            Product p = new Product();
            p.Images = fc["image"];
            p.Name = fc["name"];
            p.Price = Convert.ToDouble(fc["price"]);
            p.Content = fc["content"];
            p.Type = Convert.ToInt32(fc["type"]);
            p.Quantity = Convert.ToInt32(fc["quantity"]);
            DAOProduct dao = new DAOProduct();
            dao.Add_product(p);
            TempData["msg"] = "INSERT SUCCESS";
            return RedirectToAction("danh_sach_sp","Admin");
        }
        public ActionResult chinh_sua_sp(int id)
        {
            DAOProduct dao = new DAOProduct();
            DataSet ds = dao.show_record_byid(id);
            ViewBag.updateSP = ds.Tables[0];
            return View();
        } 
        [HttpPost]
        public ActionResult chinh_sua_sp(int id, FormCollection fc)
        {
            Product p = new Product();
            p.Id = id;
            p.Images = fc["image"];
            p.Name = fc["name"];
            p.Price = Convert.ToDouble(fc["price"]);
            p.Content = fc["content"];
            p.Type = Convert.ToInt32(fc["type"]);
            p.Quantity = Convert.ToInt32(fc["quantity"]);
            DAOProduct dao = new DAOProduct();
            dao.Update_product(p, id);
            TempData["msg"] = "UPDATE SUCCESS";
            return RedirectToAction("danh_sach_sp", "Admin");
        }

        public ActionResult xoa_sp(int id)
        {
            DAOProduct dao = new DAOProduct();
            dao.delete(id);
            return RedirectToAction("danh_sach_sp", "Admin");
        }
        public ActionResult ql_loai_sp()
        {
            List<ProductType> list = DAOProduct.getListProductType();
            return View(list);
        }
        public ActionResult them_loai_sp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them_loai_sp(FormCollection formCollection)
        {
            int id = Convert.ToInt32(formCollection["id"]);
            string name = formCollection["name"];
            ProductType productType = new ProductType(id, name);
            if (DAOProduct.addProductType(productType))
            {
                return RedirectToAction("ql_loai_sp", "Admin");
            }
            else
            {
                ViewBag.error = "add product type not success";
                return View();
            }
        }
        public ActionResult chinh_sua_loaiSP(int id)
        {
            ProductType productType = DAOProduct.getProductType(id);
            return View(productType);
        }
        [HttpPost]
        public ActionResult chinh_sua_loaiSP(FormCollection formCollection)
        {
            int id = Convert.ToInt32(formCollection["id"]);
            string name = formCollection["name"];
            int active = Convert.ToInt32(formCollection["active"]);

            ProductType productType = new ProductType(id,name,active);
            if (DAOProduct.editProductType(productType))
            {
                return RedirectToAction("ql_loai_sp","Admin");
            }
            else
            {
                ViewBag.error = "edit product type not success";
                return View();
            }
        }
        public ActionResult xoa_loai_sp(int id)
        {
            DAOProduct.delProductType(id);
            return RedirectToAction("ql_loai_sp", "Admin");
        }
        public ActionResult khach_hang()
        {
            List<User> listuser = DAOUser.getlistUser();
            return View(listuser);
        }
        public ActionResult them_khach_hang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them_khach_hang(FormCollection formCollection)
        {
            User user = new User();
            user.email = formCollection["email"];
            user.password = formCollection["password"];
            user.userName = formCollection["username"];
            user.phone = formCollection["phone"];
            user.address = formCollection["address"];
            user.gender = formCollection["gender"];
            DAOUser.addUser(user);
            return RedirectToAction("khach_hang", "Admin");
        }
        public ActionResult chinh_sua_kh(int id)
        {
            User user = DAOUser.getuser(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult chinh_sua_kh(FormCollection formCollection)
        {
            User user = new User();
            user.id = Convert.ToInt32(formCollection["id"]);
            user.email = formCollection["email"];
            user.password = formCollection["password"];
            user.userName = formCollection["username"];
            user.phone = formCollection["phone"];
            user.address = formCollection["address"];
            user.gender = formCollection["gender"];
            user.level = Convert.ToInt32(formCollection["level"]);
            Console.WriteLine("User:: {'ID: " + user.id + "','userName: " + user.userName + "pass:" + user.password +
                              " email: " + user.email
                              + " address: " + user.address + "phone: " + user.phone + " gender: " + user.gender +
                              " level: " + user.level + "'}");
            if (DAOUser.editUser(user))
            {
                return RedirectToAction("khach_hang", "Admin");
            }
            else
            {
                ViewBag.error = "not success";
                return RedirectToAction("chinh_sua_kh", "Admin", new {ID = Convert.ToInt32(formCollection["id"])});
            }
        }
        public ActionResult xoa_kh(int id)
        {
            DAOUser.delUser(id);
            return RedirectToAction("khach_hang", "Admin");
        }
       public ActionResult thanh_toan()
        {
            return View();
        }
       public ActionResult gio_hang()
        {
            return View();
        }
       public ActionResult them_gio_hang()
        {
            return View();
        }
       public ActionResult chinh_sua_donhang()
       {
           return View();
       }
        public ActionResult chi_tiet_sp()
        {
            return View();
        }
    }
}