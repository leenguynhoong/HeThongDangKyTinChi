using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootStrap4.Models.Mon_Hoc
{
    interface MonHocInterface
    {
        IEnumerable<MonHocModel> GetMonHocs(string tenTK);
        MonHocModel GetMonHocById(int monHoc);
        MonHocModel CreateSubject(int MaMon, string TenMon, string NguoiTao, DateTime NgayTao);
        MonHocModel UpdateSubject(int MaMon, string TenMon, string NguoiTao, DateTime NgayTao);
        IEnumerable<MonHocModel> FilterSubject(string tenTK,string searchString);
        bool DeleteSubject(int monHocID);
        string getNameSubject(int maMon);
        MonHocModel Save();
        


    }
}
