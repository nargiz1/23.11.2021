using System;
using System.Collections.Generic;
using System.Text;

namespace GroupStudent
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private static int count;
        public readonly int id;

        public Student()
        {
            count++;
            id = count;
            _marks = new List<int>();
        }

        public Student(string Name, string Surname):this()
        {
            this.Name = Name;
            this.Surname = Surname;
        }

        public override string ToString()
        {
            return $"{id}  Name: {Name}  Surname: {Surname} ";
        }

        public override bool Equals(object obj)
        {
            return ((Name ==((Student)obj).Name) && (Surname== ((Student)obj).Surname));
        }

        private List<int> _marks;

        public bool AddMark(int Mark)
        {
            if(Mark>=0 && Mark <= 100)
            {
                _marks.Add(Mark);
                return true;
            }
            return false;
        }

        public void PrintMark()
        {
            int sum = 0;
            int markCount = 0;
            foreach(int item in _marks)
            {
                markCount++;
                sum += item;
            }
            Console.WriteLine(sum/markCount);
        }
    }
}
