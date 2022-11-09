// Created by Laila Shihada 764700695                   4th November 2022
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace LeaveMangementForm
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }
        public string PassEmp_ID, EMP_Type;
        private Form currentChildForm;
        private object iconCurrentChildForm;
        private void MainFrame_Load(object sender, EventArgs e)     // Load the form.
        {
            CurrentTime_tmr.Start();                // Start the timer
            displayButton();                // Switch between Admin and Employee buttons


        }

        private void CurrentTime_tmr_Tick(object sender, EventArgs e)       // Set the current day and time.
        {
            CurrentTime_lbl.Text = DateTime.Now.ToShortTimeString();
            CurrentDate_lbl.Text = DateTime.Now.ToLongDateString();
        }

        private void LeaveMg_Menu_btn_Click(object sender, EventArgs e)     // Click the Leave management Button
        {
            setButton();
            Bitmap B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\LeaveManagement_Click.png");  // Change the button image when click
            LeaveMg_Menu_btn.BackgroundImage = B;
            LeaveManagement LMF = new LeaveManagement() { TopLevel = false, TopMost = true };           // Load the leave management subform into the main frame.
            SubForm_pnl.Controls.Add(LMF);
            SubFormTitle_lbl.Text = "Leave Management";
            LMF.Emp_ID = PassEmp_ID;
            OpenChildForm(LMF);     // Dispaly the form on panel and hide the exist one.
                                    

        }

        private void Leave_Grievances_btn_Click(object sender, EventArgs e)
        {
            setButton();
            LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\Leave_Grievances_Button_Click.png");  // Change the button image when click
            Leave_Grievances_btn.BackgroundImage = B;
            Leave_Grievances LGF = new Leave_Grievances() { TopLevel = false, TopMost = true };           // Load the leave Grievances subform into the main frame.
            SubForm_pnl.Controls.Add(LGF);
            SubFormTitle_lbl.Text = "Leave and Grievances";
            LGF.Emp_ID = PassEmp_ID;
            OpenChildForm(LGF);     // Dispaly the form on panel and hide the exist one.

            
            


        }
        private void OpenChildForm(Form childform)          // I took this part from Tati's Code in Admin Forms.
        {
            if (iconCurrentChildForm != null)
            {
                //open a specific fomr
                currentChildForm.Close();
            }
            currentChildForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            childform.BringToFront();
            childform.Show();
            
        }
               
        public void setButton()
        {
            Bitmap B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\LeaveManagement.png");  // Change the button image when click
            LeaveMg_Menu_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\Leave_Grievances_Button.png");  // Change the button image when click
            Leave_Grievances_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\Registration_btn.png");  // Change the button image when click
            Registration_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\AttendanceManagement_btn.png");  // Change the button image when click
            AttendanceManagement_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\PayrollPage_btn.png");  // Change the button image when click
            PayrollPage_btn.BackgroundImage = B;
        }
        public void displayButton()
        {
            if (EMP_Type == "ADM")
            {
                DisplayAdmin_btn();
            }
            else
            {
                DisplayEmployee_btn();
            }
        }
        public void DisplayAdmin_btn()
        {
            LeaveMg_Menu_btn.Visible = false;
            Leave_Grievances_btn.Visible = true;
            Registration_btn.Visible = true;
            AttendanceManagement_btn.Visible = true;
            PayrollPage_btn.Visible = true;
        }
        public void DisplayEmployee_btn()
        {
            LeaveMg_Menu_btn.Visible = true;
            Leave_Grievances_btn.Visible = false;
            Registration_btn.Visible = false;
            AttendanceManagement_btn.Visible = false;
            PayrollPage_btn.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)          // LogOut Button
        {
            setButton();
            LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\LogOut_btn_Click.png");  // Change the button image when click
            Leave_Grievances_btn.BackgroundImage = B;
            LogIn_Form LGN = new LogIn_Form();
            LGN.Show();
            this.Hide();
        }

        private void AttendanceManagement_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\AttendanceManagement_Click_btn.png");  // Change the button image when click
            AttendanceManagement_btn.BackgroundImage = B;
            //Leave_Grievances LGF = new Leave_Grievances() { TopLevel = false, TopMost = true };           // Load the leave Grievances subform into the main frame.
            //SubForm_pnl.Controls.Add(LGF);
            //SubFormTitle_lbl.Text = "Leave and Grievances";
            //LGF.Emp_ID = PassEmp_ID;
            //OpenChildForm(LGF);     // Dispaly the form on panel and hide the exist one.
        }

        private void PayrollPage_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\PayrollPage_Click_btn.png");  // Change the button image when click
            PayrollPage_btn.BackgroundImage = B;
            //Leave_Grievances LGF = new Leave_Grievances() { TopLevel = false, TopMost = true };           // Load the leave Grievances subform into the main frame.
            //SubForm_pnl.Controls.Add(LGF);
            //SubFormTitle_lbl.Text = "Leave and Grievances";
            //LGF.Emp_ID = PassEmp_ID;
            //OpenChildForm(LGF);     // Dispaly the form on panel and hide the exist one.
        }

        private void Registration_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\LeaveMangementForm\Images\Registration_Click_btn.png");  // Change the button image when click
            Registration_btn.BackgroundImage = B;
            //Leave_Grievances LGF = new Leave_Grievances() { TopLevel = false, TopMost = true };           // Load the leave Grievances subform into the main frame.
            //SubForm_pnl.Controls.Add(LGF);
            //SubFormTitle_lbl.Text = "Leave and Grievances";
            //LGF.Emp_ID = PassEmp_ID;
            //OpenChildForm(LGF);     // Dispaly the form on panel and hide the exist one.
        }


    }
}
