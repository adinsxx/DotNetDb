using System;
using System.IO;
namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {
                     // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();
            var file = "data.txt";
            if (resp == "1")
            {
              // create data file

                // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                // random number generator
                Random rnd = new Random();
                // create file
                StreamWriter sw = new StreamWriter("data.txt");
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");                    // add 1 week to date
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                 sw.Close();
            }
            else if (resp == "2")
            {
                // TODO: parse data file
                if (File.Exists(file)){
                    StreamReader reader = new StreamReader(file);
                    while(!reader.EndOfStream){
                        string line = reader.ReadLine();
                        string[] week = line.Split(',');
                        DateTime date = DateTime.Parse(week[0]);
                        int[] hours = Array.ConvertAll(week[1].Split('|'), int.Parse);
                        Console.WriteLine($"Week of {date:MMM},{date: dd},{date:yyyy}");
                        Console.WriteLine($"{"Sun", 4}{"Mon", 4}{"Tue", 4}{"Wed", 4}{"Thu", 4}{"Fri", 4}{"Sat", 4}");
                        Console.WriteLine($"{"--", 4}{"--", 4}{"--", 4}{"--", 4}{"--", 4}{"--", 4}{"--", 4}{"--", 4}{"--", 4}");
                        Console.WriteLine($"{hours[0], 4}{hours[1], 4}{hours[2], 4}{hours[3], 4}{hours[4], 4}{hours[5], 4}{hours[6], 4};");
                        Console.WriteLine();
                    }
                }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
            }
        }
    }
