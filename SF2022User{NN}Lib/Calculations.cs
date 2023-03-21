using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User_NN_Lib
{
    public class Calculations
    {
        public static string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            if (startTimes == null)
            {
                return null;
            }
            if (durations == null)
            {
                return null;
            }
            if (beginWorkingTime == null)
            {
                return null;
            }
            if (endWorkingTime == null)
            {
                return null;
            }
            TimeSpan[,] periods = new TimeSpan[startTimes.Length, 2];
            if (startTimes.Length == durations.Length)
            {
                for (int i = 0; i < startTimes.Length; i++)
                {
                    periods[i, 0] = startTimes[i];
                    periods[i, 1] = startTimes[i].Add(new TimeSpan(0, durations[i], 0));
                }
            }
            else
            {
                return null;
            }

            TimeSpan[] start = new TimeSpan[0];
            TimeSpan[] end = new TimeSpan[0];
            int j = 0;
            for (TimeSpan i = beginWorkingTime; i <= endWorkingTime; i = i.Add(new TimeSpan(0, consultationTime, 0)))
            {
                if (i == endWorkingTime)
                {
                    if (i.Subtract(new TimeSpan(0, consultationTime, 0)) == periods[j, 1])
                    {
                        Array.Resize(ref start, start.Length + 1);
                        Array.Resize(ref end, end.Length + 1);
                        start[start.Length - 1] = i.Subtract(new TimeSpan(0, consultationTime, 0));
                        end[end.Length - 1] = i;
                    }
                }
                else if (i < periods[j, 0])
                {
                    if (periods[j, 0] < i.Add(new TimeSpan(0, consultationTime, 0)) && i.Add(new TimeSpan(0, consultationTime, 0)) < periods[j, 1])
                    {
                        i = periods[j, 1];
                        continue;
                    }
                    Array.Resize(ref start, start.Length + 1);
                    Array.Resize(ref end, end.Length + 1);
                    start[start.Length - 1] = i;
                    end[end.Length - 1] = i.Add(new TimeSpan(0, consultationTime, 0));
                }
                else
                {
                    if (i == periods[j, 1])
                    {
                        Array.Resize(ref start, start.Length + 1);
                        Array.Resize(ref end, end.Length + 1);
                        start[start.Length - 1] = i;
                        end[end.Length - 1] = i.Add(new TimeSpan(0, consultationTime, 0));
                        j++;
                        continue;
                    }
                    i = periods[j, 1];
                    if (j != periods.GetLength(0) - 1 && periods[j, 1] == periods[j + 1, 0])
                    {
                        i = periods[j + 1, 1];
                        Array.Resize(ref start, start.Length + 1);
                        Array.Resize(ref end, end.Length + 1);
                        start[start.Length - 1] = i;
                        end[end.Length - 1] = i.Add(new TimeSpan(0, consultationTime, 0));
                    }
                    j++;
                }
            }

            string[] result = new string[0];
            for (int i = 0; i < start.Length; i++)
            {
                Array.Resize(ref result, result.Length + 1);
                result[i] = $"{start[i].ToString(@"hh\:mm")}-{end[i].ToString(@"hh\:mm")}";
            }
            return result;
        }
    }
}
