﻿
using System.Collections.Generic;

namespace Web_food.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public string Hinh { get; set; }
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }

    }
}