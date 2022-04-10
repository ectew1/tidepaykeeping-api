using System;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Models
{
    public class Timelog : IComparable<Timelog>
    {
        public string timelogID {get; set;}
        public DateTime clockInDate {get; set;}
        public DateTime clockOutDate {get; set;}
        public DateTime clockInTime {get; set;}
        public DateTime clockOutTime {get; set;}
        

        public override string ToString()
        {
            return $"TimelogID: {timelogID} \nClock-In Date: {clockInDate} \nClock-Out Date: {clockOutDate} \nClock-In Time: {clockInTime} \nClock-Out Time: {clockOutTime}";
        }

        public int CompareTo(Timelog temp) //since I am using IComparable, I need a CompareTo for "contract"
        { 
            return -this.timelogID.CompareTo(temp.timelogID); 
        }
    }
}