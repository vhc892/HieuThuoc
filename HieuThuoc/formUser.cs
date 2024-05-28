using HieuThuoc.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HieuThuoc
{
    public partial class formUser : Form
    {
        public formUser()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form fm = new Form();
            fm.Show();
            this.Hide();
        }

        

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            uS_DashBoard1.Visible = true;
            uS_DashBoard1.BringToFront();
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            uS_DashBoard1.Visible = false;
            btnDashBoard.PerformClick();
        }
    }
}
