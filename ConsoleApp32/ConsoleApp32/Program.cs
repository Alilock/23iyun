
using System;
using System.Collections.Generic;

namespace ConsoleApp32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string countStr;
            int count;
            do
            {
                Console.WriteLine("Imtahan sayini qeyd edin: ");
                countStr = Console.ReadLine();
            } while (!int.TryParse(countStr, out count));
            List<Exam> exams= new List<Exam>(count);

            for (int i = 0; i < exams.Capacity; i++)
            {
                Console.WriteLine($"{i+1}. Telebenin adini yazin: ");
                string student = Console.ReadLine();
                Console.WriteLine($"{i+1}. Imtahan fennini yazin: ");
                string subject = Console.ReadLine();
                string pointStr;
                double point;
                do
                {
                    Console.WriteLine($"{i+1}. Telebenin qiymetini yazin: ");
                    pointStr= Console.ReadLine();
                } while (!double.TryParse(pointStr, out point));

                string startExamStr;
                DateTime startExam;
                do
                {
                    Console.WriteLine($"{i+1}. Imtahanin baslama tarixini yazin: ");
                    startExamStr= Console.ReadLine();

                } while (!DateTime.TryParse(startExamStr, out startExam));
                string endExamStr;
                DateTime endExam;
                do
                {
                    Console.WriteLine($"{i+1}. Imtahanin bitme tarixini yazin: ");
                    endExamStr= Console.ReadLine();
                } while (!DateTime.TryParse(endExamStr, out endExam));

                Exam exam1 = new Exam()
                {
                    Student = student,
                    Point = point,
                    Subject = subject,
                    StartTime = startExam,
                    EndTime = endExam
                };
                exams.Add(exam1);
            }

            var passExams = exams.FindAll(x => x.Point > 49);
            foreach (var item in passExams)
            {
                Console.WriteLine($"Imtahani kecmisdir:{item.Student}, Fenn:{item.Subject}, Point:{item.Point}, imtahan muddeti: {item.Duration}");
            }
            DateTime now = DateTime.UtcNow.AddHours(4);

            Console.WriteLine($"Son bir hefte erzinde olan imtahanlar:");

            var lastweekexams = exams.FindAll(x => (now < x.EndTime.AddDays(7)));
             foreach(var item in lastweekexams)
            {
                item.ShowExams();
            }

            TimeSpan ahour = TimeSpan.FromHours(1);

            var overahourexams = exams.FindAll(x => x.Duration > ahour);

            Console.WriteLine("Imtahan muddeti bir saatdan cox olan imtahanlar: '[[");
            foreach (var item in overahourexams)
            {
                item.ShowExams();
            }

        }
    }
}
