using System;
using System.Net.Http;

namespace Notes.PerformanceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance check started");
            Console.WriteLine("---------------------");
            CheckNotesPerformance();
            Console.ReadKey();  
        }

        static void CheckNotesPerformance()
        {
            HttpClient _client = new HttpClient();
            string url = "https://localhost:44398/api/External/performance/getnote";
            int limit = 100000;

            HttpResponseMessage response = _client.GetAsync(url).Result;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            Console.ForegroundColor = ConsoleColor.Green;
            if (int.Parse(responseBody) > limit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"Actual Performance: {responseBody}ms | Limit: {limit}ms");
           
        }
    }
}
