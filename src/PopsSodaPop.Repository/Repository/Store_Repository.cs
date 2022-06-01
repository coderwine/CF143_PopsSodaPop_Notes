using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
NOTE: Creating class library project

    - within src folder
        dotnet new classlib -o [project name] 
            (our case was PopsSodaPop.Repository)

    - within project folder (PopsSodaPop_Student)
        dotnet sln add ./src/PopsSodaPop.Repository

    - within classlib folder (PopsSodaPop.Repository)
        dotnet add reference ../PopsSodaPop.Data
            - we reach out TO the source we want to reference

*/

// namespace PopsSodaPop.Repository.Repository
// {
    public class Store_Repository
    {
        /*
        ! CRUD
            C: Create (Post)
            R: Read (Get)
            U: Update (Put)
            D: Delete (Delete)
        
        Collection type to hold data:
            - List<T>
                - This references a a data type of List. Within the < > is meant to detail a "T"ype.
                - List<T> == List<Store>
        
        This list will be able to Add, Remove, Modify a store (Update), Give you a store (Read / Return), or Give a user all the stores it holds (Read / Return)
        */

        private readonly List<Store> _storeDataBase = new List<Store>(); // mock storage of stores. Underscore notes private variables.
        private int _count = 0;

        //NOTE: Create / Post
        // 1    2         3                4 
        public bool AddStoreToDatabase(Store store)
        {
            /*
                1. Accessor
                2. Return Type
                3. Method Name
                4. Parameters
                    - Seeking varibale that is a Store data type.
            */

            // Check to see if we even have a store to check
            if(store != null)
            {
                _count++; // Adding one to our private variable "count"
                store.ID = _count; // Setting our store object with an ID Value of the NOW updated _count.
                _storeDataBase.Add(store); // Using the Add() method [a method we can use for Lists] to add a store to our storeDataBase List.

                return true; // Providing feedback to user.
            }
            else
            {
                return false; // Providing feeback to user.
            }
        }

        //NOTE: Read / Get
        // Get All
        public List<Store> GetAllStores()
        {
            return _storeDataBase; // Our return type is of List<Store>, which is exactly what this variable return type is.
        }

        // Get ONE store
        public Store GetStoreByID(int id)
        {
            foreach(Store s in _storeDataBase) // using "s" to reference a single "store" in our List<Store> _storeDataBase.
            {
                if(s.ID == id)
                {
                    return s; // Method requires us to return a store.
                }
            }

            return null; // If no store match the id provided, return nothing/null.
        }

        //NOTE: Update / Put
        public bool UpdateStoreData(int storeID, Store newStoreData)
        {
            var oldStoreData = GetStoreByID(storeID); // Using the "Find One" method to locate and store it's returned value (Store) in our variable.

            if(oldStoreData != null)
            {
                oldStoreData.Name = newStoreData.Name;
                oldStoreData.Employees = newStoreData.Employees;
                oldStoreData.Vendors = newStoreData.Vendors;

                return true;
            }
            else
            {
                return false;
            }
        }

        //NOTE: Delete
        public bool RemoveStoreFromDatabase(int id)
        {
            var store = GetStoreByID(id);

            if(store != null)
            {
                _storeDataBase.Remove(store);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
// }