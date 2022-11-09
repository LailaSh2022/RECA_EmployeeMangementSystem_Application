using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LeaveMangementForm
{
    public partial class Leave_Grievances : Form
    {
        public Leave_Grievances()
        {
            InitializeComponent();
        }
        public string Emp_ID;
        public string ConnectionString = "server=localhost;user id=root;password=Dbms@2022;persistsecurityinfo=True;database=human_resources";
        private void Leave_Grievances_Load(object sender, EventArgs e)
        {
            FillLeaveDataGrid();
            FillGrievancesDataGrid();
        }
        public void FillLeaveDataGrid()
        {
            string sqlCommand = "SELECT LE_ID as No, concat(human_resources.employee.Emp_FName,' ',human_resources.employee.Emp_LName) as Employee," +
                "human_resources.leave.LE_Type as Type,human_resources.leave.LE_Reason as Reason" +
                " FROM human_resources.employee,human_resources.leave" +
                " Where (employee.Emp_ID = human_resources.leave.Emp_ID)";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();
                      
            LeaveRequest_dgv.DataSource = dt;
            LeaveRequest_dgv.Columns[0].Width = 50;// The id column 
            LeaveRequest_dgv.Columns[1].Width = 100;// The employee name columln
            LeaveRequest_dgv.Columns[2].Width = 100;// The leave type columln
            LeaveRequest_dgv.Columns[3].Width = 300;// The reason columln
        }

        public void FillGrievancesDataGrid()
        {
            string sqlCommand = "SELECT distinct human_resources.grievances_resigning.GR_ID, " +
                "concat(human_resources.employee.Emp_FName,' ',human_resources.employee.Emp_LName) as EmployeeName," +
                "human_resources.grievances_resigning.Reason" +
                " FROM human_resources.grievances_resigning, human_resources.employee " +
                "where human_resources.employee.Emp_ID = human_resources.grievances_resigning.Emp_ID group by GR_ID";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();
            
            Grievances_dgv.DataSource = dt;
            Grievances_dgv.Columns[0].Width = 50;// The id column 
            Grievances_dgv.Columns[1].Width = 100;// The employee name columln
            Grievances_dgv.Columns[2].Width = 500;// The reason columln
            
        }

        private void ViewLeaveDetails_btn_Click(object sender, EventArgs e)
        {
            int rowindex = LeaveRequest_dgv.CurrentCell.RowIndex;
            //int columnindex = LeaveRequest_dgv.CurrentCell.ColumnIndex;

            label3.Text =  LeaveRequest_dgv.Rows[rowindex].Cells[0].Value.ToString();

            
        }

        private void ViewGrievances_btn_Click(object sender, EventArgs e)
        {
            int rowindex = Grievances_dgv.CurrentCell.RowIndex;
            //int columnindex = Grievances_dgv.CurrentCell.ColumnIndex;

            label3.Text = Grievances_dgv.Rows[rowindex].Cells[0].Value.ToString();
        }
    }
}
