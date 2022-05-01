using System;
using System.Collections.Generic;
using System.Text;

namespace IAccountTask.Models
{
    class Group
    {
        private Student[] _students = new Student[0];
        public string GroupNo { get; set; }
        public int StudentLimit { get; set; }


        public Group(string groupNo,int studentLimit)
        {
            GroupNo = groupNo;
            StudentLimit = studentLimit;
        }

        public void AddStudent(Student student)
        {
            Array.Resize(ref _students, _students.Length + 1);
            _students[_students.Length - 1] = student;
        }

        public Student GetStudent(int id)
        {
            if(Array.Exists(_students, student=>student.Id == id))
            {
                Student wantedStudent = Array.Find(_students, student => student.Id == id);
                return wantedStudent;
            }
            return null;
        }

        public Student[] GetAllStudents()
        {
            return _students;
        }
    }
}
