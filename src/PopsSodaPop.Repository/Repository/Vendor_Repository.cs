using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace PopsSodaPop.Repository.Repository
// {
    public class Vendor_Repository
    {
        // mock db
        private readonly List<Vendor> _vendorDatabase = new List<Vendor>();
        private int _count;

        // CREATE / Post
        public bool AddVendorToDatabase(Vendor vendor)
        {
            if (vendor != null)
            {
                _count++;
                vendor.ID = _count;
                _vendorDatabase.Add(vendor);
                return true;
            }
            else
            {
                return false;
            }
        }


        // Read / Get
        // ALL
        public List<Vendor> GetAllVendors()
        {
            return _vendorDatabase;
        }

        // One
        public Vendor GetVendorByID(int id)
        {
            foreach(Vendor v in _vendorDatabase)
            {
                if(v.ID == id)
                {
                    return v;
                }
            }

            return null;
        }

    }
// }