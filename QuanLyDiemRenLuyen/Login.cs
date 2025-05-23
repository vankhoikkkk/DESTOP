using QuanLyDiemRenLuyen.DAO;
using QuanLyDiemRenLuyen.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemRenLuyen
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonDN_Click(object sender, EventArgs e)
        {
            string tk = textBoxTK.Text;
            string pass = textBoxPass.Text;
            bool check = AccountDAO.Instance.checkTaiKhoan(tk, pass);
            Account acc = AccountDAO.Instance.getTaiKhoan(tk, pass);
            if (check)
            {
                QuanLySinhVien ql = new QuanLySinhVien(acc);
                this.Hide();
                ql.ShowDialog();
                this.Show();
            }else
            {
                MessageBox.Show("Thông tin tài khoản và mật khẩu không chính xác");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắc thoát ?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
