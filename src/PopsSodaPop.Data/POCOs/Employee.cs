using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Employee
{
    /*
        Employee employee = new Employee(arg, arg);
    */
    public Employee(){}
    public Employee(string firstName, string lastName) // parameters
    {
        FirstName = firstName; // 1st param / 1st arg
        LastName = lastName; // 2nd param / 2nd arg
    }

    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
