using System;

namespace SmartClinicClient
{
    class Appointment
    {
        public static string Calculate(DateTime startAppointment, DateTime endAppointment, int minInterval)
        {
            var tempDateTime = new DateTime();
            var result = "";
            for (tempDateTime = startAppointment;
                tempDateTime <= endAppointment;
                tempDateTime = tempDateTime.AddMinutes(minInterval))
            {
                if (tempDateTime.AddMinutes(minInterval) <= endAppointment)
                {
                    result += $"'{tempDateTime.ToString()}', '{tempDateTime.AddMinutes(minInterval)}'\n";
                }
            }
            result = result.Remove(result.Length - 1, 1);
            return result;
        }
    }
}


