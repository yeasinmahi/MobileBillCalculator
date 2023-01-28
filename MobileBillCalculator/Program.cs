using System.Globalization;

Console.Write("Start time:"); 
var s = Console.ReadLine()?.ToUpper();
Console.Write("End time:");
var e = Console.ReadLine()?.ToUpper();
if (DateTime.TryParseExact(s, "yyyy-MM-dd hh:mm:ss tt", null, DateTimeStyles.None, out DateTime startTime) && 
    DateTime.TryParseExact(e, "yyyy-MM-dd hh:mm:ss tt", null, DateTimeStyles.None, out DateTime endTime))
{
    
    TimeSpan pulse= new TimeSpan(0,0,20);

    TimeSpan startPeak= new TimeSpan(9,0,0);
    TimeSpan endPeak= new TimeSpan(22,59,59);
    //TimeSpan startOffPeak = new TimeSpan(23, 0, 0);
    //TimeSpan endOffPeak = new TimeSpan(8, 59, 59);

    DateTime currentTemp = startTime + pulse;
    double TotalPaisa = 0;
    double paisa = 0;
    do
    {
        if((startTime >= new DateTime(currentTemp.Year,currentTemp.Month,currentTemp.Day)+startPeak &&
            startTime <= new DateTime(currentTemp.Year, currentTemp.Month, currentTemp.Day)  + endPeak) ||
            currentTemp >= new DateTime(currentTemp.Year, currentTemp.Month, currentTemp.Day) + startPeak &&
            currentTemp <= new DateTime(currentTemp.Year, currentTemp.Month, currentTemp.Day) + endPeak)
        {
            paisa = 30;
        }
        else
        {
            paisa = 20;
        }
        TotalPaisa+= paisa;
        TimeSpan sec = pulse;
        if (currentTemp > endTime)
        {
            sec = endTime-startTime;
        }
        Console.WriteLine($"{startTime} + {sec.TotalSeconds} seconds\n({currentTemp}) = {paisa} paisa\n");
        startTime = currentTemp;
        currentTemp = startTime + pulse;

    } while (startTime <= endTime);
    Console.WriteLine($"Sample Output: {TotalPaisa/100} Taka");
}
else
{
    Console.WriteLine("Wrong Date format input");
}




