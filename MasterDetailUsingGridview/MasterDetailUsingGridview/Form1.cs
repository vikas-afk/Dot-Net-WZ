using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MasterDetailUsingGridview
{
    public partial class Form1 : Form
    {

        SqlDataAdapter dad1, dad2;
        DataSet ds;
        DataRelation drel;
        //DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0B0HU93C\MSSQLSERVER2019;Initial Catalog=Practice;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
      
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

           /* DataTable dt_Employee = new DataTable();

            // add column to datatable 

            dt_Employee.Columns.Add("Emp_ID", typeof(int));

            dt_Employee.Columns.Add("Emp_Name", typeof(string));
            dt_Employee.Columns.Add("Emp_Salary", typeof(string));


            //Child table

            DataTable dt_Department = new DataTable();

            dt_Department.Columns.Add("Emp_ID", typeof(int));
            dt_Department.Columns.Add("Dept_ID", typeof(int));

            dt_Department.Columns.Add("Dept_Name", typeof(string));


            //Adding Rows

            dt_Employee.Rows.Add(1, "kirit", "25000");

            dt_Employee.Rows.Add(2, "pintu", "80000");

            dt_Employee.Rows.Add(3, "Rahul", "54222");



            // Department for kirit ID=1

            dt_Department.Rows.Add(1, "01", "IT");



            //Department for pintu ID=2

            dt_Department.Rows.Add(2, "02", "Account");
            //Department for Rahul ID=3

            dt_Department.Rows.Add(3, "03", "Finance");


            DataSet dsDataset = new DataSet();

            //Add two DataTables  in Dataset


            dsDataset.Tables.Add(dt_Employee);

            dsDataset.Tables.Add(dt_Department);

            DataRelation Datatablerelation = new DataRelation("Employee_Department", dsDataset.Tables[0].Columns[0], dsDataset.Tables[1].Columns[0], true);

            dsDataset.Relations.Add(Datatablerelation);

            dataGridView1.DataSource = dsDataset.Tables[0];
*/
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
           // CreateNewRow();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dad2 = new SqlDataAdapter("select * from StudentRecords", con);
            ds = new DataSet();
            dad2.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dad1 = new SqlDataAdapter("select * from AllStudent", con);
            ds = new DataSet();
            dad1.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dad1 = new SqlDataAdapter("select * from AllStudent", con);
            ds = new DataSet();
            dad1.Fill(ds, "AllStudent");
            dad1.SelectCommand.CommandText = "select * from StudentRecords";
            dad1.Fill(ds, "StudentRecords");
            drel = new DataRelation("All", ds.Tables[0].Columns[0], ds.Tables[1].Columns[0]);
            ds.Relations.Add(drel);
            //dataGridView3.DataSource = ds;
        }

        /*  public void CreateNewRow()
          {
              if (dt.Rows.Count <= 0)
              {
                  DataColumn dc1 = new DataColumn("Name", typeof(string));
                  DataColumn dc2 = new DataColumn("Age", typeof(string));
                  DataColumn dc3 = new DataColumn("Address", typeof(string));
                  dt.Columns.Add(dc1);
                  dt.Columns.Add(dc2);
                  dt.Columns.Add(dc3);


                  dt.Rows.Add(txt_name.Text, txt_age.Text, txt_address.Text);
                  dataGridView1.DataSource = dt;
              }

              else
              {
                  dt.Rows.Add(txt_name.Text, txt_age.Text, txt_address.Text);
                  dataGridView1.DataSource = dt;
              }
          }
  */

    }
}
