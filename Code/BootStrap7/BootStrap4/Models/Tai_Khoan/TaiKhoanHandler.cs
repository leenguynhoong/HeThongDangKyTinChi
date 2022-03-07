using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootStrap4.Models.Tai_Khoan;

namespace BootStrap4.Models.Tai_Khoan
{
    public class TaiKhoanHandler:TaiKhoanInterface
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

        public IEnumerable<TaiKhoanModel> GetListTK()
        {
            dtbtt1Entities db = new dtbtt1Entities();
            var list = db.TaiKhoans.ToList();
            return ConvertList(list);
        }

        public TaiKhoanModel GetTaiKhoan(string tenTK)
        {
            throw new NotImplementedException();
        }

        

        public TaiKhoanModel GetTaiKhoanByTK(string tenTK)
        {
            throw new NotImplementedException();
        }

        public TaiKhoanModel Create(string tenTk, string matKhau, string quyen, string nguoiTao, DateTime ngayTao)
        {
            dtbtt1Entities db = new dtbtt1Entities();
            TaiKhoanModel tkModel = new TaiKhoanModel();
            tkModel.TenTaiKhoan = tenTk;
            tkModel.MatKhau = matKhau;
            tkModel.Quyen = quyen;
            tkModel.NguoiTao = nguoiTao;
            tkModel.NgayTao = ngayTao;
            db.TaiKhoans.Add(ConvertModelToEF(tkModel));
            db.SaveChanges();
            return tkModel;
        }

        public TaiKhoanModel Update(string tenTk, string matKhau, string quyen)
        {
            dtbtt1Entities db = new dtbtt1Entities();
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.TenTaiKhoan == tenTk);
            if (tk != null)
            {
                TaiKhoanModel tkModel = new TaiKhoanModel();
                tkModel.TenTaiKhoan = tenTk;
                tkModel.MatKhau = matKhau;
                tkModel.Quyen = quyen;
                tk = ConvertModelToEF(tkModel);
                db.SaveChanges();
                return tkModel;
            }
            else
            {
                return null;
            }
        }
        public TaiKhoanModel Delete(string tenTk)
        {
            dtbtt1Entities db = new dtbtt1Entities();
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.TenTaiKhoan == tenTk);
            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
            return ConvertEFToModel(tk);
        }
        private TaiKhoanModel ConvertEFToModel(TaiKhoan taiKhoan)
        {
            try
            {
                TaiKhoanModel result = new TaiKhoanModel();
                result.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                result.MatKhau = taiKhoan.MatKhau;
                if(taiKhoan.Quyen == false)
                {
                    result.Quyen = "admin";
                }else
                {
                    result.Quyen = "user";
                }
                result.HoTen = taiKhoan.HoTen;
                result.NguoiTao = taiKhoan.NguoiTao;
                result.NguoiSua = taiKhoan.NguoiSua;
                result.NgaySua = taiKhoan.NgaySua;
                result.NgayTao = taiKhoan.NgayTao;
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private TaiKhoan ConvertModelToEF(TaiKhoanModel taiKhoanModel)
        {
            try
            {
                TaiKhoan result = new TaiKhoan();
                result.TenTaiKhoan = taiKhoanModel.TenTaiKhoan;
                result.MatKhau = taiKhoanModel.MatKhau;
                if (taiKhoanModel.Quyen == "admin")
                {
                    result.Quyen =  false;
                }
                else
                {
                    result.Quyen = true;
                } 
                result.HoTen = taiKhoanModel.HoTen;
                result.NguoiTao = taiKhoanModel.NguoiTao;
                result.NguoiSua = taiKhoanModel.NguoiSua;
                result.NgaySua = taiKhoanModel.NgaySua;
                result.NgayTao = taiKhoanModel.NgayTao;
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private List<TaiKhoanModel> ConvertList(List<TaiKhoan> LTK)
        {
            try
            {
                string q="";
                List<TaiKhoanModel> LTKM = new List<TaiKhoanModel>();
                foreach (TaiKhoan TK in LTK)
                {
                    if (TK.Quyen == false)
                    {
                        q = "admin";
                    }
                    else
                    {
                        q = "user";
                    }
                    LTKM.Add(new TaiKhoanModel()
                    {
                        TenTaiKhoan = TK.TenTaiKhoan,
                        MatKhau = TK.MatKhau,
                        Quyen = q,
                        HoTen = TK.HoTen,
                        NguoiTao = TK.NguoiTao,
                        NguoiSua = TK.NguoiSua,
                        NgaySua = TK.NgaySua,
                        NgayTao = TK.NgayTao,
                });
                }
                return LTKM;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
   
}