using Guna.UI2.WinForms;
using NhaKhoaCuoiKy.dbs;
using NhaKhoaCuoiKy.Views.Service;

namespace NhaKhoaCuoiKy.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form currentForm;
        private Patient patient = new Patient();
        private Servicee service;
        private AddNewRecord newRecord;

        private void MainForm_Load(object sender, EventArgs e)
        {
            panel_btn_employee.AutoSize = true;
        }

        private void openChildForm(Form childForm)
        {
            if (currentForm != null) currentForm.Close();
            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (patient != null)
            {
                patient.popupNewPatient += (s, e) =>
                {

                };

                patient.addNewRecord += (s, e) =>
                {
                    newRecord?.Close();
                    newRecord = new AddNewRecord();
                    openChildFormHaveData(newRecord);
                };
            }
        }

        private void openChildFormHaveData(Form childForm)
        {
            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (newRecord != null)
            {
                newRecord.backToPatient += (s, e) =>
                {
                    openChildForm(patient);
                };
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            closeAllPanel();
        }

        private void btn_home_MouseEnter(object sender, EventArgs e)
        {
            buttonMouseEnter(btn_home);
        }

        private void btn_home_MouseLeave(object sender, EventArgs e)
        {
            buttonMouseLeave(btn_home);
        }

        private void btn_patient_MouseEnter(object sender, EventArgs e)
        {
            buttonMouseEnter(btn_patient);
        }

        private void btn_patient_MouseLeave(object sender, EventArgs e)
        {
            buttonMouseLeave(btn_patient);
        }

        private void btn_patient_Click(object sender, EventArgs e)
        {
            closeAllPanel();
            patient?.Close();
            openChildForm(patient = new Patient(this));
        }

        private void btn_exit_MouseEnter(object sender, EventArgs e)
        {
            btn_exit.FillColor = Color.Red;
        }

        private void btn_exit_MouseLeave(object sender, EventArgs e)
        {
            buttonMouseLeave(btn_exit);
        }

        private void btn_employee_MouseEnter(object sender, EventArgs e)
        {
            buttonMouseEnter(btn_employee);
        }

        private void btn_employee_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_btn_employee.Visible)
            {
                buttonMouseLeave(btn_employee);
            }
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            if (!panel_btn_employee.Visible)
            {
                buttonMouseEnter(btn_employee);
                panel_btn_employee.Visible = true;
                return;
            }
            closeAllPanel();
            btn_employee.FillColor = Color.Transparent;

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeAllPanel()
        {
            List<Panel> panelList = new List<Panel>() { panel_btn_employee };
            List<Guna2Button> guna2Buttons = new List<Guna2Button>()
            { btn_home,
                btn_exit,
                btn_employee,
                btn_patient
            };
            foreach (Panel p in panelList)
            {
                p.Visible = false;
            }
            foreach (Guna2Button button in guna2Buttons)
            {
                buttonMouseLeave(button);
            }
        }

        private void buttonMouseEnter(Guna2Button btn)
        {
            btn.FillColor = Color.DarkGray;
        }

        private void buttonMouseLeave(Guna2Button btn)
        {
            btn.FillColor = Color.Transparent;
        }

        private void btn_service_Click(object sender, EventArgs e)
        {
            closeAllPanel();
            service?.Close();
            openChildForm(service = new Servicee(this));
        }
    }
}
