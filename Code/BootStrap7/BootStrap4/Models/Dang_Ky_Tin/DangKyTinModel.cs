using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrap4.Models.Dang_Ky_Tin
{
    public class DangKyTinModel
    {
        public int MaDangKy { get; set; }
        public string TenTaiKhoan { get; set; }
        public int MaMon { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<System.DateTime> NgaySua { get; set; }
        public string NguoiTao { get; set; }
        public string NguoiSua { get; set; }
        public string FilterObject { get; set; }
        public string FilteText { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public string TenMon { get; set; }
    }
}