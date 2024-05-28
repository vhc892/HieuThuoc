using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HieuThuoc.Admin
{
    public partial class UC_ViewUser : UserControl
    {
        Function fn = new Function();
        String query;
        String currentUser = "";

        public UC_ViewUser()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { currentUser = value; }
        }

        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM users ORDER BY Id";
            DataSet ds = fn.getData(query);
            dataUser.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM users WHERE username LIKE '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            dataUser.DataSource= ds.Tables[0];
        }

        String userName;
        private void dataUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = dataUser.Rows[e.RowIndex].Cells[6].Value.ToString();
            }catch (Exception ex)
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa ?","Xóa thông tin",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                if (currentUser != userName)
                {
                    query = "DELETE * FROM users WHERE username ='" + userName+"'";
                    fn.setData(query, "Đã xóa");
                    UC_ViewUser_Load(this, null);
                }
                else
                {
                    MessageBox.Show("Có lỗi, hãy xóa lại ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            UC_ViewUser_Load(this, null);
        }
    }
}
