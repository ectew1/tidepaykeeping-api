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