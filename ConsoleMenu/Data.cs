using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleMenu
{

    public class DataStorage
    {
        public List<Student> Students { get; set; }
        public List<Group> Groups { get; set; }
        public List<Teacher> Teachers { get; set; }

        public List<Subject> Subjects { get; set; }



        private static DataStorage dataStorage;
        public static DataStorage Instance
        {
            get
            {
                if (dataStorage == null)
                    dataStorage = new DataStorage();
                return dataStorage;
            }
        }

        private DataStorage()
        {
            Students = new List<Student>();
            Groups = new List<Group>();
            Teachers = new List<Teacher>();
            Subjects = new List<Subject>();
        }

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }

    public class Student : Person
    {
        public Group Group { get; set; }

        public void GetInfo()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine($"Student: {FullName}");
            Console.WriteLine($"Group: {Group.Number}");
            Console.WriteLine();
            Console.WriteLine("<Press any key to continue>");
            Console.ReadKey();
        }
    }

    public class Teacher : Person
    {
        public List<Subject> Subjects { get; set; }
    }
    public class Group
    {
        public string Number { get; set; }
        public void GetInfo()
        {
            var studentsList = DataStorage.Instance.Students.Where(s => s.Group == this).Select(s => s.FullName);
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine($"Group: {Number}");
            Console.WriteLine($"Students:");
            Console.WriteLine(string.Join(", ", studentsList));
            Console.WriteLine();
            Console.WriteLine("<Press any key to continue>");
            Console.ReadKey();

        }
    }

    public class Subject
    {
        public string Title { get; set; }
    }
}
