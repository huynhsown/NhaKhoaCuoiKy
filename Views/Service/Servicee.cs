using Dapper;
using NhaKhoaCuoiKy.Helpers;
using NhaKhoaCuoiKy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoaCuoiKy.Views.Service
{
    public partial class Servicee : Form
    {
        private MainForm mainForm;
        private DynamicParameters p;
        public Servicee()
        {
            InitializeComponent();
        }

        public Servicee(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Servicee_Load(object sender, EventArgs e)
        {
            loadAllCategory();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround(mainForm);
            try
            {
                using (NewCategory newCategory = new NewCategory(this))
                {
                    formBackGround.Owner = mainForm;
                    formBackGround.Show();
                    newCategory.Owner = formBackGround;
                    newCategory.ShowDialog();
                    formBackGround.Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadAllCategory()
        {
            try
            {
                DataTable dt = ServiceHelper.getAllServiceCategory();
                foreach (DataRow dr in dt.Rows)
                {
                    int id = int.Parse(dr[0].ToString());
                    string txt = dr[1].ToString();
                    data_loaiDichvu.Rows.Add(id, txt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_category_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                data_loaiDichvu.Rows.Clear();
                DataTable dt = ServiceHelper.getAllServiceCategory();
                foreach (DataRow dr in dt.Rows)
                {
                    int id = int.Parse(dr[0].ToString());
                    string txt = dr[1].ToString();
                    data_loaiDichvu.Rows.Add(id, txt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
