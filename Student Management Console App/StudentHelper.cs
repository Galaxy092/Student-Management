using MenuLib;
using RestClientLib;
using StudentLib;

namespace Student_Management_Console_App
{
    public static class StudentHelper
    {
        public static string BaseUrl { get; set; } = "https://localhost:5001";

        public static MenuBank MenuBank { get; set; } = new MenuBank()
        {
            Title = "Student Management",
            Menus = new List<Menu>()
        {
            new Menu(){ Text= "Viewing", Action=ViewingStudents},
            new Menu(){ Text= "Creating", Action=CreatingStudents},
            new Menu(){ Text= "Updating", Action=UpdatingStudents},
            new Menu(){ Text= "Deleting", Action=DeletingStudents},
            new Menu(){ Text= "Exiting", Action=ExitingProgram}
        }
        };
        public static void ExitingProgram()
        {
            Console.WriteLine("\n[Exiting Program]");
            Environment.Exit(0);
        }
        private static void DeletingStudents()
        {
            Task.Run(async () =>
            {
                RestClient<Student> restClient = new(BaseUrl);
                Console.WriteLine("\n[Deleting Student]");
                while (true)
                {
                    Console.Write("Student Id/Code: ");
                    var key = Console.ReadLine() ?? "";
                    var endpoint = $"api/students/{key}";
                    var result = await restClient.DeleteAsync<Result<string>>(endpoint);
                    if (result!.Data != null)
                    {
                        Console.WriteLine($"Successfully delete the student with id/code, {key}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to delete a student with id/code, {key}");
                    }

                    if (WaitForEscPressed("ESC to stop or any key for more deleting ..."))
                    {
                        break;
                    }
                }
            }).Wait();
        }
        private static void UpdatingStudents()
        {
            Task.Run(async () =>
            {
                RestClient<Student> restClient = new(BaseUrl);
                Console.WriteLine("\n[Updating Students]");
                while (true)
                {
                    Console.Write("Student Id/Code(required): ");
                    var key = Console.ReadLine() ?? "";
                    var endpoint = "api/students";
                    Console.Write("New Name (optional)  : ");
                    var name = Console.ReadLine();

                    Console.WriteLine($"Major available: {Enum.GetNames<Major>().Aggregate((a, b) => a + ", " + b)}");
                    Console.Write("New Major: ");
                    var category = Console.ReadLine();

                    var result = await restClient.PutAsync<StudentUpdateReq, Result<string>>(endpoint, new StudentUpdateReq()
                    {
                        Key = key,
                        Name = name,
                        Major = category
                    });

                    if (result!.Data != null)
                    {
                        Console.WriteLine($"Successfully update the student with id/code, {key}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to update the student with id/code, {key}");
                    }

                    Console.WriteLine();
                    if (WaitForEscPressed("ESC to stop or any key for more updating...")) break;
                }
            }).Wait();
        }
        private static bool WaitForEscPressed(string text)
        {
            Console.Write(text); ;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.WriteLine(keyInfo.KeyChar);
            return keyInfo.Key == ConsoleKey.Escape;
        }
        private static void CreatingStudents()
        {
            Task.Run(async () =>
            {
                RestClient<Student> restClient = new(BaseUrl);
                Console.WriteLine("\n[Creating Major]");
                var endpoint = "api/students";
                while (true)
                {
                    var req = GetCreateStudentt();
                    if (req != null)
                    {
                        var result = await restClient.PostAsync<StudentCreateReq, Result<string>>(endpoint, req);
                        var id = result!.Data;
                        if (!string.IsNullOrEmpty(id))
                            Console.WriteLine($"Successfully created a new major with id, {id}");
                        else
                            Console.WriteLine($"Failed to create a new major code, {req.Code}");
                    }

                    Console.WriteLine();
                    if (WaitForEscPressed("ESC to stop or any key for more creating...")) break;
                }
            }).Wait();
        }
        static StudentCreateReq? GetCreateStudentt()
        {
            Console.WriteLine($"Major available: {Enum.GetNames<Major>().Aggregate((a, b) => a + ", " + b)}");
            Console.Write("Student(code/name/major): ");
            string data = Console.ReadLine() ?? "";
            var dataParts = data.Split("/");
            if (dataParts.Length < 3)
            {
                Console.WriteLine("Invalid create student's data");
                return null;
            }
            var code = dataParts[0].Trim();
            var name = dataParts[1].Trim();
            var category = dataParts[2].Trim();

            return new StudentCreateReq() { Code = code, Name = name, Major = category };

        }
        private static void ViewingStudents()
        {
            Task.Run(async () =>
            {
                RestClient<Student> restClient = new(BaseUrl);
                Console.WriteLine("\n[Viewing Students]");
                var endpoint = "api/students";
                var result = await restClient.GetAsync<Result<List<StudentResponse>>>(endpoint) ?? new();
                var all = result!.Data ?? new();
                var count = all.Count;
                Console.WriteLine($"Students: {count}");
                if (count == 0) return;

                Console.WriteLine($"{"Id",-36} {"Code",-10} {"Name",-30} {"Major",-20} {"Grade", -10}");
                Console.WriteLine(new string('=', 36 + 1 + 10 + 1 + 30 + 1 + 20 + 10));
                foreach (var prd in all)
                {
                    Console.WriteLine($"{prd.Id,-36} {prd.Code,-10} {prd.Name,-30} {prd.Major,-20} {prd.Grade,-10}");
                }
            }).Wait();
        }
    }
}
