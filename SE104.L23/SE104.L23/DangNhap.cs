using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SE104.L23
{
    public partial class DangNhap : Form
    {
        private SqlConnection con;
        private string connetionString;
        private void connect_Database()
        {
            string datasource = @"LAPTOP-1CRA9CL4";
            string Initial_Catalog = "May";
            
            this.connetionString = "Server= "+datasource+"; Database= "+Initial_Catalog+";Integrated Security = SSPI; MultipleActiveResultSets = true";
            this.con = new SqlConnection(connetionString);
            try
            {
                con.Open();
                //MessageBox.Show(con.State.ToString());
          
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }

        }
        public DangNhap()
        {
            InitializeComponent();
            connect_Database();

        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string sql_query = "select count (*) from NGUOIDUNG where TenDangNhap = '" + input_TaiKhoan.Text + "' and MatKhau = '" + input_Pass.Text + "'";
            //string sql_query = "select count (*) from NGUOIDUNG";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            int check = Convert.ToInt32(cmd.ExecuteScalar());
            //MessageBox.Show(sql_query.ToString());
            if (check > 0)
            {
                Mainmenu test = new Mainmenu(con, input_TaiKhoan.Text);
                test.Show();
                this.Hide();
            }      
             else
            {
                ThatBai notice = new ThatBai("Người dùng không tôn tại hoặc sai mật khẩu");
                
                if (notice.ShowDialog() == DialogResult.OK)
                {
                    notice.Close();
                    
                }
            }
            cmd.Dispose();
            //Mainmenu test = new Mainmenu();
            //test.Show();
            //this.Hide();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void open_Click(object sender, EventArgs e)
        {
            if(input_Pass.UseSystemPasswordChar == true)
            {
                input_Pass.UseSystemPasswordChar = false;
                input_Pass.Multiline = true;
                open.BackgroundImage = Properties.Resources.hide;
            }
            else
            {
                input_Pass.UseSystemPasswordChar = true;
                input_Pass.Multiline = false;
                open.BackgroundImage = Properties.Resources.open;
            }    
            
        }

        //private void input_Pass_Enter(object sender, EventArgs e)
        //{
        //    input_Pass.Text = "";

        //    input_Pass.ForeColor = Color.Black;

        //    input_Pass.UseSystemPasswordChar = true;
        //}

        //private void input_Pass_Leave(object sender, EventArgs e)
        //{
        //    if (input_Pass.Text.Length == 0)
        //    {
        //        input_Pass.ForeColor = Color.Gray;

        //        input_Pass.Text = "Enter password";

        //        input_Pass.UseSystemPasswordChar = false;

        //        SelectNextControl(input_Pass, true, true, false, true);
        //    }
        //}
    }
}
