// See https://aka.ms/new-console-template for more information
using SchoolCatalog;

namespace StudentManagementApp
{
    class Program
    {
        static void Main()
        {
            var catalog = new StudentCatalog();
            catalog.GenerateDefaultStudents();
            string menu = "Choose an option:\n" +
                          "1. Display all students\n" +
                          "2. Display a student by ID\n" +
                          "3. Add a student\n" +
                          "4. Remove a student\n" +
                          "5. Modify student data\n" +
                          "6. Modify student address\n" +
                          "7. Assign a grade to a student\n" +
                          "8. Display overall student average\n" +
                          "9. Display subject-wise average for a student\n" +
                          "10. Display students in descending order of average\n" +
                          "11. Exit\n" +
                          "Option = ";

            while (true)
            {
                Console.WriteLine(menu);
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        catalog.DisplayAllStudents();
                        break;
                    case "2":
                        Console.Write("Enter student ID: ");
                        int studentId = int.Parse(Console.ReadLine());
                        catalog.DisplayStudentById(studentId);
                        break;
                    case "3":
                        catalog.AddStudentFromConsole();
                        break;
                    case "4":
                        Console.Write("Enter student ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        catalog.RemoveStudentById(removeId);
                        break;
                    case "5":
                        Console.Write("Enter student ID to modify: ");
                        int modifyId = int.Parse(Console.ReadLine());
                        catalog.UpdateStudentData(modifyId);
                        break;
                    case "6":
                        Console.Write("Enter student ID to modify address: ");
                        int modifyAddressId = int.Parse(Console.ReadLine());
                        catalog.UpdateStudentAddress(modifyAddressId);
                        break;
                    case "7":
                        Console.Write("Enter student ID to assign grade: ");
                        int assignGradeId = int.Parse(Console.ReadLine());
                        catalog.AssignGradeToStudent(assignGradeId);
                        break;
                    case "8":
                        Console.Write("Enter student ID to display overall average: ");
                        int overallAverageId = int.Parse(Console.ReadLine());
                        catalog.DisplayOverallAverage(overallAverageId);
                        break;
                    case "9":
                        Console.Write("Enter student ID to display subject-wise average: ");
                        int subjectAverageId = int.Parse(Console.ReadLine());
                        catalog.DisplaySubjectWiseAverage(subjectAverageId);
                        break;
                    case "10":
                        catalog.DisplayStudentsInDescendingOrder();
                        break;
                    case "11":
                        return;
                    default:
                        Console.WriteLine("\nInvalid option chosen. Please try again.\n");
                        break;
                }
            }
        }
    }
}

