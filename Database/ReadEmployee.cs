using System.Security.AccessControl;
using System.Collections.Generic;
using System;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;
using MySql.Data.MySqlClient;

namespace tidepaykeeping_api.Database
{
    public class ReadEmployee : IReadAllEmployees, IReadOneEmployee
    {
        public List<Employee> Get()
        {
            List<Employee> employees = new List<Employee>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from employee ORDER BY empID DESC";

                using var cmd = new MySqlCommand(stm, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employees.Add(new Employee()
                    {
                        empID = rdr.GetString(0),
                        empFName = rdr.GetString(1),
                        empLName = rdr.GetString(2),
                        salaryByHr = rdr.GetInt32(3),
                        empRole = rdr.GetString(4),
                        empEmail = rdr.GetString(5),
                        empPassword = rdr. GetString(6),
                        managerID = rdr.IsDBNull(7) ? null : rdr.GetString(7)
                    });
                }
                return employees;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Employee Get(int id)
        {
            Employee myEmployee = new Employee();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                //prepared statements to prevent sql injections
                string stm = @"SELECT * from employee WHERE empID = @id";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                return new Employee()
                {
                    empID = rdr.GetString(0),
                    empFName = rdr.GetString(1),
                    empLName = rdr.GetString(2),
                    salaryByHr = rdr.GetInt32(3),
                    empRole = rdr.GetString(4),
                    empEmail = rdr.GetString(5),
                    empPassword = rdr.GetString(6),
                    managerID = rdr.IsDBNull(7) ? null : rdr.GetString(7)
                };
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Employee GetOne(string empEmail, string empPassword)
        {
            Employee myEmployee = new Employee();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from employee WHERE empEmail = @empEmail and empPassword = @empPassword";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@empEmail", empEmail);
                cmd.Parameters.AddWithValue("@empPassword", empPassword);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                return new Employee()
                {
                    empID = rdr.GetString(0),
                    empFName = rdr.GetString(1),
                    empLName = rdr.GetString(2),
                    salaryByHr = rdr.GetInt32(3),
                    empRole = rdr.GetString(4),
                    empEmail = rdr.GetString(5),
                    empPassword = rdr.GetString(6),
                    managerID = rdr.IsDBNull(7) ? null : rdr.GetString(7)
                };
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }
    }
}