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
    public partial class Form1 : Form
    {
        Function fn = new Function();
        String query;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

     

        private void btnLoggin_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if(txtUsername.Text == "root" && txtPassword.Text == "root")
                {
                    formAdmin admin = new formAdmin();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "SELECT * FROM users WHERE username = '" + txtUsername.Text + "' and pass= '" + txtPassword.Text + "'";
                ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if(role== "Admin")
                    {
                        formAdmin admin = new formAdmin(txtUsername.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "User")
                    {
                        formUser user = new formUser();
                        user.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }
            //if(txtUsername.Text == "abc" && txtPassword.Text == "abc")
            //{
            //    formAdmin admin = new formAdmin();
            //    admin.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
