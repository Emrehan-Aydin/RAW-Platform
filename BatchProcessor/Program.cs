using System.Net.Http.Json;
using System.Timers;
using static System.Net.WebRequestMethods;

DateTime now = DateTime.Now;
TimeSpan timeToGo = new TimeSpan(23, 59, 59) - now.TimeOfDay;
double milisecondsToGo = timeToGo.TotalMilliseconds;

System.Timers.Timer timer = new System.Timers.Timer();
timer.Interval = milisecondsToGo;

TimeSpan time = TimeSpan.FromMilliseconds(milisecondsToGo);
string timeString = time.ToString(@"hh\:mm\:ss");

Console.WriteLine("Akışın Yenilenmesine " + timeString.ToString() + " Saat var");
timer.Elapsed += Timer_Elapsed;
timer.Start();
Console.ReadKey();

static void Timer_Elapsed(object sender, ElapsedEventArgs e) {
    HttpClient client = new HttpClient();
    client.GetAsync($"https://localhost:7213/api/Content/ProcessDailyContent/Music");
    client.GetAsync($"https://localhost:7213/api/Content/ProcessDailyContent/Video");
    client.GetAsync($"https://localhost:7213/api/Content/ProcessDailyContent/Draw");
    client.GetAsync($"https://localhost:7213/api/Content/ProcessDailyContent/Text");
    client.GetAsync($"https://localhost:7213/api/Content/ProcessDailyContent/Document");

}