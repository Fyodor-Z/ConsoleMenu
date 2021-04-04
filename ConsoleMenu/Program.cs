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
            for (int i = 0; i < DataStorage.Instance.Students.Count; i++)
            {
                chooseStudent.esc = studentMenu.Activate;
                Menu.MenuItem Item = new Menu.MenuItem { Caption = DataStorage.Instance.Students[i].FullName, itemAction = DataStorage.Instance.Students[i].GetInfo };
                Item.itemAction += studentMenu.Activate;
                chooseStudent.menuItems.Add(Item);
            }
            chooseStudent.Activate();
        }

        static void GetTeacherInfo()
        {
            //Create choice menu and update menu items of choose menu
            Menu chooseStudent = new Menu(40, 15, "Choose teacher");
            chooseStudent.menuItems = new List<Menu.MenuItem>();
            for (int i = 0; i < DataStorage.Instance.Students.Count; i++)
            {
                chooseStudent.esc = studentMenu.Activate;
                Menu.MenuItem Item = new Menu.MenuItem { Caption = DataStorage.Instance.Students[i].FullName, itemAction = DataStorage.Instance.Students[i].GetInfo };
                Item.itemAction += studentMenu.Activate;
                chooseStudent.menuItems.Add(Item);
            }
            chooseStudent.Activate();
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

            Teacher teacher1 = new Teacher { FirstName = "Arkadii", LastName = "Vasiliev" };
            teacher1.Subjects = new List<Subject> { subject1, subject2 };
            Teacher teacher2 = new Teacher { FirstName = "Petr", LastName = "Kabanevich" };
            teacher2.Subjects = new List<Subject> { subject3, subject4 };
            
            //Menus initializtion

            //Menu mainMenu = new Menu(24, 15, "Main Menu");
            //Menu studentMenu = new Menu(24, 12, "Students");
            //Menu grMenu = new Menu(24, 15, "Groups");
            //Menu teachMenu = new Menu(24, 15, "Teachers");
            //Menu subjMenu = new Menu(24, 15, "Subjects");



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
            studentMenu.esc = mainMenu.Activate;  //Action on esc pressed

            Menu.MenuItem sAItem0 = new Menu.MenuItem { Caption = "Get info", itemAction = GetStudentInfo }; //action chooseStudent menu for choice
            Menu.MenuItem sAItem1 = new Menu.MenuItem { Caption = "Add teacher", itemAction = Exit };
            Menu.MenuItem sAItem2 = new Menu.MenuItem { Caption = "Edit teacher", itemAction = Exit };
            Menu.MenuItem sAItem3 = new Menu.MenuItem { Caption = "Main menu", itemAction = mainMenu.Activate };
            studentMenu.menuItems = new List<Menu.MenuItem> { sAItem0, sAItem1, sAItem2, sAItem3 };


            mainMenu.Activate();




        }
    }
}

