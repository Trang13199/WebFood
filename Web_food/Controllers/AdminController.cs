using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Project.Models;
using Web_food.DAO;
// using Web_food.EditModel;
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
        public ActionResult danh_sach_sp()
        {
            List<Product> listProduct = DAOProduct.getListProducts();
            return View(listProduct);
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
        public ActionResult chi_tiet_sp()
        {
            return View();
        }

        public ActionResult chinh_sua_donhang()
        {
            return View();
        }
        public ActionResult them_khach_hang()
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
        public ActionResult Index()

        {
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

      public ActionResult them_loai_sp()
        {
            return View();
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
    }
}