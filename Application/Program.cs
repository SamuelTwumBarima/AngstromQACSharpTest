using Application;
using System.Globalization;
using System.Net.Http.Json;

using HttpClient client = new();

var canadaDateResponse = client.GetFromJsonAsync<WorldTimeAPIResponse>("http://worldtimeapi.org/api/timezone/America/Toronto").Result;
var canadaDateTime = DateTimeOffset.ParseExact(canadaDateResponse.datetime, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFzzz", CultureInfo.InvariantCulture);

// Edit: Set ukDateTime to DateTimeOffset in UTC to match the type and timezone of canadaDateTime for accurate comparison
var ukDateTime = DateTimeOffset.UtcNow;

var dateTimeFormatter = "dddd dd MMMM yyyy HH:mm:ss";

Console.WriteLine($"UK Time: {ukDateTime.ToString(dateTimeFormatter)}");

// Edit: changed "time" to "Time" to keep naming convention consistent 
Console.WriteLine($"Canada Time:  {canadaDateTime.ToString(dateTimeFormatter)}");


if (ukDateTime.Minute > canadaDateTime.Minute)
{
    // Edit: changed to canadaDateTime.DateTime & ukDateTime.DateTime to ensure the return type is DateTime for compatibility in Subtract method
    // Added extra string comment "minutes ahead of you" to be more clear
    Console.WriteLine($"You are {Math.Round(ukDateTime.DateTime.Subtract(canadaDateTime.DateTime).TotalMinutes, 0)} minutes ahead of Canada");
} 
else
{
    // Edit: changed to canadaDateTime.DateTime & ukDateTime.DateTime to ensure the return type is DateTime for compatibility in Subtract method
    // Added extra string comment "minutes ahead of you" to be more clear
    Console.WriteLine($"Canada is {Math.Round(canadaDateTime.DateTime.Subtract(ukDateTime.DateTime).TotalMinutes, 0)} minutes behind of you");
}

//public partial class Program { }
