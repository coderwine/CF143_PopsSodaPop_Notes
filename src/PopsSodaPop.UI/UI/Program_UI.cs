using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace PopsSodaPop.UI.UI
// {
    public class Program_UI
    {
        //NOTE: Top
        // Repository (DB) connections
        private readonly Store_Repository _sRepo = new Store_Repository();
        private readonly Employee_Repository _eRepo = new Employee_Repository();
        private readonly Vendor_Repository _vRepo = new Vendor_Repository();

        public void Run()
        {
            SeedData();

            RunApplication();
        }

        //NOTE: Seed Data
        private void SeedData()
        {
            //Employees
            Employee bill = new Employee("Bill", "Waterson");
            Employee jim = new Employee("Jim", "Davis");
            Employee cathy = new Employee("Cathy", "Guisewite");
            Employee chuck = new Employee("Charles", "Schulz");
            Employee gary = new Employee("Gary", "Larson");

            _eRepo.AddEmployeeToDatabase(bill);
            _eRepo.AddEmployeeToDatabase(jim);
            _eRepo.AddEmployeeToDatabase(cathy);
            _eRepo.AddEmployeeToDatabase(chuck);
            _eRepo.AddEmployeeToDatabase(gary);

            //Vendor
            Vendor coke = new Vendor("Coca-Cola");
            Vendor pepper = new Vendor("Dr. Pepper");

            _vRepo.AddVendorToDatabase(coke);
            _vRepo.AddVendorToDatabase(pepper);

            //Stores
            Store storeA = new Store("Pops Soda Shack", new List<Employee>{jim, gary}, new List<Vendor> {coke});
            Store storeB = new Store("Mom Malt Mart");

            _sRepo.AddStoreToDatabase(storeA);
            _sRepo.AddStoreToDatabase(storeB);
        }

        public void RunApplication()
        {
            bool isRunning = true; // Our "key" or "on switch" for having our application running.

            while(isRunning)
            {
                Console.Clear(); // Clearing our console for user display.
                System.Console.WriteLine("=== Welcome to the Soda Shop ===");
                /*
                    Store:
                        - Add, View All, View One, Update, Delete
                    Employee:
                        - Add, View All, View One
                    Vendor:
                        - Add, View All, View One

                    - Exit Application 
                */

                System.Console.WriteLine(
                    "Please make a selection: \n"
                    + "=== Store Database === \n"
                    + " 1. Add Store \n"
                    + " 2. View All Stores \n"
                    + " 3. View a Store \n"
                    + " 4. Update Store \n"
                    + " 5. Delete Store \n"
                    + "---------------------- \n"
                    + "=== Employee Database === \n"
                    + " 6. Add Employee \n"
                    + " 7. View All Employee \n"
                    + " 8. View an Employee \n"
                    + "---------------------- \n"
                    + "=== Vendor Database === \n"
                    + " 9. Add Vendor \n"
                    + "10. View All Vendors \n"
                    + "11. View a Vendor \n"
                    + "---------------------- \n"
                    + " X. Close Application \n"
                );

                string userInput = Console.ReadLine();

                //NOTE: Switch Statement
                switch(userInput.ToLower())
                {
                    case "1":
                        Add a Store
                        // AddStoreToDatabase();
                        break;
                    case "2":
                        // View All Store
                        ViewAllStore();
                        break;
                    case "3":
                        // View A Store
                        ViewStoreByID();
                        break;
                    case "4":
                        // Update / Modify Store
                        UpdateStore();
                        break;
                    case "5":
                        // Delete Store
                        DeleteStore();
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "x":
                        // Close application
                        isRunning = CloseApplication();
                        break;

                    default:
                        System.Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }

        //NOTE: Store Methods
        private void AddStoreToDatabase() // Switch Option 1
        {
            Console.Clear();

            Store newStore = new Store(); // Creating a new store object.

            // Temporary containers that hold our different lists.
            var currentEmployees = _eRepo.GetAllEmployees();
            var currentVendors = _vRepo.GetAllVendors();

            System.Console.WriteLine("Please enter a name for the store: ");
            newStore.Name = Console.ReadLine();

            // Add Employees
            bool hasAssignedEmployee = false;
            while(!hasAssignedEmployee)
            {
                System.Console.WriteLine("Do you have any employees? y/n");
                string hasEmployees = Console.ReadLine().ToLower(); // setting ToLower() to catch either "Y" or "N" in place of lowercase.

                // Check user input
                if (hasEmployees == "y")
                {
                    foreach(var e in currentEmployees)
                    {
                        System.Console.WriteLine($"ID {e.ID}: {e.FirstName} {e.LastName}");
                    }

                    System.Console.WriteLine("Please select an employee ID number \n");
                    int employeeSelection = int.Parse(Console.ReadLine());
                    Employee selectedEmployee = _eRepo.GetEmployeeByID(employeeSelection);

                    if(selectedEmployee != null)
                    {
                        newStore.Employees.Add(selectedEmployee); // Targeting our store object. Using the Add() method to include the currently selected Employee to that list for THIS store object.
                        currentEmployees.Remove(selectedEmployee); // Using the Remove() method so that they are no longer in the roster to pull from.
                    }
                    else
                    {
                        System.Console.WriteLine($"Sorry, the employee with ID: {employeeSelection}");
                    }
                }
                else
                {
                    hasAssignedEmployee = true; // If user selects "n"
                }
            }

            // Add Vendor
            bool hasAssignedVendors = false;
            while(!hasAssignedVendors)
            {
                Console.WriteLine("Do you have any vendors? y/n");
                string userInputHasVendors = Console.ReadLine();

                if (userInputHasVendors.ToLower() == "y")
                {
                    //Display Vendors
                    foreach(var v in currentVendors)
                    {
                        System.Console.WriteLine($"{v.ID}: {v.Name}");
                    }

                    System.Console.WriteLine("Please select a vendor by ID: \n");
                    int userInputVendorSelection = int.Parse(Console.ReadLine());
                    Vendor selectedVendor = _vRepo.GetVendorByID(userInputVendorSelection);

                    //Checking user input
                    if (selectedVendor != null)
                    {
                        newStore.Vendors.Add(selectedVendor);
                        currentVendors.Remove(selectedVendor);
                    }
                    else
                    {
                        System.Console.WriteLine($"Sorry, the vendor with the ID: {userInputVendorSelection} doesn't exist.");
                    }
                }
                else
                {
                    hasAssignedVendors = true;
                }
            }

            bool isSuccessful = _sRepo.AddStoreToDatabase(newStore);
            if(isSuccessful)
            {
                System.Console.WriteLine($"Store: {newStore.Name} was added to the database!");
            }
            else
            {
                System.Console.WriteLine("Store failed to be added to the database.");
            }

            PressAnyKey();
        }

        private void ViewAllStore() // Switch Option 2
        {
            Console.Clear();

            System.Console.WriteLine("=== Store Listing ===");
            
            var storesInDB = _sRepo.GetAllStores(); // Accessing the repo methods to obtain the complete list.

            foreach(Store s in storesInDB)
            {
                DisplayStoreListing(s);
            }

            PressAnyKey();
        }

        //! Helper Method
        // methods that help other methods in handling various logic.
        private void DisplayStoreListing(Store store)
        {
            System.Console.WriteLine($"Store ID: {store.ID} \n Store Name: {store.Name}\n");
        }

        private void ViewStoreByID() // Switch Option 3
        {
            Console.Clear();

            System.Console.WriteLine("=== Store Details ===");
            var stores = _sRepo.GetAllStores(); // Pulling all stores to view each ID

            foreach(Store s in stores)
            {
                DisplayStoreListing(s);
            }

            try
            {
                System.Console.WriteLine("Please select a store by ID: \n");
                int userInput = int.Parse(Console.ReadLine());
                var selectedStore = _sRepo.GetStoreByID(userInput);

                if(selectedStore != null)
                {
                    DisplayStoreDetails(selectedStore);  
                }
                else
                {
                    System.Console.WriteLine($"Sorry, the store with the ID: {userInput} doesn't exist.");
                }
            }
            catch
            {
                System.Console.WriteLine("Sorry, invalid Selection.");
            }

            PressAnyKey();
        }

        private void DisplayStoreDetails(Store thisStore) // HELPER METHOD
        {
            Console.Clear();

            System.Console.WriteLine(
                $"Store ID: {thisStore.ID} \n"
                + $"Store Name: {thisStore.Name} \n"
            );

            // Listing Employees
            System.Console.WriteLine("--- Employees --- \n");
            if(thisStore.Employees.Count > 0)
            {
                foreach (var e in thisStore.Employees)
                {
                    DisplayEmployeeInfo(e);
                }
            }
            else
            {
                System.Console.WriteLine("There are no employees");
            }

            //Listing Vendors
            System.Console.WriteLine("-------------------------");
            System.Console.WriteLine("--- Vendor ---- \n");

            if(thisStore.Vendors.Count > 0)
            {
                foreach(var v in thisStore.Vendors)
                {
                    DisplayVendorInfo(v);
                }
            }
            else
            {
                System.Console.WriteLine("There are no vendors");
            }

            PressAnyKey();
        }

        private void UpdateStore() // Switch Option 4
        {
            Console.Clear();

            var availStores = _sRepo.GetAllStores();
            foreach (var s in availStores)
            {
                DisplayStoreListing(s);
            }

            System.Console.WriteLine("Please enter a valid Store ID: \n");
            int userInput = int.Parse(Console.ReadLine());
            var selectedStore = _sRepo.GetStoreByID(userInput);

            if(selectedStore != null)
            {
                Console.Clear();
                Store newStore = new Store(); // Creating a new object of store
                // Temp variables 
                var currentEmployees = _eRepo.GetAllEmployees();
                var currentVendors = _vRepo.GetAllVendors();

                System.Console.WriteLine("Please enter a Store Name: \n");
                newStore.Name = Console.ReadLine();

                // Add Employee
                bool hasAssignedEmployees = false;
                while(!hasAssignedEmployees)
                {
                    System.Console.WriteLine("Do you have any employees? y/n \n");
                    string employeeInput = Console.ReadLine().ToLower();

                    if(employeeInput == "y")
                    {
                        foreach(var e in currentEmployees)
                        {
                            System.Console.WriteLine($"{e.ID} {e.FirstName} {e.LastName}");
                        }

                        System.Console.WriteLine("Please select employee by ID: \n");
                        int employeeSelected = int.Parse(Console.ReadLine());
                        var selectedEmployee = _eRepo.GetEmployeeByID(employeeSelected);

                        if(selectedEmployee != null)
                        {
                            newStore.Employees.Add(selectedEmployee);
                            currentEmployees.Remove(selectedEmployee);
                        }
                        else
                        {
                            System.Console.WriteLine("Sorry, no employee.");
                        }
                    }
                    else
                    {
                        hasAssignedEmployees = true;
                    }
                }

                // Add Vendor
                bool hasAssignedVendors = false;
                while(!hasAssignedVendors)
                {
                    System.Console.WriteLine("Do you have any vendors? y/n \n");
                    string vendorInput = Console.ReadLine().ToLower();

                    if(vendorInput == "y")
                    {
                        foreach(var v in currentVendors)
                        {
                            System.Console.WriteLine($"{v.ID} {v.Name}");
                        }

                        System.Console.WriteLine("Please select vendor by ID: \n");
                        int vendorSelected = int.Parse(Console.ReadLine());
                        var selectedVendor = _vRepo.GetVendorByID(vendorSelected);

                        if(selectedVendor != null)
                        {
                            newStore.Vendors.Add(selectedVendor);
                            currentVendors.Remove(selectedVendor);
                        }
                        else
                        {
                            System.Console.WriteLine("Sorry, no vendor.");
                        }
                    }
                    else
                    {
                        hasAssignedVendors = true;
                    }
                }

                // User Response
                bool isSuccessful = _sRepo.UpdateStoreData(userInput, newStore); // Find original store by ID / input new infor within the newStore

                if(isSuccessful)
                {
                    System.Console.WriteLine("Success!");
                }
                else
                {
                    System.Console.WriteLine("Failure....");
                }

            }
            else
            {
                System.Console.WriteLine($"Sorry, the store with ID: {userInput} doesn't exist.");
            }

            PressAnyKey();
        }

        private void DeleteStore() // Switch Option 5
        {
            Console.Clear();

            System.Console.WriteLine("=== Store Removal Page === \n");
            var stores = _sRepo.GetAllStores();

            foreach(Store s in stores)
            {
                DisplayStoreListing(s);
            }

            try
            {
                System.Console.WriteLine("Please select a store by ID: \n");
                int userSelectedStore = int.Parse(Console.ReadLine());
                bool isSuccessful = _sRepo.RemoveStoreFromDatabase(userSelectedStore);

                if (isSuccessful)
                {
                    System.Console.WriteLine("Store was removed.");
                }
                else
                {
                    System.Console.WriteLine("Store could not be removed.");
                }
            }
            catch
            {
                System.Console.WriteLine("Sorry, invalid selection.");
            }

            PressAnyKey();
        }

        //NOTE: Employee Methods
        private void DisplayEmployeeInfo(Employee employee) // HELPER METHOD
        {
            System.Console.WriteLine(
                $" \tEmployee ID: {employee.ID} \n \tEmployee Name: {employee.FirstName} {employee.LastName} \n"
            );
        }

        //NOTE: Vendor Methods
        private void DisplayVendorInfo(Vendor vendor) // HELPER METHOD
        {
            System.Console.WriteLine(
                $" \tVendor ID: {vendor.ID} \n \tVendor Name: {vendor.Name} \n"
            );
        }

        //NOTE: Close App
        private bool CloseApplication()
        {
            Console.Clear();
            System.Console.WriteLine("Have a great day!");
            PressAnyKey();
            return false;
        }

        private void PressAnyKey()
        {
            System.Console.WriteLine("Press ANY KEY to continue...");
            Console.ReadKey();
        }

    }
// }