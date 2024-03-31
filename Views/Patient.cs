using Dapper;
using NhaKhoaCuoiKy.Helpers;
using NhaKhoaCuoiKy.Models;
using NhaKhoaCuoiKy.Views.Service;
using System.Data;

namespace NhaKhoaCuoiKy.Views
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        public EventHandler popupNewPatient;
        public EventHandler addNewRecord;
        private NewPatient newPatient;
        private Validate validate = new Validate();
        private MainForm mainForm;
        PatientModel pm;

        public Patient(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            newPatient?.Close();
            newPatient = new NewPatient();
            newPatient.Owner = this;
            newPatient.Show();
            newPatient.eventAddPatient += (s, e) =>
            {
                DynamicParameters p = newPatient.p;
                int maBN = p.Get<int>("@MaBenhNhan");
                string hoTen = p.Get<string>("@HoVaTen");
                string gioiTinh = p.Get<string>("@GioiTinh");
                string ngaySinh = p.Get<DateTime>("@NgaySinh").ToShortDateString();
                int soNha = p.Get<int>("@SoNha");
                string soDienThoai = p.Get<string>("@SoDienThoai");
                string duong = p.Get<string>("@TenDuong");
                string phuong = p.Get<string>("@Phuong");
                string thanhPho = p.Get<string>("@ThanhPho");
                string diaChi = soNha.ToString() + " " + duong + " " + phuong + " " + thanhPho;
                data_benhNhan.Rows.Add(maBN, hoTen, soDienThoai, ngaySinh, gioiTinh, diaChi);
            };

/*            FormBackGround formBackGround = new FormBackGround(mainForm);
            try
            {
                using (NewPatient newCategory = new NewPatient(this))
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
            }*/
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            pm = new PatientModel();
            data_benhNhan.AllowUserToAddRows = false;
            /*            data_benhNhan.Columns[0].Width = 90;
                        DataGridViewButtonColumn btn_record = new DataGridViewButtonColumn();
                        btn_record.HeaderText = "Thêm bệnh án";
                        btn_record.Name = "btn_addRecord";
                        btn_record.Text = "Thêm";
                        btn_record.UseColumnTextForButtonValue = true;
                        data_benhNhan.Columns.Add(btn_record);

                        DataGridViewButtonColumn btn_info = new DataGridViewButtonColumn();
                        btn_info.HeaderText = "Xem thông tin";
                        btn_info.Name = "btn_editInfoPatient";
                        btn_info.Text = "Xem";
                        btn_info.UseColumnTextForButtonValue = true;
                        data_benhNhan.Columns.Add(btn_info);*/
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (tb_filter_search.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui long nhap thong tin", "Thong tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            data_benhNhan.Rows.Clear();
            data_benhNhan.Refresh();
            if (cb_filter.SelectedIndex == 0)
            {
                searchByID();
            }
            else if (cb_filter.SelectedIndex == 1)
            {
                searchByName();
            }
            else if (cb_filter.SelectedIndex == 2)
            {
                searchByPhone();
            }
        }

        private void addToDataGrid(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int maBN = Convert.ToInt32(dt.Rows[i]["MaBenhNhan"]);
                    string hoTen = Convert.ToString(dt.Rows[i]["HoVaTen"]);
                    string gioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                    string ngaySinh = Convert.ToDateTime(dt.Rows[i]["NgaySinh"]).ToShortDateString();
                    int soNha = int.Parse(dt.Rows[i]["SoNha"].ToString());
                    string soDienThoai = dt.Rows[i]["SoDienThoai"].ToString();
                    string duong = dt.Rows[i]["TenDuong"].ToString();
                    string phuong = dt.Rows[i]["Phuong"].ToString();
                    string thanhPho = dt.Rows[i]["ThanhPho"].ToString();

                    string diaChi = soNha.ToString() + " " + duong + " " + phuong + " " + thanhPho;
                    data_benhNhan.Rows.Add(maBN, hoTen, soDienThoai, ngaySinh, gioiTinh, diaChi);
                }
            }
            else
            {
                MessageBox.Show("Khong co thong tin!", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void searchByID()
        {
            try
            {
                if (!validate.validateNumber(tb_filter_search.Text.Trim()))
                {
                    MessageBox.Show("Ma benh nhan khong hop le (Chua ky tu dac biet hoac chu cai)", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = pm.getByID(int.Parse(tb_filter_search.Text.Trim()));
                addToDataGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void searchByName()
        {
            try
            {
                DataTable dt = pm.getByName(tb_filter_search.Text.Trim());
                addToDataGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchByPhone()
        {
            try
            {
                if (!validate.validateNumber(tb_filter_search.Text.Trim()))
                {
                    MessageBox.Show("So dien thoai khong hop le (Chua ky tu dac biet hoac chu cai)", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = pm.getByPhone(tb_filter_search.Text.Trim());
                addToDataGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void data_benhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data_benhNhan.Columns[e.ColumnIndex].Name == "col_btn_addRecord")
            {
                addNewRecord?.Invoke(sender, e);
            }
        }
    }
}
