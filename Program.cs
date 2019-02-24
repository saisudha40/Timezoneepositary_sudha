using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            try
            {
                Parser timeZoneParser = new Parser();
                DateTime currentTime = DateTime.Now;
                using (Reader fileReader = new Reader())
                {
                    string str;
                    str = string.Empty;
                    StreamWriter sw = new StreamWriter(@"C:\Users\User\Downloads\Timezone-master\Timezone-master\Timezone\Timezones.txt");


                    List<Tuple<string, string>> lTimes = fileReader.Read();
                    foreach (Tuple<string, string> item in lTimes)
                    {
                        sw.WriteLine("The time in the UK is " + currentTime + " and the time in timezone " + item.Item2 + " is " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central European Standard Time"));

                        Console.WriteLine("The time in the UK is " + currentTime + " and the time in timezone " + item.Item2 + " is " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central European Standard Time"));
                        Console.WriteLine("Where " + currentTime + " is always treated as being UTC Dublin, Edinburgh, London.");
                    }
                    sw.Close();

                }

                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);

            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
    }

