using NhaKhoaCuoiKy.Helpers;
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

        public NewService()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewService_Load(object sender, EventArgs e)
        {
/*            Dictionary<int, string> lsCategory = ServiceHelper.getAllServiceCategory();
            foreach (KeyValuePair<int, string> kvp in lsCategory)
            {
                cb_category.Items.Add(new ComboBoxItem(kvp.Key, kvp.Value));
            }*/
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
