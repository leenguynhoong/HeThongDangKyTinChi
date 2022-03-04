using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootStrap4.Models;
using System.Data.Entity;
using BootStrap4.Models.Dang_Ky_Tin;

namespace BootStrap4.Models.Mon_Hoc
{
    public class MonHocHandler : MonHocInterface
    {
        MonHocModel _monHocModel = null;
        public MonHocHandler()
        {
            _monHocModel = new MonHocModel();
        }
        public IEnumerable<MonHocModel> GetMonHocs(string tenTK)
        {
            try
            {
                List<DangKyTin> listdkt = DB().DangKyTins.ToList();
                List<MonHoc> listmh = DB().MonHocs.ToList();
                List<MonHocModel> listMhModel = ConvertListMH(listmh);
                var querry = listMhModel.Select(x => x.MaMon).Except(listdkt.Where(s => s.TenTaiKhoan == tenTK).Select(y => y.MaMon));
                var mk = listMhModel.Where(x => querry.Contains(x.MaMon));
                return mk;
            }
            catch(Exception e)
            {
                return null;
            }
            
        }
        public MonHocModel GetMonHocById(int id)
        {
            try
            {
                return ConvertEFToModel(DB().MonHocs.SingleOrDefault(x => x.MaMon == id));
            }
            catch(Exception e)
            {
                return null;
            }
            
        }
        public dtbtt1Entities DB()
        {
            dtbtt1Entities db = new dtbtt1Entities();
            return db;
        }
        public MonHocModel CreateSubject(int maMon, string tenMon, string nguoiTao, DateTime ngayTao)
        {
            dtbtt1Entities db = new dtbtt1Entities();

            _monHocModel.MaMon = maMon;
            _monHocModel.TenMon = tenMon;
            _monHocModel.NguoiTao = nguoiTao;
            _monHocModel.NgayTao = ngayTao;
            db.MonHocs.Add(ConvertModelToEF(_monHocModel));
            db.SaveChanges();
            return _monHocModel;
        }

        public bool DeleteSubject(int maMon)
        {
            dtbtt1Entities db = new dtbtt1Entities();
            var del = db.MonHocs.SingleOrDefault(p => p.MaMon == maMon);
            var delete = ConvertEFToModel(del);
            if (delete == null)
            {
                return false;
            }else
            {
                var finddkt = db.DangKyTins.Where(p => p.MaMon == maMon).ToList();
                var deldkt = new DangKyTinHandler().ConvertListModel(finddkt);
                if (deldkt != null)
                {
                    foreach (var item in deldkt)
                    {
                        var delitem = new DangKyTinHandler().ConvertModelToEF(item);
                        db.DangKyTins.Remove(delitem);

                    }
                    db.SaveChanges();
                }
                db.MonHocs.Remove(del);
                db.SaveChanges();
                return true;
            }
        }
        public MonHocModel UpdateSubject(int maMon, string tenMon, string nguoiTao, DateTime ngaySua)
        {
            try
            {
                dtbtt1Entities db = new dtbtt1Entities();
                MonHoc monHoc = db.MonHocs.SingleOrDefault(x => x.MaMon == maMon);
                if (monHoc != null)
                {
                    monHoc.TenMon = tenMon;
                    monHoc.NguoiSua = nguoiTao;
                    monHoc.NgaySua = ngaySua;
                    db.SaveChanges();
                    return ConvertEFToModel(monHoc);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                return null;
            }
            
        }
        public MonHocModel Save()
        {
            throw new NotImplementedException();
        }
   
        public IEnumerable<MonHocModel> FilterSubject(string tenTK,string searchString)
        {
            try
            {
                return GetMonHocs(tenTK).Where(x => x.TenMon.Contains(searchString)).ToList();
            }
            catch(Exception e)
            {
                return null;
            }
           
        }

        public string getNameSubject(int maMon)
        {
            
            try
            {
                return DB().MonHocs.SingleOrDefault(x => x.MaMon == maMon).TenMon;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private MonHocModel ConvertEFToModel(MonHoc monHoc)
        {
            try
            {
                MonHocModel result = new MonHocModel();
                result.MaMon    = monHoc.MaMon;
                result.TenMon   = monHoc.TenMon;
                result.NguoiTao = monHoc.NguoiTao;
                result.NguoiSua = monHoc.NguoiSua;
                result.NgaySua  = monHoc.NgaySua;
                result.NgayTao  = monHoc.NgayTao;
                return result;
            }catch(Exception e)
            {
                return null;
            }
        }

        private MonHoc ConvertModelToEF(MonHocModel monHocModel)
        {
            try
            {
                MonHoc result = new MonHoc();
                result.MaMon = monHocModel.MaMon;
                result.TenMon = monHocModel.TenMon;
                result.NguoiTao = monHocModel.NguoiTao;
                result.NguoiSua = monHocModel.NguoiSua;
                result.NgaySua = monHocModel.NgaySua;
                result.NgayTao = monHocModel.NgayTao;
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private List<MonHocModel> ConvertListMH(List<MonHoc> LMH)
        {
            try
            {
                List<MonHocModel> LMHM = new List<MonHocModel>();
                foreach (MonHoc mh in LMH)
                {
                    LMHM.Add(new MonHocModel() { MaMon = mh.MaMon, TenMon = mh.TenMon, NguoiTao = mh.NguoiTao,
                                                 NguoiSua = mh.NguoiSua, NgaySua = mh.NgaySua}); 
                }
                return LMHM;
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}



