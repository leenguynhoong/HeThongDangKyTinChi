using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootStrap4.Models.Tai_Khoan
{
    interface TaiKhoanInterface
    {
        IEnumerable<TaiKhoanModel> GetListTK();
        TaiKhoanModel GetTaiKhoan(string tenTK);

        TaiKhoanModel GetTaiKhoanByTK(string tenTK);

        string GetTenTK();
        string GetMatKhau();

        string GetHoTen(string tenTK);

        TaiKhoanModel Create(string tenTk, string matKhau, string quyen, string nguoiTao, DateTime ngayTao);

        TaiKhoanModel Update(string tenTk, string matKhau, string quyen);

        TaiKhoanModel Delete(string tenTk);

        bool Login(string tenTK, string mK);

        bool Logout();

        

        
    }
}
