﻿using NhaKhoaCuoiKy.Helpers;
using NhaKhoaCuoiKy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewService_Load(object sender, EventArgs e)
        {
            DataTable lsCategory = ServiceHelper.getAllServiceCategory();
            foreach (DataRow dr in lsCategory.Rows)
            {
                int id = Convert.ToInt32(dr[0]);
                string title = dr[1].ToString();
                cb_category.Items.Add(new ComboBoxItem(id, title));
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
