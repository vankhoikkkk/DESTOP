using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemRenLuyen.Model
{
    public class SinhVienThamGiaSuKien
    {
        private int msv;
        private int msk;
        private string nameSV;
        private string nameSK;
        private DateTime ngayToChuc;
        private int diemCong;

        public SinhVienThamGiaSuKien(DataRow data)
        {
            this.msv = (int)data["MaSV"];
            this.msk = (int)data["MaSuKien"];
            this.nameSV = (string)data["HoTen"];
            this.nameSK = (string)data["TenSuKien"];
            this.ngayToChuc = (DateTime)data["NgayToChuc"];
            this.diemCong = (int)data["DiemCong"];
        }

        public int Msv { get => msv; set => msv = value; }
        public int Msk { get => msk; set => msk = value; }
        public string NameSV { get => nameSV; set => nameSV = value; }
        public string NameSK { get => nameSK; set => nameSK = value; }
        public DateTime NgayToChuc { get => ngayToChuc; set => ngayToChuc = value; }
        public int DiemCong { get => diemCong; set => diemCong = value; }
    }
}
