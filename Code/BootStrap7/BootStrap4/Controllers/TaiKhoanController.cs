using BootStrap4.Models.Tai_Khoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BootStrap4.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace BootStrap4.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan

        public ActionResult QuanLyTaiKhoan(int page = 1, int pageSize = 10)
        {
            var model = new TaiKhoanHandler().GetListTK().ToPagedList(page, pageSize);
            return View(model);
        }
        public ActionResult UpdateTK(string tentk, string matkhau, string quyen)
        {
            return View();
        }

        public ActionResult CreateTK(string tentk, string matkhau, string quyen)
        {
            return View();
        }

        public ActionResult DelTK(string tentk)
        {
            return View();
        }

        public ActionResult Download_PDF()
        {
            dtbtt1Entities context = new dtbtt1Entities();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "ReportTK.rpt"));
            rd.SetDataSource(context.TaiKhoans.Select(c => new
            {
                TenTaiKhoan = c.TenTaiKhoan,
                MatKhau = c.MatKhau,
                Hoten = c.HoTen
               
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            //rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            //rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "DSTaiKhoan.pdf");
        }
        
    }
}