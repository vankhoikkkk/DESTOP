using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemRenLuyen.Model
{
    public class SuKien
    {
        private int maSuKien;
        private string nameSK;
        private DateTime ngayToChuc;
        private int diem;

        public SuKien(DataRow data)
        {
            this.maSuKien = (int)data["MaSuKien"];
            this.nameSK = (string)data["TenSuKien"];
            this.ngayToChuc = (DateTime)data["NgayToChuc"];
            this.Diem = (int)data["DiemCong"];
        }

        public int MaSuKien { get => maSuKien; set => maSuKien = value; }
        public string NameSK { get => nameSK; set => nameSK = value; }
        public DateTime NgayToChuc { get => ngayToChuc; set => ngayToChuc = value; }
        public int Diem { get => diem; set => diem = value; }
    }
}
