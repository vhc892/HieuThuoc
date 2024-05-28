﻿using System;
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
    public partial class UC_AddUser : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role = txtRole.Text;
            String name = txtName.Text;
            String dob = txtDob.Text;
            Int64 mobile = Int64.Parse(txtPhoneNumber.Text);
            String email = txtEmail.Text;
            String username = txtUserName.Text;
            String pass = txtPassword.Text;
            try
            {
                query = "insert into users (userRole,name,dob,mobile,email,username,pass) values('" + role + "','" + name + "','" + dob + "','" + mobile + "','" + email + "','" + username + "','" + pass + "')";
                fn.setData(query, "Đăng ký thành công ");
            }
            catch(Exception)
            {
                MessageBox.Show("Đã tồn tại ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtName.Clear();
            txtDob.ResetText();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtRole.SelectedIndex = -1;

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM users WHERE username = '" + txtUserName.Text + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                picAddUser.ImageLocation = @"C:\Users\Cong\source\repos\HieuThuoc\HieuThuoc\Admin\pic\image_pharmacy\image_pharmacy\yes.png";
            }
            else
            {
                picAddUser.ImageLocation = @"C:\Users\Cong\source\repos\HieuThuoc\HieuThuoc\Admin\pic\image_pharmacy\image_pharmacy\no.png";
            }
        }
    }
}
