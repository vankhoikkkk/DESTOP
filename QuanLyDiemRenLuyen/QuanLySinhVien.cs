using QuanLyDiemRenLuyen.Model;
using QuanLyDiemRenLuyen.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemRenLuyen
{
    public partial class QuanLySinhVien : Form
    {

        private Account account;
        
        BindingSource listSV = new BindingSource() ;
        BindingSource listSK = new BindingSource() ;
        BindingSource listSVTG = new BindingSource() ;

        //tbNameSV.DataBindings.Clear(); các xoá một binding 
        public QuanLySinhVien(Account acc)
        {
            account = acc;
            InitializeComponent();
            load();
            AdddataBindingSinhVien();
            AddDataBindingSK();
            AddDataBindingSVTG();
            tabC.SelectedTab = pageDanhDiemRenLuyen;
        }
        #region Methon
        void load()
        {
            loadListSV();
            loadListSuKien();
            loadListSVTG();
            loadTongDS();
        }

        public void loadListSV()
        {
            listSV.DataSource = SinhVienDAO.Instance.getListSV();
            dataGridViewSinhVien.DataSource = listSV;
        }

        private void AdddataBindingSinhVien()
        {
            tbIdSV.DataBindings.Add(new Binding("Text", dataGridViewSinhVien.DataSource, "MSV1"));
            tbNameSV.DataBindings.Add(new Binding("Text", dataGridViewSinhVien.DataSource, "NameSV", true, DataSourceUpdateMode.Never));
        }

        private void AddDataBindingSK()
        {
            tbMaSuKien.DataBindings.Add(new Binding("Text", dataGridViewSK.DataSource, "MaSuKien"));
            tbNameSK.DataBindings.Add(new Binding("Text", dataGridViewSK.DataSource, "NameSK", true, DataSourceUpdateMode.Never));
            tbDiemCong.DataBindings.Add(new Binding("Text", dataGridViewSK.DataSource, "Diem", true, DataSourceUpdateMode.Never));
            tbDateSK.DataBindings.Add(new Binding("Text", dataGridViewSK.DataSource, "NgayToChuc", true, DataSourceUpdateMode.Never));
        }

        private void loadListSuKien()
        {
            listSK.DataSource = SuKienDAO.Instance.getListSuKien();
            dataGridViewSK.DataSource = listSK;
        }

        private void loadListSVTG()
        {
            listSVTG.DataSource = SinhVienThamGiaSuKienDAO.Instance.getListSVTGSK();
            dataGridViewQLSK.DataSource = listSVTG;
            comboBoxSV.DataSource = SinhVienDAO.Instance.getListSV();
            comboBoxSV.DisplayMember = "NameSV";
            comboBoxSV.ValueMember = "MSV1";
            comboBoxSK.DataSource = SuKienDAO.Instance.getListSuKien();
            comboBoxSK.DisplayMember = "NameSK";
            comboBoxSK.ValueMember = "MaSuKien";
        }

        private void AddDataBindingSVTG()
        {
            comboBoxSV.DataBindings.Add(new Binding("SelectedValue", dataGridViewQLSK.DataSource, "Msv", true, DataSourceUpdateMode.Never));
            comboBoxSK.DataBindings.Add(new Binding("SelectedValue", dataGridViewQLSK.DataSource, "Msk", true, DataSourceUpdateMode.Never));
        }

        private void loadTongDS()
        {
            dataGridViewShowFull.DataSource = TongDsDAO.Instance.getListDS();
        }

        #endregion

        #region Event
        private void btnAddSV_Click(object sender, EventArgs e)
        {
            string name = tbNameSV.Text;
            bool check = SinhVienDAO.Instance.InsertSV(name);
            if (check)
            {
                MessageBox.Show("Thêm thành công sinh viên " + name + " ");
            }else
            {
                MessageBox.Show("Thêm thất bại");
            }
            load();
        }

        private void btnEditSV_Click(object sender, EventArgs e)
        {
            string name = tbNameSV.Text;
            int id = Convert.ToInt32(tbIdSV.Text);
            bool check = SinhVienDAO.Instance.UpdateSV(id, name);
            if (check)
            {
                MessageBox.Show("Sửa thành công sinh viên " + name + " ");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            load();
        }

        private void btnDeleteSV_Click(object sender, EventArgs e)
        {
            string name = tbNameSV.Text;
            int id = Convert.ToInt32(tbIdSV.Text);
            bool check = SinhVienDAO.Instance.DeleteSV(id);
            if (check)
            {
                MessageBox.Show("Xoá thành công sinh viên " + name + " ");
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
            load();
        }

        private void btnShowSV_Click(object sender, EventArgs e)
        {
            load();
        }


        private void btnAddSK_Click(object sender, EventArgs e)
        {
            string name = tbNameSK.Text;
            DateTime date = DateTime.Parse(tbDateSK.Text);
            int diem = Convert.ToInt32(tbDiemCong.Text);
            bool check = SuKienDAO.Instance.InsertSK(name, date, diem);
            if (check)
            {
                MessageBox.Show("thành công sự kiện " + name + " ");
            }
            else
            {
                MessageBox.Show("thất bại");
            }
            load();
        }

        private void btnEditSK_Click(object sender, EventArgs e)
        {
            int maSK = Convert.ToInt32(tbMaSuKien.Text);
            string name = tbNameSK.Text;
            DateTime date = DateTime.Parse(tbDateSK.Text);
            int diem = Convert.ToInt32(tbDiemCong.Text);
            bool check = SuKienDAO.Instance.UpdateSK(maSK, name, date, diem);
            if (check)
            {
                MessageBox.Show("thành công sự kiện " + name + " ");
            }
            else
            {
                MessageBox.Show("thất bại");
            }
            load();
        }

        private void btnDeleteSK_Click(object sender, EventArgs e)
        {
            int maSK = Convert.ToInt32(tbMaSuKien.Text);
            string name = tbNameSK.Text;
            bool check = SuKienDAO.Instance.DeleteSK(maSK);
            if (check)
            {
                MessageBox.Show("thành công sự kiện " + name + " ");
            }
            else
            {
                MessageBox.Show("thất bại");
            }
            load();
        }

        private void btnShowSK_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnAddQLSK_Click(object sender, EventArgs e)
        {
            int idSK = (int)comboBoxSK.SelectedValue;
            int idMsv = (int)comboBoxSV.SelectedValue;

            bool check = SinhVienThamGiaSuKienDAO.Instance.InsertSVTG(idMsv, idSK);
            if (check)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            load();
        }

        private void btnDeleteQLSK_Click(object sender, EventArgs e)
        {
            int idSK = (int)comboBoxSK.SelectedValue;
            int idMsv = (int)comboBoxSV.SelectedValue;

            bool check = SinhVienThamGiaSuKienDAO.Instance.DeleteSVTG(idMsv, idSK);
            if (check)
            {
                MessageBox.Show("Xoá thành công");
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
            load();
        }

        private void btnShowQLSK_Click(object sender, EventArgs e)
        {
            load();
        }



        #endregion

        private void tabC_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (account.IsAdmin != 1)
            {

                if (e.TabPage == pageQuanLySinhVien || e.TabPage == pageQuanLyThamGia || e.TabPage == Pagequanlysukien)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
