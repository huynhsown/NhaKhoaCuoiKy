﻿using Guna.UI2.WinForms;
using NhaKhoaCuoiKy.Helpers;
using NhaKhoaCuoiKy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NhaKhoaCuoiKy.Views.Service
{
    public partial class NewService : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private Servicee service;
        private Validate validate = new Validate();
        public NewService()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        public NewService(Servicee service)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.service = service;
        }

        private Form currentForm;

        private void openChildForm(Form childForm)
        {
            /*            if (currentForm != null) currentForm.Close();
                        currentForm = childForm;
                        childForm.TopLevel = false;
                        childForm.FormBorderStyle = FormBorderStyle.None;
                        childForm.Dock = DockStyle.Fill;
                        panel_addCategory.Controls.Add(childForm);
                        panel_addCategory.Tag = childForm;
                        childForm.BringToFront();
                        childForm.Show();
                        childForm.FormClosed += new FormClosedEventHandler(FormClosed);*/
            DialogResult dr = childForm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                panel_addCategory.Visible = false;
                loadAllCategorytoComboBox();
            }
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadAllCategorytoComboBox()
        {
            cb_category.Items.Clear();
            cb_category.Items.Add(new ComboBoxItem(-999, "----CHỌN LOẠI DỊCH VỤ----"));
            cb_category.SelectedIndex = 0;
            DataTable lsCategory = ServiceHelper.getAllServiceCategory();
            foreach (DataRow dr in lsCategory.Rows)
            {
                int id = Convert.ToInt32(dr[0]);
                string title = Convert.ToString(dr[1]);
                cb_category.Items.Add(new ComboBoxItem(id, title));
            }
        }

        private void NewService_Load(object sender, EventArgs e)
        {
            loadAllCategorytoComboBox();
        }

        private void btn_addCategory_Click(object sender, EventArgs e)
        {
            panel_addCategory.Dock = DockStyle.Fill;
            panel_addCategory.Visible = true;
            openChildForm(new NewCategory(service));
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cb_category.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ", "Chọn loại dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!verify())
            {
                MessageBox.Show("Dữ liệu thiếu hoặc sai", "Thêm dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                int category_id = ((ComboBoxItem)cb_category.SelectedItem).Id;
                string title = tb_title.Text.Trim();
                int price = Convert.ToInt32(tb_price.Text);
                int discount = Convert.ToInt32(tb_discount.Text);
                int warranty = Convert.ToInt32(tb_warranty.Text);
                int unit = Convert.ToInt32(tb_unit.Text);
                int time = Convert.ToInt32(tb_time.Text);
                string detail = tb_detail.Text.Trim();
                int id = ServiceHelper.addNewService(category_id, title, price, discount, warranty, unit, time, detail);
                if (id != -1)
                {
                    MessageBox.Show("Thêm dịch vụ thành công", "Thêm dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm dịch vụ thất bại", "Thêm dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = ServiceHelper.getServiceByID(id);
                DataRow dr = dt.Rows[0];
                service.data_category_items.Rows.Add(Convert.ToInt32(dr[0]),Convert.ToString(dr[1]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool verify()
        {
            if (tb_discount.Text.Trim().Length == 0
                || tb_price.Text.Trim().Length == 0
                || tb_time.Text.Trim().Length == 0
                || tb_title.Text.Trim().Length == 0
                || tb_unit.Text.Trim().Length == 0
                || tb_warranty.Text.Trim().Length == 0) return false;

            if(tb_discount.BorderThickness == 3
                || tb_price.BorderThickness == 3
                || tb_title.BorderThickness == 3
                || tb_unit.BorderThickness == 3
                || tb_warranty.BorderThickness == 3) return false;
            return true;
        }



        private void warningValidate(Guna2TextBox tb, bool check)
        {
            tb.BorderColor = (check || tb.Text.Length == 0) ? Color.Black : Color.Red;
            tb.BorderThickness = (check || tb.Text.Length == 0) ? 1 : 3;
        }

        private void tb_price_TextChanged(object sender, EventArgs e)
        {
            warningValidate(tb_price, validate.validateNumber(tb_price.Text));
        }

        private void tb_discount_TextChanged(object sender, EventArgs e)
        {
            warningValidate(tb_discount, validate.validateNumber(tb_discount.Text));
        }

        private void tb_warranty_TextChanged(object sender, EventArgs e)
        {
            warningValidate(tb_warranty, validate.validateNumber(tb_warranty.Text));
        }

        private void tb_unit_TextChanged(object sender, EventArgs e)
        {
            warningValidate(tb_unit, validate.validateNumber(tb_unit.Text));
        }

        private void tb_time_TextChanged(object sender, EventArgs e)
        {
            warningValidate(tb_time, validate.validateNumber(tb_time.Text));
        }
    }
}
