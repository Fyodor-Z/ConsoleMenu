using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleMenu
{
    public class NameFirstSymbolValidation : System.Attribute
    {
        public bool FirstLetterIsUpper { get; set; }

        public NameFirstSymbolValidation()
        { }

        public NameFirstSymbolValidation(bool isUpper)
        {
            FirstLetterIsUpper = isUpper;
        }
    }

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

    [NameFirstSymbolValidation(true)]
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

        public void GetInfo()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine($"Teacher: {FullName}");
            Console.WriteLine($"Subjects:");
            Console.WriteLine(string.Join(", ", Subjects.Select(s=>s.Title)));
            Console.WriteLine();
            Console.WriteLine("<Press any key to continue>");
            Console.ReadKey();
        }
    }
    public class Group
    {
        public string Number { get; set; }
        public void GetInfo()
        {
            var studentsList = DataStorage.Instance.Students.Where(s => s.Group == this).Select(s => s.FullName).ToList();
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

        public void GetInfo()
        {
            var teachersList = DataStorage.Instance.Teachers.Where(t => t.Subjects.Contains(this)).Select(t => t.FullName).ToList();
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine($"Subject: {Title}");
            Console.WriteLine($"Teachers:");
            Console.WriteLine(string.Join(", ", teachersList));
            Console.WriteLine();
            Console.WriteLine("<Press any key to continue>");
            Console.ReadKey();
        }
    }
}
