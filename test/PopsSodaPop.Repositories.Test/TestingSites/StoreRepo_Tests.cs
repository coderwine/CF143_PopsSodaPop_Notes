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
        
        //NOTE: Add Store to DB Test
        [Fact]
        public void AddStoreToDatabase_ShouldReturnTrue()
        {
            //Arrange
            var store = new Store("Soda Pop Shack");

            //Action
            var expectingTrue = _sRepo.AddStoreToDatabase(store);

            //Assert
            Assert.True(expectingTrue);
        }

        //NOTE: Get One Store
        [Fact]
        public void RetriveStoreDataByID_ShouldReturnCorrectID_True()
        {
            // Given = Arrange
            var indyStore = new Store("Bee Line");
            _sRepo.AddStoreToDatabase(indyStore);

            // When = Action
            var store = _sRepo.GetStoreByID(2); // With the above store creation, we will have two stores added to the "DB". This would make the ID of the indyStore "2".

            int actual = store.ID; // Targeting the objects ID
            int expected = 2; // Hard-coding what we expect to see.

            // Then = Assert
            Assert.Equal(expected, actual);
        }

        //NOTE: Get ALL Stores
        [Fact]
        public void GetAllStores_CountShouldMatch()
        {
            // Given / Arrange
            var store = new Store("Soda Pop Shack");
            var store2 = new Store("Bee Line");
            var store3 = new Store("7/11");

            // When / Action
            // Add to Repo (DB)
            _sRepo.AddStoreToDatabase(store);
            _sRepo.AddStoreToDatabase(store2);
            _sRepo.AddStoreToDatabase(store3);

            int expectedStoreCount = 4;
            int actual = _sRepo.GetAllStores().Count;

            // Then / Assert
            Assert.Equal(expectedStoreCount, actual);
        }

        //NOTE: Update Store 
        [Fact]
        public void UpdateStoreData_ShouldReturn_True()
        {
            // Arrange 
            // using variable created at the top

            // Action
            var oldStoreID = _store.ID;
            var newStoreValues = new Store("The Green Dragon", new List<Employee>
            {
                new Employee
                {
                    FirstName = "Frodo",
                    LastName = "Baggins"
                },
                new Employee{FirstName = "Samwise", LastName = "Gamgee"}
            },
            new List<Vendor>
            {
                new Vendor { Name = "Ent-Draught"}
            }
            ); // Created a new store with a Name, a couple employees, and 

            var expected = _sRepo.UpdateStoreData(oldStoreID, newStoreValues);
            
            // Assert
            Assert.True(expected);
        }

        //NOTE: Delete Store
        [Fact]
        public void DeleteStore_ShouldReturn_True()
        {
            //* Why should this return true?
            int oldStoreID = _store.ID;
            var expected = _sRepo.RemoveStoreFromDatabase(oldStoreID);
            Assert.True(expected);
            
        }

    }
