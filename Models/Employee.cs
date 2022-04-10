using System;
using tidepaykeeping_api.Database;

namespace tidepaykeeping_api.Models
{
    public class Employee : IComparable<Employee>
    {
        // auto implemented properties
        public string empID {get; set;}
        public string empFName {get; set;}
        public string empLName {get; set;}
        public double salaryByHr {get; set;}
        public string empRole {get; set;}
        public string empEmail {get; set;}
        public string empPassword {get; set;}
        public string managerID {get; set;}

        public override string ToString()
        {
            return SongTitle + " (ID: " + SongID + ", Added " + SongTimestamp + ")";
        }

        // public string ToFile(){
        //     return SongID + "#" + SongTitle + "#" + SongTimestamp + "#" + Deleted;
        // }

        public int CompareTo(Employee temp) // since I am using IComparable, I need a CompareTo for "contract"
        { 
            return -this.SongTimestamp.CompareTo(temp.SongTimestamp); // negative sign allows the timestamps to be sorted in descending order
        }
    }
}