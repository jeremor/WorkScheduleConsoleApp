// See https://aka.ms/new-console-template for more information
using WorkScheduleApp;
using WorkScheduleApp.Models;

DateTime date = DateTime.Today;
Console.WriteLine("Please add today's working hours");
Console.WriteLine("Add starting time. (hh:mm)");
string? startTime = Console.ReadLine();
Console.WriteLine("Add end time. (hh:mm)");
string? endTime = Console.ReadLine();

WorkTimeValidator validator = new WorkTimeValidator();
if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
{
    WorkTime workTime = validator.AddWorkTimes(date, startTime, endTime);
    Console.WriteLine(workTime.Message);

    if (!workTime.Error)
    {
        Console.WriteLine("Would you like to see the shift's length? (y/n)");
        string? answer = Console.ReadLine();
        if (!string.IsNullOrEmpty(answer) && !string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
        {
            decimal workShiftLegth = validator.ReturnWorkShiftLength(date, startTime, endTime);
            Console.WriteLine($"Today's shift was {workShiftLegth} hours");
        }
    }
}
else
{
    Console.WriteLine("Please add start and end times correctly.");
}
