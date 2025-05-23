using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemRenLuyen.Model
{
    public class SinhVien
    {
        private int MSV;
        private string nameSV;

        public SinhVien(DataRow data)
        {
            this.MSV = (int)data["MaSV"];
            this.nameSV = (string)data["HoTen"];
        }

        public int MSV1 { get => MSV; set => MSV = value; }
        public string NameSV { get => nameSV; set => nameSV = value; }
    }
}
