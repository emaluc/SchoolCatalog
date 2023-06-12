using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    internal class StudentCatalog
    {
        private List<Student> students = new List<Student>();

        public void GenerateDefaultStudents()
        {
            students = new List<Student>
            {
                new Student(1, "John", "Doe", 20, new Address("City1", "Street1", "1")),
                new Student(2, "Jane", "Smith", 22, new Address("City2", "Street2", "2")),
                new Student(3, "Michael", "Johnson", 21, new Address("City3", "Street3", "3")),
            };
        }

        public void DisplayAllStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void DisplayStudentById(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void AddStudentFromConsole()
        {
            Console.Write("Enter student ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter student first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter student last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter student age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter student city: ");
            string city = Console.ReadLine();
            Console.Write("Enter student street: ");
            string street = Console.ReadLine();
            Console.Write("Enter student number: ");
            string number = Console.ReadLine();

            var address = new Address(city, street, number);
            var student = new Student(id, firstName, lastName, age, address);

            students.Add(student);
            Console.WriteLine("Student added successfully.");
        }

        public void RemoveStudentById(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student removed successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void UpdateStudentData(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Enter new first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter new last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter new age: ");
                int age = int.Parse(Console.ReadLine());

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;

                Console.WriteLine("Student data updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void UpdateStudentAddress(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Enter new city: ");
                string city = Console.ReadLine();
                Console.Write("Enter new street: ");
                string street = Console.ReadLine();
                Console.Write("Enter new number: ");
                string number = Console.ReadLine();

                student.Address.City = city;
                student.Address.Street = street;
                student.Address.Number = number;

                Console.WriteLine("Student address updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void AssignGradeToStudent(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Enter the subject name: ");
                string subject = Console.ReadLine();
                Console.Write("Enter the grade: ");
                double grade = double.Parse(Console.ReadLine());

                student.Grades.Add(subject, grade);
                Console.WriteLine("Grade assigned successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DisplayOverallAverage(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                double average = student.Grades.Values.Average();
                Console.WriteLine($"Overall average for student {student.FirstName} {student.LastName}: {average}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DisplaySubjectWiseAverage(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Enter the subject name: ");
                string subject = Console.ReadLine();

                if (student.Grades.ContainsKey(subject))
                {
                    double subjectAverage = student.Grades[subject];
                    Console.WriteLine($"Subject-wise average for student {student.FirstName} {student.LastName} in {subject}: {subjectAverage}");
                }
                else
                {
                    Console.WriteLine($"No grades found for {subject}.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DisplayStudentsInDescendingOrder()
        {
            var sortedStudents = students.OrderByDescending(s => s.Grades.Values.Average());
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
        class Student
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public Address Address { get; set; }
            public Dictionary<string, double> Grades { get; set; }

            public Student(int id, string firstName, string lastName, int age, Address address)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                Address = address;
                Grades = new Dictionary<string, double>();
            }

            public override string ToString()
            {
                return $"ID: {Id}\nName: {FirstName} {LastName}\nAge: {Age}\nAddress: {Address.City}, {Address.Street}, {Address.Number}\n";
            }
        }
    }
}
