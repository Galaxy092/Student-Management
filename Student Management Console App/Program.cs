using Student_Management_Console_App;

StudentHelper.BaseUrl = "https://localhost:7258";
Console.WriteLine("Student Management");
StudentHelper.MenuBank.MenuSimulate(() => { Console.WriteLine(); });
