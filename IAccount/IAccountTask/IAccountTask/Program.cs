using IAccountTask.Models;
using System;

namespace IAccountTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = null;

            Console.WriteLine("Enter the fullname:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter the Email");
            string email = Console.ReadLine();

            string password;

            do
            {
                Console.WriteLine("Enter Password");
                password = Console.ReadLine();


            } while (!PasswordChecker(password));

            User user = new User(email, password, fullName);

            bool choice = true;

            do
            {
                Console.WriteLine("1 - User Info\n" +
                    "2 - Create Group \n" +
                    "3 - Next page\n" +
                    "0 - Quit");
                
                int command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        user.ShowInfo();
                        break;
                    case 2:
                        Console.WriteLine("Enter the group no");
                        string no = Console.ReadLine();
                        Console.WriteLine("Enter the group student limit");
                        int limit = Convert.ToInt32(Console.ReadLine());
                        group = new Group(no, limit);
                        Console.WriteLine("no: " + group.GroupNo + " " + "student limit:" + group.StudentLimit);
                        break;
                    case 3:
                        bool quit = true;
                        do
                        {
                            Console.WriteLine("1 - AllStudentInfo\n" +
                                              "2 - Get Student by id \n" +
                                              "3 - Add Student \n" +
                                              "0 - Go to back");
                            int innerCommand = Convert.ToInt32(Console.ReadLine());
                            switch (innerCommand)
                            {
                                case 1:
                                    foreach (Student student in group.GetAllStudents())
                                    {
                                        student.StudentInfo();
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the student id");
                                    group.GetStudent(Convert.ToInt32(Console.ReadLine())).StudentInfo(); 
                                    break;
                                case 3:
                                    group.AddStudent(CreateStudent());
                                    break;
                                case 0:
                                    quit = false;
                                    break;
                                default:
                                    Console.WriteLine("Choose correct choice");
                                    break;
                            }


                        } while (quit);
                        break;
                    case 0:
                        choice = false;
                        break;
                    default:
                        Console.WriteLine("Choose correct choice");
                        break;
                }


            } while (choice);

        }


        //Password Checker Method
        public static bool PasswordChecker(string password)
        {
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            if (!String.IsNullOrWhiteSpace(password) && password.Length >= 8)
            {
                foreach (char cr in password)
                {
                    if (char.IsUpper(cr)) hasUpper = true;
                    else if (char.IsLower(cr)) hasLower = true;
                    else if (char.IsDigit(cr)) hasDigit = true;

                    if (hasUpper && hasDigit && hasLower) return true;
                }
            }
            return false;
        }

        // Create Student Method
        public static Student CreateStudent()
        {
            Console.WriteLine("Enter the student fullname:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter the student point:");
            double point = Convert.ToDouble(Console.ReadLine());

            Student student = new Student(fullName, point);

            return student;
        }
    }
}
