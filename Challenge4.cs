using System;
using System.Collections.Generic;

namespace UAMS
{

    class Subject
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;

        public Subject(string c, string t, int ch, int f)
        {
            code = c; type = t; creditHours = ch; subjectFees = f;
        }
    }


    class DegreeProgram
    {
        public string title;
        public int duration;
        public int seats;
        public List<Subject> subjects = new List<Subject>();

        public DegreeProgram(string t, int d, int s)
        {
            title = t;
             duration = d; 
             seats = s;
        }

        public bool addSubject(Subject s)
        {
            int totalCH = 0;
            foreach (Subject sub in subjects) 
            { 
                totalCH += sub.creditHours; 
            }

            if (totalCH + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            return false;
        }
    }


    class Student
    {
        public string name;
        public int age;
        public float fscMarks;
        public float ecatMarks;
        public float merit;
        public List<DegreeProgram> preferences = new List<DegreeProgram>();
        public DegreeProgram admittedDegree = null;
        public List<Subject> registeredSubjects = new List<Subject>();

        public Student(string n, int a, float fsc, float ecat)
        {
            name = n; age = a;
             fscMarks = fsc; 
             
             ecatMarks = ecat;
            calculateMerit();
        }

        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100.0f) * 0.6f) + ((ecatMarks / 400.0f) * 0.4f)) * 100;
        }

        public bool regStudentSubject(Subject s)
        {
            int stCH = 0;
            foreach (Subject sub in registeredSubjects) 
            {
                 stCH += sub.creditHours; 
            }

            if (stCH + s.creditHours <= 9)
            {
                registeredSubjects.Add(s);
                return true;
            }
            return false;
        }

        public int calculateFee()
        {
            int totalFee = 0;
            foreach (Subject s in registeredSubjects)
             { 
                totalFee += s.subjectFees;
                 }
            return totalFee;
        }
    }

    class Program
    {
        static List<Student> studentList = new List<Student>();
        static List<DegreeProgram> programList = new List<DegreeProgram>();

        static void Main(string[] args)
        {
            int option = 0;
            while (option != 8)
            {
                Console.WriteLine("\n--- UAMS MAIN MENU ---");
                Console.WriteLine("1. Add Student\n2. Add Degree Program\n3. Generate Merit\n4. View Registered Students\n5. View Students of Specific Degree\n6. Register Subjects\n7. Calculate Fees\n8. Exit");
                Console.Write("Enter Option: ");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                 AddStudent();
                else if (option == 2)
                 AddDegree();
                else if (option == 3)
                 GenerateMerit();
                else if (option == 4) 
                ViewRegistered();
                else if (option == 5) 
                ViewSpecificDegree();
                else if (option == 6) 
                RegisterSubjects();
                else if (option == 7)
                
             CalculateTotalFees();
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter Name: ");
             string n = Console.ReadLine();
            Console.Write("Enter Age: "); 
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter FSC Marks: "); 
            float f = float.Parse(Console.ReadLine());
            Console.Write("Enter Ecat Marks: ");
             float e = float.Parse(Console.ReadLine());

            Student s = new Student(n, a, f, e);

            Console.WriteLine("Available Degrees:");
            for (int i = 0; i < programList.Count; i++) 
            { 
                Console.WriteLine(programList[i].title); 
            }

            Console.Write("How many preferences? ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter Preference Name: ");
                string pref = Console.ReadLine();
                foreach (DegreeProgram dp in programList)
                {
                    if (dp.title == pref) 
                    { 
                        s.preferences.Add(dp); 
                        }
                }
            }
            studentList.Add(s);
        }

        static void AddDegree()
        {
            Console.Write("Degree Name: "); 
            string t = Console.ReadLine();
            Console.Write("Duration: "); 
            int d = int.Parse(Console.ReadLine());
            Console.Write("Seats: "); 
            int s = int.Parse(Console.ReadLine());
            DegreeProgram dp = new DegreeProgram(t, d, s);

            Console.Write("How many subjects for this degree? ");
            int subCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < subCount; i++)
            {
                Console.Write("Subject Code: "); 
                string code = Console.ReadLine();
                Console.Write("Credit Hours: ");
                 int ch = int.Parse(Console.ReadLine());
                Console.Write("Subject Fees: ");
                 int fee = int.Parse(Console.ReadLine());
                dp.addSubject(new Subject(code, "Core", ch, fee));
            }
            programList.Add(dp);
        }

        static void GenerateMerit()
        {

            for (int i = 0; i < studentList.Count; i++)
            {
                for (int j = i + 1; j < studentList.Count; j++)
                {
                    if (studentList[j].merit > studentList[i].merit)
                    {
                        Student temp = studentList[i];
                        studentList[i] = studentList[j];
                        studentList[j] = temp;
                    }
                }
            }


            foreach (Student s in studentList)
            {
                foreach (DegreeProgram dp in s.preferences)
                {
                    if (dp.seats > 0 && s.admittedDegree == null)
                    {
                        s.admittedDegree = dp;
                        dp.seats--;
                        Console.WriteLine(s.name + " got admission in " + dp.title);
                        break;
                    }
                }
                if (s.admittedDegree == null) 
                {
                     Console.WriteLine(s.name + " did not get admission."); 
                     }
            }
        }

        static void ViewRegistered()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in studentList)
            {
                if (s.admittedDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }

        static void ViewSpecificDegree()
        {
            Console.Write("Enter Degree Title: ");
            string title = Console.ReadLine();
            foreach (Student s in studentList)
            {
                if (s.admittedDegree != null && s.admittedDegree.title == title)
                {
                    Console.WriteLine(s.name);
                }
            }
        }

        static void RegisterSubjects()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            foreach (Student s in studentList)
            {
                if (s.name == name && s.admittedDegree != null)
                {
                    Console.Write("Enter Subject Code: ");
                    string code = Console.ReadLine();
                    foreach (Subject sub in s.admittedDegree.subjects)
                    {
                        if (sub.code == code)
                        {
                            if (s.regStudentSubject(sub))
                             { 
                                Console.WriteLine("Subject Registered.");
                                 }
                            else 
                            { 
                                Console.WriteLine("Credit Hour limit exceeded (Max 9).");
                                 }
                        }
                    }
                }
            }
        }

        static void CalculateTotalFees()
        {
            foreach (Student s in studentList)
            {
                if (s.admittedDegree != null)
                {
                    Console.WriteLine(s.name + " has total fee: " + s.calculateFee());
                }
            }
        }
    }
}