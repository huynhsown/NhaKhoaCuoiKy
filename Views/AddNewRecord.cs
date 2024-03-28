using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoaCuoiKy.Views
{
    public partial class AddNewRecord : Form
    {
        public AddNewRecord()
        {
            InitializeComponent();
        }

        public EventHandler backToPatient;

        private void btn_back_Click(object sender, EventArgs e)
        {
            backToPatient?.Invoke(sender, e);
        }
    }
}
