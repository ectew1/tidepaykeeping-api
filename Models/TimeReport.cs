using System;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Models
{
    public class TimeReport : IComparable<TimeReport>
    {
        public string empID {get; set;}
        public DateTime dayofwork {get; set;}
        public DateTime clockIn {get; set;}
        public DateTime clockOut {get; set;}
        
        
        public double totalHours{get; set;}

        
        
        // public override string ToString()
        // {
        //     return $"TimelogID: {emp} \nClock-In: {clockIn} \nClock-Out: {clockOut}";
        // }

        public int CompareTo(TimeReport temp) //since I am using IComparable, I need a CompareTo for "contract"
        { 
            return -this.empID.CompareTo(temp.empID); 
        }
    }
}