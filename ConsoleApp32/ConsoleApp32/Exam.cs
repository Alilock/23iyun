using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp32
{
    internal class Exam
    {
        public string Student;
        public double Point;
        public string Subject;
        public DateTime StartTime;
        public  DateTime EndTime;
        public TimeSpan Duration
        {
            get=> EndTime - StartTime;
           
        }

        public void ShowExams()
        {
            Console.WriteLine($"{Student}, Qiymeti:{Point}, Fenn:{Subject}, Imtahan tarixi:{StartTime}, imtahan muddeti:{Duration} ");
        }
    }
}
