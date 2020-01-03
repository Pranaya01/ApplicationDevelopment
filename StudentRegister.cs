using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCourseWork
{
    class StudentRegister
    {
    private string path = "studenregister.json";
    //making Getter and Setter Properties in order to carries data into our application
    public int StudentId { get; set; }
    public string Name { get; set; }
    //public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string ContactNo { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string CourseEnroll { get; set; }
    public DateTime RegisterDate { get; set; }
    
    public void Add(StudentRegister info)
        {
            Random randomID = new Random();
            info.StudentId = randomID.Next(1000, 9999);
            string input = JsonConvert.SerializeObject(info, Formatting.None);
            Utility.WriteToTextFile(path, input);
        }
    public StudentRegister Edit(int StudId)
        {
            
            StudentRegister studRegister = new StudentRegister();
            return studRegister;
        }
     public void Edit(StudentRegister info)
    {
            //calling the list method of Student Register Class in order to get the student register data
            List<StudentRegister> list = List();
            //selecting the student with specified id using List
            StudentRegister studReg = list.Where(x => x.StudentId == info.StudentId).FirstOrDefault();
            //code that will remove the student object which is updated via list
            list.Remove(studReg);
            //code will add the student object to the list
            list.Add(studReg);
            //below code will convert the list of student to string
            string input = JsonConvert.SerializeObject(list, Formatting.None);
            Utility.WriteToTextFile(path, input, false);

     }
     public void Delete(int studId)
        {
            //calling the list method of Student Register Class in order to get the student register data
            List<StudentRegister> list = List();
            //selecting the student with specified id using List
            StudentRegister studReg = list.Where(x => x.StudentId == studId).FirstOrDefault();
            //code that will remove the student object which is updated via list
            list.Remove(studReg);
            //code will add the student object to the list
            //list.Add(studReg);
            //below code will convert the list of student to string
            string input = JsonConvert.SerializeObject(list, Formatting.None);
            Utility.WriteToTextFile(path, input, false);

        }
        public StudentRegister Detail(int studId)
        {
            StudentRegister studRegister = new StudentRegister();
            return studRegister;
     }

        public List<StudentRegister> List()
        {
            string data = Utility.ReadFromTextFile(path);
            if(data != null)
            {
                List<StudentRegister> lst = JsonConvert.DeserializeObject<List<StudentRegister>>(data);
                return lst;

            }
            return null;

        }
        public List<StudentRegister> SortingByName(List<StudentRegister> list)
        {
            int student_id;
            string name;
            string address;
            string email;
            string contact_no;
            DateTime dateofbirth;
            string gender;
            string course_enroll;
            DateTime registerDate;

            if (list != null)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i].Name.CompareTo(list[j].Name) > 0)
                        {
                            student_id = list[i].StudentId;
                            list[i].StudentId = list[j].StudentId;
                            list[j].StudentId = student_id;

                            name = list[i].Name;
                            list[i].Name = list[j].Name;
                            list[j].Name = name;

                            gender = list[i].Gender;
                            list[i].Gender = list[j].Gender;
                            list[j].Gender = gender;

                            email = list[i].Email;
                            list[i].Email = list[j].Email;
                            list[j].Email = email;

                            registerDate = list[i].RegisterDate;
                            list[i].RegisterDate = list[j].RegisterDate;
                            list[j].RegisterDate = registerDate;

                            contact_no = list[i].ContactNo;
                            list[i].ContactNo = list[j].ContactNo;
                            list[j].ContactNo = contact_no;


                        }

                    }
                }
                return list;
            }   
            return null;
        }
        public List<StudentRegister> SortingByRegisterDate(List<StudentRegister> list)
        {
            int student_id;
            string name;
            string address;
            string email;
            string contact_no;
            DateTime dateofbirth;
            string gender;
            string course_enroll;
            DateTime registerDate;

            if (list != null)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i].RegisterDate.CompareTo(list[j].RegisterDate) > 0)
                        {
                            student_id = list[i].StudentId;
                            list[i].StudentId = list[j].StudentId;
                            list[j].StudentId = student_id;

                            name = list[i].Name;
                            list[i].Name = list[j].Name;
                            list[j].Name = name;

                            address = list[i].Address;
                            list[i].Address = list[j].Address;
                            list[j].Address = Address;

                            gender = list[i].Gender;
                            list[i].Gender = list[j].Gender;
                            list[j].Gender = gender;

                            email = list[i].Email;
                            list[i].Email = list[j].Email;
                            list[j].Email = email;

                            contact_no = list[i].ContactNo;
                            list[i].ContactNo = list[j].ContactNo;
                            list[j].ContactNo = name;

                            registerDate = list[i].RegisterDate;
                            list[i].RegisterDate = list[j].RegisterDate;
                            list[j].RegisterDate = registerDate;

                            course_enroll = list[i].CourseEnroll;
                            list[i].CourseEnroll = list[j].CourseEnroll;
                            list[j].CourseEnroll = name;


                            contact_no = list[i].ContactNo;
                            list[i].ContactNo = list[j].ContactNo;
                            list[j].ContactNo = contact_no;


                        }

                    }
                }
                return list;
            }
            return null;
        }



    }


}
