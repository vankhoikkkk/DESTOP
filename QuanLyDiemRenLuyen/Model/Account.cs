using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QuanLyDiemRenLuyen.Model
{
    public class Account
    {
        private int idTK;
        private string tenTK;
        private string passTK;
        private int isAdmin;


        public Account(DataRow data) {
            this.idTK = (int)data["id_TK"];
            this.tenTK = (string)data["tenTK"];
            this.passTK = (string)data["pass"];
            this.isAdmin = (int)data["isAdmin"];
        }

        public int IdTK { get => idTK; set => idTK = value; }
        public string TenTK { get => tenTK; set => tenTK = value; }
        public string PassTK { get => passTK; set => passTK = value; }
        public int IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
