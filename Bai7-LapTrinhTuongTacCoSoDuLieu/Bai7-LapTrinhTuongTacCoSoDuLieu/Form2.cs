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

namespace Bai7_LapTrinhTuongTacCoSoDuLieu
{
    public class KetNoi2
    {
        public SqlConnection connect;
        public KetNoi2()
        {
            connect = new SqlConnection("Data source = MSI\\SQLEXPRESS; Initial Catalog = QLSinhVien; Integrated Security = true");
        }
        public KetNoi2(string strcn)
        {
            connect = new SqlConnection(strcn);
        }
    }
    public partial class Form2 : Form
    {
        KetNoi kn = new KetNoi();
        SqlConnection connsql;
        public Form2()
        {
            InitializeComponent();
            connsql = kn.connect;
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //kiem tra ket noi truoc khi mo
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                //xac dinh chuoi truy van
                string insertString;
                insertString = "insert into SINHVIEN values('" + txbMaSV.Text + "',N'" + txbHoTen.Text + "'," + TxbNgSinh.Text + ",'" + txbMaLop.Text + "')";
                //khai bao commamnd moi
                SqlCommand cmd = new SqlCommand(insertString, connsql);
                //goi ExecuteNonQuery de gui commamnd 
                cmd.ExecuteNonQuery();
                //Kiem tra ket noi truoc khi dong
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                //Hien thi thong bao
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string deleteString;
                deleteString = "delete SINHVIEN where MaSV = '" + txbMaSV.Text + "' ";
                SqlCommand cmd = new SqlCommand(deleteString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string updateString;
                updateString = "update SINHVIEN set HoTen = N'" + txbHoTen.Text + "', NgSinh = "+ TxbNgSinh.Text +", MaLop = '"+ txbMaLop +"' where MaSV = '" + txbMaSV.Text + "' ";
                SqlCommand cmd = new SqlCommand(updateString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }
    }
}
