using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstCourseWork
{
    public partial class StudentRegisterForm : Form
    {
        public StudentRegisterForm()
        {
            InitializeComponent();
            BindGrid();

            btnUpdate.Visible = false;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                StudentRegister studRegister = new StudentRegister();
                string first_name = txtFirstName.Text;
                string last_name = txtLastName.Text;
                studRegister.Name = first_name + " " + last_name;
               // studRegister.FirstName = first_name;
                //studRegister.LastName = last_name;
                string address = txtAddress.Text;
                studRegister.Address = address;
                string email = txtEmail.Text;
                studRegister.Email = email;
                string contact_no = txtContactNo.Text;
                studRegister.ContactNo = contact_no;
                DateTime dateOfBirth = dtDateOfBirth.Value;
                studRegister.DateOfBirth = dateOfBirth;
                string gender = cbGender.SelectedItem.ToString();
                studRegister.Gender = gender;
                string course_enroll = cbCourseEnroll.SelectedItem.ToString();
                studRegister.CourseEnroll = course_enroll;
                DateTime register_date = dtRegisterDate.Value;
                studRegister.RegisterDate = register_date;
                studRegister.Add(studRegister);
                BindGrid();
                Clear();
            }

        }
        private bool CheckValidation()
        {
            if (txtFirstName.Text == "")
            {
                MsgValidation(txtFirstName, "Please Enter student's First Name!!");
                return false;
            }
            if (txtLastName.Text == "")
            {
                MsgValidation(txtLastName, "Please Enter Student's Last Name!!");
                return false;
            }
            if (txtAddress.Text == "")
            {
                MsgValidation(txtAddress, "Please Enter Student's Address!!");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MsgValidation(txtEmail, "Please Enter Student's Email Address!!");
                return false;
            }
            if (txtContactNo.Text == "")
            {
                MsgValidation(txtContactNo, "Please Enter Student's Contact Number!!");
                return false;
            }
            if (DateTime.Today.AddYears(-16) < dtDateOfBirth.Value.Date)
            {
                MsgValidation(dtDateOfBirth, "Please Select Student's BirthDate!!");
                return false;
            }
            if (cbGender.Text == "")
            {
                MsgValidation(cbGender, "Please Select Student's Gender!!");
                return false;
            }
            if (cbCourseEnroll.Text == "")
            {
                MsgValidation(cbCourseEnroll, "Please Select Student's enrollment program!!");
                return false;
            }
            if (dtRegisterDate.Text == "")
            {
                MsgValidation(dtRegisterDate, "Please Select Student's registered date!!");
                return false;
            }
            return true;
        }
        private void MsgValidation(Control ctrl, string MsgValidation)
        {
            ctrl.BackColor = Color.Red;
            MessageBox.Show(MsgValidation, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ctrl.Focus();
        }
        private void Ctrl_Text(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }


        public void Clear()
        {
            txtStudentId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            dtDateOfBirth.Value = DateTime.Today;
            cbGender.SelectedItem = null;
            cbCourseEnroll.SelectedItem = null;
            dtRegisterDate.Value = DateTime.Today;

        }
        public void BindGrid()
        {
            StudentRegister studRegister = new StudentRegister();
            List<StudentRegister> studentLists = studRegister.List();
            DataTable dt = Utility.ConvertToDataTable(studentLists);
            dgStudentData.DataSource = dt;
            BindChart(studentLists);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentRegister studRegister = new StudentRegister();
            studRegister.StudentId = int.Parse(txtStudentId.Text);
            string first_name = txtFirstName.Text;
            string last_name = txtLastName.Text;
            studRegister.Name = first_name + " " + last_name;
            studRegister.Address = txtAddress.Text;
            studRegister.Email = txtEmail.Text;
            studRegister.ContactNo = txtContactNo.Text;
            studRegister.DateOfBirth = dtDateOfBirth.Value;            
            studRegister.Gender = cbGender.SelectedItem.ToString();
            studRegister.CourseEnroll = cbCourseEnroll.SelectedItem.ToString();
            studRegister.RegisterDate = dtRegisterDate.Value; 
            studRegister.Edit(studRegister);
            BindGrid();
            Clear();
            btnAdd.Visible = false;
            btnUpdate.Visible = true;


            /*   string first_name = txtFirstName.Text;
            string last_name = txtLastName.Text;
           studRegister.Name = first_name + " " + last_name;
          studRegister.FirstName = first_name;
          studRegister.LastName = last_name;
          string address = 
           // studRegister.Address = address;
            string email = txtEmail.Text;
            studRegister.Email = email;
            string contact_no = txtContactNo.Text;
            studRegister.ContactNo = contact_no;
            DateTime dateOfBirth = dtDateOfBirth.Value;
            studRegister.DateOfBirth = dateOfBirth;
            string gender = cbGender.SelectedItem.ToString();
            studRegister.Gender = gender;
            string course_enroll = cbCourseEnroll.SelectedItem.ToString();
            studRegister.CourseEnroll = course_enroll;
            DateTime register_date = dtRegisterDate.Value;
            studRegister.RegisterDate = register_date; */
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgStudentData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentRegister studRegister = new StudentRegister();
            if (e.ColumnIndex == 0)
            {
                //code that will take data from the row which we have clicked
                string val = dgStudentData[2, e.RowIndex].Value.ToString();
                int studId = 0;
                if (String.IsNullOrEmpty(val))
                {
                    MessageBox.Show("Please Enter Valid Data");
                }
                else
                {
                    studId = int.Parse(val);
                    StudentRegister obj = studRegister.List().Where(x => x.StudentId == studId).FirstOrDefault();
                    txtStudentId.Text = obj.StudentId.ToString();
                    txtFirstName.Text = obj.Name.Split(' ')[0];
                    txtLastName.Text = obj.Name.Split(' ')[1];
                    txtAddress.Text = obj.Address;
                    txtEmail.Text = obj.Email;
                    txtContactNo.Text = obj.ContactNo;
                    dtDateOfBirth.Value = obj.DateOfBirth;
                    cbGender.SelectedItem = obj.Gender;
                    cbCourseEnroll.SelectedItem = obj.CourseEnroll;
                    dtRegisterDate.Value = obj.RegisterDate;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
            else if (e.ColumnIndex == 1)
            {
                string word = "Do you want to Delete the Record?";
                string title = "Are you sure that you want to Delete the Record?";
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult outcome = MessageBox.Show(word, title, btn);
                if (outcome == DialogResult.OK)
                {
                    string val = dgStudentData[2, e.RowIndex].Value.ToString();
                    studRegister.Delete(int.Parse(val));
                    BindGrid();
                    MessageBox.Show("Record Successfully Deleted");
                }
            }
        }
        private void BindChart(List<StudentRegister> lst)
        {
            if (lst != null)
            {
                var result = lst
                    .GroupBy(l => l.CourseEnroll)
                    .Select(cl => new
                    {
                        CourseEnroll = cl.First().CourseEnroll,
                        Count = cl.Count().ToString()
                    }).ToList();
                DataTable dt = Utility.ConvertToDataTable(result);
                chart1.DataSource = dt;
                chart1.Name = "CourseEnroll";
                chart1.Series["Series1"].XValueMember = "CourseEnroll";
                chart1.Series["Series1"].YValueMembers = "Count";
                this.chart1.Titles.Remove(this.chart1.Titles.FirstOrDefault());
                this.chart1.Titles.Add("Weekly Enrollment Chart");
                chart1.Series["Series1"].IsValueShownAsLabel = true;
            }
        }
        private void btnFirstNameSort_Click(object sender, EventArgs e)
        {
            dgStudentData.Sort(dgStudentData.Columns[4], ListSortDirection.Descending);
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentRegister studRegister = new StudentRegister();
            List<StudentRegister> studentsList = studRegister.List();
            if (cbSort.SelectedItem.ToString() == "Name")
            {
                List<StudentRegister> list = studRegister.SortingByName(studentsList);
                DataTable dt = Utility.ConvertToDataTable(list);
                dgStudentData.DataSource = dt;
            }
            if (cbSort.SelectedItem.ToString() == "Registration Date")
            {
                List<StudentRegister> list = studRegister.SortingByRegisterDate(studentsList);
                DataTable dt = Utility.ConvertToDataTable(list);
                dgStudentData.DataSource = dt;
            }


            /* if(cbSort.SelectedItem.ToString() == "Name")
             {
                 dgStudentData.Sort(dgStudentData.Columns[3], ListSortDirection.Ascending);
             }
             if (cbSort.SelectedItem.ToString() == "Registration Date")
             {
                 dgStudentData.Sort(dgStudentData.Columns[10], ListSortDirection.Ascending);
             }*/

        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation for first name
            if((!Char.IsControl(e.KeyChar)) && (!Char.IsLetter(e.KeyChar)) && (!Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
