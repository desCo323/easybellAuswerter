using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasybellAuswerter
{
    public class TimeCheck
    {
        public  TimeCheck()
        {

        }
        public bool istinOeffnungszeit(DateTime timestamp)
        {
            // Aktuelles Datum und Uhrzeit erhalten
            DateTime now = timestamp;

            // Öffnungszeiten für jeden Wochentag festlegen
            Dictionary<DayOfWeek, List<(TimeSpan, TimeSpan)>> openingHours = new Dictionary<DayOfWeek, List<(TimeSpan, TimeSpan)>>
{
                { DayOfWeek.Monday, new List<(TimeSpan, TimeSpan)> { (new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) } },
                { DayOfWeek.Tuesday, new List<(TimeSpan, TimeSpan)> { (new TimeSpan(12, 30, 0), new TimeSpan(16, 0, 0)) } },
                { DayOfWeek.Wednesday, new List<(TimeSpan, TimeSpan)> { (new TimeSpan(8, 0, 0), new TimeSpan(11, 0, 0)) } },
                { DayOfWeek.Thursday, new List<(TimeSpan, TimeSpan)> { (new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) } },
                { DayOfWeek.Friday, new List<(TimeSpan, TimeSpan)> { (new TimeSpan(8, 0, 0), new TimeSpan(11, 0, 0)) } },
                { DayOfWeek.Saturday, new List<(TimeSpan, TimeSpan)> { (TimeSpan.MinValue, TimeSpan.MinValue) } }, // Geschlossen
                { DayOfWeek.Sunday, new List<(TimeSpan, TimeSpan)> { (TimeSpan.MinValue, TimeSpan.MinValue) } }   // Geschlossen
};

            // Wochentag des aktuellen Datums erhalten
            DayOfWeek currentDayOfWeek = now.DayOfWeek;

            // Aktuelle Uhrzeit
            TimeSpan currentTime = now.TimeOfDay;

            // Überprüfen, ob die aktuelle Uhrzeit in einem der Öffnungszeitintervalle liegt
            if (openingHours.ContainsKey(currentDayOfWeek))
            {
                List<(TimeSpan, TimeSpan)> openingIntervals = openingHours[currentDayOfWeek];
                foreach ((TimeSpan startTime, TimeSpan endTime) in openingIntervals)
                {
                    if (startTime == TimeSpan.MinValue && endTime == TimeSpan.MinValue)
                    {
                        //Console.WriteLine("Das Unternehmen ist am " + currentDayOfWeek + " geschlossen.");
                        return false;
                    }
                    if (currentTime >= startTime && currentTime <= endTime)
                    {
                        //Console.WriteLine("Das Unternehmen ist geöffnet.");
                        return true;
                    }
                }
            }

            //Console.WriteLine("Das Unternehmen ist geschlossen.");

            return false;
        
        }





    }
}
