using System;

namespace LabTasks
{
    class Student
    {
        public string name;
        public int rollNumber;
        public float cgpa;
        public int matricMarks;
        public int fscMarks;
        public int ecatMarks;
        public string homeTown;
        public bool isHostelite;
        public bool isTakingScholarship;

        
        public float claculateMerit()
        {
            float fscPercentage = (fscMarks / 1100.0f) * 60.0f;
            float ecatPercentage = (ecatMarks / 400.0f) * 40.0f;
            return fscPercentage + ecatPercentage;
        }

        public bool isEligibleforScholarship(float meritPercentage)
        {
            if (meritPercentage > 80 && isHostelite == true)
            {
                return true;
            }
            return false;
        }
    }

    class Program1
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.name = "Ali";
            s1.rollNumber = 12;
            s1.fscMarks = 950;
            s1.ecatMarks = 320;
            s1.isHostelite = true;

            float merit = s1.claculateMerit();
            Console.WriteLine("Student Name: " + s1.name);
            Console.WriteLine("Merit: " + merit + "%");
            
            bool getsScholarship = s1.isEligibleforScholarship(merit);
            Console.WriteLine("Eligible for Scholarship: " + getsScholarship);
        }
    }
}