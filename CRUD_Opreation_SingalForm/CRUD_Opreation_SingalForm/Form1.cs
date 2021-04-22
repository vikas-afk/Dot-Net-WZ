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
namespace CRUD_Opreation_SingalForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H9G4NTK\DOTNET;Initial Catalog=Practice1;Integrated Security=True");
        public int StudentId;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudent();
        }


        private void GetStudent()
        {
            SqlCommand cmd = new SqlCommand("select * from Students",con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            StudentDtataTable.DataSource = dt;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(isValid())
            {
                SqlCommand cmd = new SqlCommand("insert into Students values (@Name,@FatherName,@RollNo,@MobileNo )", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name",txtName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@RollNo", txtRollNo.Text);
                cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("STUDENT DATA IS INSERTED ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudent();
                DataClear();
            }
        }

        private bool isValid()
        {
            
            if(txtName.Text==string.Empty)
            {
                MessageBox.Show("STUDENT NAME IS REQUIRED ","FAILED",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;

            }
            return true;
        }


        private void DataClear()
        {
            txtFatherName.Clear();
            txtName.Clear();
            txtMobileNo.Clear();
            txtRollNo.Clear();
            StudentId = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DataClear();
        }

        private void StudentDtataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentId = Convert.ToInt32(StudentDtataTable.SelectedRows[0].Cells[0].Value);
            txtName.Text = StudentDtataTable.SelectedRows[0].Cells[1].Value.ToString();
            txtFatherName.Text = StudentDtataTable.SelectedRows[0].Cells[2].Value.ToString();
            txtRollNo.Text = StudentDtataTable.SelectedRows[0].Cells[3].Value.ToString();
            txtMobileNo.Text = StudentDtataTable.SelectedRows[0].Cells[4].Value.ToString(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(StudentId>0)
            {
                SqlCommand cmd = new SqlCommand("update Students set    Name=@Name,FatherName=@FatherName,RollNo=@RollNo,MobileNo=@MobileNo where Id=@StudentId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@RollNo", txtRollNo.Text);
                cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text);
                cmd.Parameters.AddWithValue("@StudentId", this.StudentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("STUDENT DATA IS UPDATED ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudent();
                DataClear();
            }
            else
            {
                MessageBox.Show("PLEASE SELECT STUDENT DATA TO UPDATED ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (StudentId > 0)
            {
                SqlCommand cmd = new SqlCommand("delete from Students   where Id=@StudentId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentId", this.StudentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("STUDENT DATA IS DELETED SUCCESSFULLY ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudent();
                DataClear();
            }
            else
            {
                MessageBox.Show("PLEASE SELECT STUDENT DATA TO DELETE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
