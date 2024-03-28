using Dapper;
using Guna.UI2.WinForms;
using NhaKhoaCuoiKy.dbs;
using NhaKhoaCuoiKy.Helpers;
using NhaKhoaCuoiKy.Models;

namespace NhaKhoaCuoiKy.Views
{
    public partial class NewPatient : Form
    {
        public DynamicParameters p { get; set; }
        public EventHandler eventAddPatient;
        private Validate validate = new Validate();
        public NewPatient()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(100, 17, 34, 71), ButtonBorderStyle.Solid);
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_uploadImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
                if ((opf.ShowDialog() == DialogResult.OK))
                {
                    pb_avt.Image = Image.FromFile(opf.FileName);
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tb_name.Text;
                DateTime birth = dtp_birth.Value;
                string phone = tb_phone.Text;
                int homenum = int.Parse(tb_homenum.Text);
                string ward = tb_ward.Text;
                string city = tb_city.Text;
                string gender = "other";
                string street = tb_street.Text;

                if (rdb_male.Checked)
                {
                    gender = "male";
                }
                else if (rdb_female.Checked)
                {
                    gender = "female";
                }

                MemoryStream ms = new MemoryStream();
                pb_avt.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] img = ms.ToArray();

                PatientModel patient = new PatientModel();
                p = patient.addPatient(name, gender, birth, homenum, ward, city, img, phone, street);
                eventAddPatient?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR::" + ex.Message);
            }

        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            warningValidate(pb_name, tb_name, validate.validateName(tb_name.Text));
        }

        private void warningValidate(PictureBox picbox, Guna2TextBox tb, bool check)
        {
            picbox.Visible = (check || tb.Text.Length == 0) ? false : true;
            tb.BorderColor = (check || tb.Text.Length == 0) ? Color.Black : Color.Red;
            tb.BorderThickness = (check || tb.Text.Length == 0) ? 1 : 3;
        }

        private void tb_phone_TextChanged(object sender, EventArgs e)
        {
            warningValidate(pb_phone, tb_phone, validate.validatePhone(tb_phone.Text));
        }
    }
}
