using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrap4.Models.Dang_Ky_Tin
{
    interface DangKyTinInterface
    {
        IEnumerable<DangKyTinModel> GetDangKyTin(string tenTK);
        DangKyTinModel GetDKTById(int id);
        DangKyTinModel CreateDKT(int MaMon, string TenMon, string NguoiTao, DateTime NgayTao);
      
        IEnumerable<DangKyTinModel> FilterDKT(string tenTK, string searchString);
        bool DeleteDKT(int maMon, string tenTK);
        DangKyTinModel Save();

    }
   
}