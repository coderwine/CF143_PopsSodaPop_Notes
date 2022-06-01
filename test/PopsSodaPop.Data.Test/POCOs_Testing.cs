using System.Collections.Generic; // connects us to our POCOs collection
using Xunit; // Type of dotnet project 

namespace PopsSodaPop.Data;
/*
    What this file is doing:
        - POCO Testing
        - run this file with:
!           - dotnet test
                - *make sure that yo uare in the folder you want to test.
*/
public class UnitTest1
{
    //NOTE: Employee Test
    [Fact]
    /*
        Attributes of xUnit Testing
            Fact: 
                - Identify a "normal" unit test.
                - Takes no method arguments
            Theory:
                - expects one or more DataAttribute instances to supply the value.
    */
    public void CreateAnInstanceOf_Employee()
    {
        /*
        ! AAA Setup
            - Arrange
                - Create the basic build.
            - Act
                - Manipulate or set values to the basic build
            - Assert
                - Check if creation matchews what has been stored in memory.
        */

        //! Arrange
        Employee employee = new Employee("Peter", "Parker");
        employee.ID = 1;

        //! Act
        int expectedEmpID = 1;
        int actualEmpID = employee.ID;

        //! Assert
        Assert.Equal(expectedEmpID, actualEmpID);
        /*
            .Equal(firstArg, secondArg)
                - returns true/false (boolean)
                    - true if both args are the same.
                    - false if they are different.
        */
    }

    [Fact]
    public void CreateAnInstanceOf_Vendor()
    {
        // Arrange
        Vendor vendor = new Vendor("Coca-Cola");
        
        // Act
        string expected = "Coca-Cola";
        string actual = vendor.Name;

        // Assert
        Assert.Contains(expected, actual);
    }

    [Fact]
    public void CreateAnInstanceOf_Store()
    {
        // Arrange
        Store store = new Store();
        store.Employees = new List<Employee>
        {
            new Employee("Bruce", "Wayne")
        }; // Our Employee property has a return type of "List", we can generate a quick "list" (of 1 name) to test our store.

        // Act
        int expected = 1;
        int actual = store.Employees.Count;

        // Assert
        Assert.Equal(expected, actual);
    }
}