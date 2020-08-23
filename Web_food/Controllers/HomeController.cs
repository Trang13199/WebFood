using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using PagedList;
using Project.Models;
using Web_food.DAO;
using Web_food.EditModel;
using Web_food.Models;

namespace Web_food.Controllers
{
    public class HomeController : Controller
    {
        // public HomeController()
        // {
        //     this.lever = 1;
        // }

        public ActionResult Index(int? type)
        {
            List<Product> list = ListProduct.Product(type);
            // ViewBag.list = list;
            List<ProductType> types = ListProduct.getType();
            ViewBag.type = types;
            if (type == null)
            { 
             list = ListProduct.showProduct();
            }

            return View(list);
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
            r.doRegister(register.Username, register.Password, register.Email,register.Phone, register.Address);
            
            return RedirectToAction("dang_nhap","Home");
        }
        
        public ActionResult san_pham(int? type, int? page)
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

            if (page == null && type == null) page = 1;
            List<Product> pages = ListProduct.getPage(page);
            
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            
            // ViewBag.page = pages.ToPagedList(pageNumber, pageSize);

            return View(pages.ToPagedList(pageNumber, pageSize));
        }
        
        public ActionResult san_pham1(int? type, int pageindex = 1, int pagesize = 2)
        {
            // List<Product> list = ListProduct.Category(type, pageindex, pagesize);
            // ViewBag.list = list;
            
            List<Product> list = ListProduct.Product(type);
            ViewBag.list = list;
            
            List<ProductType> types = ListProduct.getType();
            ViewBag.type = types;
            if (type == null)
            {
                list = ListProduct.showProduct();
                ViewBag.list = list;
            }
            return View();
        }
        public ActionResult gio_hang()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }

        public ActionResult thanh_toan()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            User u = (User) Session["username"];
            if (u == null)
            {
                return RedirectToAction("dang_nhap");
            }
            return View(giohang);
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
        
        
        
        public RedirectToRouteResult ThemVaoGio(int SanPhamID)
        {
            if(Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }
           
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID) == null) // ko co sp nay trong gio hang
            {
                Product sp = new Product().find(SanPhamID);  // tim sp theo sanPhamID

                CartItem newItem = new CartItem()
                {
                    SanPhamID = SanPhamID,
                    TenSanPham = sp.Name,
                    SoLuong = 1,
                    Hinh = sp.Images,
                    DonGia = sp.Price

                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem cardItem = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
                cardItem.SoLuong++;
            }
            
            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return RedirectToAction("san_pham", "Home", new { id = SanPhamID });
        }

        public RedirectToRouteResult SuaSoLuong(int SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
            if(itemSua != null)
            {
                itemSua.SoLuong = soluongmoi;
            }
            return RedirectToAction("gio_hang");

        }
        public RedirectToRouteResult XoaKhoiGio(int SanPhamID)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("gio_hang");
        }


    }
}
