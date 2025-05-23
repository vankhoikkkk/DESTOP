using Microsoft.SqlServer.Server;
using QuanLyDiemRenLuyen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace QuanLyDiemRenLuyen.DAO
{
    public class SinhVienDAO
    {
        private static SinhVienDAO instance;

        public static SinhVienDAO Instance { 
            
            get
            {
                if (SinhVienDAO.instance == null)
                {
                    SinhVienDAO.instance = new SinhVienDAO();
                }
                return SinhVienDAO.instance;
            }
            
            private set => instance = value; }


        public List<SinhVien> getListSV()
        {
            List<SinhVien> listSV = new List<SinhVien> ();

            string query = "SELECT * FROM SINHVIEN";
            DataTable dataTable = Database.Instanrce.ExectuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                SinhVien sv = new SinhVien(row);
                listSV.Add(sv);
            }
            return listSV;
        }

        public bool InsertSV(string name)
        {
            int dataRow = 0;
            string query = "INSERT INTO SinhVien (HoTen) VALUES (N'" + name + "')";
            dataRow = Database.Instanrce.ExectuteNonQuery(query);
            if (dataRow > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSV(int MSV, string name)
        {
            int dataRow = 0;
            string query = "Update SinhVien SET HoTen = N'"+name+"' WHERE MaSV = "+MSV+"";
            dataRow = Database.Instanrce.ExectuteNonQuery(query);
            if (dataRow > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteSV(int MSV)
        {
            int dataRow = 0;
            int check = 0;
            string query = "DELETE FROM SinhVien WHERE MaSV = " + MSV + "";
            string queryTG = "DELETE FROM ThamGia WHERE MaSV = " + MSV + "";
            string queryCheck = "SELECT COUNT(*) FROM ThamGia WHERE MaSV = " + MSV + "";
            check = (int)Database.Instanrce.ExectuteScalar(queryCheck);

            if (check > 0)
            {
                DialogResult result = MessageBox.Show(
               "Sinh viên này đang tham gia sự kiện.\nBạn có muốn xóa luôn cả dữ liệu tham gia không?",
               "Xác nhận", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Database.Instanrce.ExectuteNonQuery(queryTG);
                    dataRow = Database.Instanrce.ExectuteNonQuery(query);
                    if(dataRow > 0)
                    {
                        return true;
                    }

                }
            }else
            {
                dataRow = Database.Instanrce.ExectuteNonQuery(query);
                if(dataRow > 0)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            return false;
            
        }
    }
}
