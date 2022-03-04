using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrap4.Models.Dang_Ky_Tin
{
    public class DangKyTinHandler:DangKyTinInterface
    {
        
        public dtbtt1Entities DB()
        {
            dtbtt1Entities db = new dtbtt1Entities();
            return db;
        }
        public DangKyTinHandler()
        {
            DangKyTin dangKyTin = new DangKyTin();
        }
      
        public IEnumerable<DangKyTinModel> GetDangKyTin(string tenTK)
        {
            List<DangKyTin> ldkt = DB().DangKyTins.Where(x => x.TenTaiKhoan == tenTK).ToList();
            var ldktm = ConvertListModel(ldkt);
            return ldktm;
        }
        public DangKyTinModel GetDKTById(int id)
        {
            throw new NotImplementedException();
        }

        public DangKyTinModel CreateDKT(int maMon, string tenTK, string NguoiTao, DateTime NgayTao)
        {
            DangKyTinModel dangKyTinModel = new DangKyTinModel();
            dangKyTinModel.TenTaiKhoan = tenTK;
            dangKyTinModel.MaMon = maMon;
            dangKyTinModel.NgayTao = NgayTao;
            dangKyTinModel.NguoiTao = NguoiTao;
            if (dangKyTinModel != null)
            {
                dtbtt1Entities db = new dtbtt1Entities();
                db.DangKyTins.Add(ConvertModelToEF(dangKyTinModel));
                db.SaveChanges();
                return dangKyTinModel;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<DangKyTinModel> FilterDKT(string tenTK, string searchString)
        {
            try
            {
                int id = int.Parse(searchString);
                List<DangKyTin> ldkt = DB().DangKyTins.Where(x => x.MaMon == id && x.TenTaiKhoan == tenTK).ToList();
                var ldktm = ConvertListModel(ldkt);
                return ldktm;
            }
            catch(Exception e)
            {
                return null;
            }
            
        }

        public bool DeleteDKT(int maMon, string tenTK)
        {
            try
            {
                dtbtt1Entities db = new dtbtt1Entities();
                var del = db.DangKyTins.SingleOrDefault(p => p.MaMon == maMon && p.TenTaiKhoan == tenTK);
                if (del == null)
                {
                    return false;
                }
                else
                {
                    db.DangKyTins.Remove(del);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public DangKyTinModel Save()
        {
            throw new NotImplementedException();
        }
        public DangKyTinModel ConvertEFToModel(DangKyTin dkt)
        {
            try
            {
                DangKyTinModel dktm = new DangKyTinModel();
                dktm.MaDangKy = dkt.MaDangKy;
                dktm.MaMon = dkt.MaMon;
                dktm.TenTaiKhoan = dkt.TenTaiKhoan;
                dktm.NguoiTao = dkt.NguoiTao;
                dktm.NguoiSua = dkt.NguoiSua;
                dktm.NgaySua = dkt.NgaySua;
                dktm.NgayTao = dkt.NgayTao;
                dktm.TenMon = dkt.MonHoc.TenMon;
                return dktm;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public DangKyTin ConvertModelToEF(DangKyTinModel dktm)
        {
            try
            {
                DangKyTin dkt = new DangKyTin();
                dkt.MaDangKy = dktm.MaDangKy  ;
                dkt.MaMon = dktm.MaMon  ;
                dkt.TenTaiKhoan = dktm.TenTaiKhoan  ;
                dkt.NguoiTao = dktm.NguoiTao  ;
                dkt.NguoiSua =  dktm.NguoiSua  ;
                dkt.NgaySua = dktm.NgaySua  ;
                dkt.NgayTao = dktm.NgayTao  ;
                return dkt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<DangKyTinModel> ConvertListModel(List<DangKyTin> ldkt)
        {
            try
            {
                List<DangKyTinModel> ldktm = new List<DangKyTinModel>();
                foreach (var item in ldkt)
                {
                    ldktm.Add(new DangKyTinModel()
                    {
                        MaDangKy = item.MaDangKy,
                        MaMon = item.MaMon,
                        TenTaiKhoan = item.TenTaiKhoan,
                        NguoiTao = item.NguoiTao,
                        NguoiSua = item.NguoiSua,
                        NgaySua = item.NgaySua,
                        NgayTao = item.NgayTao,
                        TenMon = item.MonHoc.TenMon
                    });
                }
                return ldktm;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}