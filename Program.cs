using System;
using System.Collections.Generic;

namespace GroupStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            List < Group > GroupContext= new List<Group>();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Menu: 1- Add Group| 2- Add Student| 3- Add Student Mark| 4- View Student List| 5- Find Student| 6- Delete Group| exit");
                Console.ResetColor();

                string UserResponse = Console.ReadLine();

                if (UserResponse.ToLower() == "exit")
                {
                    break;
                }

                int selection;
                bool selectionIsValid = int.TryParse(UserResponse, out selection);
                if (selectionIsValid && selection >= 1 && selection <= 6)
                {
                    switch (selection)
                    {
                        #region AddGroup
                        case (int)Menu.AddGroup:
                            Console.Write("Enter Group: ");
                            string GroupNumber = Console.ReadLine();
                            if (!string.IsNullOrEmpty(GroupNumber))
                            {
                                
                                    Group Group = new Group(GroupNumber);
                                    if (!GroupContext.Contains(Group))
                                    {
                                        GroupContext.Add(Group);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Group added successfully");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Group already exists");
                                        Console.ResetColor();
                                    }
                                
                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Group Number");
                                Console.ResetColor();
                            }
                                break;
                        #endregion
                        #region AddStudent

                        case (int)Menu.AddStudent:
                            if (GroupContext.Count == 0)
                            {
                                Console.WriteLine("Add group first");
                                break;
                            }
                            Console.Write("Add Student Name: ");
                            string studentName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(studentName))
                            {
                                Console.Write("Add Student Surname: ");
                                string studentSurname = Console.ReadLine();
                                if (!string.IsNullOrEmpty(studentSurname))
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    foreach (Group item in GroupContext)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ResetColor();
                                    Console.Write("Choose the group ID you want to add Student to: ");

                                    int groupToAddStudentTo;
                                    bool groupToAddStudentToIsValid = int.TryParse(Console.ReadLine(), out groupToAddStudentTo);
                                    if (groupToAddStudentToIsValid)
                                    {
                                        Group GroupToAddStudent = null;

                                        foreach(Group item in GroupContext)
                                        {
                                            if(item.id == groupToAddStudentTo)
                                            {
                                                GroupToAddStudent = item;
                                            }
                                            
                                        }
                                        
                                        if (!(GroupToAddStudent == null))
                                        {
                                            Student student1 = new Student(studentName, studentSurname);
                                            if (GroupToAddStudent.AddStudents(student1))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Student Added Successfully");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Student limit is exceeded. Are you sure you want to add a student?");
                                                Console.ResetColor();
                                                string answer = Console.ReadLine();

                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid Group ID");
                                            Console.ResetColor();
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("ID is not valid");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Student surname cannot be empty");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Student name cannot be empty");
                                Console.ResetColor();
                            }

                            break;
                        #endregion
                        #region AddMark


                        case (int)Menu.AddStudentMark:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            foreach (Group item in GroupContext)
                            {
                                Console.WriteLine(item);
                            }
                            Console.ResetColor();
                            Console.Write("Choose the group: ");
                            int GroupId;
                            bool GroupIdIsValid = int.TryParse(Console.ReadLine(), out GroupId);
                            if (GroupIdIsValid)
                            {
                                Group GroupToSearch2 = null;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                foreach (Group item in GroupContext)
                                {
                                    if (item.id == GroupId)
                                    {
                                        GroupToSearch2 = item;
                                        GroupToSearch2.PrintStudents();
                                    }
                                    
                                }
                                Console.ResetColor();
                                Console.Write("Choose Student: ");
                                int StudentId;
                                bool StudentIdIsValid = int.TryParse(Console.ReadLine(), out StudentId);
                                if (StudentIdIsValid)
                                {
                                    Student StudentToMark = null;
                                    foreach(Group item in GroupContext)
                                    {
                                        List<Student> one = item._students;
                                        foreach(Student item1 in one)
                                        {
                                            if (StudentId == item1.id)
                                            {
                                                StudentToMark = item1;
                                            }
                                        }
                                        if (!(StudentToMark == null))
                                        {
                                            Console.Write("Add mark: ");
                                            string add = Console.ReadLine();
                                            int Mark = int.Parse(add);
                                            if (StudentToMark.AddMark(Mark))
                                            {
                                                Console.WriteLine("Mark added successfully");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid mark");
                                            }
                                            
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Mark cannot be empty");
                                            Console.ResetColor();
                                        }
                                    }

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Student ID is Invalid");
                                    Console.ResetColor();
                                }

                                
                                



                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Group ID");
                                Console.ResetColor();
                            }



                            break;

                        #endregion

                        #region ViewStudentList

                        case (int)Menu.ViewStudentList:
                            foreach(Group item in GroupContext)
                            {
                                item.PrintStudentInfo();
                            }

                            break;

                            #endregion
                            
                        #region FindStudent

                        case (int)Menu.FindStudent:
                            Console.Write("Enter query: ");
                            string usersQuery = Console.ReadLine();
                            if (!string.IsNullOrEmpty(usersQuery))
                            {
                                foreach(Group item in GroupContext)
                                {
                                    item.SearchAndPrintStudent(usersQuery);
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Query cannot be empty");
                                Console.ResetColor();
                            }



                                break;

                        #endregion

                        #region DeleteGroup

                        case (int)Menu.DeleteGroup:
                            foreach(Group item in GroupContext)
                            {
                                Console.WriteLine(item);
                            }
                            Console.Write("Choose the ID of group you want to delete: ");
                            int GroupIdToDelete;
                            bool GroupToDeleteIsValid = int.TryParse(Console.ReadLine(), out GroupIdToDelete);
                            if (GroupToDeleteIsValid)
                            {
                                Group GroupToDelete = null;
                                foreach(Group item in GroupContext)
                                {
                                    if(GroupIdToDelete == item.id)
                                    {
                                        GroupToDelete = item;
                                    }
                                }
                                if (!(GroupToDelete == null))
                                {
                                    GroupContext.Remove(GroupToDelete);
                                    Console.WriteLine("Group deleted successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID");
                                }
                            }




                        break;

                            #endregion

                        
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Menu Selection");
                    Console.ResetColor();
                }
            }
        }
    }
}
