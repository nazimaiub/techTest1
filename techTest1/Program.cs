using System;

namespace techTest1
{
    class Program
    {
        static void Main(string[] args)
        {
           //this is input dates for test
            DateTime startTime= new DateTime(2019,08,31, 08, 59, 13);
            DateTime endTime = new DateTime(2019, 08, 31, 09, 00,39);
            
            var totalCallingtimeInSeconds = System.Math.Abs((startTime - endTime).TotalSeconds);
            
            //20 second pulse
            double pulseNo = totalCallingtimeInSeconds / 20;
            
            int roundedPulseNo = Convert.ToInt32(Math.Ceiling(pulseNo));
            
            bool result = isOffPickHour(startTime, endTime);
            if (result == true)
            {
                //when offpick hour
                double bill = roundedPulseNo * 20;
                double convertedBill = bill / 100;
                Console.WriteLine(convertedBill+"Tk");

                Console.Write("offpickhour");
               
            }
            else
            {
                //when pick hour
                double bill = roundedPulseNo * 30;
                double convertedBill = bill / 100;
                Console.WriteLine(convertedBill + "Tk");
            }
            Console.ReadKey();
        }

        public static bool isOffPickHour(DateTime start,DateTime end)
        {
            //creating offpick datetime
            DateTime offpictimeStart1 = start.Date + new TimeSpan(12, 00, 00);
            DateTime offpictimeEnd1 = start.Date + new TimeSpan(08, 59, 59);
            DateTime offpictimeStart2 = start.Date + new TimeSpan(23, 00, 00);
            DateTime offpictimeEnd2 = start.Date + new TimeSpan(23, 59, 59);

            //taking only time part
            TimeSpan offpicStartTime1 = offpictimeStart1.TimeOfDay;
            TimeSpan offpicEndTime1 = offpictimeEnd1.TimeOfDay;
            TimeSpan offpicStartTime2 = offpictimeStart2.TimeOfDay;
            TimeSpan offpicEndTime2 = offpictimeEnd2.TimeOfDay;

            //taking only time part from input datetimes
            TimeSpan startTime = start.TimeOfDay;
            TimeSpan endTime = end.TimeOfDay;

            if (startTime >= offpicStartTime1 && startTime <= offpicEndTime1 && endTime >= offpicStartTime1 && endTime <= offpicEndTime1)
            {
                Console.Write("offpickhour");
                //Console.Write(startTime);
                return true;
            }
            else if (startTime >= offpicStartTime2 && startTime <= offpicEndTime2 && endTime >= offpicStartTime2 && endTime <= offpicEndTime2)
            {
                Console.Write("offpickhour");
               // Console.Write(startTime);
                return true;
            }
            else
            {
               
                return false;

            }
            
          

        }
    }
}
