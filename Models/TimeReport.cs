using System;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Models
{
    public class TimeReport : IComparable<TimeReport>
    {
        public string empID {get; set;}
        public DateTime dayofwork {get; set;}
        public DateTime clockinHour {get; set;}
        public DateTime clockoutHour {get; set;}
        public double total {get; set;}

        // public TimeReport()
        // {

        // }
        
        public override string ToString()
        {
            return $"empID: {empID}";
        }

        public int CompareTo(TimeReport temp) //since I am using IComparable, I need a CompareTo for "contract"
        { 
            return -this.empID.CompareTo(temp.empID); 
        }
    }
}