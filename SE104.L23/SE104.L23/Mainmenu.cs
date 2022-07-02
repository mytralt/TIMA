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
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace SE104.L23
{
    public partial class Mainmenu : Form
    {
        private bool check_DV;
        private string TenDangNhap;
        private SqlConnection con;
        
        
        DataGridViewComboBoxColumn LoaiND = new DataGridViewComboBoxColumn();
        
        public string Tim_MaCD(string TenBenXeDen, string TenBenXeDi, string ngaygio)
        {
            string sql_query = "select MaChuyenDi" +
                        " from CHUYENDI CD join TUYEN T on CD.MaTuyen = T.MaTuyen" +
                        " where BenXeDen in (select BX1.MaBenXe" +
                        " from BENXE BX1" +
                        " where BX1.TenBenXe = N'" + TenBenXeDen + "')" +
                        " and BenXeDi in (select BX2.MaBenXe" +
                        " from BENXE BX2" +
                        " where BX2.TenBenXe = N'" + TenBenXeDi + "')" + 
                        " and convert(date, CD.NgayGio) = convert(date,'" + FormatDate(ngaygio) + "')";

            SqlCommand cmd = new SqlCommand(sql_query, con);
            string macd = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    macd = reader["MaChuyenDi"].ToString();
                }

            }
            //MessageBox.Show(sql_query);
            return macd;
        }
        public string Tim_MaKH(string TenKhachHang)
        {
            string sql_query = "select MaKhachHang" +
                " from KHACHHANG" +
                " where HoTen = N'"+TenKhachHang+"'";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            string maKH = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    maKH = reader["MaKhachHang"].ToString();
                }

            }
            return maKH;
        }
        public string FormatTime(string time)
        {
            return time.Substring(0,5);
        }
        public string FormatDate(string date)
        {
            return date.Substring(3, 3) + date.Substring(0, 3) + date.Substring(6); 
        }
        public Mainmenu(SqlConnection con, string TenDangNhap)
        {

            InitializeComponent();
            LoaiND.FlatStyle = FlatStyle.Flat;
            
            
            Time_Qlcd_Them.ShowUpDown = true;
            CSCD_Time.ShowUpDown = true;
            this.con = con;
            string sql_query = "select MaLoaiND from NGUOIDUNG where TenDangNhap = '" + TenDangNhap + "'";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            string MaLoaiND = cmd.ExecuteScalar().ToString();
            if (MaLoaiND == "2")
            {
                btn_user.Text = "@user";
            }
            else btn_user.Text = "@admin";

            //cmd.Dispose();

            this.TenDangNhap = TenDangNhap;

            sql_query = "select TenChucNang from CHUCNANG CN, PHANQUYEN PQ where CN.MaChucNang = PQ.MaChucNang and MaLoaiND = '" + MaLoaiND + "'";
            cmd = new SqlCommand(sql_query, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    if (btn_DatVe.Tag.ToString() == reader["TenChucNang"].ToString()) btn_DatVe.Visible = true;
                    else if (btn_Qlcd.Tag.ToString() == reader["TenChucNang"].ToString()) btn_Qlcd.Visible = true;
                    else if (btn_Qlbx.Tag.ToString() == reader["TenChucNang"].ToString()) btn_Qlbx.Visible = true;
                    else if (btn_Tkbc.Tag.ToString() == reader["TenChucNang"].ToString()) btn_Tkbc.Visible = true;
                    else if (btn_Qlnd.Tag.ToString() == reader["TenChucNang"].ToString()) btn_Qlnd.Visible = true;
                    else if (btn_QuyDinh.Tag.ToString() == reader["TenChucNang"].ToString()) btn_QuyDinh.Visible = true;
                }    
               
            }       
            bunifuPages1.SetPage("Trang Chính");
            Init_Control();
        }



        private string Tim_BXTG(string TenBenXe)
        {
            string maBX = "";
            string sql_query = "select MaBenXe" +
                " from BENXE" +
                " where TenBenXe = N'"+TenBenXe+"'";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    maBX = reader["MaBenXe"].ToString();
                }

            }
            return maBX;
        }
        private void btn_DatVe_MouseLeave(object sender, EventArgs e)
        {
            if(btn_DatVe.Tag.ToString() != "true")
            {
                btn_DatVe.Image = Properties.Resources.btn_datve;
                btn_DatVe.BackColor = Color.Transparent;
            }       
        }

        private void btn_DatVe_MouseMove(object sender, MouseEventArgs e)
        {
            btn_DatVe.Image = Properties.Resources.btn_Datve_click;
            btn_DatVe.BackColor = Color.FromArgb(78,204,163);
        }

        private void btn_DatVe_Click(object sender, EventArgs e)
        {
            btn_DatVe.Image = Properties.Resources.btn_Datve_click;
            btn_DatVe.BackColor = Color.FromArgb(78, 204, 163);

            btn_Qlcd.Image = Properties.Resources.btn_qlcd;
            btn_Qlcd.BackColor = Color.Transparent;

            btn_Qlbx.Image = Properties.Resources.btn_qlbx;
            btn_Qlbx.BackColor = Color.Transparent;

            btn_Tkbc.Image = Properties.Resources.btn_tkbc;
            btn_Tkbc.BackColor = Color.Transparent;

            btn_Qlnd.Image = Properties.Resources.btn_QLND;
            btn_Qlnd.BackColor = Color.Transparent;

            btn_QuyDinh.Image = Properties.Resources.btn_QuyDinh;
            btn_QuyDinh.BackColor = Color.Transparent;

            if (btn_DatVe.Tag.ToString() == "true")
            {
                btn_DatVe.Tag = "Đặt vé";
            }
            else btn_DatVe.Tag = "true";
            bunifuPages1.SetPage("Đặt vé");
        }
        private void Init_Control()
        {
            string sql_query = "select TenBenXe from BENXE BX ";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DropDown_BXD.Items.Add(reader["TenBenXe"].ToString());
                }
            }
            Date.MinDate = DateTime.Now;
        }
        private void btn_TraCuu_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql_query = "select CD.ThoiGianDi , CONVERT(time, CD.NgayGio) AS GioDi "+ 
                                "from TUYEN T, CHUYENDI CD "+
                                "where T.BenXeDi in (select BX1.MaBenXe "+
                                                        "from BENXE BX1 "+
                                                        "where BX1.TenBenXe = N'"+ DropDown_BXDi.Text+"') "+
	                                                        "and T.BenXeDen in (select BX2.MaBenXe "+
                                                             "from BENXE BX2 "+
                                                              "where BX2.TenBenXe = N'" + DropDown_BXD.Text + "')" +
                                                              " and CD.MaTuyen = T.MaTuyen "+
                                                              "and CONVERT(date, CD.NgayGio) = CONVERT(date, '" + FormatDate(Date.Text) + "')";
            
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int count = 1;
                while (reader.Read())
                {

                    //MessageBox.Show(count.ToString());
                    Bitmap icon = new Bitmap(Properties.Resources.btn_next, new Size(30,30));
                    dataGridView1.Rows.Add(count, DropDown_BXD.Text, DropDown_BXDi.Text, Date.Text, FormatTime(reader["GioDi"].ToString()), reader["ThoiGianDi"].ToString(), (Image)icon);
                    count++;                
                }

            }
            check_DV = true;
        }

        private void DropDown_BXD_TextChanged(object sender, EventArgs e)
        {
            //if(DropDown_BXD.Text != "")
            //{
                
            //}
        }

        private void DropDown_BXD_SelectedValueChanged(object sender, EventArgs e)
        {
            DropDown_BXDi.Items.Clear();
            string sql_query = "select BX.TenBenXe from BENXE BX where BX.MaBenXe in (" +
                " select T.BenXeDi from BENXE BX1, TUYEN T where T.BenXeDen in (" +
                "select MaBenXe from BENXE BX2 where BX2.TenBenXe = N'" + DropDown_BXD.Text + "') and T.BenXeDen = BX1.MaBenXe)";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DropDown_BXDi.Items.Add(reader["TenBenXe"].ToString());
                }

            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql_query = "select BX1.TenBenXe as TenBenXeDi , BenXeDenn.TenBenXe as TenBenXeDen, res.NgayDi, res.GioDi, res.ThoiGianDi " +
                "from(select * " +
                    "from TUYEN T, BENXE BX " +
                    "where T.BenXeDen = BX.MaBenXe) AS BenXeDenn,  (select CD.MaTuyen, CONVERT(time, CD.NgayGio) AS GioDi, CONVERT(date, CD.NgayGio) AS NgayDi, CD.ThoiGianDi " +
                                                                    "from KHACHHANG KH, VECHUYENDI V, CHUYENDI CD " +
                                                                    " where KH.DienThoai = '" + input_SDT.Text + "' " +
                                                                    "and KH.MaKhachHang = V.MaKhachHang " +
                                                                    "and CD.MaChuyenDi = V.MaChuyenDi) AS RES, BENXE BX1 " +
                "where BenXeDenn.MaTuyen = RES.MaTuyen " +
                "and BenXeDenn.BenXeDi = BX1.MaBenXe ";

            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int count = 1;
                while (reader.Read())
                {

                    //MessageBox.Show(count.ToString());
                    Bitmap icon = new Bitmap(Properties.Resources.btn_next, new Size(30, 30));
                    dataGridView1.Rows.Add(count, reader["TenBenXeDen"].ToString(), reader["TenBenXeDi"].ToString(), reader["NgayDi"].ToString().Substring(0,10), FormatTime(reader["GioDi"].ToString()), reader["ThoiGianDi"].ToString(), (Image)icon);
                    count++;
                }

            }
            check_DV = false;
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(e.ColumnIndex == 6)
            {
                string date = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string BenXeDen = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string BenXeDi = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string ThoiGianDi = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (check_DV == false)
                {
                    string sql_query = "select BX.TenBenXe as TenBenXeTrungGian, ThoiGianDung, GiaVe, TenHangVe, SoGheTrong" +
                        " from BENXE BX, HANGVE HV, (select BenXeTrungGian, ThoiGianDung, GiaVe, CD.MaHangVe, SoGheTrong" +
                        " from CHITIETCHUYENDI CT JOIN CHUYENDI CD ON CT.MaChuyenDi = CD.MaChuyenDi JOIN TUYEN T ON T.MaTuyen = CD.MaTuyen JOIN DONGIA DG ON DG.MaTuyen = CD.MaTuyen JOIN TINHTRANGCD TT ON TT.MaChuyenDi = CD.MaChuyenDi" +
                        " where CONVERT(date, CD.NgayGio) = CONVERT(date, '" + FormatDate(date) + "')" +
                        " and CD.ThoiGianDi = " + ThoiGianDi +
                        " and T.BenXeDi in (select BX1.MaBenXe" +
                        " from BENXE BX1" +
                        " where BX1.TenBenXe = N'" + BenXeDi + "')" +
                        " and T.BenXeDen in (select BX2.MaBenXe" +
                        " from BENXE BX2" +
                        " where BX2.TenBenXe = N'" + BenXeDen + "')) as RES" +
                        " where BX.MaBenXe = RES.BenXeTrungGian" +
                        " and RES.MaHangVe = HV.MaHangVe";
                    SqlCommand cmd = new SqlCommand(sql_query, con);
                    Text_DV_BXTG.Text = "";
                    Text_DV_TGDung.Text = "0";
                    string BenXe = "";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            BenXe += reader["TenBenXeTrungGian"].ToString();
                            Text_DV_TGDung.Text = Convert.ToString(Convert.ToInt32(reader["ThoiGianDung"]) + Convert.ToInt32(Text_DV_TGDung.Text));
                            Text_DV_GiaVe.Text = reader["GiaVe"].ToString().Substring(0, reader["GiaVe"].ToString().IndexOf("."));
                            Text_DV_HangVe.Text = reader["TenHangVe"].ToString();
                            Text_DV_GheTrong.Text = reader["SoGheTrong"].ToString();

                        }

                    }
                    Text_DV_BXD.Text = BenXeDen;
                    Text_DV_BXTG.Text = BenXe;
                    Text_DV_BXDi.Text = BenXeDi;
                    Text_DV_NgayGio.Text = date;
                    Text_DV_ThoiGian.Text = ThoiGianDi;
                    sql_query = " select distinct KH.HoTen, P.MaGhe,P.NgayDat as NgayDatVe, ND.TenDangNhap" +
                        " from KHACHHANG KH join PHIEUDATCHO P on KH.MaKhachHang = P.MaKhachHang join NGUOIDUNG ND on P.MaNguoiDung = ND.MaNguoiDung " +
                        " where KH.DienThoai = '" + input_SDT.Text +"'";
                    cmd = new SqlCommand(sql_query, con);
                    //MessageBox.Show(sql_query);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Text_DV_SDT.Text = input_SDT.Text;
                            Text_DV_HoTen.Text = reader["HoTen"].ToString();
                            Text_DV_ViTri.Text = reader["MaGhe"].ToString();
                            Text_DV_NgayDV.Text = reader["NgayDatVe"].ToString().Substring(0, reader["NgayDatVe"].ToString().IndexOf(" "));
                            Text_DV_NhanVien.Text = reader["TenDangNhap"].ToString();
                        }
                    }
                    List<string> temp = new List<string>();
                    sql_query = "select MaGhe" +
                        " from GHE G" +
                        " where MaChuyenDi in (select MaChuyenDi" +
                        " from CHUYENDI CD join TUYEN T on CD.MaTuyen = T.MaTuyen" +
                        " where BenXeDen in (select BX1.MaBenXe" +
                        " from BENXE BX1" +
                        " where BX1.TenBenXe = N'" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "')" +
                        " and BenXeDi in (select BX2.MaBenXe" +
                        " from BENXE BX2" +
                        " where BX2.TenBenXe = N'" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "')" +
                        " and CONVERT(date, NgayGio) = CONVERT(date, '" + FormatDate(date) + "'))";
                    cmd = new SqlCommand(sql_query, con);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temp.Add(reader["MaGhe"].ToString());
                            //MessageBox.Show(reader["MaGhe"].ToString());
                        }

                    }
                    viTriGhe2.Xoa();
                    viTriGhe2.HienThi(temp);
                    bunifuPages1.SetPage("DV - TTDV");
                }
                else
                {
                    string sql_query = "select BX.TenBenXe as TenBenXeTrungGian, ThoiGianDung, GiaVe, TenHangVe, SoGheTrong" +
                        " from BENXE BX,HANGVE HV ,(select BenXeTrungGian, ThoiGianDung, GiaVe, CD.MaHangVe, SoGheTrong" +
                        " from CHITIETCHUYENDI CT JOIN CHUYENDI CD ON CT.MaChuyenDi = CD.MaChuyenDi JOIN TUYEN T ON T.MaTuyen = CD.MaTuyen JOIN DONGIA DG ON DG.MaTuyen = CD.MaTuyen JOIN TINHTRANGCD TT ON TT.MaChuyenDi = CD.MaChuyenDi" +
                        " where CONVERT(date, CD.NgayGio) = CONVERT(date, '" + FormatDate(date) + "')" +
                        " and CD.ThoiGianDi = " + ThoiGianDi +
                        " and T.BenXeDi in (select BX1.MaBenXe" +
                        " from BENXE BX1" +
                        " where BX1.TenBenXe = N'" + BenXeDi + "')" +
                        " and T.BenXeDen in (select BX2.MaBenXe" +
                        " from BENXE BX2" +
                        " where BX2.TenBenXe = N'" + BenXeDen + "')) as RES" +
                        " where BX.MaBenXe = RES.BenXeTrungGian" +
                        " and RES.MaHangVe = HV.MaHangVe";
                    SqlCommand cmd = new SqlCommand(sql_query, con);
                    //MessageBox.Show(sql_query);
                    Text_DatVe_BXTG.Text = "";
                    Text_DatVe_TGDung.Text = "0";
                    string BenXe = "";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BenXe += reader["TenBenXeTrungGian"].ToString();
                            Text_DatVe_TGDung.Text = Convert.ToString(Convert.ToInt32(reader["ThoiGianDung"]) + Convert.ToInt32(Text_DatVe_TGDung.Text));
                            Text_DatVe_GiaVe.Text = reader["GiaVe"].ToString().Substring(0, reader["GiaVe"].ToString().IndexOf("."));
                            Text_DatVe_HV.Text = reader["TenHangVe"].ToString();
                            Text_DatVe_GheTrong.Text = reader["SoGheTrong"].ToString();
                        }

                    }
                    Text_DatVe_BXD.Text = BenXeDen;
                    Text_DatVe_BXTG.Text = BenXe;
                    Text_DatVe_BXDi.Text = BenXeDi;
                    Text_DatVe__NgayGio.Text = date;
                    Text_DatVe_ThoiGian.Text = ThoiGianDi;

                    List<string> temp = new List<string>();
                    sql_query = "select MaGhe" +
                        " from GHE G" +
                        " where MaChuyenDi in (select MaChuyenDi" +
                        " from CHUYENDI CD join TUYEN T on CD.MaTuyen = T.MaTuyen" +
                        " where BenXeDen in (select BX1.MaBenXe" +
                        " from BENXE BX1" +
                        " where BX1.TenBenXe = N'"+ DropDown_BXD.Text + "')" +
                        " and BenXeDi in (select BX2.MaBenXe" +
                        " from BENXE BX2" +
                        " where BX2.TenBenXe = N'" + DropDown_BXDi.Text + "')" +
                        " and CONVERT(date, NgayGio) = CONVERT(date, '" + FormatDate(date) + "'))";
                    cmd = new SqlCommand(sql_query, con);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temp.Add(reader["MaGhe"].ToString());
                        }

                    }
                    sql_query = "select SoLuongGhe" +
                        " from CHUYENDI CD" +
                        " where MaChuyenDi in (select MaChuyenDi" +
                        " from CHUYENDI CD join TUYEN T on CD.MaTuyen = T.MaTuyen" +
                        " where BenXeDen in (select BX1.MaBenXe" +
                        " from BENXE BX1" +
                        " where BX1.TenBenXe = N'" + DropDown_BXD.Text + "')" +
                        " and BenXeDi in (select BX2.MaBenXe" +
                        " from BENXE BX2" +
                        " where BX2.TenBenXe = N'" + DropDown_BXDi.Text + "')" +
                        " and CONVERT(date, NgayGio) = CONVERT(date, '" + FormatDate(date) + "'))";
                    cmd = new SqlCommand(sql_query, con);
                    int sl_ghe = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sl_ghe = Convert.ToInt32(reader["SoLuongGhe"].ToString());
                        }

                    }
                    DropDown_DatVe_ViTri.Items.Clear();
                    
                    for (int i = 1; i <= 9 && i <= sl_ghe; i++)
                    {
                        if (!temp.Contains("A0" + i))
                        {
                            DropDown_DatVe_ViTri.Items.Add("A0" + i);
                        }
                    }
                    for (int i = 10; i <= sl_ghe; i++)
                    {
                        if (!temp.Contains("A" + i))
                        {
                            DropDown_DatVe_ViTri.Items.Add("A" + i);
                        }
                    }
                    viTriGhe1.Xoa();
                    viTriGhe1.HienThi(temp);
                    bunifuPages1.SetPage("Đặt vé - DV");

                }
                
            }
        }
    
        private void btn_Qlcd_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Qlcd.Image = Properties.Resources.btn_Qlcd_click;
            btn_Qlcd.BackColor = Color.FromArgb(78, 204, 163);
        }

        private void btn_Qlcd_MouseLeave(object sender, EventArgs e)
        {
            if (btn_Qlcd.Tag.ToString() != "true")
            {
                btn_Qlcd.Image = Properties.Resources.btn_qlcd;
                btn_Qlcd.BackColor = Color.Transparent;
            }
        }

        private void btn_Qlcd_Click(object sender, EventArgs e)
        {
            btn_Qlcd.Image = Properties.Resources.btn_Qlcd_click;
            btn_Qlcd.BackColor = Color.FromArgb(78, 204, 163);

            btn_Qlbx.Image = Properties.Resources.btn_qlbx;
            btn_Qlbx.BackColor = Color.Transparent;

            btn_Tkbc.Image = Properties.Resources.btn_tkbc;
            btn_Tkbc.BackColor = Color.Transparent;

            btn_Qlnd.Image = Properties.Resources.btn_QLND;
            btn_Qlnd.BackColor = Color.Transparent;

            btn_QuyDinh.Image = Properties.Resources.btn_QuyDinh;
            btn_QuyDinh.BackColor = Color.Transparent;

            btn_DatVe.Image = Properties.Resources.btn_datve;
            btn_DatVe.BackColor = Color.Transparent;
            if (btn_Qlcd.Tag.ToString() == "true")
            {
                btn_Qlcd.Tag = "Quản lý chuyến đi";
            }
            else btn_Qlcd.Tag = "true";
            Dropdown_Qlcd_BXD.Items.Clear();
            string sql_query = "select TenBenXe from BENXE BX ";
            SqlCommand cmd = new SqlCommand(sql_query, con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Dropdown_Qlcd_BXD.Items.Add(reader["TenBenXe"].ToString());
                }
            }
            bunifuPages1.SetPage("Quản lý chuyến đi");
        }

        private void btn_TraCuucd_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            int count = 0;
            string sub_where = "";
            
            if ( Dropdown_Qlcd_BXD.Text != null)
            {
                sub_where += " T.BenXeDen in (select BX3.MaBenXe" +
                    " from BENXE BX3" +
                    " where BX3.TenBenXe = N'" + Dropdown_Qlcd_BXD.Text + "')";
                count++;
            }
            if (Dropdown_Qlcd_BXDi.Text != null)
            {
                if(count == 1)
                {
                    sub_where += " and";
                }
                sub_where += " T.BenXeDi in (select BX4.MaBenXe" +
                    " from BENXE BX4" +
                    " where BX4.TenBenXe = N'" + Dropdown_Qlcd_BXDi.Text + "')";
                
            }
            string sql_query = "select distinct t.MaTuyen, ThoiGianDi, CONVERT(date, CD.NgayGio) AS NgayDi, CONVERT(time, CD.NgayGio) AS GioDi, SoLuongGhe, BenXeDen, BenXeDi, SoLuongGhe, cd.MaHangVe, Giave" + 
                                " from CHUYENDI cd join TUYEN t on cd.MaTuyen = t.MaTuyen  join DONGIA dg on t.MaTuyen = dg.MaTuyen and cd.MaHangVe = dg.MaHangVe" +
                                " where " + sub_where;
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int count_STT = 1;
                while (reader.Read())
                {

                   
                    Bitmap icon = new Bitmap(Properties.Resources.btn_next, new Size(30, 30));


                    dataGridView2.Rows.Add(count_STT,
                        Dropdown_Qlcd_BXD.Text,
                        Dropdown_Qlcd_BXDi.Text, 
                        reader["NgayDi"].ToString().Substring(0, 10), 
                        FormatTime(reader["GioDi"].ToString()), 
                        reader["GiaVe"].ToString().Substring(0, 
                        reader["GiaVe"].ToString().IndexOf(".")),
                        reader["SoLuongGhe"].ToString(), (Image)icon);
                    count_STT++;
                }
                //MessageBox.Show(count_STT.ToString());

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex == 8)
            //{
            //    label75.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    label74.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    label63.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString() +" "+ dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    label50.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    label48.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    string sql_query = "select TenBenXe as BenXeTrungGian, ThoiGianDi, TenHangVe, ThoiGianDung" +
            //    " from CHUYENDI CD join CHITIETCHUYENDI CT on CT.MaChuyenDi = CD.MaChuyenDi join BENXE BX on BX.MaBenXe = CT.BenXeTrungGian join TUYEN T on T.MaTuyen = CD.MaTuyen join HANGVE HV on HV.MaHangVe = CD.MaHangVe" +
            //    " where BenXeDen in (select BX1.MaBenXe" +
            //    " from BENXE BX1" +
            //    " where BX1.TenBenXe = N'" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() + "')" +
            //    " and BenXeDi in (select BX2.MaBenXe" +
            //    " from BENXE BX2" +
            //    " where BX2.TenBenXe = N'" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "')" +
            //    " and CONVERT(date, NgayGio) = CONVERT(date, '" + dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString() + "')" +
            //    " and CONVERT(time, NgayGio) = CONVERT(time, '" + dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString() + "') ";
            //    SqlCommand cmd = new SqlCommand(sql_query, con);
            //    MessageBox.Show(sql_query);
            //    string BXTG = "";
            //    int TGDung = 0;
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            BXTG += reader["BenXeTrungGian"].ToString() + "\n";
            //            TGDung += Convert.ToInt32(reader["ThoiGianDung"]);
            //            label62.Text = reader["ThoiGianDi"].ToString();
            //            label49.Text = reader["TenHangVe"].ToString();
            //        }
            //    }
            //    label61.Text = BXTG;
            //    label60.Text = TGDung.ToString();
            //}
            label75.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            label74.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            label63.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            label50.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            
            string sql_query = "select TenBenXe as BenXeTrungGian, ThoiGianDi, TenHangVe, ThoiGianDung, SoLuongGhe" +
            " from CHUYENDI CD join CHITIETCHUYENDI CT on CT.MaChuyenDi = CD.MaChuyenDi join BENXE BX on BX.MaBenXe = CT.BenXeTrungGian join TUYEN T on T.MaTuyen = CD.MaTuyen join HANGVE HV on HV.MaHangVe = CD.MaHangVe" +
            " where BenXeDen in (select BX1.MaBenXe" +
            " from BENXE BX1" +
            " where BX1.TenBenXe = N'" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() + "')" +
            " and BenXeDi in (select BX2.MaBenXe" +
            " from BENXE BX2" +
            " where BX2.TenBenXe = N'" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "')" +
            " and CONVERT(date, NgayGio) = CONVERT(date, '" + FormatDate(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString())  + "')" +
            " and CONVERT(time, NgayGio) = CONVERT(time, '" + dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString() + "') ";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            string BXTG = "";
            int TGDung = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    label48.Text = reader["SoLuongGhe"].ToString();
                    BXTG += reader["BenXeTrungGian"].ToString() + "\n";
                    TGDung += Convert.ToInt32(reader["ThoiGianDung"]);
                    label62.Text = reader["ThoiGianDi"].ToString();
                    label49.Text = reader["TenHangVe"].ToString();
                }
            }
            label61.Text = BXTG;
            label60.Text = TGDung.ToString();
            bunifuPages1.SetPage("QLCD - TTCD");
        }

        private void btn_Themcd_Click(object sender, EventArgs e)
        {
            DropDown_Qlcd_Them_BXD.Text = "";
            DropDown_Qlcd_Them_BXDi.Text = "";
            input_Qlcd_Them_ThoiGian.Text = "";
            input_Qlcd_Them_GiaVe.Text = "";
            DropDown_Qlcd_Them_HV.Text = "";
            input_Qlcd_Them_SoGhe.Text = "";
            bunifuDropdown14.Text = "";
            dataGridView4.Rows.Clear();
            if (dataGridView4.Columns.Count > 1)
            {
                dataGridView4.Columns.RemoveAt(2);
                dataGridView4.Columns.RemoveAt(1);
            }
            DataGridViewComboBoxColumn BXTG = new DataGridViewComboBoxColumn();
            BXTG.FlatStyle = FlatStyle.Flat;
            
            string sql_query = "select TenBenXe from BENXE BX ";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DropDown_Qlcd_Them_BXD.Items.Add(reader["TenBenXe"].ToString());
                }
            }
            sql_query = "select *" +
                " from THAMSO";
            cmd = new SqlCommand(sql_query, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    label36.Text = ">= " + reader["ThoiGianDiToiThieu"].ToString();
                    label10.Text = reader["ThoiGianDungToiThieu"].ToString() + " >= TGD >= " + reader["ThoiGianDungToiDa"].ToString();
                    bunifuDropdown14.Items.Clear();
                    for (int i = 1;  i <= Convert.ToInt32(reader["SoBenXeTrungGianToiDa"]); i++)
                    {
                        bunifuDropdown14.Items.Add(i);
                    }    
                }
            }
            DropDown_Qlcd_Them_HV.Items.Clear();
            sql_query = "select TenHangVe from HANGVE";
            cmd = new SqlCommand(sql_query, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DropDown_Qlcd_Them_HV.Items.Add(reader["TenHangVe"].ToString());
                }
            }

            bunifuPages1.SetPage("QLCD - Thêm chuyến đi");
        }

        private void bunifuDropdown14_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            if (dataGridView4.Columns.Count < 2)
            {
                DataGridViewComboBoxColumn BXTG = new DataGridViewComboBoxColumn();
                DataGridViewTextBoxColumn TGD = new DataGridViewTextBoxColumn();
                BXTG.FlatStyle = FlatStyle.Flat;
                TGD.HeaderText = "Thời gian dừng";
                BXTG.HeaderText = "Bến xe trung gian";
                string sql_query = "select TenBenXe from BENXE BX where TenBenXe <> N'" + DropDown_Qlcd_Them_BXD.Text + "' and TenBenXe <> N'" + DropDown_Qlcd_Them_BXDi.Text +"'";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BXTG.Items.Add(reader["TenBenXe"].ToString());
                    }
                }
                
                dataGridView4.Columns.Add(BXTG);
                dataGridView4.Columns.Add(TGD);
            }
            
            for (int i = 1; i <= Convert.ToInt32(bunifuDropdown14.Text);i++)
            {
                dataGridView4.Rows.Add(i.ToString());
            }
        }

        private void input_DatVe_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            
        }

        private void input_DatVe_HoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;
            }

        }

        private void DropDown_Qlcd_Them_BXD_SelectedValueChanged(object sender, EventArgs e)
        {
            DropDown_Qlcd_Them_BXDi.Items.Clear();
            string sql_query = "select TenBenXe from BENXE BX where TenBenXe <> N'" + DropDown_Qlcd_Them_BXD.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DropDown_Qlcd_Them_BXDi.Items.Add(reader["TenBenXe"].ToString());
                }

            }
        }

        private void btn_qlcd_Them_Fi_Click(object sender, EventArgs e)
        {
            string sql_query = "select MaTuyen " +
                " from TUYEN" +
                " where BenXeDen = (select MaBenXe from BENXE where TenBenXe = N'" + DropDown_Qlcd_Them_BXD.Text + "')" +
                " and BenXeDi = (select MaBenXe from BENXE where TenBenXe = N'" + DropDown_Qlcd_Them_BXDi.Text + "')";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            int check = 1;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    check = 0;
                    break;
                }
            }
            if (check == 1)
            {
                sql_query = "insert into TUYEN (BenXeDen,BenXeDi)" +
                    " select BX1.MaBenXe as BenXeDen, RES.MaBenXe as BenXeDi" +
                    " from BENXE BX1 , (select BX2.MaBenXe" +
                    " from BENXE BX2" +
                    " where BX2.TenBenXe = N'" + DropDown_Qlcd_Them_BXDi.Text + "') AS RES" +
                    " where BX1.TenBenXe = N'" + DropDown_Qlcd_Them_BXD.Text + "'";
                cmd = new SqlCommand(sql_query, con);
                //MessageBox.Show(sql_query);
                cmd.ExecuteNonQuery();
            }
            sql_query = "select MaTuyen " +
                " from TUYEN" +
                " where BenXeDen = (select MaBenXe from BENXE where TenBenXe = N'" + DropDown_Qlcd_Them_BXD.Text + "')" +
                " and BenXeDi = (select MaBenXe from BENXE where TenBenXe = N'" + DropDown_Qlcd_Them_BXDi.Text + "')";
            cmd = new SqlCommand(sql_query, con);
            string matuyen = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    matuyen = reader["MaTuyen"].ToString();
                }
            }
            sql_query = "select MaHangVe" +
                " from HANGVE" +
                " where TenHangVe = N'"+ DropDown_Qlcd_Them_HV.Text + "'";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            string mahv = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    mahv = reader["MaHangVe"].ToString();
                }
            }
            sql_query = "insert into CHUYENDI(MaTuyen, MaHangVe, NgayGio, ThoiGianDi, SoLuongGhe) values " +
                " (" + matuyen + ", " + mahv + ", '" + FormatDate(Date_Qlcd_Them.Text) +" " + Time_Qlcd_Them.Text + "', " + input_Qlcd_Them_ThoiGian.Text + ", " + input_Qlcd_Them_SoGhe.Text + ")";
            cmd = new SqlCommand(sql_query, con);
            
            cmd.ExecuteNonQuery();
            sql_query = "select MaChuyenDi" +
                " from CHUYENDI" +
                " where MaTuyen = " + matuyen + "" +
                " and convert(Date, NgayGio) = convert(Date, '" + FormatDate(Date_Qlcd_Them.Text) + "')" +
                " and convert(time, NgayGio) = convert(time, '" + Time_Qlcd_Them.Text + "')";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            string macd = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    macd = reader["MaChuyenDi"].ToString();
                }
            }
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                string Bxtg = Tim_BXTG(dataGridView4.Rows[i].Cells[1].Value.ToString());
                sql_query = "insert into CHITIETCHUYENDI(MaChuyenDi,BenXeTrungGian,ThoiGianDung) values " +
               " (" + macd + "," + Bxtg + "," + Convert.ToInt32(dataGridView4.Rows[i].Cells[2].Value) + ")";
                cmd = new SqlCommand(sql_query, con);
                //MessageBox.Show(sql_query);
                cmd.ExecuteNonQuery();
            }
            sql_query = "insert into DONGIA (GiaVe, MaTuyen, MaHangVe) values" +
                " (" + input_Qlcd_Them_GiaVe.Text + "," + matuyen + "," + mahv + ")";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "insert into TINHTRANGCD(MaChuyenDi, SoGheTrong, SoGheDat) values" +
                " (" + macd + ", " + input_Qlcd_Them_SoGhe.Text + "," + 0 + ")";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            ThanhCong notice = new ThanhCong("Bạn đã thêm chuyến đi thành công");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Quản lý chuyến đi");
            }
        }

        private void btn_Qlbx_Click(object sender, EventArgs e)
        {
            btn_Qlbx.Image = Properties.Resources.btn_Qlbx_click;
            btn_Qlbx.BackColor = Color.FromArgb(78, 204, 163);

            btn_Qlcd.Image = Properties.Resources.btn_qlcd;
            btn_Qlcd.BackColor = Color.Transparent;

            btn_Tkbc.Image = Properties.Resources.btn_tkbc;
            btn_Tkbc.BackColor = Color.Transparent;

            btn_Qlnd.Image = Properties.Resources.btn_QLND;
            btn_Qlnd.BackColor = Color.Transparent;

            btn_QuyDinh.Image = Properties.Resources.btn_QuyDinh;
            btn_QuyDinh.BackColor = Color.Transparent;

            btn_DatVe.Image = Properties.Resources.btn_datve;
            btn_DatVe.BackColor = Color.Transparent;
            if (btn_Qlbx.Tag.ToString() == "true")
            {
                btn_Qlbx.Tag = "Quản Lý Bến Xe";
            }
            else btn_Qlbx.Tag = "true";
           
            bunifuPages1.SetPage("Quản Lý Bến Xe");
        }



        private void Qlbx_Keyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                dataGridView3.Rows.Clear();
                string sql_query = "select TenBenXe" +
                    " from BENXE" +
                    " where TenBenXe like N'%" + Qlbx_Keyword.Text + "%'";
                //MessageBox.Show(sql_query);
                SqlCommand cmd = new SqlCommand(sql_query, con);
                //MessageBox.Show(sql_query);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int count = 1;
                    while (reader.Read())
                    {

                        //MessageBox.Show(count.ToString());
                        Bitmap icon = new Bitmap(Properties.Resources.icon_x, new Size(30, 30));
                        dataGridView3.Rows.Add(count, reader["TenBenXe"].ToString(), (Image)icon);
                        count++;
                    }

                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                string sql_query = "delete from BENXE" +
                    " where TenBenXe = N'" + dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                //MessageBox.Show(sql_query);
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show(sql_query);
                dataGridView3.Rows.RemoveAt(e.RowIndex);
                for (int i = 1; i <= dataGridView3.Rows.Count; i++)
                {
                    dataGridView3.Rows[i - 1].Cells[0].Value = i;
                }
                ThanhCong notice = new ThanhCong("Đã xoá bến xe thành công");
                
                if (notice.ShowDialog() == DialogResult.OK)
                {
                    notice.Close();
                    bunifuPages1.SetPage("Quản Lý Bến Xe");
                }
            }
        }

        private void btn_Thembx_Click(object sender, EventArgs e)
        {
            string sql_query = "insert into BENXE(TenBenXe) values (N'"+ Qlbx_Keyword_Them.Text +"')";
            //MessageBox.Show(sql_query);
            SqlCommand cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            ThanhCong notice = new ThanhCong("Đã thêm bến xe thành công");
            

            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Quản Lý Bến Xe");
            }

        }

        private void btn_Tkbc_Click(object sender, EventArgs e)
        {
            btn_Tkbc.Image = Properties.Resources.btn_tkbc_click;
            btn_Tkbc.BackColor = Color.FromArgb(78, 204, 163);

            btn_Qlnd.Image = Properties.Resources.btn_QLND;
            btn_Qlnd.BackColor = Color.Transparent;

            btn_QuyDinh.Image = Properties.Resources.btn_QuyDinh;
            btn_QuyDinh.BackColor = Color.Transparent;

            btn_DatVe.Image = Properties.Resources.btn_datve;
            btn_DatVe.BackColor = Color.Transparent;

            btn_Qlcd.Image = Properties.Resources.btn_qlcd;
            btn_Qlcd.BackColor = Color.Transparent;

            btn_Qlbx.Image = Properties.Resources.btn_qlbx;
            btn_Qlbx.BackColor = Color.Transparent;
            if (btn_Tkbc.Tag.ToString() == "true")
            {
                btn_Tkbc.Tag = "Thống kê báo cáo";
            }
            else btn_Tkbc.Tag = "true";
            bunifuPages1.SetPage("Thống kê báo cáo");
        }

        private void Tkbc_LoaiBC_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Tkbc_LoaiBC.Text == "Báo cáo Năm")
            {
                label158.Visible = false;
                DropDown_Thang.Visible = false;
            }
            else
            {
                label158.Visible = true;
                DropDown_Thang.Visible = true;
            }
        }

        private void Dropdown_Nam_SelectedValueChanged(object sender, EventArgs e)
        {
            DropDown_Thang.Items.Clear();
            string year = DateTime.Now.Year.ToString();
            if(Dropdown_Nam.Text == year)
            {
                for (int i = 1; i < DateTime.Now.Month; i++)
                {
                    DropDown_Thang.Items.Add(i);
                }    
            }
            else
            {
                for(int i = 1; i <= 12; i++)
                {
                    DropDown_Thang.Items.Add(i);
                }    
            }
        }

        private void btn_XemBC_Click(object sender, EventArgs e)
        {
            
            int sumsove = 0;
            int sumdoanhthu = 0;
            
            if (Tkbc_LoaiBC.Text == "Báo cáo Năm")
            {
                string sql_query = "select DTT.Thang, DTT.SoChuyenDi, DTT.TyLe, DTT.TongDoanhThuThang" +
                    " from DOANHTHUNAM DTN, DOANHTHUTHANG DTT" +
                    " where DTN.MaDoanhThuNam = DTT.MaDoanhThuNam" +
                    " and DTN.Nam = " + Dropdown_Nam.Text ;
                SqlCommand cmd = new SqlCommand(sql_query, con);
                //MessageBox.Show(sql_query);
                dataGridView6.Rows.Clear();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int count = 1;
                    while (reader.Read())
                    {
                        dataGridView6.Rows.Add(count, reader["Thang"].ToString(), reader["SoChuyenDi"].ToString(), reader["TongDoanhThuThang"].ToString().Substring(0, reader["TongDoanhThuThang"].ToString().IndexOf(".")), reader["TyLe"].ToString().Substring(0, 4));
                        count++;
                    }

                }
                for (int i = 0; i < dataGridView6.Rows.Count; i++)
                {
                    sumsove += Convert.ToInt32(dataGridView6.Rows[i].Cells[2].Value.ToString());
                    sumdoanhthu += Convert.ToInt32(dataGridView6.Rows[i].Cells[3].Value.ToString());

                }

                label149.Text = sumsove.ToString();
                label147.Text = sumdoanhthu.ToString();
                label127.Text = "Thống kê báo cáo năm " + Dropdown_Nam.Text + "";
                bunifuPages1.SetPage("TKBC - Nam");
            }
            else
            {
                string sql_query = "select TenBenXe as TenBenXeDi, sum(SoVe) as SoVe, sum(DoanhThu) as DoanhThu, AVG(TyLe) as TyLe, TenBenXeDen" +
                 " from BENXE BX1, (select TenBenXe as TenBenXeDen , CTDTT.SoVe, CTDTT.DoanhThu, CTDTT.TyLe,BenXeDi" +
                 " from DOANHTHUTHANG DTT, DOANHTHUNAM DTN, CTDOANHTHUTHANG CTDTT, TUYEN T, BENXE BX, CHUYENDI CD" +
                 " where DTN.MaDoanhThuNam = DTT.MaDoanhThuNam" +
                 " and DTT.MaDoanhThuThang = CTDTT.MaDoanhThuThang" +
                 " and DTN.Nam = " + Dropdown_Nam.Text +
                 " and DTT.Thang = " + DropDown_Thang.Text +
                 " and T.MaTuyen = CD.MaTuyen" +
                 " and CD.MaChuyenDi = CTDTT.MaChuyenDi" +
                 " and BX.MaBenXe = T.BenXeDen) AS RES" +
                 " where BX1.MaBenXe = RES.BenXeDi" +
                 " GROUP BY TenBenXeDen, BX1.TenBenXe";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                //MessageBox.Show(sql_query);
                dataGridView5.Rows.Clear();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int count = 1;
                    while (reader.Read())
                    {
                        dataGridView5.Rows.Add(count, reader["TenBenXeDen"].ToString(), reader["TenBenXeDi"], reader["SoVe"].ToString(), reader["DoanhThu"].ToString().Substring(0, reader["DoanhThu"].ToString().IndexOf(".")), reader["TyLe"].ToString().Substring(0, 4));
                        count++;
                    }

                }
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {

                    sumsove += Convert.ToInt32(dataGridView5.Rows[i].Cells[3].Value.ToString());
                    sumdoanhthu += Convert.ToInt32(dataGridView5.Rows[i].Cells[4].Value.ToString());

                }
                label126.Text = "Thống kê báo cáo tháng " + DropDown_Thang.Text + "/" + Dropdown_Nam.Text + " ";
                label128.Text = sumsove.ToString();
                label145.Text = sumdoanhthu.ToString();
                bunifuPages1.SetPage("TKBC - Thang");
            }
            
        }

        private void btn_QuyDinh_Click(object sender, EventArgs e)
        {
            btn_QuyDinh.Image = Properties.Resources.btn_QD_click;
            btn_QuyDinh.BackColor = Color.FromArgb(78, 204, 163);
            btn_Qlcd.Image = Properties.Resources.btn_qlcd;
            btn_Qlcd.BackColor = Color.Transparent;

            btn_Qlbx.Image = Properties.Resources.btn_qlbx;
            btn_Qlbx.BackColor = Color.Transparent;

            btn_Tkbc.Image = Properties.Resources.btn_tkbc;
            btn_Tkbc.BackColor = Color.Transparent;

            btn_Qlnd.Image = Properties.Resources.btn_QLND;
            btn_Qlnd.BackColor = Color.Transparent;

            btn_DatVe.Image = Properties.Resources.btn_datve;
            btn_DatVe.BackColor = Color.Transparent;
            if (btn_QuyDinh.Tag.ToString() == "true")
            {
                btn_QuyDinh.Tag = "Quy Định";
            }
            else btn_QuyDinh.Tag = "true";


            string sql_query = "select * from THAMSO";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    label137.Text = reader["ThoiGianDiToiThieu"].ToString();
                    label138.Text = reader["SoBenXeTrungGianToiDa"].ToString();
                    label139.Text = reader["ThoiGianDungToiDa"].ToString();
                    label140.Text = reader["ThoiGianDungToiThieu"].ToString();
                    label142.Text = reader["TGChamNhatDatVe"].ToString();
                    label143.Text = reader["TGChamNhatHuyVe"].ToString();
                    label141.Text = reader["SoLuongHangVeToiDa"].ToString();
                }

            }
            bunifuPages1.SetPage("Quy Định");
        }

        private void btn_ThayQD1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Thay Đổi QĐ1");
            QD1_ThoiGian.Text = label137.Text;
            QD1_BXTG.Text = label138.Text;
            QD1_DungToiDa.Text = label139.Text;
            QD1_DungToiThieu.Text = label140.Text;
        }

        private void btn_LuuQD1_Click(object sender, EventArgs e)
        {
            string sql_query = "update THAMSO" +
                " set ThoiGianDiToiThieu = "+ QD1_ThoiGian.Text + "," +
                " SoBenXeTrungGianToiDa = " + QD1_BXTG.Text + "," +
                " ThoiGianDungToiDa = " + QD1_DungToiDa.Text + "," +
                " ThoiGianDungToiThieu = " + QD1_DungToiThieu.Text + "";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            cmd.ExecuteReader();
            //MessageBox.Show("Thanh cong");
            sql_query = "select * from THAMSO";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    label137.Text = reader["ThoiGianDiToiThieu"].ToString();
                    label138.Text = reader["SoBenXeTrungGianToiDa"].ToString();
                    label139.Text = reader["ThoiGianDungToiDa"].ToString();
                    label140.Text = reader["ThoiGianDungToiThieu"].ToString();
                }

            }
            ThanhCong notice = new ThanhCong("Thay đổi quy định 1 thành công");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Quy Định");
            }
            

        }

        private void DropDown_BXDi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Qlbx_MouseLeave(object sender, EventArgs e)
        {
            if (btn_Qlbx.Tag.ToString() != "true")
            {
                btn_Qlbx.Image = Properties.Resources.btn_qlbx;
                btn_Qlbx.BackColor = Color.Transparent;
            }

        }

        private void btn_Qlbx_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Qlbx.Image = Properties.Resources.btn_Qlbx_click;
            btn_Qlbx.BackColor = Color.FromArgb(78, 204, 163);
        }

        private void btn_Tkbc_MouseLeave(object sender, EventArgs e)
        {
            if (btn_Tkbc.Tag.ToString() != "true")
            {
                btn_Tkbc.Image = Properties.Resources.btn_tkbc;
                btn_Tkbc.BackColor = Color.Transparent;
            }
        }

        private void btn_Tkbc_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Tkbc.Image = Properties.Resources.btn_tkbc_click;
            btn_Tkbc.BackColor = Color.FromArgb(78, 204, 163);

        }

        private void btn_Qlnd_MouseLeave(object sender, EventArgs e)
        {
            if (btn_Qlnd.Tag.ToString() != "true")
            {
                btn_Qlnd.Image = Properties.Resources.btn_QLND;
                btn_Qlnd.BackColor = Color.Transparent;
            }


        }

        private void btn_Qlnd_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Qlnd.Image = Properties.Resources.btn_Qlnd_click;
            btn_Qlnd.BackColor = Color.FromArgb(78, 204, 163);

        }

        private void btn_Qlnd_Click(object sender, EventArgs e)
        {
            btn_Qlnd.Image = Properties.Resources.btn_Qlnd_click;
            btn_Qlnd.BackColor = Color.FromArgb(78, 204, 163);
            btn_QuyDinh.Image = Properties.Resources.btn_QuyDinh;
            btn_QuyDinh.BackColor = Color.Transparent;

            btn_DatVe.Image = Properties.Resources.btn_datve;
            btn_DatVe.BackColor = Color.Transparent;
            btn_Qlcd.Image = Properties.Resources.btn_qlcd;
            btn_Qlcd.BackColor = Color.Transparent;

            btn_Qlbx.Image = Properties.Resources.btn_qlbx;
            btn_Qlbx.BackColor = Color.Transparent;

            btn_Tkbc.Image = Properties.Resources.btn_tkbc;
            btn_Tkbc.BackColor = Color.Transparent;
            if (btn_Qlnd.Tag.ToString() == "true")
            {
                btn_Qlnd.Tag = "Quản lý người dùng";
            }
            else btn_Qlnd.Tag = "true";
            bunifuPages1.SetPage("Quản lý người dùng");


            if (dataGridView8.Columns.Count <= 5)
            {
                LoaiND.HeaderText = "Loại người dùng";

                string sql_query = "select TenLoaiND from LOAINGUOIDUNG";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                //MessageBox.Show(sql_query);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LoaiND.Items.Add(reader["TenLoaiND"].ToString());
                    }
                }
                dataGridView8.Columns.Insert(3, LoaiND); 
            }

        }

        private void btn_QuyDinh_MouseLeave(object sender, EventArgs e)
        {
            if (btn_QuyDinh.Tag.ToString() != "true")
            {
                btn_QuyDinh.Image = Properties.Resources.btn_QuyDinh;
                btn_QuyDinh.BackColor = Color.Transparent;
            }

        }

        private void btn_QuyDinh_MouseMove(object sender, MouseEventArgs e)
        {
            btn_QuyDinh.Image = Properties.Resources.btn_QD_click;
            btn_QuyDinh.BackColor = Color.FromArgb(78, 204, 163);

        }

        private void btn_DatVe_fi_Click(object sender, EventArgs e)
        {

            string sql_query = "if ('" + input_DatVe_HoTen.Text +"' not in (select HoTen" +
                " from KHACHHANG))" +
                " insert into KHACHHANG(HoTen, DienThoai) values" +
                " (N'" + input_DatVe_HoTen.Text + "','" + input_DatVe_SDT.Text + "')";
            //MessageBox.Show(sql_query);
            SqlCommand cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();


            sql_query = "update TINHTRANGCD" +
                " set SoGheTrong = SoGheTrong - 1, SoGheDat = SoGheDat + 1" +
                " where MaChuyenDi = " + Tim_MaCD(Text_DatVe_BXD.Text, Text_DatVe_BXDi.Text, Text_DatVe__NgayGio.Text) + "";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            cmd.ExecuteNonQuery();
            string maKH = "";
            sql_query = "select MaKhachHang" +
                " from KHACHHANG KH" +
                " where HoTen = N'" + input_DatVe_HoTen.Text + "'";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    maKH = reader["MaKhachHang"].ToString();
                }
            }
            string maND = "";
            sql_query = "select MaNguoiDung" +
                " from NGUOIDUNG" +
                " where TenDangNhap = N'"+ TenDangNhap +"'";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    maND = reader["MaNguoiDung"].ToString();
                }
            }
            sql_query = "insert into PHIEUDATCHO(MaChuyenDi, MaKhachHang, MaGhe, MaNguoiDung, NgayDat) values" +
                " (" + Tim_MaCD(Text_DatVe_BXD.Text, Text_DatVe_BXDi.Text, Text_DatVe__NgayGio.Text) + ", " + maKH + ",'" + DropDown_DatVe_ViTri.Text + "'," + maND + ",'" + FormatDate(DateTime.Now.ToShortDateString()) + "')";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            cmd.ExecuteNonQuery();
            sql_query = "insert into VECHUYENDI(MaChuyenDi, MaKhachHang, MaGhe, MaNguoiDung) values" +
                " (" + Tim_MaCD(Text_DatVe_BXD.Text, Text_DatVe_BXDi.Text, Text_DatVe__NgayGio.Text) + ", " + maKH + ",'" + DropDown_DatVe_ViTri.Text + "'," + maND + ")";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            cmd.ExecuteNonQuery();

            sql_query = "insert into GHE(MaGhe, MaChuyenDi, MaKhachHang, TenGhe) values" +
                " ('" + DropDown_DatVe_ViTri.Text + "'," + Tim_MaCD(Text_DatVe_BXD.Text, Text_DatVe_BXDi.Text, Text_DatVe__NgayGio.Text) + ", " + maKH + ",'" + DropDown_DatVe_ViTri.Text + "')";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            cmd.ExecuteNonQuery();

            //MessageBox.Show("thanh công rồi ^^");
            input_DatVe_SDT.Text = "";
            input_DatVe_HoTen.Text = "";
            DropDown_DatVe_ViTri.Text = "";
            ThanhCong notice = new ThanhCong("Bạn đã đặt vé thành công");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Đặt vé");
            }
            
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            Text_TTDV_BXD.Text = Text_DV_BXD.Text;
            Text_TTDV_BXDi.Text = Text_DV_BXDi.Text;
            Text_TTDV_NgayGio.Text = Text_DV_NgayGio.Text;
            Text_TTDV_ThoiGian.Text = Text_DV_ThoiGian.Text;
            Text_TTDV_BXTG.Text = Text_DV_BXTG.Text;
            Text_TTDV_TGDung.Text = Text_DV_TGDung.Text;
            Text_TTDV_GiaVe.Text = Text_DV_GiaVe.Text;
            Text_TTDV_HV.Text = Text_DV_HangVe.Text;
            Text_TTDV_GheTrong.Text = Text_DV_GheTrong.Text;
            CS_TTDV_SDT.Text = Text_DV_SDT.Text;
            CS_TTDV_HoTen.Text = Text_DV_HoTen.Text;
            CS_TTDV_ViTri.Text = Text_DV_ViTri.Text;

            List<string> temp = new List<string>();
            string sql_query = "select MaGhe" +
                       " from GHE G" +
                       " where MaChuyenDi in (select MaChuyenDi" +
                       " from CHUYENDI CD join TUYEN T on CD.MaTuyen = T.MaTuyen" +
                       " where BenXeDen in (select BX1.MaBenXe" +
                       " from BENXE BX1" +
                       " where BX1.TenBenXe = N'" + DropDown_BXD.Text + "')" +
                       " and BenXeDi in (select BX2.MaBenXe" +
                       " from BENXE BX2" +
                       " where BX2.TenBenXe = N'" + DropDown_BXDi.Text + "')" +
                       " and CONVERT(date, NgayGio) = CONVERT(date, '" + FormatDate(Text_TTDV_NgayGio.Text) + "'))";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //MessageBox.Show(reader["MaGhe"].ToString());
                    temp.Add(reader["MaGhe"].ToString());
                }

            }
            temp.Add(Text_DV_ViTri.Text);
            sql_query = "select SoLuongGhe" +
                       " from CHUYENDI CD" +
                       " where MaChuyenDi in (select MaChuyenDi" +
                       " from CHUYENDI CD join TUYEN T on CD.MaTuyen = T.MaTuyen" +
                       " where BenXeDen in (select BX1.MaBenXe" +
                       " from BENXE BX1" +
                       " where BX1.TenBenXe = N'" + Text_TTDV_BXD.Text + "')" +
                       " and BenXeDi in (select BX2.MaBenXe" +
                       " from BENXE BX2" +
                       " where BX2.TenBenXe = N'" + Text_TTDV_BXDi.Text + "')" +
                       " and CONVERT(date, NgayGio) = CONVERT(date, '" + FormatDate(Text_TTDV_NgayGio.Text) + "'))";
            cmd = new SqlCommand(sql_query, con);
            int sl_ghe = 0;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    sl_ghe = Convert.ToInt32(reader["SoLuongGhe"].ToString());
                }

            }
            CS_TTDV_ViTri.Items.Clear();
            for (int i = 1; i <= 9 && i <= sl_ghe; i++)
            {
                if (!temp.Contains("A0" + i))
                {
                    CS_TTDV_ViTri.Items.Add("A0" + i);
                }
            }
            for (int i = 10; i <= sl_ghe; i++)
            {
                if (!temp.Contains("A" + i))
                {
                    CS_TTDV_ViTri.Items.Add("A" + i);
                }
            }
            viTriGhe3.Xoa();
            viTriGhe3.HienThi(temp);


            bunifuPages1.SetPage("DV - TTDV - CS");
        }

        private void btn_ChinhSua1_Click(object sender, EventArgs e)
        {
            string sql_query = "update KHACHHANG " +
                " set DienThoai = '"+ CS_TTDV_SDT.Text + "', HoTen = N'"+ CS_TTDV_HoTen.Text + "'" +
                " where DienThoai = '"+ Text_DV_SDT.Text+ "' and HoTen = N'"+ Text_DV_HoTen.Text+ "'";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "update GHE" +
                " set MaGhe = '"+ CS_TTDV_ViTri.Text + "', TenGhe = '" + CS_TTDV_ViTri.Text + "'" +
                " where MaChuyenDi = "+ Tim_MaCD(Text_TTDV_BXD.Text, Text_TTDV_BXDi.Text, Text_TTDV_NgayGio.Text) + " and MaKhachHang = "+ Tim_MaKH(Text_DV_HoTen.Text) + "";
 
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();

            sql_query = "update PHIEUDATCHO" +
                " set MaGhe = '" + CS_TTDV_ViTri.Text + "'" +
                " where MaChuyenDi = " + Tim_MaCD(Text_TTDV_BXD.Text, Text_TTDV_BXDi.Text, Text_TTDV_NgayGio.Text) + "and MaKhachHang = " + Tim_MaKH(Text_DV_HoTen.Text) + "";

            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Chỉnh sửa thành công");
            bunifuPages1.SetPage("Đặt vé");
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            string sql_query = "delete from PHIEUDATCHO " +
                " where MaChuyenDi = "+ Tim_MaCD(Text_DV_BXD.Text, Text_DV_BXDi.Text, Text_DV_NgayGio.Text) + " and MaKhachHang =" + Tim_MaKH(Text_DV_HoTen.Text) + "";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from GHE " +
                " where MaChuyenDi = " + Tim_MaCD(Text_DV_BXD.Text, Text_DV_BXDi.Text, Text_DV_NgayGio.Text) + " and MaKhachHang =" + Tim_MaKH(Text_DV_HoTen.Text) + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from VECHUYENDI " +
                " where MaChuyenDi = " + Tim_MaCD(Text_DV_BXD.Text, Text_DV_BXDi.Text, Text_DV_NgayGio.Text) + " and MaKhachHang =" + Tim_MaKH(Text_DV_HoTen.Text) + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "update TINHTRANGCD" +
                " set SoGheTrong = SoGheTrong + 1, SoGheDat = SoGheDat - 1" +
                " where MaChuyenDi = " + Tim_MaCD(Text_DV_BXD.Text, Text_DV_BXDi.Text, Text_DV_NgayGio.Text) + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Bạn đã xoá thành công");
            ThanhCong notice = new ThanhCong("Bạn đã huỷ vé thành công");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Đặt vé");
            }
           
        }

        private void btn_Chinhsuacd_Click(object sender, EventArgs e)
        {
            CSCD_BXD.Text = label75.Text;
            CSCD_BXDi.Text = label74.Text;
            CSCD_ThoiGian.Text = label62.Text;
            CSCD_Date.Text = label63.Text.Substring(0, label63.Text.IndexOf(" "));
            CSCD_Time.Text = label63.Text.Substring(label63.Text.IndexOf(" ") + 1);
            CSCD_GiaVe.Text = label50.Text;
            CSCD_HangVe.Text = label49.Text;
            CSCD_SoGhe.Text = label48.Text;
            dataGridView7.Rows.Clear();
            string sql_query = "select *" +
                " from THAMSO";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    CSCD_SL.Items.Clear();
                    for (int i = 1; i <= Convert.ToInt32(reader["SoBenXeTrungGianToiDa"]); i++)
                    {
                        CSCD_SL.Items.Add(i);
                    }
                }
            }
           
            bunifuPages1.SetPage("QLCD - Chỉnh sửa cđ");
        }

        

        private void CSCD_SL_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView7.Rows.Clear();
            /*MessageBox.Show(dataGridView7.Columns.Count.ToString());*/
            if (dataGridView7.Columns.Count < 2)
            {
                DataGridViewComboBoxColumn BXTG = new DataGridViewComboBoxColumn();
                DataGridViewTextBoxColumn TGD = new DataGridViewTextBoxColumn();
                BXTG.FlatStyle = FlatStyle.Flat;
                TGD.HeaderText = "Thời gian dừng";
                BXTG.HeaderText = "Bến xe trung gian";
                string sql_query = "select TenBenXe from BENXE BX where TenBenXe <> N'" + CSCD_BXD.Text + "' and TenBenXe <> N'" + CSCD_BXDi.Text + "'";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BXTG.Items.Add(reader["TenBenXe"].ToString());
                    }
                }

                dataGridView7.Columns.Add(BXTG);
                dataGridView7.Columns.Add(TGD);
            }

            for (int i = 1; i <= Convert.ToInt32(CSCD_SL.Text); i++)
            {
                dataGridView7.Rows.Add(i.ToString());
            }
        }

        private void btn_Chinhsuacd_fi_Click(object sender, EventArgs e)
        {
            string sql_query = "";
            SqlCommand cmd = new SqlCommand();

            sql_query = "delete from CHITIETCHUYENDI" +
                " where MaChuyenDi = '" + Tim_MaCD(CSCD_BXD.Text, CSCD_BXDi.Text, label63.Text) + "'";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                string Bxtg = Tim_BXTG(dataGridView7.Rows[i].Cells[1].Value.ToString());
                sql_query = "insert into CHITIETCHUYENDI(MaChuyenDi,BenXeTrungGian,ThoiGianDung) values " +
               " (" + Tim_MaCD(CSCD_BXD.Text, CSCD_BXDi.Text, label63.Text) + "," + Bxtg + "," + Convert.ToInt32(dataGridView7.Rows[i].Cells[2].Value) + ")";
                cmd = new SqlCommand(sql_query, con);
                //MessageBox.Show(sql_query);
                cmd.ExecuteNonQuery();
            }

            sql_query = "update CHUYENDI" +
                " set NgayGio = CONVERT(datetime, '"+ FormatDate(CSCD_Date.Text)+ " "+ CSCD_Time.Text + "')" +
                " where MaChuyenDi = "+ Tim_MaCD(CSCD_BXD.Text, CSCD_BXDi.Text, label63.Text) +"";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();

            ThanhCong notice = new ThanhCong("Đã cập nhật chuyến đi thành công");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Quản lý chuyến đi");
            }
            //MessageBox.Show("Chỉnh sửa thành công");
            

        }

        private void btn_ThayQD2_Click(object sender, EventArgs e)
        {
            bunifuTextBox26.Text = label141.Text;

            bunifuPages1.SetPage("Thay Đổi QĐ2");



        }

        private void btn_LuuQD2_Click(object sender, EventArgs e)
        {
            string sql_query = "update THAMSO" +
                " set SoLuongHangVeToiDa = " + bunifuTextBox26.Text + ""; 
            SqlCommand cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from HANGVE";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            for (int i = 1; i <= Convert.ToInt32(bunifuTextBox26.Text); i++)
            {
                sql_query = "insert into HANGVE(TenHangVe) values " +
                    " (N'"+"Loại " + i +"')";
                cmd = new SqlCommand(sql_query, con);
                cmd.ExecuteNonQuery();
            }
            label141.Text = bunifuTextBox26.Text;
            ThanhCong notice = new ThanhCong("Thay đổi quy định 2 thành công");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Quy Định");
            }
            
        }

        private void btn_ThayQD3_Click(object sender, EventArgs e)
        {
            bunifuTextBox2.Text = label142.Text;
            bunifuTextBox3.Text = label143.Text;
            bunifuPages1.SetPage("Thay Đổi QĐ3");
        }

        private void btn_LuuTD3_Click(object sender, EventArgs e)
        {
            string sql_query = "update THAMSO" +
               " set TGChamNhatDatVe = " + bunifuTextBox2.Text + ", TGChamNhatHuyVe = "+ bunifuTextBox3.Text + "";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "select * from THAMSO";
            cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    label142.Text = reader["TGChamNhatDatVe"].ToString();
                    label143.Text = reader["TGChamNhatHuyVe"].ToString(); 
                }

            }
            ThanhCong notice = new ThanhCong("Thay đổi quy định 3 thành công");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Quy Định");
            }
            

        }

        private void btn_ThemND_Click(object sender, EventArgs e)
        {
            string sql_query = "select TenLoaiND from LOAINGUOIDUNG";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query)
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bunifuDropdown1.Items.Add(reader["TenLoaiND"].ToString());
                }
            }
            
            bunifuPages1.SetPage("QLND - Thêm");
        }

        private void bunifuTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                dataGridView8.Rows.Clear();

                string sql_query = "select TenDangNhap, MatKhau, TenLoaiND" +
                    " from NGUOIDUNG ND join LOAINGUOIDUNG LND on ND.MaLoaiND = LND.MaLoaiND" +
                    " where TenDangNhap like N'%" + bunifuTextBox4.Text + "%'";
                //MessageBox.Show(sql_query);
                SqlCommand cmd = new SqlCommand(sql_query, con);
                //MessageBox.Show(sql_query);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int count = 1;
                    while (reader.Read())
                    {

                        Bitmap icon_capnhat = new Bitmap(Properties.Resources.btn_capnhat, new Size(70,30 ));
                        
                        Bitmap icon = new Bitmap(Properties.Resources.icon_x, new Size(30, 30));
                        dataGridView8.Rows.Add(count, reader["TenDangNhap"].ToString(), reader["MatKhau"].ToString(),reader["TenLoaiND"].ToString(), (Image)icon_capnhat, (Image)icon);
                        count++;
                    }

                }

            }



        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql_query = "select MaLoaiND" +
                " from LOAINGUOIDUNG" +
                " where TenLoaiND = '"+dataGridView8.Rows[e.RowIndex].Cells[3].Value.ToString() +"'";
            //MessageBox.Show(sql_query);
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            string malnd = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    malnd = reader["MaLoaiND"].ToString();
                }

            }

            if (e.ColumnIndex == 4)
            {
                sql_query = "update NGUOIDUNG" +
                    " set MaLoaiND = "+ malnd +"" +
                    " where TenDangNhap = '" + dataGridView8.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                cmd = new SqlCommand(sql_query, con);
                cmd.ExecuteNonQuery();
                ThanhCong notice = new ThanhCong("Cập nhật thành công");

                if (notice.ShowDialog() == DialogResult.OK)
                {
                    notice.Close();
                    bunifuPages1.SetPage("Quản lý người dùng");
                }
                //MessageBox.Show("Cập nhật thành công");
            }    
            else if (e.ColumnIndex == 5)
            {
                sql_query = "delete from NGUOIDUNG" +
                    " where TenDangNhap = '" + dataGridView8.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                cmd = new SqlCommand(sql_query, con);
                cmd.ExecuteNonQuery();
                dataGridView8.Rows.RemoveAt(e.RowIndex);
                for (int i = 0; i < dataGridView8.Rows.Count; i++ )
                {
                    dataGridView8.Rows[i].Cells[0].Value = i;
                }
                ThanhCong notice = new ThanhCong("Đã xoá thành công");

                if (notice.ShowDialog() == DialogResult.OK)
                {
                    notice.Close();
                    bunifuPages1.SetPage("Quản lý người dùng");
                }
            }    
        }

        private void btn_ThemND_Fi_Click(object sender, EventArgs e)
        {
            if(bunifuTextBox1.Text != bunifuTextBox19.Text)
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }
            string sql_query = "select MaLoaiND" +
                " from LOAINGUOIDUNG" +
                " where TenLoaiND = '"+ bunifuDropdown1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query)
            string malnd = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    malnd = reader["MaLoaiND"].ToString();
                }
            }
            sql_query = "insert into NGUOIDUNG(TenDangNhap, MatKhau, MaLoaiND) values " +
                " ('"+ bunifuTextBox20.Text + "','"+ bunifuTextBox19.Text + "', "+ malnd +")";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            ThanhCong notice = new ThanhCong("Đã thêm thành công");

            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Quản lý người dùng");
            }
            //MessageBox.Show("Thêm thành công");
        }

        private void Qlbx_Keyword_Them_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_InBC_Click(object sender, EventArgs e)
        {
            ThanhCong notice = new ThanhCong("Đã in báo cáo");
            
            if(notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Thống kê báo cáo");
            }                
        }

        private void btn_InBCT_Click(object sender, EventArgs e)
        {
            ThanhCong notice = new ThanhCong("Đã in báo cáo");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Thống kê báo cáo");
            }
        }

        private void btn_Huycd_Click(object sender, EventArgs e)
        {
            string macd = Tim_MaCD(label75.Text, label74.Text, label63.Text);
            string sql_query = "delete from CHUYENDI" +
                " where MaChuyenDi = "+ macd +"";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from CHITIETCHUYENDI" +
                " where MaChuyenDi = " + macd + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from TINHTRANGCD" +
                " where MaChuyenDi = " + macd + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from GHE" +
                " where MaChuyenDi = " + macd + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from VECHUYENDI" +
                " where MaChuyenDi = " + macd + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from PHIEUDATCHO" +
                " where MaChuyenDi = " + macd + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();
            sql_query = "delete from CTDOANHTHUTHANG" +
                " where MaChuyenDi = " + macd + "";
            cmd = new SqlCommand(sql_query, con);
            cmd.ExecuteNonQuery();


            //MessageBox.Show("Thành công");
            ThanhCong notice = new ThanhCong("Đã huỷ chuyến đi thành công");
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Quản lý chuyến đi");
            }
        }

        private void Dropdown_Qlcd_BXD_SelectedValueChanged(object sender, EventArgs e)
        {
            Dropdown_Qlcd_BXDi.Items.Clear();
            string sql_query = "select TenBenXe from BENXE BX where TenBenXe <> N'" + Dropdown_Qlcd_BXD.Text + "'";
            SqlCommand cmd = new SqlCommand(sql_query, con);
            //MessageBox.Show(sql_query);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Dropdown_Qlcd_BXDi.Items.Add(reader["TenBenXe"].ToString());
                }

            }
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DangNhap test = new DangNhap();
            test.Show();
            this.Close();
        }

        private void btn_Xong_Click(object sender, EventArgs e)
        {
            ThanhCong notice = new ThanhCong("Bạn đã chỉnh vé thành công");
            
            if (notice.ShowDialog() == DialogResult.OK)
            {
                notice.Close();
                bunifuPages1.SetPage("Đặt vé");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
