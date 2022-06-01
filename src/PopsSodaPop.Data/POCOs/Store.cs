using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Store
{
    /* NOTE: Constructor
        - Constructors help us define an object up creation (new-up).
        - Overloads provide us options as to how we generate that object.
    */
    public Store(){} // 1st overload. We can simply new-up an object with "new Store()"

    // Store storeName = new Store("Store A");
    public Store(string name) // 2nd overload. Passing a string argument allows us to define the name of our Store object.
    {
        Name = name;
    }
    public Store(string name, List<Employee> employees, List<Vendor> vendors) // 3rd overload. Passing these three different arguments allow us to set all the starting values of the Store object.
    {
        Name = name;
        Employees = employees;
        Vendors = vendors;
    }

    // NOTE: Properties
    public int ID { get; set; } // Unique Identifier. Set up creation.
    public string Name { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>(); // We are creating space in memory for our list of employees.
    public List<Vendor> Vendors { get; set; } = new List<Vendor>(); // Creating space in memory for our list of vendors.
}
