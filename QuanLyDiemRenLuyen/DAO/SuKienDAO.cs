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
    public class SuKienDAO
    {
        private static SuKienDAO instance;

        public static SuKienDAO Instance {
            get
            {
                if(instance == null)
                {
                    instance = new SuKienDAO();
                }
                return instance;
            } 
            
            private set => instance = value; }


        public List<SuKien> getListSuKien()
        {
            List<SuKien> list = new List<SuKien>();

            string query = "SELECT * FROM SuKienRenLuyen";

            DataTable dataTable =  Database.Instanrce.ExectuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                SuKien suKien = new SuKien(row);
                list.Add(suKien);
            }

            return list;
        }

        public bool InsertSK(string name, DateTime ngayToChuc, int DiemCong)
        {
            int dataRow = 0;

            string query = "INSERT INTO SuKienRenLuyen (TenSuKien, NgayToChuc, DiemCong) VALUES (N'" + name + "', '" + ngayToChuc + "', " + DiemCong + ")";
            dataRow = Database.Instanrce.ExectuteNonQuery(query);

            if(dataRow > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSK(int maSK ,string name, DateTime ngayToChuc, int DiemCong)
        {
            int dataRow = 0;

            string query = "UPDATE SuKienRenLuyen SET TenSuKien = N'" + name + "' , NgayToChuc = '" + ngayToChuc + "' , DiemCong = " + DiemCong + "  WHERE MaSuKien = " + maSK + "";
            dataRow = Database.Instanrce.ExectuteNonQuery(query);

            if (dataRow > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteSK(int maSK)
        {
            int dataRow = 0;
            string queryTG = "DELETE FROM ThamGia WHERE MaSuKien = " + maSK + "";
            string querySL = "SELECT COUNT(*) FROM ThamGia WHERE MaSuKien = "+maSK+""; 
            string query = "DELETE FROM SuKienRenLuyen WHERE MaSuKien = "+maSK+"";

            int check = (int)Database.Instanrce.ExectuteScalar(querySL);

            if (check > 0)
            {
                DialogResult result = MessageBox.Show("Sự kiện này có sinh tham gia bạn có muốn xoá luôn sinh viên tham gia không", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Database.Instanrce.ExectuteNonQuery(queryTG);
                    Database.Instanrce.ExectuteNonQuery(query);
                    return true;
                }
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
