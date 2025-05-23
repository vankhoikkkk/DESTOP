using QuanLyDiemRenLuyen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemRenLuyen.DAO
{
    public class TongDsDAO
    {
        private static TongDsDAO instance;

        public static TongDsDAO Instance { get { if (instance == null) instance = new TongDsDAO(); return instance; } private set => instance = value; }


        public List<TongDS> getListDS()
        {
            List<TongDS> list = new List<TongDS>();

            string query = "SELECT sv.MaSV, sv.HoTen,  ISNULL(SUM(sk.DiemCong), 0) as TongDiemRenLuyen FROM SinhVien sv LEFT JOIN ThamGia tg ON sv.MaSV = tg.MaSV\r\nLEFT JOIN SuKienRenLuyen sk ON tg.MaSuKien = sk.MaSuKien GROUP BY sv.MaSV, sv.HoTen\r\nORDER BY sv.MaSV;";
            DataTable dt = Database.Instanrce.ExectuteQuery(query);

            foreach(DataRow dr in dt.Rows)
            {
                TongDS t = new TongDS(dr);
                list.Add(t);
            }
            return list;
        }
    }
}
