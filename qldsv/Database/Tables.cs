using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qldsv.Database
{
    class Lop
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string KhoaHoc { get; set; }
        public string MaKhoa { get; set; }

        public static List<Lop> GetAll(SqlConnection connection) {
            string query = "SELECT * FROM LOP";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Lop> lopList = new List<Lop>();
            while (reader.Read())
            {
                Lop lop = new Lop();
                lop.MaLop = reader.GetString(0);
                lop.TenLop = reader.GetString(1);
                lop.KhoaHoc = reader.GetString(2);
                lop.MaKhoa = reader.GetString(3);

                lopList.Add(lop);
            }
            reader.Close();
            return lopList;
        }
    }
    
    class DongHocPhi
    {
        public string MaSV { get; set; }
        public string NienKhoa { get; set; }
        public int HocKy { get; set; }
        public DateTime NgayDong { get; set; }
        public int SoTienDong { get; set; }

        public static List<DongHocPhi> GetAll(SqlConnection connection)
        {
            string query = "SELECT * FROM CT_DONGHOCPHI";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<DongHocPhi> ct_donghocphiList = new List<DongHocPhi>();
            while (reader.Read())
            {
                DongHocPhi ct_donghocphi = new DongHocPhi();
                ct_donghocphi.MaSV = reader.GetString(0);
                ct_donghocphi.NienKhoa = reader.GetString(1);
                ct_donghocphi.HocKy = reader.GetInt32(2);
                ct_donghocphi.NgayDong = reader.GetDateTime(3);
                ct_donghocphi.SoTienDong = reader.GetInt32(4);

                ct_donghocphiList.Add(ct_donghocphi);
            }
            reader.Close();
            return ct_donghocphiList;
        }
    }

    class DangKy
    {
        public int MaLopTinChi { get; set; }
        public string MaSV { get; set; }
        public int? DiemCC { get; set; }
        public float? DiemGK { get; set; }
        public float? DiemCK { get; set; }
        public bool? HuyDangKy { get; set; }

        public static List<DangKy> GetAll(SqlConnection connection)
        {
            string query = "SELECT * FROM DANGKY";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<DangKy> dangKyList = new List<DangKy>();
            while (reader.Read())
            {
                DangKy dangKy = new DangKy();
                dangKy.MaLopTinChi = reader.GetInt32(0);
                dangKy.MaSV = reader.GetString(1);
                if (!reader.IsDBNull(2)) dangKy.DiemCC = reader.GetInt32(2);
                if (!reader.IsDBNull(3)) dangKy.DiemGK = (float)reader.GetDouble(3);
                if (!reader.IsDBNull(4)) dangKy.DiemCK = (float)reader.GetDouble(4);
                if (!reader.IsDBNull(5)) dangKy.HuyDangKy = reader.GetBoolean(5);

                dangKyList.Add(dangKy);
            }
            reader.Close();
            return dangKyList;
        }
    }

    class GiangVien
    {
        public string MaGV { get; set; }
        public string MaKhoa { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string HocVi { get; set; }
        public string HocHam { get; set; }
        public string ChuyenMon { get; set; }

        public override string ToString()
        {
            return $"MaGV: {MaGV}, MaKhoa: {MaKhoa}, Ho: {Ho}, Ten: {Ten}, HocVi: {HocVi}, HocHam: {HocHam}, ChuyenMon: {ChuyenMon}";
        }


        public static List<GiangVien> GetAll(SqlConnection connection)
        {
            string query = "SELECT * FROM GIANGVIEN";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<GiangVien> giangVienList = new List<GiangVien>();
            while (reader.Read())
            {
                GiangVien giangVien = new GiangVien();
                giangVien.MaGV = reader.GetString(0);
                giangVien.MaKhoa = reader.GetString(1);
                giangVien.Ho = reader.GetString(2);
                giangVien.Ten = reader.GetString(3);
                if (!reader.IsDBNull(4)) giangVien.HocVi = reader.GetString(4);
                if (!reader.IsDBNull(5)) giangVien.HocHam = reader.GetString(5);
                if (!reader.IsDBNull(6)) giangVien.ChuyenMon = reader.GetString(6);

                giangVienList.Add(giangVien);
            }
            reader.Close();
            return giangVienList;
        }
    }

    class HocPhi
    {
        public string MaSV { get; set; }
        public string NienKhoa { get; set; }
        public int HocKy { get; set; }
        public int HocPhiAmount { get; set; }

        public override string ToString()
        {
            return string.Format("MaSV: {0}, NienKhoa: {1}, HocKy: {2}, HocPhiAmount: {3}",
                MaSV, NienKhoa, HocKy, HocPhiAmount);
        }

        public static List<HocPhi> GetAll(SqlConnection connection)
        {
            string query = "SELECT * FROM HOCPHI";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<HocPhi> hocPhiList = new List<HocPhi>();
            while (reader.Read())
            {
                HocPhi hocPhi = new HocPhi();
                hocPhi.MaSV = reader.GetString(0);
                hocPhi.NienKhoa = reader.GetString(1);
                hocPhi.HocKy = reader.GetInt32(2);
                hocPhi.HocPhiAmount = reader.GetInt32(3);

                hocPhiList.Add(hocPhi);
            }
            reader.Close();
            return hocPhiList;
        }
    }

    class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public override string ToString()
        {
            return $"{MaKhoa} - {TenKhoa}";
        }

        public static List<Khoa> GetAll(SqlConnection connection)
        {
            string query = "SELECT * FROM KHOA";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Khoa> khoaList = new List<Khoa>();
            while (reader.Read())
            {
                Khoa khoa = new Khoa();
                khoa.MaKhoa = reader.GetString(0);
                khoa.TenKhoa = reader.GetString(1);

                khoaList.Add(khoa);
            }
            reader.Close();
            return khoaList;
        }
    }

    class LopTinChi
    {
        public int MaLTC { get; set; }
        public string NienKhoa { get; set; }
        public int HocKy { get; set; }
        public string MaMH { get; set; }
        public int Nhom { get; set; }
        public string MaGV { get; set; }
        public string MaKhoa { get; set; }
        public int SoSVToiThieu { get; set; }
        public bool HuyLop { get; set; }

        public override string ToString()
        {
            return $"MaLTC: {MaLTC}, NienKhoa: {NienKhoa}, HocKy: {HocKy}, MaMH: {MaMH}, Nhom: {Nhom}, MaGV: {MaGV}, MaKhoa: {MaKhoa}, SoSVToiThieu: {SoSVToiThieu}, HuyLop: {HuyLop}";
        }


        public static List<LopTinChi> GetAll(SqlConnection connection)
        {
            string query = "SELECT * FROM LOPTINCHI";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<LopTinChi> lopTinChiList = new List<LopTinChi>();
            while (reader.Read())
            {
                LopTinChi lopTinChi = new LopTinChi();
                lopTinChi.MaLTC = reader.GetInt32(0);
                lopTinChi.NienKhoa = reader.GetString(1);
                lopTinChi.HocKy = reader.GetInt32(2);
                lopTinChi.MaMH = reader.GetString(3);
                lopTinChi.Nhom = reader.GetInt32(4);
                lopTinChi.MaGV = reader.GetString(5);
                lopTinChi.MaKhoa = reader.GetString(6);
                lopTinChi.SoSVToiThieu = reader.GetInt32(7);
                lopTinChi.HuyLop = reader.GetBoolean(8);

                lopTinChiList.Add(lopTinChi);
            }
            reader.Close();
            return lopTinChiList;
        }
    }

    class MonHoc
    {
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTietLT { get; set; }
        public int SoTietTH { get; set; }

        public static List<MonHoc> GetAll(SqlConnection connection)
        {
            string query = "SELECT * FROM MONHOC";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<MonHoc> monHocList = new List<MonHoc>();
            while (reader.Read())
            {
                MonHoc monHoc = new MonHoc();
                monHoc.MaMH = reader.GetString(0);
                monHoc.TenMH = reader.GetString(1);
                monHoc.SoTietLT = reader.GetInt32(2);
                monHoc.SoTietTH = reader.GetInt32(3);

                monHocList.Add(monHoc);
            }
            reader.Close();
            return monHocList;
        }

        public override string ToString()
        {
            return $"{MaMH} - {TenMH} ({SoTietLT}/{SoTietTH})";
        }
    }

    class SinhVien
    {
        public string MaSV { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string MaLop { get; set; }
        public bool DangHoc { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{MaSV} - {Ho} {Ten} ({(GioiTinh ? "Nam" : "Nữ")}), {DiaChi}, " +
                   $"{(NgaySinh.HasValue ? NgaySinh.Value.ToString("dd/MM/yyyy") : "")}, {MaLop}, " +
                   $"{(DangHoc ? "Đang học" : "Nghỉ học")}, {Password}";
        }

        public static List<SinhVien> GetAll(SqlConnection connection)
        {
            string query = "SELECT * FROM SINHVIEN";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<SinhVien> sinhVienList = new List<SinhVien>();
            while (reader.Read())
            {
                SinhVien sinhVien = new SinhVien();
                sinhVien.MaSV = reader.GetString(0);
                sinhVien.Ho = reader.GetString(1);
                sinhVien.Ten = reader.GetString(2);
                sinhVien.GioiTinh = reader.GetBoolean(3);
                sinhVien.DiaChi = reader.IsDBNull(4) ? null : reader.GetString(4);
                sinhVien.NgaySinh = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5);
                sinhVien.MaLop = reader.GetString(6);
                sinhVien.DangHoc = reader.GetBoolean(7);
                sinhVien.Password = reader.IsDBNull(8) ? null : reader.GetString(8);

                sinhVienList.Add(sinhVien);
            }
            reader.Close();
            return sinhVienList;
        }
    }

}
