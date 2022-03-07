using BootStrap4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootStrap4.Models.Tai_Khoan;


namespace BootStrap4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }
        public ActionResult Login(TaiKhoanModel taiKhoanModel)
        {
            if(taiKhoanModel.TenTaiKhoan == null && taiKhoanModel.MatKhau== null)
            {
                return View("LoginIndex");
            }
            else
            {
                var log = new TaiKhoanHandler().Login(taiKhoanModel.TenTaiKhoan, taiKhoanModel.MatKhau);
                if (log==true)
                {
                    Session["User"] = taiKhoanModel.TenTaiKhoan;
                    Session["Acess"] = new TaiKhoanHandler().GetQuyen(taiKhoanModel.TenTaiKhoan, taiKhoanModel.MatKhau);
                    return RedirectToAction("MainIndex", "Main");
                }
                else
                {
                    return View("LoginIndex");
                }
            }
        }
        public ActionResult Logout(TaiKhoanModel taiKhoanModel)
        {
            Session["User"] = "";
            return RedirectToAction("LoginIndex");
        }
    }
}