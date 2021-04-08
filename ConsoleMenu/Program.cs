using System;
using System.Collections;
using System.Collections.Generic;



namespace ConsoleMenu
{
    class Program


    {
        public static Menu mainMenu = new Menu(24, 15, "Main Menu");
        public static Menu studentMenu = new Menu(24, 12, "Students");
        public static Menu grMenu = new Menu(24, 15, "Groups");
        public static Menu teachMenu = new Menu(24, 15, "Teachers");
        public static Menu subjMenu = new Menu(24, 15, "Subjects");
        static void GetStudentInfo()
        {
            //Create choice menu and update menu items of choose menu
            Menu chooseStudent = new Menu(40, 15, "Choose student");
            chooseStudent.menuItems = new List<Menu.MenuItem>();
            chooseStudent.esc = studentMenu.Activate;
            for (int i = 0; i < DataStorage.Instance.Students.Count; i++)
            {

                Menu.MenuItem Item = new Menu.MenuItem { Caption = DataStorage.Instance.Students[i].FullName, itemAction = DataStorage.Instance.Students[i].GetInfo };
                Item.itemAction += studentMenu.Activate;
                chooseStudent.menuItems.Add(Item);
            }
            chooseStudent.Activate();
        }

        static void GetTeacherInfo()
        {
            //Create choice menu and update menu items of choose menu
            Menu chooseTeacher = new Menu(40, 15, "Choose teacher");
            chooseTeacher.menuItems = new List<Menu.MenuItem>();
            chooseTeacher.esc = teachMenu.Activate;
            for (int i = 0; i < DataStorage.Instance.Teachers.Count; i++)
            {
                Menu.MenuItem Item = new Menu.MenuItem { Caption = DataStorage.Instance.Teachers[i].FullName, itemAction = DataStorage.Instance.Teachers[i].GetInfo };
                Item.itemAction += teachMenu.Activate;
                chooseTeacher.menuItems.Add(Item);
            }
            chooseTeacher.Activate();
        }

        static void GetSublectInfo()
        {
            //Create choice menu and update menu items of choose menu
            Menu chooseSubj = new Menu(40, 15, "Choose subject");
            chooseSubj.menuItems = new List<Menu.MenuItem>();
            chooseSubj.esc = subjMenu.Activate;
            for (int i = 0; i < DataStorage.Instance.Subjects.Count; i++)
            {
                Menu.MenuItem Item = new Menu.MenuItem { Caption = DataStorage.Instance.Subjects[i].Title, itemAction = DataStorage.Instance.Subjects[i].GetInfo };
                Item.itemAction += chooseSubj.Activate;
                chooseSubj.menuItems.Add(Item);
            }
            chooseSubj.Activate();
        }


        static void GetGroupInfo()
        {
            //Create choice menu and update menu items of choose menu
            Menu chooseGroup = new Menu(15, 15, "Choose group");
            chooseGroup.menuItems = new List<Menu.MenuItem>();
            chooseGroup.esc = subjMenu.Activate;
            for (int i = 0; i < DataStorage.Instance.Groups.Count; i++)
            {
                Menu.MenuItem Item = new Menu.MenuItem { Caption = DataStorage.Instance.Groups[i].Number, itemAction = DataStorage.Instance.Groups[i].GetInfo };
                Item.itemAction += chooseGroup.Activate;
                chooseGroup.menuItems.Add(Item);
            }
            chooseGroup.Activate();
        }

        static void Exit()
        {
            Environment.Exit(0);
        }
        static void Main(string[] args)


        {
            //Initialization of some data objects
            //groups
            Group gr1 = new Group { Number = "C1" };
            Group gr2 = new Group { Number = "C2" };
            DataStorage.Instance.Groups.Add(gr1);
            DataStorage.Instance.Groups.Add(gr2);

            //students
            Student student1 = new Student { FirstName = "Ivan", LastName = "Ivanov", Group = gr1 };
            Student student2 = new Student { FirstName = "Petr", LastName = "Petrov", Group = gr1 };
            Student student3 = new Student { FirstName = "Akakii", LastName = "Bashmachkin", Group = gr2 };
            Student student4 = new Student { FirstName = "Vasiliy", LastName = "Alexandrov", Group = gr2 };

            DataStorage.Instance.Students.Add(student1);
            DataStorage.Instance.Students.Add(student2);
            DataStorage.Instance.Students.Add(student3);
            DataStorage.Instance.Students.Add(student4);

            //subjects

            Subject subject1 = new Subject { Title = "Computer Science" };
            Subject subject2 = new Subject { Title = "C#" };
            Subject subject3 = new Subject { Title = "JavaScript" };
            Subject subject4 = new Subject { Title = "HTML" };

            DataStorage.Instance.Subjects.Add(subject1);
            DataStorage.Instance.Subjects.Add(subject2);
            DataStorage.Instance.Subjects.Add(subject3);
            DataStorage.Instance.Subjects.Add(subject4);

            //teachers

            Teacher teacher1 = new Teacher { FirstName = "Arkadii", LastName = "vasiliev" };
            teacher1.Subjects = new List<Subject> { subject1, subject2 };
            Teacher teacher2 = new Teacher { FirstName = "Petr", LastName = "Kabanevich" };
            teacher2.Subjects = new List<Subject> { subject3, subject4 };

            DataStorage.Instance.Teachers.Add(teacher1);
            DataStorage.Instance.Teachers.Add(teacher2);



            //MainMenuActions
            mainMenu.esc = Exit;
            Menu.MenuItem mMItem0 = new Menu.MenuItem { Caption = "Students DB", itemAction = studentMenu.Activate };
            Menu.MenuItem mMItem1 = new Menu.MenuItem { Caption = "Groups DB", itemAction = grMenu.Activate };
            Menu.MenuItem mMItem2 = new Menu.MenuItem { Caption = "Subjects DB", itemAction = subjMenu.Activate };
            Menu.MenuItem mMItem3 = new Menu.MenuItem { Caption = "Teachers DB", itemAction = teachMenu.Activate };
            Menu.MenuItem mMitem4 = new Menu.MenuItem { Caption = "Exit", itemAction = Exit };
            mainMenu.menuItems = new List<Menu.MenuItem> { mMItem0, mMItem1, mMItem2, mMItem3, mMitem4 };



            //StudentActions
            studentMenu.esc = mainMenu.Activate;  //Action on esc pressed

            Menu.MenuItem sAItem0 = new Menu.MenuItem { Caption = "Get info", itemAction = GetStudentInfo }; //action chooseStudent menu for choice
            Menu.MenuItem sAItem1 = new Menu.MenuItem { Caption = "Add student", itemAction = Exit };
            Menu.MenuItem sAItem2 = new Menu.MenuItem { Caption = "Edit", itemAction = Exit };
            Menu.MenuItem sAItem3 = new Menu.MenuItem { Caption = "Main menu", itemAction = mainMenu.Activate };
            studentMenu.menuItems = new List<Menu.MenuItem> { sAItem0, sAItem1, sAItem2, sAItem3 };

            //TeacherActions
            teachMenu.esc = mainMenu.Activate;  //Action on esc pressed

            Menu.MenuItem tAItem0 = new Menu.MenuItem { Caption = "Get info", itemAction = GetTeacherInfo }; //action chooseStudent menu for choice
            Menu.MenuItem tAItem1 = new Menu.MenuItem { Caption = "Add teacher", itemAction = Exit };
            Menu.MenuItem tAItem2 = new Menu.MenuItem { Caption = "Edit teacher", itemAction = Exit };
            Menu.MenuItem tAItem3 = new Menu.MenuItem { Caption = "Main menu", itemAction = mainMenu.Activate };
            teachMenu.menuItems = new List<Menu.MenuItem> { tAItem0, tAItem1, tAItem2, tAItem3 };

            //SubjActions
            subjMenu.esc = mainMenu.Activate;  //Action on esc pressed

            Menu.MenuItem sbjAItem0 = new Menu.MenuItem { Caption = "Get info", itemAction = GetSublectInfo }; //action chooseStudent menu for choice
            Menu.MenuItem sbjAItem1 = new Menu.MenuItem { Caption = "Add subject", itemAction = Exit };
            Menu.MenuItem sbjAItem2 = new Menu.MenuItem { Caption = "Edit subject", itemAction = Exit };
            Menu.MenuItem sbjAItem3 = new Menu.MenuItem { Caption = "Main menu", itemAction = mainMenu.Activate };
            subjMenu.menuItems = new List<Menu.MenuItem> { sbjAItem0, sbjAItem1, sbjAItem2, sbjAItem3 };

            //SubjActions
            grMenu.esc = mainMenu.Activate;  //Action on esc pressed

            Menu.MenuItem grAItem0 = new Menu.MenuItem { Caption = "Get info", itemAction = GetGroupInfo }; //action chooseStudent menu for choice
            Menu.MenuItem grAItem1 = new Menu.MenuItem { Caption = "Add group", itemAction = Exit };
            Menu.MenuItem grAItem2 = new Menu.MenuItem { Caption = "Edit group", itemAction = Exit };
            Menu.MenuItem grAItem3 = new Menu.MenuItem { Caption = "Main menu", itemAction = mainMenu.Activate };
            grMenu.menuItems = new List<Menu.MenuItem> { grAItem0, grAItem1, grAItem2, grAItem3 };


            static bool ValidatePerson(Person person)
            {
                Type t = typeof(Person);
                object[] attrs = t.GetCustomAttributes(false);
                foreach (NameFirstSymbolValidation attr in attrs)
                {
                    if ((char.IsUpper((person.FirstName[0])) == attr.FirstLetterIsUpper) &
                            (char.IsUpper((person.LastName[0])) == attr.FirstLetterIsUpper))
                        return true;
                    else return false;
                }
                return true;
            }

            bool student1Validate = ValidatePerson(student1);
            bool teacher1Validate = ValidatePerson(teacher1);

            Console.WriteLine($"{student1.FullName} validation is {student1Validate}");
            Console.WriteLine($"{teacher1.FullName} validation is {teacher1Validate}");


            //mainMenu.Activate();




        }
    }
}

