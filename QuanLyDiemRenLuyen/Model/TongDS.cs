using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemRenLuyen.Model
{
    public class TongDS
    {
        private int maSinhVien;
        private string nameSinhVien;
        private int diemRenLuyen;

        public TongDS (DataRow row)
        {
            this.maSinhVien = (int)row["MaSV"];
            this.nameSinhVien= (string)row["HoTen"];
            this.diemRenLuyen = (int)row["TongDiemRenLuyen"];
        }
        public int MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string NameSinhVien { get => nameSinhVien; set => nameSinhVien = value; }
        public int DiemRenLuyen { get => diemRenLuyen; set => diemRenLuyen = value; }
    }
}
