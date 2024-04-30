using NhaKhoaCuoiKy.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoaCuoiKy.Views.PatientForm
{
    public partial class AddNewRecord : Form
    {
        int patienID;
        public AddNewRecord(int patienID)
        {
            InitializeComponent();
            this.patienID = patienID;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime dtp_pick = dtp_date.Value;
            int age = today.Year - dtp_pick.Year;
            tb_age.Text = age.ToString();
        }

        private void AddNewRecord_Load(object sender, EventArgs e)
        {
            panel_patienInfo.Location = new Point(21, 115);
            panel_medicalhistory.Location = new Point(21, 330);
            panel_reason.Location = new Point(21, 755); // Khoảng cách = 20
            panel_diagnose.Location = new Point(21, 1025);
            panel_plan.Location = new Point(21, 1435);
            panel_abstract.Location = new Point(21, 2130);
            panel1.Dispose();
            loadPatientInfomation();
        }

        private void loadPatientInfomation()
        {
            try
            {
                DataTable dt = PatientHelper.getByID(patienID);
                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Không thể thêm bệnh án", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                string name = Convert.ToString(dt.Rows[0]["HoVaTen"]).Trim();
                DateTime dob = Convert.ToDateTime(dt.Rows[0]["NgaySinh"]);
                string h_number = dt.Rows[0]["SoNha"].ToString();
                string s_name = dt.Rows[0]["TenDuong"].ToString();
                string ward = dt.Rows[0]["Phuong"].ToString();
                string city = dt.Rows[0]["ThanhPho"].ToString();
                string address = h_number + ", " + s_name + ", " + ward + ", " + city;
                string phone = dt.Rows[0]["SoDienThoai"].ToString();
                string gender = dt.Rows[0]["GioiTinh"].ToString().Trim();
                Image img;
                using (MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["Anh"]))
                {
                    img = Image.FromStream(ms);
                }
                pb_patientImg.Image = img;
                tb_name.Text = name;
                tb_address.Text = address;
                tb_phone.Text = phone;
                if (gender == "female") rbt_female.Checked = true;
                else if (gender == "male") rbt_male.Checked = true;
                dtp_date.Value = dob;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR::" + ex.Message);
            }
        }
    }
}
