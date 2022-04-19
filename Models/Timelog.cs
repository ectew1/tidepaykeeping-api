using System;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Models
{
    public class Timelog : IComparable<Timelog>
    {
        public int timelogID {get; set;}
        public DateTime clockIn {get; set;}
        public DateTime clockOut {get; set;}
        public string empID {get; set;}

        public Timelog()
        {
            clockIn = DateTime.Now;
            clockOut = new DateTime(2012, 12, 21, 3, 0, 0); //trigger value for clockOut is 12/21/2012 @3am (when the world was supposed to end in 2012 lol)
        }
        
        public override string ToString()
        {
            return $"TimelogID: {timelogID} \nClock-In: {clockIn} \nClock-Out: {clockOut}";
        }

        public int CompareTo(Timelog temp) //since I am using IComparable, I need a CompareTo for "contract"
        { 
            return -this.timelogID.CompareTo(temp.timelogID); 
        }
    }
}