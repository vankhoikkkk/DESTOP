using QuanLyDiemRenLuyen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemRenLuyen.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance { get
            {
                if(instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            } 
            
            private set => instance = value; }

        public Account getTaiKhoan(string taikhoan, string matkhau)
        {
            Account account = null;

            string query = "SELECT * FROM Account WHERE tenTK = '"+taikhoan+"' AND pass = '"+matkhau+"'";
            DataTable data = Database.Instanrce.ExectuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                account = new Account(row);
            }

            return account;
        }

        public bool checkTaiKhoan(string taikhoan, string matkhau)
        {
            bool check = false;
            string query = "SELECT * FROM Account WHERE tenTK = '" + taikhoan + "' AND pass = '" + matkhau + "'";
            DataTable data = Database.Instanrce.ExectuteQuery(query);
            if (data.Rows.Count > 0)
            {
                check = true;
            }

            return check;
        }
    } 
}
