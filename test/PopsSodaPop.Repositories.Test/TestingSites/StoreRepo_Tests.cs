using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit; // Part of C# software development kit (SDK). Required to run tests.


    public class StoreRepo_Tests
    {
        // ARRANGE
        // Private variables created but not initialized.

        private readonly Store_Repository _sRepo;
        private Store _store;
        private Vendor _vendor;
        private Employee _employee;
        // We want to be able to use any of these variables anywhere in the testing as we choose.

        // Constructor
        public StoreRepo_Tests()
        {
            _sRepo = new Store_Repository(); 
            _vendor = new Vendor("Coco-Cola");
            _employee = new Employee("Jane", "Doe");

            // _vendor & _employee are passing arg. to constructo objects with default values. ** track back later to see where these are flowing **
            _store = new Store("Pops Soda House", new List<Employee>{_employee}, new List<Vendor>{_vendor});
            _sRepo.AddStoreToDatabase(_store);
        }
        
    }
