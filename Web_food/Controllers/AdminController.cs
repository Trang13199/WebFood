using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
<<<<<<< HEAD
using PagedList;
=======
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
using Web_food.DAO;
using Web_food.EditModel;
using Web_food.Models;

namespace Web_food.Controllers
{
    [KiemTraQuyen]
    public class AdminController : Controller
    {
<<<<<<< HEAD
        public ActionResult Index()
        {
            return View();
=======
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
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(EditModelLogin editModel)
        {
            Login login = new Login();
            User user = login.doLogin(editModel.Password, editModel.Email);
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
        public ActionResult danh_sach_sp(int? page)
        {
            if (page == null) page = 1;
            List<Product> pages = DAOProduct.getPage(page);
            
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            
            return View(pages.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult loai_sp(int? type)
        {
            List<Product> list = DAOProduct.Product_type(type);
            return View(list);
        }
        public ActionResult them_sp()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
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
            if (dao.Add_product(p))
            {
                new DaoLog().INFO("success", "them_sp");
            }
            else
            {
                new DaoLog().INFO("fail", "them_sp");
            }

            TempData["msg"] = "INSERT SUCCESS";
            return RedirectToAction("danh_sach_sp", "Admin");  }
        public ActionResult chinh_sua_sp(int id)
        {
            DAOProduct dao = new DAOProduct();
            DataSet ds = dao.show_record_byid(id);
            ViewBag.updateSP = ds.Tables[0];
            return View();
        } 
        [HttpPost, ValidateInput(false)]
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
            if (dao.Update_product(p, id))
            {
                new DaoLog().INFO("success", "chinh_sua_sp");
            }
            else
            {
                new DaoLog().INFO("fail", "chinh_sua_sp");
            }

            TempData["msg"] = "UPDATE SUCCESS";
            return RedirectToAction("danh_sach_sp", "Admin");
        }
        public ActionResult xoa_sp(int id)
        {
            DAOProduct dao = new DAOProduct();
            if (dao.delete(id))
            {
                new DaoLog().WARNING("success", "xoa_sp");
            }
            else
            {
                new DaoLog().WARNING("fail", "xoa_sp");
            }

            return RedirectToAction("danh_sach_sp", "Admin");
        }
<<<<<<< HEAD

=======
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
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
<<<<<<< HEAD
                new DaoLog().INFO("success", "them_loai_sp");
=======
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
                return RedirectToAction("ql_loai_sp", "Admin");
            }
            else
            {
<<<<<<< HEAD
                new DaoLog().INFO("fail", "them_loai_sp");
=======
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
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
<<<<<<< HEAD

            ProductType productType = new ProductType(id, name, active);
            if (DAOProduct.editProductType(productType))
            {
                new DaoLog().INFO("success", "chinh_sua_loaiSP");
                return RedirectToAction("ql_loai_sp", "Admin");
            }
            else
            {
                new DaoLog().INFO("fail", "chinh_sua_loaiSP");
                ViewBag.error = "edit product type not success";
                return View();
            }
        }
        public ActionResult xoa_loai_sp(int id)
        {
            if (DAOProduct.delProductType(id))
            {
                new DaoLog().WARNING("success", "xoa_loai_sp");
            }
            else
            {
                new DaoLog().WARNING("fail", "xoa_loai_sp");
            }

            return RedirectToAction("ql_loai_sp", "Admin");
        }
        public ActionResult khach_hang()
        {
            List<User> listuser = DAOUser.getlistUser();
            return View(listuser);
        }
        public ActionResult them_khach_hang()
=======

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
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
        {
            DAOProduct.delProductType(id);
            return RedirectToAction("ql_loai_sp", "Admin");
        }
<<<<<<< HEAD
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
            if (DAOUser.addUser(user))
            {
                new DaoLog().INFO("success", "them_khach_hang");
            }
            else
            {
                new DaoLog().INFO("fail", "them_khach_hang");
            }

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
            // user.password = formCollection["password"];
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
                new DaoLog().INFO("success", "chinh_sua_kh");
                return RedirectToAction("khach_hang", "Admin");
            }
            else
            {
                new DaoLog().INFO("fail", "chinh_sua_kh");
                ViewBag.error = "not success";
                return RedirectToAction("chinh_sua_kh", "Admin", new {ID = Convert.ToInt32(formCollection["id"])});
            }
        }

        public ActionResult xoa_kh(int id)
        {
            if (DAOUser.delUser(id))
            {
                new DaoLog().WARNING("success", "xoa_kh");
            }
            else
            {
                new DaoLog().WARNING("fail", "xoa_kh");
            }

            return RedirectToAction("khach_hang", "Admin");
        }

        public ActionResult chinh_sua_donhang(string maDH)
       {
           DAOOrder dao = new DAOOrder();
           DataSet ds = dao.show_order_id(maDH);
           ViewBag.updateDH = ds.Tables[0];
           return View();
       }
        [HttpPost]
        public ActionResult chinh_sua_donhang(string maDH, FormCollection fc)
        {
            Order o = new Order();
            o.id = maDH;
            o.status = fc["status"];
            o.date = Convert.ToDateTime(fc["date"]);
            DAOOrder daoOrder = new DAOOrder();
            daoOrder.Update_order(o,maDH);
            return RedirectToAction("QuanLyDonHang", "Admin");
        }
        public ActionResult chi_tiet_sp()
        {
            return View();
        }
        public ActionResult del_oder(string idi)
        {
            if (DAOOrder.del_oder(idi))
            {
                new DaoLog().WARNING("success", "del_oder");
            }
            else
            {
                new DaoLog().WARNING("fail", "del_oder");
=======
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
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
            }

            return RedirectToAction("QuanLyDonHang", "Admin");
        }
<<<<<<< HEAD


        public ActionResult QuanLyDonHang()
=======
        public ActionResult xoa_kh(int id)
        {
            DAOUser.delUser(id);
            return RedirectToAction("khach_hang", "Admin");
        }
       public ActionResult thanh_toan()
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
        {
            List<Order> list_order = DAOOrder.show_quanlyhoadon();
            return View(list_order);
        }
<<<<<<< HEAD

        public ActionResult chi_tiet_don_hang(string idi)
=======
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
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
        {
            ViewBag.list_order = DAOOrder.show_hoadon(idi);
            DataSet ds = DAOOrder.show_order_byID(idi);
            ViewBag.show = ds.Tables[0];
            return View();
        }
    }
}
