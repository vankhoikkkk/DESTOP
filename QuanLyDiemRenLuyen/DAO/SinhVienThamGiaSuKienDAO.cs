using QuanLyDiemRenLuyen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemRenLuyen.DAO
{
    public class SinhVienThamGiaSuKienDAO
    {
        private static SinhVienThamGiaSuKienDAO instance;

        public static SinhVienThamGiaSuKienDAO Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new SinhVienThamGiaSuKienDAO();
                }
                return instance;
            }
            private set => instance = value; 
        }

        public List<SinhVienThamGiaSuKien> getListSVTGSK()
        {
            List<SinhVienThamGiaSuKien> list = new List<SinhVienThamGiaSuKien> ();

            string query = "SELECT sv.MaSV, sk.MaSuKien , sv.HoTen, sk.TenSuKien, NgayToChuc, DiemCong FROM SinhVien sv JOIN ThamGia tg ON sv.MaSV = tg.MaSV JOIN  SuKienRenLuyen sk ON tg.MaSuKien = sk.MaSuKien ORDER BY sv.MaSV;";

            DataTable dataTable = Database.Instanrce.ExectuteQuery(query);
            foreach(DataRow data in dataTable.Rows)
            {
                SinhVienThamGiaSuKien sv = new SinhVienThamGiaSuKien(data);
                list.Add(sv);
            }

            return list;
        }

        public bool InsertSVTG(int msv, int msk)
        {
            int dataRow = 0;
            string querySl = "SELECT COUNT(*) FROM ThamGia WHERE MaSV = " + msv + " AND MaSuKien = " + msk + "";
            string query = "INSERT INTO ThamGia (MaSV, MaSuKien) VALUES (" + msv + ", " + msk + ")";
            int check = (int)Database.Instanrce.ExectuteScalar(querySl);
            if (check > 0)
            {
                MessageBox.Show("Sinh viên này đã tham sự kiện này rồi");
                
            }else
            {
                dataRow = Database.Instanrce.ExectuteNonQuery(query);
                if(dataRow > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteSVTG(int msv, int msk)
        {
            int dataRow = 0;
            string querySl = "SELECT COUNT(*) FROM ThamGia WHERE MaSV = " + msv + " AND MaSuKien = " + msk + "";
            string query = "DElETE FROM THAMGIA WHERE MaSV = " + msv + " AND MaSuKien = " + msk + "";
            int check = (int)Database.Instanrce.ExectuteScalar(querySl);
            if (check <= 0)
            {
                MessageBox.Show("Sinh viên này chưa tham gia sự kiện này");

            }
            else
            {
                dataRow = Database.Instanrce.ExectuteNonQuery(query);
                if (dataRow > 0)
                {
                    return true;
                }
            }
            return false;

        }

        
    }
}
