using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkScheduleApp.Models;

namespace WorkScheduleApp
{
    public class WorkTimeValidator
    {
        public WorkTime AddWorkTimes(DateTime date, string startTime, string endTime)
        {
            try
            {
                bool error = false;
                DateTime startDateTime = date.Add(TimeSpan.Parse(startTime));
                DateTime endDateTime = date.Add(TimeSpan.Parse(endTime));
                string message = "";

                TimeSpan difference = endDateTime - startDateTime;
                double hours = difference.TotalHours;
                if (!CheckWorkShiftLength(hours))
                {
                    error = true;
                    message = "Worktime should be less than 16 hours";
                    return new WorkTime() { Error = error, Message = message};
                }
                if (!CheckStartAndEndTimes(startDateTime, endDateTime))
                {
                    error = true;
                    message = "Please check the times. Shift cannot start after the end time.";
                    return new WorkTime() { Error = error, Message = message };
                }

                message = "Work shift data added succesfully.";
                return new WorkTime() { Error = error, Message = message };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Boolean CheckWorkShiftLength(double hours)
        {
            if (hours > 16)
            {
                return false;
            }
            return true;
        }

        public Boolean CheckStartAndEndTimes(DateTime startDateTime, DateTime endDateTime)
        {
            if (startDateTime > endDateTime)
            {
                return false;
            }
            return true;
        }

        public decimal ReturnWorkShiftLength(DateTime date, string startTime, string endTime)
        {
            DateTime startDateTime = date.Add(TimeSpan.Parse(startTime));
            DateTime endDateTime = date.Add(TimeSpan.Parse(endTime));

            TimeSpan difference = endDateTime - startDateTime;
            decimal hours = (decimal)difference.TotalHours;
            hours = decimal.Round(hours, 2, MidpointRounding.AwayFromZero);
            return hours;
        }
    }
}
