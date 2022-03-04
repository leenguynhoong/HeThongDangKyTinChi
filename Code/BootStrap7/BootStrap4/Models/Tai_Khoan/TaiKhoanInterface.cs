using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootStrap4.Models.Tai_Khoan
{
    interface TaiKhoanInterface
    {
        IEnumerable<TaiKhoan> TaiKhoan();
        TaiKhoan GetTaiKhoanById(int taiKhoanId);

        void Login(TaiKhoan taiKhoan);

        void Logout(TaiKhoan taiKhoan);

        
    }
}
