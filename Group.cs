using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GroupStudent
{
    class Group: Stack
    {
        public string GroupNumber { get; set; }

        private static int _count;
        public readonly int id;
        
        public Group()
        {
            _count++;
            id = _count;
            _students = new List<Student>();
        }

        public Group(string GroupNumber):this()
        {
            this.GroupNumber = GroupNumber;
            
        }

        public override string ToString()
        {
            return $"{id}  Group Number: {GroupNumber}";
        }

        public override bool Equals(object obj)
        {
            return GroupNumber==((Group)obj).GroupNumber;
        }

        public List<Student> _students;

        

        public bool AddStudents(Student student)
        {
            if (!_students.Contains(student))
            {
                 _students.Add(student);
                    return true; 
            }
            Console.WriteLine("Student already exists");
            return false;
        }

        public void PrintStudents()
        {
            foreach(Student item in _students)
            {
                Console.WriteLine(item);
                
            }
        }

        public bool SearchAndPrintStudent(string query)
        {
            
            foreach (Student item in _students)
            {
                if (item.Name.Contains(query) || item.Surname.Contains(query))
                {
                    Console.WriteLine($"{item} is found");
                    return true;
                }
            }
            Console.WriteLine("Nothing is found");
            return false;
            
        }

        public void PrintStudentInfo()
        {
            foreach(Student item in _students)
            {
                Console.Write(item);
                item.PrintMark();
            }
        }




    }
}
