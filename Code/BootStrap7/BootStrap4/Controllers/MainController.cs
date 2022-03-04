using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BootStrap4.Models;
using BootStrap4.Models.Dang_Ky_Tin;
using BootStrap4.Models.Tai_Khoan;
using BootStrap4.Models.Mon_Hoc;


namespace BootStrap4.Controllers
{
    public class MainController : Controller
    {
        DangKyTinModel dangKyTinModel = new DangKyTinModel();
        MonHocModel monHocModel = new MonHocModel();
        TaiKhoanModel taiKhoanModel = new TaiKhoanModel();

        // GET: Main
        [HttpGet]
        public ActionResult MainIndex()
        {
            return View();
        }

        public ActionResult DangKyTinChi(int page = 1, int pageSize = 10)
        {
            try
            {
                string tenTK = Session["user"].ToString();
                var model = new DangKyTinHandler().GetDangKyTin(tenTK).ToPagedList(page, pageSize);
                return View(model);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            
            
        }
        public ActionResult FilterDKT(string searchString, int page = 1, int pageSize = 10)
        {
            try
            {
                string tenTK = Session["user"].ToString();
                var model = new DangKyTinHandler().FilterDKT(tenTK, searchString ).ToPagedList(page, pageSize);
                return View("DangKyTinChi", model);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        public ActionResult MethodDKT(string submitButton, MonHoc monHoc, FormCollection frmCollection, string searchString)
        {
            switch (submitButton)
            {
                case "Hủy đăng ký":
                    return DeleteDKT(frmCollection);
                case "Search":
                    return FilterDKT(searchString);
                case "Refresh":
                    return RedirectToAction("DangKyTinChi");
                default:
                    return (View("Index"));
            }
        }

        public ActionResult QuanLyMonHoc(int page = 1, int pageSize = 10)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                var modelMH = new MonHocHandler().GetMonHocs(tenTK).OrderBy(x => x.MaMon).ToPagedList(page, pageSize);
                return View(modelMH);
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        
        
        public ActionResult MethodMonHoc(string submitButton, MonHoc monHoc, FormCollection frmCollection, 
                                         string searchString,string maMon, string tenMon)
        {
            switch (submitButton)
            {
                case "Đăng ký":
                    return CreateDKT(frmCollection);
                case "Tạo":
                    return (View("CreateMH"));
                case "Sửa":
                    return EditMonHoc(frmCollection, monHoc);
                case "Capnhat":
                    return UpdateMonHoc2(maMon, tenMon);
                case "Xóa":
                    return DeleteMonHoc(frmCollection, monHoc);
                case "Search":
                    return FilterMonHoc(searchString);
                case "Refresh":
                    return RedirectToAction("QuanLyMonHoc");
                default:
                    return View("Index");
            }
        }

        [HttpPost]
        public JsonResult FindMH(int Id)
        {
            try
            {
                var mh = new MonHocHandler().GetMonHocById(Id);
                ViewBag.tenMon = mh.TenMon;
                return Json(mh);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
        public ActionResult CreateMH(int maMon, string tenMon)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                var tk = new TaiKhoanHandler().GetHoTen(tenTK);
                var result = new MonHocHandler().CreateSubject(maMon, tenMon, tk, DateTime.Now);
                return RedirectToAction("QuanLyMonHoc");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult FilterMonHoc(string searchString, int page = 1, int pageSize = 10)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                var modelMH = new MonHocHandler().FilterSubject(tenTK, searchString).OrderBy(x => x.MaMon).ToPagedList(page, pageSize);
                return View("QuanLyMonHoc",modelMH);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        public ActionResult CreateMonHoc(MonHoc monHoc)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                var tk = new TaiKhoanHandler().GetHoTen(tenTK);
                var result = new MonHocHandler().CreateSubject(monHoc.MaMon, monHoc.TenMon, tk, DateTime.Now);
                return RedirectToAction("QuanLyMonHoc");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult EditMonHoc(FormCollection frmCollection, MonHoc monHoc)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                string[] ids = frmCollection["checkboxid"].Split(new char[] { ',' });
                MonHocHandler mh = new MonHocHandler();
                if (ids.Length > 1)
                {
                    return RedirectToAction("QuanLyMonHoc");
                }
                else
                {
                    foreach (string id in ids)
                    {
                        monHoc.MaMon = int.Parse(id);
                        monHoc.TenMon = new MonHocHandler().getNameSubject(int.Parse(id));
                    }
                    return PartialView("PopUpEditMonhoc", monHoc);
                }
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult UpdateMonHoc2(string maMon,string tenMon)
        {
            try
            { 
                string tenTK = Session["User"].ToString();
                var tk = new TaiKhoanHandler().GetHoTen(tenTK);
                var result = new MonHocHandler().UpdateSubject(int.Parse(maMon),tenMon, tk, DateTime.Now);
                return RedirectToAction("QuanLyMonHoc");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult UpdateMonHoc(MonHoc monHoc)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                var tk = new TaiKhoanHandler().GetHoTen(tenTK);
                var result = new MonHocHandler().UpdateSubject(monHoc.MaMon, monHoc.TenMon, tk, DateTime.Now);
                return RedirectToAction("QuanLyMonHoc");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        
        public ActionResult DeleteMonHoc(FormCollection frmCollection, MonHoc monHoc)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                string[] ids = frmCollection["checkboxid"].Split(new char[] { ',' });
                MonHocHandler mh = new MonHocHandler();
                foreach (string id in ids)
                {
                    var result = new MonHocHandler().DeleteSubject(int.Parse(id));
                }
                return RedirectToAction("QuanLyMonHoc");
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }
        public bool DeleteMH(int Id)
        {
            try
            {
                var result = new MonHocHandler().DeleteSubject(Id);
                if (result == true)
                {
                    return true;
                }
                else return false;
            }catch(Exception e)
            {
                return false;
            }
        }
        public bool CreateDK(int Id)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                var tk = new TaiKhoanHandler().GetHoTen(tenTK);
                var result = new DangKyTinHandler().CreateDKT(Id, tenTK, tk, DateTime.Now);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
             
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ActionResult CreateDKT(FormCollection frmCollection)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                string[] ids = frmCollection["checkboxid"].Split(new char[] { ',' });
                var tk = new TaiKhoanHandler().GetHoTen(tenTK);
                var dkt = new DangKyTinHandler();

                foreach (string id in ids)
                {
                    var result = dkt.CreateDKT(int.Parse(id), tenTK, tk, DateTime.Now);
                    if (result == null)
                    {

                    }
                    else
                    {

                    }
                }
                return RedirectToAction("QuanLyMonHoc");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }  
        }

        public ActionResult DeleteDKT(FormCollection frmCollection)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                string[] ids = frmCollection["checkboxid"].Split(new char[] { ',' });
                var dkt = new DangKyTinHandler();
                foreach (string id in ids)
                {
                    var result = dkt.DeleteDKT(int.Parse(id),tenTK );
                    if (result == null)
                    {

                    }
                    else
                    {

                    }
                }
                return RedirectToAction("DangKyTinChi");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public bool HuyDKT(int Id)
        {
            try
            {
                string tenTK = Session["User"].ToString();
                var result = new DangKyTinHandler().DeleteDKT(Id, tenTK);
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
            
        }

        public ActionResult Edit(MonHocModel monHocModel)
        {
            return View();
        }

        public ActionResult quanLyTaiKhoan()
        {
            return View();
        }

        public ActionResult logout()
        {
            return View("LoginIndex");
        }

    }
}