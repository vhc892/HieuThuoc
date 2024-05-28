using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HieuThuoc
{
    internal class Function
    {
        protected SqlConnection getConnection()
        {
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "data source = Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Cong\\OneDrive - Hanoi University of Science and Technology\\Documents\\hieuthuoc.mdf\";Integrated Security=True;Connect Timeout=30";
            //return conn;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Cong\OneDrive - Hanoi University of Science and Technology\Documents\hieuthuoc.mdf"";Integrated Security=True;Connect Timeout=30");
            return conn;
        }
        public DataSet getData(string query)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setData(string query, string msg)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText= query;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show(msg,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
