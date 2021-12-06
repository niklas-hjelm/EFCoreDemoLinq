using System;
using System.Linq;
using EFCoreDemoLinq.Contexts;
using EFCoreDemoLinq.Models;

namespace EFCoreDemoLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            var run = true;
            while (run)
            {
                Console.WriteLine("What do you want to do? \n" +
                                  "1. List all students \n" +
                                  "2. Change name of student \n" +
                                  "3. Remove student \n" +
                                  "4. Add new student");

                var input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        ListAllStudents();
                        break;
                    case 2:
                        Console.WriteLine("Please input id of student to update:");
                        var idU = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please input new name of student to update:");
                        var newName = Console.ReadLine();
                        UpdateStudent(idU, newName);
                        break;
                    case 3:
                        Console.WriteLine("Please input id of student to remove:");
                        var idR = int.Parse(Console.ReadLine());
                        RemoveStudent(idR);
                        break;
                    case 4:
                        Console.WriteLine("Please input name of student to add:");
                        var name = Console.ReadLine();
                        AddStudent(name);
                        break;
                    default:
                        run = false;
                        break;
                }
            }

        }

        private static void RemoveStudent(int id)
        {
            using var context = new SchoolContext();
            
            if (context.Students.Any(s => s.StudentId == id))
            {
                context.Students.RemoveRange(context.Students.Where(s => s.StudentId == id));
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student does not exist.");
            }
        }

        private static void ListAllStudents()
        {
            using var context = new SchoolContext();
            foreach (var student in context.Students)
            {
                Console.WriteLine($"Id: {student.StudentId} Name: {student.StudentName}");
            }
        }

        private static void AddStudent(string name)
        {
            using var context = new SchoolContext();
            var student = new Student()
            {
                StudentName = name
            };

            context.Add(student);
            context.SaveChanges();
        }

        private static void UpdateStudent(int id, string newName)
        {
            using var context = new SchoolContext();

            if (context.Students.Any(s => s.StudentId == id))
            {
                var student = context.Students.First(s => s.StudentId == id);
                student.StudentName = newName;
                context.Update(student);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student does not exist.");
            }
        }
    }
}
