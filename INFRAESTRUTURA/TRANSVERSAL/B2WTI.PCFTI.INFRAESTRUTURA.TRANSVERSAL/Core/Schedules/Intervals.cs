
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Core.Schedules
{
    using System;

    public struct Intervals
    {

        private readonly JobSchedule schedule;

        public Intervals(JobSchedule schedule)
        {
            this.schedule = schedule;
        }

        public JobSchedule Milliseconds(long value)
        {
            return schedule.EveryInternal(System.TimeSpan.FromMilliseconds(value));
        }

        public JobSchedule Seconds(double value)
        {
            return schedule.EveryInternal(System.TimeSpan.FromSeconds(value));
        }

        public JobSchedule Minutes(double value)
        {
            return schedule.EveryInternal(System.TimeSpan.FromMinutes(value));
        }

        public JobSchedule Hours(double value)
        {
            return schedule.EveryInternal(System.TimeSpan.FromHours(value));
        }

        public JobSchedule Days(double value)
        {
            return schedule.EveryInternal(System.TimeSpan.FromDays(value));
        }

        public JobSchedule TimeSpan(TimeSpan value)
        {
            return schedule.EveryInternal(value);
        }
    }
}