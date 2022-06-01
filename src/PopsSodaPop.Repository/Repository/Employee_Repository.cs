using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Employee_Repository
    {
        // mock database (db)
        private readonly List<Employee> _employeeDatabase = new List<Employee>();
        private int _count;  // placeholder for our IDs

        //NOTE: Create
        public bool AddEmployeeToDatabase(Employee employee)
        {
            if(employee != null)
            {
                _count++;
                employee.ID = _count;
                _employeeDatabase.Add(employee);
                return true;
            }
            else
            {
                return false;
            }
        }

        //NOTE: Read
        // Get ALL employees
        public List<Employee> GetAllEmployees()
        {
            return _employeeDatabase;
        }

        // Get ONE employee
        public Employee GetEmployeeByID(int id)
        {
            foreach(Employee e in _employeeDatabase)
            {
                // "e" represents a singular employee.
                if(e.ID == id)
                {
                    return e;
                }
            }

            return null;
        }

    }
