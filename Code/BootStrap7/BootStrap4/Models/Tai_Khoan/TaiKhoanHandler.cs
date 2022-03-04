using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrap4.Models.Tai_Khoan
{
    public class TaiKhoanHandler
    {
        private TaiKhoanModel _TK = null;
        public TaiKhoanHandler()
        {
            _TK = new TaiKhoanModel();
        }

        public dtbtt1Entities DB()
        {
            dtbtt1Entities db = new dtbtt1Entities();
            return db;
        }

        public string GetHoTen(string tentk)
        {
            string hoten = DB().TaiKhoans.SingleOrDefault(x => x.TenTaiKhoan == tentk).HoTen.ToString();
            return hoten;
        }

        public string GetTenTK()
        {
            return _TK.TenTaiKhoan;
        }

        public string GetMatKhau()
        {
            return _TK.MatKhau;
        }

        public bool GetQuyen(string TenTK, string Mk)
        {
            var result = DB().TaiKhoans.SingleOrDefault(x => x.TenTaiKhoan == TenTK && x.MatKhau == Mk);
            var acess = bool.Parse(result.Quyen.ToString());
            return acess;
        }

        public bool Login(string TenTK, string Mk)
        {

            var result = DB().TaiKhoans.SingleOrDefault(x => x.TenTaiKhoan == TenTK && x.MatKhau == Mk);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Logout()
        {
            return false;
        }
    }
   
}