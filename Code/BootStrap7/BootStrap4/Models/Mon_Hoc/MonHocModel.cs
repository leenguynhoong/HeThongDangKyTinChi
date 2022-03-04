using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrap4.Models.Mon_Hoc
{
    public class MonHocModel:MonHoc
    {
        public MonHocModel()
        {
        }
        


        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<System.DateTime> NgaySua { get; set; }
        public string NguoiTao { get; set; }
        public string NguoiSua { get; set; }
        public List<MonHocModel> ListMonHocModel
        {   get;
            set;
        }
        public virtual ICollection<DangKyTin> DangKyTins { get; set; }


    }
    public class BaseModel : MonHocModel
    {
        public string FilterObject { get; set; }
        public string FilterText { get; set; }
        public List<MonHoc> ListMonHoc { get; set; }
        public MonHoc monHoc { get; set; }

    }
}
    