using System;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Models
{
    public class TimeReport : IComparable<TimeReport>
    {
        
        public string empID {get; set;}
        public string weekday {get; set;}
        public DateTime dayofwork {get; set;}
        public string clockinHour {get; set;}
        public string clockoutHour {get; set;}
        public double total {get; set;}
        public int timelogID {get; set;}

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